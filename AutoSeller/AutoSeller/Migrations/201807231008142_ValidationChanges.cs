namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Automobiles", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Automobiles", "Name", c => c.String());
        }
    }
}
