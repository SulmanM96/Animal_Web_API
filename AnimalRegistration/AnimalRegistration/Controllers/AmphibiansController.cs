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
    public class AmphibiansController : Controller
    {
        private AnimalDB db = new AnimalDB();

        // GET: Amphibians
        public ActionResult Index()
        {
            var amphibians = db.Amphibians.Include(a => a.animal);
            return View(amphibians.ToList());
        }

        // GET: Amphibians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amphibian amphibian = db.Amphibians.Find(id);
            if (amphibian == null)
            {
                return HttpNotFound();
            }
            return View(amphibian);
        }

        // GET: Amphibians/Create
        public ActionResult Create()
        {
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID");
            return View();
        }

        // POST: Amphibians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AmphibiansID,AmphibiansName,AmphibiansType,animalSpecies_animalID,DietryType,PopulationNumber")] Amphibian amphibian)
        {
            if (ModelState.IsValid)
            {
                db.Amphibians.Add(amphibian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", amphibian.animalSpecies_animalID);
            return View(amphibian);
        }

        // GET: Amphibians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amphibian amphibian = db.Amphibians.Find(id);
            if (amphibian == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", amphibian.animalSpecies_animalID);
            return View(amphibian);
        }

        // POST: Amphibians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AmphibiansID,AmphibiansName,AmphibiansType,animalSpecies_animalID,DietryType,PopulationNumber")] Amphibian amphibian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amphibian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", amphibian.animalSpecies_animalID);
            return View(amphibian);
        }

        // GET: Amphibians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amphibian amphibian = db.Amphibians.Find(id);
            if (amphibian == null)
            {
                return HttpNotFound();
            }
            return View(amphibian);
        }

        // POST: Amphibians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Amphibian amphibian = db.Amphibians.Find(id);
            db.Amphibians.Remove(amphibian);
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
