using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicari.Models.Siniflar;

namespace OnlineTicari.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();

        // GET: Fatura
        public ActionResult Index()
        {
            var liste = c.Faturas.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturas.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Fatura f)
        {
            var fatura = c.Faturas.Find(f.Faturaid);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSiraNo = f.FaturaSiraNo;
            fatura.Saat = f.Saat;
            fatura.Tarih = f.Tarih;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            fatura.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.Fatura_kalems.Where(x => x.Faturaid == id).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(Fatura_kalem p)
        {
            c.Fatura_kalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

         public ActionResult Dinamik()
        {
            Class3 cs = new Class3();
            cs.deger1 = c.Faturas.ToList();
            cs.deger2 = c.Fatura_kalems.ToList();
            return View(cs);
        }

        public  ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSiraNo, DateTime Tarih, string VergiDairesi, string Saat,
            string TeslimEden, string TeslimAlan, string Toplam, Fatura_kalem[] kalemler) 
        {
            Fatura f = new Fatura();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSiraNo = FaturaSiraNo;
            f.Tarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.Saat = Saat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.Toplam = decimal.Parse(Toplam);
            c.Faturas.Add(f);
            foreach(var x in kalemler)
            {
                Fatura_kalem fk = new Fatura_kalem();
                fk.Aciklama = x.Aciklama;
                fk.BirimFiyat = x.BirimFiyat;
                fk.Faturaid = x.Faturaid;  
                fk.Miktar = x.Miktar;  
                fk.Tutar = x.Tutar;
                c.Fatura_kalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem başarılı", JsonRequestBehavior.AllowGet);

        }

    }
}