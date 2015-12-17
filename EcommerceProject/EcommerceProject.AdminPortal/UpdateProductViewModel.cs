using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.AdminPortal
{
    public class UpdateProductViewModel:INotifyPropertyChanged
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

        public UpdateProductViewModel()
        {
            source = "UpdateProductView.xaml";
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
