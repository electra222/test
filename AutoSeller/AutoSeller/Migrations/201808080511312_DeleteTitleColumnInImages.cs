namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTitleColumnInImages : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Images", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Title", c => c.String());
        }
    }
}
