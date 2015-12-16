using EcommerceProject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceProject.Website.Controllers
{
    public class AjaxController : Controller
    {
        HomeController hc = new HomeController();

        public ActionResult Index(string searchInput)
        {

            return PartialView();
        }
        
    }
}
