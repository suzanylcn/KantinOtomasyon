using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KantinSite.Panel
{
    public partial class UrunListele : System.Web.UI.Page
    {
        public List<Urun> urunList = new List<Urun>();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();
            string islemcik = Request.QueryString["islem"];
            if(islemcik== "sil")
            {
                int silincekId = Convert.ToInt32(Request.QueryString["id"]);
                SqlCommand komut1 = new SqlCommand("Delete from ürünler where id=" + silincekId, baglan);

                komut1.ExecuteNonQuery();
            }
            SqlCommand komut = new SqlCommand("select ürünler.* ,kategoriler.kategoriAdi from ürünler inner join kategoriler on ürünler.kategoriId=kategoriler.id", baglan);
            SqlDataReader UrunlerdengelenVeri = komut.ExecuteReader();
            while (UrunlerdengelenVeri.Read())
            {
                Urun uruncuk = new Urun();
                uruncuk.id = Convert.ToInt32(UrunlerdengelenVeri["id"]);
                uruncuk.ad = UrunlerdengelenVeri["ad"].ToString();
                uruncuk.KategoriAdi = UrunlerdengelenVeri["kategoriAdi"].ToString();
                uruncuk.stok = Convert.ToInt32(UrunlerdengelenVeri["stok"]);
                uruncuk.fiyat = Convert.ToInt32(UrunlerdengelenVeri["fiyat"]);
                urunList.Add(uruncuk);
            }
            baglan.Close();
        }
    }
}