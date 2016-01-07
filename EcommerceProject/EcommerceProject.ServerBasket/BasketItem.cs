using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ServerBasket
{
  public class BasketItem
  {
    [DataMember]
    private ProductData _product;
    public ProductData product
    {
      get { return _product; }
      set { _product = value; }
    }
    
    [DataMember]
    private int _itemCount;
    public int itemCount
    {
      get { return _itemCount; }
      set { _itemCount = value; }
    }
    
  }
}
