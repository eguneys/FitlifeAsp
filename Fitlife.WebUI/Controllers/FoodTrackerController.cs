using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Fitlife.Domain.Entities;
using Fitlife.Domain.Concrete;
using Fitlife.Domain.Abstract;

namespace Fitlife.WebUI.Controllers
{
    [Authorize]
    public class FoodTrackerController : ApiController
    {
        private EFFoodTrackerRepository trackerRepository;
        private IUserRepository userRepository;

        public FoodTrackerController() {
            trackerRepository = EFFoodTrackerRepository.getRepository();
            userRepository = EFUserRepository.getRepository();
        }

        // GET api/FoodTracker
        public IEnumerable<FoodTracker> GetFoodTrackers()
        {
            return trackerRepository.FoodTrackers.AsEnumerable();
        }

        public IEnumerable<FoodTracker> GetFoodTrackers(DateTime date)
        {
            
            string name = User.Identity.Name;
            Domain.Entities.User user = userRepository.Users.Where(x => x.Name == name).FirstOrDefault();

            return trackerRepository.FoodTrackers.Where(x => x.TrackDate == date && x.UserID == user.UserID);
        }

        public IEnumerable<Food> GetFoodTrackers(DateTime date, int populated)
        {
            string name = User.Identity.Name;
            Domain.Entities.User user = userRepository.Users.Where(x => x.Name == name).FirstOrDefault();

            return trackerRepository.FoodTrackersPopulated(date, user.UserID);
        }

        // GET api/FoodTracker/5
        public FoodTracker GetFoodTracker(int id)
        {
            FoodTracker foodtracker = trackerRepository.FoodTrackers.First(x => x.FoodCode == id);
            if (foodtracker == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return foodtracker;
        }

        // POST api/FoodTracker
        public HttpResponseMessage PostFoodTracker(FoodTracker foodtracker)
        {
            if (ModelState.IsValid)
            {

            string name = User.Identity.Name;
            Domain.Entities.User user = userRepository.Users.Where(x => x.Name == name).FirstOrDefault();

            foodtracker.UserID = user.UserID;

                trackerRepository.SaveFoodTracker(foodtracker);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/FoodTracker/5
        public HttpResponseMessage DeleteFoodTracker(int id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "");
        }
    }
}