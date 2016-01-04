using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceProject.Website.Controllers
{
  public class ProductController : Controller
  {
    public ActionResult Index(string id)
    {
      HomeController homeController = new HomeController();

      ProductData product = homeController.SearchProducts(id)[0];

      return View(product);
    }
  }
}