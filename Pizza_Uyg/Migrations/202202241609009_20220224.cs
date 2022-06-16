namespace Pizza_Uyg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20220224 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ebat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Siparis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Adet = c.Int(nullable: false),
                        PizzaId = c.Int(nullable: false),
                        EbatId = c.Int(nullable: false),
                        KenarId = c.Int(nullable: false),
                        Malzeme = c.String(),
                        TelNo = c.String(),
                        MailAdresi = c.String(),
                        AdiSoyadi = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ebat", t => t.EbatId, cascadeDelete: true)
                .ForeignKey("dbo.Pizza", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.PizzaId)
                .Index(t => t.EbatId);
            
            CreateTable(
                "dbo.Pizza",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kenar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Malzeme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Siparis", "PizzaId", "dbo.Pizza");
            DropForeignKey("dbo.Siparis", "EbatId", "dbo.Ebat");
            DropIndex("dbo.Siparis", new[] { "EbatId" });
            DropIndex("dbo.Siparis", new[] { "PizzaId" });
            DropTable("dbo.Malzeme");
            DropTable("dbo.Kenar");
            DropTable("dbo.Pizza");
            DropTable("dbo.Siparis");
            DropTable("dbo.Ebat");
        }
    }
}
