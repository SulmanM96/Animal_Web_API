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
    public class BirdsController : Controller
    {
        private AnimalDB db = new AnimalDB();

        // GET: Birds
        public ActionResult Index()
        {
            var birds = db.Birds.Include(b => b.animal);
            return View(birds.ToList());
        }

        // GET: Birds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bird bird = db.Birds.Find(id);
            if (bird == null)
            {
                return HttpNotFound();
            }
            return View(bird);
        }

        // GET: Birds/Create
        public ActionResult Create()
        {
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID");
            return View();
        }

        // POST: Birds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BirdsID,BirdName,BirdsType,animalSpecies_animalID,DietryType,PopulationNumber")] Bird bird)
        {
            if (ModelState.IsValid)
            {
                db.Birds.Add(bird);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", bird.animalSpecies_animalID);
            return View(bird);
        }

        // GET: Birds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bird bird = db.Birds.Find(id);
            if (bird == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", bird.animalSpecies_animalID);
            return View(bird);
        }

        // POST: Birds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BirdsID,BirdName,BirdsType,animalSpecies_animalID,DietryType,PopulationNumber")] Bird bird)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bird).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", bird.animalSpecies_animalID);
            return View(bird);
        }

        // GET: Birds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bird bird = db.Birds.Find(id);
            if (bird == null)
            {
                return HttpNotFound();
            }
            return View(bird);
        }

        // POST: Birds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bird bird = db.Birds.Find(id);
            db.Birds.Remove(bird);
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
