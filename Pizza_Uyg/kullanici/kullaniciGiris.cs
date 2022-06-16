using Pizza_Uyg.Entities;
using Pizza_Uyg.Repository;
using Pizza_Uyg.Siparisler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Uyg.kullanici
{
    public partial class kullaniciGiris : Form
    {
        public kullaniciGiris()
        {
            InitializeComponent();
        }


       
        KullaniciRepository repo = new KullaniciRepository();

        private void kullaniciGiris_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum sifre = new SifremiUnuttum();
            sifre.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            YeniKullanici yeni = new YeniKullanici();
            yeni.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kullanici kul = new Kullanici();

            kul.KullaniciAdi = txtKadi.Text;
            kul.Sifre = txtSifre.Text;
            var sonuc = repo.Exist(kul);
            if (sonuc)
            {                
                kul.KullaniciAdi = txtKadi.Text;
                kul.Sifre = txtSifre.Text;

                MessageBox.Show("Başarılı");
                Form1 sip = new Form1();
                sip.ShowDialog();            
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");
            }
        }
    }
}
