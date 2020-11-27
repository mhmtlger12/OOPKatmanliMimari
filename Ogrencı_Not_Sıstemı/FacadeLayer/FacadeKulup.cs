using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace FacadeLayer
{
   public class FacadeKulup
    {
        public static int Ekle(EntitKulup Deger)
        {
            SqlCommand komut = new SqlCommand("KULUPEKLE", SqlSonnect.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if(komut.Connection.State!=ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KULUPAD", Deger.KULUPAD);
            return komut.ExecuteNonQuery();
        }
        public static bool Sil(int Deger)
        {
            SqlCommand komut = new SqlCommand("KULUPSILME", SqlSonnect.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KULUPID", Deger);
            return komut.ExecuteNonQuery() >0;
        }
        public static bool GUNCELLE(EntitKulup deger)
        {
            SqlCommand komut = new SqlCommand("KULUPGUNCELLE", SqlSonnect.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KULUPAD", deger.KULUPAD);
            komut.Parameters.AddWithValue("KULUPID", deger.KULUPID);
            return komut.ExecuteNonQuery() > 0;
        }
        public static List<EntitKulup> KULUPLISTESI()
        {
            List<EntitKulup> degerler = new List<EntitKulup>();
            SqlCommand komut = new SqlCommand("KULUPLISTESI", SqlSonnect.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                EntitKulup ent = new EntitKulup();
                ent.KULUPID = Convert.ToInt16(dr["KULUPID"]);
                ent.KULUPAD = dr["KULUPAD"].ToString();
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }


    }
}
