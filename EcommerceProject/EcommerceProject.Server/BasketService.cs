using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Server
{
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
  public class BasketService: IDataRetrieverService
  {
    public Dictionary<ProductData, int> _basket;

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
  }
}
