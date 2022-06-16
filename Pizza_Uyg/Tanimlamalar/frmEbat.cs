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

namespace Pizza_Uyg
{
    public partial class frmEbat : Form
    {
        public frmEbat()
        {
            InitializeComponent();
        }

        EbatRepository repo = new EbatRepository();

        private void frmEbat_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repo.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ekleme  bölümü

            Ebat yeniEbat = new Ebat();
            yeniEbat.Adi = textBox1.Text;
            yeniEbat.Fiyat = Convert.ToDecimal(textBox2.Text);

            int gelenDeger = repo.Add(yeniEbat);

            if (gelenDeger > 0)
            {
                MessageBox.Show("Ekleme işlemi başarılıdır");
                dataGridView1.DataSource = repo.GetAll();

                FormIslemleri.Temizle(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Güncelleme var olan bir Id üzerinden yapılacağı için secilenEbatı burada da kullanıyoruz.
            secilenEbat.Adi = textBox1.Text;
            secilenEbat.Fiyat = Convert.ToDecimal(textBox2.Text);

            int gelenDeger = repo.Edit(secilenEbat);

            if (gelenDeger > 0)
            {
                MessageBox.Show("Düzenleme işlemi başarılıdır");
                dataGridView1.DataSource = repo.GetAll();

                FormIslemleri.Temizle(this);
            }

        }

        Ebat secilenEbat;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ebatId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            secilenEbat = repo.GetAll().Where(x => x.Id == ebatId).FirstOrDefault();
            textBox1.Text = secilenEbat.Adi;
            textBox2.Text = secilenEbat.Fiyat.ToString();
            // Single,SingleOrDefault,First,FirstOrDefault farkları ve calısma mantıkları araştırılsın.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Silme işlemi
            int gelenDeger = repo.Delete(secilenEbat.Id);
            if (gelenDeger > 0)
            {
                MessageBox.Show("Silme işlemi başarılıdır");
                dataGridView1.DataSource = repo.GetAll();

                FormIslemleri.Temizle(this);
            }
        }
    }
}
