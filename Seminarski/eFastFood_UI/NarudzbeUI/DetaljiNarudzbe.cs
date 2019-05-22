using eFastFood_PCL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFastFood_UI.NarudzbeUI
{
    public partial class DetaljiNarudzbe : Form
    {
        public DetaljiNarudzbe(List<NarudzbaStavka> lista)
        {
            InitializeComponent();
            stavkeDataGridView.DataSource = lista.Select(x => new { Naziv = x.GotoviProizvod.Naziv, Kolicina = x.Kolicina }).ToList();
        }
    }
}
