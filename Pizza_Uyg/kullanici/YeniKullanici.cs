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

namespace Pizza_Uyg.kullanici
{
    public partial class YeniKullanici : Form
    {
        public YeniKullanici()
        {
            InitializeComponent();
        }

        KullaniciRepository repo = new KullaniciRepository();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();

            //bu if bloğunda modelini dolduruyorsun bu yüzden ekleme fonksiyonuda bu bloğun içinde olmalı dönen değer 0 dan büyükse yani kaydı eklediysen de mesajı ekrana basmışsın 
            if (txtSifre.Text == txtSifreTekrar.Text)
            {
                k.AdSoyad = txtAdSoyad.Text;
                k.KullaniciAdi = txtKadi.Text;
                k.Sifre = txtSifre.Text;

                int gelenDeger = repo.Add(k);

                if (gelenDeger > 0)
                {
                    MessageBox.Show("Ekleme işlemi başarılıdır");

                    FormIslemleri.Temizle(this);
                }
                else
                {
                    MessageBox.Show("Ekleme İşlemi Başarısızdır.");
                }
            }
            else if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Lütfen şifreleri aynı giriniz");
            }
      }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox işaretli ise
            if (checkBox1.Checked)
            {
                //karakteri göster.
                txtSifre.PasswordChar = '\0';
                txtSifreTekrar.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                txtSifre.PasswordChar = '*';
                txtSifreTekrar.PasswordChar = '*';
            }
        }
        private void YeniKullanici_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
            txtSifreTekrar.PasswordChar = '*';
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
