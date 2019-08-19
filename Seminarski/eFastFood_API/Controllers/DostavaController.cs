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
    public class DostavaController : ApiController
    {
        private readonly eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/Dostava
        public IHttpActionResult GetDostava()
        {
            return Ok(_db.Dostava.ToList());
        }

        // GET: api/Dostava/5
        [ResponseType(typeof(Dostava))]
        public IHttpActionResult GetDostava(int id)
        {
            Dostava dostava = _db.Dostava.Find(id);
            if (dostava == null)
                return NotFound();

            return Ok(dostava);
        }

        // PUT: api/Dostava/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDostava(int id, Dostava dostava)
        {
            if (id != dostava.DostavaID)
                return BadRequest();

            Dostava d = _db.Dostava.Find(id);

            d.AdresaDostave = dostava.AdresaDostave;
            d.NarudzbaID = dostava.NarudzbaID;
            d.UposlenikID = dostava.UposlenikID;
            d.VrijemeDostavljanja = dostava.VrijemeDostavljanja;
            d.VrijemePreuzimanja = dostava.VrijemePreuzimanja;

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

        // POST: api/Dostava
        [ResponseType(typeof(Dostava))]
        public IHttpActionResult PostDostava(Dostava dostava)
        {
            _db.Dostava.Add(dostava);

            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = dostava.DostavaID }, dostava);
        }

        // DELETE: api/Dostava/5
        [ResponseType(typeof(Dostava))]
        public IHttpActionResult DeleteDostava(int id)
        {
            Dostava dostava = _db.Dostava.Find(id);
            if (dostava == null)
                return NotFound();

            _db.Dostava.Remove(dostava);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(dostava);
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