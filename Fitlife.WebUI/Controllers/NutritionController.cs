using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitlife.WebUI.Filters;

namespace Fitlife.WebUI.Controllers
{

    [CustomAuth]
    public class NutritionController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

    }
}
