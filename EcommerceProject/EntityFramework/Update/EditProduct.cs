using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DatabaseModel.Update
{
    public class EditProduct
    {
        private ECommerceEntities context;

        public EditProduct()
        {
            context = new ECommerceEntities();
        }

        public EditProduct(ECommerceEntities eCommerceEntities)
        {
            context = eCommerceEntities;
        }

        public void UpdateProduct(int id, string name, string descript, decimal prices, string tagOne, string tagTwo, string tagThree, int stockAmount, string picture)
        {
            using (context)
            {
                int p_id = id;

                ProductData product = context.ProductDatas.Where(p => p.p_id == id).First();
                product.product_name = name;
                product.description = descript;
                product.price = prices;
                product.tag1 = tagOne;
                product.tag2 = tagTwo;
                product.tag3 = tagThree;
                product.stock = stockAmount;
                product.imageurl = picture;
                context.SaveChanges();
            }
        }
    }
}
