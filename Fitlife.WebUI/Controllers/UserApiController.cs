using Fitlife.Domain.Abstract;
using Fitlife.Domain.Concrete;
using Fitlife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fitlife.WebUI.Controllers
{
    public class UserApiController : ApiController
    {
        IUserRepository uRepo = EFUserRepository.getRepository();

        public UserApiController()
        {
        }

        public UserSafe GetUser(int userID)
        {
             User user = uRepo.Users.Where(x => x.UserID == userID).FirstOrDefault();
             return new UserSafe(user);
        }

        public void PostUser(User user, string action)
        {

            uRepo.SaveUser(user);
        }
    }
}
