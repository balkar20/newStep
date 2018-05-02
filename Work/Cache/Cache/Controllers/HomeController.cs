using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Cache.Controllers
{
    public class HomeController : Controller
    {
        static int x = 9;

        [OutputCache(Duration = 30, Location = OutputCacheLocation.Server)]
        public string Index()
        {
            x++;
            return x.ToString();
        }
    }
}