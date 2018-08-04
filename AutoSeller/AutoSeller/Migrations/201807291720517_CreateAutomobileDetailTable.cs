namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAutomobileDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutomobileDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AutomobileId = c.Int(nullable: false),
                        DetailId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Automobiles", t => t.AutomobileId, cascadeDelete: true)
                .ForeignKey("dbo.Details", t => t.DetailId, cascadeDelete: true)
                .Index(t => t.AutomobileId)
                .Index(t => t.DetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AutomobileDetails", "DetailId", "dbo.Details");
            DropForeignKey("dbo.AutomobileDetails", "AutomobileId", "dbo.Automobiles");
            DropIndex("dbo.AutomobileDetails", new[] { "DetailId" });
            DropIndex("dbo.AutomobileDetails", new[] { "AutomobileId" });
            DropTable("dbo.AutomobileDetails");
        }
    }
}
