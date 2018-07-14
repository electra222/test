namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCountyData : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Countries on");
            Sql("INSERT INTO Countries(Id, CountryCode, Name) VALUES(1, 'GB', 'Great Britain')");
            Sql("INSERT INTO Countries(Id, CountryCode, Name) VALUES(2, 'GE', 'Germany')");
            Sql("INSERT INTO Countries(Id, CountryCode, Name) VALUES(3, 'IT', 'Italy')");
            Sql("INSERT INTO Countries(Id, CountryCode, Name) VALUES(4, 'USA', 'USA')");
        }
        
        public override void Down()
        {
        }
    }
}
