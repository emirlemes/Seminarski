namespace eFastFood_UI.KategorijaUI
{
    partial class KategorijaEdit
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.opisInput = new System.Windows.Forms.TextBox();
            this.snimiButton = new System.Windows.Forms.Button();
            this.odustaniButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Opis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Naziv";
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(80, 15);
            this.nazivInput.Margin = new System.Windows.Forms.Padding(4);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(340, 23);
            this.nazivInput.TabIndex = 13;
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(80, 47);
            this.opisInput.Margin = new System.Windows.Forms.Padding(4);
            this.opisInput.Multiline = true;
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(340, 73);
            this.opisInput.TabIndex = 14;
            // 
            // snimiButton
            // 
            this.snimiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.snimiButton.Location = new System.Drawing.Point(80, 174);
            this.snimiButton.Margin = new System.Windows.Forms.Padding(4);
            this.snimiButton.Name = "snimiButton";
            this.snimiButton.Size = new System.Drawing.Size(100, 30);
            this.snimiButton.TabIndex = 15;
            this.snimiButton.Text = "Snimi";
            this.snimiButton.UseVisualStyleBackColor = true;
            this.snimiButton.Click += new System.EventHandler(this.SnimiButton_Click);
            // 
            // odustaniButton
            // 
            this.odustaniButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.odustaniButton.Location = new System.Drawing.Point(320, 174);
            this.odustaniButton.Margin = new System.Windows.Forms.Padding(4);
            this.odustaniButton.Name = "odustaniButton";
            this.odustaniButton.Size = new System.Drawing.Size(100, 30);
            this.odustaniButton.TabIndex = 16;
            this.odustaniButton.Text = "Odustani";
            this.odustaniButton.UseVisualStyleBackColor = true;
            this.odustaniButton.Click += new System.EventHandler(this.OdustaniButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // KategorijaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 217);
            this.Controls.Add(this.odustaniButton);
            this.Controls.Add(this.snimiButton);
            this.Controls.Add(this.opisInput);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KategorijaEdit";
            this.ShowIcon = false;
            this.Text = "Kategorija uredi ";
            this.Load += new System.EventHandler(this.KategorijaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.TextBox opisInput;
        private System.Windows.Forms.Button snimiButton;
        private System.Windows.Forms.Button odustaniButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
