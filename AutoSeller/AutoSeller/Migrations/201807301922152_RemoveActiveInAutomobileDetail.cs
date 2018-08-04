namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveActiveInAutomobileDetail : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AutomobileDetails", "Active");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AutomobileDetails", "Active", c => c.Boolean(nullable: false));
        }
    }
}
