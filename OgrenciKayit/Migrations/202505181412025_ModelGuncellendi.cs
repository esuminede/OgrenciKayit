namespace OgrenciKayit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelGuncellendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ogrencis", "Hakkinda", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ogrencis", "Hakkinda");
        }
    }
}
