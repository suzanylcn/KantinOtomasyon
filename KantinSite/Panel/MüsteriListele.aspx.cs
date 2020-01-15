using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KantinSite.Panel
{
    public partial class MüsteriListele : System.Web.UI.Page
    { 

        public List<musteri> musteriList = new List<musteri>();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();
            string islemcik = Request.QueryString["islem"];
            if (islemcik == "sil")
            {
                int silincekId = Convert.ToInt32(Request.QueryString["id"]);
                SqlCommand komut1 = new SqlCommand("Delete from musteriler where id=" + silincekId, baglan);

                komut1.ExecuteNonQuery();
            }
            SqlCommand komut = new SqlCommand("Select*from musteriler", baglan);
            SqlDataReader musteridengelen = komut.ExecuteReader();
            while (musteridengelen.Read())
            {
                musteri mustericik = new musteri();
                mustericik.id = Convert.ToInt32(musteridengelen["id"]);
                mustericik.adsoyad = musteridengelen["adiSoyadi"].ToString();
                mustericik.kullanıcı = musteridengelen["kullaniciAdi"].ToString();
                mustericik.mail = musteridengelen["mail"].ToString();
                mustericik.sifre = musteridengelen["sifre"].ToString();
                musteriList.Add(mustericik);
            }
            baglan.Close();
        }
    }
}