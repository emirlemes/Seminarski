using eFastFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Korpa : ContentPage
    {
        private object bc;
        public Korpa()
        {
            bc = new KorpaVM(this);
            InitializeComponent();
            BindingContext = bc;
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = sender as Entry;
            int gpId;
            int kolicina;
            if (Int32.TryParse(entry.Text, out kolicina) && Int32.TryParse(entry.MaxLength.ToString(), out gpId))
            {
                if (kolicina == 0)
                {
                    var k = Global.stavkeNarudzbe.Where(x => x.GotoviProizvodID == gpId).FirstOrDefault();
                    Global.stavkeNarudzbe.Remove(k);
                    var m = ((KorpaVM)bc).GotoviProizvodiList.Where(x => x.GotoviProizvodID == gpId).FirstOrDefault();
                    ((KorpaVM)bc).GotoviProizvodiList.Remove(m);
                }
                else
                    Global.stavkeNarudzbe.Where(x => x.GotoviProizvodID == gpId).FirstOrDefault().Kolicina = kolicina;

                ((KorpaVM)bc).PriceOfCart = Global.GetOrderPrice();
            }
        }
    }
}