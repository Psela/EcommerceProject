using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EcommerceProject.ServerBasket
{
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
  public class Basket : IBasket
  {
    public Dictionary<ProductData, int> _basket;

    public Basket(Dictionary<ProductData, int> Basket)
    {
      _basket = Basket;
    }

    public Basket()
    {

    }

    public Dictionary<ProductData, int> GetBasket()
    {
      if (_basket == null)
      {
        _basket = new Dictionary<ProductData, int>();
      }
      return _basket;
    }

    public void AddToBasket(ProductData product, int amount)
    {
      GetBasket();
      _basket.Add(product, amount);
    }

    public void EmptyBasket()
    {
      _basket = new Dictionary<ProductData, int>();
    }
  }
}
