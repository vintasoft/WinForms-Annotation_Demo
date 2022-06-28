namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    partial class PdfCompressionControl
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

         #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.compressionJbig2RadioButton = new System.Windows.Forms.RadioButton();
            this.compressionCcittRadioButton = new System.Windows.Forms.RadioButton();
            this.compressionJpeg2000RadioButton = new System.Windows.Forms.RadioButton();
            this.compressionLzwRadioButton = new System.Windows.Forms.RadioButton();
            this.compressionJpegRadioButton = new System.Windows.Forms.RadioButton();
            this.compressionZipRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.binarizationGroupBox = new System.Windows.Forms.GroupBox();
            this.thresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.binarizationModeComboBox = new System.Windows.Forms.ComboBox();
            this.jpeg2000CompressionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.jpeg2000SettingsButton = new System.Windows.Forms.Button();
            this.compressionJpegZipRadioButton = new System.Windows.Forms.RadioButton();
            this.compressionAutoRadioButton = new System.Windows.Forms.RadioButton();
            this.compressionNoneRadioButton = new System.Windows.Forms.RadioButton();
            this.jbig2CompressionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.jbig2UseGlobalsCheckBox = new System.Windows.Forms.CheckBox();
            this.jbig2SettingsButton = new System.Windows.Forms.Button();
            this.zipCompressionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.zipLevelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.jpegCompressionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.jpegGrayscaleCheckBox = new System.Windows.Forms.CheckBox();
            this.jpegQualityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.binarizationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).BeginInit();
            this.jpeg2000CompressionSettingsGroupBox.SuspendLayout();
            this.jbig2CompressionSettingsGroupBox.SuspendLayout();
            this.zipCompressionSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zipLevelNumericUpDown)).BeginInit();
            this.jpegCompressionSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // compressionJbig2RadioButton
            // 
            this.compressionJbig2RadioButton.AutoSize = true;
            this.compressionJbig2RadioButton.Location = new System.Drawing.Point(106, 82);
            this.compressionJbig2RadioButton.Name = "compressionJbig2RadioButton";
            this.compressionJbig2RadioButton.Size = new System.Drawing.Size(56, 19);
            this.compressionJbig2RadioButton.TabIndex = 8;
            this.compressionJbig2RadioButton.Text = "JBIG 2";
            this.compressionJbig2RadioButton.UseVisualStyleBackColor = true;
            this.compressionJbig2RadioButton.CheckedChanged += new System.EventHandler(this.compressionRadioButton_CheckedChanged);
            // 
            // compressionCcittRadioButton
            // 
            this.compressionCcittRadioButton.AutoSize = true;
            this.compressionCcittRadioButton.Location = new System.Drawing.Point(6, 102);
            this.compressionCcittRadioButton.Name = "compressionCcittRadioButton";
            this.compressionCcittRadioButton.Size = new System.Drawing.Size(101, 19);
            this.compressionCcittRadioButton.TabIndex = 9;
            this.compressionCcittRadioButton.Text = "CCITT Group 4";
            this.compressionCcittRadioButton.UseVisualStyleBackColor = true;
            this.compressionCcittRadioButton.CheckedChanged += new System.EventHandler(this.compressionRadioButton_CheckedChanged);
            // 
            // compressionJpeg2000RadioButton
            // 
            this.compressionJpeg2000RadioButton.AutoSize = true;
            this.compressionJpeg2000RadioButton.Location = new System.Drawing.Point(6, 82);
            this.compressionJpeg2000RadioButton.Name = "compressionJpeg2000RadioButton";
            this.compressionJpeg2000RadioButton.Size = new System.Drawing.Size(77, 19);
            this.compressionJpeg2000RadioButton.TabIndex = 7;
            this.compressionJpeg2000RadioButton.Text = "JPEG 2000";
            this.compressionJpeg2000RadioButton.UseVisualStyleBackColor = true;
            this.compressionJpeg2000RadioButton.CheckedChanged += new System.EventHandler(this.compressionRadioButton_CheckedChanged);
            // 
            // compressionLzwRadioButton
            // 
            this.compressionLzwRadioButton.AutoSize = true;
            this.compressionLzwRadioButton.Location = new System.Drawing.Point(106, 63);
            this.compressionLzwRadioButton.Name = "compressionLzwRadioButton";
            this.compressionLzwRadioButton.Size = new System.Drawing.Size(49, 19);
            this.compressionLzwRadioButton.TabIndex = 6;
            this.compressionLzwRadioButton.Text = "LZW";
            this.compressionLzwRadioButton.UseVisualStyleBackColor = true;
            this.compressionLzwRadioButton.CheckedChanged += new System.EventHandler(this.compressionRadioButton_CheckedChanged);
            // 
            // compressionJpegRadioButton
            // 
            this.compressionJpegRadioButton.AutoSize = true;
            this.compressionJpegRadioButton.Location = new System.Drawing.Point(6, 44);
            this.compressionJpegRadioButton.Name = "compressionJpegRadioButton";
            this.compressionJpegRadioButton.Size = new System.Drawing.Size(50, 19);
            this.compressionJpegRadioButton.TabIndex = 3;
            this.compressionJpegRadioButton.Text = "JPEG";
            this.compressionJpegRadioButton.UseVisualStyleBackColor = true;
            this.compressionJpegRadioButton.CheckedChanged += new System.EventHandler(this.compressionRadioButton_CheckedChanged);
            // 
            // compressionZipRadioButton
            // 
            this.compressionZipRadioButton.AutoSize = true;
            this.compressionZipRadioButton.Location = new System.Drawing.Point(106, 44);
            this.compressionZipRadioButton.Name = "compressionZipRadioButton";
            this.compressionZipRadioButton.Size = new System.Drawing.Size(42, 19);
            this.compressionZipRadioButton.TabIndex = 4;
            this.compressionZipRadioButton.Text = "ZIP";
            this.compressionZipRadioButton.UseVisualStyleBackColor = true;
            this.compressionZipRadioButton.CheckedChanged += new System.EventHandler(this.compressionRadioButton_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.binarizationGroupBox);
            this.groupBox3.Controls.Add(this.jpeg2000CompressionSettingsGroupBox);
            this.groupBox3.Controls.Add(this.compressionCcittRadioButton);
            this.groupBox3.Controls.Add(this.compressionLzwRadioButton);
            this.groupBox3.Controls.Add(this.compressionJbig2RadioButton);
            this.groupBox3.Controls.Add(this.compressionJpegZipRadioButton);
            this.groupBox3.Controls.Add(this.compressionAutoRadioButton);
            this.groupBox3.Controls.Add(this.compressionZipRadioButton);
            this.groupBox3.Controls.Add(this.compressionJpegRadioButton);
            this.groupBox3.Controls.Add(this.compressionJpeg2000RadioButton);
            this.groupBox3.Controls.Add(this.compressionNoneRadioButton);
            this.groupBox3.Controls.Add(this.jbig2CompressionSettingsGroupBox);
            this.groupBox3.Controls.Add(this.zipCompressionSettingsGroupBox);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(345, 138);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Compression of image resource";
            // 
            // binarizationGroupBox
            // 
            this.binarizationGroupBox.Controls.Add(this.thresholdNumericUpDown);
            this.binarizationGroupBox.Controls.Add(this.thresholdLabel);
            this.binarizationGroupBox.Controls.Add(this.binarizationModeComboBox);
            this.binarizationGroupBox.Location = new System.Drawing.Point(170, 19);
            this.binarizationGroupBox.Name = "binarizationGroupBox";
            this.binarizationGroupBox.Size = new System.Drawing.Size(131, 68);
            this.binarizationGroupBox.TabIndex = 24;
            this.binarizationGroupBox.TabStop = false;
            this.binarizationGroupBox.Text = "Binarization";
            // 
            // thresholdNumericUpDown
            // 
            this.thresholdNumericUpDown.Location = new System.Drawing.Point(70, 42);
            this.thresholdNumericUpDown.Maximum = new decimal(new int[] {
            765,
            0,
            0,
            0});
            this.thresholdNumericUpDown.Name = "thresholdNumericUpDown";
            this.thresholdNumericUpDown.Size = new System.Drawing.Size(53, 23);
            this.thresholdNumericUpDown.TabIndex = 2;
            this.thresholdNumericUpDown.ValueChanged += new System.EventHandler(this.thresholdNumericUpDown_ValueChanged);
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(3, 44);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(59, 15);
            this.thresholdLabel.TabIndex = 1;
            this.thresholdLabel.Text = "Threshold";
            // 
            // binarizationModeComboBox
            // 
            this.binarizationModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.binarizationModeComboBox.FormattingEnabled = true;
            this.binarizationModeComboBox.Location = new System.Drawing.Point(6, 17);
            this.binarizationModeComboBox.Name = "binarizationModeComboBox";
            this.binarizationModeComboBox.Size = new System.Drawing.Size(117, 23);
            this.binarizationModeComboBox.TabIndex = 0;
            this.binarizationModeComboBox.SelectedIndexChanged += new System.EventHandler(this.binarizationModeComboBox_SelectedIndexChanged);
            // 
            // jpeg2000CompressionSettingsGroupBox
            // 
            this.jpeg2000CompressionSettingsGroupBox.Controls.Add(this.jpeg2000SettingsButton);
            this.jpeg2000CompressionSettingsGroupBox.Location = new System.Drawing.Point(170, 19);
            this.jpeg2000CompressionSettingsGroupBox.Name = "jpeg2000CompressionSettingsGroupBox";
            this.jpeg2000CompressionSettingsGroupBox.Size = new System.Drawing.Size(131, 54);
            this.jpeg2000CompressionSettingsGroupBox.TabIndex = 25;
            this.jpeg2000CompressionSettingsGroupBox.TabStop = false;
            this.jpeg2000CompressionSettingsGroupBox.Text = "JPEG2000";
            this.jpeg2000CompressionSettingsGroupBox.Visible = false;
            // 
            // jpeg2000SettingsButton
            // 
            this.jpeg2000SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jpeg2000SettingsButton.Location = new System.Drawing.Point(6, 17);
            this.jpeg2000SettingsButton.Name = "jpeg2000SettingsButton";
            this.jpeg2000SettingsButton.Size = new System.Drawing.Size(120, 23);
            this.jpeg2000SettingsButton.TabIndex = 0;
            this.jpeg2000SettingsButton.Text = "Settings...";
            this.jpeg2000SettingsButton.UseVisualStyleBackColor = true;
            this.jpeg2000SettingsButton.Click += new System.EventHandler(this.jpeg2000SettingsButton_Click);
            // 
            // compressionJpegZipRadioButton
            // 
            this.compressionJpegZipRadioButton.AutoSize = true;
            this.compressionJpegZipRadioButton.Location = new System.Drawing.Point(6, 63);
            this.compressionJpegZipRadioButton.Name = "compressionJpegZipRadioButton";
            this.compressionJpegZipRadioButton.Size = new System.Drawing.Size(81, 19);
            this.compressionJpegZipRadioButton.TabIndex = 5;
            this.compressionJpegZipRadioButton.Text = "JPEG + ZIP";
            this.compressionJpegZipRadioButton.UseVisualStyleBackColor = true;
            // 
            // compressionAutoRadioButton
            // 
            this.compressionAutoRadioButton.AutoSize = true;
            this.compressionAutoRadioButton.Checked = true;
            this.compressionAutoRadioButton.Location = new System.Drawing.Point(106, 19);
            this.compressionAutoRadioButton.Name = "compressionAutoRadioButton";
            this.compressionAutoRadioButton.Size = new System.Drawing.Size(51, 19);
            this.compressionAutoRadioButton.TabIndex = 2;
            this.compressionAutoRadioButton.TabStop = true;
            this.compressionAutoRadioButton.Text = "Auto";
            this.compressionAutoRadioButton.UseVisualStyleBackColor = true;
            this.compressionAutoRadioButton.CheckedChanged += new System.EventHandler(this.compressionRadioButton_CheckedChanged);
            // 
            // compressionNoneRadioButton
            // 
            this.compressionNoneRadioButton.AutoSize = true;
            this.compressionNoneRadioButton.Location = new System.Drawing.Point(6, 19);
            this.compressionNoneRadioButton.Name = "compressionNoneRadioButton";
            this.compressionNoneRadioButton.Size = new System.Drawing.Size(54, 19);
            this.compressionNoneRadioButton.TabIndex = 1;
            this.compressionNoneRadioButton.Text = "None";
            this.compressionNoneRadioButton.UseVisualStyleBackColor = true;
            this.compressionNoneRadioButton.CheckedChanged += new System.EventHandler(this.compressionRadioButton_CheckedChanged);
            // 
            // jbig2CompressionSettingsGroupBox
            // 
            this.jbig2CompressionSettingsGroupBox.Controls.Add(this.jbig2UseGlobalsCheckBox);
            this.jbig2CompressionSettingsGroupBox.Controls.Add(this.jbig2SettingsButton);
            this.jbig2CompressionSettingsGroupBox.Location = new System.Drawing.Point(170, 19);
            this.jbig2CompressionSettingsGroupBox.Name = "jbig2CompressionSettingsGroupBox";
            this.jbig2CompressionSettingsGroupBox.Size = new System.Drawing.Size(131, 57);
            this.jbig2CompressionSettingsGroupBox.TabIndex = 24;
            this.jbig2CompressionSettingsGroupBox.TabStop = false;
            this.jbig2CompressionSettingsGroupBox.Text = "JBIG2";
            this.jbig2CompressionSettingsGroupBox.Visible = false;
            // 
            // jbig2UseGlobalsCheckBox
            // 
            this.jbig2UseGlobalsCheckBox.AutoSize = true;
            this.jbig2UseGlobalsCheckBox.Checked = true;
            this.jbig2UseGlobalsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.jbig2UseGlobalsCheckBox.Location = new System.Drawing.Point(6, 37);
            this.jbig2UseGlobalsCheckBox.Name = "jbig2UseGlobalsCheckBox";
            this.jbig2UseGlobalsCheckBox.Size = new System.Drawing.Size(137, 19);
            this.jbig2UseGlobalsCheckBox.TabIndex = 9;
            this.jbig2UseGlobalsCheckBox.Text = "Use global dictionary";
            this.jbig2UseGlobalsCheckBox.UseVisualStyleBackColor = true;
            this.jbig2UseGlobalsCheckBox.CheckedChanged += new System.EventHandler(this.jbig2UseGlobalsCheckBox_CheckedChanged);
            // 
            // jbig2SettingsButton
            // 
            this.jbig2SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jbig2SettingsButton.Location = new System.Drawing.Point(6, 13);
            this.jbig2SettingsButton.Name = "jbig2SettingsButton";
            this.jbig2SettingsButton.Size = new System.Drawing.Size(120, 23);
            this.jbig2SettingsButton.TabIndex = 10;
            this.jbig2SettingsButton.Text = "Settings...";
            this.jbig2SettingsButton.UseVisualStyleBackColor = true;
            this.jbig2SettingsButton.Click += new System.EventHandler(this.jbig2SettingsButton_Click);
            // 
            // zipCompressionSettingsGroupBox
            // 
            this.zipCompressionSettingsGroupBox.Controls.Add(this.label2);
            this.zipCompressionSettingsGroupBox.Controls.Add(this.zipLevelNumericUpDown);
            this.zipCompressionSettingsGroupBox.Location = new System.Drawing.Point(170, 79);
            this.zipCompressionSettingsGroupBox.Name = "zipCompressionSettingsGroupBox";
            this.zipCompressionSettingsGroupBox.Size = new System.Drawing.Size(131, 55);
            this.zipCompressionSettingsGroupBox.TabIndex = 26;
            this.zipCompressionSettingsGroupBox.TabStop = false;
            this.zipCompressionSettingsGroupBox.Text = "ZIP";
            this.zipCompressionSettingsGroupBox.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Level";
            // 
            // zipLevelNumericUpDown
            // 
            this.zipLevelNumericUpDown.Location = new System.Drawing.Point(70, 13);
            this.zipLevelNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.zipLevelNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zipLevelNumericUpDown.Name = "zipLevelNumericUpDown";
            this.zipLevelNumericUpDown.Size = new System.Drawing.Size(54, 23);
            this.zipLevelNumericUpDown.TabIndex = 0;
            this.zipLevelNumericUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.zipLevelNumericUpDown.ValueChanged += new System.EventHandler(this.zipLevelNumericUpDown_ValueChanged);
            // 
            // jpegCompressionSettingsGroupBox
            // 
            this.jpegCompressionSettingsGroupBox.Controls.Add(this.jpegGrayscaleCheckBox);
            this.jpegCompressionSettingsGroupBox.Controls.Add(this.jpegQualityNumericUpDown);
            this.jpegCompressionSettingsGroupBox.Controls.Add(this.label1);
            this.jpegCompressionSettingsGroupBox.Location = new System.Drawing.Point(173, 19);
            this.jpegCompressionSettingsGroupBox.Name = "jpegCompressionSettingsGroupBox";
            this.jpegCompressionSettingsGroupBox.Size = new System.Drawing.Size(131, 57);
            this.jpegCompressionSettingsGroupBox.TabIndex = 23;
            this.jpegCompressionSettingsGroupBox.TabStop = false;
            this.jpegCompressionSettingsGroupBox.Text = "JPEG";
            // 
            // jpegGrayscaleCheckBox
            // 
            this.jpegGrayscaleCheckBox.AutoSize = true;
            this.jpegGrayscaleCheckBox.Location = new System.Drawing.Point(9, 36);
            this.jpegGrayscaleCheckBox.Name = "jpegGrayscaleCheckBox";
            this.jpegGrayscaleCheckBox.Size = new System.Drawing.Size(76, 19);
            this.jpegGrayscaleCheckBox.TabIndex = 12;
            this.jpegGrayscaleCheckBox.Text = "Grayscale";
            this.jpegGrayscaleCheckBox.UseVisualStyleBackColor = true;
            this.jpegGrayscaleCheckBox.CheckedChanged += new System.EventHandler(this.jpegGrayscaleCheckBox_CheckedChanged);
            // 
            // jpegQualityNumericUpDown
            // 
            this.jpegQualityNumericUpDown.Location = new System.Drawing.Point(69, 13);
            this.jpegQualityNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.jpegQualityNumericUpDown.Name = "jpegQualityNumericUpDown";
            this.jpegQualityNumericUpDown.Size = new System.Drawing.Size(54, 23);
            this.jpegQualityNumericUpDown.TabIndex = 1;
            this.jpegQualityNumericUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.jpegQualityNumericUpDown.ValueChanged += new System.EventHandler(this.jpegQualityNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quality";
            // 
            // PdfCompressionControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.jpegCompressionSettingsGroupBox);
            this.Controls.Add(this.groupBox3);
            this.Name = "PdfCompressionControl";
            this.Size = new System.Drawing.Size(351, 144);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.binarizationGroupBox.ResumeLayout(false);
            this.binarizationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).EndInit();
            this.jpeg2000CompressionSettingsGroupBox.ResumeLayout(false);
            this.jbig2CompressionSettingsGroupBox.ResumeLayout(false);
            this.jbig2CompressionSettingsGroupBox.PerformLayout();
            this.zipCompressionSettingsGroupBox.ResumeLayout(false);
            this.zipCompressionSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zipLevelNumericUpDown)).EndInit();
            this.jpegCompressionSettingsGroupBox.ResumeLayout(false);
            this.jpegCompressionSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton compressionJbig2RadioButton;
        private System.Windows.Forms.RadioButton compressionCcittRadioButton;
        private System.Windows.Forms.RadioButton compressionJpeg2000RadioButton;
        private System.Windows.Forms.RadioButton compressionLzwRadioButton;
        private System.Windows.Forms.RadioButton compressionJpegRadioButton;
        private System.Windows.Forms.RadioButton compressionZipRadioButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton compressionNoneRadioButton;
        private System.Windows.Forms.RadioButton compressionAutoRadioButton;
        private System.Windows.Forms.GroupBox jpegCompressionSettingsGroupBox;
        private System.Windows.Forms.CheckBox jpegGrayscaleCheckBox;
        private System.Windows.Forms.NumericUpDown jpegQualityNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox jpeg2000CompressionSettingsGroupBox;
        private System.Windows.Forms.Button jpeg2000SettingsButton;
        private System.Windows.Forms.GroupBox jbig2CompressionSettingsGroupBox;
        private System.Windows.Forms.Button jbig2SettingsButton;
        private System.Windows.Forms.CheckBox jbig2UseGlobalsCheckBox;
        private System.Windows.Forms.RadioButton compressionJpegZipRadioButton;
        private System.Windows.Forms.GroupBox zipCompressionSettingsGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown zipLevelNumericUpDown;
        private System.Windows.Forms.GroupBox binarizationGroupBox;
        private System.Windows.Forms.ComboBox binarizationModeComboBox;
        private System.Windows.Forms.NumericUpDown thresholdNumericUpDown;
        private System.Windows.Forms.Label thresholdLabel;
    }
}