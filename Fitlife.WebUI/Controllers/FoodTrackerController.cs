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

namespace Fitlife.WebUI.Controllers
{
    public class FoodTrackerController : ApiController
    {
        private EFFoodTrackerRepository trackerRepository;

        public FoodTrackerController() {
            trackerRepository = EFFoodTrackerRepository.getRepository();
        }

        // GET api/FoodTracker
        public IEnumerable<FoodTracker> GetFoodTrackers()
        {
            return trackerRepository.FoodTrackers.AsEnumerable();
        }

        public IEnumerable<FoodTracker> GetFoodTrackers(DateTime date, int userID)
        {
            return trackerRepository.FoodTrackers.Where(x => x.TrackDate == date && x.UserID == userID);
        }

        public IEnumerable<Food> GetFoodTrackers(DateTime date, int userID, int populated)
        {
            return trackerRepository.FoodTrackersPopulated(date, userID);
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