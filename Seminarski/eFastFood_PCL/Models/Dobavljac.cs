using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_PCL.Models
{
    public class Dobavljac
    {
        public Dobavljac()
        {
        }

        public int DobavljacID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
    }
}
