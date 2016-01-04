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

    /// <summary>
    /// Note to self:
    /// Last things done were:
    ///   Added IDataRetrieverService.cs and made DataRetrieverService.cs a service contract.
    ///   Made connections for server ( endpoints, binding, and behaviours ) in App.config.
    ///   Added Service.svc host.
    ///   EcommerceProject.Server is now being used as a server.
    ///   Can now add more methods to the server.
    ///   And can begin take methods used in the ViewModels and place them in the server since the ViewModels should not hold logic and 
    ///   if this programme was sent out it would be easier to change code in the server than have to change all the ViewModels accross the world.
    ///Lasly.. Welcome back!
    /// </summary>
    /// <returns></returns>

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
