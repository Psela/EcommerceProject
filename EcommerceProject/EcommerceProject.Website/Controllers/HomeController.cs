using EcommerceProject.DataModel;
using EcommerceProject.Server;
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
  

    public HomeController()
    {
      reader = new DatabaseReader(new DataRetrieverService());
    }

    public HomeController(DatabaseReader DbReader)
    {
      reader = DbReader;
    }

    
    public ActionResult Index(string searchInput)
    {
        if (Request.IsAjaxRequest())
        {
            return ShowResults(searchInput);
        }
      return View();
    }

    public PartialViewResult ShowResults(string searchInput)
    {
        List<Product> listOfProducts = SearchProducts(searchInput);

        foreach (Product p in listOfProducts)
        {
            return PartialView("_PartialProductView", p);
        }
      return PartialView("_PartialProductView", null);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      return View();
    }

    public List<Product> SearchProducts(string searchFor)
    {
      List<Product> listOfProducts = GetAllProductsInList();
      List<Product> foundProduct = new List<Product>();
      foreach (Product product in listOfProducts)
      {
        int id = 0;
        if (int.TryParse(searchFor, out id))
        {
          if (product.id == id)
          {
            foundProduct.Clear();
            foundProduct.Add(product);
            break;
          }
        }
        if (
          product.name.Contains(searchFor) ||
          product.tag1 == searchFor ||
          product.tag2 == searchFor ||
          product.tag3 == searchFor ||
          product.description.Contains(searchFor))
        {
          foundProduct.Add(product);
        }
      }

      return foundProduct;
    }

   public List<Product> GetAllProductsInList()
    {
        DataRetrieverService service = new DataRetrieverService();
        List<Product> listOfProducts = reader.GetAllProducts();
    
        return listOfProducts;
    }


  }
}