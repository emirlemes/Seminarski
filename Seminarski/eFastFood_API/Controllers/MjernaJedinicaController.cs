using eFastFood_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace eFastFood_API.Controllers
{
    public class MjernaJedinicaController : ApiController
    {
        private readonly eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/MjernaJedinica
        [ResponseType(typeof(List<MjernaJedinica>))]
        public IHttpActionResult GetMjernaJedinicas()
        {
            return Ok(_db.MjernaJedinica.ToList());
        }

        // GET: api/MjernaJedinica/5
        [ResponseType(typeof(MjernaJedinica))]
        public IHttpActionResult GetMjernaJedinica(int id)
        {
            MjernaJedinica mjernaJedinica = _db.MjernaJedinica.Find(id);
            if (mjernaJedinica == null)
                return NotFound();

            return Ok(mjernaJedinica);
        }

        // PUT: api/MjernaJedinica/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMjernaJedinica(int id, MjernaJedinica mjernaJedinica)
        {

            if (id != mjernaJedinica.MjernaJedinicaID)
                return BadRequest();
            MjernaJedinica mj = _db.MjernaJedinica.Find(id);

            mj.Naziv = mjernaJedinica.Naziv;
            mj.Opis = mjernaJedinica.Opis;
            mj.Exponent = mjernaJedinica.Exponent;

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

        // POST: api/MjernaJedinica
        [ResponseType(typeof(MjernaJedinica))]
        public IHttpActionResult PostMjernaJedinica(MjernaJedinica mjernaJedinica)
        {
            try
            {
                _db.MjernaJedinica.Add(mjernaJedinica);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = mjernaJedinica.MjernaJedinicaID }, mjernaJedinica);
        }

        // DELETE: api/MjernaJedinica/5
        [ResponseType(typeof(MjernaJedinica))]
        public IHttpActionResult DeleteMjernaJedinica(int id)
        {
            MjernaJedinica mjernaJedinica = _db.MjernaJedinica.Find(id);
            if (mjernaJedinica == null)
                return NotFound();

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
    }
}
