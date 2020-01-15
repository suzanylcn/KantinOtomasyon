using KantinSite.Panel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KantinSite
{
    public partial class Urunler : System.Web.UI.Page
    {
        public List<Urun> urunlist = new List<Urun>();

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();

            string islem = Request.QueryString["islem"];

            if (islem == "siparis")
            {

                
                if (Session["kullaniciAdi"] == null)
                {
                    Response.Redirect("Giris.aspx");
                    Response.End();
                }

                int UrunId = Convert.ToInt32(Request.QueryString["urunId"]);
                SqlCommand komut2 = new SqlCommand("Select*from ürünler where id=" + UrunId, baglan);
                SqlDataReader urundenGelen = komut2.ExecuteReader();

                Urun uruncuk = new Urun();
                while (urundenGelen.Read())
                {
                    uruncuk.id = Convert.ToInt32(urundenGelen["id"]);
                    uruncuk.resim = urundenGelen["resim"].ToString();
                    uruncuk.ad = urundenGelen["ad"].ToString();
                    uruncuk.stok = Convert.ToInt32(urundenGelen["stok"]);
                    uruncuk.fiyat = Convert.ToInt32(urundenGelen["fiyat"]);
                }
                urundenGelen.Close();
                SqlCommand komut3 = new SqlCommand("insert into siparis (urunAdi,fiyat,resim,siparisTarihi,musteriId)values(@urunAdi,@fiyat,@resim,@tarih,@musteriId)", baglan);
                komut3.Parameters.Add("@urunAdi", SqlDbType.Text).Value = uruncuk.ad;
                komut3.Parameters.Add("@fiyat", SqlDbType.Int).Value = uruncuk.fiyat;
                komut3.Parameters.Add("@resim", SqlDbType.Text).Value = uruncuk.resim;
                komut3.Parameters.Add("@musteriId", SqlDbType.Int).Value = Session["kullaniciId"];

                komut3.Parameters.Add("@tarih", SqlDbType.DateTime).Value = DateTime.Now;

                komut3.ExecuteNonQuery();
                Response.Redirect("Default.aspx");
                Response.End();
            }
            else if (islem=="sepetekle")
            {

                if (Session["kullaniciAdi"] == null)
                {
                    Response.Redirect("Giris.aspx");
                    Response.End();
                }


                
                int UrunId = Convert.ToInt32(Request.QueryString["urunId"]);

                SqlCommand komut2 = new SqlCommand("Select*from ürünler where id=" + UrunId, baglan);
                SqlDataReader urundenGelen = komut2.ExecuteReader();

                Urun uruncuk = new Urun();
                while (urundenGelen.Read())
                {
                    uruncuk.id = Convert.ToInt32(urundenGelen["id"]);
                    uruncuk.resim = urundenGelen["resim"].ToString();
                    uruncuk.kategoriId = Convert.ToInt32(urundenGelen["kategoriId"]);
                    uruncuk.ad = urundenGelen["ad"].ToString();
                    uruncuk.stok = Convert.ToInt32(urundenGelen["stok"]);
                    uruncuk.fiyat = Convert.ToInt32(urundenGelen["fiyat"]);
                }
                urundenGelen.Close();

                


                if (Session["sepet"]==null)
                {
                    List<Urun> sepetListe = new List<Urun>();
                    sepetListe.Add(uruncuk);
                    Session["sepet"] = sepetListe;
                }
                else
                {
                    List<Urun> sepetListe = (List<Urun>)Session["sepet"];
                    sepetListe.Add(uruncuk);
                    Session["sepet"] = sepetListe;
                }

                Response.Redirect("Urunler.aspx?kategoriId="+uruncuk.kategoriId);
                Response.End();

            }


            int id = Convert.ToInt32(Request.QueryString["kategoriId"]);


            SqlCommand komut = new SqlCommand("select * from ürünler where kategoriId=" + id, baglan);
            SqlDataReader UrunlerdengelenVeri = komut.ExecuteReader();
            while (UrunlerdengelenVeri.Read())
            {
                Urun uruncuk = new Urun();
                uruncuk.id = Convert.ToInt32(UrunlerdengelenVeri["id"]);
                uruncuk.ad = UrunlerdengelenVeri["ad"].ToString();
                uruncuk.stok = Convert.ToInt32(UrunlerdengelenVeri["stok"]);
                uruncuk.fiyat = Convert.ToInt32(UrunlerdengelenVeri["fiyat"]);
                uruncuk.resim = UrunlerdengelenVeri["resim"].ToString();
                urunlist.Add(uruncuk);
            }
            baglan.Close();

        }

        protected void btnSepet_Click(object sender, EventArgs e)
        {
        }
    }
}