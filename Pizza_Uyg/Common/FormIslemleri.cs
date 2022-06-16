using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Uyg.Common
{
   public class FormIslemleri
    {
        public static void Temizle(Form temizlenecekForm)
        {
            foreach (Control item in temizlenecekForm.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
    }
}
