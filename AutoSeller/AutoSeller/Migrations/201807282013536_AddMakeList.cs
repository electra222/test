namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMakeList : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT AutomobileMakes on");
            Sql("INSERT INTO AutomobileMakes (Id, Name) VALUES (1, 'AC'), (2, 'Acura'), (3, 'Alfa Romeo'), (4, 'Alpina'), (5, 'Alpine'), (195, 'AM General'), (191, 'Ariel'), (8, 'Aston Martin'), (9, 'Audi'), (240, 'Bajaj'), (12, 'Beijing'), (13, 'Bentley'), (238, 'Bilenkin'), (16, 'BMW'), (224, 'Borgward'), (207, 'Brabus'), (173, 'Brilliance'), (17, 'Bristol'), (203, 'Bronto'), (183, 'Bufori'), (18, 'Bugatti'), (19, 'Buick')");
            
        }
        
        public override void Down()
        {
        }
    }
}
