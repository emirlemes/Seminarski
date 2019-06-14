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

namespace eFastFood_UI.ProizvodUI
{
    public partial class ProizvodIndex : Form
    {
        APIHelper proizvodiService = new APIHelper(Global.ApiUrl, Global.ProizvoidRoute);

        List<Proizvod> proizvodList = new List<Proizvod>();
        public ProizvodIndex()
        {
            InitializeComponent();
            proizvodiDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ProizvodIndex_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void PretragaInput_KeyUp(object sender, KeyEventArgs e)
        {
            proizvodiDataGridView.DataSource = proizvodList.Where(x => x.Naziv.ToLower().StartsWith(pretragaInput.Text.ToLower()));
        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            ProizvodAdd frm = new ProizvodAdd();
            if (frm.ShowDialog() == DialogResult.OK)
                BindGrid();
        }

        private void UrediButton_Click(object sender, EventArgs e)
        {
            int id = proizvodiDataGridView.SelectedRows[0].Cells[0].Value.ToInt();
            if (id == 0)
                MessageBox.Show(Messages.nothing_selected, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                ProizvodEdit frm = new ProizvodEdit(id);
                if (frm.ShowDialog() == DialogResult.OK)
                    BindGrid();
            }
        }

        private void BindGrid()
        {
            HttpResponseMessage reponseP = proizvodiService.GetResponse();

            if (reponseP.IsSuccessStatusCode)
            {
                proizvodList = reponseP.Content.ReadAsAsync<List<Proizvod>>().Result;
                proizvodiDataGridView.DataSource = proizvodList;
            }
        }

        private void NaruciButton_Click(object sender, EventArgs e)
        {
            int id = proizvodiDataGridView.SelectedRows[0].Cells[0].Value.ToInt();
            if (id == 0)
                MessageBox.Show(Messages.nothing_selected, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                ProizvodNaruci form = new ProizvodNaruci(id);
                form.ShowDialog();
            }
        }
    }
}
