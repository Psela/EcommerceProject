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
        ProductData product = context.ProductDatas.Where(p => p.p_id == productWithChanges.p_id).First();

        product = productWithChanges;
        context.SaveChanges();
      }
    }
  }
}
