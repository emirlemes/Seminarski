using eFastFood_PCL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFastFood.ViewModels
{
    public class PocetnaVM
    {
        public string Title { get; set; }
        public List<GotoviProizvod> gpList { get; set; }
    }
}
