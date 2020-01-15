using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KantinSite
{
    public partial class Giris : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string kAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from musteriler where kullaniciAdi='" + kAdi + "' and sifre= '" + sifre + "'", baglan);
            SqlDataReader yoneticilerdengelenveri = komut.ExecuteReader();
            if (yoneticilerdengelenveri.Read())
            {
                
                Session["kullaniciAdi"] = yoneticilerdengelenveri["kullaniciAdi"];
                Session["adiSoyadi"] = yoneticilerdengelenveri["adiSoyadi"];
                Session["kullaniciId"] = yoneticilerdengelenveri["id"];
                Response.Redirect("Default.aspx");
                Response.End();
            }
            else
            {
                uyarıKutu.InnerHtml = "<div class='alert alert-danger'>Lütfen Kullanıcı Adı ve Şifrenizi Kontrol Edip Tekrar Deneyiniz.</div>";

            }
        }
    }
}