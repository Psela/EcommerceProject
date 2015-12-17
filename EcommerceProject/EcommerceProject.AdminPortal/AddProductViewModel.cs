using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EcommerceProject.AdminPortal
{
    public class AddProductViewModel : INotifyPropertyChanged
    {


        private int _productId;
        private string _name;
        private string _description;
        private double _price;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private int _stock;
        private string _imageUrl;

        public int Product_ID
        {
            get { return _productId; }
            set
            {
                _productId = value;
                onPropertyChanged("Product_ID");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                onPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                onPropertyChanged("Description");
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                onPropertyChanged("Price");
            }
        }

        public string Tag1
        {
            get { return _tag1; }
            set
            {
                _tag1 = value;
                onPropertyChanged("Tag1");
            }
        }

        public string Tag2
        {
            get { return _tag2; }
            set
            {
                _tag2 = value;
                onPropertyChanged("Tag2");
            }
        }

        public string Tag3
        {
            get { return _tag3; }
            set
            {
                _tag3 = value;
                onPropertyChanged("Tag3");
            }
        }

        public int Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                onPropertyChanged("Stock");
            }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                onPropertyChanged("ImageUrl");
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
            Product_ID = 0;
            Name = string.Empty;
            Description = string.Empty;
            Price = 0.00;
            Tag1 = string.Empty;
            Tag2 = string.Empty;
            Tag3 = string.Empty;
            Stock = 0;
            ImageUrl = string.Empty;
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
