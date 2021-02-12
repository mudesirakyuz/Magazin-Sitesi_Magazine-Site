﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace Megazinde.Models.DB.CodeFirst
{
    public class HaberlerIndex
    {
        [Key]
        public int h_index_id { get; set; }
        public string baslik { get; set; }
        public string icerik { get; set; }
        public string resim { get; set; }

        public Kategoriler Kategoriler { get; set; }
    }
}