using EcommerceProject.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceProject.Website.Controllers
{
  public class HomeController : Controller
  {
    DatabaseReader reader;

    public HomeController(DatabaseReader DbReader)
    {
      reader = DbReader;
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    public Product SearchProducts(string searchFor)
    {
      DataRetrieverService service = new DataRetrieverService();
      Product foundProduct = new Product();
      List<Product> listOfProducts = reader.GetAllProducts();

      foreach (Product product in listOfProducts)
      {
        if (product.name==searchFor)
        {
          foundProduct = product;
          break;
        }
      }

      return foundProduct;
    }
  }
}