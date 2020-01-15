using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KantinSite.Panel
{
    public class Urun
    {
        public int id { get; set; }
        public int kategoriId { get; set; }
       
        public string KategoriAdi { get; set; }
        public string ad { get; set; }
        public int stok { get; set; }
        public string resim { get; set; }
        public int fiyat { get; set; }
    }
}