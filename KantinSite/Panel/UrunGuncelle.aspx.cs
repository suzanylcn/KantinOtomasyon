using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KantinSite.Panel
{
    public partial class UrunGuncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
                baglan.Open();

                SqlCommand komut = new SqlCommand("select*from kategoriler", baglan);
                SqlDataReader kategoridengelenVeri = komut.ExecuteReader();

                List<kategori> kategoriList = new List<kategori>();

                while (kategoridengelenVeri.Read())
                {
                    kategori uruncuk = new kategori();

                    uruncuk.kategoriAdi = kategoridengelenVeri["KategoriAdi"].ToString();
                    uruncuk.id = Convert.ToInt32(kategoridengelenVeri["id"]);

                    kategoriList.Add(uruncuk);
                }
                kategoridengelenVeri.Close();

                drpKtgr.DataSource = kategoriList;

                drpKtgr.DataValueField = "id";

                drpKtgr.DataTextField = "kategoriAdi";
                drpKtgr.DataBind();

                int duzenlencekId = Convert.ToInt32(Request.QueryString["id"]);
                SqlCommand Komut = new SqlCommand("Select * From ürünler where id=" + duzenlencekId, baglan);
                SqlDataReader ürünlerdengelenveri = Komut.ExecuteReader();
                while (ürünlerdengelenveri.Read())
                {
                    txturun.Text = ürünlerdengelenveri["ad"].ToString();

                    txtstok.Text = Convert.ToInt32(ürünlerdengelenveri["stok"]).ToString();
                    txtfiyat.Text = Convert.ToInt32(ürünlerdengelenveri["fiyat"]).ToString();

                    drpKtgr.SelectedValue = ürünlerdengelenveri["kategoriId"].ToString();

                }

                baglan.Close();







            }


            
        }
       


        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();





            int id = Convert.ToInt32(Request.QueryString["id"]);

            string filename = "";
            if (FileResim.HasFile)
            {   

                filename = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + Path.GetFileName(FileResim.FileName);
                FileResim.SaveAs(Server.MapPath("~/resimler/urun/") + filename);
                SqlCommand komut = new SqlCommand("Update ürünler set ad=@adi ,kategoriId=@kategori,stok=@stok,fiyat=@fiyat,resim=@resim where id=" + id, baglan);
                komut.Parameters.Add("@adi", SqlDbType.Text).Value = txturun.Text;
                komut.Parameters.Add("@kategori", SqlDbType.Int).Value = drpKtgr.SelectedValue;
                komut.Parameters.Add("@stok", SqlDbType.Int).Value = txtstok.Text;
                komut.Parameters.Add("@fiyat", SqlDbType.Int).Value = txtfiyat.Text;
                komut.Parameters.Add("@resim", SqlDbType.NVarChar).Value = filename;
                komut.ExecuteNonQuery();
            }
            else
            {

                SqlCommand komut = new SqlCommand("Update ürünler set ad=@adi ,kategoriId=@kategori,stok=@stok,fiyat=@fiyat where id=" + id, baglan);
                komut.Parameters.Add("@adi", SqlDbType.Text).Value = txturun.Text;
                komut.Parameters.Add("@kategori", SqlDbType.Int).Value = drpKtgr.SelectedValue;
                komut.Parameters.Add("@stok", SqlDbType.Int).Value = txtstok.Text;
                komut.Parameters.Add("@fiyat", SqlDbType.NVarChar).Value = txtfiyat.Text;
                komut.ExecuteNonQuery();
            }


            Response.Redirect("UrunListele.aspx");
            Response.End();
        }
    }
}