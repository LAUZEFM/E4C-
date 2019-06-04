namespace PersonnelWindowsForm
{
    partial class FormEditPersonne
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
            this.labeltxtId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.labeltxtNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.labeltxtPrenom = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.labeltxtDate = new System.Windows.Forms.Label();
            this.labeltxtSB = new System.Windows.Forms.Label();
            this.txtSalBrut = new System.Windows.Forms.TextBox();
            this.labeltxtSN = new System.Windows.Forms.Label();
            this.txtSalNet = new System.Windows.Forms.TextBox();
            this.dtPickerDateDenaissance = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbService = new System.Windows.Forms.ComboBox();
            this.labelService = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labeltxtId
            // 
            this.labeltxtId.AutoSize = true;
            this.labeltxtId.Location = new System.Drawing.Point(13, 34);
            this.labeltxtId.Name = "labeltxtId";
            this.labeltxtId.Size = new System.Drawing.Size(15, 13);
            this.labeltxtId.TabIndex = 0;
            this.labeltxtId.Text = "id";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(87, 31);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 1;
            // 
            // labeltxtNom
            // 
            this.labeltxtNom.AutoSize = true;
            this.labeltxtNom.Location = new System.Drawing.Point(13, 60);
            this.labeltxtNom.Name = "labeltxtNom";
            this.labeltxtNom.Size = new System.Drawing.Size(29, 13);
            this.labeltxtNom.TabIndex = 2;
            this.labeltxtNom.Text = "Nom";
            // 
            // txtNom
            // 
            this.txtNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNom.Location = new System.Drawing.Point(87, 57);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 2;
            // 
            // labeltxtPrenom
            // 
            this.labeltxtPrenom.AutoSize = true;
            this.labeltxtPrenom.Location = new System.Drawing.Point(13, 85);
            this.labeltxtPrenom.Name = "labeltxtPrenom";
            this.labeltxtPrenom.Size = new System.Drawing.Size(43, 13);
            this.labeltxtPrenom.TabIndex = 3;
            this.labeltxtPrenom.Text = "Prénom";
            // 
            // txtPrenom
            // 
            this.txtPrenom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrenom.Location = new System.Drawing.Point(87, 82);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(100, 20);
            this.txtPrenom.TabIndex = 2;
            // 
            // labeltxtDate
            // 
            this.labeltxtDate.AutoSize = true;
            this.labeltxtDate.Location = new System.Drawing.Point(13, 111);
            this.labeltxtDate.Name = "labeltxtDate";
            this.labeltxtDate.Size = new System.Drawing.Size(30, 13);
            this.labeltxtDate.TabIndex = 5;
            this.labeltxtDate.Text = "Date";
            // 
            // labeltxtSB
            // 
            this.labeltxtSB.AutoSize = true;
            this.labeltxtSB.Location = new System.Drawing.Point(13, 137);
            this.labeltxtSB.Name = "labeltxtSB";
            this.labeltxtSB.Size = new System.Drawing.Size(61, 13);
            this.labeltxtSB.TabIndex = 6;
            this.labeltxtSB.Text = "Salaire Brut";
            // 
            // txtSalBrut
            // 
            this.txtSalBrut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSalBrut.Location = new System.Drawing.Point(87, 134);
            this.txtSalBrut.Name = "txtSalBrut";
            this.txtSalBrut.Size = new System.Drawing.Size(100, 20);
            this.txtSalBrut.TabIndex = 2;
            this.txtSalBrut.TextChanged += new System.EventHandler(this.txtSalBrut_TextChanged);
            // 
            // labeltxtSN
            // 
            this.labeltxtSN.AutoSize = true;
            this.labeltxtSN.Location = new System.Drawing.Point(12, 163);
            this.labeltxtSN.Name = "labeltxtSN";
            this.labeltxtSN.Size = new System.Drawing.Size(59, 13);
            this.labeltxtSN.TabIndex = 7;
            this.labeltxtSN.Text = "Salaire Net";
            // 
            // txtSalNet
            // 
            this.txtSalNet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSalNet.Location = new System.Drawing.Point(87, 160);
            this.txtSalNet.Name = "txtSalNet";
            this.txtSalNet.Size = new System.Drawing.Size(100, 20);
            this.txtSalNet.TabIndex = 2;
            // 
            // dtPickerDateDenaissance
            // 
            this.dtPickerDateDenaissance.Location = new System.Drawing.Point(87, 109);
            this.dtPickerDateDenaissance.Name = "dtPickerDateDenaissance";
            this.dtPickerDateDenaissance.Size = new System.Drawing.Size(185, 20);
            this.dtPickerDateDenaissance.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(16, 226);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Valider";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(197, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbService
            // 
            this.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbService.FormattingEnabled = true;
            this.cbService.Location = new System.Drawing.Point(87, 187);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(121, 21);
            this.cbService.TabIndex = 11;
            // 
            // labelService
            // 
            this.labelService.AutoSize = true;
            this.labelService.Location = new System.Drawing.Point(16, 194);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(43, 13);
            this.labelService.TabIndex = 12;
            this.labelService.Text = "Service";
            // 
            // FormEditPersonne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 391);
            this.ControlBox = false;
            this.Controls.Add(this.labelService);
            this.Controls.Add(this.cbService);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtPickerDateDenaissance);
            this.Controls.Add(this.txtSalNet);
            this.Controls.Add(this.labeltxtSN);
            this.Controls.Add(this.txtSalBrut);
            this.Controls.Add(this.labeltxtSB);
            this.Controls.Add(this.labeltxtDate);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.labeltxtPrenom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.labeltxtNom);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.labeltxtId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormEditPersonne";
            this.Text = "FormEditPersonne";
            this.Load += new System.EventHandler(this.FormEditPersonne_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labeltxtId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label labeltxtNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label labeltxtPrenom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label labeltxtDate;
        private System.Windows.Forms.Label labeltxtSB;
        private System.Windows.Forms.TextBox txtSalBrut;
        private System.Windows.Forms.Label labeltxtSN;
        private System.Windows.Forms.TextBox txtSalNet;
        private System.Windows.Forms.DateTimePicker dtPickerDateDenaissance;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbService;
        private System.Windows.Forms.Label labelService;
    }
}