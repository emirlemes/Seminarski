namespace eFastFood_UI.DobavljacUI
{
    partial class DobavljacEdit
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
            this.brojTelefonaInput = new System.Windows.Forms.MaskedTextBox();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.adresaDobavljacInput = new System.Windows.Forms.TextBox();
            this.dobavljacNazivInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.snimiButton = new System.Windows.Forms.Button();
            this.odustaniButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.brojTelefonaInput);
            this.groupBox1.Controls.Add(this.emailInput);
            this.groupBox1.Controls.Add(this.adresaDobavljacInput);
            this.groupBox1.Controls.Add(this.dobavljacNazivInput);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(469, 293);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dobavljač";
            // 
            // brojTelefonaInput
            // 
            this.brojTelefonaInput.Location = new System.Drawing.Point(143, 142);
            this.brojTelefonaInput.Margin = new System.Windows.Forms.Padding(4);
            this.brojTelefonaInput.Mask = "(999) 000-0000";
            this.brojTelefonaInput.Name = "brojTelefonaInput";
            this.brojTelefonaInput.Size = new System.Drawing.Size(295, 23);
            this.brojTelefonaInput.TabIndex = 2;
            // 
            // emailInput
            // 
            this.emailInput.Location = new System.Drawing.Point(143, 198);
            this.emailInput.Margin = new System.Windows.Forms.Padding(5);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(295, 23);
            this.emailInput.TabIndex = 3;
            // 
            // adresaDobavljacInput
            // 
            this.adresaDobavljacInput.Location = new System.Drawing.Point(143, 92);
            this.adresaDobavljacInput.Margin = new System.Windows.Forms.Padding(5);
            this.adresaDobavljacInput.Name = "adresaDobavljacInput";
            this.adresaDobavljacInput.Size = new System.Drawing.Size(295, 23);
            this.adresaDobavljacInput.TabIndex = 1;
            // 
            // dobavljacNazivInput
            // 
            this.dobavljacNazivInput.Location = new System.Drawing.Point(143, 39);
            this.dobavljacNazivInput.Margin = new System.Windows.Forms.Padding(5);
            this.dobavljacNazivInput.Name = "dobavljacNazivInput";
            this.dobavljacNazivInput.Size = new System.Drawing.Size(295, 23);
            this.dobavljacNazivInput.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 206);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "E- mail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 147);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Broj telefona";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Adresa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Naziv";
            // 
            // snimiButton
            // 
            this.snimiButton.Location = new System.Drawing.Point(74, 342);
            this.snimiButton.Name = "snimiButton";
            this.snimiButton.Size = new System.Drawing.Size(100, 30);
            this.snimiButton.TabIndex = 4;
            this.snimiButton.Text = "Snimi";
            this.snimiButton.UseVisualStyleBackColor = true;
            this.snimiButton.Click += new System.EventHandler(this.SnimiButton_Click);
            // 
            // odustaniButton
            // 
            this.odustaniButton.Location = new System.Drawing.Point(352, 342);
            this.odustaniButton.Name = "odustaniButton";
            this.odustaniButton.Size = new System.Drawing.Size(100, 30);
            this.odustaniButton.TabIndex = 5;
            this.odustaniButton.Text = "Odustani";
            this.odustaniButton.UseVisualStyleBackColor = true;
            this.odustaniButton.Click += new System.EventHandler(this.OdustaniButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // DobavljacEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 401);
            this.Controls.Add(this.odustaniButton);
            this.Controls.Add(this.snimiButton);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DobavljacEdit";
            this.ShowIcon = false;
            this.Text = "Dobavljač uredi";
            this.Load += new System.EventHandler(this.DobavljacEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox brojTelefonaInput;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.TextBox adresaDobavljacInput;
        private System.Windows.Forms.TextBox dobavljacNazivInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button snimiButton;
        private System.Windows.Forms.Button odustaniButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}