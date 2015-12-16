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
        //List<Product> listOfProducts = SearchProducts(searchInput);

        ////// DELETE ONCE CONNECTED TO DATABASE!//////
        List<Product> listOfProducts = new List<Product>();
        Product prod = new Product() { id = 1, name = "Book", price = 10.00, stock = 1, tag1 = "Wand", tag2 = "Harry Potter", tag3 = "Magic", description = "abc \n bcd", imageurl = "http://vignette2.wikia.nocookie.net/harrypotter/images/a/a8/Harrypotterwand.jpg/revision/latest?cb=20090315070416" };
        //listOfProducts.Add(new Product() { id = 1, name = "Wand", price = 10.00, stock = 1, tag1 = "Wand", tag2 = "Harry Potter", tag3 = "Magic", description = "abc \n bcd", imageurl = "http://vignette2.wikia.nocookie.net/harrypotter/images/a/a8/Harrypotterwand.jpg/revision/latest?cb=20090315070416" });
        listOfProducts.Add(prod);
        return PartialView("_PartialProductView", prod);
        ///////////////////////////////////////////////

        //foreach (Product p in listOfProducts)
        //{
        //    return PartialView("_PartialProductView", listOfProducts);
        //}
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

    public List<Product> SearchProducts(string searchFor)
    {
      DataRetrieverService service = new DataRetrieverService();
      List<Product> foundProduct = new List<Product>();
      List<Product> listOfProducts = reader.GetAllProducts();

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

  }
}