using Megazinde.Models.DB.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Megazinde.Models.Siniflar
{
    public class anasayfaClass
    {
        public IEnumerable<Kategorilers> csKategoriler { get; set; }
        public IEnumerable<Heads> csHead { get; set; }
        public IEnumerable<Haberlers> csHaberler { get; set; }
        public IEnumerable<Duyurulars> csDuyurular { get; set; }
        public IEnumerable<Yorumlars> csYorumlar { get; set; }
        public IEnumerable<HaberlerIndexes> csHaberlerIndex { get; set; }
        public IEnumerable<HaberlerDogas> csHaberlerDoga { get; set; }
        public IEnumerable<HaberlerFilms> csHaberlerFilm { get; set; }
        public IEnumerable<HaberlerModas> csHaberlerModa { get; set; }
        public IEnumerable<HaberlerSeyahats> csHaberlerSeyahat { get; set; }
        public IEnumerable<HaberlerSpors> csHaberlerSpor { get; set; }
        public IEnumerable<HaberlerTeknolojis> csHaberlerTeknoloji { get; set; }

    }
}