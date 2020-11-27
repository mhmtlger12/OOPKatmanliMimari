using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace FacadeLayer
{
    public class FacadeOgrenci
    {
        public static int Ekle(EntityOgrenci deger)
        {
            SqlCommand komut = new SqlCommand("OGRENCIEKLE", SqlSonnect.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if(komut.Connection.State!=ConnectionState.Open)
            {
                komut.Connection.Open();

            }
            komut.Parameters.AddWithValue("AD", deger.AD);
            komut.Parameters.AddWithValue("SOYAD", deger.SOYAD);
            komut.Parameters.AddWithValue("FOTOGRAF", deger.FOTOGRAF);
            komut.Parameters.AddWithValue("KULUPID", deger.KULUPID);
             return komut.ExecuteNonQuery();
            
        }
        public static bool Sil(int deger )
        {
            SqlCommand komut = new SqlCommand("OGRENCISIL",SqlSonnect.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
         if(komut.Connection.State!=ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("ID", deger);
            return komut.ExecuteNonQuery() > 0;
        }
        public static bool Guncelle(EntityOgrenci deger)
        {
            SqlCommand komut = new SqlCommand("OGRENCUGUNCELLE", SqlSonnect.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if(komut.Connection.State!=ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("AD", deger.AD);
            komut.Parameters.AddWithValue("SOYAD", deger.SOYAD);
            komut.Parameters.AddWithValue("FOTOGRAF", deger.FOTOGRAF);
            komut.Parameters.AddWithValue("KULUPID", deger.KULUPID);
            komut.Parameters.AddWithValue("ID", deger.ID);
            return komut.ExecuteNonQuery() > 0;


        }
        public static List<EntityOgrenci> OGRENCILISTESI()
        {
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            SqlCommand komut = new SqlCommand("OGRENCILISTESI",SqlSonnect.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if(komut.Connection.State!=  ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.AD = dr["AD"].ToString();
                ent.SOYAD = dr["SOYAD"].ToString();
                ent.FOTOGRAF = dr["FOTOGRAF"].ToString();
                ent.KULUPID = Convert.ToInt16(dr["KULUPID"].ToString());
                ent.ID = Convert.ToInt16(dr["ID"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }
    }
}
