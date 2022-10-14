﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace DataAccessLayer
{
    public class DalOgrenci
    {
        public static int OgrenciEkle(EntityOgrenci p)
        {
            SqlCommand komut1 = new SqlCommand("insert into TblOgrenci (Ad,Soyad,Numara,Bolum) values (@p1,@p2,@p3,@p4)", Baglanti.bgl);
            if(komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@p1", p.Ad);
            komut1.Parameters.AddWithValue("@p2", p.Soyad);
            komut1.Parameters.AddWithValue("@p3", p.Numara);
            komut1.Parameters.AddWithValue("@p4", p.Bolum);
            return komut1.ExecuteNonQuery();
        }
        public static List<EntityOgrenci> OgrenciListesi()
        {
            List<EntityOgrenci> ogrenciler = new List<EntityOgrenci>();
            SqlCommand komut2 = new SqlCommand("select * from TblOgrenci", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.OgrID = int.Parse(dr[0].ToString());
                ent.Ad = dr["Ad"].ToString();
                ent.Soyad = dr[2].ToString();
                ent.Numara = dr[3].ToString();
                ent.Bolum = dr[4].ToString();
                ogrenciler.Add(ent);

            }
            dr.Close();
            return ogrenciler;
        }
        public static int OgrenciSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("delete from TblOgrenci where OgrID = @p1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1",p);
            return komut3.ExecuteNonQuery();
        }

        public static int OgrenciGüncelle(EntityOgrenci p)
        {
            SqlCommand komut4 = new SqlCommand("update TblOgrenci set ad=@p1,soyad=@p2,numara=@p3,bolum=@p4 where OgrID=@p5",Baglanti.bgl);
            if(komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@p1", p.Ad);
            komut4.Parameters.AddWithValue("@p2", p.Soyad);
            komut4.Parameters.AddWithValue("@p3", p.Numara);
            komut4.Parameters.AddWithValue("@p4", p.Bolum);
            komut4.Parameters.AddWithValue("@p5", p.OgrID);
            return komut4.ExecuteNonQuery();
        }


    }
}
