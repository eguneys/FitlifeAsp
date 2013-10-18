using Fitlife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitlife.WebUI.Filters
{
    public class CurrentUserAttribute : AuthorizeAttribute
    {
        private User _user { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return _user == (User)httpContext.Session["user"];
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            _user = (User) filterContext.Controller.ValueProvider.GetValue("User").ConvertTo(typeof(User));
        }
    }

}