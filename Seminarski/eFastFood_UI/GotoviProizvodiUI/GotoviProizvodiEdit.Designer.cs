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
            this.errorProviderEdit = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
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
            this.label4.Location = new System.Drawing.Point(3, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Vrijeme pripreme (minute)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(3, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Kategorija";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(358, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Slika";
            // 
            // snimiButton
            // 
            this.snimiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.755F);
            this.snimiButton.Location = new System.Drawing.Point(45, 281);
            this.snimiButton.Name = "snimiButton";
            this.snimiButton.Size = new System.Drawing.Size(75, 30);
            this.snimiButton.TabIndex = 7;
            this.snimiButton.Text = "Snimi";
            this.snimiButton.UseVisualStyleBackColor = true;
            // 
            // odustaniButton
            // 
            this.odustaniButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.odustaniButton.Location = new System.Drawing.Point(161, 281);
            this.odustaniButton.Name = "odustaniButton";
            this.odustaniButton.Size = new System.Drawing.Size(75, 30);
            this.odustaniButton.TabIndex = 8;
            this.odustaniButton.Text = "Odustani";
            this.odustaniButton.UseVisualStyleBackColor = true;
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(78, 7);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(186, 20);
            this.nazivInput.TabIndex = 0;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.NazivInput_Validating);
            // 
            // cijenaInput
            // 
            this.cijenaInput.Location = new System.Drawing.Point(78, 40);
            this.cijenaInput.Name = "cijenaInput";
            this.cijenaInput.Size = new System.Drawing.Size(186, 20);
            this.cijenaInput.TabIndex = 1;
            this.cijenaInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VrijemePripremeInput_KeyPress);
            this.cijenaInput.Validating += new System.ComponentModel.CancelEventHandler(this.CijenaInput_Validating);
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(78, 66);
            this.opisInput.Multiline = true;
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(239, 55);
            this.opisInput.TabIndex = 2;
            this.opisInput.Validating += new System.ComponentModel.CancelEventHandler(this.OpisInput_Validating);
            // 
            // vrijemePripremeInput
            // 
            this.vrijemePripremeInput.Location = new System.Drawing.Point(174, 163);
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
            this.kategorijaComboBox.Location = new System.Drawing.Point(78, 127);
            this.kategorijaComboBox.Name = "kategorijaComboBox";
            this.kategorijaComboBox.Size = new System.Drawing.Size(186, 21);
            this.kategorijaComboBox.TabIndex = 3;
            this.kategorijaComboBox.ValueMember = "ID";
            // 
            // panel1
            // 
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
            this.panel1.Size = new System.Drawing.Size(326, 212);
            this.panel1.TabIndex = 14;
            // 
            // fileDialogButton
            // 
            this.fileDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.fileDialogButton.Location = new System.Drawing.Point(462, 274);
            this.fileDialogButton.Name = "fileDialogButton";
            this.fileDialogButton.Size = new System.Drawing.Size(75, 30);
            this.fileDialogButton.TabIndex = 5;
            this.fileDialogButton.Text = "Odaberi";
            this.fileDialogButton.UseVisualStyleBackColor = true;
            // 
            // errorProviderEdit
            // 
            this.errorProviderEdit.ContainerControl = this;
            // 
            // GotoviProizvodiEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 341);
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
            this.Text = "Gotovi proizvodi izmjena";
            this.Load += new System.EventHandler(this.GotoviProizvodiEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEdit)).EndInit();
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
        private System.Windows.Forms.ErrorProvider errorProviderEdit;
    }
}