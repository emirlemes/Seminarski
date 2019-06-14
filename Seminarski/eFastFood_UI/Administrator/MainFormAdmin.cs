using eFastFood_UI.DobavljacUI;
using eFastFood_UI.GotoviProizvodiUI;
using eFastFood_UI.KategorijaUI;
using eFastFood_UI.KorisniciUI;
using eFastFood_UI.NarudzbeUI;
using eFastFood_UI.ProizvodUI;
using eFastFood_UI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFastFood_UI.Administrator
{
    public partial class MainFormAdmin : Form
    {
        APIHelper proizvodService = new APIHelper(Global.ApiUrl, Global.ProizvoidRoute);

        public MainFormAdmin()
        {
            InitializeComponent();
            notifyIcon.Icon = Icon;
            proizvodiToolStripMenuItem.PerformClick();
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
                HttpResponseMessage responeP = proizvodService.GetActionResponse("ProizvodiZaNarucit");

                if (responeP.IsSuccessStatusCode)
                {
                    List<string> vs = responeP.Content.ReadAsAsync<List<string>>().Result;

                    new Thread(() =>
                    {
                        foreach (var item in vs)
                        {
                            notifyIcon.Icon = SystemIcons.Information;
                            notifyIcon.BalloonTipText = Messages.product + item;
                            notifyIcon.Visible = true;
                            notifyIcon.BalloonTipTitle = Messages.need_to_order;
                            notifyIcon.ShowBalloonTip(1000);
                            Thread.Sleep(2000);
                        }
                    }).Start();


                }
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
