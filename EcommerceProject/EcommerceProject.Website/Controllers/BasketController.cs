using EcommerceProject.DatabaseModel;
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
        IDataRetrieverService client;
       public Dictionary<ProductData, int> ProductsInBasket= new Dictionary<ProductData, int>() ;

        public BasketController()
        {
            var factory = new ChannelFactory<IDataRetrieverService>("TheService");
            client = factory.CreateChannel();
        }

        // GET: Basket
        public ActionResult Index()
        {
            return View();
        }

        // confirmation view
        public ActionResult ConfirmationPage()
        {
            return View();
        }

        public void GetBasketProducts()
        {
            ProductsInBasket = client.GetBasket();

            //Temporary test products
            ProductsInBasket.Add(new ProductData() { product_name = "newItem", description = "a", price=100 }, 1);
            ProductsInBasket.Add(new ProductData() { product_name = "newItem2", description = "b", price= 9000}, 2);

        }

        public PartialViewResult ShowBasketProducts()
        {
            return PartialView("_ProductListView", ProductsInBasket);
        }
    }
}