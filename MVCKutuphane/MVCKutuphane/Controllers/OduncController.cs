using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    
    public class OduncController : Controller
    {
        // GET: Odunc
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        public ActionResult Index()
        {
            var degerler = db.Hareket.Where(i=>i.IslemDurum==false).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

        public ActionResult OduncVer(Hareket p)
        {
            db.Hareket.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Oduncİade(Hareket p)
        {
            var odn = db.Hareket.Find(p.Id);
            DateTime d1 = DateTime.Parse(odn.İadeTarihi.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;


            ViewBag.dgr = d3.TotalDays;
            return View("Oduncİade", odn);
        }

        public ActionResult OduncGuncelle(Hareket p)
        {
            var hrk = db.Hareket.Find(p.Id);
            hrk.UyeGetirTarih = p.UyeGetirTarih;
            hrk.IslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}