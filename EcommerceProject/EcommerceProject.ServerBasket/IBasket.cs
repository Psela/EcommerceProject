using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EcommerceProject.ServerBasket
{
  [ServiceContract]
  public interface IBasket
  {
    [OperationContract]
    List<BasketItem> GetBasket();

    [OperationContract]
    void AddToBasket(ProductData product, int amount);

    [OperationContract]
    void EmptyBasket();

    [OperationContract]
    decimal Total();
  }
}
