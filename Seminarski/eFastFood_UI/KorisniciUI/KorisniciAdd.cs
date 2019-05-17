using eFastFood_PCL.Helpers;
using eFastFood_PCL.Models;
using eFastFood_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFastFood_UI.KorisniciUI
{
    public partial class KorisniciAdd : Form
    {
        APIHelper ulogeService = new APIHelper(Global.ApiUrl, Global.UlogeRoute);
        APIHelper uposleniciService = new APIHelper(Global.ApiUrl, Global.UposleniciRoute);

        public KorisniciAdd()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private void KorisniciAdd_Load(object sender, EventArgs e)
        {
            HttpResponseMessage reponseU = ulogeService.GetResponse();

            if (reponseU.IsSuccessStatusCode)
                ulogeComboBox.DataSource = reponseU.Content.ReadAsAsync<List<Uloga>>().Result.Select(x => new ComboItem() { ID = x.UlogaID, Text = x.Naziv }).ToList();
            else
                MessageBox.Show(Messages.error + ": " + reponseU.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SnimiButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Uposlenik uAdd = new Uposlenik();
                uAdd.Ime = imeInput.Text;
                uAdd.Prezime = prezimeInput.Text;
                uAdd.UserName = korisnickoImeInput.Text;
                uAdd.BrojTelefona = brojTelefonaInput.Text;
                uAdd.Email = emailInput.Text;
                uAdd.LozinkaSalt = UIHelper.GenerateSalt();
                uAdd.LozinkaHash = UIHelper.GenerateHash(uAdd.LozinkaSalt, lozinkaInput.Text);
                uAdd.Status = true;
                uAdd.UlogaID = ulogeComboBox.SelectedValue.ToInt();

                HttpResponseMessage reponseU = uposleniciService.PostResponse(uAdd);

                if (reponseU.IsSuccessStatusCode)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    MessageBox.Show(Messages.success_add, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(Messages.error + ": " + reponseU.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region Validacija

        private void ImeInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(imeInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(imeInput, Messages.empty_string);
            }
            else if (imeInput.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider.SetError(imeInput, Messages.string_length50);
            }
            else
                errorProvider.SetError(imeInput, null);
        }

        private void PrezimeInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(prezimeInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(prezimeInput, Messages.empty_string);
            }
            else if (prezimeInput.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider.SetError(prezimeInput, Messages.string_length50);
            }
            else
                errorProvider.SetError(prezimeInput, null);
        }

        private void KorisnickoImeInput_Validating(object sender, CancelEventArgs e)
        {
            HttpResponseMessage responseU = uposleniciService.GetActionResponse("CheckUserName");
            bool usernameExitst = false;
            if (responseU.IsSuccessStatusCode)
                usernameExitst = responseU.Content.ReadAsAsync<bool>().Result;

            if (string.IsNullOrEmpty(korisnickoImeInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(korisnickoImeInput, Messages.empty_string);
            }
            else if (korisnickoImeInput.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider.SetError(korisnickoImeInput, Messages.string_length50);
            }
            else if (usernameExitst)
            {
                e.Cancel = true;
                errorProvider.SetError(korisnickoImeInput, Messages.user_name_exist);
            }
            else
                errorProvider.SetError(korisnickoImeInput, null);

        }

        private void BrojTelefonaInput_Validating(object sender, CancelEventArgs e)
        {
            HttpResponseMessage responseU = uposleniciService.GetActionResponse("CheckBrojTelefona");
            bool brojExitst = false;
            if (responseU.IsSuccessStatusCode)
                brojExitst = responseU.Content.ReadAsAsync<bool>().Result;

            if (brojTelefonaInput.Text.Length > 20)
            {
                e.Cancel = true;
                errorProvider.SetError(brojTelefonaInput, Messages.string_length20);
            }
            else if (brojExitst)
            {
                e.Cancel = true;
                errorProvider.SetError(brojTelefonaInput, Messages.phone_number_exist);
            }
            else
                errorProvider.SetError(brojTelefonaInput, null);
        }

        private void EmailInput_Validating(object sender, CancelEventArgs e)
        {
            HttpResponseMessage responseU = uposleniciService.GetActionResponse("CheckEmail");
            bool emailExitst = false;
            if (responseU.IsSuccessStatusCode)
                emailExitst = responseU.Content.ReadAsAsync<bool>().Result;
            if (string.IsNullOrEmpty(emailInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(emailInput, Messages.empty_string);
            }
            else if (emailInput.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider.SetError(emailInput, Messages.string_length50);
            }
            else if (emailExitst)
            {
                e.Cancel = true;
                errorProvider.SetError(emailInput, Messages.email_exist);
            }
            else
                errorProvider.SetError(emailInput, null);

        }

        private void LozinkaInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(lozinkaInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(lozinkaInput, Messages.empty_string);
            }
            else
                errorProvider.SetError(lozinkaInput, null);
        }

        private void UlogeComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (ulogeComboBox.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider.SetError(ulogeComboBox, Messages.nothing_selected);
            }
            else
                errorProvider.SetError(ulogeComboBox, null);
        }

        #endregion


    }
}
