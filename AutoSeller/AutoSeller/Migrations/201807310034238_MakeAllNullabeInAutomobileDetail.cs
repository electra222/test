namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeAllNullabeInAutomobileDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AutomobileDetails", "AutomobileId", "dbo.Automobiles");
            DropForeignKey("dbo.AutomobileDetails", "DetailId", "dbo.Details");
            DropIndex("dbo.AutomobileDetails", new[] { "AutomobileId" });
            DropIndex("dbo.AutomobileDetails", new[] { "DetailId" });
            AlterColumn("dbo.AutomobileDetails", "AutomobileId", c => c.Int());
            AlterColumn("dbo.AutomobileDetails", "DetailId", c => c.Int());
            CreateIndex("dbo.AutomobileDetails", "AutomobileId");
            CreateIndex("dbo.AutomobileDetails", "DetailId");
            AddForeignKey("dbo.AutomobileDetails", "AutomobileId", "dbo.Automobiles", "Id");
            AddForeignKey("dbo.AutomobileDetails", "DetailId", "dbo.Details", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AutomobileDetails", "DetailId", "dbo.Details");
            DropForeignKey("dbo.AutomobileDetails", "AutomobileId", "dbo.Automobiles");
            DropIndex("dbo.AutomobileDetails", new[] { "DetailId" });
            DropIndex("dbo.AutomobileDetails", new[] { "AutomobileId" });
            AlterColumn("dbo.AutomobileDetails", "DetailId", c => c.Int(nullable: false));
            AlterColumn("dbo.AutomobileDetails", "AutomobileId", c => c.Int(nullable: false));
            CreateIndex("dbo.AutomobileDetails", "DetailId");
            CreateIndex("dbo.AutomobileDetails", "AutomobileId");
            AddForeignKey("dbo.AutomobileDetails", "DetailId", "dbo.Details", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AutomobileDetails", "AutomobileId", "dbo.Automobiles", "Id", cascadeDelete: true);
        }
    }
}
