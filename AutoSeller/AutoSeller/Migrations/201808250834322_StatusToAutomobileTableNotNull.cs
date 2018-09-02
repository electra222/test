namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusToAutomobileTableNotNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Automobiles", "StatusId", "dbo.Status");
            DropIndex("dbo.Automobiles", new[] { "StatusId" });
            AlterColumn("dbo.Automobiles", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Automobiles", "StatusId");
            AddForeignKey("dbo.Automobiles", "StatusId", "dbo.Status", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Automobiles", "StatusId", "dbo.Status");
            DropIndex("dbo.Automobiles", new[] { "StatusId" });
            AlterColumn("dbo.Automobiles", "StatusId", c => c.Int());
            CreateIndex("dbo.Automobiles", "StatusId");
            AddForeignKey("dbo.Automobiles", "StatusId", "dbo.Status", "Id");
        }
    }
}
