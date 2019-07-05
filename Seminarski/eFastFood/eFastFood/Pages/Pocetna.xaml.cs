using eFastFood.ViewModels;
using eFastFood_PCL.Models;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pocetna : ContentPage
    {
        public Pocetna()
        {
            InitializeComponent();
            BindingContext = new PocetnaVM(this);
        }

        private void ListaProizvoda_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var gp = e.Item as GotoviProizvod;
            Navigation.PushAsync(new GotoviProizvodDetalji(gp.GotoviProizvodID, false));
        }
    }
}