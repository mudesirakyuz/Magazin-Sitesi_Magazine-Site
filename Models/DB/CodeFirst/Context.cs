using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Megazinde.Models.DB.CodeFirst
{
    public class Context: DbContext
    {
        public DbSet<Duyurular> Duyurulars { get; set; }
        public DbSet<Haberler> Haberlers { get; set; }
        public DbSet<HaberlerDoga> HaberlerDogas { get; set; }
        public DbSet<HaberlerFilm> HaberlerFilms { get; set; }
        public DbSet<HaberlerIndex> HaberlerIndexs { get; set; }
        public DbSet<HaberlerModa> HaberlerModas { get; set; }
        public DbSet<HaberlerSeyahat> HaberlerSeyahats { get; set; }
        public DbSet<HaberlerSpor> HaberlerSpors { get; set; }
        public DbSet<HaberlerTeknoloji> HaberlerTeknolojis { get; set; }
        public DbSet<Head> Heads { get; set; }
        public DbSet<Kategoriler> Kategorilers { get; set; }
        public DbSet<Kullanicilar> Kullanicilars { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
    }
}