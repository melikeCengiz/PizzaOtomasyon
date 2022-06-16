using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Uyg.Common
{
    // gönderilecek generic Tipin sadece class olması için bir filtre yazdık.

    interface IRepository<T> where T:class
    {
        //CRUD - Create,Read,Update,Delete

        int Add(T veri);

        int Edit(T veri);

        int Delete(int veriId);

        List<T> GetAll();

    }
}
