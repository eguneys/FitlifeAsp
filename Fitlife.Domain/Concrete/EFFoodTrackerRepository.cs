using Fitlife.Domain.Abstract;
using Fitlife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitlife.Domain.Concrete
{
    public class EFFoodTrackerRepository : IFoodTrackerRepository
    {
        public EFDBContext context = new EFDBContext();

        //private static EFFoodTrackerRepository repository = new EFFoodTrackerRepository();

        public static EFFoodTrackerRepository getRepository()
        {
            return new EFFoodTrackerRepository();
          //  return repository;
        }

        public IQueryable<FoodTracker> FoodTrackers
        {
            get
            {
                return context.FoodTrackers;
            }
        }

        public IEnumerable<Food> FoodTrackersPopulated(DateTime date, int userID)
        {
            EFFoodRepository frepo = new EFFoodRepository();

            return FoodTrackers.Where(x=> x.UserID == userID && x.TrackDate == date).ToList().ConvertAll<Food>((x) =>
            {
                Food f = frepo.GetFood(x.FoodCode);
                f.SelectedMeals = x.SelectedMeals;
                f.Amount = x.Amount;
                f.Portion = frepo.PortionDescriptions.First(y => y.PortionCode == x.PortionCode);
                return f;
            });
        }

        public void SaveFoodTracker(FoodTracker tracker)
        {
            if (tracker.FoodTrackerID == 0)
            {
                context.FoodTrackers.Add(tracker);
            }
            else
            {
                throw new NotImplementedException();
            }
            context.SaveChanges();
        }
    }
}
