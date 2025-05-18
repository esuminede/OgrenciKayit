namespace OgrenciKayit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        OgrenciNo = c.Int(nullable: false),
                        Sinif = c.String(nullable: false),
                        Isim = c.String(nullable: false),
                        Soyisim = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OgrenciNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ogrencis");
        }
    }
}
