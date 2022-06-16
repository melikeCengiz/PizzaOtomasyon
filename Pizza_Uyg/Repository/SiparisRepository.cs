using Pizza_Uyg.Common;
using Pizza_Uyg.Entities;
using Pizza_Uyg.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Uyg.Repository
{
    public class SiparisRepository
    {

        SqlConnection cnn;

        public SiparisRepository()
        {
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PizzaConnection"].ConnectionString);
        }

        // Pizza tablosundan Adi kolonunu listeye çekiyorum.

        public List<string> pizzalar = new List<string>();

       
        internal object GetAll()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAll_Pizzalar()
        {
            SqlCommand cmd = new SqlCommand("select * from Pizza", cnn);
            cnn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                pizzalar.Add(rdr["Adi"].ToString());
            }

            cnn.Close();
            return pizzalar;
        }

        // Ebat tablosundan Adi kolonunu listeye çekiyorum.

        public List<string> ebatlar = new List<string>();

        public List<string> GetAll_Ebatlar()
        {
            SqlCommand cmd = new SqlCommand("select * from Ebat", cnn);
            cnn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ebatlar.Add(rdr["Adi"].ToString());
            }

            cnn.Close();
            return ebatlar;
        }

        // Kenar tablosundan Adi kolonunu listeye çekiyorum.

        public List<string> kenarlar = new List<string>();

        public List<string> GetAll_Kenarlar()
        {
            SqlCommand cmd = new SqlCommand("select * from Kenar", cnn);
            cnn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                kenarlar.Add(rdr["Adi"].ToString());
            }

            cnn.Close();
            return kenarlar;

        }

        // Malzeme tablosundan Adi kolonunu listeye çekiyorum

        public List<string> malzemeler = new List<string>();

        public List<string> GetAll_Malzemeler()
        {
            SqlCommand cmd = new SqlCommand("select * from Malzeme", cnn);
            cnn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                malzemeler.Add(rdr["Adi"].ToString());
            }

            cnn.Close();
            return malzemeler;
        }
        //bütün alanlar geri döneceğinden list<string> uygun değil
        public List<SiparisModel> GetAll_Siparisler()
        {
            var liste = new List<SiparisModel>();
            //string ifade yazarken tırnak başına @ işareti koyarsan sonraki tırnak gelene kadar yeni satıra yazsanda onu tek metin olarak kabul eder.
            //aşağıda yazdığımız kodu fonksiyona tanımlayıp direk o fonksiyon adını da çağırabilirdik yöntem sana kalmış
            SqlCommand cmd = new SqlCommand(@"select 
                s.Adet
                ,s.AdiSoyadi
                ,s.BirimFiyat
                ,e.Adi as EbatAdi
                ,k.Adi as KenarAdi
                ,s.MailAdresi
                ,s.Malzeme
                ,p.Adi as PizzaAdi
                ,s.Tarih
                ,s.TelNo
                ,s.ToplamTutar
                from Siparis s 
                inner join Pizza p on s.PizzaId=p.Id 
                inner join Ebat e on s.EbatId=e.Id 
                inner join Kenar k on s.KenarId=k.Id", cnn);
            cnn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                var row = new SiparisModel();
                row.Adet = Convert.ToInt32(rdr["Adet"]);// sql den okurken rdr["Adet"] değeri object olarak döner model tipi farklı olduğundan convert yapmak zorunda kaldık
                row.AdiSoyadi = rdr["AdiSoyadi"].ToString();
                row.BirimFiyat = Convert.ToDecimal(rdr["BirimFiyat"]);
                row.EbatAdi = rdr["EbatAdi"].ToString();
                row.KenarAdi = rdr["KenarAdi"].ToString();
                row.MailAdresi = rdr["MailAdresi"].ToString();
                row.Malzeme = rdr["Malzeme"].ToString();
                row.PizzaAdi = rdr["PizzaAdi"].ToString();
                row.Tarih = Convert.ToDateTime(rdr["Tarih"]);
                row.TelNo = rdr["TelNo"].ToString();
                row.ToplamTutar = Convert.ToDecimal(rdr["ToplamTutar"]);
                liste.Add(row);
            }

            cnn.Close();
            return liste;
        }

        // Sipariş ekleme methodu

        public int Add(Siparis veri)
        {
            SqlCommand cmd = new SqlCommand("insert into Siparis (Tarih, ToplamTutar, BirimFiyat, Adet, PizzaId, EbatId, KenarId, Malzeme, MailAdresi, AdiSoyadi) values (@tarih, @toplamtutar, @birimfiyat, @adet, @pizzaid, @ebatid, @kenarid, @malzeme, @mailadresi, @adisoyadi)", cnn);

            cmd.Parameters.AddWithValue("@tarih", veri.Tarih);
            cmd.Parameters.AddWithValue("@toplamtutar", veri.ToplamTutar);
            cmd.Parameters.AddWithValue("@birimfiyat", veri.BirimFiyat);
            cmd.Parameters.AddWithValue("@adet", veri.Adet);
            cmd.Parameters.AddWithValue("@pizzaid", veri.PizzaId);
            cmd.Parameters.AddWithValue("@ebatid", veri.EbatId);
            cmd.Parameters.AddWithValue("@kenarid", veri.KenarId);
            cmd.Parameters.AddWithValue("@malzeme", veri.Malzeme);
            //cmd.Parameters.AddWithValue("@telno", veri.TelNo);
            cmd.Parameters.AddWithValue("@mailadresi", veri.MailAdresi);
            cmd.Parameters.AddWithValue("@adisoyadi", veri.AdiSoyadi);

            cnn.Open();

            int sonuc = 0;

            try
            {
                sonuc = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                sonuc = 0;
            }

            cnn.Close();
            return sonuc;
        }
    }
}
