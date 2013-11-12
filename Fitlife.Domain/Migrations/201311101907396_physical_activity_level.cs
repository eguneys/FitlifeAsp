namespace Fitlife.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class physical_activity_level : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "PhysicalActivity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "PhysicalActivity");
        }
    }
}
