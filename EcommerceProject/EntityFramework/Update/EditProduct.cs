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

    public void UpdateProduct(ProductData productWithChanges)
    {
      using (context)
      {
        ProductData Original = context.ProductDatas.Where<ProductData>(x => x.p_id == productWithChanges.p_id).FirstOrDefault();
        Original.product_name = productWithChanges.product_name;
        Original.description = productWithChanges.description;
        Original.imageurl = productWithChanges.imageurl;
        Original.price = productWithChanges.price;
        Original.stock = productWithChanges.stock;
        Original.tag1 = productWithChanges.tag1;
        Original.tag2 = productWithChanges.tag2;
        Original.tag3 = productWithChanges.tag3;
        context.SaveChanges();
      }
    }
  }
}
