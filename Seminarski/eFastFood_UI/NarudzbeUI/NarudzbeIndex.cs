using eFastFood_PCL.Models;
using eFastFood_PCL.Helpers;
using eFastFood_UI.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using System.Drawing.Printing;

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
            odbijeneDataGridView.AutoGenerateColumns = false;

            noveDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pripremaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            zavrseneDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            odbijeneDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            noveDataGridView.MultiSelect = false;
            pripremaDataGridView.MultiSelect = false;
            zavrseneDataGridView.MultiSelect = false;
            odbijeneDataGridView.MultiSelect = false;
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
            else if (narudzbeTabControl.SelectedIndex == 3)
                BindGridOdbijene();
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

        private void BindGridOdbijene()
        {
            HttpResponseMessage responseN = narudzbeService.GetActionResponse("GetOdbijeneNarudzbe");
            if (responseN.IsSuccessStatusCode)
            {
                narudzbeNove = responseN.Content.ReadAsAsync<List<Narudzba>>().Result;
                odbijeneDataGridView.DataSource = narudzbeNove.Select(x => new NarudzbaDataView()
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
                        BindGridNove();
                    }
                    else
                    {
                        ErrorMessage m = responseN.Content.ReadAsAsync<ErrorMessage>().Result;
                        MessageBox.Show(Messages.error + ": " + m.Message, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

            }
            else if (e.ColumnIndex == 6)
            {
                int id = noveDataGridView.Rows[e.RowIndex].Cells[0].Value.ToInt();
                if (id == 0)
                    MessageBox.Show(Messages.order_id_error, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DetaljiView(id);
                }
            }
            else if (e.ColumnIndex == 7)
            {
                int id = noveDataGridView.Rows[e.RowIndex].Cells[0].Value.ToInt();
                if (id == 0)
                    MessageBox.Show(Messages.order_id_error, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    HttpResponseMessage responseN = narudzbeService.GetActionResponse("PrebaciUOdbijene", id.ToString());
                    if (responseN.IsSuccessStatusCode)
                        BindGridNove();
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
                    DetaljiView(id);
                }
            }
            else if (e.ColumnIndex == 6)
            {
                int id = zavrseneDataGridView.Rows[e.RowIndex].Cells[0].Value.ToInt();
                if (id == 0)
                    MessageBox.Show(Messages.order_id_error, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    PrintDocument printDocument = new PrintDocument();

                    printDialog.Document = printDocument;
                    printDocument.PrintPage += new PrintPageEventHandler((s, k) => printDocument_PrintPage(s, k, id));
                    if (printDialog.ShowDialog() == DialogResult.OK)
                        printDocument.Print();
                }
            }
        }

        private void OdbijeneDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int id = odbijeneDataGridView.Rows[e.RowIndex].Cells[0].Value.ToInt();
                if (id == 0)
                    MessageBox.Show(Messages.order_id_error, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    DetaljiView(id);
            }
        }

        private void DetaljiView(int id)
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

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e, int id)
        {
            Graphics g = e.Graphics;

            Font font = new Font("Courier New", 12);
            SolidBrush brush = new SolidBrush(Color.Black);

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            g.DrawString("Dobrodošli u restoran", font, brush, startX, startY);
            g.DrawString("--------------------------------------", font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            HttpResponseMessage responseN = narudzbeService.GetActionResponse("GetStavkeNarudzbe", id.ToString());

            float totalPrice = 0;

            if (responseN.IsSuccessStatusCode)
            {
                var stavke = responseN.Content.ReadAsAsync<List<NarudzbaStavka>>().Result;

                foreach (var item in stavke)
                {
                    string proizvod = item.GotoviProizvod.Naziv.PadRight(30);
                    g.DrawString(proizvod, font, brush, startX, startY + offset);
                    offset = offset + (int)fontHeight + 5;
                    string total = String.Format("{0}X", item.Kolicina).PadRight(15) + String.Format("{0:c}", item.GotoviProizvod.Cijena).PadRight(15) + String.Format("{0:c}", (item.Kolicina * item.GotoviProizvod.Cijena));
                    item.GotoviProizvod.Cijena.ToString().PadRight(8);
                    totalPrice += (float)item.GotoviProizvod.Cijena * item.Kolicina;
                    g.DrawString(total, font, brush, startX, startY + offset);

                    offset = offset + (int)fontHeight + 5;
                }

                offset = offset + 20;
                g.DrawString("--------------------------------------", font, brush, startX, startY + offset);
                offset = offset + (int)fontHeight + 5;
                g.DrawString("Za platiti:".PadRight(30) + String.Format("{0:c}", totalPrice), font, brush, startX, startY + offset);
                offset = offset + (int)fontHeight + 5;
                g.DrawString("--------------------------------------", font, brush, startX, startY + offset);
                offset = offset + (int)fontHeight + 5;
                g.DrawString("Hvala na posjeti".PadLeft(15), font, brush, startX, startY + offset);
            }
        }


    }

    public class ErrorMessage
    {
        public string Message { get; set; }
    }
}
