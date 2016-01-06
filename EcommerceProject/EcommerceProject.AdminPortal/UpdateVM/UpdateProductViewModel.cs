using EcommerceProject.AdminPortal.ServiceHostReference;
using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EcommerceProject.AdminPortal.UpdateVM
{
  public class UpdateProductViewModel : INotifyPropertyChanged
  {
    DataRetrieverServiceClient client;

    public UpdateProductViewModel()
    {
      client = new ServiceHostReference.DataRetrieverServiceClient("TheService");
    }

    private ProductData _product;
    public ProductData product
    {
      get { return _product; }
      set
      {
        _product = value;
        onPropertyChanged("product");
      }
    }

    private void onPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    private ICommand _update;
    public ICommand update
    {
      get
      {
        if (_update == null)
        {
          _update = new Command(UpdateDetails, CanUpdateDetails);
        }
        return _update;
      }
      set
      {
        _update = value;
      }
    }

    private ICommand _find;
    public ICommand find
    {
      get
      {
        if (_find == null)
        {
          _find = new Command<string>(findProduct, canfindProduct);
        }
        return _find;
      }
      set { _find = value; }
    }

    private ICommand _goBack;
    public ICommand goBack
    {
      get
      {
        if (_goBack == null)
        {
          _goBack = new Command(GoBack, CanGoBack);
        }
        return _goBack;
      }
      set { _goBack = value; }
    }

    private bool CanGoBack()
    {
      return true;
    }

    private void GoBack()
    {
      MainWindowViewModel vm = App.Current.MainWindow.DataContext as MainWindowViewModel;
      vm.source = "FindVM/FindProductView.xaml";
    }

    private bool canfindProduct(string id)
    {
      return true;
    }

    private async void findProduct(string id)
    {
      if (!string.IsNullOrWhiteSpace(id))
      {
        product = await client.FindByIdAsync(id);
        if (product == null)
        {
          MessageBox.Show("The product with id " + id + " cannot be found.");
        }
      }
    }

    private bool CanUpdateDetails()
    {
      return true;
    }

    private void UpdateDetails()
    {
      if (product != null)
      {
        if (product.product_name == "")
        {
          MessageBox.Show("Please enter a Product Name");
        }
        else
        {
          client.UpdateProduct(product);
          MessageBox.Show("The product " + product.product_name + " has been updated");
        }
      }
    }



    public event PropertyChangedEventHandler PropertyChanged;
  }
}
