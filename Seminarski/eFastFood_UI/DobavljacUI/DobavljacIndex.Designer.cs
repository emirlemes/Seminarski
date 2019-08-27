namespace eFastFood_UI.DobavljacUI
{
    partial class DobavljacIndex
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
            this.dobavljaciDataGridView = new System.Windows.Forms.DataGridView();
            this.DobavljacID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojTelefona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dodajButton = new System.Windows.Forms.Button();
            this.urediButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.obrisiButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dobavljaciDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dobavljaciDataGridView
            // 
            this.dobavljaciDataGridView.AllowUserToAddRows = false;
            this.dobavljaciDataGridView.AllowUserToDeleteRows = false;
            this.dobavljaciDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dobavljaciDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dobavljaciDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DobavljacID,
            this.Naziv,
            this.Adresa,
            this.BrojTelefona,
            this.Email});
            this.dobavljaciDataGridView.Location = new System.Drawing.Point(11, 49);
            this.dobavljaciDataGridView.Name = "dobavljaciDataGridView";
            this.dobavljaciDataGridView.ReadOnly = true;
            this.dobavljaciDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dobavljaciDataGridView.Size = new System.Drawing.Size(727, 398);
            this.dobavljaciDataGridView.TabIndex = 0;
            // 
            // DobavljacID
            // 
            this.DobavljacID.DataPropertyName = "DobavljacID";
            this.DobavljacID.HeaderText = "DobavljacID";
            this.DobavljacID.Name = "DobavljacID";
            this.DobavljacID.ReadOnly = true;
            this.DobavljacID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 160;
            // 
            // Adresa
            // 
            this.Adresa.DataPropertyName = "Adresa";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.Name = "Adresa";
            this.Adresa.ReadOnly = true;
            this.Adresa.Width = 170;
            // 
            // BrojTelefona
            // 
            this.BrojTelefona.DataPropertyName = "BrojTelefona";
            this.BrojTelefona.HeaderText = "Broj telefona";
            this.BrojTelefona.Name = "BrojTelefona";
            this.BrojTelefona.ReadOnly = true;
            this.BrojTelefona.Width = 150;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // dodajButton
            // 
            this.dodajButton.Location = new System.Drawing.Point(3, 3);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(130, 30);
            this.dodajButton.TabIndex = 1;
            this.dodajButton.Text = "Dodaj dobavljača";
            this.dodajButton.UseVisualStyleBackColor = true;
            this.dodajButton.Click += new System.EventHandler(this.DodajButton_Click);
            // 
            // urediButton
            // 
            this.urediButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.urediButton.Location = new System.Drawing.Point(346, 3);
            this.urediButton.Name = "urediButton";
            this.urediButton.Size = new System.Drawing.Size(100, 30);
            this.urediButton.TabIndex = 2;
            this.urediButton.Text = "Uredi";
            this.urediButton.UseVisualStyleBackColor = true;
            this.urediButton.Click += new System.EventHandler(this.UrediButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.obrisiButton);
            this.panel1.Controls.Add(this.dodajButton);
            this.panel1.Controls.Add(this.urediButton);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.MinimumSize = new System.Drawing.Size(727, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 40);
            this.panel1.TabIndex = 3;
            // 
            // obrisiButton
            // 
            this.obrisiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.obrisiButton.Location = new System.Drawing.Point(624, 3);
            this.obrisiButton.Name = "obrisiButton";
            this.obrisiButton.Size = new System.Drawing.Size(100, 30);
            this.obrisiButton.TabIndex = 3;
            this.obrisiButton.Text = "Obriši";
            this.obrisiButton.UseVisualStyleBackColor = true;
            this.obrisiButton.Click += new System.EventHandler(this.ObrisiButton_Click);
            // 
            // DobavljacIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 460);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dobavljaciDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(750, 460);
            this.Name = "DobavljacIndex";
            this.ShowIcon = false;
            this.Text = "Dobavljači";
            this.Load += new System.EventHandler(this.DobavljacIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dobavljaciDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dobavljaciDataGridView;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.Button urediButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn DobavljacID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojTelefona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button obrisiButton;
    }
}