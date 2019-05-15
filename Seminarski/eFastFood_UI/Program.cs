using eFastFood_UI.Administrator;
using eFastFood_UI.GotoviProizvodiUI;
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

            //ProizvodUI.ProizvodAdd form = new ProizvodUI.ProizvodAdd();
            //form.ShowDialog();


            //GotoviProizvodiIndex frm = new GotoviProizvodiIndex();
            //frm.ShowDialog();

            //GotoviProizvodiEdit frm = new GotoviProizvodiEdit();
            //frm.ShowDialog();

            //GotoviProizvodiAdd frm = new GotoviProizvodiAdd();
            //frm.ShowDialog();

            //KategorijaUI.KategorijaAdd kategorijaAdd = new KategorijaUI.KategorijaAdd();
            //kategorijaAdd.ShowDialog();

            //KategorijaUI.KategorijaEdit kategorijaEdit = new KategorijaUI.KategorijaEdit();
            //kategorijaEdit.ShowDialog();

            //Login frm = new Login();
            //frm.ShowDialog();

            //if (frm.DialogResult == DialogResult.OK && Global.prijavnjeniKorisnik.Uloga.Naziv == "Administrator")
            Application.Run(new MainFormAdmin());
        }
    }
}
