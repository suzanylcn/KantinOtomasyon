using System;
using System.Data;
using System.Data.SqlClient;

namespace KantinSite.Panel
{
    public partial class YoneticiEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["kullaniciAdi"] == null)
            {
                Response.Redirect("Giris.aspx");
                Response.End();
            }


        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into yoneticiler(adiSoyadi,kullaniciAdi,mail,sifre)values(@adi,@kullanici,@mail,@sifre)", baglan);

            komut.Parameters.Add("@adi", SqlDbType.Text).Value = txtAdSoyad.Text;
            komut.Parameters.Add("@kullanici", SqlDbType.Text).Value = txtKullanici.Text;
            komut.Parameters.Add("@mail", SqlDbType.Text).Value = txtmail.Text;
            komut.Parameters.Add("@sifre", SqlDbType.Text).Value = txtsifre.Text;
            komut.ExecuteNonQuery();
            baglan.Close();
            Response.Redirect("YoneticiListele.aspx");
            Response.End();

        }
    }
}