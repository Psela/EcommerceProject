using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EcommerceProject.AdminPortal
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private ICommand _addButton;
        public ICommand addButton
        {
            get { return _addButton; }
            set 
            { 
                _addButton = value;
                onPropertyChanged("addButton");
            }
        }

        private ICommand _updateButton;
        public ICommand updateButton
        {
            get { return _updateButton; }
            set 
            { 
                _updateButton = value;
                onPropertyChanged("updateButton");
            }
        }

        private ICommand _removeButton;
        public ICommand removeButton
        {
            get { return _removeButton; }
            set 
            {
                _removeButton = value;
                onPropertyChanged("removeButton");
            }
        }

        private ICommand _manageCustomerButton;
        public ICommand manageCustomerButton
        {
            get { return _manageCustomerButton; }
            set 
            {
                _manageCustomerButton = value;
                onPropertyChanged("manageCustomerButton");
            }
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
