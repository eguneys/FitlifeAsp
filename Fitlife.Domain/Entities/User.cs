using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fitlife.Domain.Entities
{

    public class UserSafe
    {
            public UserSafe(User user)
            {
                UserID = user.UserID;
                Name = user.Name;
                Email = user.Email;
                Password = user.Password;
                PasswordConfirmation = user.PasswordConfirmation;
                PasswordDigest = user.PasswordDigest;
                Age = user.Age;
                Gender = user.Gender;
                Photo = user.Photo;
            }

        public UserSafe()
        {
            Age = 0;
            Photo = "http://placehold.it/200x200";
        }

        public int UserID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string PasswordConfirmation { get; set; }
        public string PasswordDigest { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }


    }

    public class User
    {
        public User()
        {
            Age = 0;
            Photo = "http://placehold.it/200x200";
        }

        public int UserID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string PasswordConfirmation { get; set; }
        public string PasswordDigest { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<BodyPhoto> BodyPhotos { get; set; }

    }

    public class UserProfile
    {
        public UserProfile()
        {
            Gender = "male";
        }
        public int UserProfileID { get; set; }
        public int UserID { get; set; }

        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        [Column("PhysicalActivity")]
        public int PhysicalActivityAsInt { get; set; }

        [NotMapped]
        public PhysicalActiviyLevel PhysicalActivity
        {
            get { return (PhysicalActiviyLevel)this.PhysicalActivityAsInt; }
            set { this.PhysicalActivityAsInt = (int)value; }
        }
    }

    public enum PhysicalActiviyLevel {
        LittleOrNone = 0,
        Light = 1,
        Moderate = 2,
        Heavy = 3,
        VeryHeavy = 4
    };
}
