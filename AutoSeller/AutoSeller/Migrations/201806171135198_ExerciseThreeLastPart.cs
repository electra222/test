namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExerciseThreeLastPart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Automobiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateImported = c.DateTime(nullable: false),
                        NuberInStock = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Automobiles", "CountryId", "dbo.Countries");
            DropIndex("dbo.Automobiles", new[] { "CountryId" });
            DropTable("dbo.Countries");
            DropTable("dbo.Automobiles");
        }
    }
}
