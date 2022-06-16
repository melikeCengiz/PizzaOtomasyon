using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Uyg.Common
{
    interface IOrtak
    {
        /*
         
         c# dilinde 1 class sadece 1 classtan miras alabilir. Interface'ler bu problemi gidermek için vardır. Interface ile amaçlanan multiple inheritance'dır

         Diğer bir amacı bir standarrt oluşturarak Interface' i miras alan sınıflarda o özelliklerini kesinlikle barındırılıyor ve dolduruluyor olmasıdır .

        Interface sadece miras verir , Abstract classlar gibi instance alınamazlar.

        Interface'in tek amacı bir şeyleri barındırmaktır. Bu yüzden bazı kullanım kısıtlamaları vardır.
         
         Kısıtlamalar ;
        instance alınamaz,
        field tanımlanamaz,
        üyeleri sadece property ve metot olabilir,
        üyelerinin erişim seviye yazılmaz. üyeler miras verileceği için genel olmalıdır
        üyelerini varsayılan erişim seviyesi interface in erişim seviyesidir.
        üyelerinin gövdeleri olmaz.
        üyelerin , abstract classlarda olduğu gibi(abstract metot) implement(miras alan sınıf tamamlamak) zorundadır
         
         */

        string Adi { get; set; }
        decimal Fiyat { get; set; }

    }
}
