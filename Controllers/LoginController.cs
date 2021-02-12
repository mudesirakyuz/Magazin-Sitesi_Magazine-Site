using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Megazinde.Models.DB.DbFirst;
using Megazinde.Models.Siniflar;

namespace Megazinde.Controllers
{
    public class LoginController : Controller
    {
        DbMegazindeEntities db = new DbMegazindeEntities();
        kullanicilarClass cs = new kullanicilarClass();

        // GET: Login
        public ActionResult Index()
        {
            cs.csKullanicilar = db.Kullanicilars.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection col)
        {
            string kullaniciadi = col["kullaniciadi"];
            string parola = col["parola"];

            bool kontrol = db.Kullanicilars.Where(x => x.kullaniciadi == kullaniciadi && x.parola == parola).Any();

            if (kontrol==true)
            {
                return RedirectToAction("Index", "Anasayfa");
            }

            else return RedirectToAction("Index", "Login");

        }
    }
}