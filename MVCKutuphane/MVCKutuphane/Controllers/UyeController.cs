using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Uyeler.ToList();
            var degerler = db.Uyeler.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(Uyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.Uyeler.Add(p);
            db.SaveChanges();

            return View();

        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.Uyeler.Find(id);
            db.Uyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.Uyeler.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(Uyeler p)
        {
            var uye = db.Uyeler.Find(p.Id);
            uye.Ad = p.Ad;
            uye.Soyad = p.Soyad;
            uye.Mail = p.Mail;
            uye.KullaniciAdi = p.KullaniciAdi;
            uye.Sifre = p.Sifre;
            uye.Telefon = p.Telefon;
            uye.Okul = p.Okul;
            uye.Fotograf = p.Fotograf;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}