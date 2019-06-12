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
        public Pocetna()
        {
            InitializeComponent();
            BindingContext = new PocetnaVM();
        }

        //private async void Cart_Clicked(object sender, EventArgs e)
        //{
        //    var page = (Page)Activator.CreateInstance(typeof(Korpa));
        //    page.Title = "Korpa";
        //    await Navigation.PushAsync(page);
        //}

        //private void AddToCart_Tapped(object sender, EventArgs e)
        //{
        //    var args = (TappedEventArgs)e;
        //    var myObject = args.Parameter;

        //    if (myObject != null)
        //    {
        //        if (Global.trenutnaNarudzba == null)
        //            Global.trenutnaNarudzba = new Narudzba();
        //        if (Global.trenutnaNarudzba.NarudzbaStavka == null)
        //            Global.trenutnaNarudzba.NarudzbaStavka = new List<NarudzbaStavka>();

        //        //Global.trenutnaNarudzba.NarudzbaStavka.Add(new NarudzbaStavka()
        //        //{
        //        //    GotoviProizvodID = gp.GotoviProizvodID,
        //        //    Kolicina = 1,
        //        //});
        //    }
        //    DisplayAlert("Radi", "Radi", "OK");
        //}

        //private void OpisModal_Tapped(object sender, EventArgs e)
        //{
        //    DisplayAlert("Radi", "Radi", "OK");
        //}
    }
}