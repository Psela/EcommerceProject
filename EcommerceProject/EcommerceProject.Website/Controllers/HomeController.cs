using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Select;
using EcommerceProject.Website.WebsiteServerHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace EcommerceProject.Website.Controllers
{
  public class HomeController : Controller
  {
    IDataRetrieverService client;
    List<ProductData> listOfProducts;
    
    public HomeController()
    {
      var factory = new ChannelFactory<IDataRetrieverService>("BasicHttpBinding_IDataRetrieverService");
      client = factory.CreateChannel();
      listOfProducts = GetAllProductsInList();
    }

    public HomeController(IDataRetrieverService DbReader)
    {
      client = DbReader;
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
      List<ProductData> foundProducts = client.SearchData(searchFor);
      return foundProducts;
    }

    public List<ProductData> GetAllProductsInList()
    {
      List<ProductData> listOfProducts = client.ReadData();

      return listOfProducts;
    }


  }
}