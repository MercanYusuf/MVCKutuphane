using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        public ActionResult Index()
        {
            var degerler = db.Personel.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.Personel.Add(p);
            db.SaveChanges();

            return View();

        }

        public ActionResult PersonelSil(int id)
        {
            var personel = db.Personel.Find(id);
            db.Personel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var prsnl = db.Personel.Find(id);
            return View("PersonelGetir", prsnl);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {

            
            if (!ModelState.IsValid)
            {
                return View("PersonelGetir");
            }
            var prsnl = db.Personel.Find(p.Id);
            prsnl.Personel1 = p.Personel1;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}