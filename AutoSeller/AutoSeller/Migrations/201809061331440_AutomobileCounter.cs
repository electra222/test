namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutomobileCounter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Automobiles", "Counter", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Automobiles", "Counter");
        }
    }
}
