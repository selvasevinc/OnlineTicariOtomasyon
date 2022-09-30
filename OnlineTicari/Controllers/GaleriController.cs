using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicari.Models.Siniflar;
namespace OnlineTicari.Controllers
{
    public class GaleriController : Controller
    {
        Context c = new Context();
        // GET: Galeri
        public ActionResult Index()
        {
            var degerler = c.Urunlers.ToList();
            return View(degerler);
        }
    }
}