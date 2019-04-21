using eFastFood_API.Models;
using eFastFood_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFastFood_UI
{
    public partial class Login : Form
    {
        private APIHelper usersService = new APIHelper(ConfigurationSettings.AppSettings["APIAddress"].ToString(), Global.UposleniciRoute);

        public Login()
        {
            InitializeComponent();
        }

        private void  Prijava()
        {
            HttpResponseMessage response = usersService.GetActionResponse("GetUposlenikByUsername", korisnickoImeInput.Text);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                MessageBox.Show(Messages.login_user_err, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            else if (response.IsSuccessStatusCode)
            {
                Uposlenik korisnik = response.Content.ReadAsAsync<Uposlenik>().Result;

                if (Hashing.GenerateHash(korisnik.LozinkaSalt, korisnickoImeInput.Text) == korisnik.LozinkaHash)
                {
                    this.DialogResult = DialogResult.OK;
                    Global.prijavnjeniKorisnik = korisnik;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Messages.login_user_err, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error Code: " + response.StatusCode + " Message: " + response.ReasonPhrase);
            }
        }
        private void prijava_Click(object sender, EventArgs e)
        {
            Prijava();
        }

        private void odustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void prijava_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Prijava();
        }
    }
}
