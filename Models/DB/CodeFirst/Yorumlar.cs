using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace Megazinde.Models.DB.CodeFirst
{
    public class Yorumlar
    {
        [Key]
        public int yorum_id { get; set; }
        public string yorum { get; set; }
        public string tarih { get; set; }

        public Kategoriler Kategoriler { get; set; }

        public Haberler Haberler { get; set; }

        public Kullanicilar Kullanicilar { get; set; }
    }
}