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
    public partial class KorisniciEdit : Form
    {
        APIHelper uposleniciService = new APIHelper(Global.ApiUrl, Global.UposleniciRoute);
        APIHelper ulogeService = new APIHelper(Global.ApiUrl, Global.UlogeRoute);

        Uposlenik uEdit { get; set; }
        List<Uloga> ulogeList = new List<Uloga>();

        public KorisniciEdit(int id)
        {
            HttpResponseMessage reponseU = uposleniciService.GetResponse(id.ToString());
            HttpResponseMessage reponseUL = ulogeService.GetResponse();



            if (reponseU.IsSuccessStatusCode)
                uEdit = reponseU.Content.ReadAsAsync<Uposlenik>().Result;
            else
                MessageBox.Show(Messages.error + ": " + reponseU.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (reponseUL.IsSuccessStatusCode)
                ulogeList = reponseUL.Content.ReadAsAsync<List<Uloga>>().Result;
            else
                MessageBox.Show(Messages.error + ": " + reponseUL.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);


            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private void KorisniciEdit_Load(object sender, EventArgs e)
        {
            imeInput.Text = uEdit.Ime;
            prezimeInput.Text = uEdit.Prezime;
            korisnickoImeInput.Text = uEdit.UserName;
            brojTelefonaInput.Text = uEdit.BrojTelefona;
            emailInput.Text = uEdit.Email;
            statusCheckBox.Checked = uEdit.Status;
            ulogeComboBox.SelectedValue = uEdit.UlogaID;

            ulogeComboBox.DataSource = ulogeList.Select(x => new ComboItem() { ID = x.UlogaID, Text = x.Naziv }).ToList();
        }

        private void SnimiButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                uEdit.Ime = imeInput.Text;
                uEdit.Prezime = prezimeInput.Text;
                uEdit.UserName = korisnickoImeInput.Text;
                uEdit.BrojTelefona = brojTelefonaInput.Text;
                uEdit.Email = emailInput.Text;
                uEdit.Status = statusCheckBox.Checked;
                uEdit.UlogaID = ulogeComboBox.SelectedValue.ToInt();

                if (lozinkaInput.Text.Length != 0)
                {
                    uEdit.LozinkaSalt = UIHelper.GenerateSalt();
                    uEdit.LozinkaHash = UIHelper.GenerateHash(uEdit.LozinkaSalt, lozinkaInput.Text);
                }

                HttpResponseMessage reponseU = uposleniciService.PutResponse(uEdit.UposlenikID, uEdit);

                if (reponseU.IsSuccessStatusCode)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    MessageBox.Show(Messages.success_edited, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            HttpResponseMessage responseU = uposleniciService.GetActionResponse("CheckUserName", korisnickoImeInput.Text + "/" + uEdit.UposlenikID.ToString());
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
            HttpResponseMessage responseU = uposleniciService.GetActionResponse("CheckBrojTelefona", brojTelefonaInput.Text + "/" + uEdit.UposlenikID);
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

            bool invalidEmail = false;
            try
            {
                System.Net.Mail.MailAddress k = new System.Net.Mail.MailAddress(emailInput.Text);
            }
            catch (FormatException)
            {
                invalidEmail = true;
            }


            HttpResponseMessage responseU = uposleniciService.GetActionResponse("CheckEmail", emailInput.Text + "/" + uEdit.UposlenikID.ToString());
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
            else if (invalidEmail)
            {
                e.Cancel = true;
                errorProvider.SetError(emailInput, Messages.not_valid_email);
            }
            else
                errorProvider.SetError(emailInput, null);

        }

        private void LozinkaInput_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(lozinkaInput.Text))
            //{
            //    e.Cancel = true;
            //    errorProvider.SetError(lozinkaInput, Messages.empty_string);
            //}
            //else
            //    errorProvider.SetError(lozinkaInput, null);
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
