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

namespace eFastFood_UI.DobavljacUI
{
    public partial class DobavljacIndex : Form
    {
        APIHelper dobavljacService = new APIHelper(Global.ApiUrl, Global.DobavljacRoute);

        List<Dobavljac> dobavljaciList;
        public DobavljacIndex()
        {
            InitializeComponent();
            BindGrid();
        }

        private void DobavljacIndex_Load(object sender, EventArgs e)
        {

        }

        private void BindGrid()
        {
            HttpResponseMessage reponseD = dobavljacService.GetResponse();

            if (reponseD.IsSuccessStatusCode)
            {
                dobavljaciList = reponseD.Content.ReadAsAsync<List<Dobavljac>>().Result.ToList();
                dobavljaciDataGridView.DataSource = dobavljaciList;
            }
            else
            {
                Close();
                MessageBox.Show(Messages.error + ": " + reponseD.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            DobavljacAdd form = new DobavljacAdd();
            if (form.ShowDialog() == DialogResult.OK)
                BindGrid();
        }

        private void UrediButton_Click(object sender, EventArgs e)
        {
            int id = dobavljaciDataGridView.SelectedRows[0].Cells[0].Value.ToInt();

            if (id == 0)
                MessageBox.Show(Messages.nothing_selected, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DobavljacEdit form = new DobavljacEdit(id);

                if (form.ShowDialog() == DialogResult.OK)
                    BindGrid();
            }
        }

        private void ObrisiButton_Click(object sender, EventArgs e)
        {
            int id = dobavljaciDataGridView.SelectedRows[0].Cells[0].Value.ToInt();
            if (id == 0)
                MessageBox.Show(Messages.nothing_selected, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                HttpResponseMessage responseD = dobavljacService.DeleteResponse(id.ToString());
                if (responseD.IsSuccessStatusCode)
                {
                    MessageBox.Show(Messages.success_deleted, Messages.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGrid();
                }
                else
                {
                    ErrorMessage m = responseD.Content.ReadAsAsync<ErrorMessage>().Result;

                    MessageBox.Show(responseD.ReasonPhrase + ": " + m.Message, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
