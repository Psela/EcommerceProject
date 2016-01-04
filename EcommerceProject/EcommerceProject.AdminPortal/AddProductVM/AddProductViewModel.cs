using EcommerceProject.AdminPortal.ServiceHostReference;
using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Add;
using EcommerceProject.DatabaseModel.Select;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EcommerceProject.AdminPortal.AddProductVM
{
  public class AddProductViewModel : INotifyPropertyChanged
  {

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

    public AddProductViewModel()
    {
      FindProduct findProduct = new FindProduct();
      ProductData productFound = findProduct.GetAllProducts().Last();
      product = new ProductData();
      product.p_id = productFound.p_id + 1;
    }

    private ICommand _resetButton;
    public ICommand ResetButton
    {
      get
      {
        if (_resetButton == null)
        {
          _resetButton = new Command(ResetAddPage, CanResetAddPage);
        }
        return _resetButton;
      }
      set
      {
        _resetButton = value;
        onPropertyChanged("ResetButton");
      }
    }

    private bool CanResetAddPage()
    {
      return true;
    }

    private void ResetAddPage()
    {
      product = new ProductData();
    }

    private ICommand _saveButton;
    public ICommand SaveButton
    {
      get
      {
        if (_saveButton == null)
        {
          _saveButton = new Command(SaveAddPage, CanSaveAddPage);
        }
        return _saveButton;
      }
      set
      {
        _saveButton = value;
        onPropertyChanged("SaveButton");
      }
    }

    private bool CanSaveAddPage()
    {
      return true;
    }

    private void SaveAddPage()
    {
      MessageBoxResult result = MessageBox.Show("Would you like to add the product", "Save",MessageBoxButton.YesNoCancel);
      switch (result)
      {
          case MessageBoxResult.No: ResetAddPageExceptId();
              break;

          case MessageBoxResult.Yes:
              {
                  DataRetrieverServiceClient client = new DataRetrieverServiceClient();
                  client.CreateNewProductItem(product);
                  MessageBox.Show("Success" + "The product:" + " " + product.product_name + " " + product.p_id + "was added");
              break;
              }
      }

    }

    private void ResetAddPageExceptId()
    {
        product.price = 0.00m;
        product.product_name = "";
        product.stock = 0;
        product.tag1 = "";
        product.tag2 = "";
        product.tag3 = "";

    }

    private bool validateInput()
    {
        return true;
      
    }

    private string _bordercolor;
    public string BorderColor
    {
      get { return _bordercolor; }
      set
      {
        _bordercolor = value;
        onPropertyChanged("BorderColor");
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void onPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }


  }
}
