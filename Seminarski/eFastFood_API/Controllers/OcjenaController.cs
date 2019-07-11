using eFastFood_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace eFastFood_API.Controllers
{
    public class OcjenaController : ApiController
    {
        private readonly eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/Ocjena
        [ResponseType(typeof(List<Ocjena>))]
        public IHttpActionResult GetOcjena()
        {
            return Ok(_db.Ocjena.ToList());
        }

        // GET: api/Ocjena/5
        [ResponseType(typeof(Ocjena))]
        public IHttpActionResult GetOcjena(int id)
        {
            return Ok(_db.Ocjena.Where(x => x.OcjenaID == id).FirstOrDefault());
        }

        // GET: api/Ocjena/OcjenaUserProduct/{userId}/{producId}
        [HttpGet]
        [ResponseType(typeof(Ocjena))]
        [Route("api/Ocjena/OcjenaUserProduct/{userId}/{productId}")]
        public IHttpActionResult OcjenaUserProduct(int userId, int productId)
        {
            var a = _db.Ocjena.Where(x => x.GotoviProizvodID == productId && x.KlijentID == userId).FirstOrDefault();
            if (a != null)
                return Ok(a);
            return Ok(0);
        }

        // PUT: api/Ocjena/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOcjena(int id, Ocjena ocjena)
        {
            if (id != ocjena.OcjenaID)
                return BadRequest();

            Ocjena o = _db.Ocjena.Find(id);

            if (o == null)
                NotFound();

            o.NumerickaOcjena = ocjena.NumerickaOcjena;
            o.Komentar = ocjena.Komentar;

            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ocjena
        [ResponseType(typeof(Ocjena))]
        public IHttpActionResult PostOcjena(Ocjena ocjena)
        {
            _db.Ocjena.Add(ocjena);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = ocjena.OcjenaID }, ocjena);
        }

        // DELETE: api/Ocjena/5
        [ResponseType(typeof(Dobavljac))]
        public IHttpActionResult DeleteOcjena(int id)
        {
            Ocjena ocjena = _db.Ocjena.Find(id);
            if (ocjena == null)
                return NotFound();

            _db.Ocjena.Remove(ocjena);
            _db.SaveChanges();

            return Ok(ocjena);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();

            base.Dispose(disposing);
        }
    }
}
