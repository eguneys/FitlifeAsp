using Fitlife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitlife.Domain.Abstract
{
    public interface IFoodTrackerRepository
    {
        IQueryable<FoodTracker> FoodTrackers { get; }

        IEnumerable<Food> FoodTrackersPopulated(DateTime date, int userID);

        void SaveFoodTracker(FoodTracker tracker);
    }
}
