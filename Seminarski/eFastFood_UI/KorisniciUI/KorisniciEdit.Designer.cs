namespace eFastFood_UI.KorisniciUI
{
    partial class KorisniciEdit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.statusCheckBox = new System.Windows.Forms.CheckBox();
            this.ulogeComboBox = new System.Windows.Forms.ComboBox();
            this.lozinkaInput = new System.Windows.Forms.TextBox();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.brojTelefonaInput = new System.Windows.Forms.MaskedTextBox();
            this.korisnickoImeInput = new System.Windows.Forms.TextBox();
            this.prezimeInput = new System.Windows.Forms.TextBox();
            this.imeInput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.snimiButton = new System.Windows.Forms.Button();
            this.odustaniButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.statusCheckBox);
            this.groupBox1.Controls.Add(this.ulogeComboBox);
            this.groupBox1.Controls.Add(this.lozinkaInput);
            this.groupBox1.Controls.Add(this.emailInput);
            this.groupBox1.Controls.Add(this.brojTelefonaInput);
            this.groupBox1.Controls.Add(this.korisnickoImeInput);
            this.groupBox1.Controls.Add(this.prezimeInput);
            this.groupBox1.Controls.Add(this.imeInput);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(358, 380);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Uposlenik";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Status";
            // 
            // statusCheckBox
            // 
            this.statusCheckBox.AutoSize = true;
            this.statusCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.statusCheckBox.Location = new System.Drawing.Point(175, 328);
            this.statusCheckBox.Name = "statusCheckBox";
            this.statusCheckBox.Padding = new System.Windows.Forms.Padding(5);
            this.statusCheckBox.Size = new System.Drawing.Size(25, 24);
            this.statusCheckBox.TabIndex = 15;
            this.statusCheckBox.UseVisualStyleBackColor = true;
            // 
            // ulogeComboBox
            // 
            this.ulogeComboBox.DisplayMember = "Text";
            this.ulogeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ulogeComboBox.FormattingEnabled = true;
            this.ulogeComboBox.Location = new System.Drawing.Point(109, 291);
            this.ulogeComboBox.Name = "ulogeComboBox";
            this.ulogeComboBox.Size = new System.Drawing.Size(190, 24);
            this.ulogeComboBox.TabIndex = 14;
            this.ulogeComboBox.ValueMember = "ID";
            this.ulogeComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.UlogeComboBox_Validating);
            // 
            // lozinkaInput
            // 
            this.lozinkaInput.Location = new System.Drawing.Point(109, 250);
            this.lozinkaInput.Name = "lozinkaInput";
            this.lozinkaInput.Size = new System.Drawing.Size(190, 23);
            this.lozinkaInput.TabIndex = 13;
            this.lozinkaInput.Validating += new System.ComponentModel.CancelEventHandler(this.LozinkaInput_Validating);
            // 
            // emailInput
            // 
            this.emailInput.Location = new System.Drawing.Point(109, 209);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(190, 23);
            this.emailInput.TabIndex = 12;
            this.emailInput.Validating += new System.ComponentModel.CancelEventHandler(this.EmailInput_Validating);
            // 
            // brojTelefonaInput
            // 
            this.brojTelefonaInput.Location = new System.Drawing.Point(109, 168);
            this.brojTelefonaInput.Mask = "(999) 000-0000";
            this.brojTelefonaInput.Name = "brojTelefonaInput";
            this.brojTelefonaInput.Size = new System.Drawing.Size(190, 23);
            this.brojTelefonaInput.TabIndex = 11;
            this.brojTelefonaInput.Validating += new System.ComponentModel.CancelEventHandler(this.BrojTelefonaInput_Validating);
            // 
            // korisnickoImeInput
            // 
            this.korisnickoImeInput.Location = new System.Drawing.Point(109, 127);
            this.korisnickoImeInput.Name = "korisnickoImeInput";
            this.korisnickoImeInput.Size = new System.Drawing.Size(190, 23);
            this.korisnickoImeInput.TabIndex = 10;
            this.korisnickoImeInput.Validating += new System.ComponentModel.CancelEventHandler(this.KorisnickoImeInput_Validating);
            // 
            // prezimeInput
            // 
            this.prezimeInput.Location = new System.Drawing.Point(109, 86);
            this.prezimeInput.Name = "prezimeInput";
            this.prezimeInput.Size = new System.Drawing.Size(190, 23);
            this.prezimeInput.TabIndex = 9;
            this.prezimeInput.Validating += new System.ComponentModel.CancelEventHandler(this.PrezimeInput_Validating);
            // 
            // imeInput
            // 
            this.imeInput.Location = new System.Drawing.Point(109, 45);
            this.imeInput.Name = "imeInput";
            this.imeInput.Size = new System.Drawing.Size(190, 23);
            this.imeInput.TabIndex = 8;
            this.imeInput.Validating += new System.ComponentModel.CancelEventHandler(this.ImeInput_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Uloga";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lozinka";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Broj telefona";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Korisničko ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prezime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime";
            // 
            // snimiButton
            // 
            this.snimiButton.Location = new System.Drawing.Point(62, 436);
            this.snimiButton.Name = "snimiButton";
            this.snimiButton.Size = new System.Drawing.Size(100, 30);
            this.snimiButton.TabIndex = 2;
            this.snimiButton.Text = "Snimi";
            this.snimiButton.UseVisualStyleBackColor = true;
            this.snimiButton.Click += new System.EventHandler(this.SnimiButton_Click);
            // 
            // odustaniButton
            // 
            this.odustaniButton.Location = new System.Drawing.Point(237, 436);
            this.odustaniButton.Name = "odustaniButton";
            this.odustaniButton.Size = new System.Drawing.Size(100, 30);
            this.odustaniButton.TabIndex = 3;
            this.odustaniButton.Text = "Odustani";
            this.odustaniButton.UseVisualStyleBackColor = true;
            this.odustaniButton.Click += new System.EventHandler(this.OdustaniButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // KorisniciEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 481);
            this.Controls.Add(this.odustaniButton);
            this.Controls.Add(this.snimiButton);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KorisniciEdit";
            this.ShowIcon = false;
            this.Text = "Uposlenik uredi";
            this.Load += new System.EventHandler(this.KorisniciEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ulogeComboBox;
        private System.Windows.Forms.TextBox lozinkaInput;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.MaskedTextBox brojTelefonaInput;
        private System.Windows.Forms.TextBox korisnickoImeInput;
        private System.Windows.Forms.TextBox prezimeInput;
        private System.Windows.Forms.TextBox imeInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox statusCheckBox;
        private System.Windows.Forms.Button snimiButton;
        private System.Windows.Forms.Button odustaniButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
