using EcommerceProject.DatabaseModel;
using EcommerceProject.Website.WebsiteBasketHost;
using EcommerceProject.Website.WebsiteServerHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace EcommerceProject.Website.Controllers
{
  public class BasketController : Controller
  {
    IBasket basket;
    public Dictionary<ProductData, int> ProductsInBasket = new Dictionary<ProductData, int>();

    public BasketController()
    {
      var factory = new ChannelFactory<IBasket>("BasketService");
      basket = factory.CreateChannel();
    }

    // GET: Basket
    public ActionResult Index()
    {
      return View();
    }

    // confirmation view
    public ActionResult ConfirmationPage()
    {
      basket.EmptyBasket();
      return View();
    }

    public void GetBasketProducts()
    {
      ProductsInBasket = basket.GetBasket();
    }

    public PartialViewResult ShowBasketProducts()
    {
      return PartialView("_ProductListView", ProductsInBasket);
    }
  }
}