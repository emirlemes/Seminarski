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
    public partial class KorisniciIndex : Form
    {
        APIHelper korisniciService = new APIHelper(Global.ApiUrl, Global.KorisniciRoute);
        APIHelper uposleniciService = new APIHelper(Global.ApiUrl, Global.UposleniciRoute);
        APIHelper narudzbeService = new APIHelper(Global.ApiUrl, Global.NarudzbeRoute);

        List<KorisniciDataView> korisniciList = new List<KorisniciDataView>();

        public KorisniciIndex()
        {
            InitializeComponent();
            korisniciDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void KorisniciIndex_Load(object sender, EventArgs e)
        {
            //TO DO: SVE U JEDNU LIST KOJA CE SE PRIKAZIVAT

            HttpResponseMessage reponseU = uposleniciService.GetResponse();

            HttpResponseMessage reponseN = narudzbeService.GetActionResponse("BrojNarudzbiAll");


            List<Uposlenik> uposlenikList = new List<Uposlenik>();
            Dictionary<int, int> brojNarudzbi = new Dictionary<int, int>();

            if (reponseN.IsSuccessStatusCode)
                brojNarudzbi = reponseN.Content.ReadAsAsync<Dictionary<int, int>>().Result;
            else
                MessageBox.Show(Messages.error + ": " + reponseN.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (reponseU.IsSuccessStatusCode)
                uposlenikList = reponseU.Content.ReadAsAsync<List<Uposlenik>>().Result;
            else
                MessageBox.Show(Messages.error + ": " + reponseU.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            korisniciList = uposlenikList.Select(x => new KorisniciDataView()
            {
                KorisnikID = x.UposlenikID,
                ImePrezime = x.Ime + " " + x.Prezime,
                Uloga = x.Uloga.Naziv,
                Email = x.Email,
                BrojTelefona = x.BrojTelefona,
                BrojNarudzbi = 0,   //brojNarudzbi.TryGetValue(x.)
                Status = x.Status
            }).ToList();

            korisniciDataGridView.DataSource = korisniciList;
        }


        private void PretragaInput_KeyUp(object sender, KeyEventArgs e)
        {
            korisniciDataGridView.DataSource = korisniciList.Where(x => x.ImePrezime.ToLower().Contains(pretragaInput.Text.ToLower())).ToList();
        }
    }
}
