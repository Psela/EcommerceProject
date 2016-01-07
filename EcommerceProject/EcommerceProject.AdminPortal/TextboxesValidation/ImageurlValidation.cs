using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EcommerceProject.AdminPortal.TextboxesValidation
{
    class ImageurlValidation: ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var str = value as string;
            if (str != string.Empty)
            {
                return new ValidationResult(true, null);

            }

            return new ValidationResult(false, "This field cannot be empty");
        }
    }
    }

