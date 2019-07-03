using eFastFood_PCL.Helpers;
using eFastFood_PCL.Models;
using eFastFood_PCL.ViewModel;
using eFastFood_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFastFood_UI.IzvjestajiUI
{
    public partial class NarudzbeIzvjestaj : Form
    {
        private APIHelper narudzbeService = new APIHelper(Global.ApiUrl, Global.NarudzbeRoute);
        private APIHelper klijentiService = new APIHelper(Global.ApiUrl, Global.KlijentRoute);

        private DateTime now { get; set; } = DateTime.Now;

        public NarudzbeIzvjestaj()
        {
            InitializeComponent();
            IzvjestajDataGrid.AutoGenerateColumns = false;
            odDateTime.Value = now;
            doDateTime.Value = now;
        }

        private void NarudzbeIzvjestaj_Load(object sender, EventArgs e)
        {
            HttpResponseMessage responseK = klijentiService.GetResponse();

            if (responseK.IsSuccessStatusCode)
            {
                List<Klijent> klijenti = responseK.Content.ReadAsAsync<List<Klijent>>().Result;
                List<ComboItem> items = klijenti.Select(x => new ComboItem() { ID = x.KlijentID, Text = x.Ime + " " + x.Prezime }).OrderBy(x => x.Text).ToList();
                items.Insert(0, new ComboItem() { ID = 0, Text = "Svi" });
                korisnicComboBox.DataSource = items;
                korisnicComboBox.SelectedIndex = 0;
            }
            else
                MessageBox.Show(responseK.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            LoadData(now.ToDateApiString(), now.ToDateApiString());
        }

        private void LoadData(string dateOD, string dateDO, int klijentId = 0)
        {
            HttpResponseMessage responseN = klijentId == 0 ? narudzbeService.GetActionResponse("Izvjestaj", dateOD + "/" + dateDO) : narudzbeService.GetActionResponse("Izvjestaj", dateOD + "/" + dateDO + "/" + klijentId.ToString());

            if (responseN.IsSuccessStatusCode)
            {
                List<NarudzbeIzvjestajVM> vs = responseN.Content.ReadAsAsync<List<NarudzbeIzvjestajVM>>().Result;
                IzvjestajDataGrid.DataSource = dostavaCheckBox.Checked ? vs.Where(x => x.VrstaNarudzbe == "Dostava").ToList() : vs;
            }
            else
                MessageBox.Show(responseN.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void OsvjeziButton_Click(object sender, EventArgs e)
        {
            string dateOD = odDateTime.Value.Date.ToDateApiString();
            string dateDO = doDateTime.Value.Date.ToDateApiString();

            int korisnikId = korisnicComboBox.SelectedValue.ToInt();

            LoadData(dateOD, dateDO, korisnikId);
        }

        private void PrintajButton_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument;

            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            if (printDialog.ShowDialog() == DialogResult.OK)
                printDocument.Print();
        }

        private void printDocument_PrintPage(object s, PrintPageEventArgs e)
        {
            List<NarudzbeIzvjestajVM> list = IzvjestajDataGrid.DataSource as List<NarudzbeIzvjestajVM>;

            Graphics g = e.Graphics;

            Font font = new Font("Courier New", 12);
            SolidBrush brush = new SolidBrush(Color.Black);

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            string crtice = "------------------------------------------------";

            g.DrawString("Izvještaj o narudžbama", font, brush, startX, startY);
            g.DrawString("Za period od: " + odDateTime.Value.ToDateApiString() + "      Do: " + doDateTime.Value.ToDateApiString(), font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            g.DrawString(crtice, font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;

            float totalPrice = 0;


            foreach (var item in list)
            {
                string proizvod = item.Narucio.PadRight(20);
                string datum = item.Datum.ToDateApiString().PadRight(20);
                string total = String.Format("{0:c}", item.Cijena);
                string linija = proizvod + datum + total;
                totalPrice += (float)item.Cijena;
                g.DrawString(linija, font, brush, startX, startY + offset);

                offset = offset + (int)fontHeight + 5;
            }

            offset = offset + 20;
            g.DrawString(crtice, font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            g.DrawString("Ukupno:".PadRight(40) + String.Format("{0:c}", totalPrice), font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            g.DrawString(crtice, font, brush, startX, startY + offset);

        }
    }
}
