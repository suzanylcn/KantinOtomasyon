using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KantinSite.Panel
{
    public class kategori
    {

        public int id { get; set; }
        public string kategoriAdi { get; set; }

        public List<Urun> uruns { get; set; }


    }
}