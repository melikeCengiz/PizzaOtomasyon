using Pizza_Uyg.Common;
using Pizza_Uyg.Entities;
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

namespace Pizza_Uyg.Tanimlamalar
{
    public partial class frmKenar : Form
    {
        public frmKenar()
        {
            InitializeComponent();
        }

        KenarRepository repo = new KenarRepository();

        private void frmKenar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repo.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ekleme bölümü
            Kenar yeniKenar = new Kenar();
            yeniKenar.Adi = textBox1.Text;

            int gelenDeger = repo.Add(yeniKenar);

            if (gelenDeger > 0)
            {
                MessageBox.Show("Ekleme işlemi başarılıdır.");
                dataGridView1.DataSource = repo.GetAll();
                FormIslemleri.Temizle(this);
            }
        }
        Kenar secilenKenar;

        private void button2_Click(object sender, EventArgs e)
        {
            // Güncelleme
            secilenKenar.Adi = textBox1.Text;

            int gelenDeger = repo.Edit(secilenKenar);

            if (gelenDeger > 0)
            {
                MessageBox.Show("Düzenleme işlemi başarılıdır.");
                dataGridView1.DataSource = repo.GetAll();

                FormIslemleri.Temizle(this);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Silme işlemi
            int gelenDeger = repo.Delete(secilenKenar.Id);
            if (gelenDeger > 0)
            {
                MessageBox.Show("Silme işlemi başarılıdır.");
                dataGridView1.DataSource = repo.GetAll();

                FormIslemleri.Temizle(this);
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int kenarId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            secilenKenar = repo.GetAll().Where(x => x.Id == kenarId).FirstOrDefault();
            textBox1.Text = secilenKenar.Adi;
        }
    }

    
}
