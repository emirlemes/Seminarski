using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using eFastFood_PCL.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Prijava : ContentPage
    {
        APIHelper klijentiService = new APIHelper(Global.ApiUrl, Global.KlijentRoute);

        public Prijava()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void Prijava_Button_Clicked(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    PrijavaVM klijent = new PrijavaVM() { korisnickoIme = email.Text, lozinka = lozinka.Text };
                    IsBusy = true;
                    HttpResponseMessage responseK = await klijentiService.PostActionResponse("Prijava", klijent);
                    if (responseK.IsSuccessStatusCode)
                    {
                        Global.prijavnjeniKorisnik = JsonConvert.DeserializeObject<Klijent>(await responseK.Content.ReadAsStringAsync());
                        IsBusy = false;
                        await Navigation.PushModalAsync(new XamarinApp.Navigacija.MDPage());
                        await Application.Current.SavePropertiesAsync();
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