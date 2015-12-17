using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DatabaseModel.Delete
{
    public class RemoveProduct
    {
        private ECommerceEntities context;

        public RemoveProduct()
        {
            context = new ECommerceEntities();
        }

        public RemoveProduct(ECommerceEntities eCommerceEntities)
        {
            context = eCommerceEntities;
        }

        public void DeleteProductByID(int id)
        {
            using (context)
            {
                ProductData product = context.ProductDatas.SingleOrDefault(p => p.p_id == id);
                if (product != null)
                {
                    context.ProductDatas.Remove(product);
                    context.SaveChanges();
                }
            }
        }
    }
}
