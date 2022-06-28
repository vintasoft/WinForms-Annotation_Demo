namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    partial class TiffEncoderSettingsForm
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
            this.addImagesToExistingFileCheckBox = new System.Windows.Forms.CheckBox();
            this.zipCompressionRadioButton = new System.Windows.Forms.RadioButton();
            this.autoCompressionRadioButton = new System.Windows.Forms.RadioButton();
            this.jpegCompressionRadioButton = new System.Windows.Forms.RadioButton();
            this.lzwCompressionRadioButton = new System.Windows.Forms.RadioButton();
            this.ccitt4CompressionRadioButton = new System.Windows.Forms.RadioButton();
            this.noneCompressionRadioButton = new System.Windows.Forms.RadioButton();
            this.jpegCompressionAdvancedSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.jpegGrayscaleCheckBox = new System.Windows.Forms.CheckBox();
            this.jpegQualityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.jpegQualityLabel = new System.Windows.Forms.Label();
            this.zipLevelLabel = new System.Windows.Forms.Label();
            this.zipLevelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.compressionTabPage = new System.Windows.Forms.TabPage();
            this.binarizationAdvancedSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.binarizationThresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.binarizationThresholdLabel = new System.Windows.Forms.Label();
            this.binarizationModeComboBox = new System.Windows.Forms.ComboBox();
            this.stripsAndTilesGroupBox = new System.Windows.Forms.GroupBox();
            this.tileHeightLabel = new System.Windows.Forms.Label();
            this.tileHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.useTilesRadioButton = new System.Windows.Forms.RadioButton();
            this.useStripsRadioButton = new System.Windows.Forms.RadioButton();
            this.tileWidthLabel = new System.Windows.Forms.Label();
            this.tileWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rowsPerStripNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rowsPerStripLabel = new System.Windows.Forms.Label();
            this.jpeg2000CompressionRadioButton = new System.Windows.Forms.RadioButton();
            this.lzwCompressionAdvancedSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.lzwUsePredictorCheckBox = new System.Windows.Forms.CheckBox();
            this.zipCompressionAdvancedSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.zipUsePredictorCheckBox = new System.Windows.Forms.CheckBox();
            this.jpeg2000CompressionAdvancedSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.jpeg2000SettingsButton = new System.Windows.Forms.Button();
            this.annotationsTabPage = new System.Windows.Forms.TabPage();
            this.annotationWangCheckBox = new System.Windows.Forms.CheckBox();
            this.annotationXmpCheckBox = new System.Windows.Forms.CheckBox();
            this.annotationsBinaryCheckBox = new System.Windows.Forms.CheckBox();
            this.metadataTabPage = new System.Windows.Forms.TabPage();
            this.copyCommonMetadataCheckBox = new System.Windows.Forms.CheckBox();
            this.copyGpsMetadataCheckBox = new System.Windows.Forms.CheckBox();
            this.copyExifMetadataCheckBox = new System.Windows.Forms.CheckBox();
            this.fileTabPage = new System.Windows.Forms.TabPage();
            this.fileFormatGroupBox = new System.Windows.Forms.GroupBox();
            this.bigEndianRadioButton = new System.Windows.Forms.RadioButton();
            this.littleEndianRadioButton = new System.Windows.Forms.RadioButton();
            this.fileVersionGroupBox = new System.Windows.Forms.GroupBox();
            this.bigTiffRadioButton = new System.Windows.Forms.RadioButton();
            this.standardTiffRadioButton = new System.Windows.Forms.RadioButton();
            this.jpegCompressionAdvancedSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipLevelNumericUpDown)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.compressionTabPage.SuspendLayout();
            this.binarizationAdvancedSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binarizationThresholdNumericUpDown)).BeginInit();
            this.stripsAndTilesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsPerStripNumericUpDown)).BeginInit();
            this.lzwCompressionAdvancedSettingsGroupBox.SuspendLayout();
            this.zipCompressionAdvancedSettingsGroupBox.SuspendLayout();
            this.jpeg2000CompressionAdvancedSettingsGroupBox.SuspendLayout();
            this.annotationsTabPage.SuspendLayout();
            this.metadataTabPage.SuspendLayout();
            this.fileTabPage.SuspendLayout();
            this.fileFormatGroupBox.SuspendLayout();
            this.fileVersionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // appendCheckBox
            // 
            this.addImagesToExistingFileCheckBox.AutoSize = true;
            this.addImagesToExistingFileCheckBox.Location = new System.Drawing.Point(8, 12);
            this.addImagesToExistingFileCheckBox.Name = "appendCheckBox";
            this.addImagesToExistingFileCheckBox.Size = new System.Drawing.Size(163, 17);
            this.addImagesToExistingFileCheckBox.TabIndex = 9;
            this.addImagesToExistingFileCheckBox.Text = "Append to existing document";
            this.addImagesToExistingFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // zipCompressionRadioButton
            // 
            this.zipCompressionRadioButton.AutoSize = true;
            this.zipCompressionRadioButton.Location = new System.Drawing.Point(7, 87);
            this.zipCompressionRadioButton.Name = "zipCompressionRadioButton";
            this.zipCompressionRadioButton.Size = new System.Drawing.Size(42, 17);
            this.zipCompressionRadioButton.TabIndex = 4;
            this.zipCompressionRadioButton.Text = "ZIP";
            this.zipCompressionRadioButton.UseVisualStyleBackColor = true;
            this.zipCompressionRadioButton.CheckedChanged += new System.EventHandler(this.UpdateUI);
            // 
            // autoCompressionRadioButton
            // 
            this.autoCompressionRadioButton.AutoSize = true;
            this.autoCompressionRadioButton.Checked = true;
            this.autoCompressionRadioButton.Location = new System.Drawing.Point(7, 7);
            this.autoCompressionRadioButton.Name = "autoCompressionRadioButton";
            this.autoCompressionRadioButton.Size = new System.Drawing.Size(47, 17);
            this.autoCompressionRadioButton.TabIndex = 0;
            this.autoCompressionRadioButton.TabStop = true;
            this.autoCompressionRadioButton.Text = "Auto";
            this.autoCompressionRadioButton.UseVisualStyleBackColor = true;
            this.autoCompressionRadioButton.CheckedChanged += new System.EventHandler(this.UpdateUI);
            // 
            // jpegCompressionRadioButton
            // 
            this.jpegCompressionRadioButton.AutoSize = true;
            this.jpegCompressionRadioButton.Location = new System.Drawing.Point(7, 107);
            this.jpegCompressionRadioButton.Name = "jpegCompressionRadioButton";
            this.jpegCompressionRadioButton.Size = new System.Drawing.Size(52, 17);
            this.jpegCompressionRadioButton.TabIndex = 5;
            this.jpegCompressionRadioButton.Text = "JPEG";
            this.jpegCompressionRadioButton.UseVisualStyleBackColor = true;
            this.jpegCompressionRadioButton.CheckedChanged += new System.EventHandler(this.UpdateUI);
            // 
            // lzwCompressionRadioButton
            // 
            this.lzwCompressionRadioButton.AutoSize = true;
            this.lzwCompressionRadioButton.Location = new System.Drawing.Point(7, 67);
            this.lzwCompressionRadioButton.Name = "lzwCompressionRadioButton";
            this.lzwCompressionRadioButton.Size = new System.Drawing.Size(49, 17);
            this.lzwCompressionRadioButton.TabIndex = 3;
            this.lzwCompressionRadioButton.Text = "LZW";
            this.lzwCompressionRadioButton.UseVisualStyleBackColor = true;
            this.lzwCompressionRadioButton.CheckedChanged += new System.EventHandler(this.UpdateUI);
            // 
            // ccitt4CompressionRadioButton
            // 
            this.ccitt4CompressionRadioButton.AutoSize = true;
            this.ccitt4CompressionRadioButton.Location = new System.Drawing.Point(7, 47);
            this.ccitt4CompressionRadioButton.Name = "ccitt4CompressionRadioButton";
            this.ccitt4CompressionRadioButton.Size = new System.Drawing.Size(97, 17);
            this.ccitt4CompressionRadioButton.TabIndex = 2;
            this.ccitt4CompressionRadioButton.Text = "CCITT Group 4";
            this.ccitt4CompressionRadioButton.UseVisualStyleBackColor = true;
            this.ccitt4CompressionRadioButton.CheckedChanged += new System.EventHandler(this.UpdateUI);
            // 
            // noneCompressionRadioButton
            // 
            this.noneCompressionRadioButton.AutoSize = true;
            this.noneCompressionRadioButton.Location = new System.Drawing.Point(7, 27);
            this.noneCompressionRadioButton.Name = "noneCompressionRadioButton";
            this.noneCompressionRadioButton.Size = new System.Drawing.Size(51, 17);
            this.noneCompressionRadioButton.TabIndex = 1;
            this.noneCompressionRadioButton.Text = "None";
            this.noneCompressionRadioButton.UseVisualStyleBackColor = true;
            this.noneCompressionRadioButton.CheckedChanged += new System.EventHandler(this.UpdateUI);
            // 
            // jpegCompressionAdvancedSettingsGroupBox
            // 
            this.jpegCompressionAdvancedSettingsGroupBox.Controls.Add(this.jpegGrayscaleCheckBox);
            this.jpegCompressionAdvancedSettingsGroupBox.Controls.Add(this.jpegQualityNumericUpDown);
            this.jpegCompressionAdvancedSettingsGroupBox.Controls.Add(this.jpegQualityLabel);
            this.jpegCompressionAdvancedSettingsGroupBox.Location = new System.Drawing.Point(117, 84);
            this.jpegCompressionAdvancedSettingsGroupBox.Name = "jpegCompressionAdvancedSettingsGroupBox";
            this.jpegCompressionAdvancedSettingsGroupBox.Size = new System.Drawing.Size(243, 65);
            this.jpegCompressionAdvancedSettingsGroupBox.TabIndex = 9;
            this.jpegCompressionAdvancedSettingsGroupBox.TabStop = false;
            this.jpegCompressionAdvancedSettingsGroupBox.Text = "JPEG Advanced Settings";
            this.jpegCompressionAdvancedSettingsGroupBox.Visible = false;
            // 
            // jpegGrayscaleCheckBox
            // 
            this.jpegGrayscaleCheckBox.AutoSize = true;
            this.jpegGrayscaleCheckBox.Location = new System.Drawing.Point(9, 42);
            this.jpegGrayscaleCheckBox.Name = "jpegGrayscaleCheckBox";
            this.jpegGrayscaleCheckBox.Size = new System.Drawing.Size(103, 17);
            this.jpegGrayscaleCheckBox.TabIndex = 0;
            this.jpegGrayscaleCheckBox.Text = "Grayscale JPEG";
            this.jpegGrayscaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // jpegQualityNumericUpDown
            // 
            this.jpegQualityNumericUpDown.Location = new System.Drawing.Point(95, 18);
            this.jpegQualityNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.jpegQualityNumericUpDown.Name = "jpegQualityNumericUpDown";
            this.jpegQualityNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.jpegQualityNumericUpDown.TabIndex = 13;
            this.jpegQualityNumericUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // jpegQualityLabel
            // 
            this.jpegQualityLabel.AutoSize = true;
            this.jpegQualityLabel.Location = new System.Drawing.Point(6, 20);
            this.jpegQualityLabel.Name = "jpegQualityLabel";
            this.jpegQualityLabel.Size = new System.Drawing.Size(69, 13);
            this.jpegQualityLabel.TabIndex = 14;
            this.jpegQualityLabel.Text = "JPEG Quality";
            // 
            // zipLevelLabel
            // 
            this.zipLevelLabel.AutoSize = true;
            this.zipLevelLabel.Location = new System.Drawing.Point(6, 42);
            this.zipLevelLabel.Name = "zipLevelLabel";
            this.zipLevelLabel.Size = new System.Drawing.Size(53, 13);
            this.zipLevelLabel.TabIndex = 16;
            this.zipLevelLabel.Text = "ZIP Level";
            // 
            // zipLevelNumericUpDown
            // 
            this.zipLevelNumericUpDown.Location = new System.Drawing.Point(95, 40);
            this.zipLevelNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.zipLevelNumericUpDown.Name = "zipLevelNumericUpDown";
            this.zipLevelNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.zipLevelNumericUpDown.TabIndex = 16;
            this.zipLevelNumericUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(198, 220);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(117, 220);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.compressionTabPage);
            this.tabControl1.Controls.Add(this.annotationsTabPage);
            this.tabControl1.Controls.Add(this.metadataTabPage);
            this.tabControl1.Controls.Add(this.fileTabPage);
            this.tabControl1.Location = new System.Drawing.Point(8, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 181);
            this.tabControl1.TabIndex = 13;
            // 
            // compressionTabPage
            // 
            this.compressionTabPage.Controls.Add(this.binarizationAdvancedSettingsGroupBox);
            this.compressionTabPage.Controls.Add(this.stripsAndTilesGroupBox);
            this.compressionTabPage.Controls.Add(this.jpeg2000CompressionRadioButton);
            this.compressionTabPage.Controls.Add(this.jpegCompressionRadioButton);
            this.compressionTabPage.Controls.Add(this.autoCompressionRadioButton);
            this.compressionTabPage.Controls.Add(this.zipCompressionRadioButton);
            this.compressionTabPage.Controls.Add(this.noneCompressionRadioButton);
            this.compressionTabPage.Controls.Add(this.lzwCompressionRadioButton);
            this.compressionTabPage.Controls.Add(this.ccitt4CompressionRadioButton);
            this.compressionTabPage.Controls.Add(this.jpegCompressionAdvancedSettingsGroupBox);
            this.compressionTabPage.Controls.Add(this.lzwCompressionAdvancedSettingsGroupBox);
            this.compressionTabPage.Controls.Add(this.zipCompressionAdvancedSettingsGroupBox);
            this.compressionTabPage.Controls.Add(this.jpeg2000CompressionAdvancedSettingsGroupBox);
            this.compressionTabPage.Location = new System.Drawing.Point(4, 22);
            this.compressionTabPage.Name = "compressionTabPage";
            this.compressionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.compressionTabPage.Size = new System.Drawing.Size(367, 155);
            this.compressionTabPage.TabIndex = 0;
            this.compressionTabPage.Text = "Compression";
            this.compressionTabPage.UseVisualStyleBackColor = true;
            // 
            // binarizationAdvancedSettingsGroupBox
            // 
            this.binarizationAdvancedSettingsGroupBox.Controls.Add(this.binarizationThresholdNumericUpDown);
            this.binarizationAdvancedSettingsGroupBox.Controls.Add(this.binarizationThresholdLabel);
            this.binarizationAdvancedSettingsGroupBox.Controls.Add(this.binarizationModeComboBox);
            this.binarizationAdvancedSettingsGroupBox.Location = new System.Drawing.Point(117, 84);
            this.binarizationAdvancedSettingsGroupBox.Name = "binarizationAdvancedSettingsGroupBox";
            this.binarizationAdvancedSettingsGroupBox.Size = new System.Drawing.Size(243, 65);
            this.binarizationAdvancedSettingsGroupBox.TabIndex = 15;
            this.binarizationAdvancedSettingsGroupBox.TabStop = false;
            this.binarizationAdvancedSettingsGroupBox.Text = "Binarization Advanced Settings";
            this.binarizationAdvancedSettingsGroupBox.Visible = false;
            // 
            // binarizationThresholdNumericUpDown
            // 
            this.binarizationThresholdNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.binarizationThresholdNumericUpDown.Location = new System.Drawing.Point(113, 40);
            this.binarizationThresholdNumericUpDown.Maximum = new decimal(new int[] {
            765,
            0,
            0,
            0});
            this.binarizationThresholdNumericUpDown.Name = "binarizationThresholdNumericUpDown";
            this.binarizationThresholdNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.binarizationThresholdNumericUpDown.TabIndex = 2;
            this.binarizationThresholdNumericUpDown.Visible = false;
            // 
            // binarizationThresholdLabel
            // 
            this.binarizationThresholdLabel.AutoSize = true;
            this.binarizationThresholdLabel.Location = new System.Drawing.Point(9, 42);
            this.binarizationThresholdLabel.Name = "binarizationThresholdLabel";
            this.binarizationThresholdLabel.Size = new System.Drawing.Size(54, 13);
            this.binarizationThresholdLabel.TabIndex = 1;
            this.binarizationThresholdLabel.Text = "Threshold";
            this.binarizationThresholdLabel.Visible = false;
            // 
            // binarizationModeComboBox
            // 
            this.binarizationModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.binarizationModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.binarizationModeComboBox.FormattingEnabled = true;
            this.binarizationModeComboBox.Location = new System.Drawing.Point(9, 16);
            this.binarizationModeComboBox.Name = "binarizationModeComboBox";
            this.binarizationModeComboBox.Size = new System.Drawing.Size(224, 21);
            this.binarizationModeComboBox.TabIndex = 0;
            this.binarizationModeComboBox.SelectedIndexChanged += new System.EventHandler(this.binarizationModeComboBox_SelectedIndexChanged);
            // 
            // stripsAndTilesGroupBox
            // 
            this.stripsAndTilesGroupBox.Controls.Add(this.tileHeightLabel);
            this.stripsAndTilesGroupBox.Controls.Add(this.tileHeightNumericUpDown);
            this.stripsAndTilesGroupBox.Controls.Add(this.useTilesRadioButton);
            this.stripsAndTilesGroupBox.Controls.Add(this.useStripsRadioButton);
            this.stripsAndTilesGroupBox.Controls.Add(this.tileWidthLabel);
            this.stripsAndTilesGroupBox.Controls.Add(this.tileWidthNumericUpDown);
            this.stripsAndTilesGroupBox.Controls.Add(this.rowsPerStripNumericUpDown);
            this.stripsAndTilesGroupBox.Controls.Add(this.rowsPerStripLabel);
            this.stripsAndTilesGroupBox.Location = new System.Drawing.Point(117, 7);
            this.stripsAndTilesGroupBox.Name = "stripsAndTilesGroupBox";
            this.stripsAndTilesGroupBox.Size = new System.Drawing.Size(243, 71);
            this.stripsAndTilesGroupBox.TabIndex = 12;
            this.stripsAndTilesGroupBox.TabStop = false;
            this.stripsAndTilesGroupBox.Text = "Strips and Tiles";
            // 
            // tileHeightLabel
            // 
            this.tileHeightLabel.AutoSize = true;
            this.tileHeightLabel.Location = new System.Drawing.Point(170, 21);
            this.tileHeightLabel.Name = "tileHeightLabel";
            this.tileHeightLabel.Size = new System.Drawing.Size(56, 13);
            this.tileHeightLabel.TabIndex = 7;
            this.tileHeightLabel.Text = "Tile height";
            this.tileHeightLabel.Visible = false;
            // 
            // tileHeightNumericUpDown
            // 
            this.tileHeightNumericUpDown.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.tileHeightNumericUpDown.Location = new System.Drawing.Point(173, 37);
            this.tileHeightNumericUpDown.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.tileHeightNumericUpDown.Name = "tileHeightNumericUpDown";
            this.tileHeightNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.tileHeightNumericUpDown.TabIndex = 6;
            this.tileHeightNumericUpDown.Visible = false;
            this.tileHeightNumericUpDown.ValueChanged += new System.EventHandler(this.tileHeightNumericUpDown_ValueChanged);
            // 
            // useTilesRadioButton
            // 
            this.useTilesRadioButton.AutoSize = true;
            this.useTilesRadioButton.Location = new System.Drawing.Point(9, 40);
            this.useTilesRadioButton.Name = "useTilesRadioButton";
            this.useTilesRadioButton.Size = new System.Drawing.Size(65, 17);
            this.useTilesRadioButton.TabIndex = 1;
            this.useTilesRadioButton.Text = "Use tiles";
            this.useTilesRadioButton.UseVisualStyleBackColor = true;
            this.useTilesRadioButton.CheckedChanged += new System.EventHandler(this.UpdateUI);
            // 
            // useStripsRadioButton
            // 
            this.useStripsRadioButton.AutoSize = true;
            this.useStripsRadioButton.Checked = true;
            this.useStripsRadioButton.Location = new System.Drawing.Point(9, 19);
            this.useStripsRadioButton.Name = "useStripsRadioButton";
            this.useStripsRadioButton.Size = new System.Drawing.Size(71, 17);
            this.useStripsRadioButton.TabIndex = 0;
            this.useStripsRadioButton.TabStop = true;
            this.useStripsRadioButton.Text = "Use strips";
            this.useStripsRadioButton.UseVisualStyleBackColor = true;
            this.useStripsRadioButton.CheckedChanged += new System.EventHandler(this.UpdateUI);
            // 
            // tileWidthLabel
            // 
            this.tileWidthLabel.AutoSize = true;
            this.tileWidthLabel.Location = new System.Drawing.Point(92, 21);
            this.tileWidthLabel.Name = "tileWidthLabel";
            this.tileWidthLabel.Size = new System.Drawing.Size(52, 13);
            this.tileWidthLabel.TabIndex = 4;
            this.tileWidthLabel.Text = "Tile width";
            this.tileWidthLabel.Visible = false;
            // 
            // tileWidthNumericUpDown
            // 
            this.tileWidthNumericUpDown.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.tileWidthNumericUpDown.Location = new System.Drawing.Point(95, 37);
            this.tileWidthNumericUpDown.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.tileWidthNumericUpDown.Name = "tileWidthNumericUpDown";
            this.tileWidthNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.tileWidthNumericUpDown.TabIndex = 5;
            this.tileWidthNumericUpDown.Visible = false;
            this.tileWidthNumericUpDown.ValueChanged += new System.EventHandler(this.tileWidthNumericUpDown_ValueChanged);
            // 
            // rowsPerStripNumericUpDown
            // 
            this.rowsPerStripNumericUpDown.Location = new System.Drawing.Point(95, 37);
            this.rowsPerStripNumericUpDown.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.rowsPerStripNumericUpDown.Name = "rowsPerStripNumericUpDown";
            this.rowsPerStripNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.rowsPerStripNumericUpDown.TabIndex = 3;
            // 
            // rowsPerStripLabel
            // 
            this.rowsPerStripLabel.AutoSize = true;
            this.rowsPerStripLabel.Location = new System.Drawing.Point(92, 21);
            this.rowsPerStripLabel.Name = "rowsPerStripLabel";
            this.rowsPerStripLabel.Size = new System.Drawing.Size(74, 13);
            this.rowsPerStripLabel.TabIndex = 2;
            this.rowsPerStripLabel.Text = "Rows per strip";
            // 
            // jpeg2000CompressionRadioButton
            // 
            this.jpeg2000CompressionRadioButton.AutoSize = true;
            this.jpeg2000CompressionRadioButton.BackColor = System.Drawing.Color.White;
            this.jpeg2000CompressionRadioButton.Location = new System.Drawing.Point(7, 127);
            this.jpeg2000CompressionRadioButton.Name = "jpeg2000CompressionRadioButton";
            this.jpeg2000CompressionRadioButton.Size = new System.Drawing.Size(79, 17);
            this.jpeg2000CompressionRadioButton.TabIndex = 6;
            this.jpeg2000CompressionRadioButton.TabStop = true;
            this.jpeg2000CompressionRadioButton.Text = "JPEG 2000";
            this.jpeg2000CompressionRadioButton.UseVisualStyleBackColor = true;
            this.jpeg2000CompressionRadioButton.CheckedChanged += new System.EventHandler(this.UpdateUI);
            // 
            // lzwCompressionAdvancedSettingsGroupBox
            // 
            this.lzwCompressionAdvancedSettingsGroupBox.Controls.Add(this.lzwUsePredictorCheckBox);
            this.lzwCompressionAdvancedSettingsGroupBox.Location = new System.Drawing.Point(117, 84);
            this.lzwCompressionAdvancedSettingsGroupBox.Name = "lzwCompressionAdvancedSettingsGroupBox";
            this.lzwCompressionAdvancedSettingsGroupBox.Size = new System.Drawing.Size(243, 65);
            this.lzwCompressionAdvancedSettingsGroupBox.TabIndex = 13;
            this.lzwCompressionAdvancedSettingsGroupBox.TabStop = false;
            this.lzwCompressionAdvancedSettingsGroupBox.Text = "LZW Advanced Settings";
            this.lzwCompressionAdvancedSettingsGroupBox.Visible = false;
            // 
            // lzwUsePredictorCheckBox
            // 
            this.lzwUsePredictorCheckBox.AutoSize = true;
            this.lzwUsePredictorCheckBox.Location = new System.Drawing.Point(9, 20);
            this.lzwUsePredictorCheckBox.Name = "lzwUsePredictorCheckBox";
            this.lzwUsePredictorCheckBox.Size = new System.Drawing.Size(89, 17);
            this.lzwUsePredictorCheckBox.TabIndex = 17;
            this.lzwUsePredictorCheckBox.Text = "Use predictor";
            this.lzwUsePredictorCheckBox.UseVisualStyleBackColor = true;
            // 
            // zipCompressionAdvancedSettingsGroupBox
            // 
            this.zipCompressionAdvancedSettingsGroupBox.Controls.Add(this.zipUsePredictorCheckBox);
            this.zipCompressionAdvancedSettingsGroupBox.Controls.Add(this.zipLevelLabel);
            this.zipCompressionAdvancedSettingsGroupBox.Controls.Add(this.zipLevelNumericUpDown);
            this.zipCompressionAdvancedSettingsGroupBox.Location = new System.Drawing.Point(117, 84);
            this.zipCompressionAdvancedSettingsGroupBox.Name = "zipCompressionAdvancedSettingsGroupBox";
            this.zipCompressionAdvancedSettingsGroupBox.Size = new System.Drawing.Size(243, 65);
            this.zipCompressionAdvancedSettingsGroupBox.TabIndex = 11;
            this.zipCompressionAdvancedSettingsGroupBox.TabStop = false;
            this.zipCompressionAdvancedSettingsGroupBox.Text = "ZIP Advanced Settings";
            this.zipCompressionAdvancedSettingsGroupBox.Visible = false;
            // 
            // zipUsePredictorCheckBox
            // 
            this.zipUsePredictorCheckBox.AutoSize = true;
            this.zipUsePredictorCheckBox.Location = new System.Drawing.Point(9, 20);
            this.zipUsePredictorCheckBox.Name = "zipUsePredictorCheckBox";
            this.zipUsePredictorCheckBox.Size = new System.Drawing.Size(89, 17);
            this.zipUsePredictorCheckBox.TabIndex = 17;
            this.zipUsePredictorCheckBox.Text = "Use predictor";
            this.zipUsePredictorCheckBox.UseVisualStyleBackColor = true;
            // 
            // jpeg2000CompressionAdvancedSettingsGroupBox
            // 
            this.jpeg2000CompressionAdvancedSettingsGroupBox.Controls.Add(this.jpeg2000SettingsButton);
            this.jpeg2000CompressionAdvancedSettingsGroupBox.Location = new System.Drawing.Point(117, 84);
            this.jpeg2000CompressionAdvancedSettingsGroupBox.Name = "jpeg2000CompressionAdvancedSettingsGroupBox";
            this.jpeg2000CompressionAdvancedSettingsGroupBox.Size = new System.Drawing.Size(243, 65);
            this.jpeg2000CompressionAdvancedSettingsGroupBox.TabIndex = 10;
            this.jpeg2000CompressionAdvancedSettingsGroupBox.TabStop = false;
            this.jpeg2000CompressionAdvancedSettingsGroupBox.Text = "JPEG2000 Advanced Settings";
            this.jpeg2000CompressionAdvancedSettingsGroupBox.Visible = false;
            // 
            // jpeg2000SettingsButton
            // 
            this.jpeg2000SettingsButton.Location = new System.Drawing.Point(9, 19);
            this.jpeg2000SettingsButton.Name = "jpeg2000SettingsButton";
            this.jpeg2000SettingsButton.Size = new System.Drawing.Size(131, 23);
            this.jpeg2000SettingsButton.TabIndex = 0;
            this.jpeg2000SettingsButton.Text = "JPEG2000 Settings...";
            this.jpeg2000SettingsButton.UseVisualStyleBackColor = true;
            this.jpeg2000SettingsButton.Click += new System.EventHandler(this.jpeg2000SettingsButton_Click);
            // 
            // annotationsTabPage
            // 
            this.annotationsTabPage.Controls.Add(this.annotationWangCheckBox);
            this.annotationsTabPage.Controls.Add(this.annotationXmpCheckBox);
            this.annotationsTabPage.Controls.Add(this.annotationsBinaryCheckBox);
            this.annotationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.annotationsTabPage.Name = "annotationsTabPage";
            this.annotationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.annotationsTabPage.Size = new System.Drawing.Size(367, 155);
            this.annotationsTabPage.TabIndex = 1;
            this.annotationsTabPage.Text = "Annotations";
            this.annotationsTabPage.UseVisualStyleBackColor = true;
            // 
            // annotationWangCheckBox
            // 
            this.annotationWangCheckBox.AutoSize = true;
            this.annotationWangCheckBox.Location = new System.Drawing.Point(7, 53);
            this.annotationWangCheckBox.Name = "annotationWangCheckBox";
            this.annotationWangCheckBox.Size = new System.Drawing.Size(60, 17);
            this.annotationWangCheckBox.TabIndex = 13;
            this.annotationWangCheckBox.Text = "WANG";
            this.annotationWangCheckBox.UseVisualStyleBackColor = true;
            // 
            // annotationXmpCheckBox
            // 
            this.annotationXmpCheckBox.AutoSize = true;
            this.annotationXmpCheckBox.Location = new System.Drawing.Point(7, 30);
            this.annotationXmpCheckBox.Name = "annotationXmpCheckBox";
            this.annotationXmpCheckBox.Size = new System.Drawing.Size(93, 17);
            this.annotationXmpCheckBox.TabIndex = 12;
            this.annotationXmpCheckBox.Text = "Vintasoft XMP";
            this.annotationXmpCheckBox.UseVisualStyleBackColor = true;
            // 
            // annotationsBinaryCheckBox
            // 
            this.annotationsBinaryCheckBox.AutoSize = true;
            this.annotationsBinaryCheckBox.Location = new System.Drawing.Point(7, 7);
            this.annotationsBinaryCheckBox.Name = "annotationsBinaryCheckBox";
            this.annotationsBinaryCheckBox.Size = new System.Drawing.Size(99, 17);
            this.annotationsBinaryCheckBox.TabIndex = 11;
            this.annotationsBinaryCheckBox.Text = "Vintasoft Binary";
            this.annotationsBinaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // metadataTabPage
            // 
            this.metadataTabPage.Controls.Add(this.copyCommonMetadataCheckBox);
            this.metadataTabPage.Controls.Add(this.copyGpsMetadataCheckBox);
            this.metadataTabPage.Controls.Add(this.copyExifMetadataCheckBox);
            this.metadataTabPage.Location = new System.Drawing.Point(4, 22);
            this.metadataTabPage.Name = "metadataTabPage";
            this.metadataTabPage.Size = new System.Drawing.Size(367, 155);
            this.metadataTabPage.TabIndex = 2;
            this.metadataTabPage.Text = "Metadata";
            this.metadataTabPage.UseVisualStyleBackColor = true;
            // 
            // copyCommonMetadataCheckBox
            // 
            this.copyCommonMetadataCheckBox.AutoSize = true;
            this.copyCommonMetadataCheckBox.Location = new System.Drawing.Point(7, 7);
            this.copyCommonMetadataCheckBox.Name = "copyCommonMetadataCheckBox";
            this.copyCommonMetadataCheckBox.Size = new System.Drawing.Size(140, 17);
            this.copyCommonMetadataCheckBox.TabIndex = 2;
            this.copyCommonMetadataCheckBox.Text = "Copy common metadata";
            this.copyCommonMetadataCheckBox.UseVisualStyleBackColor = true;
            // 
            // copyGpsMetadataCheckBox
            // 
            this.copyGpsMetadataCheckBox.AutoSize = true;
            this.copyGpsMetadataCheckBox.Location = new System.Drawing.Point(7, 53);
            this.copyGpsMetadataCheckBox.Name = "copyGpsMetadataCheckBox";
            this.copyGpsMetadataCheckBox.Size = new System.Drawing.Size(119, 17);
            this.copyGpsMetadataCheckBox.TabIndex = 1;
            this.copyGpsMetadataCheckBox.Text = "Copy Gps metadata";
            this.copyGpsMetadataCheckBox.UseVisualStyleBackColor = true;
            // 
            // copyExifMetadataCheckBox
            // 
            this.copyExifMetadataCheckBox.AutoSize = true;
            this.copyExifMetadataCheckBox.Location = new System.Drawing.Point(7, 30);
            this.copyExifMetadataCheckBox.Name = "copyExifMetadataCheckBox";
            this.copyExifMetadataCheckBox.Size = new System.Drawing.Size(117, 17);
            this.copyExifMetadataCheckBox.TabIndex = 0;
            this.copyExifMetadataCheckBox.Text = "Copy Exif metadata";
            this.copyExifMetadataCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileTabPage
            // 
            this.fileTabPage.Controls.Add(this.fileFormatGroupBox);
            this.fileTabPage.Controls.Add(this.fileVersionGroupBox);
            this.fileTabPage.Location = new System.Drawing.Point(4, 22);
            this.fileTabPage.Name = "fileTabPage";
            this.fileTabPage.Size = new System.Drawing.Size(367, 155);
            this.fileTabPage.TabIndex = 3;
            this.fileTabPage.Text = "File";
            this.fileTabPage.UseVisualStyleBackColor = true;
            // 
            // fileFormatGroupBox
            // 
            this.fileFormatGroupBox.Controls.Add(this.bigEndianRadioButton);
            this.fileFormatGroupBox.Controls.Add(this.littleEndianRadioButton);
            this.fileFormatGroupBox.Location = new System.Drawing.Point(10, 7);
            this.fileFormatGroupBox.Name = "fileFormatGroupBox";
            this.fileFormatGroupBox.Size = new System.Drawing.Size(107, 70);
            this.fileFormatGroupBox.TabIndex = 3;
            this.fileFormatGroupBox.TabStop = false;
            this.fileFormatGroupBox.Text = "File format";
            // 
            // bigEndianRadioButton
            // 
            this.bigEndianRadioButton.AutoSize = true;
            this.bigEndianRadioButton.Location = new System.Drawing.Point(6, 42);
            this.bigEndianRadioButton.Name = "bigEndianRadioButton";
            this.bigEndianRadioButton.Size = new System.Drawing.Size(75, 17);
            this.bigEndianRadioButton.TabIndex = 2;
            this.bigEndianRadioButton.Text = "Big endian";
            this.bigEndianRadioButton.UseVisualStyleBackColor = true;
            // 
            // littleEndianRadioButton
            // 
            this.littleEndianRadioButton.AutoSize = true;
            this.littleEndianRadioButton.Checked = true;
            this.littleEndianRadioButton.Location = new System.Drawing.Point(6, 19);
            this.littleEndianRadioButton.Name = "littleEndianRadioButton";
            this.littleEndianRadioButton.Size = new System.Drawing.Size(82, 17);
            this.littleEndianRadioButton.TabIndex = 1;
            this.littleEndianRadioButton.TabStop = true;
            this.littleEndianRadioButton.Text = "Little endian";
            this.littleEndianRadioButton.UseVisualStyleBackColor = true;
            // 
            // fileVersionGroupBox
            // 
            this.fileVersionGroupBox.Controls.Add(this.bigTiffRadioButton);
            this.fileVersionGroupBox.Controls.Add(this.standardTiffRadioButton);
            this.fileVersionGroupBox.Location = new System.Drawing.Point(123, 7);
            this.fileVersionGroupBox.Name = "fileVersionGroupBox";
            this.fileVersionGroupBox.Size = new System.Drawing.Size(107, 70);
            this.fileVersionGroupBox.TabIndex = 2;
            this.fileVersionGroupBox.TabStop = false;
            this.fileVersionGroupBox.Text = "File version";
            // 
            // bigTiffRadioButton
            // 
            this.bigTiffRadioButton.AutoSize = true;
            this.bigTiffRadioButton.Location = new System.Drawing.Point(6, 42);
            this.bigTiffRadioButton.Name = "bigTiffRadioButton";
            this.bigTiffRadioButton.Size = new System.Drawing.Size(65, 17);
            this.bigTiffRadioButton.TabIndex = 2;
            this.bigTiffRadioButton.Text = "Big TIFF";
            this.bigTiffRadioButton.UseVisualStyleBackColor = true;
            // 
            // standardTiffRadioButton
            // 
            this.standardTiffRadioButton.AutoSize = true;
            this.standardTiffRadioButton.Checked = true;
            this.standardTiffRadioButton.Location = new System.Drawing.Point(6, 19);
            this.standardTiffRadioButton.Name = "standardTiffRadioButton";
            this.standardTiffRadioButton.Size = new System.Drawing.Size(93, 17);
            this.standardTiffRadioButton.TabIndex = 1;
            this.standardTiffRadioButton.TabStop = true;
            this.standardTiffRadioButton.Text = "Standard TIFF";
            this.standardTiffRadioButton.UseVisualStyleBackColor = true;
            // 
            // TiffEncoderSettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(390, 251);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.addImagesToExistingFileCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TiffEncoderSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TIFF Encoder Settings";
            this.jpegCompressionAdvancedSettingsGroupBox.ResumeLayout(false);
            this.jpegCompressionAdvancedSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipLevelNumericUpDown)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.compressionTabPage.ResumeLayout(false);
            this.compressionTabPage.PerformLayout();
            this.binarizationAdvancedSettingsGroupBox.ResumeLayout(false);
            this.binarizationAdvancedSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binarizationThresholdNumericUpDown)).EndInit();
            this.stripsAndTilesGroupBox.ResumeLayout(false);
            this.stripsAndTilesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsPerStripNumericUpDown)).EndInit();
            this.lzwCompressionAdvancedSettingsGroupBox.ResumeLayout(false);
            this.lzwCompressionAdvancedSettingsGroupBox.PerformLayout();
            this.zipCompressionAdvancedSettingsGroupBox.ResumeLayout(false);
            this.zipCompressionAdvancedSettingsGroupBox.PerformLayout();
            this.jpeg2000CompressionAdvancedSettingsGroupBox.ResumeLayout(false);
            this.annotationsTabPage.ResumeLayout(false);
            this.annotationsTabPage.PerformLayout();
            this.metadataTabPage.ResumeLayout(false);
            this.metadataTabPage.PerformLayout();
            this.fileTabPage.ResumeLayout(false);
            this.fileFormatGroupBox.ResumeLayout(false);
            this.fileFormatGroupBox.PerformLayout();
            this.fileVersionGroupBox.ResumeLayout(false);
            this.fileVersionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox addImagesToExistingFileCheckBox;
        private System.Windows.Forms.RadioButton zipCompressionRadioButton;
        private System.Windows.Forms.RadioButton autoCompressionRadioButton;
        private System.Windows.Forms.RadioButton jpegCompressionRadioButton;
        private System.Windows.Forms.RadioButton lzwCompressionRadioButton;
        private System.Windows.Forms.RadioButton ccitt4CompressionRadioButton;
        private System.Windows.Forms.RadioButton noneCompressionRadioButton;
        private System.Windows.Forms.GroupBox jpegCompressionAdvancedSettingsGroupBox;
        private System.Windows.Forms.CheckBox jpegGrayscaleCheckBox;
        private System.Windows.Forms.NumericUpDown jpegQualityNumericUpDown;
        private System.Windows.Forms.Label jpegQualityLabel;
        private System.Windows.Forms.Label zipLevelLabel;
        private System.Windows.Forms.NumericUpDown zipLevelNumericUpDown;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage compressionTabPage;
        private System.Windows.Forms.TabPage annotationsTabPage;
        private System.Windows.Forms.CheckBox annotationWangCheckBox;
        private System.Windows.Forms.CheckBox annotationXmpCheckBox;
        private System.Windows.Forms.CheckBox annotationsBinaryCheckBox;
        private System.Windows.Forms.TabPage metadataTabPage;
        private System.Windows.Forms.CheckBox copyExifMetadataCheckBox;
        private System.Windows.Forms.Button jpeg2000SettingsButton;
        private System.Windows.Forms.CheckBox copyCommonMetadataCheckBox;
        private System.Windows.Forms.CheckBox copyGpsMetadataCheckBox;
        private System.Windows.Forms.RadioButton jpeg2000CompressionRadioButton;
        private System.Windows.Forms.GroupBox jpeg2000CompressionAdvancedSettingsGroupBox;
        private System.Windows.Forms.GroupBox zipCompressionAdvancedSettingsGroupBox;
        private System.Windows.Forms.GroupBox stripsAndTilesGroupBox;
        private System.Windows.Forms.RadioButton useTilesRadioButton;
        private System.Windows.Forms.RadioButton useStripsRadioButton;
        private System.Windows.Forms.NumericUpDown rowsPerStripNumericUpDown;
        private System.Windows.Forms.Label rowsPerStripLabel;
        private System.Windows.Forms.Label tileWidthLabel;
        private System.Windows.Forms.Label tileHeightLabel;
        private System.Windows.Forms.NumericUpDown tileHeightNumericUpDown;
        private System.Windows.Forms.NumericUpDown tileWidthNumericUpDown;
        private System.Windows.Forms.CheckBox zipUsePredictorCheckBox;
        private System.Windows.Forms.GroupBox lzwCompressionAdvancedSettingsGroupBox;
        private System.Windows.Forms.CheckBox lzwUsePredictorCheckBox;
        private System.Windows.Forms.TabPage fileTabPage;
        private System.Windows.Forms.GroupBox fileFormatGroupBox;
        private System.Windows.Forms.RadioButton bigEndianRadioButton;
        private System.Windows.Forms.RadioButton littleEndianRadioButton;
        private System.Windows.Forms.GroupBox fileVersionGroupBox;
        private System.Windows.Forms.RadioButton bigTiffRadioButton;
        private System.Windows.Forms.RadioButton standardTiffRadioButton;
        private System.Windows.Forms.GroupBox binarizationAdvancedSettingsGroupBox;
        private System.Windows.Forms.ComboBox binarizationModeComboBox;
        private System.Windows.Forms.NumericUpDown binarizationThresholdNumericUpDown;
        private System.Windows.Forms.Label binarizationThresholdLabel;
    }
}