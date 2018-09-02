namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusesTableFill2 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Status on");
            Sql("INSERT INTO Status(Id, Name) VALUES (1, 'Active')");
            Sql("INSERT INTO Status(Id, Name) VALUES (2, 'Deleted')");
        }
        
        public override void Down()
        {
        }
    }
}
