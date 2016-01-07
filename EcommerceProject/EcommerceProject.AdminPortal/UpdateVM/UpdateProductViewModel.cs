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
    string EmptyMessage = "This field can not be empty";
    Dictionary<String, bool> FinalResult = new Dictionary<String, bool>();
    List<string> BorderNames = new List<string>();


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


    private string _bordercolor_name;
    public string BorderColorName
    {
        get { return _bordercolor_name; }
        set
        {
            _bordercolor_name = value;
            onPropertyChanged("BorderColorName");
        }
    }
    private string _bordercolor_price;
    public string BorderColorPrice
    {
        get { return _bordercolor_price; }
        set
        {
            _bordercolor_price = value;
            onPropertyChanged("BorderColorPrice");
        }
    }

    private string _bordercolor_Tag1;
    public string BorderColorTag1
    {
        get { return _bordercolor_Tag1; }
        set
        {
            _bordercolor_Tag1 = value;
            onPropertyChanged("BorderColorTag1");
        }
    }

    private string _bordercolor_Tag2;
    public string BorderColorTag2
    {
        get { return _bordercolor_Tag2; }
        set
        {
            _bordercolor_Tag2 = value;
            onPropertyChanged("BorderColorTag2");
        }
    }

    private string _bordercolor_Tag3;
    public string BorderColorTag3
    {
        get { return _bordercolor_Tag3; }
        set
        {
            _bordercolor_Tag3 = value;
            onPropertyChanged("BorderColorTag3");
        }
    }

    private string _bordercolor_stock;
    public string BorderColorStock
    {
        get { return _bordercolor_stock; }
        set
        {
            _bordercolor_stock = value;
            onPropertyChanged("BorderColorStock");
        }
    }


    private string _bordercolor_img;
    public string BorderColorImg
    {
        get { return _bordercolor_img; }
        set
        {
            _bordercolor_img = value;
            onPropertyChanged("BorderColorImg");
        }
    }


    private string _bordercolor_description;
    public string BorderColorDesc
    {
        get { return _bordercolor_description; }
        set
        {
            _bordercolor_description = value;
            onPropertyChanged("BorderColorDesc");
        }
    }

    private String _tooltipMessageName;
    public String ToolTipMessageName
    {
        get
        {
            return _tooltipMessageName;
        }
        set
        {
            _tooltipMessageName = value;
            onPropertyChanged("ToolTipMessageName");
        }
    }

    private String _tooltipMessagePrice;
    public String ToolTipMessagePrice
    {
        get
        {
            return _tooltipMessagePrice;
        }
        set
        {
            _tooltipMessagePrice = value;
            onPropertyChanged("ToolTipMessagePrice");
        }
    }

    private String _tooltipMessageTag1;
    public String ToolTipMessageTag1
    {
        get
        {
            return _tooltipMessageTag1;
        }
        set
        {
            _tooltipMessageTag1 = value;
            onPropertyChanged("ToolTipMessageTag1");
        }
    }

    private String _tooltipMessageTag2;
    public String ToolTipMessageTag2
    {
        get
        {
            return _tooltipMessageTag2;
        }
        set
        {
            _tooltipMessageTag2 = value;
            onPropertyChanged("ToolTipMessageTag2");
        }
    }

    private String _tooltipMessageTag3;
    public String ToolTipMessageTag3
    {
        get
        {
            return _tooltipMessageTag3;
        }
        set
        {
            _tooltipMessageTag3 = value;
            onPropertyChanged("ToolTipMessageTag3");
        }
    }


    private String _tooltipMessageStock;
    public String ToolTipMessageStock
    {
        get
        {
            return _tooltipMessageStock;
        }
        set
        {
            _tooltipMessageStock = value;
            onPropertyChanged("ToolTipMessageStock");
        }
    }


    private String _tooltipMessageImageurl;
    public String ToolTipMessageImageurl
    {
        get
        {
            return _tooltipMessageImageurl;
        }
        set
        {
            _tooltipMessageImageurl = value;
            onPropertyChanged("ToolTipMessageImageurl");
        }
    }
    private String _tooltipMessageDesc;

    public String ToolTipMessageDesc
    {
        get
        {
            return _tooltipMessageDesc;
        }
        set
        {
            _tooltipMessageDesc = value;
            onPropertyChanged("ToolTipMessageDesc");
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
          BorderColorName = "Red";
          ToolTipMessageName = EmptyMessage;
        }
        else
        {
           
          client.UpdateProduct(product);
          MessageBox.Show("The product " + product.product_name + " has been updated");
        }
      }
    /*    if (validateInput())
        {
            client.UpdateProduct(product);
            MessageBox.Show("The product " + " " +product.product_name + " " +"has been updated");
        }
        else
        {
            MessageBox.Show("Failed!" + " " + "A Field/Some Fields are missing");
           /// GetFinalBorderColor();
        }*/
    }



    private void GetFinalBorderColor()
    {
        foreach (var item in FinalResult)
        {

            if (item.Value == false)
            {

                if (item.Key == "BorderColorName")
                {
                    BorderColorName = "Red";
                    ToolTipMessageName = EmptyMessage;
                }

                else if (item.Key == "BorderColorPrice")
                {
                    BorderColorPrice = "Red";
                    ToolTipMessagePrice = EmptyMessage;
                }

                else if (item.Key == "BorderColorTag1")
                {
                    BorderColorTag1 = "Red";
                    ToolTipMessageTag1 = EmptyMessage;
                }

                else if (item.Key == "BorderColorTag2")
                {
                    BorderColorTag2 = "Red";
                    ToolTipMessageTag2 = EmptyMessage;
                }

                else if (item.Key == "BorderColorTag3")
                {


                    BorderColorTag3 = "Red";
                    ToolTipMessageTag3 = EmptyMessage;
                }
                else if (item.Key == "BorderColorStock")
                {
                    BorderColorStock = "Red";
                    ToolTipMessageStock = EmptyMessage;
                }

                else if (item.Key == "BorderColorImg")
                {
                    BorderColorImg = "Red";
                    ToolTipMessageImageurl = EmptyMessage;
                }
                else
                {
                    BorderColorDesc = "Red";
                    ToolTipMessageDesc = EmptyMessage;
                }
            }

        }
    }
        
    private bool validateInput()
    {
        if (product.stock.HasValue && product.price.HasValue && product.product_name != null &&
        product.tag1 != null && product.tag2 != null &&
           product.tag3 != null && product.imageurl != null && product.description != null)
        {
            return true;
        }
        FinalResult.Add("BorderColorName", product.product_name != null);

        FinalResult.Add("BorderColorPrice", product.price.HasValue);
        FinalResult.Add("BorderColorTag1", product.tag1 != null);
        FinalResult.Add("BorderColorTag2", product.tag2 != null);
        FinalResult.Add("BorderColorTag3", product.tag3 != null);
        FinalResult.Add("BorderColorStock", product.stock.HasValue);
        FinalResult.Add("BorderColorImg", product.imageurl != null);
        FinalResult.Add("BorderColorDesc", product.description != null);

        BorderNames.Add("BorderColorName");
        BorderNames.Add("BorderColorPrice");
        BorderNames.Add("BorderColorTag1");
        BorderNames.Add("BorderColorTag2");
        BorderNames.Add("BorderColorTag3");
        BorderNames.Add("BorderColorStock");
        BorderNames.Add("BorderColorImg");
        BorderNames.Add("BorderColorDesc");

        return false;
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
