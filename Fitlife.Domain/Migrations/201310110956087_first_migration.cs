namespace Fitlife.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(nullable: false),
                        PasswordDigest = c.String(),
                        Age = c.Int(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.BodyPhoto",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PhotoSource = c.String(),
                        MuscleGroup = c.String(),
                    })
                .PrimaryKey(t => t.PhotoID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.MainFoodDes",
                c => new
                    {
                        FoodCode = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.FoodCode);
            
            CreateTable(
                "dbo.FNDDSNutVals",
                c => new
                    {
                        FoodCode = c.Int(nullable: false),
                        NutrientCode = c.Int(nullable: false),
                        NutrientValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.FoodCode, t.NutrientCode });
            
            CreateTable(
                "dbo.FoodWeights",
                c => new
                    {
                        FoodWeightsID = c.Int(nullable: false, identity: true),
                        FoodCode = c.Int(nullable: false),
                        PortionCode = c.Int(nullable: false),
                        PortionWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FoodWeightsID);
            
            CreateTable(
                "dbo.PortionDescriptions",
                c => new
                    {
                        PortionID = c.Int(nullable: false, identity: true),
                        PortionCode = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PortionID);
            
            CreateTable(
                "dbo.NutrDescs",
                c => new
                    {
                        NutrientCode = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Tagname = c.String(),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.NutrientCode);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BodyPhoto", new[] { "UserID" });
            DropForeignKey("dbo.BodyPhoto", "UserID", "dbo.Users");
            DropTable("dbo.NutrDescs");
            DropTable("dbo.PortionDescriptions");
            DropTable("dbo.FoodWeights");
            DropTable("dbo.FNDDSNutVals");
            DropTable("dbo.MainFoodDes");
            DropTable("dbo.BodyPhoto");
            DropTable("dbo.Users");
        }
    }
}
