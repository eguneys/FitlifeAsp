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
    }
}
