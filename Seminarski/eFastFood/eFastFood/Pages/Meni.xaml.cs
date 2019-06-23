using eFastFood;
using eFastFood.Pages;
using eFastFood.ViewModels;
using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Meni : TabbedPage
    {
        APIHelper kategorijeService = new APIHelper(Global.ApiUrl, Global.KategorijaRoute);
        APIHelper gotoviproizvodService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);

        public Meni()
        {
            InitializeComponent();
            BindingContext = new MeniVM(this);

            //LoadTabs();
        }

        //private async void LoadTabs()
        //{
        //    HttpResponseMessage responseK = await kategorijeService.GetResponse();
        //    HttpResponseMessage responseGP = await gotoviproizvodService.GetResponse();

        //    if (responseK.IsSuccessStatusCode)
        //    {
        //        if (responseGP.IsSuccessStatusCode)
        //        {
        //            var gproizvodi = JsonConvert.DeserializeObject<List<GotoviProizvod>>(await responseGP.Content.ReadAsStringAsync());
        //            var kategorije = JsonConvert.DeserializeObject<List<Kategorija>>(await responseK.Content.ReadAsStringAsync());
        //            foreach (var item in kategorije)
        //            {
        //                //if (Device.RuntimePlatform == Device.Android)
        //                //{
        //                PocetnaVM vm = new PocetnaVM();
        //                vm.Title = item.Naziv;
        //                vm.GotoviProizvodiList = gproizvodi.Where(x => x.KategorijaID == item.KategorijaID).ToList();
        //                Children.Add(new MeniItem() { BindingContext = vm });
        //                //}
        //            }

        //        }
        //        else
        //            await DisplayAlert(Messages.error, responseGP.ReasonPhrase, Messages.ok);
        //    }
        //    else
        //        await DisplayAlert(Messages.error, responseK.ReasonPhrase, Messages.ok);
        //}

        //protected async override void OnAppearing()
        //{
        //    try
        //    {




        //        base.OnAppearing();

        //    }
        //    catch (Exception k)
        //    {
        //        await DisplayAlert(Messages.error, k.Message, Messages.ok);
        //    }
        //}
    }
}