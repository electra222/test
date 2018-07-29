namespace AutoSeller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMakeList2 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT AutomobileMakes on");
            Sql("INSERT INTO AutomobileMakes (Id, Name) VALUES (20, 'BYD'),(199, 'Byvin'),(21, 'Cadillac'),(24, 'Caterham'),(184, 'Changan'),(171, 'ChangFeng'),(25, 'Chery'),(26, 'Chevrolet'),(27, 'Chrysler'),(28, 'Citroen'),(30, 'Coggiola'),(31, 'Dacia'),(33, 'Daewoo'),(35, 'Daihatsu'),(36, 'Daimler'),(37, 'Datsun'),(40, 'Derways'),(41, 'Dodge'),(169, 'DongFeng'),(43, 'Donkervoort'),(213, 'DS'),(198, 'E-Car'),(197, 'Ecomotors'),(45, 'FAW'),(46, 'Ferrari'),(47, 'Fiat'),(196, 'Fisker'),(48, 'Ford'),(168, 'Foton'),(176, 'Fuqi'),(155, 'GAZ'),(50, 'Geely'),(232, 'Genesis'),(52, 'GMC'),(180, 'Gonow'),(211, 'Gordon'),(53, 'Great Wall'),(167, 'Hafei'),(189, 'Haima'),(212, 'Haval'),(209, 'Hawtai'),(54, 'Hindustan'),(55, 'Holden'),(56, 'Honda'),(177, 'HuangHai'),(57, 'Hummer'),(58, 'Hyundai'),(60, 'Infiniti'),(62, 'Invicta'),(59, 'Iran Khodro'),(64, 'Isuzu'),(65, 'IVECO'),(158, 'Izh'),(66, 'JAC'),(67, 'Jaguar'),(68, 'Jeep'),(242, 'Jinbei'),(182, 'JMC'),(70, 'Kia'),(71, 'Koenigsegg'),(223, 'Kombat'),(162, 'KTM'),(72, 'Lamborghini'),(73, 'Lancia'),(74, 'Land Rover'),(75, 'Landwind'),(76, 'Lexus'),(185, 'Liebao Motor'),(170, 'Lifan'),(77, 'Lincoln'),(78, 'Lotus'),(79, 'LTI'),(245, 'Lucid'),(194, 'Luxgen'),(80, 'Mahindra'),(163, 'Marlin'),(188, 'Marussia'),(82, 'Maruti'),(83, 'Maserati'),(84, 'Maybach'),(85, 'Mazda'),(86, 'McLaren'),(88, 'Mercedes-Benz'),(89, 'Mercury'),(91, 'MG'),(92, 'Microcar'),(94, 'MINI'),(95, 'Mitsubishi'),(96, 'Mitsuoka'),(97, 'Morgan'),(99, 'Nissan'),(100, 'Noble'),(102, 'Opel'),(104, 'Pagani'),(105, 'Panoz'),(106, 'Perodua'),(107, 'Peugeot'),(164, 'PGO'),(165, 'Piaggio'),(109, 'Pontiac'),(110, 'Porsche'),(112, 'Proton'),(113, 'PUCH'),(206, 'Qoros'),(225, 'Ravon'),(117, 'Renault'),(123, 'Renault Samsung'),(217, 'Rezvani'),(218, 'Rimac'),(118, 'Rolls-Royce'),(119, 'Ronart'),(121, 'Saab'),(192, 'Santana'),(124, 'Saturn'),(125, 'Scion'),(126, 'SEAT'),(214, 'Shanghai Maple'),(172, 'ShuangHuan'),(127, 'Skoda'),(128, 'Smart'),(174, 'Soueast'),(130, 'Spyker'),(131, 'SsangYong'),(132, 'Subaru'),(133, 'Suzuki'),(179, 'TagAZ'),(135, 'TATA'),(190, 'Tazzari'),(187, 'Tesla'),(239, 'Think'),(137, 'Tianma'),(140, 'Toyota'),(204, 'Tramontana'),(161, 'UAZ'),(210, 'Ultima'),(144, 'Vauxhall'),(154, 'VAZ (Lada)'),(147, 'Volkswagen'),(148, 'Volvo'),(166, 'Vortex'),(216, 'W Motors'),(150, 'Westfield'),(151, 'Wiesmann'),(152, 'Xin Kai'),(202, 'Yo-mobile'),(153, 'Zastava'),(156, 'ZAZ'),(228, 'Zenos'),(215, 'Zenvo'),(234, 'Zibar'),(193, 'Zotye'),(175, 'ZX')");
        }
        
        public override void Down()
        {
        }
    }
}
