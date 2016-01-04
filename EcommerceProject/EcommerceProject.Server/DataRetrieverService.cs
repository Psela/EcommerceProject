using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Select;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcommerceProject.Server
{
  public class DataRetrieverService : IDataRetrieverService
  {
    FindProduct dbFind;

    public DataRetrieverService(FindProduct findProduct)
    {
      dbFind = findProduct;
    }

    public DataRetrieverService()
    {
      dbFind = new FindProduct();
    }

    public virtual List<ProductData> ReadData()
    {
      List<ProductData> products = dbFind.GetAllProducts();
      return products;
    }

    public virtual List<ProductData> SearchData(string searchFor)
    {
      List<ProductData> listOfProducts = ReadData();
      List<ProductData> foundProduct = new List<ProductData>();

      foreach (ProductData product in listOfProducts)
      {
        int id = 0;
        if (int.TryParse(searchFor, out id))
        {
          if (product.p_id == id)
          {
            foundProduct.Clear();
            foundProduct.Add(product);
            break;
          }
        }
        if (
          product.product_name.Contains(searchFor) ||
          product.tag1 == searchFor ||
          product.tag2 == searchFor ||
          product.tag3 == searchFor ||
          product.description.Contains(searchFor))
        {
          foundProduct.Add(product);
        }
      }

      return foundProduct;
    }

  }
}
