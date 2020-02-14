using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Models.Class
{
    public class IEKitap
    {
        public IEnumerable<Kitap> Kitaps { get; set; }
        public IEnumerable<Hakkimizda> Hakkimizdas { get; set; }
    }
}