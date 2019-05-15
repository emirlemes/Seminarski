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
        readonly APIHelper gotoviProizvodiService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);

        readonly APIHelper kategorrijaService = new APIHelper(Global.ApiUrl, Global.KategorijaRoute);

        readonly APIHelper mjerneJediniceService = new APIHelper(Global.ApiUrl, Global.MjernaJedinicaRoute);

        readonly APIHelper proizvodiService = new APIHelper(Global.ApiUrl, Global.ProizvoidRoute);

        readonly APIHelper gpProizvodService = new APIHelper(Global.ApiUrl, Global.GPProizvodRoute);

        GotoviProizvod gp = new GotoviProizvod();

        public GotoviProizvodiAdd()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void GotoviProizvodiAdd_Load(object sender, EventArgs e)
        {
            HttpResponseMessage responseK = kategorrijaService.GetResponse();
            HttpResponseMessage responseP = proizvodiService.GetResponse();
            HttpResponseMessage responseM = mjerneJediniceService.GetResponse();

            if (responseK.IsSuccessStatusCode)
            {
                List<Kategorija> kategorije = responseK.Content.ReadAsAsync<List<Kategorija>>().Result;

                kategorijaComboBox.DataSource = kategorije.Select(x => new ComboItem(x.KategorijaID, x.Naziv)).ToList();
            }
            else
                MessageBox.Show(Messages.error + ": " + responseK.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            List<GPProizvodDataSet> dataGridList = new List<GPProizvodDataSet>();


            if (responseP.IsSuccessStatusCode && responseM.IsSuccessStatusCode)
            {
                List<Proizvod> proizvodiList = responseP.Content.ReadAsAsync<List<Proizvod>>().Result;
                List<MjernaJedinica> mjernaJedinicaList = responseM.Content.ReadAsAsync<List<MjernaJedinica>>().Result;

                foreach (var item in proizvodiList)
                {
                    dataGridList.Add(new GPProizvodDataSet()
                    {
                        ProizvodID = item.ProizvodID,
                        Dodaj = false,
                        ProizvodNaziv = item.Naziv,
                        Kolicina = 0,
                    });
                }
                DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn
                {
                    HeaderText = "Mjerne jedinice",
                    DataSource = mjernaJedinicaList.Select(x => new ComboItem() { ID = x.MjernaJedinicaID, Text = x.Naziv }).ToList(),
                    DisplayMember = "Text",
                    ValueMember = "ID",
                    Resizable = DataGridViewTriState.False
                };

                sastojciDataGridView.Columns.Add(column);

                sastojciDataGridView.DataSource = dataGridList;
            }
            else
                MessageBox.Show(Messages.error + ": " + responseK.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                List<GPProizvod> gppList = new List<GPProizvod>();

                try
                {

                    foreach (DataGridViewRow row in sastojciDataGridView.Rows)
                    {
                        if (row.Cells[1].Value.ToBool())
                        {
                            if (row.Cells[4].Value.ToInt() == 0)
                                throw new Exception("MjernaJedinicaID");
                            // dodaj Za koji proizvod fali
                            gppList.Add(new GPProizvod()
                            {
                                ProizvodID = row.Cells[0].Value.ToInt(),
                                KolicinaUtroska = row.Cells[3].Value.ToDecimal(),
                                MjernaJedinicaID = row.Cells[4].Value.ToInt(),
                            });
                        }
                    }
                    if (gppList.Count == 0)
                        throw new Exception("NijeOdabranoNista");

                    gp.Cijena = cijenaInput.Text.ToDecimal();
                    gp.KategorijaID = (int)kategorijaComboBox.SelectedValue;
                    gp.Opis = opisInput.Text;
                    gp.VrijemePripreme = vrijemePripremeInput.Text.ToInt();
                    gp.Naziv = nazivInput.Text;
                    gp.Opis = opisInput.Text;

                    if (string.IsNullOrEmpty(slikaInput.Text))
                    {
                        gp.Slika = UIHelper.AddDefaultPictureFull();
                        gp.SlikaUmanjeno = UIHelper.AddDefaultPictureResized();
                    }
                    else
                    {
                        gp.Slika = UIHelper.AddFromFileFull(slikaInput.Text);
                        gp.SlikaUmanjeno = UIHelper.AddFromFileResized(slikaInput.Text);
                    }

                    HttpResponseMessage responseGP = gotoviProizvodiService.PostResponse(gp);

                    if (responseGP.IsSuccessStatusCode)
                    {
                        gp = responseGP.Content.ReadAsAsync<GotoviProizvod>().Result;
                        gppList.ForEach(x => x.GotoviProizvodID = gp.GotoviProizvodID);
                        HttpResponseMessage responseGPP = gpProizvodService.PostActionResponse("GPProizvodList", gppList);

                        if (responseGPP.IsSuccessStatusCode)
                        {
                            this.Close();
                            MessageBox.Show(Messages.success_add, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(Messages.error + ": " + responseGPP.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                        MessageBox.Show(Messages.error + ": " + responseGP.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (Exception k)
                {
                    if (k.Message == "MjernaJedinicaID")
                        MessageBox.Show(Messages.mj_not_selected, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (k.Message == "NijeOdabranoNista")
                        MessageBox.Show(Messages.nothing_selected_product, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SlikaButton_Click(object sender, EventArgs e)
        {
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "jpg files(*.jpg)|*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image orgImg = Image.FromFile(openFileDialog.FileName);

                if (orgImg.Width > Global.ResizeWidth && orgImg.Height > Global.ResizeHeight)
                    slikaInput.Text = openFileDialog.FileName;
                else
                    MessageBox.Show(Messages.picture_to_small, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            if (!string.IsNullOrEmpty(cijenaInput.Text))
            {
                if (double.Parse(cijenaInput.Text) < 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(cijenaInput, Messages.negative_price);
                }
                else
                    errorProvider1.SetError(cijenaInput, null);
            }
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

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



        #endregion

    }
}
