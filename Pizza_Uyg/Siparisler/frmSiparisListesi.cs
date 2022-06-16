using Pizza_Uyg.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Uyg.Siparisler
{
    public partial class frmSiparisListesi : Form
    {
        public frmSiparisListesi()
        {
            InitializeComponent();
        }

        private void frmSiparisListesi_Load(object sender, EventArgs e)
        {


            SiparisRepository repo = new SiparisRepository();

            dataGridView1.DataSource = repo.GetAll_Siparisler();
        }
    }
}
