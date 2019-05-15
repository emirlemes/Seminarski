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

                HttpResponseMessage response = dostavljacService.PostResponse(dobavljacAdd);

                if (response.IsSuccessStatusCode)
                {
                    this.Close();
                    MessageBox.Show(Messages.success_add, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(Messages.error + ": " + response.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
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
            else
                errorProvider.SetError(dobavljacNazivInput, null);
        }

        private void AdresaDobavljacInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(dobavljacNazivInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(dobavljacNazivInput, Messages.empty_string);
            }
            else
                errorProvider.SetError(dobavljacNazivInput, null);
        }

        private void BrojTelefonaInput_Validating(object sender, CancelEventArgs e)
        {

        }

        private void EmailInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(dobavljacNazivInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(dobavljacNazivInput, Messages.empty_string);
            }
            else
                errorProvider.SetError(dobavljacNazivInput, null);
            try
            {
                new System.Net.Mail.MailAddress(emailInput.Text);
            }
            catch (FormatException)
            {
                e.Cancel = true;
                errorProvider.SetError(emailInput, Messages.not_valid_email);
            }
        }
        #endregion

    }
}
