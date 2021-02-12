using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace Megazinde.Models.DB.CodeFirst
{
    public class HaberlerModa
    {
        [Key]
        public int h_moda_id { get; set; }
        public string baslik { get; set; }
        public string icerik { get; set; }
        public string icerik1 { get; set; }
        public string icerik2 { get; set; }
        public string resim { get; set; }
        public string video { get; set; }
        public string tarih { get; set; }
        public int tiklanma { get; set; }
    }
}