using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.AdminPortal
{
   public class AddProductViewModel
    {

        private string _source;

        public string source
        {
            get { return _source; }
            set { _source = value; }
        }
        public AddProductViewModel()
        {
            source = "AddProduct.xaml";
        }
        
    }
}
