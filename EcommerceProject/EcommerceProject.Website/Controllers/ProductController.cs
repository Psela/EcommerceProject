using EcommerceProject.DatabaseModel;
using EcommerceProject.Website.WebsiteServerHost;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using EcommerceProject.Website.WebsiteBasketHost;

namespace EcommerceProject.Website.Controllers
{
  public class ProductController : Controller
  {
    IDataRetrieverService client;
    IBasket basket;
    private IDataRetrieverService dataRetrieverService;

    public ProductController()
    {
      var factory = new ChannelFactory<IDataRetrieverService>("TheService");
      client = factory.CreateChannel();
      var factory2 = new ChannelFactory<IBasket>("BasketService");
      basket = factory2.CreateChannel();
    }

    public ProductController(IDataRetrieverService DbReader, IBasket Basket)
    {
      client = DbReader;
      basket = Basket;
    }

    public ActionResult Index(string id)
    {
      ProductData product = client.SearchData(id)[0];

      return View(product);
    }

    public void AddToBasket(ProductData productToAdd)
    {
      basket.AddToBasket(productToAdd, 1);
      Response.Redirect("~/Basket/Index");
    }
  }
}