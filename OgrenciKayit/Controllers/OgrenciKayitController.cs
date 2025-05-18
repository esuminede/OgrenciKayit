using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using OgrenciKayit.Data;
using OgrenciKayit.Models;



namespace OgrenciKayit.Controllers
{
    public class OgrenciKayitController : Controller
    {
        // GET: OgrenciKayit
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string ara)
        {
            var ogrenciler = db.Ogrenciler.AsQueryable();
            if (!string.IsNullOrEmpty(ara))
            { 
                ogrenciler = ogrenciler.Where(s => s.Isim.Contains(ara) || s.Soyisim.Contains(ara) || s.Sinif.Contains(ara));
                ViewBag.Ara = ara;
            }
            return View(ogrenciler.ToList());
        }

        // GET: OgrenciKayit/Ekle
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(Ogrenci ogrenci)
        {
            if(ModelState.IsValid)
            {
                db.Ogrenciler.Add(ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }
        [HttpGet]
        public ActionResult Duzenle(int ogrenci_no)
        {
            var ogrenci = db.Ogrenciler.Find(ogrenci_no);
            if (ogrenci == null)
                return HttpNotFound();
            return View(ogrenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Ogrenci ogrenci)
        {
            if (ModelState.IsValid) 
            {
                var ogrenci_var = db.Ogrenciler.Find(ogrenci.OgrenciNo); // var olan öğrenci
                if (ogrenci_var == null)
                {
                    return HttpNotFound();
                }

                ogrenci_var.Sinif = ogrenci.Sinif;
                ogrenci_var.Isim = ogrenci.Isim;
                ogrenci_var.Soyisim = ogrenci.Soyisim;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sil(int ogrenci_no)
        {
            var ogrenci = db.Ogrenciler.Find(ogrenci_no);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            
            return View(ogrenci);
        }

        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult SilOnay(int ogrenci_no)
        {
            var ogrenci = db.Ogrenciler.Find(ogrenci_no);
           db.Ogrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Detay(int ogrenci_no)
        {
            var ogrenci = db.Ogrenciler.Find(ogrenci_no);
            if(ogrenci == null) 
                return HttpNotFound();

            return View(ogrenci);
        }
    }
}