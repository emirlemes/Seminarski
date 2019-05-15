using eFastFood_PCL.Models;
using eFastFood_UI.Util;
using eFastFood_PCL.Helpers;
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

namespace eFastFood_UI.KategorijaUI
{
    public partial class KategorijaIndex : Form
    {
        APIHelper kategorijeService = new APIHelper(Global.ApiUrl, Global.KategorijaRoute);

        public KategorijaIndex()
        {
            InitializeComponent();
            kategorijeDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BindGrid();
        }

        private void BindGrid()
        {
            HttpResponseMessage response = kategorijeService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<Kategorija> kategorijeList = response.Content.ReadAsAsync<List<Kategorija>>().Result.ToList();
                kategorijeDataGridView.DataSource = kategorijeList;
            }
            else
            {
                this.Close();
                MessageBox.Show(Messages.error + ": " + response.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KategorijaAddbutton_Click(object sender, EventArgs e)
        {
            KategorijaAdd form = new KategorijaAdd();
            form.TopMost = true;

            if (form.ShowDialog() == DialogResult.OK)
                BindGrid();
        }

        private void KategorijaUrediButton_Click(object sender, EventArgs e)
        {
            int id = kategorijeDataGridView.SelectedRows[0].Cells[0].Value.ToInt();

            if (id == 0)
                MessageBox.Show(Messages.nothing_selected, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                KategorijaEdit form = new KategorijaEdit(id);
                if (form.ShowDialog() == DialogResult.OK)
                    BindGrid();
            }
        }
    }
}
