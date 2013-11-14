namespace Fitlife.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                        PhotoDescription = c.String(),
                        MuscleGroup = c.String(),
                    })
                .PrimaryKey(t => t.PhotoID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.BlogItems",
                c => new
                    {
                        BlogItemID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.BlogItemID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        BlogCommentID = c.Int(nullable: false, identity: true),
                        BlogItemID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.BlogCommentID)
                .ForeignKey("dbo.BlogItems", t => t.BlogItemID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.BlogItemID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.BlogLikes",
                c => new
                    {
                        BlogLikeID = c.Int(nullable: false, identity: true),
                        BlogItemID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogLikeID)
                .ForeignKey("dbo.BlogItems", t => t.BlogItemID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.BlogItemID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.FPEDs",
                c => new
                    {
                        FPEDID = c.Int(nullable: false, identity: true),
                        FoodCode = c.Int(nullable: false),
                        ModCode = c.Int(nullable: false),
                        Description = c.String(),
                        F_CITMLB = c.String(),
                        F_OTHER = c.String(),
                        F_JUICE = c.String(),
                        F_TOTAL = c.String(),
                        V_DRKGR = c.String(),
                        V_REDOR_TOATO = c.String(),
                        V_REDOR_OTHER = c.String(),
                        V_REDOR_TOTAL = c.String(),
                        V_STARCHY_POTATO = c.String(),
                        V_STARCHY_OTHER = c.String(),
                        V_STARCHY_TOTAL = c.String(),
                        V_OTHER = c.String(),
                        V_TOTAL = c.String(),
                        V_LEGUMES = c.String(),
                        G_WHOLE = c.String(),
                        G_REFINED = c.String(),
                        G_TOTAL = c.String(),
                        PF_MEAT = c.String(),
                        PF_CUREDMEAT = c.String(),
                        PF_ORGAN = c.String(),
                        PF_POULT = c.String(),
                        PF_SEAFD_HI = c.String(),
                        PF_SEAFD_LOW = c.String(),
                        PF_MPS_TOTAL = c.String(),
                        PF_EGGS = c.String(),
                        PF_SOY = c.String(),
                        PF_NUTSDS = c.String(),
                        PF_LEGUMES = c.String(),
                        PF_TOTAL = c.String(),
                        D_MILK = c.String(),
                        D_YOGURT = c.String(),
                        D_CHEESE = c.String(),
                        D_TOTAL = c.String(),
                        OILS = c.String(),
                        SOLID_FATS = c.String(),
                        ADD_SUGARS = c.String(),
                        A_DRINKS = c.String(),
                    })
                .PrimaryKey(t => t.FPEDID);
            
            CreateTable(
                "dbo.FoodTrackers",
                c => new
                    {
                        FoodTrackerID = c.Int(nullable: false, identity: true),
                        FoodCode = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        PortionCode = c.Int(nullable: false),
                        SelectedMeals = c.String(),
                        UserID = c.Int(nullable: false),
                        TrackDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FoodTrackerID);
            
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
                        NutrientID = c.Int(nullable: false, identity: true),
                        NutrientCode = c.Int(nullable: false),
                        Description = c.String(),
                        Tagname = c.String(),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.NutrientID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BlogLikes", new[] { "UserID" });
            DropIndex("dbo.BlogLikes", new[] { "BlogItemID" });
            DropIndex("dbo.BlogComments", new[] { "UserID" });
            DropIndex("dbo.BlogComments", new[] { "BlogItemID" });
            DropIndex("dbo.BlogItems", new[] { "UserID" });
            DropIndex("dbo.BodyPhoto", new[] { "UserID" });
            DropForeignKey("dbo.BlogLikes", "UserID", "dbo.Users");
            DropForeignKey("dbo.BlogLikes", "BlogItemID", "dbo.BlogItems");
            DropForeignKey("dbo.BlogComments", "UserID", "dbo.Users");
            DropForeignKey("dbo.BlogComments", "BlogItemID", "dbo.BlogItems");
            DropForeignKey("dbo.BlogItems", "UserID", "dbo.Users");
            DropForeignKey("dbo.BodyPhoto", "UserID", "dbo.Users");
            DropTable("dbo.NutrDescs");
            DropTable("dbo.PortionDescriptions");
            DropTable("dbo.FoodWeights");
            DropTable("dbo.FNDDSNutVals");
            DropTable("dbo.MainFoodDes");
            DropTable("dbo.FoodTrackers");
            DropTable("dbo.FPEDs");
            DropTable("dbo.BlogLikes");
            DropTable("dbo.BlogComments");
            DropTable("dbo.BlogItems");
            DropTable("dbo.BodyPhoto");
            DropTable("dbo.Users");
        }
    }
}
