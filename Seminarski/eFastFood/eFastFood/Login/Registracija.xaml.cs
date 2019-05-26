using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eFastFood.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registracija : ContentPage
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void Registruj_Clicked(object sender, EventArgs e)
        {
            if (Validacija())
            {
                //Poslat podatke na api 
                DisplayAlert(Messages.success, Messages.registration_success, Messages.ok);
                this.Navigation.PopAsync();
            }
        }

        #region Validacija

        private bool Validacija()
        {
            bool validacija = (ImeValidation() && PrezimeValidation() && BrojTelefonaValidation() && EmailValidation() && AdresaValidation() && LozinkaValidation());
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

        private bool EmailValidation()
        {
            // provjeriti dali email vec postoji
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(EmailInput.Text);
            }
            catch (FormatException)
            {
                DisplayAlert(Messages.error, Messages.email_format, Messages.ok);
                return false;
            }
            if (string.IsNullOrEmpty(EmailInput.Text))
            {
                DisplayAlert(Messages.error, Messages.empty_string + " Email.", Messages.ok);
                return false;
            }
            else if (EmailInput.Text.Length > 50)
            {
                DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
                return false;
            }
            return true;
        }

        private bool BrojTelefonaValidation()
        {
            // provjeriti dali broj vec postoji
            if (string.IsNullOrEmpty(BrojTelefonaInput.Text))
            {
                DisplayAlert(Messages.error, Messages.empty_string + " Broj telefona.", Messages.ok);
                return false;
            }
            else if (BrojTelefonaInput.Text.Length > 20)
            {
                DisplayAlert(Messages.error, Messages.string_length50, Messages.ok);
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