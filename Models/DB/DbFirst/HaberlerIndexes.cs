//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Megazinde.Models.DB.DbFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class HaberlerIndexes
    {
        public int h_index_id { get; set; }
        public string baslik { get; set; }
        public string icerik { get; set; }
        public string resim { get; set; }
        public Nullable<int> Kategoriler_kategori_id { get; set; }
    
        public virtual Kategorilers Kategorilers { get; set; }
    }
}