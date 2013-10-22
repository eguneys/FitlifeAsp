using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitlife.Domain.Entities;

namespace Fitlife.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        void SaveUser(User u);
        bool ValidateUser(User u);
        bool ValidateUser(string username, string pass);
    }
}
