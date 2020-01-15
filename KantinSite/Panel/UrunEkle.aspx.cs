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
    public partial class UrunEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["kullaniciAdi"]== null)
            {
                Response.Redirect("Giris.aspx");
                Response.End();
            }



            if (!IsPostBack){
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


                drpKtgr.DataSource = kategoriList;
                drpKtgr.DataValueField = "id";
                drpKtgr.DataTextField = "kategoriAdi";
                drpKtgr.DataBind();

            }

        }



        protected void btnKaydet_Click(object sender, EventArgs e)
        {


            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();
            string filename = "";

            if (FileResim.HasFile)
            {
                filename = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + Path.GetFileName(FileResim.FileName);
                FileResim.SaveAs(Server.MapPath("~/resimler/urun/") + filename);
            }
            SqlCommand komut = new SqlCommand("insert into ürünler(ad,kategoriId,stok,fiyat,resim)values(@adi,@kategori,@stok,@fiyat,@resimi)", baglan);

            komut.Parameters.Add("@adi", SqlDbType.Text).Value = txturun.Text;
            komut.Parameters.Add("@stok", SqlDbType.Int).Value = txtstok.Text;
            komut.Parameters.Add("@fiyat", SqlDbType.Int).Value = txtfiyat.Text;
            komut.Parameters.Add("@resimi", SqlDbType.NVarChar).Value = filename;
            komut.Parameters.Add("@kategori", SqlDbType.Int).Value = drpKtgr.SelectedValue;
            komut.ExecuteNonQuery();
            baglan.Close();
            Response.Redirect("UrunListele.aspx");
            Response.End();

        }
    }
}