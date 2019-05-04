using eFastFood_UI.Administrator;
using eFastFood_UI.GotoviProizvodi;
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

            GotoviProizvodiAdd frm= new GotoviProizvodiAdd();
            frm.ShowDialog();

            //Login frm = new Login();
            //frm.ShowDialog();

            //if (frm.DialogResult == DialogResult.OK && Global.prijavnjeniKorisnik.Uloga.Naziv == "Administrator")
            //    Application.Run(new MainFormAdmin());
        }
    }
}
