using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFastFood_UI.GotoviProizvodi
{
    public partial class GotoviProizvodiAdd : Form
    {
        public GotoviProizvodiAdd()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void cijenaInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void OdustaniButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

            }
        }

        #region Validacija
        private void NazivInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nazivInput.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(nazivInput, Messages.empty_string);
            }
            else
                errorProvider1.SetError(nazivInput, null);
        }



        #endregion

        private void CijenaInput_Validating(object sender, CancelEventArgs e)
        {
            if (double.Parse(cijenaInput.Text) < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cijenaInput, Messages.negative_price);
            }
            else
                errorProvider1.SetError(cijenaInput, null);
        }
    }
}
