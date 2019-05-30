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
using eFastFood_PCL.ViewModels;
using eFastFood_PCL.Util;
using System.Threading.Tasks;

namespace eFastFood_API.Controllers
{
    public class KlijentController : ApiController
    {
        private eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/Klijent
        [HttpGet]
        [Route("api/Klijent")]
        [ResponseType(typeof(List<Klijent>))]
        public IHttpActionResult GetKlijent()
        {
            var list = _db.Klijent.ToList();
            list.ForEach(x => _db.Entry(x).Reference(c => c.Uloga).Load());

            return Ok(list);
        }

        // GET: api/Klijent/5
        [ResponseType(typeof(Klijent))]
        public IHttpActionResult GetKlijent(int id)
        {
            Klijent klijent = _db.Klijent.Find(id);
            if (klijent == null)
                return NotFound();

            return Ok(klijent);
        }

        // GET: api/Klijent/CheckBrojTelefona/{telefon}
        [HttpGet]
        [Route("api/Klijent/CheckBrojTelefona/{telefon}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult CheckBrojTelefona(string telefon)
        {
            return Ok(_db.Klijent.Where(x => x.BrojTelefona == telefon).Count() > 0);
        }

        // GET: api/Klijent/CheckEmail/{email}
        [HttpGet]
        [Route("api/Klijent/CheckEmail/{email}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult CheckEmail(string email)
        {
            return Ok(_db.Klijent.Where(x => x.Email == email).Count() > 0);
        }


        // PUT: api/Klijent/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlijent(int id, Klijent klijent)
        {
            if (id != klijent.KlijentID)
                return BadRequest();

            Klijent edit = _db.Klijent.Find(klijent.KlijentID);

            if (edit == null)
                return BadRequest();

            edit = klijent;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlijentExists(id))
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

        // POST: api/Klijent
        [HttpPost]
        [Route("api/Klijent")]
        [ResponseType(typeof(Klijent))]
        public IHttpActionResult PostKlijent(Klijent klijent)
        {
            klijent.UlogaID = _db.Uloga.Where(x => x.Naziv == "Klijent").FirstOrDefault().UlogaID;
            klijent.Status = true;

            try
            {
                _db.Klijent.Add(klijent);
                _db.SaveChanges();
                return Ok(klijent);
                return Created("DefaultApi", klijent);
                return CreatedAtRoute("DefaultApi", new { id = klijent.KlijentID }, klijent);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //POST: api/Klijent/{korisnickoIme}/{lozinka}
        [HttpPost]
        [Route("api/Klijent/Prijava")]
        [ResponseType(typeof(Uposlenik))]
        public IHttpActionResult Prijava([FromBody]PrijavaVM k)
        {
            //var token = Guid.NewGuid();

            //tokeni.Add(token);

            Klijent klijent = _db.Klijent.Where(x => x.Email == k.korisnickoIme).FirstOrDefault();
            if (klijent == null)
                return NotFound();
            else if (UIHelper.GenerateHash(klijent.LozinkaSalt, k.lozinka) == klijent.LozinkaHash)
                return Ok(klijent);

            return Unauthorized();
        }

        // DELETE: api/Klijent/5
        [ResponseType(typeof(Klijent))]
        public IHttpActionResult DeleteKlijent(int id)
        {
            Klijent klijent = _db.Klijent.Find(id);
            if (klijent == null)
            {
                return NotFound();
            }

            _db.Klijent.Remove(klijent);
            _db.SaveChanges();

            return Ok(klijent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KlijentExists(int id)
        {
            return _db.Klijent.Count(e => e.KlijentID == id) > 0;
        }
    }
}