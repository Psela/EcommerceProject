using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceProject.Website
{
  public class Basket
  {
    private ProductData product;
    public ProductData _product
    {
      get { return product; }
      set { product = value; }
    }

    private int quantity;
    public int _quantity
    {
      get { return quantity; }
      set { quantity = value; }
    }
    
  }
}