﻿using eFastFood_API.Models;
using eFastFood_PCL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace eFastFood_API.Controllers
{
    public class NarudzbaController : ApiController
    {
        private readonly eFastFoodEntitie _db = new eFastFoodEntitie();

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
                return NotFound();

            return Ok(narudzba);
        }

        // GET: api/Narudzba/BrojNarudzbiAll
        [HttpGet]
        [ResponseType(typeof(Dictionary<int, int>))]
        [Route("api/Narudzba/BrojNarudzbiAll")]
        public IHttpActionResult BrojNarudzbiAll()
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            var klijenti = _db.Klijent.ToList();

            foreach (var x in klijenti)
                keyValuePairs.Add(x.KlijentID, (int?)_db.Narudzba.Count(c => x.KlijentID == c.KlijentID) ?? 0);

            return Ok(keyValuePairs);
        }

        // GET: api/Narudzba/GetNoveNarudzbe
        [HttpGet]
        [ResponseType(typeof(List<Narudzba>))]
        [Route("api/Narudzba/GetNoveNarudzbe")]
        public IHttpActionResult GetNoveNarudzbe()
        {
            var list = _db.Narudzba.Where(x => x.Status == nameof(StatusNarudzbe.Nova)).ToList();
            list.ForEach(x => _db.Entry(x).Reference(c => c.Klijent).Load());

            return Ok(list);
        }

        // GET: api/Narudzba/GetUPripremiNarudzbe
        [HttpGet]
        [ResponseType(typeof(List<Narudzba>))]
        [Route("api/Narudzba/GetUPripremiNarudzbe")]
        public IHttpActionResult GetUPripremiNarudzbe()
        {
            var list = _db.Narudzba.Where(x => x.Status == nameof(StatusNarudzbe.Priprema)).ToList();
            list.ForEach(x => _db.Entry(x).Reference(c => c.Klijent).Load());

            return Ok(list);
        }

        // GET: api/Narudzba/GetZavrseneNarudzbe
        [HttpGet]
        [ResponseType(typeof(List<Narudzba>))]
        [Route("api/Narudzba/GetZavrseneNarudzbe")]
        public IHttpActionResult GetZavrseneNarudzbe()
        {
            var list = _db.Narudzba.Where(x => x.Status == nameof(StatusNarudzbe.Zavrsena)).ToList();
            list.ForEach(x => _db.Entry(x).Reference(c => c.Klijent).Load());

            return Ok(list);
        }

        // GET: api/Narudzba/GetOdbijeneNarudzbe
        [HttpGet]
        [ResponseType(typeof(List<Narudzba>))]
        [Route("api/Narudzba/GetOdbijeneNarudzbe")]
        public IHttpActionResult GetOdbijeneNarudzbe()
        {
            var list = _db.Narudzba.Where(x => x.Status == nameof(StatusNarudzbe.Odbijena)).ToList();
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

        // GET: api/Narudzba/UserOrders/{id}
        [HttpGet]
        [ResponseType(typeof(List<int>))]
        [Route("api/Narudzba/UserOrders/{id}")]
        public IHttpActionResult UserOrders(int id)
        {
            List<int> orders = _db.Narudzba.Where(x => x.KlijentID == id).Select(c => c.NarudzbaID).ToList();

            List<int> gp = _db.NarudzbaStavka.Where(x => orders.Contains(x.NarudzbaID)).Select(c => c.GotoviProizvodID).Distinct().ToList();

            return Ok(gp);
        }

        // GET: api/Narudzba/Izvjestaj/{datumOd}/{datumDo}/{userId?}
        [HttpGet]
        [ResponseType(typeof(List<NarudzbeIzvjestajVM>))]
        [Route("api/Narudzba/Izvjestaj/{datumOd}/{datumDo}/{userId?}")]
        public IHttpActionResult Izvjestaj(DateTime datumOd, DateTime datumDo, int userId = 0)
        {
            List<NarudzbeIzvjestajVM> vs = _db.Narudzba.Where(x => x.Datum > datumOd && x.Datum < datumDo)
                .Select(x => new NarudzbeIzvjestajVM()
                {
                    Cijena = x.UkupnaCijena,
                    Datum = x.Datum,
                    NarudzbaID = x.NarudzbaID,
                    VrstaNarudzbe = _db.Dostava.Where(c => c.NarudzbaID == x.NarudzbaID).FirstOrDefault() != null ? "Dostava" : "Preuzimanje",
                    Narucio = x.Klijent.Ime + " " + x.Klijent.Prezime,
                    KlijentID = x.KlijentID
                }).ToList();

            if (userId != 0)
                vs = vs.Where(x => x.KlijentID == userId).ToList();

            return Ok(vs);
        }

        //PUT: api/Narudzba/PrebaciUPripremu/{id}
        [HttpGet]
        [ResponseType(typeof(void))]
        [Route("api/Narudzba/PrebaciUPripremu/{id}")]
        public IHttpActionResult PrebaciUPripremu(int id)
        {
            string nemaDovoljnoProizvoda = String.Empty;

            Narudzba narudzba = _db.Narudzba.Where(x => x.NarudzbaID == id).FirstOrDefault();
            Dictionary<Proizvod, decimal> oduzetiKolicinu = new Dictionary<Proizvod, decimal>();
            if (narudzba != null)
            {
                _db.Entry(narudzba).Collection(x => x.NarudzbaStavka).Load();
                foreach (var NS in narudzba.NarudzbaStavka)
                {
                    var SGP = _db.GPProizvod.Where(x => x.GotoviProizvodID == NS.GotoviProizvodID).ToList();
                    foreach (var GPP in SGP)
                    {
                        var mj = _db.MjernaJedinica.Where(c => c.MjernaJedinicaID == GPP.MjernaJedinicaID).FirstOrDefault();

                        decimal utrosak = (decimal)((double)GPP.KolicinaUtroska * Math.Pow(10, mj.Exponent) * NS.Kolicina);

                        Proizvod k = _db.Proizvod.Find(GPP.ProizvodID);

                        oduzetiKolicinu.Add(k, utrosak);
                        if (utrosak >= k.Kolicina)
                            nemaDovoljnoProizvoda += k.Naziv + " za pripremu " + _db.GotoviProizvod.Find(GPP.GotoviProizvodID).Naziv;
                    }
                }
                if (String.IsNullOrEmpty(nemaDovoljnoProizvoda))
                {
                    foreach (var item in oduzetiKolicinu)
                        item.Key.Kolicina -= item.Value;

                    narudzba.Status = nameof(StatusNarudzbe.Priprema);
                    _db.SaveChanges();
                    return Ok();
                }
                else
                {
                    nemaDovoljnoProizvoda = nemaDovoljnoProizvoda.Insert(0, "Nema dovoljno: ");
                    return BadRequest(nemaDovoljnoProizvoda);
                }
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
                n.Status = nameof(StatusNarudzbe.Zavrsena);
                _db.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
        }

        //PUT: api/Narudzba/PrebaciUOdbijene/{id}
        [HttpGet]
        [ResponseType(typeof(void))]
        [Route("api/Narudzba/PrebaciUOdbijene/{id}")]
        public IHttpActionResult PrebaciUOdbijene(int id)
        {
            Narudzba n = _db.Narudzba.Where(x => x.NarudzbaID == id).FirstOrDefault();
            if (n != null)
            {
                n.Status = nameof(StatusNarudzbe.Odbijena);
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
            if (id != narudzba.NarudzbaID)
                return BadRequest();

            Narudzba n = _db.Narudzba.Find(id);

            if (n == null)
                return BadRequest();

            n.Datum = narudzba.Datum;
            n.KlijentID = narudzba.KlijentID;
            n.Status = narudzba.Status;
            n.UkupnaCijena = narudzba.UkupnaCijena;
            n.VrstaNarudzbe = narudzba.VrstaNarudzbe;

            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Narudzba
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult PostNarudzba(Narudzba narudzba)
        {
            _db.Narudzba.Add(narudzba);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = narudzba.NarudzbaID }, narudzba);
        }

        // POST: api/Narudzba/MobileOrder

        [HttpPost]
        [Route("api/Narudzba/MobileOrder")]
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult MobileOrder(Narudzba n)
        {
            Narudzba narudzba = new Narudzba()
            {
                Datum = n.Datum,
                KlijentID = n.KlijentID,
                Status = n.Status,
                UkupnaCijena = n.UkupnaCijena,
                VrstaNarudzbe = n.VrstaNarudzbe,
            };
            _db.Narudzba.Add(narudzba);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


            foreach (var item in n.NarudzbaStavka)
            {
                _db.NarudzbaStavka.Add(new NarudzbaStavka()
                {
                    GotoviProizvodID = item.GotoviProizvodID,
                    Kolicina = item.Kolicina,
                    NarudzbaID = narudzba.NarudzbaID,
                });
            }

            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(narudzba);
        }

        // DELETE: api/Narudzba/5
        [ResponseType(typeof(Narudzba))]
        public IHttpActionResult DeleteNarudzba(int id)
        {
            Narudzba narudzba = _db.Narudzba.Find(id);
            if (narudzba == null)
                return NotFound();
            try
            {
                _db.Narudzba.Remove(narudzba);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

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
    }
}
