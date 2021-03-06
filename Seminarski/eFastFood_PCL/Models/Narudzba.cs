﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_PCL.Models
{
    public class Narudzba
    {
        public int NarudzbaID { get; set; }
        public string VrstaNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public decimal UkupnaCijena { get; set; }
        public int KlijentID { get; set; }
        public string Status { get; set; }

        public Klijent Klijent { get; set; }
        public ICollection<NarudzbaStavka> NarudzbaStavka { get; set; }
    }
}
