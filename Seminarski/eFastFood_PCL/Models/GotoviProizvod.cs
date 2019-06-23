using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_PCL.Models
{
    public class GotoviProizvod
    {

        public int GotoviProizvodID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public int KategorijaID { get; set; }
        public int VrijemePripreme { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaUmanjeno { get; set; }

        public virtual Kategorija Kategorija { get; set; }
    }
}
