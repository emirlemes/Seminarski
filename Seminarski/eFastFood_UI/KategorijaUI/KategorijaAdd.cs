using eFastFood_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eFastFood_PCL.Models;
using System.Net.Http;

namespace eFastFood_UI.KategorijaUI
{
    public partial class KategorijaAdd : Form
    {
        APIHelper kategorijaService = new APIHelper(Global.ApiUrl, Global.KategorijaRoute);


        public KategorijaAdd()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void SnimiButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                Kategorija kategorija = new Kategorija();

                kategorija.Naziv = nazivInput.Text;
                kategorija.Opis = opisInput.Text;

                HttpResponseMessage response = kategorijaService.PostResponse(kategorija);

                if (response.IsSuccessStatusCode)
                {
                    this.Close();
                    MessageBox.Show(Messages.success_add, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(Messages.error +": "+ response.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Validacija
        private void NazivInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(nazivInput.Text))
            {
                e.Cancel = true;
                errorProviderKategorija.SetError(nazivInput, Messages.empty_string);
            }
            else if (nazivInput.Text.Length < 3)
            {
                e.Cancel = true;
                errorProviderKategorija.SetError(nazivInput, Messages.string_length3);
            }
            else
                errorProviderKategorija.SetError(nazivInput, null);
        }

        private void OpisInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(opisInput.Text))
            {
                e.Cancel = true;
                errorProviderKategorija.SetError(opisInput, Messages.empty_string);
            }
            else
                errorProviderKategorija.SetError(opisInput, null);
        }
        #endregion
    }
}
