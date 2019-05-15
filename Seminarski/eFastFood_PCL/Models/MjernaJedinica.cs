using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_PCL.Models
{
    public class MjernaJedinica
    {
        public MjernaJedinica()
        {
        }

        public int MjernaJedinicaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public Nullable<int> Exponent { get; set; }
    }
}
