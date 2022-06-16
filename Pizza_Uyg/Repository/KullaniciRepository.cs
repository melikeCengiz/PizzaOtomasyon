using Pizza_Uyg.Common;
using Pizza_Uyg.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Uyg.Repository
{
    public class KullaniciRepository : IRepository<Kullanici>
    {
        SqlConnection cnn;

        public KullaniciRepository()
        {
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PizzaConnection"].ConnectionString);
        }

        public int Add(Kullanici veri)
        {
            SqlCommand cmd = new SqlCommand("insert Kullanici (AdSoyad,KullaniciAdi,Sifre) values (@AdSoyad,@KullaniciAdi,@Sifre)", cnn);
            cmd.Parameters.AddWithValue("@AdSoyad", veri.AdSoyad);
            cmd.Parameters.AddWithValue("@KullaniciAdi", veri.KullaniciAdi);
            cmd.Parameters.AddWithValue("@Sifre", veri.Sifre);

            cnn.Open();

            int sonuc = 0;

            try
            {
                sonuc = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                sonuc = 0;
            }

            cnn.Close();
            return sonuc;
        }

        public int Delete(int veriId)
        {
            throw new NotImplementedException();
        }

        public int Edit(Kullanici veri)
        {
            throw new NotImplementedException();
        }
        //exist fonksiyonunu bütün repositorylerde değilde sadece kullanıcı kısmında kullanacağımız için buraya ekledik temel 4 fonksiyon haricinde "var mı" manasına gelen exist fonksiyonunu oluşturduk
        public bool Exist(Kullanici veri)
        {
            SqlCommand cmd = new SqlCommand("Select * From Kullanici Where KullaniciAdi=@KullaniciAdi And Sifre=@Sifre ", cnn);
            cmd.Parameters.AddWithValue("@KullaniciAdi", veri.KullaniciAdi);
            cmd.Parameters.AddWithValue("@Sifre", veri.Sifre);

            cnn.Open();

            bool sonuc = false;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    sonuc = true;
                }
                dr.Close();
            }
            catch (Exception)
            {
            }

            cnn.Close();
            return sonuc;           
        }

        public List<Kullanici> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
