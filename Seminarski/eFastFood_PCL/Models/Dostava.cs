using System;


namespace eFastFood_PCL.Models
{
    public class Dostava
    {
        public int DostavaID { get; set; }
        public int NarudzbaID { get; set; }
        public Nullable<int> UposlenikID { get; set; }
        public string AdresaDostave { get; set; }
        public Nullable<DateTime> VrijemePreuzimanja { get; set; }
        public Nullable<DateTime> VrijemeDostavljanja { get; set; }

        public virtual Narudzba Narudzba { get; set; }
        public virtual Uposlenik Uposlenik { get; set; }
    }
}
