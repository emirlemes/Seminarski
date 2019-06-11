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
    public class DobavljacController : ApiController
    {
        private eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/Dobavljac
        [ResponseType(typeof(List<Dobavljac>))]
        public IHttpActionResult GetDobavljac()
        {
            return Ok(_db.Dobavljac.ToList());
        }

        // GET: api/Dobavljac/5
        [ResponseType(typeof(Dobavljac))]
        public IHttpActionResult GetDobavljac(int id)
        {
            Dobavljac dobavljac = _db.Dobavljac.Find(id);

            if (dobavljac == null)
                return NotFound();

            return Ok(dobavljac);
        }

        // PUT: api/Dobavljac/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDobavljac(int id, Dobavljac dobavljac)
        {
            if (id != dobavljac.DobavljacID)
                return BadRequest();

            Dobavljac d = _db.Dobavljac.Find(id);

            if (d == null)
                NotFound();

            d.Adresa = dobavljac.Adresa;
            d.BrojTelefona = dobavljac.BrojTelefona;
            d.Email = dobavljac.Email;
            d.Naziv = dobavljac.Naziv;

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

        // POST: api/Dobavljac
        [ResponseType(typeof(Dobavljac))]
        public IHttpActionResult PostDobavljac(Dobavljac dobavljac)
        {
            _db.Dobavljac.Add(dobavljac);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dobavljac.DobavljacID }, dobavljac);
        }

        // DELETE: api/Dobavljac/5
        [ResponseType(typeof(Dobavljac))]
        public IHttpActionResult DeleteDobavljac(int id)
        {
            Dobavljac dobavljac = _db.Dobavljac.Find(id);
            if (dobavljac == null)
                return NotFound();

            _db.Dobavljac.Remove(dobavljac);
            _db.SaveChanges();

            return Ok(dobavljac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();

            base.Dispose(disposing);
        }
    }
}