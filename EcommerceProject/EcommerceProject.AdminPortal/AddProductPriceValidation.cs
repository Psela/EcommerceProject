using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EcommerceProject.AdminPortal
{
    public class AddProductPriceValidation : ValidationRule
    {
        private string _product_name;

        public string ProductName
        {
            get 
            { 
                return _product_name; 
            }
            set { 
                _product_name = value; 
            
            
            }
        }

       
        
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
          /*  int i;
            if (int.TryParse(value.ToString(), out i))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Please enter a valid integer value.");*/

            if(ProductName!=string.Empty)
            {
                return new ValidationResult(true, null);

            }

            return new ValidationResult(false, "This field cannot be empty");
        }
    }
}