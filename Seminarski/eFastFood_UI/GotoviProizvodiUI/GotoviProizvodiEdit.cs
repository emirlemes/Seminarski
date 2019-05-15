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
        APIHelper gotoviProizvodiService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);
        APIHelper kategorijeService = new APIHelper(Global.ApiUrl, Global.KategorijaRoute);

        private GotoviProizvod gotoviProizvod { get; set; }

        public GotoviProizvodiEdit(int id = 1)
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;

            HttpResponseMessage response = gotoviProizvodiService.GetResponse(id.ToString());

            if (response.IsSuccessStatusCode)
            {
                gotoviProizvod = response.Content.ReadAsAsync<GotoviProizvod>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                this.Close();
                MessageBox.Show(Messages.error + ": " + Messages.not_found, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GotoviProizvodiEdit_Load(object sender, EventArgs e)
        {
            nazivInput.Text = gotoviProizvod.Naziv;
            cijenaInput.Text = gotoviProizvod.Cijena.ToString();
            opisInput.Text = gotoviProizvod.Opis;
            vrijemePripremeInput.Text = gotoviProizvod.VrijemePripreme.ToString();

            pictureBox.Image = Image.FromStream(new MemoryStream(gotoviProizvod.SlikaUmanjeno));



            HttpResponseMessage responseK = kategorijeService.GetResponse();

            if (responseK.IsSuccessStatusCode)
            {
                List<Kategorija> kategorije = responseK.Content.ReadAsAsync<List<Kategorija>>().Result;
                kategorijaComboBox.DataSource = kategorije.Select(x => new ComboItem() { ID = x.KategorijaID, Text = x.Naziv }).ToList();

                kategorijaComboBox.SelectedIndex = kategorijaComboBox.FindString(kategorije.Find(x => x.KategorijaID == gotoviProizvod.KategorijaID).Naziv);
            }
        }

        private void SnimiButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                gotoviProizvod.KategorijaID = (int)kategorijaComboBox.SelectedValue;
                gotoviProizvod.Naziv = nazivInput.Text;
                gotoviProizvod.Opis = opisInput.Text;
                gotoviProizvod.VrijemePripreme = vrijemePripremeInput.Text.ToInt();
                gotoviProizvod.Cijena = cijenaInput.Text.ToDecimal();

                if (string.IsNullOrEmpty(slikaPath.Text))
                {
                    //  NE MIJENJAT STARU SLIKU
                    //gotoviProizvod.Slika = UIHelper.AddDefaultPictureFull();
                    //gotoviProizvod.SlikaUmanjeno = UIHelper.AddDefaultPictureResized();
                }
                else
                {
                    gotoviProizvod.Slika = UIHelper.AddFromFileFull(slikaPath.Text);
                    gotoviProizvod.SlikaUmanjeno = UIHelper.AddFromFileResized(slikaPath.Text);
                }

                HttpResponseMessage response = gotoviProizvodiService.PutResponse(gotoviProizvod.GotoviProizvodID, gotoviProizvod);
                if (response.IsSuccessStatusCode)
                {
                    this.Close();
                    MessageBox.Show(Messages.success_edited, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(Messages.error, Messages.error + ": " + response.ReasonPhrase, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FileDialogButton_Click(object sender, EventArgs e)
        {
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "jpg files(*.jpg)|*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image orgImg = Image.FromFile(openFileDialog.FileName);

                if (orgImg.Width > Global.ResizeWidth && orgImg.Height > Global.ResizeHeight)
                    slikaPath.Text = openFileDialog.FileName;
                else
                    MessageBox.Show(Messages.picture_to_small, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void KategorijaComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (kategorijaComboBox.SelectedValue == null)
            {
                e.Cancel = true;
                errorProviderEdit.SetError(kategorijaComboBox, Messages.required);
            }
            else
                errorProviderEdit.SetError(kategorijaComboBox, null);
        }

        #endregion
    }
}
