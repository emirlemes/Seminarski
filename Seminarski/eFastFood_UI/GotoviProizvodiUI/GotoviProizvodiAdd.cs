using eFastFood_PCL.Helpers;
using eFastFood_PCL.Models;
using eFastFood_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace eFastFood_UI.GotoviProizvodiUI
{
    public partial class GotoviProizvodiAdd : Form
    {
        APIHelper gotoviProizvodiService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);

        APIHelper kategorrijaService = new APIHelper(Global.ApiUrl, Global.KategorijaRoute);

        GotoviProizvod gp = new GotoviProizvod();

        public GotoviProizvodiAdd()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void GotoviProizvodiAdd_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = kategorrijaService.GetResponse();
            List<Kategorija> kategorije = new List<Kategorija>();

            if (response.IsSuccessStatusCode)
            {
                kategorije = response.Content.ReadAsAsync<List<Kategorija>>().Result;
                List<ComboItem> comboItems = new List<ComboItem>(kategorije.Select(x => new ComboItem(x.KategorijaID, x.Naziv)));

                kategorijaComboBox.DataSource = comboItems;
            }
            else
                MessageBox.Show(Messages.error + ": " + response.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                gp.Cijena = cijenaInput.Text.ToDecimal();
                gp.KategorijaID = (int)kategorijaComboBox.SelectedValue;
                gp.Opis = opisInput.Text;
                gp.VrijemePripreme = vrijemePripremeInput.Text.ToInt();
                gp.Naziv = nazivInput.Text;
                gp.Opis = opisInput.Text;

                if (string.IsNullOrEmpty(slikaInput.Text))
                    AddDefaultPicture();

                HttpResponseMessage response = gotoviProizvodiService.PostResponse(gp);

                if (response.IsSuccessStatusCode)
                {
                    this.Close();
                    MessageBox.Show(Messages.success_add, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(Messages.error + ": " + response.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SlikaButton_Click(object sender, EventArgs e)
        {
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "jpg files(*.jpg)|*.jpg";
            openFileDialog.FileName = "";

            Image orgImg;
            Image resizedImg;

            MemoryStream ms = new MemoryStream();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                orgImg = Image.FromFile(openFileDialog.FileName);

                if (orgImg.Width > Global.ResizeWidth || orgImg.Height > Global.ResizeHeight)
                {
                    orgImg.Save(ms, ImageFormat.Jpeg);
                    gp.Slika = ms.ToArray();

                    resizedImg = UIHelper.ResizeImage(orgImg, new Size(Global.ResizeWidth, Global.ResizeHeight));
                    ms = new MemoryStream();
                    resizedImg.Save(ms, ImageFormat.Jpeg);

                    gp.SlikaUmanjeno = ms.ToArray();
                }
                else
                    MessageBox.Show(Messages.picture_to_small, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                AddDefaultPicture();
            }
            pictureBox.Image = Image.FromStream(new MemoryStream(gp.SlikaUmanjeno));
        }

        private void AddDefaultPicture()
        {
            Image orgImg;
            Image resizedImg;

            MemoryStream ms = new MemoryStream();
            orgImg = Properties.Resources._default;
            orgImg.Save(ms, ImageFormat.Jpeg);
            gp.Slika = ms.ToArray();

            ms = new MemoryStream();
            resizedImg = UIHelper.ResizeImage(orgImg, new Size(Global.ResizeWidth, Global.ResizeHeight));
            resizedImg.Save(ms, ImageFormat.Jpeg);

            gp.SlikaUmanjeno = ms.ToArray();
        }
        #region Validacija

        private void NazivInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nazivInput.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(nazivInput, Messages.empty_string);
            }
            else
                errorProvider1.SetError(nazivInput, null);
        }

        private void CijenaInput_Validating(object sender, CancelEventArgs e)
        {
            if (double.Parse(cijenaInput.Text) < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cijenaInput, Messages.negative_price);
            }
            else
                errorProvider1.SetError(cijenaInput, null);
        }

        private void OpisInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(opisInput.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(opisInput, Messages.empty_string);
            }
            else
                errorProvider1.SetError(opisInput, null);
        }

        private void CijenaInput_KeyPress(object sender, KeyPressEventArgs e)
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



        #endregion

        private void KategorijaComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (kategorijaComboBox.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(kategorijaComboBox, Messages.required);
            }
            else
                errorProvider1.SetError(kategorijaComboBox, null);
        }
    }
}
