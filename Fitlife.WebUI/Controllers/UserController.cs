using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitlife.Domain.Abstract;

namespace Fitlife.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository repository;
        
        public UserController(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public ViewResult List()
        {
            return View(repository.Users);
        }
    }
}
