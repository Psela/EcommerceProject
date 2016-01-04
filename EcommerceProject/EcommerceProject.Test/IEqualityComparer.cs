using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Test
{
    public class ProductEqualityComparer : IEqualityComparer<ProductData>
    {
        public bool Equals(ProductData x, ProductData y)
        {
            if (object.ReferenceEquals(x, y)) return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;

            return x.product_name == y.product_name && x.p_id == y.p_id;
        }

        public int GetHashCode(ProductData obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;

            int hashCodeName = obj.product_name == null ? 0 : obj.product_name.GetHashCode();
            int hasCodeAge = obj.p_id.GetHashCode();

            return hashCodeName ^ hasCodeAge;
        }
    }
}
