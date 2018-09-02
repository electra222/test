namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusToAutomobileTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Automobiles", "StatusId", c => c.Int());
            CreateIndex("dbo.Automobiles", "StatusId");
            AddForeignKey("dbo.Automobiles", "StatusId", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Automobiles", "StatusId", "dbo.Status");
            DropIndex("dbo.Automobiles", new[] { "StatusId" });
            DropColumn("dbo.Automobiles", "StatusId");
        }
    }
}
