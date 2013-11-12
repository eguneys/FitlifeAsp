using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitlife.WebUI.Filters;
using System.Net.Mail;
using Fitlife.WebUI.Models;
using System.Net;

namespace Fitlife.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult ContactUsMail(HomeViewModel model)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("eguneys@hotmail.com");

            message.To.Add(new MailAddress("eguneys@hotmail.com"));

            message.Subject = model.ContactUsMail.Subject;
            message.Body = model.ContactUsMail.Message;

            SmtpClient client = new SmtpClient("smtpout.secureserver.net", 80);
            client.Credentials = new NetworkCredential("eguneys@fitlifefree.com", "cotton412@COM");
            client.Send(message);

            return View("Index");
        }
    }
}
