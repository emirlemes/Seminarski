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

namespace eFastFood_UI.GotoviProizvodiUI
{
    public partial class GotoviProizvodiIndex : Form
    {
        APIHelper gotoviProizvodiService = new APIHelper(Global.ApiUrl, Global.GotoviProizvodRoute);

        List<GotoviProizvod> gotiviPList = new List<GotoviProizvod>();

        public GotoviProizvodiIndex()
        {
            InitializeComponent();
            gotoviPDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void GotoviProizvodiIndex_Load(object sender, EventArgs e)
        {
            HttpResponseMessage reposneGP = gotoviProizvodiService.GetResponse();

            if (reposneGP.IsSuccessStatusCode)
            {
                gotiviPList = reposneGP.Content.ReadAsAsync<List<GotoviProizvod>>().Result;
                gotoviPDataGridView.DataSource = gotiviPList;
            }
            else
            {
                MessageBox.Show(Messages.error + ": " + reposneGP.ReasonPhrase, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void PretragaInput_KeyUp(object sender, KeyEventArgs e)
        {
            gotoviPDataGridView.DataSource = gotiviPList.Where(x => x.Naziv.ToLower().StartsWith(pretragaInput.Text.ToLower())).ToList();
        }

        private void UrediButton_Click(object sender, EventArgs e)
        {
            int id = gotoviPDataGridView.SelectedRows[0].Cells[0].Value.ToInt();
            if (id == 0)
                MessageBox.Show(Messages.nothing_selected, Messages.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                GotoviProizvodiEdit frm = new GotoviProizvodiEdit(id);
                frm.ShowDialog();
            }
        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            GotoviProizvodiAdd frm = new GotoviProizvodiAdd();
            frm.ShowDialog();
        }
    }
}
