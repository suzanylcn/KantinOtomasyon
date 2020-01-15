using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KantinSite.Panel
{
    public partial class YoneticiListele : System.Web.UI.Page
    {
        public List<Yonetici> yoneticiList = new List<Yonetici>();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();
            string islemcik = Request.QueryString["islem"];
            if (islemcik == "sil")
            {
                int silincekId = Convert.ToInt32(Request.QueryString["id"]);
                SqlCommand komut1 = new SqlCommand("Delete from yoneticiler where id=" + silincekId, baglan);

                komut1.ExecuteNonQuery();
            }
            SqlCommand komut = new SqlCommand("Select*from yoneticiler", baglan);
            SqlDataReader yoneticidengelen = komut.ExecuteReader();
            while (yoneticidengelen.Read())
            {
                Yonetici yoneticik = new Yonetici();
                yoneticik.id = Convert.ToInt32(yoneticidengelen["id"]);
                yoneticik.adsoyad= yoneticidengelen["adiSoyadi"].ToString();
                yoneticik.kullanıcı = yoneticidengelen["kullaniciAdi"].ToString();
                yoneticik.mail= yoneticidengelen["mail"].ToString();
                yoneticik.sifre= yoneticidengelen["sifre"].ToString();
                yoneticiList.Add(yoneticik);
            }
            baglan.Close();
        }
    }
}