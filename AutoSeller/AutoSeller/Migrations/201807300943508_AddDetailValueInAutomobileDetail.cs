namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetailValueInAutomobileDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AutomobileDetails", "DetailValue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AutomobileDetails", "DetailValue");
        }
    }
}
