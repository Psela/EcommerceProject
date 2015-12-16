using EcommerceProject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Test
{
    public class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (object.ReferenceEquals(x, y)) return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;

            return x.name == y.name && x.id == y.id;
        }

        public int GetHashCode(Product obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;

            int hashCodeName = obj.name == null ? 0 : obj.name.GetHashCode();
            int hasCodeAge = obj.id.GetHashCode();

            return hashCodeName ^ hasCodeAge;
        }
    }
}
