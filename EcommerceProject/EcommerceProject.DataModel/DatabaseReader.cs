using EcommerceProject.DatabaseModel;
using EcommerceProject.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcommerceProject.DataModel
{
    //1 tola = 11.66 grams

  public class DatabaseReader
  {
    DataRetrieverService reader;


    public DatabaseReader(DataRetrieverService dbReader)
    {
      reader = dbReader;
    }


    public virtual List<Product> GetAllProducts()
    {
      List<Product> listOfProducts = new List<Product>();
      List<ProductData> listOfProductData = reader.ReadData();

      foreach (ProductData productData in listOfProductData)
      {
        listOfProducts.Add(new Product()
        {
          id = productData.p_id,
          name = productData.product_name,
          tag1 = productData.tag1,
          tag2 = productData.tag2,
          tag3 = productData.tag3,
          description = productData.description,
          imageurl = productData.imageurl,
          price = (double)productData.price,
          stock = (int)productData.stock
        });
      }

      return listOfProducts;
    }
  }
}
