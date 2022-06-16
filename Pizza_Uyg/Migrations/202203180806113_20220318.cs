namespace Pizza_Uyg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20220318 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                        KullaniciAdi = c.String(),
                        Sifre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kullanici");
        }
    }
}
