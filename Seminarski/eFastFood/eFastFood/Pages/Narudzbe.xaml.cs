using eFastFood.ViewModels;
using eFastFood_PCL.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Narudzbe : ContentPage
    {
        public Narudzbe()
        {
            InitializeComponent();
            BindingContext = new NarudzbeVM(this);
        }

        private void Item_Tapped(object sender, ItemTappedEventArgs e)
        {
            var gp = e.Item as GotoviProizvod;
            this.Navigation.PushAsync(new GotoviProizvodDetalji(gp.GotoviProizvodID, true));
        }
    }
}
