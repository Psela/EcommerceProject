using EcommerceProject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceProject.Website.Controllers
{
  public class ProductController : Controller
  {
    public ActionResult Index(string product_id)
    {
      return View(product_id);
    }
  }
}