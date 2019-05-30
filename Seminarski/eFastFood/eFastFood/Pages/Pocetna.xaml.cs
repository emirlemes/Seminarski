using eFastFood;
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
        }

        protected override void OnAppearing()
        {
            LoadProizvode();
            base.OnAppearing();
        }

        private async void Cart_Clicked(object sender, EventArgs e)
        {
            var page = (Page)Activator.CreateInstance(typeof(Korpa));
            page.Title = "Korpa";
            await this.Navigation.PushAsync(page);
        }

        private async void LoadProizvode()
        {
            HttpResponseMessage responseGP = await gotoviProizvidiService.GetResponse();

            if (responseGP.IsSuccessStatusCode)
            {
                var jsnoObject = await responseGP.Content.ReadAsStringAsync();
                List<GotoviProizvod> listaProizvoda = JsonConvert.DeserializeObject<List<GotoviProizvod>>(jsnoObject);

                gpList.ItemsSource = listaProizvoda;
            }
        }

        private void AddToCart_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Radi", "Radi", "OK");
        }
    }
}