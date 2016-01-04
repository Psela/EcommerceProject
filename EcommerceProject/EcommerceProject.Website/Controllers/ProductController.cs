using EcommerceProject.DatabaseModel;
using EcommerceProject.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceProject.Website.Controllers
{
  public class ProductController : Controller
  {
    WebsiteServerHost.DataRetrieverServiceClient client;

    public ProductController()
    {
      client = new WebsiteServerHost.DataRetrieverServiceClient();
    }

    public ActionResult Index(string id)
    {
      ProductData product = client.SearchData(id)[0];

      return View(product);
    }
  }
}