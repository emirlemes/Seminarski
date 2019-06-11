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
    public class ProizvodController : ApiController
    {
        private eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/Proizvod
        public IHttpActionResult GetProizvod()
        {
            return Ok(_db.Proizvod.ToList());
        }

        // GET: api/Proizvod/5
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult GetProizvod(int id)
        {
            Proizvod proizvod = _db.Proizvod.Find(id);

            if (proizvod == null)
                return NotFound();

            return Ok(proizvod);
        }

        // PUT: api/Proizvod/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProizvod(int id, Proizvod proizvod)
        {
            if (id != proizvod.ProizvodID)
                return BadRequest();

            Proizvod p = _db.Proizvod.Find(id);

            p.Naziv = proizvod.Naziv;
            p.Opis = proizvod.Opis;
            p.DobavljacID = proizvod.DobavljacID;
            p.DonjaGranica = proizvod.DonjaGranica;
            p.Kolicina = proizvod.Kolicina;
            p.MjernaJedinicaID = proizvod.MjernaJedinicaID;

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

        // POST: api/Proizvod
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult PostProizvod(Proizvod proizvod)
        {
            try
            {
                _db.Proizvod.Add(proizvod);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = proizvod.ProizvodID }, proizvod);
        }



        // DELETE: api/Proizvod/5
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult DeleteProizvod(int id)
        {
            Proizvod proizvod = _db.Proizvod.Find(id);
            if (proizvod == null)
                return NotFound();

            try
            {
                _db.Proizvod.Remove(proizvod);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(proizvod);
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