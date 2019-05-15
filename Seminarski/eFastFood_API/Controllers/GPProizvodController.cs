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
    public class GPProizvodController : ApiController
    {
        private eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/GPProizvod
        public IQueryable<GPProizvod> GetGPProizvod()
        {
            return _db.GPProizvod;
        }

        // GET: api/GPProizvod/5
        [ResponseType(typeof(GPProizvod))]
        public IHttpActionResult GetGPProizvod(int id)
        {
            GPProizvod gPProizvod = _db.GPProizvod.Find(id);
            if (gPProizvod == null)
            {
                return NotFound();
            }

            return Ok(gPProizvod);
        }

        // PUT: api/GPProizvod/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGPProizvod(int id, GPProizvod gPProizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gPProizvod.GPProizvodID)
            {
                return BadRequest();
            }

            _db.Entry(gPProizvod).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GPProizvodExists(id))
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

        // POST: api/GPProizvod
        [ResponseType(typeof(GPProizvod))]
        public IHttpActionResult PostGPProizvod(GPProizvod gPProizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.GPProizvod.Add(gPProizvod);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gPProizvod.GPProizvodID }, gPProizvod);
        }

        //POST: api/GPProizvod
        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("api/GPProizvod/GPProizvodList")]
        public IHttpActionResult GPProizvodList(List<GPProizvod> gPProizvod)
        {
            if (gPProizvod == null || !gPProizvod.Any())
                return BadRequest();

            foreach (var item in gPProizvod)
                _db.GPProizvod.Add(item);

            _db.SaveChanges();

            return Ok();
        }

        // DELETE: api/GPProizvod/5
        [ResponseType(typeof(GPProizvod))]
        public IHttpActionResult DeleteGPProizvod(int id)
        {
            GPProizvod gPProizvod = _db.GPProizvod.Find(id);
            if (gPProizvod == null)
            {
                return NotFound();
            }

            _db.GPProizvod.Remove(gPProizvod);
            _db.SaveChanges();

            return Ok(gPProizvod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GPProizvodExists(int id)
        {
            return _db.GPProizvod.Count(e => e.GPProizvodID == id) > 0;
        }
    }
}