namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateImageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImagePath = c.String(),
                        AutomobileId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Automobiles", t => t.AutomobileId)
                .Index(t => t.AutomobileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "AutomobileId", "dbo.Automobiles");
            DropIndex("dbo.Images", new[] { "AutomobileId" });
            DropTable("dbo.Images");
        }
    }
}
