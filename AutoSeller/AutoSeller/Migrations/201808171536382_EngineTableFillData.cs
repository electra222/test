namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EngineTableFillData : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Engines on");
            Sql("INSERT into Engines(Id, Name) VALUES(1,'Diesel')");
            Sql("INSERT into Engines(Id, Name) VALUES(2,'Benzine')");
            Sql("INSERT into Engines(Id, Name) VALUES(3,'Hybrid')");
            Sql("INSERT into Engines(Id, Name) VALUES(4,'Electric')");
        }

        public override void Down()
        {
        }
    }
}
