namespace Fitlife.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_profile_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserProfileID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.UserProfileID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfiles");
        }
    }
}
