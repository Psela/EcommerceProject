using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Select;
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
    DataRetrieverService reader;
    List<ProductData> listOfProducts;

    public HomeController()
    {
      reader = new DataRetrieverService();
      listOfProducts = GetAllProductsInList();
    }

    public HomeController(DataRetrieverService DbReader)
    {
      reader = DbReader;
    }


    public ActionResult Index(string searchInput)
    {
      if (Request.IsAjaxRequest())
      {
        return ShowResults(searchInput);
      }
      return View(listOfProducts);
    }

    public PartialViewResult ShowResults(string searchInput)
    {
      List<ProductData> listOfResultProducts = SearchProducts(searchInput);

      return PartialView("_ProductListView", listOfResultProducts);
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

    public List<ProductData> SearchProducts(string searchFor)
    {
      List<ProductData> foundProducts = reader.SearchData(searchFor);
      return foundProducts;
    }

    public List<ProductData> GetAllProductsInList()
    {
      List<ProductData> listOfProducts = reader.ReadData();

      return listOfProducts;
    }


  }
}