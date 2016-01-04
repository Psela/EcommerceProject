using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcommerceProject.Server
{
  public class DataRetrieverService : IDataRetrieverService
  {
    public virtual List<ProductData> ReadData()
    {
        DatabaseModel.Select.FindProduct find = new DatabaseModel.Select.FindProduct();
        List<ProductData> products = find.GetAllProducts();
        return products;
    }
  }
}
