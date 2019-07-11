using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using eFastFood_API.Models;
using eFastFood_API.Util;

namespace eFastFood_API.Controllers
{
    public class ProizvodController : ApiController
    {
        private readonly eFastFoodEntitie _db = new eFastFoodEntitie();

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
            _db.Entry(proizvod).Reference(x => x.MjernaJedinica).Load();
            if (proizvod == null)
                return NotFound();

            return Ok(proizvod);
        }

        // GET: api/Proizvod/ProizvodiZaNarucit
        [HttpGet]
        [Route("api/Proizvod/ProizvodiZaNarucit")]
        [ResponseType(typeof(List<string>))]
        public IHttpActionResult ProizvodiZaNarucit()
        {
            var listaProizvoda = _db.Proizvod.Where(x => x.Kolicina < x.DonjaGranica).Select(c => c.Naziv).ToList();
            if (listaProizvoda.Count == 0)
                return NotFound();
            else
                return Ok(listaProizvoda);
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

        [HttpPost]
        [Route("api/Proizvod/NaruciProizvod")]
        public IHttpActionResult NaruciProizvod([FromBody]string order)
        {
            int id = int.Parse(order.Split(':')[0]);
            string kolicina = order.Split(':')[1];

            var proizvod = _db.Proizvod.Where(x => x.ProizvodID == id).FirstOrDefault();
            _db.Entry(proizvod).Reference(x => x.Dobavljac).Load();
            _db.Entry(proizvod).Reference(x => x.MjernaJedinica).Load();

            string email = proizvod.Dobavljac.Email;

            if (email == null)
                return BadRequest("Email Dobavljača greška.");
            else
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                path += "EmailTemplates\\email.html";
                string Body = System.IO.File.ReadAllText(path);
                Body = Body.Replace("#datum#", DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm"));
                Body = Body.Replace("#proizvod#", proizvod.Naziv);
                Body = Body.Replace("#kolicina#", kolicina + "  " + proizvod.MjernaJedinica.Naziv);

                EmailSender.SendEmail(Body, email);
            }

            return Ok();
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