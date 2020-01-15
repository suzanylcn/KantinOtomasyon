using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KantinSite
{
    public class siparis
    {
        public int id { get; set; }
        public int musteriId { get; set; }
        
        public string urunAdi { get; set; }
        public string musteriAdi { get; set; }
      
        public int fiyat { get; set; }
        
        public DateTime tarih { get; set; }
    }
}