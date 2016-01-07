using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EcommerceProject.AdminPortal.AddProductVM;


namespace EcommerceProject.AdminPortal
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private ICommand _addButton;
        public ICommand addButton
        {
            get
            {
                if (_addButton == null)
                {
                    _addButton = new Command(GoToAddPage, CanGoToAddPage);
                }
                return _addButton;
            }
            set
            {
                _addButton = value;
                onPropertyChanged("addButton");
            }
        }

        private ICommand _removeButton;
        public ICommand removeButton
        {
            get
            {
                if (_removeButton == null)
                {
                    _removeButton = new Command(GoToRemovePage, CanGoToRemovePage);
                }
                return _removeButton;
            }
            set
            {
                _removeButton = value;
            }
        }

        private bool CanGoToAddPage()
        {
            return true;
        }
        private void GoToAddPage()
        {
            MainWindowViewModel vm = App.Current.MainWindow.DataContext as MainWindowViewModel;
            vm.source = "AddProductVM/AddProduct.xaml"; 
        }

        private bool CanGoToRemovePage()
        {
            return true;
        }
        private void GoToRemovePage()
        {
            MainWindowViewModel vm = App.Current.MainWindow.DataContext as MainWindowViewModel;
            vm.source = "FindVM/FindProductView.xaml";
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
