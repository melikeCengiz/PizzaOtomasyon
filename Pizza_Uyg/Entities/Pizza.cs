using Pizza_Uyg.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Uyg.Entities
{
    [Table("Pizza")]
    public class Pizza : BaseEntity, IOrtak
    {
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }

        public ICollection<Siparis> Siparis { get; set; } = new List<Siparis>();
        public override string ToString()
        {
            return Adi;
        }
    }
}
