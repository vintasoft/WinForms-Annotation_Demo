namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    partial class PdfEncoderSettingsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.compressionTabPage = new System.Windows.Forms.TabPage();
            this.pdfImageCompressionControl1 = new DemosCommonCode.Imaging.Codecs.Dialogs.PdfImageCompressionControl();
            this.imageTilesGroupBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tileHeightCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tileWidthCheckBox = new System.Windows.Forms.CheckBox();
            this.tileWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tileHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.annotationsTabPage = new System.Windows.Forms.TabPage();
            this.annotationsPdfAppearanceCheckBox = new System.Windows.Forms.CheckBox();
            this.annotationXmpCheckBox = new System.Windows.Forms.CheckBox();
            this.annotationsBinaryCheckBox = new System.Windows.Forms.CheckBox();
            this.documentInformationTabPage = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.producerTextBox = new System.Windows.Forms.TextBox();
            this.keywordsTextBox = new System.Windows.Forms.TextBox();
            this.creatorTextBox = new System.Windows.Forms.TextBox();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.appendCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.pdfaCheckBox = new System.Windows.Forms.CheckBox();
            this.createThumbnailsCheckBox = new System.Windows.Forms.CheckBox();
            this.updateModeComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.conformanceComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.compressionTabPage.SuspendLayout();
            this.imageTilesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumericUpDown)).BeginInit();
            this.annotationsTabPage.SuspendLayout();
            this.documentInformationTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.compressionTabPage);
            this.tabControl1.Controls.Add(this.annotationsTabPage);
            this.tabControl1.Controls.Add(this.documentInformationTabPage);
            this.tabControl1.Location = new System.Drawing.Point(1, 102);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(411, 325);
            this.tabControl1.TabIndex = 7;
            // 
            // compressionTabPage
            // 
            this.compressionTabPage.Controls.Add(this.pdfImageCompressionControl1);
            this.compressionTabPage.Controls.Add(this.imageTilesGroupBox);
            this.compressionTabPage.Location = new System.Drawing.Point(4, 24);
            this.compressionTabPage.Name = "compressionTabPage";
            this.compressionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.compressionTabPage.Size = new System.Drawing.Size(403, 297);
            this.compressionTabPage.TabIndex = 0;
            this.compressionTabPage.Text = "Compression";
            this.compressionTabPage.UseVisualStyleBackColor = true;
            // 
            // pdfImageCompressionControl1
            // 
#if !REMOVE_PDF_PLUGIN
            this.pdfImageCompressionControl1.Compression = Vintasoft.Imaging.Pdf.PdfCompression.Auto;
            this.pdfImageCompressionControl1.CompressionSettings = null;
#endif
            this.pdfImageCompressionControl1.IsMrcCompressionOnly = false;
            this.pdfImageCompressionControl1.Location = new System.Drawing.Point(7, 69);
#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            this.pdfImageCompressionControl1.MrcCompressionSettings = null;
#endif
            this.pdfImageCompressionControl1.Name = "pdfImageCompressionControl1";
            this.pdfImageCompressionControl1.Size = new System.Drawing.Size(390, 226);
            this.pdfImageCompressionControl1.TabIndex = 29;
            // 
            // imageTilesGroupBox
            // 
            this.imageTilesGroupBox.Controls.Add(this.label8);
            this.imageTilesGroupBox.Controls.Add(this.tileHeightCheckBox);
            this.imageTilesGroupBox.Controls.Add(this.label1);
            this.imageTilesGroupBox.Controls.Add(this.tileWidthCheckBox);
            this.imageTilesGroupBox.Controls.Add(this.tileWidthNumericUpDown);
            this.imageTilesGroupBox.Controls.Add(this.tileHeightNumericUpDown);
            this.imageTilesGroupBox.Location = new System.Drawing.Point(8, 6);
            this.imageTilesGroupBox.Name = "imageTilesGroupBox";
            this.imageTilesGroupBox.Size = new System.Drawing.Size(389, 63);
            this.imageTilesGroupBox.TabIndex = 28;
            this.imageTilesGroupBox.TabStop = false;
            this.imageTilesGroupBox.Text = "Split image to tiles";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "pixels";
            // 
            // tileHeightCheckBox
            // 
            this.tileHeightCheckBox.AutoSize = true;
            this.tileHeightCheckBox.Location = new System.Drawing.Point(8, 40);
            this.tileHeightCheckBox.Name = "tileHeightCheckBox";
            this.tileHeightCheckBox.Size = new System.Drawing.Size(173, 19);
            this.tileHeightCheckBox.TabIndex = 28;
            this.tileHeightCheckBox.Text = "vertical direction, tile height";
            this.tileHeightCheckBox.UseVisualStyleBackColor = true;
            this.tileHeightCheckBox.CheckedChanged += new System.EventHandler(this.UpdateUI_Handler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "pixels";
            // 
            // tileWidthCheckBox
            // 
            this.tileWidthCheckBox.AutoSize = true;
            this.tileWidthCheckBox.Location = new System.Drawing.Point(8, 19);
            this.tileWidthCheckBox.Name = "tileWidthCheckBox";
            this.tileWidthCheckBox.Size = new System.Drawing.Size(184, 19);
            this.tileWidthCheckBox.TabIndex = 26;
            this.tileWidthCheckBox.Text = "horizontal direction, tile width";
            this.tileWidthCheckBox.UseVisualStyleBackColor = true;
            this.tileWidthCheckBox.CheckedChanged += new System.EventHandler(this.UpdateUI_Handler);
            // 
            // tileWidthNumericUpDown
            // 
            this.tileWidthNumericUpDown.Location = new System.Drawing.Point(197, 18);
            this.tileWidthNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tileWidthNumericUpDown.Name = "tileWidthNumericUpDown";
            this.tileWidthNumericUpDown.Size = new System.Drawing.Size(61, 23);
            this.tileWidthNumericUpDown.TabIndex = 24;
            this.tileWidthNumericUpDown.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // tileHeightNumericUpDown
            // 
            this.tileHeightNumericUpDown.Location = new System.Drawing.Point(197, 39);
            this.tileHeightNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tileHeightNumericUpDown.Name = "tileHeightNumericUpDown";
            this.tileHeightNumericUpDown.Size = new System.Drawing.Size(61, 23);
            this.tileHeightNumericUpDown.TabIndex = 25;
            this.tileHeightNumericUpDown.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // annotationsTabPage
            // 
            this.annotationsTabPage.Controls.Add(this.annotationsPdfAppearanceCheckBox);
            this.annotationsTabPage.Controls.Add(this.annotationXmpCheckBox);
            this.annotationsTabPage.Controls.Add(this.annotationsBinaryCheckBox);
            this.annotationsTabPage.Location = new System.Drawing.Point(4, 24);
            this.annotationsTabPage.Name = "annotationsTabPage";
            this.annotationsTabPage.Size = new System.Drawing.Size(403, 297);
            this.annotationsTabPage.TabIndex = 2;
            this.annotationsTabPage.Text = "Annotations";
            this.annotationsTabPage.UseVisualStyleBackColor = true;
            // 
            // annotationsPdfAppearanceCheckBox
            // 
            this.annotationsPdfAppearanceCheckBox.AutoSize = true;
            this.annotationsPdfAppearanceCheckBox.Location = new System.Drawing.Point(7, 67);
            this.annotationsPdfAppearanceCheckBox.Name = "annotationsPdfAppearanceCheckBox";
            this.annotationsPdfAppearanceCheckBox.Size = new System.Drawing.Size(161, 19);
            this.annotationsPdfAppearanceCheckBox.TabIndex = 11;
            this.annotationsPdfAppearanceCheckBox.Text = "Generate PDF appearance";
            this.annotationsPdfAppearanceCheckBox.UseVisualStyleBackColor = true;
            // 
            // annotationXmpCheckBox
            // 
            this.annotationXmpCheckBox.AutoSize = true;
            this.annotationXmpCheckBox.Location = new System.Drawing.Point(7, 44);
            this.annotationXmpCheckBox.Name = "annotationXmpCheckBox";
            this.annotationXmpCheckBox.Size = new System.Drawing.Size(101, 19);
            this.annotationXmpCheckBox.TabIndex = 10;
            this.annotationXmpCheckBox.Text = "Vintasoft XMP";
            this.annotationXmpCheckBox.UseVisualStyleBackColor = true;
            // 
            // annotationsBinaryCheckBox
            // 
            this.annotationsBinaryCheckBox.AutoSize = true;
            this.annotationsBinaryCheckBox.Location = new System.Drawing.Point(7, 21);
            this.annotationsBinaryCheckBox.Name = "annotationsBinaryCheckBox";
            this.annotationsBinaryCheckBox.Size = new System.Drawing.Size(109, 19);
            this.annotationsBinaryCheckBox.TabIndex = 9;
            this.annotationsBinaryCheckBox.Text = "Vintasoft Binary";
            this.annotationsBinaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // documentInformationTabPage
            // 
            this.documentInformationTabPage.Controls.Add(this.label7);
            this.documentInformationTabPage.Controls.Add(this.label6);
            this.documentInformationTabPage.Controls.Add(this.label5);
            this.documentInformationTabPage.Controls.Add(this.label4);
            this.documentInformationTabPage.Controls.Add(this.label3);
            this.documentInformationTabPage.Controls.Add(this.label2);
            this.documentInformationTabPage.Controls.Add(this.producerTextBox);
            this.documentInformationTabPage.Controls.Add(this.keywordsTextBox);
            this.documentInformationTabPage.Controls.Add(this.creatorTextBox);
            this.documentInformationTabPage.Controls.Add(this.subjectTextBox);
            this.documentInformationTabPage.Controls.Add(this.authorTextBox);
            this.documentInformationTabPage.Controls.Add(this.titleTextBox);
            this.documentInformationTabPage.Location = new System.Drawing.Point(4, 24);
            this.documentInformationTabPage.Name = "documentInformationTabPage";
            this.documentInformationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.documentInformationTabPage.Size = new System.Drawing.Size(403, 297);
            this.documentInformationTabPage.TabIndex = 1;
            this.documentInformationTabPage.Text = "Document information";
            this.documentInformationTabPage.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Producer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Keywords";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Subject";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Creator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Author";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Title";
            // 
            // producerTextBox
            // 
            this.producerTextBox.Location = new System.Drawing.Point(69, 135);
            this.producerTextBox.Name = "producerTextBox";
            this.producerTextBox.Size = new System.Drawing.Size(328, 23);
            this.producerTextBox.TabIndex = 5;
            // 
            // keywordsTextBox
            // 
            this.keywordsTextBox.Location = new System.Drawing.Point(69, 109);
            this.keywordsTextBox.Name = "keywordsTextBox";
            this.keywordsTextBox.Size = new System.Drawing.Size(328, 23);
            this.keywordsTextBox.TabIndex = 4;
            // 
            // creatorTextBox
            // 
            this.creatorTextBox.Location = new System.Drawing.Point(69, 83);
            this.creatorTextBox.Name = "creatorTextBox";
            this.creatorTextBox.Size = new System.Drawing.Size(328, 23);
            this.creatorTextBox.TabIndex = 3;
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(69, 57);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(328, 23);
            this.subjectTextBox.TabIndex = 2;
            // 
            // authorTextBox
            // 
            this.authorTextBox.Location = new System.Drawing.Point(69, 32);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(328, 23);
            this.authorTextBox.TabIndex = 1;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(69, 6);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(328, 23);
            this.titleTextBox.TabIndex = 0;
            // 
            // appendCheckBox
            // 
            this.appendCheckBox.AutoSize = true;
            this.appendCheckBox.Location = new System.Drawing.Point(8, 7);
            this.appendCheckBox.Name = "appendCheckBox";
            this.appendCheckBox.Size = new System.Drawing.Size(184, 19);
            this.appendCheckBox.TabIndex = 8;
            this.appendCheckBox.Text = "Append to existing document";
            this.appendCheckBox.UseVisualStyleBackColor = true;
            this.appendCheckBox.CheckedChanged += new System.EventHandler(this.appendCheckBox_CheckedChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(191, 433);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 9;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(269, 433);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // pdfaCheckBox
            // 
            this.pdfaCheckBox.AutoSize = true;
            this.pdfaCheckBox.Location = new System.Drawing.Point(8, 28);
            this.pdfaCheckBox.Name = "pdfaCheckBox";
            this.pdfaCheckBox.Size = new System.Drawing.Size(125, 19);
            this.pdfaCheckBox.TabIndex = 11;
            this.pdfaCheckBox.Text = "PDF/A Compatible";
            this.pdfaCheckBox.UseVisualStyleBackColor = true;
            this.pdfaCheckBox.CheckedChanged += new System.EventHandler(this.pdfaCheckBox_CheckedChanged);
            // 
            // createThumbnailsCheckBox
            // 
            this.createThumbnailsCheckBox.AutoSize = true;
            this.createThumbnailsCheckBox.Location = new System.Drawing.Point(8, 50);
            this.createThumbnailsCheckBox.Name = "createThumbnailsCheckBox";
            this.createThumbnailsCheckBox.Size = new System.Drawing.Size(123, 19);
            this.createThumbnailsCheckBox.TabIndex = 12;
            this.createThumbnailsCheckBox.Text = "Create thumbnails";
            this.createThumbnailsCheckBox.UseVisualStyleBackColor = true;
            // 
            // updateModeComboBox
            // 
            this.updateModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updateModeComboBox.FormattingEnabled = true;
            this.updateModeComboBox.Location = new System.Drawing.Point(150, 71);
            this.updateModeComboBox.Name = "updateModeComboBox";
            this.updateModeComboBox.Size = new System.Drawing.Size(121, 23);
            this.updateModeComboBox.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "Document update mode";
            // 
            // conformanceComboBox
            // 
            this.conformanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conformanceComboBox.Enabled = false;
            this.conformanceComboBox.FormattingEnabled = true;
            this.conformanceComboBox.Location = new System.Drawing.Point(150, 26);
            this.conformanceComboBox.Name = "conformanceComboBox";
            this.conformanceComboBox.Size = new System.Drawing.Size(121, 23);
            this.conformanceComboBox.TabIndex = 15;
            // 
            // PdfEncoderSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(424, 468);
            this.Controls.Add(this.conformanceComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.updateModeComboBox);
            this.Controls.Add(this.createThumbnailsCheckBox);
            this.Controls.Add(this.pdfaCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.appendCheckBox);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PdfEncoderSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PDF Encoder Settings";
            this.tabControl1.ResumeLayout(false);
            this.compressionTabPage.ResumeLayout(false);
            this.imageTilesGroupBox.ResumeLayout(false);
            this.imageTilesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumericUpDown)).EndInit();
            this.annotationsTabPage.ResumeLayout(false);
            this.annotationsTabPage.PerformLayout();
            this.documentInformationTabPage.ResumeLayout(false);
            this.documentInformationTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage compressionTabPage;
        private System.Windows.Forms.TabPage documentInformationTabPage;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox producerTextBox;
        private System.Windows.Forms.TextBox keywordsTextBox;
        private System.Windows.Forms.TextBox creatorTextBox;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox appendCheckBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox pdfaCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage annotationsTabPage;
        private System.Windows.Forms.CheckBox annotationsPdfAppearanceCheckBox;
        private System.Windows.Forms.CheckBox annotationXmpCheckBox;
        private System.Windows.Forms.CheckBox annotationsBinaryCheckBox;
        private System.Windows.Forms.CheckBox createThumbnailsCheckBox;
        private System.Windows.Forms.NumericUpDown tileHeightNumericUpDown;
        private System.Windows.Forms.NumericUpDown tileWidthNumericUpDown;
        private System.Windows.Forms.GroupBox imageTilesGroupBox;
        private System.Windows.Forms.CheckBox tileWidthCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox tileHeightCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox updateModeComboBox;
        private System.Windows.Forms.Label label9;
        private PdfImageCompressionControl pdfImageCompressionControl1;
        private System.Windows.Forms.ComboBox conformanceComboBox;
    }
}