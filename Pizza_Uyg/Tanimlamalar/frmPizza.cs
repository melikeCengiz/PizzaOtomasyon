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
    public partial class frmPizza : Form
    {
        public frmPizza()
        {
            InitializeComponent();
        }

        PizzaRepository repo = new PizzaRepository();
        private void frmPizza_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repo.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ekle
            Pizza yeniPizza = new Pizza();
            yeniPizza.Adi = textBox1.Text;
            yeniPizza.Fiyat = Convert.ToDecimal(textBox2.Text);
            int gelenDeger = repo.Add(yeniPizza);

            if (gelenDeger > 0)
            {
                MessageBox.Show("Ekleme işlemi başarılıdır");
                dataGridView1.DataSource = repo.GetAll();

                FormIslemleri.Temizle(this);
            }
        }

        Pizza secilenPizza;
        private void button2_Click(object sender, EventArgs e)
        {
            // Güncelleme var olan bir Id üzerinden yapılacağı için secilenEbatı burada da kullanıyoruz.
            secilenPizza.Adi = textBox1.Text;
            secilenPizza.Fiyat = Convert.ToDecimal(textBox2.Text);
            int gelenDeger = repo.Edit(secilenPizza);

            if (gelenDeger > 0)
            {
                MessageBox.Show("Düzenleme işlemi başarılıdır");
                dataGridView1.DataSource = repo.GetAll();

                FormIslemleri.Temizle(this);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Silme işlemi
            int gelenDeger = repo.Delete(secilenPizza.Id);
            if (gelenDeger > 0)
            {
                MessageBox.Show("Silme işlemi başarılıdır");
                dataGridView1.DataSource = repo.GetAll();

                FormIslemleri.Temizle(this);
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pizzaId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            secilenPizza = repo.GetAll().Where(x => x.Id == pizzaId).FirstOrDefault();
            textBox1.Text = secilenPizza.Adi;
            textBox2.Text = secilenPizza.Fiyat.ToString();
        }
      
    }
}
