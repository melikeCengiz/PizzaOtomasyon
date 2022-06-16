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
    public class EbatRepository : IRepository<Ebat>
    {
        SqlConnection cnn;

        public EbatRepository()
        {
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PizzaConnection"].ConnectionString);
        }

        public int Add(Ebat veri)
        {
            SqlCommand cmd = new SqlCommand("insert Ebat (Adi,Fiyat) values (@ad,@fiyat)", cnn);
            cmd.Parameters.AddWithValue("@ad", veri.Adi);
            cmd.Parameters.AddWithValue("@fiyat", veri.Fiyat);

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
            SqlCommand cmd = new SqlCommand("delete from Ebat where Id = @id",cnn);
            cmd.Parameters.AddWithValue("@id", veriId);

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

        public int Edit(Ebat veri)
        {
            SqlCommand cmd = new SqlCommand("update Ebat set  Adi = @ad, Fiyat = @fiyat where Id = @id", cnn);
            cmd.Parameters.AddWithValue("@ad", veri.Adi);
            cmd.Parameters.AddWithValue("@fiyat", veri.Fiyat);
            cmd.Parameters.AddWithValue("@id", veri.Id);

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

        public List<Ebat> GetAll()
        {
            SqlCommand cmd = new SqlCommand("select * from Ebat", cnn);
            cnn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            List<Ebat> ebatlar = new List<Ebat>();

            while (rdr.Read())
            {
                Ebat ebt = new Ebat();
                ebt.Id = rdr.GetInt32(0);
                ebt.Adi = rdr.GetString(1);
                ebt.Fiyat = rdr.GetDecimal(2);

                ebatlar.Add(ebt);
            }

            cnn.Close();
            return ebatlar;

        }
    }
}
