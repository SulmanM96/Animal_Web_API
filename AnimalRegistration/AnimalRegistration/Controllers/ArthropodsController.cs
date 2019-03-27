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
    public class ArthropodsController : Controller
    {
        private AnimalDB db = new AnimalDB();

        // GET: Arthropods
        public ActionResult Index()
        {
            var arthropods = db.Arthropods.Include(a => a.animal);
            return View(arthropods.ToList());
        }

        // GET: Arthropods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arthropod arthropod = db.Arthropods.Find(id);
            if (arthropod == null)
            {
                return HttpNotFound();
            }
            return View(arthropod);
        }

        // GET: Arthropods/Create
        public ActionResult Create()
        {
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID");
            return View();
        }

        // POST: Arthropods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "arthropodsID,arthropodsName,arthropodsType,animalSpecies_animalID,DietryType,PopulationNumber")] Arthropod arthropod)
        {
            if (ModelState.IsValid)
            {
                db.Arthropods.Add(arthropod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", arthropod.animalSpecies_animalID);
            return View(arthropod);
        }

        // GET: Arthropods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arthropod arthropod = db.Arthropods.Find(id);
            if (arthropod == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", arthropod.animalSpecies_animalID);
            return View(arthropod);
        }

        // POST: Arthropods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "arthropodsID,arthropodsName,arthropodsType,animalSpecies_animalID,DietryType,PopulationNumber")] Arthropod arthropod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arthropod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalSpecies_animalID = new SelectList(db.animals, "animalID", "animalID", arthropod.animalSpecies_animalID);
            return View(arthropod);
        }

        // GET: Arthropods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arthropod arthropod = db.Arthropods.Find(id);
            if (arthropod == null)
            {
                return HttpNotFound();
            }
            return View(arthropod);
        }

        // POST: Arthropods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arthropod arthropod = db.Arthropods.Find(id);
            db.Arthropods.Remove(arthropod);
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
