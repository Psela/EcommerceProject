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
    public List<BasketItem> _basket;

    public Basket(List<BasketItem> Basket)
    {
      _basket = Basket;
    }

    public Basket()
    {

    }

    public List<BasketItem> GetBasket()
    {
      CheckBasketExists();
      return _basket;
    }

    private void CheckBasketExists()
    {
      if (_basket == null)
      {
        _basket = new List<BasketItem>();
      }
    }

    public void AddToBasket(ProductData product, int amount)
    {
      CheckBasketExists();
      foreach (BasketItem basketItem in _basket)
      {
        if (basketItem.product.p_id == product.p_id)
        {
          basketItem.itemCount += amount;
          return;
        }
      }

      _basket.Add(new BasketItem() { product = product, itemCount = amount });
    }

    public void EmptyBasket()
    {
      _basket = new List<BasketItem>();
    }
  }
}