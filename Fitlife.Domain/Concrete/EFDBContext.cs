using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Fitlife.Domain.Entities;

namespace Fitlife.Domain.Concrete
{
    public class EFDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BodyPhoto> Photos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BodyPhoto>().ToTable("BodyPhoto");
        }
    }
}
