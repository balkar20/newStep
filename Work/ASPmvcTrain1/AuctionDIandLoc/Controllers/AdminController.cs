using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionDIandLoc.Models;

namespace AuctionDIandLoc.Controllers
{
    public class AdminController : Controller
    {
        IMembersRepository membersRepository;

        public AdminController(IMembersRepository repositoryParam)
        {
            membersRepository = repositoryParam;
        }

        // GET: Admin
        public ActionResult ChangeLoginName(string oldLoginParam, string newLoginParam)
        {
            Member member = membersRepository.FetchByLoginName(oldLoginParam);
            member.LoginName = newLoginParam;
            membersRepository.SubmitChanges();
            // ... теперь будет показано представление
            return View();
        }
    }
}