using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using eFastFood_PCL.ViewModels;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Prijava : ContentPage
    {
        APIHelper klijentiService = new APIHelper(Global.ApiUrl, Global.KlijentRoute);
        APIHelper gotoviProizvodiService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);
        public int id = -1;
        public bool showContent { get => Preferences.Get("showContent", true); }
        public RelayCommand PrijavaCommand { get; }
        public Prijava()
        {
            PrijavaCommand = new RelayCommand(() => PrijavaBtn());
            InitializeComponent();
            BindingContext = this;

        }
        public async void PrijavaBtn()
        {
            if (Validate())
            {
                IsBusy = true;
                try
                {
                    HttpResponseMessage responseK;
                    if (id == -1)
                    {
                        PrijavaVM klijent = new PrijavaVM() { korisnickoIme = email.Text, lozinka = lozinka.Text };
                        responseK = await klijentiService.PostActionResponse("Prijava", klijent);
                    }
                    else
                        responseK = await klijentiService.GetResponse(id.ToString());

                    if (responseK.IsSuccessStatusCode)
                    {
                        Global.prijavnjeniKorisnik = JsonConvert.DeserializeObject<Klijent>(await responseK.Content.ReadAsStringAsync());
                        HttpResponseMessage responseGP = await gotoviProizvodiService.GetActionResponse("GotoviProizvodMobile");
                        if (responseGP.IsSuccessStatusCode)
                        {
                            Global.proizvodi = JsonConvert.DeserializeObject<List<GotoviProizvod>>(await responseGP.Content.ReadAsStringAsync());

                            Preferences.Set("User_id", Global.prijavnjeniKorisnik.KlijentID);
                            Application.Current.MainPage = new Navigacija.MDPage();
                        }
                        else
                        {
                            IsBusy = false;
                            await DisplayAlert(Messages.error, responseGP.ReasonPhrase, Messages.ok);
                        }

                        IsBusy = false;
                    }
                    else
                    {
                        IsBusy = false;
                        await DisplayAlert(Messages.error, Messages.wrong_user_or_pass, Messages.ok);
                    }
                }
                catch (Exception ex)
                {
                    IsBusy = false;
                    await DisplayAlert(Messages.error, ex.Message, Messages.ok);
                }
            }
        }

        private async void Registracija_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registracija());
        }

        private bool Validate()
        {
            if (id != -1)
                return true;
            if (emailValid() && lozinkaValid())
                return true;
            return false;
        }

        private bool lozinkaValid()
        {
            if (string.IsNullOrEmpty(lozinka.Text))
            {
                DisplayAlert(Messages.error, Messages.empty_string + " lozinka.", Messages.ok);
                return false;
            }

            return true;
        }

        private bool emailValid()
        {
            if (string.IsNullOrEmpty(email.Text))
            {
                DisplayAlert(Messages.error, Messages.empty_string + " email.", Messages.ok);
                return false;
            }
            return true;
        }
    }
}