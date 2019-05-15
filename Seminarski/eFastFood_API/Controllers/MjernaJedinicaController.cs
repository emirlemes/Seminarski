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
    public class MjernaJedinicaController : ApiController
    {
        private readonly eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/MjernaJedinica
        public IQueryable<MjernaJedinica> GetMjernaJedinicas()
        {
            return _db.MjernaJedinica;
        }

        // GET: api/MjernaJedinica/5
        [ResponseType(typeof(MjernaJedinica))]
        public IHttpActionResult GetMjernaJedinica(int id)
        {
            MjernaJedinica mjernaJedinica = _db.MjernaJedinica.Find(id);
            if (mjernaJedinica == null)
            {
                return NotFound();
            }

            return Ok(mjernaJedinica);
        }

        // PUT: api/MjernaJedinica/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMjernaJedinica(int id, MjernaJedinica mjernaJedinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mjernaJedinica.MjernaJedinicaID)
            {
                return BadRequest();
            }

            _db.Entry(mjernaJedinica).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MjernaJedinicaExists(id))
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

        // POST: api/MjernaJedinica
        [ResponseType(typeof(MjernaJedinica))]
        public IHttpActionResult PostMjernaJedinica(MjernaJedinica mjernaJedinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.MjernaJedinica.Add(mjernaJedinica);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mjernaJedinica.MjernaJedinicaID }, mjernaJedinica);
        }

        // DELETE: api/MjernaJedinica/5
        [ResponseType(typeof(MjernaJedinica))]
        public IHttpActionResult DeleteMjernaJedinica(int id)
        {
            MjernaJedinica mjernaJedinica = _db.MjernaJedinica.Find(id);
            if (mjernaJedinica == null)
            {
                return NotFound();
            }

            _db.MjernaJedinica.Remove(mjernaJedinica);
            _db.SaveChanges();

            return Ok(mjernaJedinica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MjernaJedinicaExists(int id)
        {
            return _db.MjernaJedinica.Count(e => e.MjernaJedinicaID == id) > 0;
        }
    }
}