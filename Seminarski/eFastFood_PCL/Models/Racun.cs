using System;
using System.Collections.Generic;
using System.Text;

namespace eFastFood_PCL.Models
{
    public class Racun
    {

        public int RacunID { get; set; }
        public string BrojRacuna { get; set; }
        public System.DateTime DatumIzdavanja { get; set; }
        public decimal CijenaBezPDV { get; set; }
        public decimal CijenaSaPDV { get; set; }
        public string VrstaPlacanja { get; set; }
        public bool IsPlaceno { get; set; }
        public int UposlenikID { get; set; }
        public int NarudzbaID { get; set; }

        public virtual Narudzba Narudzba { get; set; }
        public virtual Uposlenik Uposlenik { get; set; }
    }
}
