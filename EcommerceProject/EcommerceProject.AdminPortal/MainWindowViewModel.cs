using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EcommerceProject.AdminPortal
{
    public class MainWindowViewModel
    {
        private string _source;
        public string source 
        {
            get { return _source; }
            set { _source = value; }
        }

        public MainWindowViewModel()
        {
            source = "HomeView.xaml";
        }
    }
}
