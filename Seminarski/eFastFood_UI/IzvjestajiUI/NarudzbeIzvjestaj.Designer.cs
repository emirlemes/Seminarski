namespace eFastFood_UI.IzvjestajiUI
{
    partial class NarudzbeIzvjestaj
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.odDateTime = new System.Windows.Forms.DateTimePicker();
            this.doDateTime = new System.Windows.Forms.DateTimePicker();
            this.korisnicComboBox = new System.Windows.Forms.ComboBox();
            this.dostavaCheckBox = new System.Windows.Forms.CheckBox();
            this.IzvjestajDataGrid = new System.Windows.Forms.DataGridView();
            this.printajButton = new System.Windows.Forms.Button();
            this.osvjeziButton = new System.Windows.Forms.Button();
            this.NarudzbaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narucio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrstaNarudzbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.IzvjestajDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datum od:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(553, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum do:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Korisnik:";
            // 
            // odDateTime
            // 
            this.odDateTime.Location = new System.Drawing.Point(91, 26);
            this.odDateTime.Name = "odDateTime";
            this.odDateTime.Size = new System.Drawing.Size(200, 23);
            this.odDateTime.TabIndex = 4;
            // 
            // doDateTime
            // 
            this.doDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doDateTime.Location = new System.Drawing.Point(632, 26);
            this.doDateTime.Name = "doDateTime";
            this.doDateTime.Size = new System.Drawing.Size(200, 23);
            this.doDateTime.TabIndex = 5;
            // 
            // korisnicComboBox
            // 
            this.korisnicComboBox.DisplayMember = "Text";
            this.korisnicComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.korisnicComboBox.FormattingEnabled = true;
            this.korisnicComboBox.Location = new System.Drawing.Point(91, 73);
            this.korisnicComboBox.Name = "korisnicComboBox";
            this.korisnicComboBox.Size = new System.Drawing.Size(200, 24);
            this.korisnicComboBox.TabIndex = 6;
            this.korisnicComboBox.ValueMember = "ID";
            // 
            // dostavaCheckBox
            // 
            this.dostavaCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dostavaCheckBox.AutoSize = true;
            this.dostavaCheckBox.Location = new System.Drawing.Point(556, 76);
            this.dostavaCheckBox.Name = "dostavaCheckBox";
            this.dostavaCheckBox.Size = new System.Drawing.Size(79, 21);
            this.dostavaCheckBox.TabIndex = 7;
            this.dostavaCheckBox.Text = "Dostava";
            this.dostavaCheckBox.UseVisualStyleBackColor = true;
            // 
            // IzvjestajDataGrid
            // 
            this.IzvjestajDataGrid.AllowUserToAddRows = false;
            this.IzvjestajDataGrid.AllowUserToDeleteRows = false;
            this.IzvjestajDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IzvjestajDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IzvjestajDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NarudzbaId,
            this.Narucio,
            this.Cijena,
            this.Datum,
            this.VrstaNarudzbe});
            this.IzvjestajDataGrid.Location = new System.Drawing.Point(15, 103);
            this.IzvjestajDataGrid.Name = "IzvjestajDataGrid";
            this.IzvjestajDataGrid.ReadOnly = true;
            this.IzvjestajDataGrid.Size = new System.Drawing.Size(816, 330);
            this.IzvjestajDataGrid.TabIndex = 8;
            // 
            // printajButton
            // 
            this.printajButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.printajButton.Location = new System.Drawing.Point(356, 454);
            this.printajButton.Name = "printajButton";
            this.printajButton.Size = new System.Drawing.Size(100, 30);
            this.printajButton.TabIndex = 9;
            this.printajButton.Text = "Printaj";
            this.printajButton.UseVisualStyleBackColor = true;
            this.printajButton.Click += new System.EventHandler(this.PrintajButton_Click);
            // 
            // osvjeziButton
            // 
            this.osvjeziButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.osvjeziButton.Location = new System.Drawing.Point(381, 40);
            this.osvjeziButton.Name = "osvjeziButton";
            this.osvjeziButton.Size = new System.Drawing.Size(100, 30);
            this.osvjeziButton.TabIndex = 10;
            this.osvjeziButton.Text = "Osvježi";
            this.osvjeziButton.UseVisualStyleBackColor = true;
            this.osvjeziButton.Click += new System.EventHandler(this.OsvjeziButton_Click);
            // 
            // NarudzbaId
            // 
            this.NarudzbaId.DataPropertyName = "NarudzbaID";
            this.NarudzbaId.HeaderText = "Number";
            this.NarudzbaId.Name = "NarudzbaId";
            this.NarudzbaId.ReadOnly = true;
            // 
            // Narucio
            // 
            this.Narucio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Narucio.DataPropertyName = "Narucio";
            this.Narucio.HeaderText = "Naručio";
            this.Narucio.Name = "Narucio";
            this.Narucio.ReadOnly = true;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.DataPropertyName = "Datum";
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            this.Datum.Width = 150;
            // 
            // VrstaNarudzbe
            // 
            this.VrstaNarudzbe.DataPropertyName = "VrstaNarudzbe";
            this.VrstaNarudzbe.HeaderText = "Vrsta narudžbe";
            this.VrstaNarudzbe.Name = "VrstaNarudzbe";
            this.VrstaNarudzbe.ReadOnly = true;
            this.VrstaNarudzbe.Width = 150;
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // NarudzbeIzvjestaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 496);
            this.Controls.Add(this.osvjeziButton);
            this.Controls.Add(this.printajButton);
            this.Controls.Add(this.IzvjestajDataGrid);
            this.Controls.Add(this.dostavaCheckBox);
            this.Controls.Add(this.korisnicComboBox);
            this.Controls.Add(this.doDateTime);
            this.Controls.Add(this.odDateTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NarudzbeIzvjestaj";
            this.Text = "NarudzbeIzvjestaj";
            this.Load += new System.EventHandler(this.NarudzbeIzvjestaj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IzvjestajDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker odDateTime;
        private System.Windows.Forms.DateTimePicker doDateTime;
        private System.Windows.Forms.ComboBox korisnicComboBox;
        private System.Windows.Forms.CheckBox dostavaCheckBox;
        private System.Windows.Forms.DataGridView IzvjestajDataGrid;
        private System.Windows.Forms.Button printajButton;
        private System.Windows.Forms.Button osvjeziButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn NarudzbaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Narucio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrstaNarudzbe;
        private System.Windows.Forms.PrintDialog printDialog;
    }
}