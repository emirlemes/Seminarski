using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
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
    public partial class Registracija : ContentPage
    {
        APIHelper klijentService = new APIHelper(Global.ApiUrl, Global.KlijentRoute);

        public Registracija()
        {
            InitializeComponent();
        }

        private async void Registruj_Clicked(object sender, EventArgs e)
        {
            if (await Validacija())
            {
                Klijent klijentRegstracija = new Klijent()
                {
                    Adresa = AdresaInput.Text,
                    BrojTelefona = BrojTelefonaInput.Text,
                    Email = EmailInput.Text,
                    Ime = ImeInput.Text,
                    Prezime = PrezimeInput.Text,
                    Status = true,
                    LozinkaSalt = UIHelper.GenerateSalt(),
                };

                klijentRegstracija.LozinkaHash = UIHelper.GenerateHash(klijentRegstracija.LozinkaSalt, LozinkaInput.Text);

                HttpResponseMessage responseK = await klijentService.PostResponse(klijentRegstracija);
                if (responseK.IsSuccessStatusCode)
                {
                    await DisplayAlert(Messages.success, Messages.registration_success, Messages.ok);
                    Global.prijavnjeniKorisnik = JsonConvert.DeserializeObject<Klijent>(await responseK.Content.ReadAsStringAsync());
                    await Navigation.PushModalAsync(new eFastFood.Navigacija.MDPage());
                    // load Prijava
                    //await Navigation.PopAsync();
                }
                else
                    await DisplayAlert(Messages.error, responseK.ReasonPhrase, Messages.ok);
            }
        }

        #region Validacija

        private async Task<bool> Validacija()
        {
            bool validacija = (ImeValidation() && PrezimeValidation() && await BrojTelefonaValidation() && await EmailValidation() && AdresaValidation() && LozinkaValidation());
            if (validacija)
                return true;
            else
                return false;
        }

        private bool LozinkaValidation()
        {
            if (string.IsNullOrEmpty(LozinkaInput.Text))
            {
                DisplayAlert(Messages.error, Messages.empty_string + " Lozinka.", Messages.ok);
                return false;
            }
            else if (LozinkaInput.Text.CompareTo(LozinkaPonovoInput.Text) != 0)
            {
                DisplayAlert(Messages.error, Messages.password_not_match, Messages.ok);
                return false;
            }
            return true;
        }

        private bool AdresaValidation()
        {
            if (string.IsNullOrEmpty(AdresaInput.Text))
            {
                DisplayAlert(Messages.error, Messages.empty_string + " Adresa.", Messages.ok);
                return false;
            }
            else if (AdresaInput.Text.Length > 50)
            {
                DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
                return false;
            }
            return true;
        }

        private async Task<bool> EmailValidation()
        {
            HttpResponseMessage responseK = await klijentService.GetActionResponse("CheckEmail", EmailInput.Text);

            if (responseK.IsSuccessStatusCode)
            {
                if (JsonConvert.DeserializeObject<bool>(await responseK.Content.ReadAsStringAsync()))
                {
                    await DisplayAlert(Messages.error, Messages.email_exist, Messages.ok);
                    return false;
                }
            }

            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(EmailInput.Text);
            }
            catch (FormatException)
            {
                await DisplayAlert(Messages.error, Messages.email_format, Messages.ok);
                return false;
            }
            if (string.IsNullOrEmpty(EmailInput.Text))
            {
                await DisplayAlert(Messages.error, Messages.empty_string + " Email.", Messages.ok);
                return false;
            }
            else if (EmailInput.Text.Length > 50)
            {
                await DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
                return false;
            }
            return true;
        }

        private async Task<bool> BrojTelefonaValidation()
        {
            HttpResponseMessage responseK = await klijentService.GetActionResponse("CheckBrojTelefona", BrojTelefonaInput.Text);

            if (responseK.IsSuccessStatusCode)
            {
                if (JsonConvert.DeserializeObject<bool>(await responseK.Content.ReadAsStringAsync()))
                {
                    await DisplayAlert(Messages.error, Messages.phone_exist, Messages.ok);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(BrojTelefonaInput.Text))
            {
                await DisplayAlert(Messages.error, Messages.empty_string + " Broj telefona.", Messages.ok);
                return false;
            }
            else if (BrojTelefonaInput.Text.Length > 20)
            {
                await DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
                return false;
            }
            return true;
        }

        private bool PrezimeValidation()
        {
            if (string.IsNullOrEmpty(PrezimeInput.Text))
            {
                DisplayAlert(Messages.error, Messages.empty_string + " Prezime.", Messages.ok);
                return false;
            }
            else if (PrezimeInput.Text.Length > 50)
            {
                DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
                return false;
            }
            return true;
        }

        private bool ImeValidation()
        {
            if (string.IsNullOrEmpty(ImeInput.Text))
            {
                DisplayAlert(Messages.error, Messages.empty_string + " Ime.", Messages.ok);
                return false;
            }
            else if (ImeInput.Text.Length > 50)
            {
                DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
                return false;
            }
            return true;
        }

        #endregion
    }
}