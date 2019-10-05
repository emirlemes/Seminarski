namespace eFastFood_UI.GotoviProizvodiUI
{
    partial class GotoviProizvodiEdit
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.snimiButton = new System.Windows.Forms.Button();
            this.odustaniButton = new System.Windows.Forms.Button();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.cijenaInput = new System.Windows.Forms.TextBox();
            this.opisInput = new System.Windows.Forms.TextBox();
            this.vrijemePripremeInput = new System.Windows.Forms.TextBox();
            this.kategorijaComboBox = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileDialogButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.slikaPath = new System.Windows.Forms.TextBox();
            this.sastojciDataGridView = new System.Windows.Forms.DataGridView();
            this.ProizvodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dodaj = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Proizvod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VidljivodstMobile = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sastojciDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::eFastFood_UI.Properties.Resources._default;
            this.pictureBox.Location = new System.Drawing.Point(344, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(256, 256);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(30, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(26, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cijena";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(36, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Opis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(4, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Vrijeme pripreme (minute)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(26, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Kategorija";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(435, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Slika";
            // 
            // snimiButton
            // 
            this.snimiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.755F);
            this.snimiButton.Location = new System.Drawing.Point(479, 418);
            this.snimiButton.Name = "snimiButton";
            this.snimiButton.Size = new System.Drawing.Size(100, 30);
            this.snimiButton.TabIndex = 7;
            this.snimiButton.Text = "Snimi";
            this.snimiButton.UseVisualStyleBackColor = true;
            this.snimiButton.Click += new System.EventHandler(this.SnimiButton_Click);
            // 
            // odustaniButton
            // 
            this.odustaniButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.odustaniButton.Location = new System.Drawing.Point(479, 495);
            this.odustaniButton.Name = "odustaniButton";
            this.odustaniButton.Size = new System.Drawing.Size(100, 30);
            this.odustaniButton.TabIndex = 8;
            this.odustaniButton.Text = "Odustani";
            this.odustaniButton.UseVisualStyleBackColor = true;
            this.odustaniButton.Click += new System.EventHandler(this.OdustaniButton_Click);
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(78, 7);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(219, 20);
            this.nazivInput.TabIndex = 0;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.NazivInput_Validating);
            // 
            // cijenaInput
            // 
            this.cijenaInput.Location = new System.Drawing.Point(78, 40);
            this.cijenaInput.Name = "cijenaInput";
            this.cijenaInput.Size = new System.Drawing.Size(219, 20);
            this.cijenaInput.TabIndex = 1;
            this.cijenaInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VrijemePripremeInput_KeyPress);
            this.cijenaInput.Validating += new System.ComponentModel.CancelEventHandler(this.CijenaInput_Validating);
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(78, 66);
            this.opisInput.Multiline = true;
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(219, 55);
            this.opisInput.TabIndex = 2;
            this.opisInput.Validating += new System.ComponentModel.CancelEventHandler(this.OpisInput_Validating);
            // 
            // vrijemePripremeInput
            // 
            this.vrijemePripremeInput.Location = new System.Drawing.Point(171, 139);
            this.vrijemePripremeInput.Name = "vrijemePripremeInput";
            this.vrijemePripremeInput.Size = new System.Drawing.Size(50, 20);
            this.vrijemePripremeInput.TabIndex = 4;
            this.vrijemePripremeInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VrijemePripremeInput_KeyPress);
            this.vrijemePripremeInput.Validating += new System.ComponentModel.CancelEventHandler(this.CijenaInput_Validating);
            // 
            // kategorijaComboBox
            // 
            this.kategorijaComboBox.DisplayMember = "Text";
            this.kategorijaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kategorijaComboBox.FormattingEnabled = true;
            this.kategorijaComboBox.Location = new System.Drawing.Point(111, 165);
            this.kategorijaComboBox.Name = "kategorijaComboBox";
            this.kategorijaComboBox.Size = new System.Drawing.Size(186, 21);
            this.kategorijaComboBox.TabIndex = 3;
            this.kategorijaComboBox.ValueMember = "ID";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.VidljivodstMobile);
            this.panel1.Controls.Add(this.kategorijaComboBox);
            this.panel1.Controls.Add(this.vrijemePripremeInput);
            this.panel1.Controls.Add(this.opisInput);
            this.panel1.Controls.Add(this.cijenaInput);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.nazivInput);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 256);
            this.panel1.TabIndex = 14;
            // 
            // fileDialogButton
            // 
            this.fileDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.fileDialogButton.Location = new System.Drawing.Point(479, 274);
            this.fileDialogButton.Name = "fileDialogButton";
            this.fileDialogButton.Size = new System.Drawing.Size(100, 30);
            this.fileDialogButton.TabIndex = 5;
            this.fileDialogButton.Text = "Odaberi";
            this.fileDialogButton.UseVisualStyleBackColor = true;
            this.fileDialogButton.Click += new System.EventHandler(this.FileDialogButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // slikaPath
            // 
            this.slikaPath.Location = new System.Drawing.Point(438, 325);
            this.slikaPath.Name = "slikaPath";
            this.slikaPath.Size = new System.Drawing.Size(165, 20);
            this.slikaPath.TabIndex = 15;
            this.slikaPath.Visible = false;
            // 
            // sastojciDataGridView
            // 
            this.sastojciDataGridView.AllowUserToAddRows = false;
            this.sastojciDataGridView.AllowUserToDeleteRows = false;
            this.sastojciDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sastojciDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sastojciDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProizvodID,
            this.Dodaj,
            this.Proizvod,
            this.Kolicina});
            this.sastojciDataGridView.Location = new System.Drawing.Point(12, 274);
            this.sastojciDataGridView.Name = "sastojciDataGridView";
            this.sastojciDataGridView.Size = new System.Drawing.Size(415, 344);
            this.sastojciDataGridView.TabIndex = 16;
            // 
            // ProizvodID
            // 
            this.ProizvodID.DataPropertyName = "ProizvodID";
            this.ProizvodID.HeaderText = "ProizvodID";
            this.ProizvodID.Name = "ProizvodID";
            this.ProizvodID.Visible = false;
            // 
            // Dodaj
            // 
            this.Dodaj.DataPropertyName = "Dodaj";
            this.Dodaj.HeaderText = "Dodaj";
            this.Dodaj.Name = "Dodaj";
            this.Dodaj.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Dodaj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Dodaj.Width = 50;
            // 
            // Proizvod
            // 
            this.Proizvod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Proizvod.DataPropertyName = "Proizvod";
            this.Proizvod.HeaderText = "Proizvod";
            this.Proizvod.Name = "Proizvod";
            this.Proizvod.ReadOnly = true;
            // 
            // Kolicina
            // 
            this.Kolicina.DataPropertyName = "Kolicina";
            this.Kolicina.HeaderText = "Količina";
            this.Kolicina.Name = "Kolicina";
            this.Kolicina.Width = 70;
            // 
            // VidljivodstMobile
            // 
            this.VidljivodstMobile.AutoSize = true;
            this.VidljivodstMobile.Checked = true;
            this.VidljivodstMobile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VidljivodstMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.VidljivodstMobile.Location = new System.Drawing.Point(61, 212);
            this.VidljivodstMobile.Name = "VidljivodstMobile";
            this.VidljivodstMobile.Size = new System.Drawing.Size(236, 21);
            this.VidljivodstMobile.TabIndex = 14;
            this.VidljivodstMobile.Text = "Prikazivanje na mobilnoj aplikaciji";
            this.VidljivodstMobile.UseVisualStyleBackColor = true;
            // 
            // GotoviProizvodiEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 621);
            this.Controls.Add(this.sastojciDataGridView);
            this.Controls.Add(this.slikaPath);
            this.Controls.Add(this.fileDialogButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.odustaniButton);
            this.Controls.Add(this.snimiButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GotoviProizvodiEdit";
            this.ShowIcon = false;
            this.Text = "Gotovi proizvodi uredi";
            this.Load += new System.EventHandler(this.GotoviProizvodiEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sastojciDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button snimiButton;
        private System.Windows.Forms.Button odustaniButton;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.TextBox cijenaInput;
        private System.Windows.Forms.TextBox opisInput;
        private System.Windows.Forms.TextBox vrijemePripremeInput;
        private System.Windows.Forms.ComboBox kategorijaComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button fileDialogButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox slikaPath;
        private System.Windows.Forms.DataGridView sastojciDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProizvodID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Dodaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proizvod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolicina;
        private System.Windows.Forms.CheckBox VidljivodstMobile;
    }
}
