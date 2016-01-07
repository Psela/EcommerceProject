using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EcommerceProject.AdminPortal.TextboxesValidation
{
    class PriceValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            decimal p;
            Boolean noIllegalChars;
            noIllegalChars = decimal.TryParse(value.ToString(), out p);

            if (p == 0.00m)
             {
            return new ValidationResult(false,"Price field cannot be zero");
        }
        else if(noIllegalChars==false)
        {
            return new ValidationResult(false, "Illegal Characters");
        }
        else
        {
            return new ValidationResult(true, null);
        }
        }
    }
}
