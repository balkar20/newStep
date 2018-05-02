using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTrain2.Models;

namespace UnitTrain2.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo;

        public HomeController(IRepository r)
        {
            repo = r;
        }
        public HomeController()
        {
            repo = new ComputerRepository();
        }

        public ActionResult Index()
        {
            var model = repo.GetComputerList();
            if (model.Count > 0)
                ViewBag.Message = String.Format("В базе данных {0} объект", model.Count);
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
        }
    }
}