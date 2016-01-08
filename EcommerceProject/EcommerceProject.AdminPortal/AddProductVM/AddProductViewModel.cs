using EcommerceProject.AdminPortal.ServiceHostReference;
using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Add;
using EcommerceProject.DatabaseModel.Select;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EcommerceProject.AdminPortal.AddProductVM
{
    public class AddProductViewModel : INotifyPropertyChanged
    {
        IDataRetrieverService client;
        Dictionary<String, bool> FinalResult = new Dictionary<String, bool>();
        List<string> BorderNames = new List<string>();
        string EmptyMessage = "This field can not be empty";

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
            var factory = new ChannelFactory<IDataRetrieverService>("TheService");
            client = factory.CreateChannel();
            //Made the Id generator Async
            Task.Run(() => GetProductLastID()).Wait();
        }

        private async void GetProductLastID()
        {
            ProductData productFound = await Task.Run(() => client.ReadData().Last());
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
                    _resetButton = new Command(ResetAddPageExceptId, CanResetAddPage);
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
            Task.Run(() => GetProductLastID()).Wait();

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
            MessageBoxResult result = MessageBox.Show("Would you like to add the product", "Save", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.No: ResetAddPageExceptId();
                    break;

                case MessageBoxResult.Yes:
                    {
                        if (validateInput())
                        {
                            client.CreateNewProductItem(product);
                            MessageBox.Show("Success:" + " " + "The product:" + "  " + product.product_name + "   " + product.p_id + " " + "was added");
                        }
                        else
                        {
                            MessageBox.Show("Failed!" + " " + "A Field/Some Fields are missing");

                            GetFinalBorderColor();

                            }
                      
                        }

                        break;

                    }

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

                    else if (item.Key == "BorderColorTag3"){

                   
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
        

        private void ResetAddPageExceptId()
        {
            //  product.price = 0.00m;

            product.product_name = "";
            product.stock = 0;
            product.tag1 = "";
            product.tag2 = "";
            product.tag3 = "";
            product.description = "";
            product.stock = 0;
            product.imageurl = "";
            product.price = 0.00m;
            BorderColorName = "";
            BorderColorPrice = "";
            BorderColorImg = "";
            BorderColorStock = "";
            BorderColorTag1 = "";
            BorderColorTag2 = "";
            BorderColorTag3 = "";
            BorderColorDesc = "";

        }

        private bool validateInput()
        {
            if (product.stock != 0 && product.stock != null && product.price != 0.00m && product.price != null && product.product_name != null &&
            product.tag1 != null && product.tag2 != null &&
               product.tag3 != null && product.imageurl != null && product.description != null)
            {
                return true;
            }
            FinalResult.Add("BorderColorName", product.product_name != null);

            FinalResult.Add("BorderColorPrice", product.price != 0.00m && product.price != null);
            FinalResult.Add("BorderColorTag1", product.tag1 != null);
            FinalResult.Add("BorderColorTag2", product.tag2 != null);
            FinalResult.Add("BorderColorTag3", product.tag3 != null);
            FinalResult.Add("BorderColorStock", product.stock != 0 && product.stock != null);
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
            vm.source = "HomeVM/HomeView.xaml";
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
