namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruncateFileModels : DbMigration
    {
        public override void Up()
        {
            Sql("TRUNCATE TABLE FileModels");
        }
        
        public override void Down()
        {
        }
    }
}
