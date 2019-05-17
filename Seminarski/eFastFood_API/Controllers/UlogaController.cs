using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using eFastFood_API.Models;

namespace eFastFood_API.Controllers
{
    public class UlogaController : ApiController
    {
        private eFastFoodEntitie db = new eFastFoodEntitie();

        // GET: api/Uloga
        public IQueryable<Uloga> GetUloga()
        {
            return db.Uloga;
        }

        // GET: api/Uloga/5
        [ResponseType(typeof(Uloga))]
        public IHttpActionResult GetUloga(int id)
        {
            Uloga uloga = db.Uloga.Find(id);
            if (uloga == null)
            {
                return NotFound();
            }

            return Ok(uloga);
        }

        // PUT: api/Uloga/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUloga(int id, Uloga uloga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uloga.UlogaID)
            {
                return BadRequest();
            }

            db.Entry(uloga).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UlogaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Uloga
        [ResponseType(typeof(Uloga))]
        public IHttpActionResult PostUloga(Uloga uloga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Uloga.Add(uloga);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uloga.UlogaID }, uloga);
        }

        // DELETE: api/Uloga/5
        [ResponseType(typeof(Uloga))]
        public IHttpActionResult DeleteUloga(int id)
        {
            Uloga uloga = db.Uloga.Find(id);
            if (uloga == null)
            {
                return NotFound();
            }

            db.Uloga.Remove(uloga);
            db.SaveChanges();

            return Ok(uloga);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UlogaExists(int id)
        {
            return db.Uloga.Count(e => e.UlogaID == id) > 0;
        }
    }
}