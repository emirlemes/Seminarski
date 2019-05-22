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
    public class NarudzbaController : ApiController
    {
        private eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/Narudzba
        public IHttpActionResult GetNarudzba()
        {
            return Ok(_db.Narudzba.ToList());
        }

        // GET: api/Narudzba/5
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult GetNarudzba(int id)
        {
            Narudzba narudzba = _db.Narudzba.Find(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            return Ok(narudzba);
        }
        // GET: api/Narudzba/BrojNarudzbiAll
        [HttpGet]
        [ResponseType(typeof(Dictionary<int, int>))]
        [Route("api/Narudzba/BrojNarudzbiAll")]
        public IHttpActionResult BrojNarudzbiAll()
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            _db.esp_BrojNarudzbiAll().ToList().ForEach(x => keyValuePairs.Add(x.KlijentID ?? 0, x.BrojNarudzbi ?? 0));
            return Ok(keyValuePairs);
        }

        // GET: api/Narudzba/GetNoveNarudzbe
        [HttpGet]
        [ResponseType(typeof(List<Narudzba>))]
        [Route("api/Narudzba/GetNoveNarudzbe")]
        public IHttpActionResult GetNoveNarudzbe()
        {
            var list = _db.Narudzba.Where(x => x.Status == "Nova").ToList();
            list.ForEach(x => _db.Entry(x).Reference(c => c.Klijent).Load());

            return Ok(list);
        }

        // GET: api/Narudzba/GetUPripremiNarudzbe
        [HttpGet]
        [ResponseType(typeof(List<Narudzba>))]
        [Route("api/Narudzba/GetUPripremiNarudzbe")]
        public IHttpActionResult GetUPripremiNarudzbe()
        {
            var list = _db.Narudzba.Where(x => x.Status == "Priprema").ToList();
            list.ForEach(x => _db.Entry(x).Reference(c => c.Klijent).Load());

            return Ok(list);
        }

        // GET: api/Narudzba/GetZavrseneNarudzbe
        [HttpGet]
        [ResponseType(typeof(List<Narudzba>))]
        [Route("api/Narudzba/GetZavrseneNarudzbe")]
        public IHttpActionResult GetZavrseneNarudzbe()
        {
            var list = _db.Narudzba.Where(x => x.Status == "Zavrsena").ToList();
            list.ForEach(x => _db.Entry(x).Reference(c => c.Klijent).Load());

            return Ok(list);
        }
        // GET: api/Narudzba/GetStavkeNarudzbe/{id}
        [HttpGet]
        [ResponseType(typeof(List<NarudzbaStavka>))]
        [Route("api/Narudzba/GetStavkeNarudzbe/{id}")]
        public IHttpActionResult GetStavkeNarudzbe(int id)
        {
            List<NarudzbaStavka> list = _db.NarudzbaStavka.Where(x => x.NarudzbaID == id).ToList();
            list.ForEach(x => _db.Entry(x).Reference(c => c.GotoviProizvod).Load());
            return Ok(list);
        }

        //PUT: api/Narudzba/PrebaciUPripremu/{id}
        [HttpGet]
        [ResponseType(typeof(void))]
        [Route("api/Narudzba/PrebaciUPripremu/{id}")]
        public IHttpActionResult PrebaciUPripremu(int id)
        {
            Narudzba narudzba = _db.Narudzba.Where(x => x.NarudzbaID == id).FirstOrDefault();
            if (narudzba != null)
            {
                narudzba.Status = "Priprema";
                _db.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
        }

        //PUT: api/Narudzba/PrebaciUZavrsi/{id}
        [HttpGet]
        [ResponseType(typeof(void))]
        [Route("api/Narudzba/PrebaciUZavrsi/{id}")]
        public IHttpActionResult PrebaciUZavrsi(int id)
        {
            Narudzba n = _db.Narudzba.Where(x => x.NarudzbaID == id).FirstOrDefault();
            if (n != null)
            {
                n.Status = "Zavrsena";
                _db.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
        }

        // PUT: api/Narudzba/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNarudzba(int id, Narudzba narudzba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != narudzba.NarudzbaID)
            {
                return BadRequest();
            }

            _db.Entry(narudzba).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NarudzbaExists(id))
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

        // POST: api/Narudzba
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult PostNarudzba(Narudzba narudzba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Narudzba.Add(narudzba);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = narudzba.NarudzbaID }, narudzba);
        }

        // DELETE: api/Narudzba/5
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult DeleteNarudzba(int id)
        {
            Narudzba narudzba = _db.Narudzba.Find(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            _db.Narudzba.Remove(narudzba);
            _db.SaveChanges();

            return Ok(narudzba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NarudzbaExists(int id)
        {
            return _db.Narudzba.Count(e => e.NarudzbaID == id) > 0;
        }
    }
}