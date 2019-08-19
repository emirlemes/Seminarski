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
    public partial class ProizvodEdit : Form
    {
        APIHelper proizvodiService = new APIHelper(Global.ApiUrl, Global.ProizvoidRoute);

        APIHelper mjernaJedinicaService = new APIHelper(Global.ApiUrl, Global.MjernaJedinicaRoute);

        APIHelper dobavljacService = new APIHelper(Global.ApiUrl, Global.DobavljacRoute);

        Proizvod proizvodEdit;

        List<Dobavljac> dobavljaciList;
        List<MjernaJedinica> mjernaJedinicaList;

        public ProizvodEdit(int id)
        {
            InitializeComponent();

            HttpResponseMessage responseP = proizvodiService.GetResponse(id.ToString());

            HttpResponseMessage responseMJ = mjernaJedinicaService.GetResponse();

            HttpResponseMessage responseD = dobavljacService.GetResponse();

            if (responseP.IsSuccessStatusCode)
                proizvodEdit = responseP.Content.ReadAsAsync<Proizvod>().Result;
            else
                MessageBox.Show(Messages.error + ": " + responseP.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (responseMJ.IsSuccessStatusCode)
                mjernaJedinicaList = responseMJ.Content.ReadAsAsync<List<MjernaJedinica>>().Result.ToList();
            else
                MessageBox.Show(Messages.error + ": " + responseMJ.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (responseD.IsSuccessStatusCode)
                dobavljaciList = responseD.Content.ReadAsAsync<List<Dobavljac>>().Result.ToList();
            else
                MessageBox.Show(Messages.error + ": " + responseD.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (!(responseMJ.IsSuccessStatusCode && responseD.IsSuccessStatusCode && responseP.IsSuccessStatusCode))
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void ProizvodEdit_Load(object sender, EventArgs e)
        {
            nazivProizvodInput.Text = proizvodEdit.Naziv;
            opisProizvodInput.Text = proizvodEdit.Opis;
            kolicinaInput.Text = proizvodEdit.Kolicina.ToString();
            donjaGranicaInput.Text = proizvodEdit.DonjaGranica.ToString();


            dobavljaciComboBox.DataSource = dobavljaciList.Select(x => new ComboItem() { ID = x.DobavljacID, Text = x.Naziv }).ToList();

            dobavljaciComboBox.SelectedIndex = dobavljaciComboBox.FindString(dobavljaciList.Find(x => x.DobavljacID == proizvodEdit.DobavljacID).Naziv);


            mjerneJediniceComboBox.DataSource = mjernaJedinicaList.Select(x => new ComboItem() { ID = x.MjernaJedinicaID, Text = x.Naziv }).ToList();

            mjerneJediniceComboBox.SelectedIndex = mjerneJediniceComboBox.FindString(mjernaJedinicaList.Find(x => x.MjernaJedinicaID == proizvodEdit.MjernaJedinicaID).Naziv);
        }

        private void SnimiButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                proizvodEdit.Naziv = nazivProizvodInput.Text;
                proizvodEdit.Opis = opisProizvodInput.Text;
                proizvodEdit.Kolicina = kolicinaInput.Text.ToDecimal();
                proizvodEdit.DonjaGranica = donjaGranicaInput.Text.ToDecimal();
                proizvodEdit.MjernaJedinicaID = mjerneJediniceComboBox.SelectedValue.ToInt();
                proizvodEdit.DobavljacID = dobavljaciComboBox.SelectedValue.ToInt();

                HttpResponseMessage reponseP = proizvodiService.PutResponse(proizvodEdit.ProizvodID, proizvodEdit);

                if (reponseP.IsSuccessStatusCode)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    MessageBox.Show(Messages.success_edited, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(Messages.error + ": " + reponseP.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
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

        private void KolicinaInput_KeyPress(object sender, KeyPressEventArgs e)
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
