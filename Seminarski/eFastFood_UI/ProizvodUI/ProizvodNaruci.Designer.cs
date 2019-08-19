namespace eFastFood_UI.ProizvodUI
{
    partial class ProizvodNaruci
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
            this.kolicinaInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mjernajedinicaLabel = new System.Windows.Forms.Label();
            this.naruciButton = new System.Windows.Forms.Button();
            this.proizvodName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kolicinaInput
            // 
            this.kolicinaInput.Location = new System.Drawing.Point(165, 55);
            this.kolicinaInput.Margin = new System.Windows.Forms.Padding(4);
            this.kolicinaInput.Name = "kolicinaInput";
            this.kolicinaInput.Size = new System.Drawing.Size(76, 23);
            this.kolicinaInput.TabIndex = 0;
            this.kolicinaInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KolicinaInput_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Količina narudžbe";
            // 
            // mjernajedinicaLabel
            // 
            this.mjernajedinicaLabel.AutoSize = true;
            this.mjernajedinicaLabel.Location = new System.Drawing.Point(248, 58);
            this.mjernajedinicaLabel.Name = "mjernajedinicaLabel";
            this.mjernajedinicaLabel.Size = new System.Drawing.Size(46, 17);
            this.mjernajedinicaLabel.TabIndex = 2;
            this.mjernajedinicaLabel.Text = "label2";
            // 
            // naruciButton
            // 
            this.naruciButton.Location = new System.Drawing.Point(129, 119);
            this.naruciButton.Name = "naruciButton";
            this.naruciButton.Size = new System.Drawing.Size(100, 30);
            this.naruciButton.TabIndex = 3;
            this.naruciButton.Text = "Naruči";
            this.naruciButton.UseVisualStyleBackColor = true;
            this.naruciButton.Click += new System.EventHandler(this.NaruciButton_Click);
            // 
            // proizvodName
            // 
            this.proizvodName.AutoSize = true;
            this.proizvodName.Location = new System.Drawing.Point(176, 9);
            this.proizvodName.Name = "proizvodName";
            this.proizvodName.Size = new System.Drawing.Size(46, 17);
            this.proizvodName.TabIndex = 4;
            this.proizvodName.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Naruči:";
            // 
            // ProizvodNaruci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.proizvodName);
            this.Controls.Add(this.naruciButton);
            this.Controls.Add(this.mjernajedinicaLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kolicinaInput);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProizvodNaruci";
            this.ShowIcon = false;
            this.Text = "Naruči proizvod";
            this.Load += new System.EventHandler(this.ProizvodNaruci_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox kolicinaInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mjernajedinicaLabel;
        private System.Windows.Forms.Button naruciButton;
        private System.Windows.Forms.Label proizvodName;
        private System.Windows.Forms.Label label3;
    }
}