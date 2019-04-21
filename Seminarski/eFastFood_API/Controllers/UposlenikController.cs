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
    public class UposlenikController : ApiController
    {
        private eFastFoodEntities _db = new eFastFoodEntities();

        // GET: api/Uposlenik
        [HttpGet]
        [Route("api/Uposlenik")]
        [ResponseType(typeof(List<Uposlenik>))]
        public IHttpActionResult GetUposlenik()
        {
            return Ok(_db.sp_UposleniciGetAll().ToList());
        }

        // GET: api/Uposlenik/5
        [HttpGet]
        [Route("api/Uposlenik/{id}")]
        [ResponseType(typeof(Uposlenik))]
        public IHttpActionResult GetUposlenik(int id)
        {
            Uposlenik uposlenik = _db.Uposlenik.Find(id);
            if (uposlenik == null)
            {
                return NotFound();
            }

            return Ok(uposlenik);
        }

        // PUT: api/Uposlenik/5
        [HttpPut]
        [Route("api/Uposlenik/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUposlenik(int id, Uposlenik uposlenik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uposlenik.UposlenikID)
            {
                return BadRequest();
            }

            _db.Entry(uposlenik).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UposlenikExists(id))
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

        // POST: api/Uposlenik
        [HttpPost]
        [Route("api/Uposlenik")]
        [ResponseType(typeof(Uposlenik))]
        public IHttpActionResult PostUposlenik(Uposlenik uposlenik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Uposlenik.Add(uposlenik);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uposlenik.UposlenikID }, uposlenik);
        }

        // DELETE: api/Uposlenik/5
        [HttpDelete]
        [Route("api/Uposlenik/{id}")]
        [ResponseType(typeof(Uposlenik))]
        public IHttpActionResult DeleteUposlenik(int id)
        {
            Uposlenik uposlenik = _db.Uposlenik.Find(id);
            if (uposlenik == null)
            {
                return NotFound();
            }

            _db.Uposlenik.Remove(uposlenik);
            _db.SaveChanges();

            return Ok(uposlenik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UposlenikExists(int id)
        {
            return _db.Uposlenik.Count(e => e.UposlenikID == id) > 0;
        }
    }
}