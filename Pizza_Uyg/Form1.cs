using Pizza_Uyg.Entities;
using Pizza_Uyg.Siparisler;
using Pizza_Uyg.Tanimlamalar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Uyg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pizzaTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPizza pizzaForm = new frmPizza();
            pizzaForm.ShowDialog();
        }

        private void pizzaTanımlaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEbat ebatForm = new frmEbat();
            ebatForm.ShowDialog();
        }

        private void pizzaTanımlaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmKenar kenarForm = new frmKenar();
            kenarForm.ShowDialog();
        }

        private void pizzaTanımlaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmMalzeme malzemeForm = new frmMalzeme();
            malzemeForm.ShowDialog();
        }

        private void siparişOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSiparis siparisForm = new frmSiparis();
            siparisForm.ShowDialog();
        }

        private void siparişListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSiparisListesi siparisListeForm = new frmSiparisListesi();
            siparisListeForm.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Programdan Çıkmak İstediğinizden Emin Misiniz?", "Çıkış Mesajı!", MessageBoxButtons.YesNo);

            if (x == DialogResult.Yes)
            {
                //Evet tıklandığında Yapılacak İşlemler
                Environment.Exit(0); 

            }
            else if (x == DialogResult.No)
            {
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtTumSiparis_Click(object sender, EventArgs e)
        {
            frmSiparisListesi siparisListeForm = new frmSiparisListesi();
            siparisListeForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSiparis siparisForm = new frmSiparis();
            siparisForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPizza pizzaForm = new frmPizza();
            pizzaForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEbat ebatForm = new frmEbat();
            ebatForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmKenar kenarForm = new frmKenar();
            kenarForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmMalzeme malzemeForm = new frmMalzeme();
            malzemeForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Programdan Çıkmak İstediğinizden Emin Misiniz?", "Çıkış Mesajı!", MessageBoxButtons.YesNo);

            if (x == DialogResult.Yes)
            {
                //Evet tıklandığında Yapılacak İşlemler
                Environment.Exit(0);

            }
            else if (x == DialogResult.No)
            {

            }
        }
    }
}
