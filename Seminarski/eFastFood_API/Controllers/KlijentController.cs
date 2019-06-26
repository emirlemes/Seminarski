using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using eFastFood_API.Models;
using eFastFood_PCL.ViewModels;
using eFastFood_PCL.Util;

namespace eFastFood_API.Controllers
{
    public class KlijentController : ApiController
    {
        private readonly eFastFoodEntitie _db = new eFastFoodEntitie();

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

        // GET: api/Klijent/CheckBrojTelefona/{telefon}/{id}
        [HttpGet]
        [Route("api/Klijent/CheckBrojTelefona/{telefon}/{id}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult CheckBrojTelefona(string telefon, int id = 0) =>
             id == 0 ? Ok(_db.Klijent.Where(x => x.BrojTelefona == telefon).Count() > 0) : Ok(_db.Klijent.Where(x => x.BrojTelefona == telefon && x.KlijentID != id).Count() > 0);

        // GET: api/Klijent/CheckEmail/{email}/{id}
        [HttpGet]
        [Route("api/Klijent/CheckEmail/{email}/{id}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult CheckEmail(string email, int id = 0) =>
            id == 0 ? Ok(_db.Klijent.Where(x => x.Email == email).Count() > 0) : Ok(_db.Klijent.Where(x => x.BrojTelefona == email && x.KlijentID != id).Count() > 0);

        // PUT: api/Klijent/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlijent(int id, [FromBody]Klijent klijent)
        {
            if (id != klijent.KlijentID)
                return BadRequest();

            Klijent k = _db.Klijent.Find(klijent.KlijentID);

            if (k == null)
                return BadRequest();

            k.Adresa = klijent.Adresa;
            k.BrojTelefona = klijent.BrojTelefona;
            k.Email = klijent.Email;
            k.Ime = klijent.Ime;
            k.UlogaID = klijent.UlogaID;
            k.Prezime = klijent.Prezime;
            k.Status = klijent.Status;
            k.LozinkaHash = klijent.LozinkaHash;
            k.LozinkaSalt = klijent.LozinkaSalt;

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
                return NotFound();

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
    }
}