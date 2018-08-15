namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTitleInImages : DbMigration
    {
        public override void Up()
        {
            Sql("TRUNCATE TABLE Images");
        }
        
        public override void Down()
        {
        }
    }
}
