using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitlife.Domain.Entities
{
    public class FoodTracker
    {
        public int FoodTrackerID { get; set; }

        public int FoodCode { get; set; }
        public int Amount { get; set; }
        public int PortionCode { get; set; }
        public string SelectedMeals { get; set; }

        public int UserID { get; set; }
        public DateTime TrackDate { get; set; }
    }
}
