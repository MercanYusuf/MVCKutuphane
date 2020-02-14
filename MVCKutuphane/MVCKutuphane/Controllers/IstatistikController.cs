using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
   
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        public ActionResult Index()
        {
            var deger1 = db.Uyeler.Count();
            var deger2 = db.Kitap.Count();
            var deger3 = db.Kitap.Where(i => i.Durum == false).Count();
            var deger4 = db.Cezalar.Sum(x => x.Para);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dg4 = deger4;

            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase resimBase)
        {
            if (resimBase.ContentLength>0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/Web2/GaleriResim"),
                    Path.GetFileName(resimBase.FileName));
                resimBase.SaveAs(dosyayolu);


            }

            return RedirectToAction("Galeri");
        }

        public ActionResult LinqKart()
        {
            var deger1 = db.Kitap.Count();
            var deger2 = db.Uyeler.Count();
            var deger3 = db.Cezalar.Sum(x => x.Para);
            var deger4 = db.Kitap.Where(x => x.Durum==false).Count();
            var deger5 = db.Kategori.Count();
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger9 = db.Kitap.GroupBy(x => x.Yayinevi).OrderByDescending(z => z.Count()).Select(y => new {y.Key}).FirstOrDefault();
            var deger11 = db.İletisim.Count();


            ViewBag.dgr = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr11 = deger11;
            return View();
        }
    }
}