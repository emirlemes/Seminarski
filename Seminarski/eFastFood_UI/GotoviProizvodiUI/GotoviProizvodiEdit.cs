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
using System.Windows.Forms;

namespace eFastFood_UI.GotoviProizvodiUI
{
    public partial class GotoviProizvodiEdit : Form
    {
        APIHelper gotoviProizvodiService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);
        APIHelper kategorijeService = new APIHelper(Global.ApiUrl, Global.KategorijaRoute);
        APIHelper mjerneJediniceService = new APIHelper(Global.ApiUrl, Global.MjernaJedinicaRoute);
        APIHelper gpproizvodService = new APIHelper(Global.ApiUrl, Global.GPProizvodRoute);
        APIHelper proizvodiService = new APIHelper(Global.ApiUrl, Global.ProizvoidRoute);

        private GotoviProizvod gotoviProizvod { get; set; }

        public GotoviProizvodiEdit(int id)
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;

            HttpResponseMessage responseGP = gotoviProizvodiService.GetResponse(id.ToString());

            if (responseGP.IsSuccessStatusCode)
                gotoviProizvod = responseGP.Content.ReadAsAsync<GotoviProizvod>().Result;

            else if (responseGP.StatusCode == System.Net.HttpStatusCode.NotFound)
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
            else
                MessageBox.Show(Messages.error + ": " + responseK.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);



            HttpResponseMessage responseGPP = gpproizvodService.GetActionResponse("SastojciByGPID", gotoviProizvod.GotoviProizvodID.ToString());

            List<GPProizvod> gppList = new List<GPProizvod>();

            if (responseGPP.IsSuccessStatusCode)
                gppList = responseGPP.Content.ReadAsAsync<List<GPProizvod>>().Result.ToList();
            else
                MessageBox.Show(Messages.error + ": " + responseGPP.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            HttpResponseMessage responseP = proizvodiService.GetResponse();
            HttpResponseMessage responseM = mjerneJediniceService.GetResponse();

            List<GPProizvodDataSet> dataGridList = new List<GPProizvodDataSet>();

            if (responseP.IsSuccessStatusCode && responseM.IsSuccessStatusCode)
            {
                List<Proizvod> proizvodiList = responseP.Content.ReadAsAsync<List<Proizvod>>().Result;
                List<MjernaJedinica> mjernaJedinicaList = responseM.Content.ReadAsAsync<List<MjernaJedinica>>().Result;
                DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

                column.DataSource = mjernaJedinicaList.Select(x => new ComboItem() { ID = x.MjernaJedinicaID, Text = x.Naziv }).ToList();
                column.HeaderText = "Mjerna jedinica";
                column.DisplayMember = "Text";
                column.ValueMember = "ID";

                sastojciDataGridView.Columns.Add(column);

                foreach (var item in proizvodiList)
                {
                    decimal utrosak = gppList.Where(x => x.GotoviProizvodID == gotoviProizvod.GotoviProizvodID && x.ProizvodID == item.ProizvodID).FirstOrDefault()?.KolicinaUtroska ?? new decimal(0);
                    int idMJ = gppList.Where(x => x.GotoviProizvodID == gotoviProizvod.GotoviProizvodID && x.ProizvodID == item.ProizvodID).FirstOrDefault()?.MjernaJedinicaID ?? 0;

                    int rowId = sastojciDataGridView.Rows.Add(item.ProizvodID, utrosak != 0 ? true : false, item.Naziv, utrosak);
                    if (idMJ != 0)
                        sastojciDataGridView.Rows[rowId].Cells[4].Value = idMJ;
                }
            }
            else
            {
                if (!responseM.IsSuccessStatusCode)
                    MessageBox.Show(Messages.error + ": " + responseM.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!responseP.IsSuccessStatusCode)
                    MessageBox.Show(Messages.error + ": " + responseP.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SnimiButton_Click(object sender, EventArgs e)
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
                                throw new Exception("MjernaJedinicaID:" + row.Cells[2].Value.ToString());

                            gppList.Add(new GPProizvod()
                            {
                                GotoviProizvodID = gotoviProizvod.GotoviProizvodID,
                                ProizvodID = row.Cells[0].Value.ToInt(),
                                KolicinaUtroska = row.Cells[3].Value.ToDecimal(),
                                MjernaJedinicaID = row.Cells[4].Value.ToInt(),
                            });
                        }
                    }
                    if (gppList.Count == 0)
                        throw new Exception("NijeOdabranoNista");


                    gotoviProizvod.KategorijaID = kategorijaComboBox.SelectedValue.ToInt();
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

                    HttpResponseMessage responseGP = gotoviProizvodiService.PutResponse(gotoviProizvod.GotoviProizvodID, gotoviProizvod);

                    HttpResponseMessage responseGPP = gpproizvodService.PutActionResponse("GPProizvodListEdit", gotoviProizvod.GotoviProizvodID, gppList);


                    if (responseGP.IsSuccessStatusCode && responseGPP.IsSuccessStatusCode)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                        MessageBox.Show(Messages.success_edited, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (!responseGP.IsSuccessStatusCode)
                            MessageBox.Show(Messages.error, Messages.error + ": " + responseGP.ReasonPhrase, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (!responseGPP.IsSuccessStatusCode)
                            MessageBox.Show(Messages.error, Messages.error + ": " + responseGPP.ReasonPhrase, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception k)
                {
                    if (k.Message.Split(':')[0] == "MjernaJedinicaID")
                        MessageBox.Show(Messages.mj_not_selected + k.Message.Split(':')[1], Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (k.Message == "NijeOdabranoNista")
                        MessageBox.Show(Messages.nothing_selected_product, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }


        private void NazivInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nazivInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(nazivInput, Messages.empty_string);
            }
            else if (nazivInput.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider.SetError(nazivInput, Messages.string_length50);
            }
            else
                errorProvider.SetError(nazivInput, null);
        }

        private void CijenaInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cijenaInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(cijenaInput, Messages.empty_string);
            }
            else if (cijenaInput.Text.ToDecimal() < 0)
            {
                e.Cancel = true;
                errorProvider.SetError(cijenaInput, Messages.negative_price);
            }
            else
                errorProvider.SetError(cijenaInput, null);
        }

        private void OpisInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(opisInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(opisInput, Messages.empty_string);
            }
            else if (opisInput.Text.Length > 200)
            {
                e.Cancel = true;
                errorProvider.SetError(opisInput, Messages.string_length200);
            }
            else
                errorProvider.SetError(opisInput, null);
        }

        private void KategorijaComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (kategorijaComboBox.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider.SetError(kategorijaComboBox, Messages.required);
            }
            else
                errorProvider.SetError(kategorijaComboBox, null);
        }

        #endregion

    }
}
