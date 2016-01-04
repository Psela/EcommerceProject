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
    DataRetrieverService dbService;

    public ProductController()
    {
      dbService = new DataRetrieverService();
    }

    public ProductController(DataRetrieverService dataRetrieverService)
    {
      dbService = dataRetrieverService;
    }

    public ActionResult Index(string id)
    {
      ProductData product = dbService.SearchData(id)[0];

      return View(product);
    }
  }
}