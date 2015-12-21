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

    public void CreateNewProduct(ProductData product)
    {
      using (context)
      {
        context.ProductDatas.Add(product);
        context.SaveChanges();
      }
    }

  }
}
