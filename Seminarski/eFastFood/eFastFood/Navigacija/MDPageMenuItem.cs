using eFastFood.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eFastFood.Navigacija
{

    public class MDPageMenuItem
    {
        public MDPageMenuItem()
        {
            TargetType = typeof(Pocetna);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageSource { get; set; }

        public Type TargetType { get; set; }
    }
}