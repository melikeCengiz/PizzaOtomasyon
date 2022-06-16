using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Uyg.ViewModels
{
    //id ler gelmesin ve tanım tablolarından id yerine adları gelsin diyince view klasörü oluşturup orada görüntü modeli oluşturdum
    public class SiparisModel
    {
        public string AdiSoyadi { get; set; }
        public string MailAdresi { get; set; }
        public string TelNo { get; set; }
        public DateTime Tarih { get; set; }
        public decimal ToplamTutar { get; set; }
        public decimal BirimFiyat { get; set; }
        public int Adet { get; set; }
        public string PizzaAdi { get; set; }
        public string EbatAdi { get; set; }
        public string KenarAdi { get; set; }
        public string Malzeme { get; set; }
    }
}
