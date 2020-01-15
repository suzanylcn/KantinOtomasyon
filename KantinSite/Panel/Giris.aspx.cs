using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KantinSite.Panel
{
    public partial class Giris : System.Web.UI.Page
    {
        public string uyarı = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string kAdi = txtkullaniciAdi.Text;
            string sifre = txtsifre.Text;
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from yoneticiler where kullaniciAdi='" + kAdi + "' and sifre= '" + sifre + "'", baglan);
            SqlDataReader yoneticilerdengelenveri = komut.ExecuteReader();
            if (yoneticilerdengelenveri.Read())
            {
                Session["kullaniciAdi"] = yoneticilerdengelenveri["kullaniciAdi"];
                Response.Redirect("Default.aspx");
                Response.End();
            }
            else
            {
                uyarı = "Lütfen Kullanıcı Adı ve Şifrenizi Kontrol Edip Tekrar Deneyiniz.";

            }


        }
    }
}