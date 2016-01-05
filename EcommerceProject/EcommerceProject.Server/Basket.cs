using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Server
{
  [DataContract]
  public class Basket
  {
    //Might not be needed

    [DataMember]
    private ProductData _product;
    public ProductData product
    {
      get { return _product; }
      set { _product = value; }
    }
    
    [DataMember]
    private int _amount;
    public int amount
    {
      get { return _amount; }
      set { _amount = value; }
    }
    
  }
}
