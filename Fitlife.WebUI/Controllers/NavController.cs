using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitlife.WebUI.Models;

namespace Fitlife.WebUI.Controllers
{
    public class NavController : Controller
    {
        //
        // GET: /Nav/

        public PartialViewResult Menu(string action = null)
        {
            ViewBag.SelectedNav = action;
            IEnumerable<NavViewModel> navigations = new List<NavViewModel>()
            {
                new NavViewModel () {
                    Name = "Home",
                    Link = "Index",
                    Controller = "Home",
                    Action = "Index"
                },
                new NavViewModel () {
                    Name = "Progress",
                    Link = "Progress",
                    Controller = "Home",
                    Action = "Progress"
                },
                new NavViewModel () {
                    Name = "About",
                    Link = "About",
                    Controller = "Home",
                    Action = "About"
                }
            };

            return PartialView(navigations);
        }

        public PartialViewResult Signin()
        {
            return PartialView();
        }

    }
}
