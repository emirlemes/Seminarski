namespace eFastFood_UI.ProizvodUI
{
    partial class ProizvodAdd
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
            this.Proizvod = new System.Windows.Forms.GroupBox();
            this.mjerneJediniceComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.donjaGranicaInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dobavljaciComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.opisProizvodInput = new System.Windows.Forms.TextBox();
            this.nazivProizvodInput = new System.Windows.Forms.TextBox();
            this.snimiButton = new System.Windows.Forms.Button();
            this.odustaniButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Proizvod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // Proizvod
            // 
            this.Proizvod.Controls.Add(this.mjerneJediniceComboBox);
            this.Proizvod.Controls.Add(this.label5);
            this.Proizvod.Controls.Add(this.label4);
            this.Proizvod.Controls.Add(this.donjaGranicaInput);
            this.Proizvod.Controls.Add(this.label3);
            this.Proizvod.Controls.Add(this.dobavljaciComboBox);
            this.Proizvod.Controls.Add(this.label2);
            this.Proizvod.Controls.Add(this.label1);
            this.Proizvod.Controls.Add(this.opisProizvodInput);
            this.Proizvod.Controls.Add(this.nazivProizvodInput);
            this.Proizvod.Location = new System.Drawing.Point(16, 15);
            this.Proizvod.Margin = new System.Windows.Forms.Padding(4);
            this.Proizvod.Name = "Proizvod";
            this.Proizvod.Padding = new System.Windows.Forms.Padding(4);
            this.Proizvod.Size = new System.Drawing.Size(410, 346);
            this.Proizvod.TabIndex = 0;
            this.Proizvod.TabStop = false;
            this.Proizvod.Text = "Proizvod";
            // 
            // mjerneJediniceComboBox
            // 
            this.mjerneJediniceComboBox.DisplayMember = "Text";
            this.mjerneJediniceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mjerneJediniceComboBox.FormattingEnabled = true;
            this.mjerneJediniceComboBox.Location = new System.Drawing.Point(116, 217);
            this.mjerneJediniceComboBox.Name = "mjerneJediniceComboBox";
            this.mjerneJediniceComboBox.Size = new System.Drawing.Size(254, 24);
            this.mjerneJediniceComboBox.TabIndex = 10;
            this.mjerneJediniceComboBox.ValueMember = "ID";
            this.mjerneJediniceComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.DobavljaciComboBox_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mjerna jedinica";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Donja granica";
            // 
            // donjaGranicaInput
            // 
            this.donjaGranicaInput.Location = new System.Drawing.Point(116, 264);
            this.donjaGranicaInput.Name = "donjaGranicaInput";
            this.donjaGranicaInput.Size = new System.Drawing.Size(61, 23);
            this.donjaGranicaInput.TabIndex = 3;
            this.donjaGranicaInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DonjaGranicaInput_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dobavljač";
            // 
            // dobavljaciComboBox
            // 
            this.dobavljaciComboBox.DisplayMember = "Text";
            this.dobavljaciComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dobavljaciComboBox.FormattingEnabled = true;
            this.dobavljaciComboBox.Location = new System.Drawing.Point(82, 165);
            this.dobavljaciComboBox.Name = "dobavljaciComboBox";
            this.dobavljaciComboBox.Size = new System.Drawing.Size(288, 24);
            this.dobavljaciComboBox.TabIndex = 2;
            this.dobavljaciComboBox.ValueMember = "ID";
            this.dobavljaciComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.DobavljaciComboBox_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Opis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Naziv";
            // 
            // opisProizvodInput
            // 
            this.opisProizvodInput.Location = new System.Drawing.Point(82, 75);
            this.opisProizvodInput.Margin = new System.Windows.Forms.Padding(4);
            this.opisProizvodInput.Multiline = true;
            this.opisProizvodInput.Name = "opisProizvodInput";
            this.opisProizvodInput.Size = new System.Drawing.Size(288, 67);
            this.opisProizvodInput.TabIndex = 1;
            this.opisProizvodInput.Validating += new System.ComponentModel.CancelEventHandler(this.OpisProizvodInput_Validating);
            // 
            // nazivProizvodInput
            // 
            this.nazivProizvodInput.Location = new System.Drawing.Point(82, 28);
            this.nazivProizvodInput.Margin = new System.Windows.Forms.Padding(4);
            this.nazivProizvodInput.Name = "nazivProizvodInput";
            this.nazivProizvodInput.Size = new System.Drawing.Size(288, 23);
            this.nazivProizvodInput.TabIndex = 0;
            this.nazivProizvodInput.Validating += new System.ComponentModel.CancelEventHandler(this.NazivProizvodInput_Validating);
            // 
            // snimiButton
            // 
            this.snimiButton.Location = new System.Drawing.Point(83, 369);
            this.snimiButton.Margin = new System.Windows.Forms.Padding(4);
            this.snimiButton.Name = "snimiButton";
            this.snimiButton.Size = new System.Drawing.Size(100, 28);
            this.snimiButton.TabIndex = 4;
            this.snimiButton.Text = "Snimi";
            this.snimiButton.UseVisualStyleBackColor = true;
            this.snimiButton.Click += new System.EventHandler(this.SnimiButton_Click);
            // 
            // odustaniButton
            // 
            this.odustaniButton.Location = new System.Drawing.Point(286, 369);
            this.odustaniButton.Margin = new System.Windows.Forms.Padding(4);
            this.odustaniButton.Name = "odustaniButton";
            this.odustaniButton.Size = new System.Drawing.Size(100, 28);
            this.odustaniButton.TabIndex = 5;
            this.odustaniButton.Text = "Odustani";
            this.odustaniButton.UseVisualStyleBackColor = true;
            this.odustaniButton.Click += new System.EventHandler(this.OdustaniButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ProizvodAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 410);
            this.Controls.Add(this.odustaniButton);
            this.Controls.Add(this.snimiButton);
            this.Controls.Add(this.Proizvod);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProizvodAdd";
            this.ShowIcon = false;
            this.Text = "Proizvod dodaj";
            this.Load += new System.EventHandler(this.ProizvodAdd_Load);
            this.Proizvod.ResumeLayout(false);
            this.Proizvod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Proizvod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox opisProizvodInput;
        private System.Windows.Forms.TextBox nazivProizvodInput;
        private System.Windows.Forms.Button snimiButton;
        private System.Windows.Forms.Button odustaniButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox donjaGranicaInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dobavljaciComboBox;
        private System.Windows.Forms.ComboBox mjerneJediniceComboBox;
        private System.Windows.Forms.Label label5;
    }
}