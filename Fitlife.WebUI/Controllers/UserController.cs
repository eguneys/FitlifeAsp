using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitlife.Domain.Abstract;
using Fitlife.WebUI.Filters;
using System.Net;

namespace Fitlife.WebUI.Controllers
{
    [CustomAuth]
    public class UserController : Controller
    {
        private IUserRepository repository;
        
        public UserController(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public ViewResult Index(Fitlife.Domain.Entities.User user)
        {
            if (user == null || user.UserID == 0) user = (Fitlife.Domain.Entities.User)Session["user"];
            return View(user);
        }

        public ViewResult List()
        {
            return View(repository.Users);
        }
        
        [HttpPost]
        public ActionResult ChangePicture(string photo)
        {
            Fitlife.Domain.Entities.User user = ((Fitlife.Domain.Entities.User)Session["user"]);
            user.Photo = photo;
            user.Password = user.PasswordDigest;
            repository.SaveUser(user);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
