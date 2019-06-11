using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using eFastFood_API.Models;
using eFastFood_UI.Util;
using eFastFood_PCL.ViewModels;

namespace eFastFood_API.Controllers
{
    public class UposlenikController : ApiController
    {
        // readonly new List<string> tokeni = new List<string>();

        private eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/Uposlenik
        [HttpGet]
        [Route("api/Uposlenik")]
        [ResponseType(typeof(List<Uposlenik>))]
        public IHttpActionResult GetUposlenik()
        {
            var list = _db.Uposlenik.ToList();
            list.ForEach(x => _db.Entry(x).Reference(c => c.Uloga).Load());

            return Ok(list);
        }

        // GET: api/Uposlenik/5
        [HttpGet]
        [Route("api/Uposlenik/{id}")]
        [ResponseType(typeof(Uposlenik))]
        public IHttpActionResult GetUposlenik(int id)
        {
            Uposlenik uposlenik = _db.Uposlenik.Find(id);
            if (uposlenik == null)
                return NotFound();

            return Ok(uposlenik);
        }

        // GET: api/Uposlenik/CheckUserName/{userName}/{id}
        [HttpGet]
        [Route("api/Uposlenik/CheckUserName/{userName}/{id}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult CheckUserName(string userName, int id = 0)
        {
            if (id == 0)
                return Ok(_db.Uposlenik.Where(x => x.UserName == userName).Count() > 0);
            else
                return Ok(_db.Uposlenik.Where(x => x.UserName == userName && x.UposlenikID != id).Count() > 0);
        }

        // GET: api/Uposlenik/CheckBrojTelefona/{telefon}/{id}
        [HttpGet]
        [Route("api/Uposlenik/CheckBrojTelefona/{telefon}/{id}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult CheckBrojTelefona(string telefon, int id = 0)
        {
            if (id == 0)
                return Ok(_db.Uposlenik.Where(x => x.BrojTelefona == telefon).Count() > 0);
            else
                return Ok(_db.Uposlenik.Where(x => x.BrojTelefona == telefon && x.UposlenikID != id).Count() > 0);
        }

        // GET: api/Uposlenik/CheckEmail/{email}/{id}
        [HttpGet]
        [Route("api/Uposlenik/CheckEmail/{email}/{id}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult CheckEmail(string email, int id = 0)
        {
            if (id == 0)
                return Ok(_db.Uposlenik.Where(x => x.Email == email).Count() > 0);
            else
                return Ok(_db.Uposlenik.Where(x => x.Email == email && x.UposlenikID != id).Count() > 0);
        }

        // PUT: api/Uposlenik/5
        [HttpPut]
        [Route("api/Uposlenik/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUposlenik(int id, Uposlenik uposlenik)
        {
            if (id != uposlenik.UposlenikID)
                return BadRequest();

            Uposlenik u = _db.Uposlenik.Find(id);

            u.Ime = uposlenik.Ime;
            u.Prezime = uposlenik.Prezime;
            u.BrojTelefona = uposlenik.BrojTelefona;
            u.UserName = uposlenik.UserName;
            u.UlogaID = uposlenik.UlogaID;
            u.Email = uposlenik.Email;
            u.Status = uposlenik.Status;
            u.LozinkaHash = uposlenik.LozinkaHash;
            u.LozinkaSalt = uposlenik.LozinkaSalt;

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

        // POST: api/Uposlenik
        [HttpPost]
        [Route("api/Uposlenik")]
        [ResponseType(typeof(Uposlenik))]
        public IHttpActionResult PostUposlenik(Uposlenik uposlenik)
        {
            try
            {
                _db.Uposlenik.Add(uposlenik);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

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
                return NotFound();

            _db.Uposlenik.Remove(uposlenik);
            _db.SaveChanges();

            return Ok(uposlenik);
        }

        //POST: api/Uposlenik/{korisnickoIme}/{lozinka}
        [HttpPost]
        [Route("api/Uposlenik/Prijava")]
        [ResponseType(typeof(Uposlenik))]
        public IHttpActionResult Prijava([FromBody]PrijavaVM k)
        {
            //var token = Guid.NewGuid();

            //tokeni.Add(token);

            Uposlenik uposlenik = _db.Uposlenik.Where(x => x.UserName == k.korisnickoIme).FirstOrDefault();
            if (uposlenik == null)
                return NotFound();
            else if (Hashing.GenerateHash(uposlenik.LozinkaSalt, k.lozinka) == uposlenik.LozinkaHash)
                return Ok(uposlenik);

            return Unauthorized();
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