using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        KutuphaneDbEntities db = new KutuphaneDbEntities();
        public ActionResult Index()
        {
            var degerler = db.Hareket.Where(i => i.IslemDurum == true).ToList();
            return View(degerler);
        }
    }
}