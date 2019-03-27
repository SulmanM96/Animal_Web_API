using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimalRegistration;

namespace AnimalRegistration.Controllers
{
    public class ReptilesController : Controller
    {
        private AnimalDB db = new AnimalDB();

        // GET: Reptiles
        public ActionResult Index()
        {
            var reptiles = db.Reptiles.Include(r => r.animal);
            return View(reptiles.ToList());
        }

        // GET: Reptiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = db.Reptiles.Find(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            return View(reptile);
        }

        // GET: Reptiles/Create
        public ActionResult Create()
        {
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID");
            return View();
        }

        // POST: Reptiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReptilesID,ReptilesName,ReptilesType,animalSpecies_animalID,DietryType,PopulationNumber")] Reptile reptile)
        {
            if (ModelState.IsValid)
            {
                db.Reptiles.Add(reptile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", reptile.animalSpecies_animalID);
            return View(reptile);
        }

        // GET: Reptiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = db.Reptiles.Find(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", reptile.animalSpecies_animalID);
            return View(reptile);
        }

        // POST: Reptiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReptilesID,ReptilesName,ReptilesType,animalSpecies_animalID,DietryType,PopulationNumber")] Reptile reptile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reptile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", reptile.animalSpecies_animalID);
            return View(reptile);
        }

        // GET: Reptiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reptile reptile = db.Reptiles.Find(id);
            if (reptile == null)
            {
                return HttpNotFound();
            }
            return View(reptile);
        }

        // POST: Reptiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reptile reptile = db.Reptiles.Find(id);
            db.Reptiles.Remove(reptile);
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
