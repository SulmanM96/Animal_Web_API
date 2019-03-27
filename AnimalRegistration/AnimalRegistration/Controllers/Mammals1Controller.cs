using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using AnimalRegistration;

namespace AnimalRegistration.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using AnimalRegistration;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Mammal>("Mammals1");
    builder.EntitySet<animal>("animals"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class Mammals1Controller : ODataController
    {
        private AnimalDB db = new AnimalDB();

        // GET: odata/Mammals1
        [EnableQuery]
        public IQueryable<Mammal> GetMammals1()
        {
            return db.Mammals;
        }

        // GET: odata/Mammals1(5)
        [EnableQuery]
        public SingleResult<Mammal> GetMammal([FromODataUri] int key)
        {
            return SingleResult.Create(db.Mammals.Where(mammal => mammal.MammalsID == key));
        }

        // PUT: odata/Mammals1(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Mammal> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mammal mammal = db.Mammals.Find(key);
            if (mammal == null)
            {
                return NotFound();
            }

            patch.Put(mammal);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MammalExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(mammal);
        }

        // POST: odata/Mammals1
        public IHttpActionResult Post(Mammal mammal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mammals.Add(mammal);
            db.SaveChanges();

            return Created(mammal);
        }

        // PATCH: odata/Mammals1(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Mammal> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mammal mammal = db.Mammals.Find(key);
            if (mammal == null)
            {
                return NotFound();
            }

            patch.Patch(mammal);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MammalExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(mammal);
        }

        // DELETE: odata/Mammals1(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Mammal mammal = db.Mammals.Find(key);
            if (mammal == null)
            {
                return NotFound();
            }

            db.Mammals.Remove(mammal);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Mammals1(5)/animal
        [EnableQuery]
        public SingleResult<animal> Getanimal([FromODataUri] int key)
        {
            return SingleResult.Create(db.Mammals.Where(m => m.MammalsID == key).Select(m => m.animal));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MammalExists(int key)
        {
            return db.Mammals.Count(e => e.MammalsID == key) > 0;
        }
    }
}
