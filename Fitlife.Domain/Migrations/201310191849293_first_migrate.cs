namespace Fitlife.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_migrate : DbMigration
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
                        F_CITMLB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        F_OTHER = c.Decimal(nullable: false, precision: 18, scale: 2),
                        F_JUICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        F_TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        V_DRKGR = c.Decimal(nullable: false, precision: 18, scale: 2),
                        V_REDOR_TOATO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        V_REDOR_OTHER = c.Decimal(nullable: false, precision: 18, scale: 2),
                        V_REDOR_TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        V_STARCHY_POTATO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        V_STARCHY_OTHER = c.Decimal(nullable: false, precision: 18, scale: 2),
                        V_STARCHY_TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        V_OTHER = c.Decimal(nullable: false, precision: 18, scale: 2),
                        V_TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        V_LEGUMES = c.Decimal(nullable: false, precision: 18, scale: 2),
                        G_WHOLE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        G_REFINED = c.Decimal(nullable: false, precision: 18, scale: 2),
                        G_TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_MEAT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_CUREDMEAT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_ORGAN = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_POULT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_SEAFD_HI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_SEAFD_LOW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_MPS_TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_EGGS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_SOY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_NUTSDS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_LEGUMES = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PF_TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        D_MILK = c.Decimal(nullable: false, precision: 18, scale: 2),
                        D_YOGURT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        D_CHEESE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        D_TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OILS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOLID_FATS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ADD_SUGARS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        A_DRINKS = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FPEDID);
            
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
            DropTable("dbo.FPEDs");
            DropTable("dbo.BlogLikes");
            DropTable("dbo.BlogComments");
            DropTable("dbo.BlogItems");
            DropTable("dbo.BodyPhoto");
            DropTable("dbo.Users");
        }
    }
}
