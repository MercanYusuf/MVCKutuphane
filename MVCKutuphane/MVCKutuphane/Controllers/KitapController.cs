using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.Kitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.Ad.Contains(p));
            }
            //var kitaplar = db.Kitap.ToList();
            return View(kitaplar.ToList());
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.Kategori.ToList()
                select new SelectListItem
                {
                    Text = i.Ad,
                    Value = i.Id.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from y in db.Yazar.ToList()
                select new SelectListItem
                {
                    Text = y.Ad + ' '+ y.Soyad,
                    Value = y.Id.ToString()
                }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(Kitap P)
        {
            var ktg = db.Kategori.Where(k => k.Id == P.Kategori1.Id).FirstOrDefault();
            var yzr = db.Yazar.Where(y => y.Id == P.Yazar1.Id).FirstOrDefault();
            P.Kategori1 = ktg;
            P.Yazar1 = yzr;
            db.Kitap.Add(P);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.Kitap.Find(id);
            db.Kitap.Remove(kitap);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var ktp = db.Kitap.Find(id);
            List<SelectListItem> deger1 = (from i in db.Kategori.ToList()
                select new SelectListItem
                {
                    Text = i.Ad,
                    Value = i.Id.ToString()
                }).ToList();

            ViewBag.dgr = deger1;
            List<SelectListItem> deger2 = (from i in db.Yazar.ToList()
                select new SelectListItem
                {
                    Text = i.Ad,
                    Value = i.Id.ToString()
                }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }

        public ActionResult KitapGuncelle(Kitap p)
        {
            var ktp = db.Kitap.Find(p.Id);
            ktp.Ad = p.Ad;
            ktp.Basimyil = p.Basimyil;
            ktp.Sayfa = p.Sayfa;
            ktp.Durum = true;
            ktp.Yayinevi = p.Yayinevi;

            var ktg = db.Kategori.Where(k => k.Id == p.Kategori1.Id).FirstOrDefault();
            var yzr = db.Yazar.Where(y => y.Id == p.Yazar1.Id).FirstOrDefault();
            ktp.Kategori = ktg.Id;
            ktp.Yazar = yzr.Id;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}