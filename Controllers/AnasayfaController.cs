using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Megazinde.Models.Siniflar;
using Megazinde.Models.DB.DbFirst;

namespace Megazinde.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        DbMegazindeEntities db = new DbMegazindeEntities();
        anasayfaClass cs = new anasayfaClass();

        void csDoldur()
        {
            cs.csHead = db.Heads.ToList();
            cs.csKategoriler = db.Kategorilers.ToList();
            cs.csHaberlerIndex = db.HaberlerIndexes.ToList();
            cs.csDuyurular = db.Duyurulars.ToList();
            cs.csYorumlar = db.Yorumlars.ToList();
        }
        public ActionResult Index()
        {
            csDoldur();
            return View(cs);
        }

        public ActionResult DuyuruGetir(int id)
        {
            csDoldur();

            var duyuru = db.Duyurulars.Find(id);
            ViewData["duyuruTarih"] = duyuru.tarih;
            ViewData["duyuruBaslik"] = duyuru.baslik;
            ViewData["duyuruIcerik"] = duyuru.icerik;
            return View(cs);
        }

        public ActionResult KategoriOnizleme(int id)
        {
            cs.csHead = db.Heads.ToList();
            cs.csKategoriler = db.Kategorilers.ToList();
            cs.csDuyurular = db.Duyurulars.ToList();
            /*cs.csHaberler = db.Haberlers.Where(x => x.Kategoriler_kategori_id == id).ToList();
            cs.csHaberlerDoga = db.HaberlerDogas.ToList();
            cs.csHaberlerFilm = db.HaberlerFilms.ToList();
            cs.csHaberlerModa = db.HaberlerModas.ToList();
            cs.csHaberlerSeyahat = db.HaberlerSeyahats.ToList();
            cs.csHaberlerSpor = db.HaberlerSpors.ToList();
            cs.csHaberlerTeknoloji = db.HaberlerTeknolojis.ToList();*/
            if (id == 1)
            {
                cs.csHaberlerModa = db.HaberlerModas.ToList();
            }
            else if (id == 2)
            {
                cs.csHaberlerSeyahat = db.HaberlerSeyahats.ToList();
            }
            else if (id == 3)
            {
                cs.csHaberlerSpor = db.HaberlerSpors.ToList();
            }
            else if (id == 4)
            {
                cs.csHaberlerDoga = db.HaberlerDogas.ToList();
            }
            else if (id == 5)
            {
                cs.csHaberlerTeknoloji = db.HaberlerTeknolojis.ToList();
            }
            else if (id == 6)
            {
                cs.csHaberlerFilm = db.HaberlerFilms.ToList();
            }
            ViewData["kategoriid"] = id;
            return View(cs);
        }

        public ActionResult HaberDetay(int? haberid, string ktgr)
        {
            if (haberid != null && ktgr != null)
            {
                if (ktgr == "Moda")
                {
                    cs.csHaberlerModa = db.HaberlerModas.Where(x => x.h_moda_id == haberid).ToList();
                }
                else if (ktgr == "Seyahat")
                {
                    cs.csHaberlerSeyahat = db.HaberlerSeyahats.Where(x => x.h_seyahat_id == haberid).ToList();
                }
                else if (ktgr == "Spor")
                {
                    cs.csHaberlerSpor = db.HaberlerSpors.Where(x => x.h_spor_id == haberid).ToList();
                }
                else if (ktgr == "Doga")
                {
                    cs.csHaberlerDoga = db.HaberlerDogas.Where(x => x.h_doga_id == haberid).ToList();
                }
                else if (ktgr == "Teknoloji")
                {
                    cs.csHaberlerTeknoloji = db.HaberlerTeknolojis.Where(x => x.h_teknoloji_id == haberid).ToList();
                }
                else if (ktgr == "Film")
                {
                    cs.csHaberlerFilm = db.HaberlerFilms.Where(x => x.h_film_id == haberid).ToList();
                }
                ViewData["kategori"] = ktgr;
            }
            csDoldur();
            return View(cs);
        }
    }
}