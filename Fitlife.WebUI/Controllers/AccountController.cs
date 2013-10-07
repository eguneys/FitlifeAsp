using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitlife.Domain.Entities;

namespace Fitlife.WebUI.Controllers
{
    public class AccountController : Controller
    {

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Login(User user)
        {
            Session["Key"] = "asdklfj";
            return View(user);
        }

        public ViewResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Signup(User user)
        {
            return View(user);
        }
    }
}
