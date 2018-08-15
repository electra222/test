namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileTableCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileModels");
        }
    }
}
