using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcStajOdevi.Models;
using System.Data.Entity;
using System.Net;

namespace WebMvcStajOdevi.Controllers
{
    public class HomeController : Controller
    {
        OkulDataEntities firmaliste = new OkulDataEntities();
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Liste()
        {
            ViewBag.Message = "Firma Listemiz";

            return View(firmaliste.Firmalar.ToList());
        }

        public ActionResult Ekle()
        {
            ViewBag.Message = "Firma Ekle";

            return View();
        }

        private OkulDataEntities db = new OkulDataEntities();

        // GET: Firmalars
        public ActionResult Index()
        {
            return View(db.Firmalar.ToList());
        }

        // GET: Firmalars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firmalar firmalar = db.Firmalar.Find(id);
            if (firmalar == null)
            {
                return HttpNotFound();
            }
            return View(firmalar);
        }

        // GET: Firmalars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Firmalars/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Isim,Sehir,Ilce,Adres,Telefon,Kabul,Memnun,Konu,Beklenti,Maas,Calisan")] Firmalar firmalar)
        {
            if (ModelState.IsValid)
            {
                db.Firmalar.Add(firmalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firmalar);
        }

        // GET: Firmalars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firmalar firmalar = db.Firmalar.Find(id);
            if (firmalar == null)
            {
                return HttpNotFound();
            }
            return View(firmalar);
        }

        // POST: Firmalars/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Isim,Sehir,Ilce,Adres,Telefon,Kabul,Memnun,Konu,Beklenti,Maas,Calisan")] Firmalar firmalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firmalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firmalar);
        }

        // GET: Firmalars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firmalar firmalar = db.Firmalar.Find(id);
            if (firmalar == null)
            {
                return HttpNotFound();
            }
            return View(firmalar);
        }

        // POST: Firmalars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Firmalar firmalar = db.Firmalar.Find(id);
            db.Firmalar.Remove(firmalar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}