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

namespace eFastFood_UI.NarudzbeUI
{
    public partial class NarudzbeIndex : Form
    {
        APIHelper narudzbeService = new APIHelper(Global.ApiUrl, Global.NarudzbeRoute);

        List<Narudzba> narudzbeNove = new List<Narudzba>();
        List<Narudzba> narudzbeUPripremi = new List<Narudzba>();
        List<Narudzba> narudzbeZavrsene = new List<Narudzba>();

        public NarudzbeIndex()
        {
            InitializeComponent();
            noveDataGridView.AutoGenerateColumns = false;
            pripremaDataGridView.AutoGenerateColumns = false;
            zavrseneDataGridView.AutoGenerateColumns = false;
        }

        private void NarudzbeIndex_Load(object sender, EventArgs e)
        {
            BindGridNove();
        }


        private void NarudzbeTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (narudzbeTabControl.SelectedIndex == 0)
                BindGridNove();
            else if (narudzbeTabControl.SelectedIndex == 1)
                BindGridUPripremi();
            else if (narudzbeTabControl.SelectedIndex == 2)
                BindGridZavrsene();
        }

        private void BindGridNove()
        {
            HttpResponseMessage responseN = narudzbeService.GetActionResponse("GetNoveNarudzbe");
            if (responseN.IsSuccessStatusCode)
            {
                narudzbeNove = responseN.Content.ReadAsAsync<List<Narudzba>>().Result;
                noveDataGridView.DataSource = narudzbeNove.Select(x => new NarudzbaDataView()
                {
                    NarudzbaID = x.NarudzbaID,
                    Cijena = x.UkupnaCijena,
                    Datum = x.Datum.ToString("dd/MM/yyyy HH:mm"),
                    Narucilac = x.Klijent.Ime + " " + x.Klijent.Prezime,
                    VrstaNarudzbe = x.VrstaNarudzbe,
                }).ToList();
            }
            else
                MessageBox.Show(Messages.error + ": " + responseN.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BindGridUPripremi()
        {
            HttpResponseMessage responseN = narudzbeService.GetActionResponse("GetUPripremiNarudzbe");
            if (responseN.IsSuccessStatusCode)
            {
                narudzbeUPripremi = responseN.Content.ReadAsAsync<List<Narudzba>>().Result;
                pripremaDataGridView.DataSource = narudzbeUPripremi.Select(x => new NarudzbaDataView()
                {
                    NarudzbaID = x.NarudzbaID,
                    Cijena = x.UkupnaCijena,
                    Datum = x.Datum.ToString("dd/MM/yyyy HH:mm"),
                    Narucilac = x.Klijent.Ime + " " + x.Klijent.Prezime,
                    VrstaNarudzbe = x.VrstaNarudzbe,
                }).ToList();
            }
            else
                MessageBox.Show(Messages.error + ": " + responseN.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BindGridZavrsene()
        {
            HttpResponseMessage responseN = narudzbeService.GetActionResponse("GetZavrseneNarudzbe");
            if (responseN.IsSuccessStatusCode)
            {
                narudzbeZavrsene = responseN.Content.ReadAsAsync<List<Narudzba>>().Result;
                zavrseneDataGridView.DataSource = narudzbeZavrsene.Select(x => new NarudzbaDataView()
                {
                    NarudzbaID = x.NarudzbaID,
                    Cijena = x.UkupnaCijena,
                    Datum = x.Datum.ToString("dd/MM/yyyy HH:mm"),
                    Narucilac = x.Klijent.Ime + " " + x.Klijent.Prezime,
                    VrstaNarudzbe = x.VrstaNarudzbe,
                }).ToList();
            }
            else
                MessageBox.Show(Messages.error + ": " + responseN.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NoveDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int id = noveDataGridView.Rows[e.RowIndex].Cells[0].Value.ToInt();
                if (id == 0)
                    MessageBox.Show(Messages.order_id_error, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {

                    HttpResponseMessage responseN = narudzbeService.GetActionResponse("PrebaciUPripremu", id.ToString());
                    if (responseN.IsSuccessStatusCode)
                    {
                        //Dodati sistem za notifikacije za android OVDJE
                        BindGridNove();
                    }
                    else
                        MessageBox.Show(Messages.error + ": " + responseN.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (e.ColumnIndex == 6)
            {
                int id = noveDataGridView.Rows[e.RowIndex].Cells[0].Value.ToInt();
                if (id == 0)
                    MessageBox.Show(Messages.order_id_error, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    HttpResponseMessage responseN = narudzbeService.GetActionResponse("GetStavkeNarudzbe", id.ToString());
                    if (responseN.IsSuccessStatusCode)
                    {
                        List<NarudzbaStavka> list = responseN.Content.ReadAsAsync<List<NarudzbaStavka>>().Result;
                        DetaljiNarudzbe form = new DetaljiNarudzbe(list);
                        form.ShowDialog();
                    }
                    else
                        MessageBox.Show(Messages.error + ": " + responseN.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PripremaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int id = pripremaDataGridView.Rows[e.RowIndex].Cells[0].Value.ToInt();
                if (id == 0)
                    MessageBox.Show(Messages.order_id_error, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    HttpResponseMessage responseN = narudzbeService.GetActionResponse("PrebaciUZavrsi", id.ToString());
                    if (responseN.IsSuccessStatusCode)
                    {
                        //Dodati sistem za notifikacije za android OVDJE
                        BindGridUPripremi();
                    }
                    else
                        MessageBox.Show(Messages.error + ": " + responseN.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.ColumnIndex == 6)
            {
                int id = pripremaDataGridView.Rows[e.RowIndex].Cells[0].Value.ToInt();
                if (id == 0)
                    MessageBox.Show(Messages.order_id_error, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    HttpResponseMessage responseN = narudzbeService.GetActionResponse("GetStavkeNarudzbe", id.ToString());
                    if (responseN.IsSuccessStatusCode)
                    {
                        List<NarudzbaStavka> list = responseN.Content.ReadAsAsync<List<NarudzbaStavka>>().Result;
                        DetaljiNarudzbe form = new DetaljiNarudzbe(list);
                        form.ShowDialog();
                    }
                    else
                        MessageBox.Show(Messages.error + ": " + responseN.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ZavrseneDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int id = zavrseneDataGridView.Rows[e.RowIndex].Cells[0].Value.ToInt();
                if (id == 0)
                    MessageBox.Show(Messages.order_id_error, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    HttpResponseMessage responseN = narudzbeService.GetActionResponse("GetStavkeNarudzbe", id.ToString());
                    if (responseN.IsSuccessStatusCode)
                    {
                        List<NarudzbaStavka> list = responseN.Content.ReadAsAsync<List<NarudzbaStavka>>().Result;
                        DetaljiNarudzbe form = new DetaljiNarudzbe(list);
                        form.ShowDialog();
                    }
                    else
                        MessageBox.Show(Messages.error + ": " + responseN.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
