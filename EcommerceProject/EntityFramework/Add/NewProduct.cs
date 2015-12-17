using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DatabaseModel.Add
{
    public class NewProduct
    {
        private ECommerceEntities context;

        public NewProduct()
        {
            context = new ECommerceEntities();
        }

        public NewProduct(ECommerceEntities eCommerceEntities)
        {
            context = eCommerceEntities;
        }

        public void CreateNewProduct(string name, string descript, decimal prices, string tagOne, string tagTwo, string tagThree, int stockAmount, string picture)
        {
            using (context)
            {
                ProductData product = new ProductData();
                product.product_name = name;
                product.description = descript;
                product.price = prices;
                product.tag1 = tagOne;
                product.tag2 = tagTwo;
                product.tag3 = tagThree;
                product.imageurl = picture;
                context.ProductDatas.Add(product);
                context.SaveChanges();
            }
        }

    }
}
