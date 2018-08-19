namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutomobileTableEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Automobiles", "EngineId", c => c.Int());
            CreateIndex("dbo.Automobiles", "EngineId");
            AddForeignKey("dbo.Automobiles", "EngineId", "dbo.Engines", "Id");
            DropColumn("dbo.Automobiles", "Name");
            DropColumn("dbo.Automobiles", "NuberInStock");
            DropColumn("dbo.Automobiles", "Engine");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Automobiles", "Engine", c => c.String());
            AddColumn("dbo.Automobiles", "NuberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Automobiles", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Automobiles", "EngineId", "dbo.Engines");
            DropIndex("dbo.Automobiles", new[] { "EngineId" });
            DropColumn("dbo.Automobiles", "EngineId");
        }
    }
}
