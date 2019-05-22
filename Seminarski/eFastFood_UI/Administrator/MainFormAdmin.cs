using eFastFood_UI.DobavljacUI;
using eFastFood_UI.GotoviProizvodiUI;
using eFastFood_UI.KategorijaUI;
using eFastFood_UI.KorisniciUI;
using eFastFood_UI.NarudzbeUI;
using eFastFood_UI.ProizvodUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFastFood_UI.Administrator
{
    public partial class MainFormAdmin : Form
    {
        public MainFormAdmin()
        {
            InitializeComponent();
        }

        private void KategorijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["KategorijaIndex"] as KategorijaIndex) != null)
            {
                //Forma otvorena
            }
            else
            {
                foreach (Form fr in this.MdiChildren)
                {
                    fr.Dispose();
                    fr.Close();
                }

                KategorijaIndex frm = new KategorijaIndex();
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
        }

        private void GotoviProizvodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["GotoviProizvodiIndex"] as GotoviProizvodiIndex) != null)
            {
                //Forma otvorena
            }
            else
            {
                foreach (Form fr in this.MdiChildren)
                {
                    fr.Dispose();
                    fr.Close();
                }

                GotoviProizvodiIndex frm = new GotoviProizvodiIndex
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                frm.Show();
            }
        }

        private void ProizvodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["ProizvodIndex"] as ProizvodIndex) != null)
            {
                //Forma otvorena
            }
            else
            {
                foreach (Form fr in this.MdiChildren)
                {
                    fr.Dispose();
                    fr.Close();
                }

                ProizvodIndex frm = new ProizvodIndex
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                frm.Show();
            }
        }

        private void DobavljačiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["DobavljacIndex"] as DobavljacIndex) != null)
            {
                //Forma otvorena
            }
            else
            {
                foreach (Form fr in this.MdiChildren)
                {
                    fr.Dispose();
                    fr.Close();
                }

                DobavljacIndex frm = new DobavljacIndex
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                frm.Show();
            }
        }

        private void KorisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if ((Application.OpenForms["KorisniciIndex"] as KorisniciIndex) != null)
            {
                //Forma otvorena
            }
            else
            {
                foreach (Form fr in this.MdiChildren)
                {
                    fr.Dispose();
                    fr.Close();
                }

                KorisniciIndex frm = new KorisniciIndex
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                frm.Show();
            }
        }

        private void NarudžbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["NarudzbeIndex"] as NarudzbeIndex) != null)
            {
                //Forma otvorena
            }
            else
            {
                foreach (Form fr in this.MdiChildren)
                {
                    fr.Dispose();
                    fr.Close();
                }

                NarudzbeIndex frm = new NarudzbeIndex
                {
                    MdiParent = this,
                    Dock = DockStyle.Fill
                };
                frm.Show();
            }
        }
    }
}
