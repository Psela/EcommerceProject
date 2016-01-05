using EcommerceProject.DatabaseModel;
using EcommerceProject.Website.WebsiteServerHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace EcommerceProject.Website.Controllers
{
  public class ProductController : Controller
  {
    IDataRetrieverService client;

    public ProductController()
    {
      var factory = new ChannelFactory<IDataRetrieverService>("TheService");
      client = factory.CreateChannel();
    }

    public ProductController(IDataRetrieverService DbReader)
    {
      client = DbReader;
    }

    public ActionResult Index(string id)
    {
      ProductData product = client.SearchData(id)[0];

      return View(product);
    }

    public void AddToBasket(ProductData productToAdd)
    {
      client.AddToBasket(productToAdd, 1);
    }
  }
}