using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EcommerceProject.AdminPortal
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
      product.product_name = string.Empty;
      product.description = string.Empty;
      product.price = 0.00m;
      product.tag1 = string.Empty;
      product.tag2 = string.Empty;
      product.tag3 = string.Empty;
      product.stock = 0;
      product.imageurl = string.Empty;
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
      // yet to be implemented
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
