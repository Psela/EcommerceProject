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
    public List<BasketItem> ProductsInBasket = new List<BasketItem>();

    public BasketController()
    {
      var factory = new ChannelFactory<IBasket>("BasketService");
      basket = factory.CreateChannel();
    }

    public BasketController(IBasket Basket)
    {
      basket = Basket;
    }

    // GET: Basket
    public ActionResult Index()
    {      
      GetBasketProducts();
      ViewBag.Total = basket.Total();
      return View(ProductsInBasket);
    }

    // confirmation view
    public ActionResult ConfirmationPage()
    {
      ViewBag.SubTotal = basket.Total();
      ViewBag.VAT = Math.Round( 0.2m * ViewBag.SubTotal,2);
      ViewBag.GrandTotal = ViewBag.SubTotal + ViewBag.VAT;
      GetBasketProducts();
      basket.EmptyBasket();
      return View(ProductsInBasket);
    }

    public void GetBasketProducts()
    {
      ProductsInBasket = basket.GetBasket();
    }

    public void EmptyBasket()
    {
      basket.EmptyBasket();
      Response.Redirect("~/Basket/Index");
    }
  }
}