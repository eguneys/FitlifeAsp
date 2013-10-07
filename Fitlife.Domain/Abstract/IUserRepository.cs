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
    }
}
