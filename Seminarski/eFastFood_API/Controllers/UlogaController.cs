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
        private readonly eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/Uloga
        public IHttpActionResult GetUloga()
        {
            return Ok(_db.Uloga.ToList());
        }

        // GET: api/Uloga/5
        [ResponseType(typeof(Uloga))]
        public IHttpActionResult GetUloga(int id)
        {
            Uloga uloga = _db.Uloga.Find(id);
            if (uloga == null)
                return NotFound();

            return Ok(uloga);
        }

        // PUT: api/Uloga/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUloga(int id, Uloga uloga)
        {

            if (id != uloga.UlogaID)
                return BadRequest();

            Uloga u = _db.Uloga.Find(id);

            u.Naziv = uloga.Naziv;
            u.Opis = uloga.Opis;

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

        // POST: api/Uloga
        [ResponseType(typeof(Uloga))]
        public IHttpActionResult PostUloga(Uloga uloga)
        {
            try
            {
                _db.Uloga.Add(uloga);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = uloga.UlogaID }, uloga);
        }

        // DELETE: api/Uloga/5
        [ResponseType(typeof(Uloga))]
        public IHttpActionResult DeleteUloga(int id)
        {
            Uloga uloga = _db.Uloga.Find(id);
            if (uloga == null)
                return NotFound();

            try
            {
                _db.Uloga.Remove(uloga);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(uloga);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}