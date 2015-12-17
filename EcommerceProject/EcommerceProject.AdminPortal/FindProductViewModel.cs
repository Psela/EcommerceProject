using EcommerceProject.DataModel;
using EcommerceProject.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EcommerceProject.AdminPortal
{
  public class FindProductViewModel : INotifyPropertyChanged
  {
    public DatabaseReader dbReader { get; set; }

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
    }
    private bool CanSearch()
    {
      return true;
    }

    private void Search()
    {
      if (!string.IsNullOrWhiteSpace(SearchBox))
      {
        int id = 0;
        if (int.TryParse(SearchBox, out id))
        {
          Product product = dbReader.GetAllProducts().Where<Product>(x => x.id == Convert.ToInt32(SearchBox)).First();
          Name = product.name;
          Description = product.description;
          Price = product.price;
          Tag1 = product.tag1;
          Tag2 = product.tag2;
          Tag3 = product.tag3;
          Stock = product.stock;
        }
      }
    }

    private bool CanGoToUpdatePage()
    {
      return true;
    }

    private void GoToUpdatePage()
    {
      MainWindowViewModel vm = App.Current.MainWindow.DataContext as MainWindowViewModel;
      vm.source = "UpdateProductView.xaml";
    }

    private void onPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
