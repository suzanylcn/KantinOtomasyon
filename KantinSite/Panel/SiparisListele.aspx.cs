using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KantinSite.Panel
{
    public partial class SiparisListele : System.Web.UI.Page
    {
        public List<siparis> siparisList = new List<siparis>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["kullaniciAdi"] == null)
            {
                Response.Redirect("Giris.aspx");
                Response.End();
            }


            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();
            string islemcik = Request.QueryString["islem"];
            if (islemcik == "sil")
            {
                int silincekId = Convert.ToInt32(Request.QueryString["id"]);
                SqlCommand komut1 = new SqlCommand("Delete from siparis where id=" + silincekId, baglan);

                komut1.ExecuteNonQuery();
            }

            SqlCommand komut = new SqlCommand("select  siparis.id, musteriler.adiSoyadi, siparis.urunAdi,siparis.siparisTarihi,siparis.fiyat from siparis inner join musteriler on musteriler.id=siparis.musteriId", baglan);

            SqlDataReader siparistenGelen = komut.ExecuteReader();
            while (siparistenGelen.Read())
            {
                siparis sipariscik = new siparis();
                sipariscik.id = Convert.ToInt32(siparistenGelen["id"]);
                sipariscik.urunAdi = siparistenGelen["urunAdi"].ToString();
                sipariscik.musteriAdi = siparistenGelen["adiSoyadi"].ToString();
                sipariscik.fiyat = Convert.ToInt32(siparistenGelen["fiyat"]);
                sipariscik.tarih = Convert.ToDateTime(siparistenGelen["siparisTarihi"]);
                siparisList.Add(sipariscik);
            }

            baglan.Close();
        }
    }
}