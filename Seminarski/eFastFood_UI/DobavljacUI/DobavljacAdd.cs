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

namespace eFastFood_UI.DobavljacUI
{
    public partial class DobavljacAdd : Form
    {
        APIHelper dostavljacService = new APIHelper(Global.ApiUrl, Global.DobavljacRoute);

        public DobavljacAdd()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private void SnimiButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Dobavljac dobavljacAdd = new Dobavljac();
                dobavljacAdd.Naziv = dobavljacNazivInput.Text;
                dobavljacAdd.Adresa = adresaDobavljacInput.Text;
                dobavljacAdd.BrojTelefona = brojTelefonaInput.Text;
                dobavljacAdd.Email = emailInput.Text;

                HttpResponseMessage responseD = dostavljacService.PostResponse(dobavljacAdd);

                if (responseD.IsSuccessStatusCode)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    MessageBox.Show(Messages.success_add, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(Messages.error + ": " + responseD.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region Validacija
        private void DobavljacNazivInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(dobavljacNazivInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(dobavljacNazivInput, Messages.empty_string);
            }
            else if (dobavljacNazivInput.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(dobavljacNazivInput, Messages.string_length3);
            }
            else if (dobavljacNazivInput.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider.SetError(dobavljacNazivInput, Messages.string_length50);
            }
            else
                errorProvider.SetError(dobavljacNazivInput, null);
        }

        private void AdresaDobavljacInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(adresaDobavljacInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(adresaDobavljacInput, Messages.empty_string);
            }
            else if (adresaDobavljacInput.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider.SetError(adresaDobavljacInput, Messages.string_length50);
            }
            else
                errorProvider.SetError(adresaDobavljacInput, null);
        }

        private void BrojTelefonaInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(brojTelefonaInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(brojTelefonaInput, Messages.empty_string);
            }
            else
                errorProvider.SetError(brojTelefonaInput, null);
        }

        private void EmailInput_Validating(object sender, CancelEventArgs e)
        {
            bool emailValidation = false;

            try
            {
                new System.Net.Mail.MailAddress(emailInput.Text);
            }
            catch (FormatException)
            {
                emailValidation = true;
            }


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
            else if (emailValidation)
            {
                e.Cancel = true;
                errorProvider.SetError(emailInput, Messages.not_valid_email);
            }
            else
                errorProvider.SetError(emailInput, null);

        }
        #endregion

    }
}
