using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcommerceProject.DataModel
{
  public class Product
  {
    public string name { get; set; }
    public string tag1 { get; set; }
    public string tag2 { get; set; }
    public string tag3 { get; set; }
    public string description { get; set; }
    public string imageurl { get; set; }
    public int stock { get; set; }
    public double price { get; set; }
  }
}
