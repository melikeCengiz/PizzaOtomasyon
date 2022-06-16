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
    public class KenarRepository : IRepository<Kenar>
    {
        SqlConnection cnn;

        public KenarRepository()
        {
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["PizzaConnection"].ConnectionString);
        }
        public int Add(Kenar veri)
        {
            SqlCommand cmd = new SqlCommand("insert Kenar (Adi) values (@ad)", cnn);
            cmd.Parameters.AddWithValue("@ad", veri.Adi);

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
            SqlCommand cmd = new SqlCommand("delete from Kenar where Id = @id", cnn);
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

        public int Edit(Kenar veri)
        {
            SqlCommand cmd = new SqlCommand("update Kenar set  Adi = @ad where Id = @id", cnn);
            cmd.Parameters.AddWithValue("@ad", veri.Adi);
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

        public List<Kenar> GetAll()
        {
            SqlCommand cmd = new SqlCommand("select * from Kenar", cnn);
            cnn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            List<Kenar> kenarlar = new List<Kenar>();

            while (rdr.Read())
            {
                Kenar knr = new Kenar();
                knr.Id = rdr.GetInt32(0);
                knr.Adi = rdr.GetString(1);

                kenarlar.Add(knr);
            }

            cnn.Close();
            return kenarlar;
        }
    }
}
