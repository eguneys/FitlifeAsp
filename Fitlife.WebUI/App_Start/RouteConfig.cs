using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fitlife.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new { controller = "Home", action = "Index"}
                );

            routes.MapRoute(null,
                "{action}",
                new { controller = "Home", action = "{action}" });

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}