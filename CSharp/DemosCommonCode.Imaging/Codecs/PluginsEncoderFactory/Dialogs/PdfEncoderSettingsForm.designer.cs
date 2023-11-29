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
            this.pdfImageCompressionControl1 = new DemosCommonCode.Imaging.Codecs.Dialogs.PdfImageCompressionControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.compressionTabPage.SuspendLayout();
            this.imageTilesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumericUpDown)).BeginInit();
            this.annotationsTabPage.SuspendLayout();
            this.documentInformationTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.compressionTabPage);
            this.tabControl1.Controls.Add(this.annotationsTabPage);
            this.tabControl1.Controls.Add(this.documentInformationTabPage);
            this.tabControl1.Location = new System.Drawing.Point(9, 120);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(406, 331);
            this.tabControl1.TabIndex = 7;
            // 
            // compressionTabPage
            // 
            this.compressionTabPage.Controls.Add(this.pdfImageCompressionControl1);
            this.compressionTabPage.Controls.Add(this.imageTilesGroupBox);
            this.compressionTabPage.Location = new System.Drawing.Point(4, 22);
            this.compressionTabPage.Name = "compressionTabPage";
            this.compressionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.compressionTabPage.Size = new System.Drawing.Size(398, 305);
            this.compressionTabPage.TabIndex = 0;
            this.compressionTabPage.Text = "Compression";
            this.compressionTabPage.UseVisualStyleBackColor = true;
            // 
            // imageTilesGroupBox
            // 
            this.imageTilesGroupBox.AutoSize = true;
            this.imageTilesGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.imageTilesGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.imageTilesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.imageTilesGroupBox.Name = "imageTilesGroupBox";
            this.imageTilesGroupBox.Size = new System.Drawing.Size(392, 71);
            this.imageTilesGroupBox.TabIndex = 28;
            this.imageTilesGroupBox.TabStop = false;
            this.imageTilesGroupBox.Text = "Split image to tiles";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(237, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "pixels";
            // 
            // tileHeightCheckBox
            // 
            this.tileHeightCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tileHeightCheckBox.AutoSize = true;
            this.tileHeightCheckBox.Location = new System.Drawing.Point(3, 30);
            this.tileHeightCheckBox.Name = "tileHeightCheckBox";
            this.tileHeightCheckBox.Size = new System.Drawing.Size(154, 17);
            this.tileHeightCheckBox.TabIndex = 28;
            this.tileHeightCheckBox.Text = "vertical direction, tile height";
            this.tileHeightCheckBox.UseVisualStyleBackColor = true;
            this.tileHeightCheckBox.CheckedChanged += new System.EventHandler(this.UpdateUI_Handler);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "pixels";
            // 
            // tileWidthCheckBox
            // 
            this.tileWidthCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tileWidthCheckBox.AutoSize = true;
            this.tileWidthCheckBox.Location = new System.Drawing.Point(3, 4);
            this.tileWidthCheckBox.Name = "tileWidthCheckBox";
            this.tileWidthCheckBox.Size = new System.Drawing.Size(161, 17);
            this.tileWidthCheckBox.TabIndex = 26;
            this.tileWidthCheckBox.Text = "horizontal direction, tile width";
            this.tileWidthCheckBox.UseVisualStyleBackColor = true;
            this.tileWidthCheckBox.CheckedChanged += new System.EventHandler(this.UpdateUI_Handler);
            // 
            // tileWidthNumericUpDown
            // 
            this.tileWidthNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tileWidthNumericUpDown.Location = new System.Drawing.Point(170, 3);
            this.tileWidthNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tileWidthNumericUpDown.Name = "tileWidthNumericUpDown";
            this.tileWidthNumericUpDown.Size = new System.Drawing.Size(61, 20);
            this.tileWidthNumericUpDown.TabIndex = 24;
            this.tileWidthNumericUpDown.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // tileHeightNumericUpDown
            // 
            this.tileHeightNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tileHeightNumericUpDown.Location = new System.Drawing.Point(170, 29);
            this.tileHeightNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tileHeightNumericUpDown.Name = "tileHeightNumericUpDown";
            this.tileHeightNumericUpDown.Size = new System.Drawing.Size(61, 20);
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
            this.annotationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.annotationsTabPage.Name = "annotationsTabPage";
            this.annotationsTabPage.Size = new System.Drawing.Size(398, 305);
            this.annotationsTabPage.TabIndex = 2;
            this.annotationsTabPage.Text = "Annotations";
            this.annotationsTabPage.UseVisualStyleBackColor = true;
            // 
            // annotationsPdfAppearanceCheckBox
            // 
            this.annotationsPdfAppearanceCheckBox.AutoSize = true;
            this.annotationsPdfAppearanceCheckBox.Location = new System.Drawing.Point(7, 67);
            this.annotationsPdfAppearanceCheckBox.Name = "annotationsPdfAppearanceCheckBox";
            this.annotationsPdfAppearanceCheckBox.Size = new System.Drawing.Size(154, 17);
            this.annotationsPdfAppearanceCheckBox.TabIndex = 11;
            this.annotationsPdfAppearanceCheckBox.Text = "Generate PDF appearance";
            this.annotationsPdfAppearanceCheckBox.UseVisualStyleBackColor = true;
            // 
            // annotationXmpCheckBox
            // 
            this.annotationXmpCheckBox.AutoSize = true;
            this.annotationXmpCheckBox.Location = new System.Drawing.Point(7, 44);
            this.annotationXmpCheckBox.Name = "annotationXmpCheckBox";
            this.annotationXmpCheckBox.Size = new System.Drawing.Size(93, 17);
            this.annotationXmpCheckBox.TabIndex = 10;
            this.annotationXmpCheckBox.Text = "Vintasoft XMP";
            this.annotationXmpCheckBox.UseVisualStyleBackColor = true;
            // 
            // annotationsBinaryCheckBox
            // 
            this.annotationsBinaryCheckBox.AutoSize = true;
            this.annotationsBinaryCheckBox.Location = new System.Drawing.Point(7, 21);
            this.annotationsBinaryCheckBox.Name = "annotationsBinaryCheckBox";
            this.annotationsBinaryCheckBox.Size = new System.Drawing.Size(99, 17);
            this.annotationsBinaryCheckBox.TabIndex = 9;
            this.annotationsBinaryCheckBox.Text = "Vintasoft Binary";
            this.annotationsBinaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // documentInformationTabPage
            // 
            this.documentInformationTabPage.Controls.Add(this.tableLayoutPanel3);
            this.documentInformationTabPage.Location = new System.Drawing.Point(4, 22);
            this.documentInformationTabPage.Name = "documentInformationTabPage";
            this.documentInformationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.documentInformationTabPage.Size = new System.Drawing.Size(398, 305);
            this.documentInformationTabPage.TabIndex = 1;
            this.documentInformationTabPage.Text = "Document information";
            this.documentInformationTabPage.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Producer";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Keywords";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Subject";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Creator";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Author";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Title";
            // 
            // producerTextBox
            // 
            this.producerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.producerTextBox.Location = new System.Drawing.Point(62, 133);
            this.producerTextBox.Name = "producerTextBox";
            this.producerTextBox.Size = new System.Drawing.Size(327, 20);
            this.producerTextBox.TabIndex = 5;
            // 
            // keywordsTextBox
            // 
            this.keywordsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.keywordsTextBox.Location = new System.Drawing.Point(62, 107);
            this.keywordsTextBox.Name = "keywordsTextBox";
            this.keywordsTextBox.Size = new System.Drawing.Size(327, 20);
            this.keywordsTextBox.TabIndex = 4;
            // 
            // creatorTextBox
            // 
            this.creatorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.creatorTextBox.Location = new System.Drawing.Point(62, 81);
            this.creatorTextBox.Name = "creatorTextBox";
            this.creatorTextBox.Size = new System.Drawing.Size(327, 20);
            this.creatorTextBox.TabIndex = 3;
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectTextBox.Location = new System.Drawing.Point(62, 55);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(327, 20);
            this.subjectTextBox.TabIndex = 2;
            // 
            // authorTextBox
            // 
            this.authorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.authorTextBox.Location = new System.Drawing.Point(62, 29);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(327, 20);
            this.authorTextBox.TabIndex = 1;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(62, 3);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(327, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // appendCheckBox
            // 
            this.appendCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.appendCheckBox.AutoSize = true;
            this.appendCheckBox.Location = new System.Drawing.Point(3, 5);
            this.appendCheckBox.Name = "appendCheckBox";
            this.appendCheckBox.Size = new System.Drawing.Size(163, 17);
            this.appendCheckBox.TabIndex = 8;
            this.appendCheckBox.Text = "Append to existing document";
            this.appendCheckBox.UseVisualStyleBackColor = true;
            this.appendCheckBox.CheckedChanged += new System.EventHandler(this.appendCheckBox_CheckedChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(259, 457);
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
            this.buttonCancel.Location = new System.Drawing.Point(337, 457);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // pdfaCheckBox
            // 
            this.pdfaCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pdfaCheckBox.AutoSize = true;
            this.pdfaCheckBox.Location = new System.Drawing.Point(3, 32);
            this.pdfaCheckBox.Name = "pdfaCheckBox";
            this.pdfaCheckBox.Size = new System.Drawing.Size(114, 17);
            this.pdfaCheckBox.TabIndex = 11;
            this.pdfaCheckBox.Text = "PDF/A Compatible";
            this.pdfaCheckBox.UseVisualStyleBackColor = true;
            this.pdfaCheckBox.CheckedChanged += new System.EventHandler(this.pdfaCheckBox_CheckedChanged);
            // 
            // createThumbnailsCheckBox
            // 
            this.createThumbnailsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.createThumbnailsCheckBox.AutoSize = true;
            this.createThumbnailsCheckBox.Location = new System.Drawing.Point(3, 59);
            this.createThumbnailsCheckBox.Name = "createThumbnailsCheckBox";
            this.createThumbnailsCheckBox.Size = new System.Drawing.Size(110, 17);
            this.createThumbnailsCheckBox.TabIndex = 12;
            this.createThumbnailsCheckBox.Text = "Create thumbnails";
            this.createThumbnailsCheckBox.UseVisualStyleBackColor = true;
            // 
            // updateModeComboBox
            // 
            this.updateModeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.updateModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updateModeComboBox.FormattingEnabled = true;
            this.updateModeComboBox.Location = new System.Drawing.Point(172, 84);
            this.updateModeComboBox.Name = "updateModeComboBox";
            this.updateModeComboBox.Size = new System.Drawing.Size(121, 21);
            this.updateModeComboBox.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Document update mode";
            // 
            // conformanceComboBox
            // 
            this.conformanceComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.conformanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conformanceComboBox.Enabled = false;
            this.conformanceComboBox.FormattingEnabled = true;
            this.conformanceComboBox.Location = new System.Drawing.Point(172, 30);
            this.conformanceComboBox.Name = "conformanceComboBox";
            this.conformanceComboBox.Size = new System.Drawing.Size(121, 21);
            this.conformanceComboBox.TabIndex = 15;
            // 
            // pdfImageCompressionControl1
            // 
#if !REMOVE_PDF_PLUGIN
            this.pdfImageCompressionControl1.Compression = Vintasoft.Imaging.Pdf.PdfCompression.Auto;
            this.pdfImageCompressionControl1.CompressionSettings = null;
#endif
            this.pdfImageCompressionControl1.IsMrcCompressionOnly = false;
            this.pdfImageCompressionControl1.Location = new System.Drawing.Point(6, 80);
#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            this.pdfImageCompressionControl1.MrcCompressionSettings = null;
#endif
            this.pdfImageCompressionControl1.Name = "pdfImageCompressionControl1";
            this.pdfImageCompressionControl1.Size = new System.Drawing.Size(386, 219);
            this.pdfImageCompressionControl1.TabIndex = 29;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.appendCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.updateModeComboBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.conformanceComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pdfaCheckBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.createThumbnailsCheckBox, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 108);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tileWidthCheckBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tileHeightCheckBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tileWidthNumericUpDown, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tileHeightNumericUpDown, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(386, 52);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.producerTextBox, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.keywordsTextBox, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.creatorTextBox, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.subjectTextBox, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.authorTextBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.titleTextBox, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(392, 299);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // PdfEncoderSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(424, 492);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
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
            this.compressionTabPage.PerformLayout();
            this.imageTilesGroupBox.ResumeLayout(false);
            this.imageTilesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumericUpDown)).EndInit();
            this.annotationsTabPage.ResumeLayout(false);
            this.annotationsTabPage.PerformLayout();
            this.documentInformationTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}