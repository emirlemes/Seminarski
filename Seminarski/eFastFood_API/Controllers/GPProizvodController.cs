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
    public class GPProizvodController : ApiController
    {
        private readonly eFastFoodEntitie _db = new eFastFoodEntitie();


        // GET: api/GPProizvod/SastojciByGPID/5
        [HttpGet]
        [ResponseType(typeof(List<GPProizvod>))]
        [Route("api/GPProizvod/SastojciByGPID/{id}")]
        public IHttpActionResult SastojciByGPID(int id)
        {
            return Ok(_db.GPProizvod.Where(x => x.GotoviProizvodID == id).ToList());
        }
        [HttpGet]
        [ResponseType(typeof(List<string>))]
        [Route("api/GPProizvod/ProizvodiByGID/{id}")]
        public IHttpActionResult ProizvodiByGID(int id)
        {
            List<int> proizvodi = _db.GPProizvod.Where(x => x.GotoviProizvodID == id).Select(c => c.ProizvodID).ToList();
            List<string> lista = _db.Proizvod.Where(x => proizvodi.Contains(x.ProizvodID)).Select(x => x.Naziv).ToList();
            return Ok(lista);
        }

        // PUT: api/GPProizvod/GPProizvodListEdit/
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/GPProizvod/GPProizvodListEdit/{id}")]
        public IHttpActionResult GPProizvodListEdit(int id, List<GPProizvod> list)
        {
            var a = _db.GPProizvod.Where(x => id == x.GotoviProizvodID).ToList();
            if (a == null)
                return BadRequest();

            a.ForEach(x => _db.GPProizvod.Remove(x));

            list.ForEach(x =>
            _db.GPProizvod.Add(new GPProizvod()
            {
                GotoviProizvodID = x.GotoviProizvodID,
                ProizvodID = x.ProizvodID,
                KolicinaUtroska = x.KolicinaUtroska,
                MjernaJedinicaID = x.MjernaJedinicaID
            }));

            return StatusCode(HttpStatusCode.NoContent);
        }

        //POST: api/GPProizvod
        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("api/GPProizvod/GPProizvodList")]
        public IHttpActionResult GPProizvodList(List<GPProizvod> gPProizvod)
        {
            if (gPProizvod == null || !gPProizvod.Any())
                return BadRequest();

            foreach (var item in gPProizvod)
                _db.GPProizvod.Add(item);

            _db.SaveChanges();

            return Ok();
        }

        // DELETE: api/GPProizvod/5
        //[ResponseType(typeof(GPProizvod))]
        //public IHttpActionResult DeleteGPProizvod(int id)
        //{
        //    GPProizvod gPProizvod = _db.GPProizvod.Find(id);
        //    if (gPProizvod == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.GPProizvod.Remove(gPProizvod);
        //    _db.SaveChanges();

        //    return Ok(gPProizvod);
        //}

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