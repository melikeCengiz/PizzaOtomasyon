using Pizza_Uyg.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Uyg.Entities
{
    [Table("Kullanici")] 
    public class Kullanici: BaseEntity
    {
        public string AdSoyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }


    }
}
