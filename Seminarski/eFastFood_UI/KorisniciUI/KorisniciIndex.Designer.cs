namespace eFastFood_UI.KorisniciUI
{
    partial class KorisniciIndex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DodajButton = new System.Windows.Forms.Button();
            this.urediButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pretragaInput = new System.Windows.Forms.TextBox();
            this.korisniciDataGridView = new System.Windows.Forms.DataGridView();
            this.KorisnikID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImePrezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uloga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojTelefona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojNarudzbi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.uposleniciRadioButton = new System.Windows.Forms.RadioButton();
            this.klijentiRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.korisniciDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DodajButton
            // 
            this.DodajButton.Location = new System.Drawing.Point(3, 17);
            this.DodajButton.Name = "DodajButton";
            this.DodajButton.Size = new System.Drawing.Size(150, 30);
            this.DodajButton.TabIndex = 0;
            this.DodajButton.Text = "Dodaj uposlenika";
            this.DodajButton.UseVisualStyleBackColor = true;
            this.DodajButton.Click += new System.EventHandler(this.DodajButton_Click);
            // 
            // urediButton
            // 
            this.urediButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.urediButton.Location = new System.Drawing.Point(646, 17);
            this.urediButton.Name = "urediButton";
            this.urediButton.Size = new System.Drawing.Size(100, 30);
            this.urediButton.TabIndex = 1;
            this.urediButton.Text = "Uredi";
            this.urediButton.UseVisualStyleBackColor = true;
            this.urediButton.Click += new System.EventHandler(this.UrediButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pretraga";
            // 
            // pretragaInput
            // 
            this.pretragaInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pretragaInput.Location = new System.Drawing.Point(241, 21);
            this.pretragaInput.Name = "pretragaInput";
            this.pretragaInput.Size = new System.Drawing.Size(399, 23);
            this.pretragaInput.TabIndex = 3;
            this.pretragaInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PretragaInput_KeyUp);
            // 
            // korisniciDataGridView
            // 
            this.korisniciDataGridView.AllowUserToAddRows = false;
            this.korisniciDataGridView.AllowUserToDeleteRows = false;
            this.korisniciDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.korisniciDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.korisniciDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikID,
            this.ImePrezime,
            this.Uloga,
            this.Email,
            this.BrojTelefona,
            this.BrojNarudzbi,
            this.Status});
            this.korisniciDataGridView.Location = new System.Drawing.Point(12, 107);
            this.korisniciDataGridView.Name = "korisniciDataGridView";
            this.korisniciDataGridView.ReadOnly = true;
            this.korisniciDataGridView.Size = new System.Drawing.Size(749, 364);
            this.korisniciDataGridView.TabIndex = 4;
            // 
            // KorisnikID
            // 
            this.KorisnikID.DataPropertyName = "KorisnikID";
            this.KorisnikID.HeaderText = "KorinikID";
            this.KorisnikID.Name = "KorisnikID";
            this.KorisnikID.ReadOnly = true;
            this.KorisnikID.Visible = false;
            // 
            // ImePrezime
            // 
            this.ImePrezime.DataPropertyName = "ImePrezime";
            this.ImePrezime.HeaderText = "Ime prezime";
            this.ImePrezime.Name = "ImePrezime";
            this.ImePrezime.ReadOnly = true;
            this.ImePrezime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ImePrezime.Width = 130;
            // 
            // Uloga
            // 
            this.Uloga.DataPropertyName = "Uloga";
            this.Uloga.HeaderText = "Uloga";
            this.Uloga.Name = "Uloga";
            this.Uloga.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // BrojTelefona
            // 
            this.BrojTelefona.DataPropertyName = "BrojTelefona";
            this.BrojTelefona.HeaderText = "Broj telefona";
            this.BrojTelefona.Name = "BrojTelefona";
            this.BrojTelefona.ReadOnly = true;
            this.BrojTelefona.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BrojTelefona.Width = 130;
            // 
            // BrojNarudzbi
            // 
            this.BrojNarudzbi.DataPropertyName = "BrojNarudzbi";
            this.BrojNarudzbi.HeaderText = "Narudžbe";
            this.BrojNarudzbi.Name = "BrojNarudzbi";
            this.BrojNarudzbi.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Status.Width = 70;
            // 
            // uposleniciRadioButton
            // 
            this.uposleniciRadioButton.AutoSize = true;
            this.uposleniciRadioButton.Location = new System.Drawing.Point(277, 12);
            this.uposleniciRadioButton.Name = "uposleniciRadioButton";
            this.uposleniciRadioButton.Size = new System.Drawing.Size(91, 21);
            this.uposleniciRadioButton.TabIndex = 5;
            this.uposleniciRadioButton.Text = "Uposlenici";
            this.uposleniciRadioButton.UseVisualStyleBackColor = true;
            // 
            // klijentiRadioButton
            // 
            this.klijentiRadioButton.AutoSize = true;
            this.klijentiRadioButton.Checked = true;
            this.klijentiRadioButton.Location = new System.Drawing.Point(3, 12);
            this.klijentiRadioButton.Name = "klijentiRadioButton";
            this.klijentiRadioButton.Size = new System.Drawing.Size(67, 21);
            this.klijentiRadioButton.TabIndex = 6;
            this.klijentiRadioButton.TabStop = true;
            this.klijentiRadioButton.Text = "Klijenti";
            this.klijentiRadioButton.UseVisualStyleBackColor = true;
            this.klijentiRadioButton.CheckedChanged += new System.EventHandler(this.KlijentiRadioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.klijentiRadioButton);
            this.panel1.Controls.Add(this.uposleniciRadioButton);
            this.panel1.Location = new System.Drawing.Point(241, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 45);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.DodajButton);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.urediButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pretragaInput);
            this.panel2.Location = new System.Drawing.Point(12, 6);
            this.panel2.MinimumSize = new System.Drawing.Size(749, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(749, 95);
            this.panel2.TabIndex = 8;
            // 
            // KorisniciIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 483);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.korisniciDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KorisniciIndex";
            this.Text = "Korisnici";
            this.Load += new System.EventHandler(this.KorisniciIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.korisniciDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DodajButton;
        private System.Windows.Forms.Button urediButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pretragaInput;
        private System.Windows.Forms.DataGridView korisniciDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImePrezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uloga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojTelefona;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojNarudzbi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.RadioButton uposleniciRadioButton;
        private System.Windows.Forms.RadioButton klijentiRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}