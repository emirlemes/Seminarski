//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eFastFood_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GotoviProizvod
    {
        public int GotoviProizvodID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public Nullable<int> VrijemePripreme { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaUmanjeno { get; set; }
        public int KategorijaID { get; set; }
    
        public virtual Kategorija Kategorija { get; set; }
    }
}