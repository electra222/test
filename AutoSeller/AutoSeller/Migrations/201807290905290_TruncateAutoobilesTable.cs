namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruncateAutoobilesTable : DbMigration
    {
        public override void Up()
        {
            Sql("TRUNCATE TABLE Automobiles");
        }
        
        public override void Down()
        {
        }
    }
}
