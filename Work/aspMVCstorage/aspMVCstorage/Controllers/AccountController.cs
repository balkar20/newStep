using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using aspMVCstorage.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace aspMVCstorage.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (authtrainEntities db = new authtrainEntities())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);
                }

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User with this password and login not exists");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (authtrainEntities db = new authtrainEntities())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name);
                }

                if (user == null)
                {
                    //create new user
                    using (authtrainEntities db = new authtrainEntities())
                    {
                        db.Users.Add(new User()
                        {
                            Email = model.Name,
                            Password = model.Password,
                            Age = model.Age,
                        });

                        db.SaveChanges();

                        user = db.Users.Where(u => u.Email == model.Name && u.Password == model.Password)
                            .FirstOrDefault();
                    }

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with this login already exists!");
                }
            }
            return View(model);
        }
    }
}