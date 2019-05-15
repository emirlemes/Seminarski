using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_PCL.Models
{
    public class Proizvod
    {
        public Proizvod()
        {
        }

        public int ProizvodID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Kolicina { get; set; }
        public decimal DonjaGranica { get; set; }
        public Nullable<int> MjernaJedinicaID { get; set; }
        public Nullable<int> DobavljacID { get; set; }

        public virtual Dobavljac Dobavljac { get; set; }
        public virtual MjernaJedinica MjernaJedinica { get; set; }
    }
}
