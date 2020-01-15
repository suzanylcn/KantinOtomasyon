using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KantinSite.Panel
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullaniciAdi"] == null)
            {
                Response.Redirect("Giris.aspx");
                Response.End();
            }
        }

        protected void btKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();

            SqlCommand komut = new SqlCommand("insert into kategoriler(KategoriAdi) values(@adi)", baglan);
            komut.Parameters.Add("@adi", SqlDbType.Text).Value = txtktgr.Text;
            komut.ExecuteNonQuery();
            Response.Redirect("KategoriListele.aspx");
            Response.End();
        }
        
    }
}