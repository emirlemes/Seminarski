namespace eFastFood_UI.KategorijaUI
{
    partial class KategorijaAdd
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
            this.snimiButton = new System.Windows.Forms.Button();
            this.odustaniButton = new System.Windows.Forms.Button();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.opisInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProviderKategorija = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderKategorija)).BeginInit();
            this.SuspendLayout();
            // 
            // snimiButton
            // 
            this.snimiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.snimiButton.Location = new System.Drawing.Point(60, 154);
            this.snimiButton.Name = "snimiButton";
            this.snimiButton.Size = new System.Drawing.Size(75, 30);
            this.snimiButton.TabIndex = 2;
            this.snimiButton.Text = "Snimi";
            this.snimiButton.UseVisualStyleBackColor = true;
            this.snimiButton.Click += new System.EventHandler(this.SnimiButton_Click);
            // 
            // odustaniButton
            // 
            this.odustaniButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.odustaniButton.Location = new System.Drawing.Point(241, 154);
            this.odustaniButton.Name = "odustaniButton";
            this.odustaniButton.Size = new System.Drawing.Size(75, 30);
            this.odustaniButton.TabIndex = 3;
            this.odustaniButton.Text = "Odustani";
            this.odustaniButton.UseVisualStyleBackColor = true;
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(60, 36);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(256, 20);
            this.nazivInput.TabIndex = 0;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.NazivInput_Validating);
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(60, 62);
            this.opisInput.Multiline = true;
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(256, 61);
            this.opisInput.TabIndex = 1;
            this.opisInput.Validating += new System.ComponentModel.CancelEventHandler(this.OpisInput_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(17, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Opis";
            // 
            // errorProviderKategorija
            // 
            this.errorProviderKategorija.ContainerControl = this;
            // 
            // KategorijaAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 211);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.opisInput);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.odustaniButton);
            this.Controls.Add(this.snimiButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KategorijaAdd";
            this.ShowIcon = false;
            this.Text = "Kategorija dodaj";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderKategorija)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button snimiButton;
        private System.Windows.Forms.Button odustaniButton;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.TextBox opisInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProviderKategorija;
    }
}