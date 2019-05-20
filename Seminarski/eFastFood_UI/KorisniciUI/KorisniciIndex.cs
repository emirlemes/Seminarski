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

namespace eFastFood_UI.KorisniciUI
{
    public partial class KorisniciIndex : Form
    {
        APIHelper klijentService = new APIHelper(Global.ApiUrl, Global.KlijentRoute);
        APIHelper uposleniciService = new APIHelper(Global.ApiUrl, Global.UposleniciRoute);
        APIHelper narudzbeService = new APIHelper(Global.ApiUrl, Global.NarudzbeRoute);

        List<KorisniciDataView> korisniciList = new List<KorisniciDataView>();

        public KorisniciIndex()
        {
            InitializeComponent();
            korisniciDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            korisniciDataGridView.AutoGenerateColumns = false;
        }

        private void KorisniciIndex_Load(object sender, EventArgs e)
        {
            BindGrid();
        }


        private void PretragaInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (klijentiRadioButton.Checked)
                korisniciDataGridView.DataSource = korisniciList.Where(x => x.ImePrezime.ToLower().Contains(pretragaInput.Text.ToLower()) && x.VrstaKorisnika == "klijent").ToList();
            else
                korisniciDataGridView.DataSource = korisniciList.Where(x => x.ImePrezime.ToLower().Contains(pretragaInput.Text.ToLower()) && x.VrstaKorisnika == "uposlenici").ToList();

        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            KorisniciAdd form = new KorisniciAdd();

            if (form.ShowDialog() == DialogResult.OK)
                BindGrid();
        }

        private void UrediButton_Click(object sender, EventArgs e)
        {
            if (uposleniciRadioButton.Checked)
            {
                int id = korisniciDataGridView.SelectedRows[0].Cells[0].Value.ToInt();
                if (id != 0)
                {
                    KorisniciEdit form = new KorisniciEdit(id);
                    if (form.ShowDialog() == DialogResult.OK)
                        BindGrid();
                }
                else
                    MessageBox.Show(Messages.nothing_selected, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show(Messages.employees_edit_only, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void KlijentiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (klijentiRadioButton.Checked)
                korisniciDataGridView.DataSource = korisniciList.Where(x => x.VrstaKorisnika == "klijent").ToList();
            else
                korisniciDataGridView.DataSource = korisniciList.Where(x => x.VrstaKorisnika == "uposlenici").ToList();

        }

        private void BindGrid()
        {

            HttpResponseMessage responseU = uposleniciService.GetResponse();

            HttpResponseMessage responseK = klijentService.GetResponse();

            HttpResponseMessage responseN = narudzbeService.GetActionResponse("BrojNarudzbiAll");


            List<Uposlenik> uposlenikList = new List<Uposlenik>();
            List<Klijent> klijentiList = new List<Klijent>();

            Dictionary<int, int> brojNarudzbi = new Dictionary<int, int>();

            if (responseN.IsSuccessStatusCode)
                brojNarudzbi = responseN.Content.ReadAsAsync<Dictionary<int, int>>().Result;
            else
                MessageBox.Show(Messages.error + ": " + responseN.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (responseU.IsSuccessStatusCode)
                uposlenikList = responseU.Content.ReadAsAsync<List<Uposlenik>>().Result;
            else
                MessageBox.Show(Messages.error + ": " + responseU.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (responseK.IsSuccessStatusCode)
                klijentiList = responseK.Content.ReadAsAsync<List<Klijent>>().Result;

            korisniciList = uposlenikList.Select(x => new KorisniciDataView()
            {
                KorisnikID = x.UposlenikID,
                ImePrezime = x.Ime + " " + x.Prezime,
                Uloga = x.Uloga.Naziv,
                Email = x.Email,
                BrojTelefona = x.BrojTelefona,
                BrojNarudzbi = 0,   //brojNarudzbi.TryGetValue(x.)
                Status = x.Status,
                VrstaKorisnika = "uposlenici",
            }).ToList();

            korisniciList.AddRange(klijentiList.Select(x => new KorisniciDataView()
            {
                KorisnikID = x.KlijentID,
                BrojNarudzbi = brojNarudzbi[x.KlijentID],
                BrojTelefona = x.BrojTelefona,
                Email = x.Email,
                ImePrezime = x.Ime + " " + x.Prezime,
                Status = x.Status,
                Uloga = x.Uloga.Naziv,
                VrstaKorisnika = "klijent",
            }).ToList());

            if (klijentiRadioButton.Checked)
                korisniciDataGridView.DataSource = korisniciList.Where(x => x.VrstaKorisnika == "klijent").ToList();
            else
                korisniciDataGridView.DataSource = korisniciList.Where(x => x.VrstaKorisnika == "uposlenici").ToList();
        }
    }
}
