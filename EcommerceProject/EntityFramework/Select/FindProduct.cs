using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DatabaseModel.Select
{
    public class FindProduct
    {
        private ECommerceEntities context;

        public FindProduct(ECommerceEntities eCommerceEntities)
        {
            context = eCommerceEntities;
        }

        public List<ProductData> GetAllProducts()
        {
            using (context)
            {
                List<ProductData> products = context.ProductDatas.ToList<ProductData>();
                return products;
            }
        }
    }
}
