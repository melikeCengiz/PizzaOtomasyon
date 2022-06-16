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

namespace Pizza_Uyg.Siparisler
{
    public partial class frmSiparis : Form
    {
        public frmSiparis()
        {
            InitializeComponent();
        }

        EbatRepository ebatRepo = new EbatRepository();
        KenarRepository kenarRepo = new KenarRepository();
        MalzemeRepository malzemeRepo = new MalzemeRepository();
        PizzaRepository pizzaRepo = new PizzaRepository();
        SiparisRepository repo = new SiparisRepository();

        private void frmSiparis_Load(object sender, EventArgs e)
        {
            // Repository'de çekilen pizza isimlerini "pizzalar" listesi ile combobox'a attım.

            cmbPizza.DataSource = pizzaRepo.GetAll();
            cmbPizza.DataSource = pizzaRepo.GetAll();
            cmbKenar.DataSource = kenarRepo.GetAll();
            cmbEbat.DataSource = ebatRepo.GetAll();

            // Malzeme seçimi listesini oluşturma

            List<Malzeme> malzemeler = malzemeRepo.GetAll();
            foreach (Malzeme item in malzemeler)
            {
                flowLayoutPanel1.Controls.Add(new CheckBox { Text = item.Adi, Tag = item });
            }

        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            // Sipariş Ekleme

            DateTime? dt = null;

            DateTime dtt;

            if(dt.HasValue)
            {
                dtt = dt.Value;
            }
                       

            DateTime now = DateTime.Now; // Tarihi almak için

            Pizza secilenPizza =(Pizza) cmbPizza.SelectedItem;
            Ebat secilenEbat = (Ebat) cmbEbat.SelectedItem;
            Kenar secilenKenar = (Kenar) cmbKenar.SelectedItem;

            int adet = Convert.ToInt32(txtPizzaAdet.Text);

            decimal toplamTutar = (secilenPizza.Fiyat * secilenEbat.Fiyat) * adet;

            Siparis yeniSiparis = new Siparis();
            List<Malzeme> secilenMalzemeler = new List<Malzeme>();

            foreach (CheckBox item in flowLayoutPanel1.Controls)
            {
                if(item.Checked == true)
                {
                    Malzeme mlz = (Malzeme)item.Tag;
                    secilenMalzemeler.Add(mlz);
                    toplamTutar += mlz.Fiyat;
                    yeniSiparis.Malzeme += mlz.Adi+",";
                }
            }
            yeniSiparis.Malzeme.Trim(',');
           
            yeniSiparis.PizzaId = secilenPizza.Id;
            yeniSiparis.KenarId = secilenKenar.Id;
            yeniSiparis.EbatId = secilenEbat.Id;
            yeniSiparis.Adet = adet;
            yeniSiparis.AdiSoyadi = txtAdiSoyAdi.Text;
            yeniSiparis.BirimFiyat = secilenPizza.Fiyat;
            yeniSiparis.MailAdresi = txtMailAdresi.Text;
            yeniSiparis.Tarih = now;
            yeniSiparis.ToplamTutar = toplamTutar;
            label5.Text = toplamTutar.ToString();
           int sonuc =  repo.Add(yeniSiparis);

            if(sonuc > 0)
            {
                MessageBox.Show("Sipariş Alındı");
                label5.Text = 0.ToString(); ;
            }
            else
            {
                MessageBox.Show("Sipariş oluşturulurken bir hata ile karşılaşıldı");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
