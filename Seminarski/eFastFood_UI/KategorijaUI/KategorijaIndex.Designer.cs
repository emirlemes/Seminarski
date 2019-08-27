namespace eFastFood_UI.KategorijaUI
{
    partial class KategorijaIndex
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
            this.kategorijeDataGridView = new System.Windows.Forms.DataGridView();
            this.KategorijaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kategorijaAddbutton = new System.Windows.Forms.Button();
            this.kategorijaUrediButton = new System.Windows.Forms.Button();
            this.ObrisiButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.kategorijeDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kategorijeDataGridView
            // 
            this.kategorijeDataGridView.AllowUserToAddRows = false;
            this.kategorijeDataGridView.AllowUserToDeleteRows = false;
            this.kategorijeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kategorijeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kategorijeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KategorijaID,
            this.Naziv,
            this.Opis});
            this.kategorijeDataGridView.Location = new System.Drawing.Point(13, 53);
            this.kategorijeDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.kategorijeDataGridView.Name = "kategorijeDataGridView";
            this.kategorijeDataGridView.ReadOnly = true;
            this.kategorijeDataGridView.Size = new System.Drawing.Size(589, 450);
            this.kategorijeDataGridView.TabIndex = 0;
            // 
            // KategorijaID
            // 
            this.KategorijaID.DataPropertyName = "KategorijaID";
            this.KategorijaID.HeaderText = "KategorijaID";
            this.KategorijaID.Name = "KategorijaID";
            this.KategorijaID.ReadOnly = true;
            this.KategorijaID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 150;
            // 
            // Opis
            // 
            this.Opis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Opis.DataPropertyName = "Opis";
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            // 
            // kategorijaAddbutton
            // 
            this.kategorijaAddbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.kategorijaAddbutton.Location = new System.Drawing.Point(4, 4);
            this.kategorijaAddbutton.Margin = new System.Windows.Forms.Padding(4);
            this.kategorijaAddbutton.Name = "kategorijaAddbutton";
            this.kategorijaAddbutton.Size = new System.Drawing.Size(180, 30);
            this.kategorijaAddbutton.TabIndex = 1;
            this.kategorijaAddbutton.Text = "Dodaj kategoriju";
            this.kategorijaAddbutton.UseVisualStyleBackColor = true;
            this.kategorijaAddbutton.Click += new System.EventHandler(this.KategorijaAddbutton_Click);
            // 
            // kategorijaUrediButton
            // 
            this.kategorijaUrediButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kategorijaUrediButton.Location = new System.Drawing.Point(237, 3);
            this.kategorijaUrediButton.Margin = new System.Windows.Forms.Padding(4);
            this.kategorijaUrediButton.Name = "kategorijaUrediButton";
            this.kategorijaUrediButton.Size = new System.Drawing.Size(100, 30);
            this.kategorijaUrediButton.TabIndex = 2;
            this.kategorijaUrediButton.Text = "Uredi";
            this.kategorijaUrediButton.UseVisualStyleBackColor = true;
            this.kategorijaUrediButton.Click += new System.EventHandler(this.KategorijaUrediButton_Click);
            // 
            // ObrisiButton
            // 
            this.ObrisiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ObrisiButton.Location = new System.Drawing.Point(487, 3);
            this.ObrisiButton.Name = "ObrisiButton";
            this.ObrisiButton.Size = new System.Drawing.Size(100, 30);
            this.ObrisiButton.TabIndex = 3;
            this.ObrisiButton.Text = "Obriši";
            this.ObrisiButton.UseVisualStyleBackColor = true;
            this.ObrisiButton.Click += new System.EventHandler(this.ObrisiButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ObrisiButton);
            this.panel1.Controls.Add(this.kategorijaUrediButton);
            this.panel1.Controls.Add(this.kategorijaAddbutton);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.MinimumSize = new System.Drawing.Size(590, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 40);
            this.panel1.TabIndex = 4;
            // 
            // KategorijaIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 516);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kategorijeDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KategorijaIndex";
            this.ShowIcon = false;
            this.Text = "Kategorija";
            ((System.ComponentModel.ISupportInitialize)(this.kategorijeDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView kategorijeDataGridView;
        private System.Windows.Forms.Button kategorijaAddbutton;
        private System.Windows.Forms.Button kategorijaUrediButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn KategorijaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.Button ObrisiButton;
        private System.Windows.Forms.Panel panel1;
    }
}