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
using RecomandationSystem;

namespace eFastFood_API.Controllers
{
    public class GotoviProizvodController : ApiController
    {
        private readonly eFastFoodEntitie _db = new eFastFoodEntitie();

        // GET: api/GotoviProizvod
        public IHttpActionResult GetGotoviProizvod()
        {
            return Ok(_db.GotoviProizvod.ToList());
        }

        // GET: api/GotoviProizvod/GotoviProizvodMobile
        [HttpGet]
        [ResponseType(typeof(List<GotoviProizvod>))]
        [Route("api/GotoviProizvod/GotoviProizvodMobile")]
        public IHttpActionResult GotoviProizvodMobile()
        {
            var gp = _db.GotoviProizvod.Where(x => x.VidljivostMobile == true).ToList();
            gp.ForEach(x => _db.Entry(x).Reference(c => c.Kategorija).Load());
            gp.ForEach(x => { x.Kategorija.GotoviProizvod = null; x.Slika = null; });
            return Ok(gp);
        }

        // GET: api/GotoviProizvod/Preporuka/{userId}
        [HttpGet]
        [ResponseType(typeof(List<GotoviProizvod>))]
        [Route("api/GotoviProizvod/Preporuka/{userId}")]
        public IHttpActionResult Preporuka(int userId)
        {
            RecommenderSystem rc = new RecommenderSystem();

            List<int> p = rc.GetRecomended(userId).Select(x => x.Key).ToList();
            foreach (var proizvodId in p)
                if (!_db.GotoviProizvod.Find(proizvodId).VidljivostMobile)
                    p.Remove(proizvodId);

            return Ok(p);
        }

        // GET: api/GotoviProizvod/5
        [ResponseType(typeof(GotoviProizvod))]
        public IHttpActionResult GetGotoviProizvod(int id)
        {
            GotoviProizvod gotoviProizvod = _db.GotoviProizvod.Find(id);
            if (gotoviProizvod == null)
                return NotFound();

            return Ok(gotoviProizvod);
        }

        // PUT: api/GotoviProizvod/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGotoviProizvod(int id, GotoviProizvod gotoviProizvod)
        {

            if (id != gotoviProizvod.GotoviProizvodID)
                return BadRequest();

            GotoviProizvod gp = _db.GotoviProizvod.Find(id);

            if (gp == null)
                return BadRequest();

            gp.KategorijaID = gotoviProizvod.KategorijaID;
            gp.GotoviProizvodID = gotoviProizvod.GotoviProizvodID;
            gp.VrijemePripreme = gotoviProizvod.VrijemePripreme;
            gp.Slika = gotoviProizvod.Slika;
            gp.SlikaUmanjeno = gotoviProizvod.SlikaUmanjeno;
            gp.Opis = gotoviProizvod.Opis;
            gp.Naziv = gotoviProizvod.Naziv;

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

        // POST: api/GotoviProizvod
        [ResponseType(typeof(GotoviProizvod))]
        public IHttpActionResult PostGotoviProizvod(GotoviProizvod gotoviProizvod)
        {
            try
            {
                _db.GotoviProizvod.Add(gotoviProizvod);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = gotoviProizvod.GotoviProizvodID }, gotoviProizvod);
        }

        // DELETE: api/GotoviProizvod/5
        [ResponseType(typeof(GotoviProizvod))]
        public IHttpActionResult DeleteGotoviProizvod(int id)
        {
            GotoviProizvod gotoviProizvod = _db.GotoviProizvod.Find(id);
            if (gotoviProizvod == null)
            {
                return NotFound();
            }

            _db.GotoviProizvod.Remove(gotoviProizvod);
            _db.SaveChanges();

            return Ok(gotoviProizvod);
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