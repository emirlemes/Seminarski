namespace eFastFood_UI.ProizvodUI
{
    partial class ProizvodIndex
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
            this.dodajButton = new System.Windows.Forms.Button();
            this.urediButton = new System.Windows.Forms.Button();
            this.proizvodiDataGridView = new System.Windows.Forms.DataGridView();
            this.pretragaInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.proizvodiDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dodajButton
            // 
            this.dodajButton.Location = new System.Drawing.Point(13, 13);
            this.dodajButton.Margin = new System.Windows.Forms.Padding(4);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(121, 30);
            this.dodajButton.TabIndex = 0;
            this.dodajButton.Text = "Dodaj proizvod";
            this.dodajButton.UseVisualStyleBackColor = true;
            this.dodajButton.Click += new System.EventHandler(this.DodajButton_Click);
            // 
            // urediButton
            // 
            this.urediButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.urediButton.Location = new System.Drawing.Point(473, 13);
            this.urediButton.Margin = new System.Windows.Forms.Padding(4);
            this.urediButton.Name = "urediButton";
            this.urediButton.Size = new System.Drawing.Size(100, 30);
            this.urediButton.TabIndex = 1;
            this.urediButton.Text = "Uredi";
            this.urediButton.UseVisualStyleBackColor = true;
            this.urediButton.Click += new System.EventHandler(this.UrediButton_Click);
            // 
            // proizvodiDataGridView
            // 
            this.proizvodiDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.proizvodiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.proizvodiDataGridView.Location = new System.Drawing.Point(13, 84);
            this.proizvodiDataGridView.Name = "proizvodiDataGridView";
            this.proizvodiDataGridView.Size = new System.Drawing.Size(560, 354);
            this.proizvodiDataGridView.TabIndex = 2;
            // 
            // pretragaInput
            // 
            this.pretragaInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pretragaInput.Location = new System.Drawing.Point(229, 17);
            this.pretragaInput.Name = "pretragaInput";
            this.pretragaInput.Size = new System.Drawing.Size(225, 23);
            this.pretragaInput.TabIndex = 3;
            this.pretragaInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PretragaInput_KeyUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pretraga";
            // 
            // ProizvodIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pretragaInput);
            this.Controls.Add(this.proizvodiDataGridView);
            this.Controls.Add(this.urediButton);
            this.Controls.Add(this.dodajButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProizvodIndex";
            this.Text = "ProizvodIndex";
            this.Load += new System.EventHandler(this.ProizvodIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.proizvodiDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.Button urediButton;
        private System.Windows.Forms.DataGridView proizvodiDataGridView;
        private System.Windows.Forms.TextBox pretragaInput;
        private System.Windows.Forms.Label label1;
    }
}