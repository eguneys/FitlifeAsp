using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitlife.Domain.Abstract;
using Fitlife.Domain.Entities;

namespace Fitlife.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDBContext context = new EFDBContext();

        public IQueryable<User> Users
        {
            get { return context.Users; }
        }

        public bool ValidateUser(User user)
        {
            User dbEntry = context.Users.Where(x => x.Email == user.Email && x.PasswordDigest == user.Password).FirstOrDefault();
            if (dbEntry != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveUser(User user)
        {
            if (user.UserID == 0)
            {
                user.PasswordDigest = user.Password;
                context.Users.Add(user);
            }
            else
            {
                User dbEntry = context.Users.Find(user.UserID);
                if (dbEntry != null)
                {
                    dbEntry.Name = user.Name;
                    dbEntry.Email = user.Email;
                    dbEntry.Password = user.Password;
                    dbEntry.PasswordDigest = user.Password;
                    dbEntry.Photo = user.Photo;
                    dbEntry.Age = user.Age;
                }
            }
            context.SaveChanges();
        }
    }
}
