using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Megazinde.Models.DB.CodeFirst
{
    public class Kategoriler
    {
        [Key]
        public int kategori_id { get; set; }
        public string kategori { get; set; }

        public ICollection<Haberler> Haberler { get; set; }

        public ICollection<HaberlerIndex> HaberlerIndex { get; set; }

        public ICollection<Yorumlar> Yorumlar { get; set; }

        public ICollection<Head> Head { get; set; }
    }
}