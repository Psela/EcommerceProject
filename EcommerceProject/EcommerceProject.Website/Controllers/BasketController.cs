﻿using EcommerceProject.DatabaseModel;
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
      ViewBag.VAT = 0.2m * ViewBag.SubTotal;
      ViewBag.GrandTotal = ViewBag.SubTotal + ViewBag.VAT;
      GetBasketProducts();
      basket.EmptyBasket();
      return View(ProductsInBasket);
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