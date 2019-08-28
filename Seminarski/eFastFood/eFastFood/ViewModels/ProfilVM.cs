using eFastFood_PCL.Models;
using eFastFood_PCL.Util;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eFastFood.ViewModels
{
    class ProfilVM : INotifyPropertyChanged
    {
        Page page;

        APIHelper klijentService = new APIHelper(Global.ApiUrl, Global.KlijentRoute);

        public string Title { get; set; } = "Profil";

        private string _Ime;
        private string _Prezime;
        private string _BrojTelefona;
        private string _Email;
        private string _LozinkaPovovo;
        private string _LozinkaNova;
        private string _Adresa;

        public string Ime { get { return _Ime; } set { _Ime = value; OnPropertyChanged(); } }
        public string Prezime { get { return _Prezime; } set { _Prezime = value; OnPropertyChanged(); } }
        public string BrojTelefona { get { return _BrojTelefona; } set { _BrojTelefona = value; OnPropertyChanged(); } }
        public string Email { get { return _Email; } set { _Email = value; OnPropertyChanged(); } }
        public string LozinkaPovovo { get { return _LozinkaPovovo; } set { _LozinkaPovovo = value; OnPropertyChanged(); } }
        public string LozinkaNova { get { return _LozinkaNova; } set { _LozinkaNova = value; OnPropertyChanged(); } }
        public string Adresa { get { return _Adresa; } set { _Adresa = value; OnPropertyChanged(); } }

        public RelayCommand Snimi_Button { get; private set; }

        public ProfilVM(Page page)
        {
            this.page = page;
            Snimi_Button = new RelayCommand(async () => await Snimi(), () => !IsBusy);
            Task.Run(() => LoadData());
        }

        private async Task Snimi()
        {
            IsBusy = true;
            if (await Validacija())
            {
                Klijent k = Global.prijavnjeniKorisnik;
                k.Ime = Ime;
                k.Prezime = Prezime;
                k.Email = Email;
                k.BrojTelefona = BrojTelefona;
                k.Adresa = Adresa;

                if (!string.IsNullOrEmpty(LozinkaNova))
                    k.LozinkaHash = UIHelper.GenerateHash(k.LozinkaSalt, LozinkaNova);

                HttpResponseMessage responseK = klijentService.PutResponse(k.KlijentID, k);

                if (responseK.IsSuccessStatusCode)
                    await page.DisplayAlert(Messages.success, Messages.user_updated, Messages.ok);
                else
                    await page.DisplayAlert(Messages.error, responseK.ReasonPhrase, Messages.ok);
            }
            IsBusy = false;
        }


        void LoadData()
        {
            Klijent k = Global.prijavnjeniKorisnik;
            Ime = k.Ime;
            Prezime = k.Prezime;
            Adresa = k.Adresa;
            BrojTelefona = k.BrojTelefona;
            Email = k.Email;
        }


        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion

        #region Validacija

        private async Task<bool> Validacija()
        {
            bool validacija = (ImeValidation() && PrezimeValidation() && await BrojTelefonaValidation() && await EmailValidation() && AdresaValidation() && LozinkaValidation());
            if (validacija)
                return true;
            else
                return false;
        }

        private bool AdresaValidation()
        {
            if (string.IsNullOrEmpty(Adresa))
            {
                page.DisplayAlert(Messages.error, Messages.empty_string + " Adresa.", Messages.ok);
                return false;
            }
            else if (Adresa.Length > 50)
            {
                page.DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
                return false;
            }
            return true;
        }

        private async Task<bool> EmailValidation()
        {
            HttpResponseMessage responseK = await klijentService.GetActionResponse("CheckEmail", Email + "/" + Global.prijavnjeniKorisnik.KlijentID.ToString());

            if (responseK.IsSuccessStatusCode)
            {
                if (JsonConvert.DeserializeObject<bool>(await responseK.Content.ReadAsStringAsync()))
                {
                    await page.DisplayAlert(Messages.error, Messages.email_exist, Messages.ok);
                    return false;
                }
            }

            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(Email);
            }
            catch (FormatException)
            {
                await page.DisplayAlert(Messages.error, Messages.email_format, Messages.ok);
                return false;
            }
            if (string.IsNullOrEmpty(Email))
            {
                await page.DisplayAlert(Messages.error, Messages.empty_string + " Email.", Messages.ok);
                return false;
            }
            else if (Email.Length > 50)
            {
                await page.DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
                return false;
            }
            return true;
        }

        private async Task<bool> BrojTelefonaValidation()
        {
            HttpResponseMessage responseK = await klijentService.GetActionResponse("CheckBrojTelefona", BrojTelefona + "/" + Global.prijavnjeniKorisnik.KlijentID.ToString());

            if (responseK.IsSuccessStatusCode)
            {
                if (JsonConvert.DeserializeObject<bool>(await responseK.Content.ReadAsStringAsync()))
                {
                    await page.DisplayAlert(Messages.error, Messages.phone_exist, Messages.ok);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(BrojTelefona))
            {
                await page.DisplayAlert(Messages.error, Messages.empty_string + " Broj telefona.", Messages.ok);
                return false;
            }
            else if (BrojTelefona.Length > 20)
            {
                await page.DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
                return false;
            }
            return true;
        }

        private bool PrezimeValidation()
        {
            if (string.IsNullOrEmpty(Prezime))
            {
                page.DisplayAlert(Messages.error, Messages.empty_string + " Prezime.", Messages.ok);
                return false;
            }
            else if (Prezime.Length > 50)
            {
                page.DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
                return false;
            }
            return true;
        }

        private bool ImeValidation()
        {
            if (string.IsNullOrEmpty(Ime))
            {
                page.DisplayAlert(Messages.error, Messages.empty_string + " Ime.", Messages.ok);
                return false;
            }
            else if (Ime.Length > 50)
            {
                page.DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
                return false;
            }
            return true;
        }

        private bool LozinkaValidation()
        {
            if (string.IsNullOrEmpty(LozinkaNova))
                return true;
            else
            {
                if (LozinkaNova != LozinkaPovovo)
                {
                    page.DisplayAlert(Messages.error, Messages.passwords_not_same, Messages.ok);
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
