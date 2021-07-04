using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class ChartClass
    {
        public string KategoriAdi { get; set; }
        
        public int KategoriSayisi { get; set; }
        
        
        public string BaslikAdi { get; set; }
        
        public int BaslikYaziSayisi { get; set; }
        
        
        public string YazarAdi { get; set; }

        public int YazarYaziSayisi { get; set; }
    }
}