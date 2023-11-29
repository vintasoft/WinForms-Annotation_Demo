namespace DemosCommonCode.Pdf.Security
{
    partial class CreateSignatureFieldForm
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
            this.certificateTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectCertificateButton = new System.Windows.Forms.Button();
            this.signatureAppearanceButton = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.signatureNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.signerNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.reasonTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.contactInfoTextBox = new System.Windows.Forms.TextBox();
            this.certificateChainCheckBox = new System.Windows.Forms.CheckBox();
            this.signatureTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.addTimestampCheckBox = new System.Windows.Forms.CheckBox();
            this.timestampServerSettingsButton = new System.Windows.Forms.Button();
            this.timestampProperitesGroupBox = new System.Windows.Forms.GroupBox();
            this.timestampHashAlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timestampProperitesGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // certificateTextBox
            // 
            this.certificateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.certificateTextBox.Location = new System.Drawing.Point(14, 101);
            this.certificateTextBox.Name = "certificateTextBox";
            this.certificateTextBox.ReadOnly = true;
            this.certificateTextBox.Size = new System.Drawing.Size(269, 20);
            this.certificateTextBox.TabIndex = 0;
            this.certificateTextBox.Text = "(Click to select certificate)";
            this.certificateTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.certificateTextBox_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Certificate";
            // 
            // selectCertificateButton
            // 
            this.selectCertificateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectCertificateButton.Location = new System.Drawing.Point(287, 99);
            this.selectCertificateButton.Name = "selectCertificateButton";
            this.selectCertificateButton.Size = new System.Drawing.Size(39, 23);
            this.selectCertificateButton.TabIndex = 2;
            this.selectCertificateButton.Text = "...";
            this.selectCertificateButton.UseVisualStyleBackColor = true;
            this.selectCertificateButton.Click += new System.EventHandler(this.selectCertificateButton_Click);
            // 
            // signatureAppearanceButton
            // 
            this.signatureAppearanceButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signatureAppearanceButton.Location = new System.Drawing.Point(15, 52);
            this.signatureAppearanceButton.Name = "signatureAppearanceButton";
            this.signatureAppearanceButton.Size = new System.Drawing.Size(311, 23);
            this.signatureAppearanceButton.TabIndex = 5;
            this.signatureAppearanceButton.Text = "Signature Appearance...";
            this.signatureAppearanceButton.UseVisualStyleBackColor = true;
            this.signatureAppearanceButton.Click += new System.EventHandler(this.signatureAppearanceButton_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(170, 456);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(251, 456);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // signatureNameTextBox
            // 
            this.signatureNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signatureNameTextBox.Location = new System.Drawing.Point(14, 22);
            this.signatureNameTextBox.Name = "signatureNameTextBox";
            this.signatureNameTextBox.Size = new System.Drawing.Size(312, 20);
            this.signatureNameTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Signer Name";
            // 
            // signerNameTextBox
            // 
            this.signerNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signerNameTextBox.Location = new System.Drawing.Point(14, 305);
            this.signerNameTextBox.Name = "signerNameTextBox";
            this.signerNameTextBox.Size = new System.Drawing.Size(312, 20);
            this.signerNameTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Reason";
            // 
            // reasonTextBox
            // 
            this.reasonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reasonTextBox.Location = new System.Drawing.Point(14, 344);
            this.reasonTextBox.Name = "reasonTextBox";
            this.reasonTextBox.Size = new System.Drawing.Size(312, 20);
            this.reasonTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Location";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationTextBox.Location = new System.Drawing.Point(14, 383);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(312, 20);
            this.locationTextBox.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Contact Info";
            // 
            // contactInfoTextBox
            // 
            this.contactInfoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contactInfoTextBox.Location = new System.Drawing.Point(14, 422);
            this.contactInfoTextBox.Name = "contactInfoTextBox";
            this.contactInfoTextBox.Size = new System.Drawing.Size(312, 20);
            this.contactInfoTextBox.TabIndex = 16;
            // 
            // certificateChainCheckBox
            // 
            this.certificateChainCheckBox.AutoSize = true;
            this.certificateChainCheckBox.Location = new System.Drawing.Point(14, 134);
            this.certificateChainCheckBox.Name = "certificateChainCheckBox";
            this.certificateChainCheckBox.Size = new System.Drawing.Size(125, 17);
            this.certificateChainCheckBox.TabIndex = 18;
            this.certificateChainCheckBox.Text = "Add Certificate Chain";
            this.certificateChainCheckBox.UseVisualStyleBackColor = true;
            this.certificateChainCheckBox.CheckedChanged += new System.EventHandler(this.signatureTypeComboBox_SelectedItemChanged);
            // 
            // signatureTypeComboBox
            // 
            this.signatureTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signatureTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.signatureTypeComboBox.FormattingEnabled = true;
            this.signatureTypeComboBox.Location = new System.Drawing.Point(14, 257);
            this.signatureTypeComboBox.Name = "signatureTypeComboBox";
            this.signatureTypeComboBox.Size = new System.Drawing.Size(311, 21);
            this.signatureTypeComboBox.TabIndex = 20;
            this.signatureTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.signatureTypeComboBox_SelectedItemChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Signature Type";
            // 
            // addTimestampCheckBox
            // 
            this.addTimestampCheckBox.AutoSize = true;
            this.addTimestampCheckBox.Location = new System.Drawing.Point(14, 157);
            this.addTimestampCheckBox.Name = "addTimestampCheckBox";
            this.addTimestampCheckBox.Size = new System.Drawing.Size(153, 17);
            this.addTimestampCheckBox.TabIndex = 21;
            this.addTimestampCheckBox.Text = "Add Embedded Timestamp";
            this.addTimestampCheckBox.UseVisualStyleBackColor = true;
            this.addTimestampCheckBox.CheckedChanged += new System.EventHandler(this.addTimestampCheckBox_CheckedChanged);
            // 
            // timestampServerSettingsButton
            // 
            this.timestampServerSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timestampServerSettingsButton.Location = new System.Drawing.Point(6, 19);
            this.timestampServerSettingsButton.Name = "timestampServerSettingsButton";
            this.timestampServerSettingsButton.Size = new System.Drawing.Size(302, 23);
            this.timestampServerSettingsButton.TabIndex = 22;
            this.timestampServerSettingsButton.Text = "Timestamp Server Settings...";
            this.timestampServerSettingsButton.UseVisualStyleBackColor = true;
            this.timestampServerSettingsButton.Click += new System.EventHandler(this.timestampServerSettingsButton_Click);
            // 
            // timestampProperitesGroupBox
            // 
            this.timestampProperitesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timestampProperitesGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.timestampProperitesGroupBox.Controls.Add(this.timestampServerSettingsButton);
            this.timestampProperitesGroupBox.Enabled = false;
            this.timestampProperitesGroupBox.Location = new System.Drawing.Point(12, 161);
            this.timestampProperitesGroupBox.Name = "timestampProperitesGroupBox";
            this.timestampProperitesGroupBox.Size = new System.Drawing.Size(314, 72);
            this.timestampProperitesGroupBox.TabIndex = 23;
            this.timestampProperitesGroupBox.TabStop = false;
            // 
            // timestampHashAlgorithmComboBox
            // 
            this.timestampHashAlgorithmComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.timestampHashAlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timestampHashAlgorithmComboBox.FormattingEnabled = true;
            this.timestampHashAlgorithmComboBox.Items.AddRange(new object[] {
            "SHA1",
            "SHA256"});
            this.timestampHashAlgorithmComboBox.Location = new System.Drawing.Point(118, 3);
            this.timestampHashAlgorithmComboBox.Name = "timestampHashAlgorithmComboBox";
            this.timestampHashAlgorithmComboBox.Size = new System.Drawing.Size(187, 21);
            this.timestampHashAlgorithmComboBox.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Hash Algorithm Name";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.timestampHashAlgorithmComboBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 45);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(308, 27);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // CreateSignatureFieldForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(337, 489);
            this.Controls.Add(this.addTimestampCheckBox);
            this.Controls.Add(this.signatureTypeComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.certificateChainCheckBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.contactInfoTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.reasonTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.signerNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.signatureNameTextBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.signatureAppearanceButton);
            this.Controls.Add(this.selectCertificateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.certificateTextBox);
            this.Controls.Add(this.timestampProperitesGroupBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateSignatureFieldForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Digital Signature";
            this.timestampProperitesGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox certificateTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectCertificateButton;
        private System.Windows.Forms.Button signatureAppearanceButton;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox signatureNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox signerNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox reasonTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox contactInfoTextBox;
        private System.Windows.Forms.CheckBox certificateChainCheckBox;
        private System.Windows.Forms.ComboBox signatureTypeComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox addTimestampCheckBox;
        private System.Windows.Forms.Button timestampServerSettingsButton;
        private System.Windows.Forms.GroupBox timestampProperitesGroupBox;
        private System.Windows.Forms.ComboBox timestampHashAlgorithmComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}