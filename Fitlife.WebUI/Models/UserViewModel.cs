using Fitlife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitlife.WebUI.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public UserProfile Profile { get; set; }

        public double UserBMI
        {
            get
            {
                if (Profile.Gender.Equals("male"))
                {
                    return 88.362 + (13.397 * Profile.Weight) + (4.799 * Profile.Height) + (5.677 * Profile.Age);
                }
                else
                {
                    return 447.593  + (9.247 * Profile.Weight) + (3.098 * Profile.Height) + (4.330 * Profile.Age);
                }
            }
        }

        private double[] CalorieCoefficients = new double[5] {1.2, 1.375, 1.55, 1.725, 1.9};
        public double DailyCalorieIntake
        {
            get
            {
                return UserBMI * CalorieCoefficients[(int)Profile.PhysicalActivity];
            }
        }

    }
}