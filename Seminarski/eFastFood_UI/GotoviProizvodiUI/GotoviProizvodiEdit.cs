using eFastFood_PCL.Helpers;
using eFastFood_PCL.Models;
using eFastFood_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFastFood_UI.GotoviProizvodiUI
{
    public partial class GotoviProizvodiEdit : Form
    {
        APIHelper goroviProizvodiService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);
        APIHelper kategorijeService = new APIHelper(Global.ApiUrl, Global.KategorijaRoute);

        private GotoviProizvod gp { get; set; }

        public GotoviProizvodiEdit(int id = 1)
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;

            HttpResponseMessage response = goroviProizvodiService.GetResponse(id.ToString());

            if (response.IsSuccessStatusCode)
            {
                gp = response.Content.ReadAsAsync<GotoviProizvod>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                this.Close();
                MessageBox.Show(Messages.error + ": " + Messages.not_found, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GotoviProizvodiEdit_Load(object sender, EventArgs e)
        {
            nazivInput.Text = gp.Naziv;
            cijenaInput.Text = gp.Cijena.ToString();
            opisInput.Text = gp.Opis;
            vrijemePripremeInput.Text = gp.VrijemePripreme.ToString();

            pictureBox.Image = Image.FromStream(new MemoryStream(gp.SlikaUmanjeno));



            HttpResponseMessage response = kategorijeService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Kategorija> kategorije = response.Content.ReadAsAsync<List<Kategorija>>().Result;
                kategorijaComboBox.DataSource = new List<ComboItem>(kategorije.Select(x => new ComboItem() { ID = x.KategorijaID, Text = x.Naziv }));

                ComboItem selected = new ComboItem() { ID = gp.KategorijaID, Text = gp.Kategorija.Naziv };

                kategorijaComboBox.SelectedItem = selected;
            }
        }


        #region Validacija
        private void VrijemePripremeInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        private void NazivInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nazivInput.Text))
            {
                e.Cancel = true;
                errorProviderEdit.SetError(nazivInput, Messages.empty_string);
            }
            else
                errorProviderEdit.SetError(nazivInput, null);
        }

        private void CijenaInput_Validating(object sender, CancelEventArgs e)
        {
            if (double.Parse(cijenaInput.Text) < 0)
            {
                e.Cancel = true;
                errorProviderEdit.SetError(cijenaInput, Messages.negative_price);
            }
            else
                errorProviderEdit.SetError(cijenaInput, null);
        }

        private void OpisInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(opisInput.Text))
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
