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
    public partial class ProizvodEdit : Form
    {
        APIHelper proizvodiService = new APIHelper(Global.ApiUrl, Global.ProizvoidRoute);

        APIHelper mjernaJedinicaService = new APIHelper(Global.ApiUrl, Global.MjernaJedinicaRoute);

        APIHelper dobavljacService = new APIHelper(Global.ApiUrl, Global.DobavljacRoute);

        Proizvod proizvodEdit = new Proizvod();

        List<Dobavljac> dobavljaciList = new List<Dobavljac>();
        List<MjernaJedinica> mjernaJedinicaList = new List<MjernaJedinica>();

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
                mjernaJedinicaList = responseMJ.Content.ReadAsAsync<List<MjernaJedinica>>().Result;
            else
                MessageBox.Show(Messages.error + ": " + responseMJ.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (responseD.IsSuccessStatusCode)
                dobavljaciList = responseD.Content.ReadAsAsync<List<Dobavljac>>().Result;
            else
                MessageBox.Show(Messages.error + ": " + responseD.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (!(responseMJ.IsSuccessStatusCode && responseD.IsSuccessStatusCode && responseP.IsSuccessStatusCode))
                Close();
        }

        private void ProizvodEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
