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
        public EFDBContext(): base()
        {
        }

        public EFDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BodyPhoto> Photos { get; set; }
        public DbSet<BlogItem> BlogItems { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogLike> BlogLikes { get; set; }
        public DbSet<FPED> FPEDs { get; set; }
        public DbSet<FoodTracker> FoodTrackers { get; set; }



        public DbSet<MainFoodDes> MainFoodDes { get; set; }
        public DbSet<FNDDSNutVal> FNDDSNutVals { get; set; }
        public DbSet<FoodWeights> FoodWeights { get; set; }
        public DbSet<PortionDescriptions> PortionDescriptions { get; set; }
        public DbSet<NutrDesc> NutrDesc { get; set; }

        public DbSet<UserProfile> Profiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BodyPhoto>().ToTable("BodyPhoto");

            modelBuilder.Entity<BlogComment>()
                .HasRequired(c => c.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BlogLike>()
                .HasRequired(c => c.User)
                .WithMany()
                .WillCascadeOnDelete(false);
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
