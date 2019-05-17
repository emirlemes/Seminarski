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
    public class NarudzbaController : ApiController
    {
        private eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/Narudzba
        public IQueryable<Narudzba> GetNarudzba()
        {
            return _db.Narudzba;
        }

        // GET: api/Narudzba/5
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult GetNarudzba(int id)
        {
            Narudzba narudzba = _db.Narudzba.Find(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            return Ok(narudzba);
        }
        // GET: api/Narudzba/BrojNarudzbiAll
        [HttpGet]
        [ResponseType(typeof(Dictionary<int, int>))]
        [Route("api/Narudzba/BrojNarudzbiAll")]
        public IHttpActionResult BrojNarudzbiAll()
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            _db.esp_BrojNarudzbiAll().ToList().ForEach(x => keyValuePairs.Add(x.KlijentID ?? 0, x.BrojNarudzbi ?? 0));
            return Ok(keyValuePairs);
        }

        // PUT: api/Narudzba/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNarudzba(int id, Narudzba narudzba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != narudzba.NarudzbaID)
            {
                return BadRequest();
            }

            _db.Entry(narudzba).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NarudzbaExists(id))
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

        // POST: api/Narudzba
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult PostNarudzba(Narudzba narudzba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Narudzba.Add(narudzba);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = narudzba.NarudzbaID }, narudzba);
        }

        // DELETE: api/Narudzba/5
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult DeleteNarudzba(int id)
        {
            Narudzba narudzba = _db.Narudzba.Find(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            _db.Narudzba.Remove(narudzba);
            _db.SaveChanges();

            return Ok(narudzba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NarudzbaExists(int id)
        {
            return _db.Narudzba.Count(e => e.NarudzbaID == id) > 0;
        }
    }
}