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
    public partial class frmMalzeme : Form
    {
        public frmMalzeme()
        {
            InitializeComponent();
        }

        MalzemeRepository repo = new MalzemeRepository();

        private void frmMalzeme_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repo.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ekleme

            Malzeme yeniMalzeme = new Malzeme();
            yeniMalzeme.Adi = textBox1.Text;
            yeniMalzeme.Fiyat = Convert.ToDecimal(textBox2.Text);

            int gelenDeger = repo.Add(yeniMalzeme);

            if (gelenDeger > 0)
            {
                MessageBox.Show("Ekleme başarılıdır.");
                dataGridView1.DataSource = repo.GetAll();

                FormIslemleri.Temizle(this);
            }
        }

        Malzeme secilenMalzeme;

        private void button2_Click(object sender, EventArgs e)
        {
            // Güncelleme

            secilenMalzeme.Adi = textBox1.Text;
            secilenMalzeme.Fiyat = Convert.ToDecimal(textBox2.Text);

            int gelenDeger = repo.Edit(secilenMalzeme);

            if (gelenDeger > 0)
            {
                MessageBox.Show("Düzenleme işlemi başarılıdır.");
                dataGridView1.DataSource = repo.GetAll();

                FormIslemleri.Temizle(this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Silme

            int gelenDeger = repo.Delete(secilenMalzeme.Id);
            if (gelenDeger > 0)
            {
                MessageBox.Show("Silme işlemi başarıldır.");
                dataGridView1.DataSource = repo.GetAll();

                FormIslemleri.Temizle(this);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int malzemeId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            secilenMalzeme = repo.GetAll().Where(x => x.Id == malzemeId).FirstOrDefault();
            textBox1.Text = secilenMalzeme.Adi;
            textBox2.Text = secilenMalzeme.Fiyat.ToString();
        }
    }
}
