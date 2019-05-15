using eFastFood_PCL.Models;
using eFastFood_PCL.Helpers;
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

namespace eFastFood_UI.ProizvodUI
{
    public partial class ProizvodAdd : Form
    {
        readonly APIHelper proizvoddService = new APIHelper(Global.ApiUrl, Global.ProizvoidRoute);
        readonly APIHelper dobavljacService = new APIHelper(Global.ApiUrl, Global.DobavljacRoute);
        readonly APIHelper mjerneJediniceService = new APIHelper(Global.ApiUrl, Global.MjernaJedinicaRoute);

        Proizvod proizvodAdd = new Proizvod();

        public ProizvodAdd()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private void ProizvodAdd_Load(object sender, EventArgs e)
        {
            HttpResponseMessage responseD = dobavljacService.GetResponse();
            if (responseD.IsSuccessStatusCode)
            {
                List<Dobavljac> dobavljaciList = responseD.Content.ReadAsAsync<List<Dobavljac>>().Result;

                dobavljaciComboBox.DataSource = dobavljaciList.Select(x => new ComboItem() { ID = x.DobavljacID, Text = x.Naziv }).ToList();
            }
            else
                MessageBox.Show(Messages.error + ": " + responseD.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            HttpResponseMessage responseM = mjerneJediniceService.GetResponse();

            if (responseM.IsSuccessStatusCode)
            {
                List<MjernaJedinica> mjernaJedinicaList = responseM.Content.ReadAsAsync<List<MjernaJedinica>>().Result;

                mjerneJediniceComboBox.DataSource = mjernaJedinicaList.Select(x => new ComboItem() { ID = x.MjernaJedinicaID, Text = x.Naziv }).ToList();
            }
            else
                MessageBox.Show(Messages.error + ": " + responseD.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (!responseD.IsSuccessStatusCode || !responseM.IsSuccessStatusCode)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void SnimiButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                proizvodAdd.DobavljacID = dobavljaciComboBox.SelectedValue.ToInt();
                proizvodAdd.Naziv = nazivProizvodInput.Text;
                proizvodAdd.Opis = opisProizvodInput.Text;
                proizvodAdd.MjernaJedinicaID = mjerneJediniceComboBox.SelectedValue.ToInt();
                proizvodAdd.Kolicina = 0;
                proizvodAdd.DonjaGranica = donjaGranicaInput.Text.ToDecimal();

                HttpResponseMessage responseP = proizvoddService.PostResponse(proizvodAdd);

                if (responseP.IsSuccessStatusCode)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                    MessageBox.Show(Messages.success_add, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(Messages.error + ": " + responseP.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region Validacija

        private void NazivProizvodInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nazivProizvodInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(nazivProizvodInput, Messages.empty_string);
            }
            else if (nazivProizvodInput.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider.SetError(nazivProizvodInput, Messages.string_length50);
            }
            else
                errorProvider.SetError(nazivProizvodInput, null);
        }

        private void OpisProizvodInput_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(opisProizvodInput.Text))
            //{
            //    e.Cancel = true;
            //    errorProvider.SetError(opisProizvodInput, Messages.empty_string);
            //}
            //else  DALI DODATI DA JE POLJE OBAVEZNO
            if (opisProizvodInput.Text.Length > 200)
            {
                e.Cancel = true;
                errorProvider.SetError(opisProizvodInput, Messages.string_length200);
            }
            else
                errorProvider.SetError(opisProizvodInput, null);
        }

        private void DonjaGranicaInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void DobavljaciComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (dobavljaciComboBox.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider.SetError(dobavljaciComboBox, Messages.required);
            }
            else
                errorProvider.SetError(dobavljaciComboBox, null);
        }

        private void MjerneJediniceComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (mjerneJediniceComboBox.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider.SetError(mjerneJediniceComboBox, Messages.required);
            }
            else
                errorProvider.SetError(mjerneJediniceComboBox, null);
        }

        #endregion
    }
}
