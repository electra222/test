namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileTableUpdateImageDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "AutomobileId", "dbo.Automobiles");
            DropIndex("dbo.Images", new[] { "AutomobileId" });
            AddColumn("dbo.FileModels", "ImagePath", c => c.String());
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        AutomobileId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.FileModels", "ImagePath");
            CreateIndex("dbo.Images", "AutomobileId");
            AddForeignKey("dbo.Images", "AutomobileId", "dbo.Automobiles", "Id");
        }
    }
}
