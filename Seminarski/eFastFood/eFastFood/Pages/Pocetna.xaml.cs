using eFastFood;
using eFastFood.ViewModels;
using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pocetna : ContentPage
    {
        APIHelper gotoviProizvidiService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);

        public Pocetna()
        {
            InitializeComponent();
            BindingContext = new PocetnaVM();
            LoadProizvode();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Cart_Clicked(object sender, EventArgs e)
        {
            var page = (Page)Activator.CreateInstance(typeof(Korpa));
            page.Title = "Korpa";
            await Navigation.PushAsync(page);
        }

        private async void LoadProizvode()
        {
            IsBusy = true;

            if (Global.proizvodi == null)
            {
                HttpResponseMessage responseGP = await gotoviProizvidiService.GetResponse();

                if (responseGP.IsSuccessStatusCode)
                {
                    var gplista = JsonConvert.DeserializeObject<List<GotoviProizvod>>(await responseGP.Content.ReadAsStringAsync());
                    Global.proizvodi = gplista;
                }
                else
                {
                    IsBusy = false;
                    await DisplayAlert(Messages.error, responseGP.ReasonPhrase, Messages.ok);
                }
            }
        }

        private void AddToCart_Tapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                GotoviProizvod gp = e.Item as GotoviProizvod;
                if (Global.trenutnaNarudzba == null)
                    Global.trenutnaNarudzba = new Narudzba();
                if (Global.trenutnaNarudzba.NarudzbaStavka == null)
                    Global.trenutnaNarudzba.NarudzbaStavka = new List<NarudzbaStavka>();

                Global.trenutnaNarudzba.NarudzbaStavka.Add(new NarudzbaStavka()
                {
                    GotoviProizvodID = gp.GotoviProizvodID,
                    Kolicina = 1,
                }) ;
            }
            DisplayAlert("Radi", "Radi", "OK");
        }

        private void OpisModal_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Radi", "Radi", "OK");
        }
    }
}