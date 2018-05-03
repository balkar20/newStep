using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}