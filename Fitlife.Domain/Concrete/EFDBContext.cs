﻿using System;
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

        public DbSet<MainFoodDes> MainFoodDes { get; set; }
        public DbSet<FNDDSNutVal> FNDDSNutVals { get; set; }
        public DbSet<FoodWeights> FoodWeights { get; set; }
        public DbSet<PortionDescriptions> PortionDescriptions { get; set; }
        public DbSet<NutrDesc> NutrDesc { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BodyPhoto>().ToTable("BodyPhoto");
        }


        public class Initializer : IDatabaseInitializer<EFDBContext>
        {
            public void InitializeDatabase(EFDBContext context)
            {
                if (!context.Database.Exists())
                {
                    context.Database.Create();
                    Seed(context);
                }
            }

            private void Seed(EFDBContext context)
            {

            }
        }
    }
}
