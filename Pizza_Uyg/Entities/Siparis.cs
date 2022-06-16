using Pizza_Uyg.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Uyg.Entities
{
    [Table("Siparis")]
    public class Siparis :BaseEntity
    {
        public DateTime Tarih { get; set; }
        public decimal ToplamTutar { get; set; }
        public decimal BirimFiyat { get; set; }
        public int Adet { get; set; }
        public int PizzaId { get; set; }
        public int EbatId { get; set; }
        public int KenarId { get; set; }
        public string Malzeme { get; set; }
        public string TelNo { get; set; }
        public string MailAdresi { get; set; }
        public string AdiSoyadi { get; set; }

        public Pizza SeciliPizza { get; set; }
        public Ebat SeciliEbat { get; set; }

    }
}
