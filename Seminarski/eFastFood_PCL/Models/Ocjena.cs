using System;
using System.Collections.Generic;
using System.Text;

namespace eFastFood_PCL.Models
{
    public class Ocjena
    {
        public int OcjenaID { get; set; }
        public int NumerickaOcjena { get; set; }
        public string Komentar { get; set; }
        public int GotoviProizvodID { get; set; }
        public int KlijentID { get; set; }

        public virtual GotoviProizvod GotoviProizvod { get; set; }
        public virtual Klijent Klijent { get; set; }
    }
}
