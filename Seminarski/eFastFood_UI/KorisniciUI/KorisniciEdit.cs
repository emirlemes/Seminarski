using eFastFood_PCL.Helpers;
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

namespace eFastFood_UI.KorisniciUI
{
    public partial class KorisniciEdit : Form
    {
        APIHelper uposleniciService = new APIHelper(Global.ApiUrl, Global.UposleniciRoute);
        APIHelper ulogeService = new APIHelper(Global.ApiUrl, Global.UlogeRoute);

        Uposlenik uEdit { get; set; }

        public KorisniciEdit(int id)
        {
            HttpResponseMessage reponseU = uposleniciService.GetResponse(id.ToString());
            HttpResponseMessage reponseUL = ulogeService.GetResponse();

            if (reponseU.IsSuccessStatusCode)
                uEdit = reponseU.Content.ReadAsAsync<Uposlenik>().Result;
            else
                MessageBox.Show(Messages.error + ": " + reponseU.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (reponseUL.IsSuccessStatusCode)
                ulogeComboBox.DataSource = reponseUL.Content.ReadAsAsync<List<Uloga>>().Result.Select(x => new ComboItem() { ID = x.UlogaID, Text = x.Naziv }).ToList();
            else
                MessageBox.Show(Messages.error + ": " + reponseUL.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            InitializeComponent();
            AutoValidate = AutoValidate.Disable;
        }

        private void KorisniciEdit_Load(object sender, EventArgs e)
        {
            imeInput.Text = uEdit.Ime;
            prezimeInput.Text = uEdit.Prezime;
            korisnickoImeInput.Text = uEdit.UserName;
            brojTelefonaInput.Text = uEdit.BrojTelefona;
            emailInput.Text = uEdit.Email;
            statusCheckBox.Checked = uEdit.Status;
            ulogeComboBox.SelectedValue = uEdit.UlogaID;
        }

        private void SnimiButton_Click(object sender, EventArgs e)
        {

        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }
}
