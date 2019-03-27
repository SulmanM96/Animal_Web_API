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
    public class MammalsController : Controller
    {
        private AnimalDB db = new AnimalDB();

        // GET: Mammals
        public ActionResult Index()
        {
            var mammals = db.Mammals.Include(m => m.animal);
            return View(mammals.ToList());
        }

        // GET: Mammals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mammal mammal = db.Mammals.Find(id);
            if (mammal == null)
            {
                return HttpNotFound();
            }
            return View(mammal);
        }

        // GET: Mammals/Create
        public ActionResult Create()
        {
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID");
            return View();
        }

        // POST: Mammals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MammalsID,MammalsName,animalSpecies_animalID,MammalsType,DietryType,PopulationNumber")] Mammal mammal)
        {
            if (ModelState.IsValid)
            {
                db.Mammals.Add(mammal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", mammal.animalSpecies_animalID);
            return View(mammal);
        }

        // GET: Mammals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mammal mammal = db.Mammals.Find(id);
            if (mammal == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", mammal.animalSpecies_animalID);
            return View(mammal);
        }

        // POST: Mammals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MammalsID,MammalsName,animalSpecies_animalID,MammalsType,DietryType,PopulationNumber")] Mammal mammal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mammal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", mammal.animalSpecies_animalID);
            return View(mammal);
        }

        // GET: Mammals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mammal mammal = db.Mammals.Find(id);
            if (mammal == null)
            {
                return HttpNotFound();
            }
            return View(mammal);
        }

        // POST: Mammals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mammal mammal = db.Mammals.Find(id);
            db.Mammals.Remove(mammal);
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
