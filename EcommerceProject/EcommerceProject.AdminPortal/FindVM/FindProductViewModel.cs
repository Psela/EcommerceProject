using EcommerceProject.DatabaseModel;
using EcommerceProject.Server;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace EcommerceProject.AdminPortal.FindVM
{
  public class FindProductViewModel : INotifyPropertyChanged
  {
    IDataRetrieverService client;

    private ICommand _EditButton;
    public ICommand EditButton
    {
      get
      {
        if (_EditButton == null)
        {
          _EditButton = new Command(GoToUpdatePage, CanGoToUpdatePage);
        }
        return _EditButton;
      }
      set
      {
        _EditButton = value;
      }
    }

    private ICommand _search;
    public ICommand search
    {
      get
      {
        if (_search == null)
        {
          _search = new Command(Search, CanSearch);
        }
        return _search;
      }
      set
      {
        _search = value;
      }
    }

    private ICommand _RemoveButton;
    public ICommand RemoveButton
    {
      get
      {
        if (_RemoveButton == null)
        {
          _RemoveButton = new Command(Remove, CanRemove);
        }
        return _RemoveButton;
      }
      set
      {
        _RemoveButton = value;
      }
    }

    private string _SearchBox;
    public string SearchBox
    {
      get { return _SearchBox; }
      set
      {
        _SearchBox = value;
        onPropertyChanged("SearchBox");
      }
    }

    private ProductData _productTemp;
    public ProductData productTemp
    {
      get { return _productTemp; }
      set
      {
        _productTemp = value;
        onPropertyChanged("productTemp");
      }
    }

    public FindProductViewModel()
    {
      var factory = new ChannelFactory<IDataRetrieverService>("BasicHttpBinding_IDataRetrieverService");
      client = factory.CreateChannel();
    }

    public FindProductViewModel(IDataRetrieverService databaseReader)
    {
      client = databaseReader;
    }

    public bool CanRemove()
    {
      return true;
    }

    public void Remove()
    {
      int id = 0;
      if (int.TryParse(SearchBox, out id))
      {
        if (productTemp.p_id == id)
        {
          MessageBoxResult result = MessageBox.Show("You are about to remove " + productTemp.product_name + ". \n Do you want to continue", "RemoveWarning", MessageBoxButton.YesNoCancel);
          switch (result)
          {
            case MessageBoxResult.Cancel:
              return;
            case MessageBoxResult.No:
              return;
            case MessageBoxResult.Yes:
              client.RemoveById(Convert.ToInt32(SearchBox));
              MessageBox.Show(productTemp.product_name + " has been removed.");
              return;
          }

        }
      }

      MessageBox.Show("You cannot remove this item as you haven't checked it is the right one \n Please press the search button.");
    }

    public bool CanSearch()
    {
      return true;
    }

    public void Search()
    {
      if (!string.IsNullOrWhiteSpace(SearchBox))
      {
        productTemp = client.FindById(SearchBox);
      }
    }

    public bool CanGoToUpdatePage()
    {
      return true;
    }

    public void GoToUpdatePage()
    {
      MainWindowViewModel vm = App.Current.MainWindow.DataContext as MainWindowViewModel;
      vm.source = "UpdateVM/UpdateProductView.xaml";
    }

    public void onPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private ServiceHostReference.IDataRetrieverService dataRetrieverService;
  }
}
