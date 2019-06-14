namespace eFastFood_UI.NarudzbeUI
{
    partial class NarudzbeIndex
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
            this.components = new System.ComponentModel.Container();
            this.narudzbeTabControl = new System.Windows.Forms.TabControl();
            this.noveTabPage = new System.Windows.Forms.TabPage();
            this.noveDataGridView = new System.Windows.Forms.DataGridView();
            this.NarudzbaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrstaNarudzbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narucilac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priprema = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pripremaTabPage = new System.Windows.Forms.TabPage();
            this.pripremaDataGridView = new System.Windows.Forms.DataGridView();
            this.Akcija = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DetaljiUP = new System.Windows.Forms.DataGridViewButtonColumn();
            this.zavrseneTabPage = new System.Windows.Forms.TabPage();
            this.zavrseneDataGridView = new System.Windows.Forms.DataGridView();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.narudzbaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vrstaNarudzbeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.narucilacDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cijenaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.narudzbaDataViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.narudzbaIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vrstaNarudzbeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.narucilacDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cijenaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetaljiZ = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Printaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.narudzbeTabControl.SuspendLayout();
            this.noveTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noveDataGridView)).BeginInit();
            this.pripremaTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pripremaDataGridView)).BeginInit();
            this.zavrseneTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zavrseneDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.narudzbaDataViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // narudzbeTabControl
            // 
            this.narudzbeTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.narudzbeTabControl.Controls.Add(this.noveTabPage);
            this.narudzbeTabControl.Controls.Add(this.pripremaTabPage);
            this.narudzbeTabControl.Controls.Add(this.zavrseneTabPage);
            this.narudzbeTabControl.Location = new System.Drawing.Point(10, 10);
            this.narudzbeTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.narudzbeTabControl.Name = "narudzbeTabControl";
            this.narudzbeTabControl.SelectedIndex = 0;
            this.narudzbeTabControl.Size = new System.Drawing.Size(705, 490);
            this.narudzbeTabControl.TabIndex = 0;
            this.narudzbeTabControl.SelectedIndexChanged += new System.EventHandler(this.NarudzbeTabControl_SelectedIndexChanged);
            // 
            // noveTabPage
            // 
            this.noveTabPage.Controls.Add(this.noveDataGridView);
            this.noveTabPage.Location = new System.Drawing.Point(4, 25);
            this.noveTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.noveTabPage.Name = "noveTabPage";
            this.noveTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.noveTabPage.Size = new System.Drawing.Size(697, 461);
            this.noveTabPage.TabIndex = 0;
            this.noveTabPage.Text = "Nove ";
            this.noveTabPage.UseVisualStyleBackColor = true;
            // 
            // noveDataGridView
            // 
            this.noveDataGridView.AllowUserToAddRows = false;
            this.noveDataGridView.AllowUserToDeleteRows = false;
            this.noveDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.noveDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NarudzbaID,
            this.VrstaNarudzbe,
            this.Narucilac,
            this.Cijena,
            this.Datum,
            this.Priprema,
            this.Detalji});
            this.noveDataGridView.Location = new System.Drawing.Point(7, 7);
            this.noveDataGridView.Name = "noveDataGridView";
            this.noveDataGridView.ReadOnly = true;
            this.noveDataGridView.RowTemplate.Height = 25;
            this.noveDataGridView.Size = new System.Drawing.Size(683, 441);
            this.noveDataGridView.TabIndex = 0;
            this.noveDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NoveDataGridView_CellClick);
            // 
            // NarudzbaID
            // 
            this.NarudzbaID.DataPropertyName = "NarudzbaID";
            this.NarudzbaID.HeaderText = "NarudzbaID";
            this.NarudzbaID.Name = "NarudzbaID";
            this.NarudzbaID.ReadOnly = true;
            this.NarudzbaID.Visible = false;
            // 
            // VrstaNarudzbe
            // 
            this.VrstaNarudzbe.DataPropertyName = "VrstaNarudzbe";
            this.VrstaNarudzbe.HeaderText = "Vrsta narudžbe";
            this.VrstaNarudzbe.Name = "VrstaNarudzbe";
            this.VrstaNarudzbe.ReadOnly = true;
            this.VrstaNarudzbe.Width = 130;
            // 
            // Narucilac
            // 
            this.Narucilac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Narucilac.DataPropertyName = "Narucilac";
            this.Narucilac.HeaderText = "Naručio";
            this.Narucilac.Name = "Narucilac";
            this.Narucilac.ReadOnly = true;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            this.Cijena.Width = 70;
            // 
            // Datum
            // 
            this.Datum.DataPropertyName = "Datum";
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            this.Datum.Width = 130;
            // 
            // Priprema
            // 
            this.Priprema.HeaderText = "Akcija";
            this.Priprema.Name = "Priprema";
            this.Priprema.ReadOnly = true;
            this.Priprema.Text = "U pripremu";
            this.Priprema.UseColumnTextForButtonValue = true;
            // 
            // Detalji
            // 
            this.Detalji.HeaderText = "Detalji";
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            this.Detalji.Text = "Detalji";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // pripremaTabPage
            // 
            this.pripremaTabPage.Controls.Add(this.pripremaDataGridView);
            this.pripremaTabPage.Location = new System.Drawing.Point(4, 25);
            this.pripremaTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.pripremaTabPage.Name = "pripremaTabPage";
            this.pripremaTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.pripremaTabPage.Size = new System.Drawing.Size(697, 461);
            this.pripremaTabPage.TabIndex = 1;
            this.pripremaTabPage.Text = "U pripremi";
            this.pripremaTabPage.UseVisualStyleBackColor = true;
            // 
            // pripremaDataGridView
            // 
            this.pripremaDataGridView.AllowUserToAddRows = false;
            this.pripremaDataGridView.AllowUserToDeleteRows = false;
            this.pripremaDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pripremaDataGridView.AutoGenerateColumns = false;
            this.pripremaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pripremaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.narudzbaIDDataGridViewTextBoxColumn,
            this.vrstaNarudzbeDataGridViewTextBoxColumn,
            this.narucilacDataGridViewTextBoxColumn,
            this.cijenaDataGridViewTextBoxColumn,
            this.datumDataGridViewTextBoxColumn,
            this.Akcija,
            this.DetaljiUP});
            this.pripremaDataGridView.DataSource = this.narudzbaDataViewBindingSource;
            this.pripremaDataGridView.Location = new System.Drawing.Point(7, 7);
            this.pripremaDataGridView.Name = "pripremaDataGridView";
            this.pripremaDataGridView.ReadOnly = true;
            this.pripremaDataGridView.RowTemplate.Height = 25;
            this.pripremaDataGridView.Size = new System.Drawing.Size(683, 447);
            this.pripremaDataGridView.TabIndex = 0;
            this.pripremaDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PripremaDataGridView_CellClick);
            // 
            // Akcija
            // 
            this.Akcija.HeaderText = "Akcija";
            this.Akcija.Name = "Akcija";
            this.Akcija.ReadOnly = true;
            this.Akcija.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Akcija.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Akcija.Text = "Završi";
            this.Akcija.UseColumnTextForButtonValue = true;
            // 
            // DetaljiUP
            // 
            this.DetaljiUP.HeaderText = "Detalji";
            this.DetaljiUP.Name = "DetaljiUP";
            this.DetaljiUP.ReadOnly = true;
            this.DetaljiUP.Text = "Detalji";
            this.DetaljiUP.UseColumnTextForButtonValue = true;
            // 
            // zavrseneTabPage
            // 
            this.zavrseneTabPage.Controls.Add(this.zavrseneDataGridView);
            this.zavrseneTabPage.Location = new System.Drawing.Point(4, 25);
            this.zavrseneTabPage.Name = "zavrseneTabPage";
            this.zavrseneTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.zavrseneTabPage.Size = new System.Drawing.Size(697, 461);
            this.zavrseneTabPage.TabIndex = 2;
            this.zavrseneTabPage.Text = "Završene";
            this.zavrseneTabPage.UseVisualStyleBackColor = true;
            // 
            // zavrseneDataGridView
            // 
            this.zavrseneDataGridView.AllowUserToAddRows = false;
            this.zavrseneDataGridView.AllowUserToDeleteRows = false;
            this.zavrseneDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zavrseneDataGridView.AutoGenerateColumns = false;
            this.zavrseneDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zavrseneDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.narudzbaIDDataGridViewTextBoxColumn1,
            this.vrstaNarudzbeDataGridViewTextBoxColumn1,
            this.narucilacDataGridViewTextBoxColumn1,
            this.cijenaDataGridViewTextBoxColumn1,
            this.datumDataGridViewTextBoxColumn1,
            this.DetaljiZ,
            this.Printaj});
            this.zavrseneDataGridView.DataSource = this.narudzbaDataViewBindingSource;
            this.zavrseneDataGridView.Location = new System.Drawing.Point(6, 6);
            this.zavrseneDataGridView.Name = "zavrseneDataGridView";
            this.zavrseneDataGridView.ReadOnly = true;
            this.zavrseneDataGridView.RowTemplate.Height = 25;
            this.zavrseneDataGridView.Size = new System.Drawing.Size(685, 449);
            this.zavrseneDataGridView.TabIndex = 0;
            this.zavrseneDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ZavrseneDataGridView_CellClick);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // narudzbaIDDataGridViewTextBoxColumn
            // 
            this.narudzbaIDDataGridViewTextBoxColumn.DataPropertyName = "NarudzbaID";
            this.narudzbaIDDataGridViewTextBoxColumn.HeaderText = "NarudzbaID";
            this.narudzbaIDDataGridViewTextBoxColumn.Name = "narudzbaIDDataGridViewTextBoxColumn";
            this.narudzbaIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.narudzbaIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // vrstaNarudzbeDataGridViewTextBoxColumn
            // 
            this.vrstaNarudzbeDataGridViewTextBoxColumn.DataPropertyName = "VrstaNarudzbe";
            this.vrstaNarudzbeDataGridViewTextBoxColumn.HeaderText = "Vrsta narudžbe";
            this.vrstaNarudzbeDataGridViewTextBoxColumn.Name = "vrstaNarudzbeDataGridViewTextBoxColumn";
            this.vrstaNarudzbeDataGridViewTextBoxColumn.ReadOnly = true;
            this.vrstaNarudzbeDataGridViewTextBoxColumn.Width = 130;
            // 
            // narucilacDataGridViewTextBoxColumn
            // 
            this.narucilacDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.narucilacDataGridViewTextBoxColumn.DataPropertyName = "Narucilac";
            this.narucilacDataGridViewTextBoxColumn.HeaderText = "Naručio";
            this.narucilacDataGridViewTextBoxColumn.Name = "narucilacDataGridViewTextBoxColumn";
            this.narucilacDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cijenaDataGridViewTextBoxColumn
            // 
            this.cijenaDataGridViewTextBoxColumn.DataPropertyName = "Cijena";
            this.cijenaDataGridViewTextBoxColumn.HeaderText = "Cijena";
            this.cijenaDataGridViewTextBoxColumn.Name = "cijenaDataGridViewTextBoxColumn";
            this.cijenaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cijenaDataGridViewTextBoxColumn.Width = 70;
            // 
            // datumDataGridViewTextBoxColumn
            // 
            this.datumDataGridViewTextBoxColumn.DataPropertyName = "Datum";
            this.datumDataGridViewTextBoxColumn.HeaderText = "Datum";
            this.datumDataGridViewTextBoxColumn.Name = "datumDataGridViewTextBoxColumn";
            this.datumDataGridViewTextBoxColumn.ReadOnly = true;
            this.datumDataGridViewTextBoxColumn.Width = 130;
            // 
            // narudzbaDataViewBindingSource
            // 
            this.narudzbaDataViewBindingSource.DataSource = typeof(eFastFood_UI.NarudzbeUI.NarudzbaDataView);
            // 
            // narudzbaIDDataGridViewTextBoxColumn1
            // 
            this.narudzbaIDDataGridViewTextBoxColumn1.DataPropertyName = "NarudzbaID";
            this.narudzbaIDDataGridViewTextBoxColumn1.HeaderText = "NarudzbaID";
            this.narudzbaIDDataGridViewTextBoxColumn1.Name = "narudzbaIDDataGridViewTextBoxColumn1";
            this.narudzbaIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.narudzbaIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // vrstaNarudzbeDataGridViewTextBoxColumn1
            // 
            this.vrstaNarudzbeDataGridViewTextBoxColumn1.DataPropertyName = "VrstaNarudzbe";
            this.vrstaNarudzbeDataGridViewTextBoxColumn1.HeaderText = "Vrsta narudžbe";
            this.vrstaNarudzbeDataGridViewTextBoxColumn1.Name = "vrstaNarudzbeDataGridViewTextBoxColumn1";
            this.vrstaNarudzbeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.vrstaNarudzbeDataGridViewTextBoxColumn1.Width = 130;
            // 
            // narucilacDataGridViewTextBoxColumn1
            // 
            this.narucilacDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.narucilacDataGridViewTextBoxColumn1.DataPropertyName = "Narucilac";
            this.narucilacDataGridViewTextBoxColumn1.HeaderText = "Naručio";
            this.narucilacDataGridViewTextBoxColumn1.Name = "narucilacDataGridViewTextBoxColumn1";
            this.narucilacDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cijenaDataGridViewTextBoxColumn1
            // 
            this.cijenaDataGridViewTextBoxColumn1.DataPropertyName = "Cijena";
            this.cijenaDataGridViewTextBoxColumn1.HeaderText = "Cijena";
            this.cijenaDataGridViewTextBoxColumn1.Name = "cijenaDataGridViewTextBoxColumn1";
            this.cijenaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.cijenaDataGridViewTextBoxColumn1.Width = 70;
            // 
            // datumDataGridViewTextBoxColumn1
            // 
            this.datumDataGridViewTextBoxColumn1.DataPropertyName = "Datum";
            this.datumDataGridViewTextBoxColumn1.HeaderText = "Datum";
            this.datumDataGridViewTextBoxColumn1.Name = "datumDataGridViewTextBoxColumn1";
            this.datumDataGridViewTextBoxColumn1.ReadOnly = true;
            this.datumDataGridViewTextBoxColumn1.Width = 130;
            // 
            // DetaljiZ
            // 
            this.DetaljiZ.HeaderText = "Detalji";
            this.DetaljiZ.Name = "DetaljiZ";
            this.DetaljiZ.ReadOnly = true;
            this.DetaljiZ.Text = "Detalji";
            this.DetaljiZ.UseColumnTextForButtonValue = true;
            // 
            // Printaj
            // 
            this.Printaj.HeaderText = "Printaj račun";
            this.Printaj.Name = "Printaj";
            this.Printaj.ReadOnly = true;
            this.Printaj.Text = "Printaj račun";
            this.Printaj.UseColumnTextForButtonValue = true;
            // 
            // NarudzbeIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 510);
            this.Controls.Add(this.narudzbeTabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NarudzbeIndex";
            this.Text = "NarudzbeIndex";
            this.Load += new System.EventHandler(this.NarudzbeIndex_Load);
            this.narudzbeTabControl.ResumeLayout(false);
            this.noveTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.noveDataGridView)).EndInit();
            this.pripremaTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pripremaDataGridView)).EndInit();
            this.zavrseneTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zavrseneDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.narudzbaDataViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl narudzbeTabControl;
        private System.Windows.Forms.TabPage noveTabPage;
        private System.Windows.Forms.DataGridView noveDataGridView;
        private System.Windows.Forms.TabPage pripremaTabPage;
        private System.Windows.Forms.DataGridView pripremaDataGridView;
        private System.Windows.Forms.TabPage zavrseneTabPage;
        private System.Windows.Forms.DataGridView zavrseneDataGridView;
        private System.Windows.Forms.BindingSource narudzbaDataViewBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn NarudzbaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrstaNarudzbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Narucilac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewButtonColumn Priprema;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.DataGridViewTextBoxColumn narudzbaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vrstaNarudzbeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn narucilacDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cijenaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Akcija;
        private System.Windows.Forms.DataGridViewButtonColumn DetaljiUP;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn narudzbaIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn vrstaNarudzbeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn narucilacDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cijenaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn DetaljiZ;
        private System.Windows.Forms.DataGridViewButtonColumn Printaj;
    }
}