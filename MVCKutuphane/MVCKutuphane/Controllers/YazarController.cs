using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        public ActionResult Index()
        {
            var degerler = db.Yazar.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(Yazar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.Yazar.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult YazarSil(int id)
        {
            var yazar = db.Yazar.Find(id);
            db.Yazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yazar = db.Yazar.Find(id);
            return View("YazarGetir", yazar);
        }

        public ActionResult YazarGuncelle(Yazar y)
        {
            var yzr = db.Yazar.Find(y.Id);
            yzr.Ad = y.Ad;
            yzr.Soyad = y.Soyad;
            yzr.Detay = y.Detay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}