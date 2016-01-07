using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Server
{
  [ServiceContract]
  public interface IDataRetrieverService
  {
    [OperationContract]
    List<ProductData> ReadData();

    [OperationContract]
    List<ProductData> SearchData(string searchFor);

    [OperationContract]
    void CreateNewProductItem(ProductData product);

    [OperationContract]
    ProductData FindById(string id);

    [OperationContract]
    void RemoveById(int id);

    [OperationContract]
    void UpdateProduct(ProductData newProduct);
  }
}
