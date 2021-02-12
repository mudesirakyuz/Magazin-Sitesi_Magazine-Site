using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Megazinde.Models.DB.CodeFirst
{
    public class Kullanicilar
    {
        [Key]
        public string kullaniciadi { get; set; }
        public string parola { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string resim { get; set; }
        public bool admin { get; set; }

        public ICollection<Yorumlar> Yorumlar { get; set; }
    }
}