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

        public FindProduct()
        {
            context = new ECommerceEntities();
        }

        public FindProduct(ECommerceEntities eCommerceEntities)
        {
            context = eCommerceEntities;
        }

        public virtual List<ProductData> GetAllProducts()
        {
            using (context)
            {
                List<ProductData> products = context.ProductDatas.ToList<ProductData>();
                return products;
            }
        }
        public virtual ProductData GetProductByID(int ID)
        {
            using (context)
            {
                ProductData product = context.ProductDatas.Where<ProductData>(p => p.p_id == ID).FirstOrDefault();
                return product;
            }
        }
    }
}
