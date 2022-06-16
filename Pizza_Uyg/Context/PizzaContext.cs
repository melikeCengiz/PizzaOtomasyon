using Pizza_Uyg.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Uyg.Context
{
    public class PizzaContext:DbContext
    {
        public PizzaContext()
        {
            Database.Connection.ConnectionString = "Server=DESKTOP-C2STFC3\\SQLEXPRESS;Database=PizzaDb;Trusted_Connection=true";
        }
        public DbSet<Ebat> Ebat { get; set; }
        public DbSet<Kenar> Kenar { get; set; }
        public DbSet<Malzeme> Malzeme { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Siparis>()
           .HasRequired<Ebat>(s => s.SeciliEbat)
           .WithMany(x=>x.Siparis)
           .HasForeignKey(s => s.EbatId);

            modelBuilder.Entity<Siparis>()
           .HasRequired<Pizza>(s => s.SeciliPizza)
           .WithMany(x => x.Siparis)
           .HasForeignKey(s => s.PizzaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
