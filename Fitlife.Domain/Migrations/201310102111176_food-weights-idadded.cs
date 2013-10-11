namespace Fitlife.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodweightsidadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodWeights", "FoodWeightsID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.FoodWeights", new[] { "FoodCode", "PortionCode" });
            AddPrimaryKey("dbo.FoodWeights", "FoodWeightsID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FoodWeights", new[] { "FoodWeightsID" });
            AddPrimaryKey("dbo.FoodWeights", new[] { "FoodCode", "PortionCode" });
            DropColumn("dbo.FoodWeights", "FoodWeightsID");
        }
    }
}
