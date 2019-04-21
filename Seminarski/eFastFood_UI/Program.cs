using eFastFood_UI.Administrator;
using eFastFood_UI.Kuhinja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFastFood_UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login frm = new Login();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK && Global.prijavnjeniKorisnik.Uloga.Naziv == "Administrator")
                Application.Run(new MainFormAdmin());
            else if (frm.DialogResult == DialogResult.OK && Global.prijavnjeniKorisnik.Uloga.Naziv == "Kuhinja")
                Application.Run(new MainFormKuhinja());
        }
    }
}
