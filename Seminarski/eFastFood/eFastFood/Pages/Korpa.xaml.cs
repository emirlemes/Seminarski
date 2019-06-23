using eFastFood;
using eFastFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Korpa : ContentPage
    {
        public Korpa()
        {
            InitializeComponent();
            BindingContext = new KorpaVM(this);
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = sender as Entry;
            int gpId;
            int kolicina;
            if (Int32.TryParse(entry.Text, out kolicina) && Int32.TryParse(entry.MaxLength.ToString(), out gpId))
            {
                if (kolicina == 0)
                    DisplayAlert(Messages.error, Messages.quantity_zero, Messages.ok);
                else
                    Global.stavkeNarudzbe.Where(x => x.GotoviProizvodID == gpId).FirstOrDefault().Kolicina = kolicina;
            }

        }
    }
}