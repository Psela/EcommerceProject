using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EcommerceProject.AdminPortal
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
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

        public MainWindowViewModel()
        {
            source = "HomeView.xaml";
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
