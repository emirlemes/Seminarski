using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_PCL.Models
{
    public class GPProizvod
    {
        public int GotoviProizvodID { get; set; }
        public int ProizvodID { get; set; }
        public Nullable<decimal> KolicinaUtroska { get; set; }
        public int MjernaJedinicaID { get; set; }
    }
}
