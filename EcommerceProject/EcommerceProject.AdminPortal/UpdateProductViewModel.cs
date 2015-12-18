using EcommerceProject.DatabaseModel;
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
    public class UpdateProductViewModel : INotifyPropertyChanged
    {
        public DatabaseReader dbReader { get; set; }


        private string _id;

        public string id
        {
            get { return _id; }
            set
            {
                _id = value;
                onPropertyChanged("id");
            }
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                onPropertyChanged("name");
            }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                onPropertyChanged("description");
            }
        }

        private double _price;

        public double price
        {
            get { return _price; }
            set
            {
                _price = value;
                onPropertyChanged("price");
            }
        }

        private string _tag1;

        public string tag1
        {
            get { return _tag1; }
            set
            {
                _tag1 = value;
                onPropertyChanged("tag1");
            }
        }

        private string _tag2;

        public string tag2
        {
            get { return _tag2; }
            set
            {
                _tag2 = value;
                onPropertyChanged("tag2");
            }
        }

        private string _tag3;

        public string tag3
        {
            get { return _tag3; }
            set
            {
                _tag3 = value;
                onPropertyChanged("tag3");
            }
        }

        private int _stock;

        public int stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                onPropertyChanged("stock");
            }
        }

        private string _image;

        public string image
        {
            get { return _image; }
            set
            {
                _image = value;
                onPropertyChanged("image");
            }
        }


        private string _source;
        public string source
        {
            get { return _source; }
            set
            {
                _source = value;
                onPropertyChanged("source");
            }
        }

        public UpdateProductViewModel()
        {
            dbReader = new DatabaseReader(new DataRetrieverService());
            source = "UpdateProductView.xaml";
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

        private bool canfindProduct(string id)
        {
            return true;

        }

        private void findProduct(string id)
        {
            int a = 0;
            if (int.TryParse(id, out a))
            {
                int ID = int.Parse(id ?? "1");
                if (ID != 0)
                {
                    id = ID.ToString();
                    Product product = dbReader.GetAllProducts().Where<Product>(x => x.id == ID).First();
                    name = product.name;
                    description = product.description;
                    price = product.price;
                    tag1 = product.tag1;
                    tag2 = product.tag2;
                    tag3 = product.tag3;
                    stock = product.stock;
                }
            }
        }



        private bool CanUpdateDetails()
        {
            return true;
        }

        private void UpdateDetails()
        {


            int ID = int.Parse(id); 

            DatabaseModel.Update.EditProduct dbUpdate = new DatabaseModel.Update.EditProduct();

            decimal p = decimal.Parse(price.ToString());

            dbUpdate.UpdateProduct(ID, name, description, p, tag1, tag2, tag3, stock, image);

        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
