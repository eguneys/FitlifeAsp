using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitlife.Domain.Abstract;
using Fitlife.WebUI.Filters;
using System.Net;
using Fitlife.Domain.Entities;
using Fitlife.WebUI.Models;

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
            UserProfile profile = repository.UserProfiles.Where(x => x.UserID == user.UserID).FirstOrDefault();
            if (profile == null) { profile = new UserProfile(); }
            return View(new UserViewModel() { User = user, Profile = profile });
        }

        public ViewResult List()
        {
            return View(repository.Users);
        }

        public PartialViewResult EditProfile()
        {
            var user = (Fitlife.Domain.Entities.User)Session["user"];
            UserProfile profile = repository.UserProfiles.Where(x => x.UserID == user.UserID).FirstOrDefault();
            if (profile == null) { profile = new UserProfile(); }
            return PartialView(profile);
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

        [HttpPost]
        public ViewResult PostProfile(UserProfile profile)
        {
            Fitlife.Domain.Entities.User user = ((Fitlife.Domain.Entities.User)Session["user"]);
            UserViewModel model = new UserViewModel() { User = user, Profile = profile };
            if (ModelState.IsValid)
            {

                profile.UserID = user.UserID;

                repository.SaveUserProfile(profile);
                TempData["message"] = "Profile Saved";
                return View("Index", model); 
            }
            else
            {
                return View("Index", model);
            }

        }
    }
}
