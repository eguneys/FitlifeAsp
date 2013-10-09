using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitlife.Domain.Entities;
using Fitlife.WebUI.Filters;
using System.Web.Security;
using Fitlife.Domain.Abstract;

namespace Fitlife.WebUI.Controllers
{
    public class AccountController : Controller
    {

        private IUserRepository uRepository;

        public AccountController(IUserRepository repository)
        {
            uRepository = repository;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (uRepository.ValidateUser(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Name, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["message"] = string.Format("Invalid username or password");
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }

        public ViewResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                uRepository.SaveUser(user);
                TempData["message"] = string.Format("Registration successfull");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
