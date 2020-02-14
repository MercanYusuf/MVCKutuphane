using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCKutuphane.Models.Class;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    public class VitrinController : Controller
    {

        // GET: Vitrin
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            IEKitap cs = new IEKitap();

            cs.Kitaps = db.Kitap.ToList();
            cs.Hakkimizdas = db.Hakkimizda.ToList();

            //var degerler = db.Kitap.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(İletisim t)
        {
            db.İletisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}