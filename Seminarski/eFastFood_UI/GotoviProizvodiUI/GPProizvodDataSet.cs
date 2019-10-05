using System.Collections.Generic;

namespace eFastFood_PCL.Helpers
{
    public class GPProizvodDataSet
    {
        public int ProizvodID { get; set; }
        public bool Dodaj { get; set; }
        public string ProizvodNaziv { get; set; }
        public decimal Kolicina { get; set; }
        public List<ComboItem> MjernaJedinicaList { get; set; }
    }
}
