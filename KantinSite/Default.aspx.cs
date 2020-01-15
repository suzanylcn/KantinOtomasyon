using KantinSite.Panel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KantinSite
{
    public partial class _Default : Page
    {
        public List<kategori> kategoriList = new List<kategori>();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=kantin;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select*from kategoriler", baglan);
            SqlDataReader kategoridengelen = komut.ExecuteReader();
            while (kategoridengelen.Read())
            {
                kategori kategoricik = new kategori();
                kategoricik.id = Convert.ToInt32(kategoridengelen["id"]);
                kategoricik.kategoriAdi = kategoridengelen["kategoriAdi"].ToString();


                kategoriList.Add(kategoricik);
            }
           
            baglan.Close();

        }
    }
}