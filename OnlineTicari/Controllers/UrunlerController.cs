﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicari.Models.Siniflar;

namespace OnlineTicari.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Urunlers select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }
       
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urunler p)
        {
            c.Urunlers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.Urunlers.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = c.Urunlers.Find(id);
            return View("UrunGetir", urundeger);
        }

        public ActionResult UrunGuncelle(Urunler p)
        {
            var urn = c.Urunlers.Find(p.UrunId);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = c.Urunlers.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var deger2 = c.Urunlers.Find(id);
            ViewBag.dgr2 = deger2.UrunId;
            ViewBag.dgr3 = deger2.SatisFiyat;
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");

        } 
    }
}