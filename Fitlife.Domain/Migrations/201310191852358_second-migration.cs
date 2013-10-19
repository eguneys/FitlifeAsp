namespace Fitlife.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FPEDs", "F_CITMLB", c => c.String());
            AlterColumn("dbo.FPEDs", "F_OTHER", c => c.String());
            AlterColumn("dbo.FPEDs", "F_JUICE", c => c.String());
            AlterColumn("dbo.FPEDs", "F_TOTAL", c => c.String());
            AlterColumn("dbo.FPEDs", "V_DRKGR", c => c.String());
            AlterColumn("dbo.FPEDs", "V_REDOR_TOATO", c => c.String());
            AlterColumn("dbo.FPEDs", "V_REDOR_OTHER", c => c.String());
            AlterColumn("dbo.FPEDs", "V_REDOR_TOTAL", c => c.String());
            AlterColumn("dbo.FPEDs", "V_STARCHY_POTATO", c => c.String());
            AlterColumn("dbo.FPEDs", "V_STARCHY_OTHER", c => c.String());
            AlterColumn("dbo.FPEDs", "V_STARCHY_TOTAL", c => c.String());
            AlterColumn("dbo.FPEDs", "V_OTHER", c => c.String());
            AlterColumn("dbo.FPEDs", "V_TOTAL", c => c.String());
            AlterColumn("dbo.FPEDs", "V_LEGUMES", c => c.String());
            AlterColumn("dbo.FPEDs", "G_WHOLE", c => c.String());
            AlterColumn("dbo.FPEDs", "G_REFINED", c => c.String());
            AlterColumn("dbo.FPEDs", "G_TOTAL", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_MEAT", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_CUREDMEAT", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_ORGAN", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_POULT", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_SEAFD_HI", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_SEAFD_LOW", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_MPS_TOTAL", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_EGGS", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_SOY", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_NUTSDS", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_LEGUMES", c => c.String());
            AlterColumn("dbo.FPEDs", "PF_TOTAL", c => c.String());
            AlterColumn("dbo.FPEDs", "D_MILK", c => c.String());
            AlterColumn("dbo.FPEDs", "D_YOGURT", c => c.String());
            AlterColumn("dbo.FPEDs", "D_CHEESE", c => c.String());
            AlterColumn("dbo.FPEDs", "D_TOTAL", c => c.String());
            AlterColumn("dbo.FPEDs", "OILS", c => c.String());
            AlterColumn("dbo.FPEDs", "SOLID_FATS", c => c.String());
            AlterColumn("dbo.FPEDs", "ADD_SUGARS", c => c.String());
            AlterColumn("dbo.FPEDs", "A_DRINKS", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FPEDs", "A_DRINKS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "ADD_SUGARS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "SOLID_FATS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "OILS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "D_TOTAL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "D_CHEESE", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "D_YOGURT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "D_MILK", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_TOTAL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_LEGUMES", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_NUTSDS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_SOY", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_EGGS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_MPS_TOTAL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_SEAFD_LOW", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_SEAFD_HI", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_POULT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_ORGAN", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_CUREDMEAT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "PF_MEAT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "G_TOTAL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "G_REFINED", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "G_WHOLE", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "V_LEGUMES", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "V_TOTAL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "V_OTHER", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "V_STARCHY_TOTAL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "V_STARCHY_OTHER", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "V_STARCHY_POTATO", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "V_REDOR_TOTAL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "V_REDOR_OTHER", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "V_REDOR_TOATO", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "V_DRKGR", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "F_TOTAL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "F_JUICE", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "F_OTHER", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.FPEDs", "F_CITMLB", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
