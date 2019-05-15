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
    public partial class DobavljacEdit : Form
    {
        APIHelper dobavljacService = new APIHelper(Global.ApiUrl, Global.DobavljacRoute);

        Dobavljac dobavljacEdit;

        public DobavljacEdit(int id)
        {
            HttpResponseMessage responseD = dobavljacService.GetResponse(id.ToString());
            if (responseD.IsSuccessStatusCode)
                dobavljacEdit = responseD.Content.ReadAsAsync<Dobavljac>().Result;
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
                MessageBox.Show(Messages.error + ": " + responseD.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private void DobavljacEdit_Load(object sender, EventArgs e)
        {
            dobavljacNazivInput.Text = dobavljacEdit.Naziv;
            adresaDobavljacInput.Text = dobavljacEdit.Adresa;
            brojTelefonaInput.Text = dobavljacEdit.BrojTelefona;
            emailInput.Text = dobavljacEdit.Email;
        }

        private void SnimiButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                dobavljacEdit.Naziv = dobavljacNazivInput.Text;
                dobavljacEdit.Adresa = adresaDobavljacInput.Text;
                dobavljacEdit.BrojTelefona = brojTelefonaInput.Text;
                dobavljacEdit.Email = emailInput.Text;

                HttpResponseMessage reponseD = dobavljacService.PutResponse(dobavljacEdit.DobavljacID, dobavljacEdit);

                if (reponseD.IsSuccessStatusCode)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                    MessageBox.Show(Messages.success_edited, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(Messages.error + ": " + reponseD.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
