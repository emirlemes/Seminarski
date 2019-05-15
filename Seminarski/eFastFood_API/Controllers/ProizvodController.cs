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
    public class ProizvodController : ApiController
    {
        private eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/Proizvod
        public IQueryable<Proizvod> GetProizvod()
        {
            return _db.Proizvod;
        }

        // GET: api/Proizvod/5
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult GetProizvod(int id)
        {
            Proizvod proizvod = _db.Proizvod.Find(id);
            if (proizvod == null)
            {
                return NotFound();
            }

            return Ok(proizvod);
        }

        // PUT: api/Proizvod/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProizvod(int id, Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proizvod.ProizvodID)
            {
                return BadRequest();
            }

            _db.Entry(proizvod).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProizvodExists(id))
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

        // POST: api/Proizvod
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult PostProizvod(Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Proizvod.Add(proizvod);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proizvod.ProizvodID }, proizvod);
        }



        // DELETE: api/Proizvod/5
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult DeleteProizvod(int id)
        {
            Proizvod proizvod = _db.Proizvod.Find(id);
            if (proizvod == null)
            {
                return NotFound();
            }

            _db.Proizvod.Remove(proizvod);
            _db.SaveChanges();

            return Ok(proizvod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProizvodExists(int id)
        {
            return _db.Proizvod.Count(e => e.ProizvodID == id) > 0;
        }
    }
}