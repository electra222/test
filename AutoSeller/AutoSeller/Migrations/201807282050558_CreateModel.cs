namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutomobileModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        AutomobileMakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AutomobileMakes", t => t.AutomobileMakeId, cascadeDelete: true)
                .Index(t => t.AutomobileMakeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AutomobileModels", "AutomobileMakeId", "dbo.AutomobileMakes");
            DropIndex("dbo.AutomobileModels", new[] { "AutomobileMakeId" });
            DropTable("dbo.AutomobileModels");
        }
    }
}
