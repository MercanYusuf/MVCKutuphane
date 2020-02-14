using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
namespace MVCKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.Kategori.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori p)
        {
            db.Kategori.Add(p);
            db.SaveChanges();

            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.Kategori.Find(id);
            db.Kategori.Remove(kategori);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.Kategori.Find(id);
            return View("KategoriGetir", ktg);
        }

        public ActionResult KategoriGuncelle(Kategori p)
        {
            var ktg = db.Kategori.Find(p.Id);
            ktg.Ad = p.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}