using System;
using System.Collections.Generic;
using System.Text;

namespace eFastFood_PCL.ViewModel
{
    public class NarudzbeIzvjestajVM
    {
        public int NarudzbaID { get; set; }
        public string Narucio { get; set; }
        public decimal Cijena { get; set; }
        public DateTime Datum { get; set; }
        public string VrstaNarudzbe { get; set; }
        public int KlijentID { get; set; }
    }
}
