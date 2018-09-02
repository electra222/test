namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetailActiveVariableAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "Active", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Details", "Active");
        }
    }
}
