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
    public class KategorijaController : ApiController
    {
        private eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/Kategorija
        public IQueryable<Kategorija> GetKategorija()
        {
            return _db.Kategorija;
        }

        // GET: api/Kategorija/5
        [ResponseType(typeof(Kategorija))]
        public IHttpActionResult GetKategorija(int id)
        {
            Kategorija kategorija = _db.Kategorija.Find(id);
            if (kategorija == null)
            {
                return NotFound();
            }

            return Ok(kategorija);
        }

        // PUT: api/Kategorija/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKategorija(int id, Kategorija kategorija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kategorija.KategorijaID)
            {
                return BadRequest();
            }

            _db.Entry(kategorija).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategorijaExists(id))
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

        // POST: api/Kategorija
        [ResponseType(typeof(Kategorija))]
        public IHttpActionResult PostKategorija(Kategorija kategorija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Kategorija.Add(kategorija);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kategorija.KategorijaID }, kategorija);
        }

        // DELETE: api/Kategorija/5
        [ResponseType(typeof(Kategorija))]
        public IHttpActionResult DeleteKategorija(int id)
        {
            Kategorija kategorija = _db.Kategorija.Find(id);
            if (kategorija == null)
            {
                return NotFound();
            }

            _db.Kategorija.Remove(kategorija);
            _db.SaveChanges();

            return Ok(kategorija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KategorijaExists(int id)
        {
            return _db.Kategorija.Count(e => e.KategorijaID == id) > 0;
        }
    }
}