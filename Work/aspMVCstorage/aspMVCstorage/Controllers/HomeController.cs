using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using aspMVCstorage.Filters;

namespace aspMVCstorage.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            string result = "You are not authorised!";
            if (User.Identity.IsAuthenticated)
            {
                result = "YOur login: " + User.Identity.Name;
            }
            return result;
        }
        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        [MyAuth]
        public string Tester()
        {
            return User.Identity.Name;
        }

        public string Red()
        {
            return "Red";
        }
    }
}