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

namespace eFastFood_UI.KategorijaUI
{
    public partial class KategorijaEdit : Form
    {
        APIHelper kategorijaService = new APIHelper(Global.ApiUrl, Global.KategorijaRoute);

        Kategorija kategorija { get; set; }

        public KategorijaEdit(int id)
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;

            HttpResponseMessage response = kategorijaService.GetResponse(id.ToString());

            if (response.IsSuccessStatusCode)
            {
                kategorija = response.Content.ReadAsAsync<Kategorija>().Result;
            }
            else
            {
                this.Close();
                MessageBox.Show(Messages.error + ": " + response.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void KategorijaEdit_Load(object sender, EventArgs e)
        {
            nazivInput.Text = kategorija.Naziv;
            opisInput.Text = kategorija.Opis;
        }

        private void SnimiButton_Click(object sender, EventArgs e)
        {
            kategorija.Naziv = nazivInput.Text;
            kategorija.Opis = opisInput.Text;

            HttpResponseMessage response = kategorijaService.PutResponse(kategorija.KategorijaID, kategorija);

            if (response.IsSuccessStatusCode)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                MessageBox.Show(Messages.success_edited, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(Messages.error + ": " + response.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Validacija

        private void NazivInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(nazivInput.Text))
            {
                e.Cancel = true;
                errorProviderEdit.SetError(nazivInput, Messages.empty_string);
            }
            else if (nazivInput.Text.Length < 3)
            {
                e.Cancel = true;
                errorProviderEdit.SetError(nazivInput, Messages.string_length3);
            }
            else
                errorProviderEdit.SetError(nazivInput, null);
        }

        private void OpisInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(opisInput.Text))
            {
                e.Cancel = true;
                errorProviderEdit.SetError(opisInput, Messages.empty_string);
            }
            else
                errorProviderEdit.SetError(opisInput, null);
        }
        #endregion
    }
}
