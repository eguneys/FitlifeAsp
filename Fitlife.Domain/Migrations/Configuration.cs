namespace Fitlife.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Fitlife.Domain.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<Fitlife.Domain.Concrete.EFDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Fitlife.Domain.Concrete.EFDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            // Run update-database -verbose to do migration
            // Update-database -TargetMigration:0 reset migrations
           
           FoodBuilder.buildFood(context);
        }
    }
}
