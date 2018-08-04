namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAutomobileNewParams2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Automobiles", "AutomobileMakeId", c => c.Int(nullable: false));
            AddColumn("dbo.Automobiles", "AutomobileModelId", c => c.Int(nullable: false));
            AddColumn("dbo.Automobiles", "Engine", c => c.String());
            AddColumn("dbo.Automobiles", "Color", c => c.String());
            AddColumn("dbo.Automobiles", "Doors", c => c.Byte(nullable: false));
            AddColumn("dbo.Automobiles", "Transmission", c => c.String());
            AddColumn("dbo.Automobiles", "Miles", c => c.Single(nullable: false));
            CreateIndex("dbo.Automobiles", "AutomobileMakeId");
            CreateIndex("dbo.Automobiles", "AutomobileModelId");
            AddForeignKey("dbo.Automobiles", "AutomobileMakeId", "dbo.AutomobileMakes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Automobiles", "AutomobileModelId", "dbo.AutomobileModels", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Automobiles", "AutomobileModelId", "dbo.AutomobileModels");
            DropForeignKey("dbo.Automobiles", "AutomobileMakeId", "dbo.AutomobileMakes");
            DropIndex("dbo.Automobiles", new[] { "AutomobileModelId" });
            DropIndex("dbo.Automobiles", new[] { "AutomobileMakeId" });
            DropColumn("dbo.Automobiles", "Miles");
            DropColumn("dbo.Automobiles", "Transmission");
            DropColumn("dbo.Automobiles", "Doors");
            DropColumn("dbo.Automobiles", "Color");
            DropColumn("dbo.Automobiles", "Engine");
            DropColumn("dbo.Automobiles", "AutomobileModelId");
            DropColumn("dbo.Automobiles", "AutomobileMakeId");
        }
    }
}
