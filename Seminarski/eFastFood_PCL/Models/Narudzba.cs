using System;
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
        public Nullable<DateTime> Datum { get; set; }
        public Nullable<decimal> UkupnaCijena { get; set; }
        public Nullable<int> KlijentID { get; set; }
        public string Status { get; set; }
    }
}
