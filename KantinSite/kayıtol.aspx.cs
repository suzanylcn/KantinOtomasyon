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
    public partial class kayıtol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text == "" || txtkullanici.Text == "" || txtposta.Text == "" || txtSifre.Text == "")
            {
                uyarı.InnerHtml = "<div class='alert alert-danger'>Lütfen Bilgilerinizi Kontrol Edip Tekrar Deneyiniz.</div>";
            }
            else
            {
                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into musteriler(adiSoyadi,kullaniciAdi,sifre,mail)values(@adi,@kullanici,@sifre,@mail)", baglan);
                komut.Parameters.Add("@adi", SqlDbType.NVarChar).Value = txtAdi.Text;
                komut.Parameters.Add("@kullanici", SqlDbType.NVarChar).Value = txtkullanici.Text;
                komut.Parameters.Add("@sifre", SqlDbType.NVarChar).Value = txtSifre.Text;
                komut.Parameters.Add("@mail", SqlDbType.NVarChar).Value = txtposta.Text;
                komut.ExecuteNonQuery();
                Response.Redirect("Giris.aspx");
                Response.End();
            }


        }
    }

}