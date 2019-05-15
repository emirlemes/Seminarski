namespace eFastFood_UI.ProizvodUI
{
    partial class ProizvodEdit
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
            this.kolicinaInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.Proizvod.Controls.Add(this.kolicinaInput);
            this.Proizvod.Controls.Add(this.label6);
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
            this.Proizvod.Location = new System.Drawing.Point(11, 13);
            this.Proizvod.Margin = new System.Windows.Forms.Padding(4);
            this.Proizvod.Name = "Proizvod";
            this.Proizvod.Padding = new System.Windows.Forms.Padding(4);
            this.Proizvod.Size = new System.Drawing.Size(410, 321);
            this.Proizvod.TabIndex = 1;
            this.Proizvod.TabStop = false;
            this.Proizvod.Text = "Proizvod";
            // 
            // kolicinaInput
            // 
            this.kolicinaInput.Location = new System.Drawing.Point(306, 264);
            this.kolicinaInput.Name = "kolicinaInput";
            this.kolicinaInput.Size = new System.Drawing.Size(60, 23);
            this.kolicinaInput.TabIndex = 11;
            this.kolicinaInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KolicinaInput_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Količina";
            // 
            // mjerneJediniceComboBox
            // 
            this.mjerneJediniceComboBox.DisplayMember = "Text";
            this.mjerneJediniceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mjerneJediniceComboBox.FormattingEnabled = true;
            this.mjerneJediniceComboBox.Location = new System.Drawing.Point(116, 217);
            this.mjerneJediniceComboBox.Name = "mjerneJediniceComboBox";
            this.mjerneJediniceComboBox.Size = new System.Drawing.Size(254, 24);
            this.mjerneJediniceComboBox.TabIndex = 3;
            this.mjerneJediniceComboBox.ValueMember = "ID";
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
            this.donjaGranicaInput.Size = new System.Drawing.Size(60, 23);
            this.donjaGranicaInput.TabIndex = 4;
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
            // 
            // nazivProizvodInput
            // 
            this.nazivProizvodInput.Location = new System.Drawing.Point(82, 28);
            this.nazivProizvodInput.Margin = new System.Windows.Forms.Padding(4);
            this.nazivProizvodInput.Name = "nazivProizvodInput";
            this.nazivProizvodInput.Size = new System.Drawing.Size(288, 23);
            this.nazivProizvodInput.TabIndex = 0;
            // 
            // snimiButton
            // 
            this.snimiButton.Location = new System.Drawing.Point(51, 369);
            this.snimiButton.Name = "snimiButton";
            this.snimiButton.Size = new System.Drawing.Size(100, 30);
            this.snimiButton.TabIndex = 5;
            this.snimiButton.Text = "Snimi";
            this.snimiButton.UseVisualStyleBackColor = true;
            this.snimiButton.Click += new System.EventHandler(this.SnimiButton_Click);
            // 
            // odustaniButton
            // 
            this.odustaniButton.Location = new System.Drawing.Point(281, 369);
            this.odustaniButton.Name = "odustaniButton";
            this.odustaniButton.Size = new System.Drawing.Size(100, 30);
            this.odustaniButton.TabIndex = 6;
            this.odustaniButton.Text = "Odustani";
            this.odustaniButton.UseVisualStyleBackColor = true;
            this.odustaniButton.Click += new System.EventHandler(this.OdustaniButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ProizvodEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.odustaniButton);
            this.Controls.Add(this.snimiButton);
            this.Controls.Add(this.Proizvod);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProizvodEdit";
            this.ShowIcon = false;
            this.Text = "Proizvod uredi";
            this.Load += new System.EventHandler(this.ProizvodEdit_Load);
            this.Proizvod.ResumeLayout(false);
            this.Proizvod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Proizvod;
        private System.Windows.Forms.ComboBox mjerneJediniceComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox donjaGranicaInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dobavljaciComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox opisProizvodInput;
        private System.Windows.Forms.TextBox nazivProizvodInput;
        private System.Windows.Forms.Button snimiButton;
        private System.Windows.Forms.Button odustaniButton;
        private System.Windows.Forms.TextBox kolicinaInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}