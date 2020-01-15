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
    public partial class KategoriGüncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
                baglan.Open();
                int duzenlencekId = Convert.ToInt32(Request.QueryString["id"]);
                SqlCommand Komut = new SqlCommand("Select * From kategoriler where id=" + duzenlencekId, baglan);
                SqlDataReader kategoridengelenveri = Komut.ExecuteReader();
                while (kategoridengelenveri.Read())
                {
                    txtktgr.Text= kategoridengelenveri["kategoriAdi"].ToString();
                }

                baglan.Close();
            }
        }
        protected void btKaydet_Click(object sender, EventArgs e)
        {

            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            SqlCommand komut = new SqlCommand("Update kategoriler set kategoriAdi=@adi where id="+id, baglan);
            komut.Parameters.Add("@adi", SqlDbType.Text).Value = txtktgr.Text;
            komut.ExecuteNonQuery();
            Response.Redirect("KategoriListele.aspx");
            Response.End();
        }
    }
}