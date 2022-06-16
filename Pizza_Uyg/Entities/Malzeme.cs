using Pizza_Uyg.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Uyg.Entities
{
    [Table("Malzeme")]
    public class Malzeme:BaseEntity,IOrtak
    {
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }

        public override string ToString()
        {
            return Adi;
        }
    }
}
