using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcommerceProject.Test
{
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
      listOfProducts = (List<Product>)reader.ReadData();
      return listOfProducts;
    }
  }
}
