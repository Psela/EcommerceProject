using EcommerceProject.DatabaseModel.Delete;
using EcommerceProject.DataModel;
using EcommerceProject.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EcommerceProject.AdminPortal
{
  public class FindProductViewModel : INotifyPropertyChanged
  {
    public DatabaseReader dbReader { get; set; }

    RemoveProduct rm;
    Product product;

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

    private string _Name;
    public string Name
    {
      get { return _Name; }
      set
      {
        _Name = value;
        onPropertyChanged("Name");
      }
    }

    private string _Description;
    public string Description
    {
      get { return _Description; }
      set
      {
        _Description = value;
        onPropertyChanged("Description");
      }
    }

    private double _Price;
    public double Price
    {
      get { return _Price; }
      set
      {
        _Price = value;
        onPropertyChanged("Price");
      }
    }

    private string _Tag1;
    public string Tag1
    {
      get { return _Tag1; }
      set
      {
        _Tag1 = value;
        onPropertyChanged("Tag1");
      }
    }

    private string _Tag2;
    public string Tag2
    {
      get { return _Tag2; }
      set
      {
        _Tag2 = value;
        onPropertyChanged("Tag2");
      }
    }

    private string _Tag3;
    public string Tag3
    {
      get { return _Tag3; }
      set
      {
        _Tag3 = value;
        onPropertyChanged("Tag3");
      }
    }

    private string _imageurl;
    public string imageurl
    {
      get { return _imageurl; }
      set
      {
        _imageurl = value;
        onPropertyChanged("imageurl");
      }
    }

    private int _Stock;
    public int Stock
    {
      get { return _Stock; }
      set
      {
        _Stock = value;
        onPropertyChanged("Stock");
      }
    }

    public FindProductViewModel()
    {
      dbReader = new DatabaseReader(new DataRetrieverService());
      rm = new RemoveProduct();
    }

    public FindProductViewModel(DatabaseReader databaseReader, RemoveProduct removeProduct)
    {
      dbReader = databaseReader;
      rm = removeProduct;
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
        if (product.id == id)
        {
          MessageBoxResult result = MessageBox.Show("You are about to remove " + product.name + ". \n Do you want to continue", "RemoveWarning", MessageBoxButton.YesNoCancel);
          switch (result)
          {
            case MessageBoxResult.Cancel:
              return;
            case MessageBoxResult.No:
              return;
            case MessageBoxResult.Yes:
              rm.DeleteProductByID(Convert.ToInt32(SearchBox));
              MessageBox.Show(product.name + " has been removed.");
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
        int id = 0;
        if (int.TryParse(SearchBox, out id))
        {
          product = new Product();
          List<Product> listOfFoundProducts = dbReader.GetAllProducts().Where<Product>(x => x.id == Convert.ToInt32(SearchBox)).ToList();
          if (listOfFoundProducts.Count == 1)
          {
            product = listOfFoundProducts.First();
          }

          Name = product.name;
          Description = product.description;
          Price = product.price;
          Tag1 = product.tag1;
          Tag2 = product.tag2;
          Tag3 = product.tag3;
          Stock = product.stock;
          imageurl = product.imageurl;
        }
      }
    }

    public bool CanGoToUpdatePage()
    {
      return true;
    }

    public void GoToUpdatePage()
    {
      MainWindowViewModel vm = App.Current.MainWindow.DataContext as MainWindowViewModel;
      vm.source = "UpdateProductView.xaml";
    }

    public void onPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private RemoveProduct removeProduct;
    private DatabaseReader databaseReader;
  }
}
