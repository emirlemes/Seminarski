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

namespace eFastFood_UI.ProizvodUI
{
    public partial class ProizvodNaruci : Form
    {
        APIHelper proizvodService = new APIHelper(Global.ApiUrl, Global.ProizvoidRoute);

        private int _id;

        private Proizvod proizvodNaruciti { get; set; }

        public ProizvodNaruci(int id)
        {
            _id = id;
            InitializeComponent();
        }
        private void ProizvodNaruci_Load(object sender, EventArgs e)
        {
            HttpResponseMessage responseP = proizvodService.GetResponse(_id.ToString());

            if (responseP.IsSuccessStatusCode)
            {
                proizvodNaruciti = responseP.Content.ReadAsAsync<Proizvod>().Result;
                mjernajedinicaLabel.Text = proizvodNaruciti.MjernaJedinica.Naziv;
                proizvodName.Text = proizvodNaruciti.Naziv;
            }
            else
            {
                MessageBox.Show(responseP.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void NaruciButton_Click(object sender, EventArgs e)
        {
            string order = _id.ToString() + ":" + kolicinaInput.Text;
            HttpResponseMessage responseP = proizvodService.PostActionResponse("NaruciProizvod", order);

            if (responseP.IsSuccessStatusCode)
            {
                MessageBox.Show(Messages.success_order, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show(responseP.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void KolicinaInput_KeyPress(object sender, KeyPressEventArgs e) =>
          e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

    }
}
