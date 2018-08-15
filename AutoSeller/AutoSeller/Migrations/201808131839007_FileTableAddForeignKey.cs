namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileTableAddForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileModels", "AutomobileId", c => c.Int());
            CreateIndex("dbo.FileModels", "AutomobileId");
            AddForeignKey("dbo.FileModels", "AutomobileId", "dbo.Automobiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileModels", "AutomobileId", "dbo.Automobiles");
            DropIndex("dbo.FileModels", new[] { "AutomobileId" });
            DropColumn("dbo.FileModels", "AutomobileId");
        }
    }
}
