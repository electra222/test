namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetailActiveVariableAddNotNullabe2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Details", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Details", "Active", c => c.Boolean());
        }
    }
}
