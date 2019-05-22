using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_PCL.Models
{
    public partial class NarudzbaStavka
    {
        public int NarudzbaStavkaID { get; set; }
        public int Kolicina { get; set; }
        public int NarudzbaID { get; set; }
        public int GotoviProizvodID { get; set; }

        public virtual GotoviProizvod GotoviProizvod { get; set; }
        public virtual Narudzba Narudzba { get; set; }
    }
}
