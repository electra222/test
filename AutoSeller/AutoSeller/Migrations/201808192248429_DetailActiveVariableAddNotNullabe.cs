namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetailActiveVariableAddNotNullabe : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Details WHERE Id = 5");
        }
        
        public override void Down()
        {
        }
    }
}
