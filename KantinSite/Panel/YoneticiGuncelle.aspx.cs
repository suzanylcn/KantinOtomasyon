using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KantinSite
{
    public partial class YoneticiGuncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
                baglan.Open();

                int duzenlencekId = Convert.ToInt32(Request.QueryString["id"]);
                SqlCommand Komut = new SqlCommand("Select * From yoneticiler where id=" + duzenlencekId, baglan);
                SqlDataReader yoneticidengelen = Komut.ExecuteReader();
                while (yoneticidengelen.Read())
                {
                    txtAdSoyad.Text = yoneticidengelen["adiSoyadi"].ToString();
                    txtKullanici.Text = yoneticidengelen["kullaniciAdi"].ToString();
                    txtmail.Text = yoneticidengelen["mail"].ToString();
                    txtsifre.Text = yoneticidengelen["sifre"].ToString();
                    baglan.Close();
                }
           




            }

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {

            int Id = Convert.ToInt32(Request.QueryString["id"]);
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update yoneticiler set adiSoyadi=@adi,kullaniciAdi=@kullanici,mail=@mail,sifre=@sifre where id="+Id, baglan);

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