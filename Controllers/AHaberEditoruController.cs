using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Megazinde.Models.DB.DbFirst;
using Megazinde.Models.Siniflar;

namespace Megazinde.Controllers
{
    public class AHaberEditoruController : Controller
    {
        // GET: AHaberEditoru
        DbMegazindeEntities db = new DbMegazindeEntities();
        adminClass cs = new adminClass();

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
            var veriler = db.Haberlers.ToList();
            return View(veriler);
        }

        //--------------------INSERT---------------------------
        void tumhaberler(FormCollection col)
        {
            Haberlers haber = new Haberlers();
            haber.baslik = col["baslik"];
            haber.icerik = col["icerik"];
            haber.Kategoriler_kategori_id = int.Parse(col["Kategoriler_kategori_id"]);
            haber.resim = col["resim"];
            db.Haberlers.Add(haber);
        }

        [HttpGet]
        public ActionResult HaberEkle()
        {
            /*List<SelectListItem> veri = (from item in db.Kategorilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = item.kategori,
                                                Value = item.kategori_id.ToString()
                                            }).ToList();
            ViewBag.veriler = veri;*/

            csDoldur();
            return View(cs);
        }

        [HttpPost]
        public ActionResult HaberEkle(FormCollection col)
        {
            //string baslik,string icerik, string icerik1, string icerik2, string Kategoriler_kategoriler_id, string resim, string video, string tarih
            int id = int.Parse(col["Kategoriler_kategori_id"]);

            if (id == 1)
            {
                tumhaberler(col);

                HaberlerModas haber = new HaberlerModas();
                haber.baslik = col["baslik"];
                haber.icerik = col["icerik"];
                haber.icerik1 = col["icerik1"];
                haber.icerik2 = col["icerik2"];
                haber.resim = col["resim"];
                haber.video = col["video"];
                haber.tarih = DateTime.Now.ToShortDateString();
                haber.tiklanma = 0;
                db.HaberlerModas.Add(haber);
                db.SaveChanges();
            }
            else if (id == 2)
            {
                tumhaberler(col);
                HaberlerSeyahats haber = new HaberlerSeyahats();
                haber.baslik = col["baslik"];
                haber.icerik = col["icerik"];
                haber.icerik1 = col["icerik1"];
                haber.icerik2 = col["icerik2"];
                haber.resim = col["resim"];
                haber.video = col["video"];
                haber.tarih = DateTime.Now.ToShortDateString();
                haber.tiklanma = 0;
                db.HaberlerSeyahats.Add(haber);
                db.SaveChanges();
            }
            else if (id == 3)
            {
                tumhaberler(col);
                HaberlerSpors haber = new HaberlerSpors();
                haber.baslik = col["baslik"];
                haber.icerik = col["icerik"];
                haber.icerik1 = col["icerik1"];
                haber.icerik2 = col["icerik2"];
                haber.resim = col["resim"];
                haber.video = col["video"];
                haber.tarih = DateTime.Now.ToShortDateString();
                haber.tiklanma = 0;
                db.HaberlerSpors.Add(haber);
                db.SaveChanges();
            }
            else if (id == 4)
            {
                tumhaberler(col);
                HaberlerDogas haber = new HaberlerDogas();
                haber.baslik = col["baslik"];
                haber.icerik = col["icerik"];
                haber.icerik1 = col["icerik1"];
                haber.icerik2 = col["icerik2"];
                haber.resim = col["resim"];
                haber.video = col["video"];
                haber.tarih = DateTime.Now.ToShortDateString();
                haber.tiklanma = 0;
                db.HaberlerDogas.Add(haber);
                db.SaveChanges();
            }
            else if (id == 5)
            {
                tumhaberler(col);
                HaberlerTeknolojis haber = new HaberlerTeknolojis();
                haber.baslik = col["baslik"];
                haber.icerik = col["icerik"];
                haber.icerik1 = col["icerik1"];
                haber.icerik2 = col["icerik2"];
                haber.resim = col["resim"];
                haber.video = col["video"];
                haber.tarih = DateTime.Now.ToShortDateString();
                haber.tiklanma = 0;
                db.HaberlerTeknolojis.Add(haber);
                db.SaveChanges();
            }
            else if (id == 6)
            {
                tumhaberler(col);
                HaberlerFilms haber = new HaberlerFilms();
                haber.baslik = col["baslik"];
                haber.icerik = col["icerik"];
                haber.icerik1 = col["icerik1"];
                haber.icerik2 = col["icerik2"];
                haber.resim = col["resim"];
                haber.video = col["video"];
                haber.tarih = DateTime.Now.ToShortDateString();
                haber.tiklanma = 0;
                db.HaberlerFilms.Add(haber);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "AHaberEditoru");
        }

        //--------------------INSERT---------------------------

        //--------------------DELETE---------------------------
        public ActionResult HaberSil(int id, int kategori, string resim)
        {

            if (kategori == 1)
            {
                var veri = db.Haberlers.Find(id);//Tüm Haberler Tablosundan Silme
                db.Haberlers.Remove(veri);

                var tut = db.HaberlerModas.Where(x => x.resim == resim).Select(x => x.h_moda_id);//Özel Kategori Tablosundan Silme
                int[] veriid = tut.ToArray();
                var veri2 = db.HaberlerModas.Find(veriid[0]);
                db.HaberlerModas.Remove(veri2);

                db.SaveChanges();//Kayıt
            }
            else if (kategori == 2)
            {
                var veri = db.Haberlers.Find(id);//Tüm Haberler Tablosundan Silme
                db.Haberlers.Remove(veri);

                var tut = db.HaberlerSeyahats.Where(x => x.resim == resim).Select(x => x.h_seyahat_id);//Özel Kategori Tablosundan Silme
                int[] veriid = tut.ToArray();
                var veri2 = db.HaberlerSeyahats.Find(veriid[0]);
                db.HaberlerSeyahats.Remove(veri2);

                db.SaveChanges();//Kayıt
            }
            else if (kategori == 3)
            {
                var veri = db.Haberlers.Find(id);//Tüm Haberler Tablosundan Silme
                db.Haberlers.Remove(veri);

                var tut = db.HaberlerSpors.Where(x => x.resim == resim).Select(x => x.h_spor_id);//Özel Kategori Tablosundan Silme
                int[] veriid = tut.ToArray();
                var veri2 = db.HaberlerSpors.Find(veriid[0]);
                db.HaberlerSpors.Remove(veri2);

                db.SaveChanges();//Kayıt
            }
            else if (kategori == 4)
            {
                var veri = db.Haberlers.Find(id);//Tüm Haberler Tablosundan Silme
                db.Haberlers.Remove(veri);

                var tut = db.HaberlerDogas.Where(x => x.resim == resim).Select(x => x.h_doga_id);//Özel Kategori Tablosundan Silme
                int[] veriid = tut.ToArray();
                var veri2 = db.HaberlerDogas.Find(veriid[0]);
                db.HaberlerDogas.Remove(veri2);

                db.SaveChanges();//Kayıt
            }
            else if (kategori == 5)
            {
                var veri = db.Haberlers.Find(id);//Tüm Haberler Tablosundan Silme
                db.Haberlers.Remove(veri);

                var tut = db.HaberlerTeknolojis.Where(x => x.resim == resim).Select(x => x.h_teknoloji_id);//Özel Kategori Tablosundan Silme
                int[] veriid = tut.ToArray();
                var veri2 = db.HaberlerTeknolojis.Find(veriid[0]);
                db.HaberlerTeknolojis.Remove(veri2);

                db.SaveChanges();//Kayıt
            }
            else if (kategori == 6)
            {
                var veri = db.Haberlers.Find(id);//Tüm Haberler Tablosundan Silme
                db.Haberlers.Remove(veri);

                var tut = db.HaberlerFilms.Where(x => x.resim == resim).Select(x => x.h_film_id);//Özel Kategori Tablosundan Silme
                int[] veriid = tut.ToArray();
                var veri2 = db.HaberlerFilms.Find(veriid[0]);
                db.HaberlerFilms.Remove(veri2);

                db.SaveChanges();//Kayıt
            }

            return RedirectToAction("Index", "AHaberEditoru");
        }

        //--------------------DELETE---------------------------
        [HttpGet]
        public ActionResult HaberGuncelle(int id, int kategori, string resim)
        {

            csDoldur();
            if (kategori == 1)
            {
                cs.csHaberlerModa = db.HaberlerModas.Where(x => x.resim == resim).ToList();
            }
            else if (kategori == 2)
            {
                cs.csHaberlerSeyahat = db.HaberlerSeyahats.Where(x => x.resim == resim).ToList();
            }
            else if (kategori == 3)
            {
                cs.csHaberlerSpor = db.HaberlerSpors.Where(x => x.resim == resim).ToList();
            }
            else if (kategori == 4)
            {
                cs.csHaberlerDoga = db.HaberlerDogas.Where(x => x.resim == resim).ToList();
            }
            else if (kategori == 5)
            {
                cs.csHaberlerTeknoloji = db.HaberlerTeknolojis.Where(x => x.resim == resim).ToList();
            }
            else if (kategori == 6)
            {
                cs.csHaberlerFilm = db.HaberlerFilms.Where(x => x.resim == resim).ToList();
            }
            ViewBag.kategori = kategori;
            return View(cs);
        }


        void tumhaberler1(FormCollection col,int id,int kategori)
        {
            
            if (int.Parse(col["Kategoriler_kategori_id"]) == kategori)
            {
                var haber = db.Haberlers.Find(id);
                haber.baslik = col["baslik"];
                haber.icerik = col["icerik"];
                haber.Kategoriler_kategori_id = int.Parse(col["Kategoriler_kategori_id"]);
                haber.resim = col["resim"];
            }
            else
            {
                var sil = db.Haberlers.Find(id);
                db.Haberlers.Remove(sil);

                Haberlers haber = new Haberlers();
                haber.baslik = col["baslik"];
                haber.icerik = col["icerik"];
                haber.Kategoriler_kategori_id = int.Parse(col["Kategoriler_kategori_id"]);
                haber.resim = col["resim"];
                db.Haberlers.Add(haber);
            }
            
        }
        void ekekleme(FormCollection col, int tutid)
        {
            if (tutid == 1)
            {
                HaberlerModas tuthaber = new HaberlerModas();
                tuthaber.baslik = col["baslik"];
                tuthaber.icerik = col["icerik"];
                tuthaber.icerik1 = col["icerik1"];
                tuthaber.icerik2 = col["icerik2"];
                tuthaber.resim = col["resim"];
                tuthaber.video = col["video"];
                tuthaber.tarih = DateTime.Now.ToShortDateString();
                tuthaber.tiklanma = 0;
                db.HaberlerModas.Add(tuthaber);
            }
            else if (tutid == 2)
            {
                HaberlerSeyahats tuthaber = new HaberlerSeyahats();
                tuthaber.baslik = col["baslik"];
                tuthaber.icerik = col["icerik"];
                tuthaber.icerik1 = col["icerik1"];
                tuthaber.icerik2 = col["icerik2"];
                tuthaber.resim = col["resim"];
                tuthaber.video = col["video"];
                tuthaber.tarih = DateTime.Now.ToShortDateString();
                tuthaber.tiklanma = 0;
                db.HaberlerSeyahats.Add(tuthaber);
            }
            else if (tutid == 3)
            {
                HaberlerSpors tuthaber = new HaberlerSpors();
                tuthaber.baslik = col["baslik"];
                tuthaber.icerik = col["icerik"];
                tuthaber.icerik1 = col["icerik1"];
                tuthaber.icerik2 = col["icerik2"];
                tuthaber.resim = col["resim"];
                tuthaber.video = col["video"];
                tuthaber.tarih = DateTime.Now.ToShortDateString();
                tuthaber.tiklanma = 0;
                db.HaberlerSpors.Add(tuthaber);
            }
            else if (tutid == 4)
            {
                HaberlerDogas tuthaber = new HaberlerDogas();
                tuthaber.baslik = col["baslik"];
                tuthaber.icerik = col["icerik"];
                tuthaber.icerik1 = col["icerik1"];
                tuthaber.icerik2 = col["icerik2"];
                tuthaber.resim = col["resim"];
                tuthaber.video = col["video"];
                tuthaber.tarih = DateTime.Now.ToShortDateString();
                tuthaber.tiklanma = 0;
                db.HaberlerDogas.Add(tuthaber);
            }
            else if (tutid == 5)
            {
                HaberlerTeknolojis tuthaber = new HaberlerTeknolojis();
                tuthaber.baslik = col["baslik"];
                tuthaber.icerik = col["icerik"];
                tuthaber.icerik1 = col["icerik1"];
                tuthaber.icerik2 = col["icerik2"];
                tuthaber.resim = col["resim"];
                tuthaber.video = col["video"];
                tuthaber.tarih = DateTime.Now.ToShortDateString();
                tuthaber.tiklanma = 0;
                db.HaberlerTeknolojis.Add(tuthaber);
            }
            else if (tutid == 6)
            {
                HaberlerFilms tuthaber = new HaberlerFilms();
                tuthaber.baslik = col["baslik"];
                tuthaber.icerik = col["icerik"];
                tuthaber.icerik1 = col["icerik1"];
                tuthaber.icerik2 = col["icerik2"];
                tuthaber.resim = col["resim"];
                tuthaber.video = col["video"];
                tuthaber.tarih = DateTime.Now.ToShortDateString();
                tuthaber.tiklanma = 0;
                db.HaberlerFilms.Add(tuthaber);
            }
        }
        void checkcox(FormCollection col)
        {
            if (col["checkbox"] == "1")
            {
                HaberlerIndexes inceks = new HaberlerIndexes();
                inceks.baslik = col["baslik"];
                inceks.icerik = col["icerik"];
                inceks.Kategoriler_kategori_id = int.Parse(col["Kategoriler_kategori_id"]);
                inceks.resim = col["resim"];
                db.HaberlerIndexes.Add(inceks);
            }
        }
        [HttpPost]
        public ActionResult HaberGuncelle(int id, int kategori, FormCollection col)
        {
            if (kategori == 1)
            {
                tumhaberler1(col,id,kategori);//Tüm haberlerde güncelleme

                if (int.Parse(col["Kategoriler_kategori_id"]) == kategori)
                {

                    var haber = db.HaberlerModas.Find(int.Parse(col["h_moda_id"].ToString()));

                    haber.baslik = col["baslik"];
                    haber.icerik = col["icerik"];
                    haber.icerik1 = col["icerik1"];
                    haber.icerik2 = col["icerik2"];
                    haber.resim = col["resim"];
                    haber.video = col["video"];
                    haber.tarih = DateTime.Now.ToShortDateString();
                    haber.tiklanma = 0;
                    checkcox(col);
                    db.SaveChanges();
                }
                else
                {
                    var haber = db.HaberlerModas.Find(int.Parse(col["h_moda_id"].ToString()));
                    db.HaberlerModas.Remove(haber);

                    ekekleme(col, int.Parse(col["Kategoriler_kategori_id"]));//Kategori farklı ise farklı bir tabloya ekleme fonksiyonu

                    checkcox(col);

                    db.SaveChanges();
                }

            }
            else if (kategori == 2)
            {
                tumhaberler1(col, id, kategori);//Tüm haberlerde güncelleme

                if (int.Parse(col["Kategoriler_kategori_id"]) == kategori)
                {
                    var haber = db.HaberlerSeyahats.Find(int.Parse(col["h_seyahat_id"].ToString()));

                    haber.baslik = col["baslik"];
                    haber.icerik = col["icerik"];
                    haber.icerik1 = col["icerik1"];
                    haber.icerik2 = col["icerik2"];
                    haber.resim = col["resim"];
                    haber.video = col["video"];
                    haber.tarih = DateTime.Now.ToShortDateString();
                    haber.tiklanma = 0;
                    checkcox(col);
                    db.SaveChanges();
                }
                else
                {
                    var haber = db.HaberlerSeyahats.Find(int.Parse(col["h_seyahat_id"].ToString()));
                    db.HaberlerSeyahats.Remove(haber);

                    ekekleme(col, int.Parse(col["Kategoriler_kategori_id"]));//Kategori farklı ise farklı bir tabloya ekleme fonksiyonu
                    checkcox(col);
                    db.SaveChanges();
                }

            }
            else if (kategori == 3)
            {
                tumhaberler1(col, id, kategori);//Tüm haberlerde güncelleme

                if (int.Parse(col["Kategoriler_kategori_id"]) == kategori)
                {
                    var haber = db.HaberlerSpors.Find(int.Parse(col["h_spor_id"].ToString()));

                    haber.baslik = col["baslik"];
                    haber.icerik = col["icerik"];
                    haber.icerik1 = col["icerik1"];
                    haber.icerik2 = col["icerik2"];
                    haber.resim = col["resim"];
                    haber.video = col["video"];
                    haber.tarih = DateTime.Now.ToShortDateString();
                    haber.tiklanma = 0;
                    checkcox(col);
                    db.SaveChanges();
                }
                else
                {
                    var haber = db.HaberlerSpors.Find(int.Parse(col["h_spor_id"].ToString()));
                    db.HaberlerSpors.Remove(haber);

                    ekekleme(col, int.Parse(col["Kategoriler_kategori_id"]));//Kategori farklı ise farklı bir tabloya ekleme fonksiyonu
                    checkcox(col);
                    db.SaveChanges();
                }

            }
            else if (kategori == 4)
            {
                tumhaberler1(col, id, kategori);//Tüm haberlerde güncelleme

                if (int.Parse(col["Kategoriler_kategori_id"]) == kategori)
                {
                    var haber = db.HaberlerDogas.Find(int.Parse(col["h_doga_id"].ToString()));

                    haber.baslik = col["baslik"];
                    haber.icerik = col["icerik"];
                    haber.icerik1 = col["icerik1"];
                    haber.icerik2 = col["icerik2"];
                    haber.resim = col["resim"];
                    haber.video = col["video"];
                    haber.tarih = DateTime.Now.ToShortDateString();
                    haber.tiklanma = 0;
                    checkcox(col);
                    db.SaveChanges();
                }
                else
                {
                    var haber = db.HaberlerDogas.Find(int.Parse(col["h_doga_id"].ToString()));
                    db.HaberlerDogas.Remove(haber);

                    ekekleme(col, int.Parse(col["Kategoriler_kategori_id"]));//Kategori farklı ise farklı bir tabloya ekleme fonksiyonu
                    checkcox(col);
                    db.SaveChanges();
                }

            }
            else if (kategori == 5)
            {
                tumhaberler1(col, id, kategori);//Tüm haberlerde güncelleme

                if (int.Parse(col["Kategoriler_kategori_id"]) == kategori)
                {
                    var haber = db.HaberlerTeknolojis.Find(int.Parse(col["h_teknoloji_id"].ToString()));

                    haber.baslik = col["baslik"];
                    haber.icerik = col["icerik"];
                    haber.icerik1 = col["icerik1"];
                    haber.icerik2 = col["icerik2"];
                    haber.resim = col["resim"];
                    haber.video = col["video"];
                    haber.tarih = DateTime.Now.ToShortDateString();
                    haber.tiklanma = 0;
                    checkcox(col);
                    db.SaveChanges();
                }
                else
                {
                    var haber = db.HaberlerTeknolojis.Find(int.Parse(col["h_teknoloji_id"].ToString()));
                    db.HaberlerTeknolojis.Remove(haber);

                    ekekleme(col, int.Parse(col["Kategoriler_kategori_id"]));//Kategori farklı ise farklı bir tabloya ekleme fonksiyonu
                    checkcox(col);
                    db.SaveChanges();
                }

            }
            else if (kategori == 6)
            {
                tumhaberler1(col, id, kategori);//Tüm haberlerde güncelleme

                if (int.Parse(col["Kategoriler_kategori_id"]) == kategori)
                {
                    var haber = db.HaberlerFilms.Find(int.Parse(col["h_film_id"].ToString()));

                    haber.baslik = col["baslik"];
                    haber.icerik = col["icerik"];
                    haber.icerik1 = col["icerik1"];
                    haber.icerik2 = col["icerik2"];
                    haber.resim = col["resim"];
                    haber.video = col["video"];
                    haber.tarih = DateTime.Now.ToShortDateString();
                    haber.tiklanma = 0;
                    checkcox(col);
                    db.SaveChanges();
                }
                else
                {
                    var haber = db.HaberlerFilms.Find(int.Parse(col["h_film_id"].ToString()));
                    db.HaberlerFilms.Remove(haber);

                    ekekleme(col, int.Parse(col["Kategoriler_kategori_id"]));//Kategori farklı ise farklı bir tabloya ekleme fonksiyonu
                    checkcox(col);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("Index", "AHaberEditoru");
        }
    }
}