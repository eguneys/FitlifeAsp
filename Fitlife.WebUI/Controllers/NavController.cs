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
                    Action = "Index",
                    Icon = "icon-home",
                    AllowAnonymous = true
                },
                new NavViewModel () {
                    Name = "Progress",
                    Link = "Progress",
                    Controller = "Progress",
                    Action = "Index",
                    Icon = "icon-rocket",
                    AllowAnonymous = false
                },
                new NavViewModel () {
                                        Name= "Nutrition",
                                        Link = "Nutrition",
                                        Controller = "Nutrition",
                                        Action = "Index",
                                        Icon = "icon-lemon",
                                        AllowAnonymous = false
                },
                new NavViewModel () {
                                        Name = "Social",
                                        Link = "Social",
                                        Controller = "Social",
                                        Action = "Index",
                                        Icon = "icon-comment",
                                        AllowAnonymous = false
                },
                //new NavViewModel () {
                //    Name = "About",
                //    Link = "About",
                //    Controller = "Home",
                //    Action = "About",
                //    AllowAnonymous = true
                //}
            };

            return PartialView(navigations);
        }

        public PartialViewResult Signin()
        {
            return PartialView();
        }

    }
}
