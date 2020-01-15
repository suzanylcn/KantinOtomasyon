using KantinSite.Panel;
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
    public partial class sepetim : System.Web.UI.Page
    {
        public List<Urun> sepetList = new List<Urun>();
        public int toplam = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["sepet"] != null)
            {
                sepetList = (List<Urun>)Session["sepet"];


            }


            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();


            string islem = Request.QueryString["islem"];

            if (islem == "sil")
            {
                int silinecekid = Convert.ToInt32(Request.QueryString["urunId"]);
                foreach (var item in sepetList)
                {
                    if (item.id == silinecekid)
                    {
                        sepetList.Remove(item);
                        break;
                    }
                }

                Session["sepet"] = sepetList;

            }

            foreach (var item in sepetList)
            {
                toplam = item.fiyat + toplam;

            }


            if (islem == "siparisonay")
            {

                if (toplam < 10)
                {

                    uyarıKutu.InnerHtml = "<div class='alert alert-danger'>Siparişiniz Gerçekleştirelemedi 10 tl den Fazla Ürün Sipariş Etmelisiniz...</div>";

                }

                else
                {
                    foreach (var item in sepetList)
                    {

                        SqlCommand komut = new SqlCommand("insert into siparis (urunAdi,fiyat,resim,siparisTarihi,musteriId)values(@urunAdi,@fiyat,@resim,@tarih,@musteriId)", baglan);
                        komut.Parameters.Add("@urunAdi", SqlDbType.Text).Value = item.ad;
                        komut.Parameters.Add("@fiyat", SqlDbType.Int).Value = item.fiyat;
                        komut.Parameters.Add("@resim", SqlDbType.Text).Value = item.resim;
                        komut.Parameters.Add("@musteriId", SqlDbType.Int).Value = Session["kullaniciId"];
                        komut.Parameters.Add("@tarih", SqlDbType.DateTime).Value = DateTime.Now;
                        komut.ExecuteNonQuery();

                        int stokBilgi = 0;

                        SqlCommand komut1 = new SqlCommand("Select* from ürünler where id="+item.id, baglan);
                        SqlDataReader üründengelen = komut1.ExecuteReader();
                        while(üründengelen.Read())
                        {
                            stokBilgi = Convert.ToInt32(üründengelen["stok"]);
                        }
                        üründengelen.Close();
                        stokBilgi--;


                        SqlCommand komut2 = new SqlCommand("Update ürünler set stok=@stok where id=" + item.id, baglan);
                        komut2.Parameters.Add("@stok", SqlDbType.Int).Value = stokBilgi;
                        komut2.ExecuteNonQuery();
                            

                    }
                    sepetList.Clear();
                    uyarı.InnerHtml = "<div class='alert alert-success'>Siparişiniz Başarılı ile Gerçekleşmiştir</div>";
                    toplam = 0;
                }
                // Response.Redirect("Default.aspx");
                //  Response.End();
            }
        }
    }
}