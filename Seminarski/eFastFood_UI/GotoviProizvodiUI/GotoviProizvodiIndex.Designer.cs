namespace eFastFood_UI.GotoviProizvodiUI
{
    partial class GotoviProizvodiIndex
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
            this.gotoviPDataGridView = new System.Windows.Forms.DataGridView();
            this.GotoviProizvodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrijemePripreme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlikaUmanjeno = new System.Windows.Forms.DataGridViewImageColumn();
            this.KategorijaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kategorija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dodajButton = new System.Windows.Forms.Button();
            this.urediButton = new System.Windows.Forms.Button();
            this.pretragaInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gotoviPDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gotoviPDataGridView
            // 
            this.gotoviPDataGridView.AllowUserToAddRows = false;
            this.gotoviPDataGridView.AllowUserToDeleteRows = false;
            this.gotoviPDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gotoviPDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gotoviPDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GotoviProizvodID,
            this.Naziv,
            this.Opis,
            this.Cijena,
            this.VrijemePripreme,
            this.SlikaUmanjeno,
            this.KategorijaID,
            this.Slika,
            this.Kategorija});
            this.gotoviPDataGridView.Location = new System.Drawing.Point(16, 69);
            this.gotoviPDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.gotoviPDataGridView.Name = "gotoviPDataGridView";
            this.gotoviPDataGridView.ReadOnly = true;
            this.gotoviPDataGridView.RowTemplate.Height = 256;
            this.gotoviPDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gotoviPDataGridView.Size = new System.Drawing.Size(861, 470);
            this.gotoviPDataGridView.TabIndex = 0;
            // 
            // GotoviProizvodID
            // 
            this.GotoviProizvodID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GotoviProizvodID.DataPropertyName = "GotoviProizvodID";
            this.GotoviProizvodID.HeaderText = "GotoviProizvodID";
            this.GotoviProizvodID.Name = "GotoviProizvodID";
            this.GotoviProizvodID.ReadOnly = true;
            this.GotoviProizvodID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GotoviProizvodID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Naziv.Width = 130;
            // 
            // Opis
            // 
            this.Opis.DataPropertyName = "Opis";
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            this.Opis.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Opis.Width = 170;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            this.Cijena.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // VrijemePripreme
            // 
            this.VrijemePripreme.DataPropertyName = "VrijemePripreme";
            this.VrijemePripreme.HeaderText = "Vrijeme pripreme";
            this.VrijemePripreme.Name = "VrijemePripreme";
            this.VrijemePripreme.ReadOnly = true;
            this.VrijemePripreme.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VrijemePripreme.Width = 150;
            // 
            // SlikaUmanjeno
            // 
            this.SlikaUmanjeno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SlikaUmanjeno.DataPropertyName = "SlikaUmanjeno";
            this.SlikaUmanjeno.HeaderText = "Slika";
            this.SlikaUmanjeno.MinimumWidth = 256;
            this.SlikaUmanjeno.Name = "SlikaUmanjeno";
            this.SlikaUmanjeno.ReadOnly = true;
            this.SlikaUmanjeno.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // KategorijaID
            // 
            this.KategorijaID.DataPropertyName = "KategorijaID";
            this.KategorijaID.HeaderText = "KategorijaID";
            this.KategorijaID.Name = "KategorijaID";
            this.KategorijaID.ReadOnly = true;
            this.KategorijaID.Visible = false;
            // 
            // Slika
            // 
            this.Slika.DataPropertyName = "Slika";
            this.Slika.HeaderText = "Slika";
            this.Slika.Name = "Slika";
            this.Slika.ReadOnly = true;
            this.Slika.Visible = false;
            // 
            // Kategorija
            // 
            this.Kategorija.DataPropertyName = "Kategorija";
            this.Kategorija.HeaderText = "Kategorija";
            this.Kategorija.Name = "Kategorija";
            this.Kategorija.ReadOnly = true;
            this.Kategorija.Visible = false;
            // 
            // dodajButton
            // 
            this.dodajButton.Location = new System.Drawing.Point(16, 25);
            this.dodajButton.Margin = new System.Windows.Forms.Padding(4);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(100, 30);
            this.dodajButton.TabIndex = 0;
            this.dodajButton.Text = "Dodaj novi";
            this.dodajButton.UseVisualStyleBackColor = true;
            this.dodajButton.Click += new System.EventHandler(this.DodajButton_Click);
            // 
            // urediButton
            // 
            this.urediButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.urediButton.Location = new System.Drawing.Point(777, 25);
            this.urediButton.Margin = new System.Windows.Forms.Padding(4);
            this.urediButton.Name = "urediButton";
            this.urediButton.Size = new System.Drawing.Size(100, 30);
            this.urediButton.TabIndex = 2;
            this.urediButton.Text = "Uredi";
            this.urediButton.UseVisualStyleBackColor = true;
            this.urediButton.Click += new System.EventHandler(this.UrediButton_Click);
            // 
            // pretragaInput
            // 
            this.pretragaInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pretragaInput.Location = new System.Drawing.Point(283, 29);
            this.pretragaInput.Name = "pretragaInput";
            this.pretragaInput.Size = new System.Drawing.Size(308, 23);
            this.pretragaInput.TabIndex = 1;
            this.pretragaInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PretragaInput_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pretraga";
            // 
            // GotoviProizvodiIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pretragaInput);
            this.Controls.Add(this.urediButton);
            this.Controls.Add(this.dodajButton);
            this.Controls.Add(this.gotoviPDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GotoviProizvodiIndex";
            this.ShowIcon = false;
            this.Text = "Gotovi proizvodi";
            this.Load += new System.EventHandler(this.GotoviProizvodiIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gotoviPDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gotoviPDataGridView;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.Button urediButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn GotoviProizvodID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrijemePripreme;
        private System.Windows.Forms.DataGridViewImageColumn SlikaUmanjeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn KategorijaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slika;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kategorija;
        private System.Windows.Forms.TextBox pretragaInput;
        private System.Windows.Forms.Label label1;
    }
}