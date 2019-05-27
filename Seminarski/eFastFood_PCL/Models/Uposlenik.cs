using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_PCL.Models
{
    public class Uposlenik
    {
        public int UposlenikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string UserName { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public bool Status { get; set; }
        public int UlogaID { get; set; }

        public virtual Uloga Uloga { get; set; }
    }
}
