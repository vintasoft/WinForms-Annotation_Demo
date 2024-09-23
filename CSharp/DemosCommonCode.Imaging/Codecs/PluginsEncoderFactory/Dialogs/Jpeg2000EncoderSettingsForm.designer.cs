namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    partial class Jpeg2000EncoderSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.formatComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.waveletLevelsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.qualityLayersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.progressionOrderComboBox = new System.Windows.Forms.ComboBox();
            this.useTilesCheckBox = new System.Windows.Forms.CheckBox();
            this.tileWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tileHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lossyGroupBox = new System.Windows.Forms.GroupBox();
            this.compressionRatioLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.compressionRatioNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.compressionRatioRadioButton = new System.Windows.Forms.RadioButton();
            this.imageDataSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.imageDataSizeRadioButton = new System.Windows.Forms.RadioButton();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.lossyCompressionCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.waveletTransformCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.waveletLevelsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityLayersNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumericUpDown)).BeginInit();
            this.lossyGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressionRatioNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageDataSizeNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Format";
            // 
            // formatComboBox
            // 
            this.formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatComboBox.FormattingEnabled = true;
            this.formatComboBox.Location = new System.Drawing.Point(140, 19);
            this.formatComboBox.Name = "formatComboBox";
            this.formatComboBox.Size = new System.Drawing.Size(121, 21);
            this.formatComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Levels";
            // 
            // waveletLevelsNumericUpDown
            // 
            this.waveletLevelsNumericUpDown.Location = new System.Drawing.Point(140, 18);
            this.waveletLevelsNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.waveletLevelsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.waveletLevelsNumericUpDown.Name = "waveletLevelsNumericUpDown";
            this.waveletLevelsNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.waveletLevelsNumericUpDown.TabIndex = 3;
            this.waveletLevelsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quality Layers";
            // 
            // qualityLayersNumericUpDown
            // 
            this.qualityLayersNumericUpDown.Location = new System.Drawing.Point(140, 43);
            this.qualityLayersNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.qualityLayersNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qualityLayersNumericUpDown.Name = "qualityLayersNumericUpDown";
            this.qualityLayersNumericUpDown.Size = new System.Drawing.Size(121, 20);
            this.qualityLayersNumericUpDown.TabIndex = 5;
            this.qualityLayersNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Progression Order";
            // 
            // progressionOrderComboBox
            // 
            this.progressionOrderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.progressionOrderComboBox.FormattingEnabled = true;
            this.progressionOrderComboBox.Location = new System.Drawing.Point(140, 66);
            this.progressionOrderComboBox.Name = "progressionOrderComboBox";
            this.progressionOrderComboBox.Size = new System.Drawing.Size(121, 21);
            this.progressionOrderComboBox.TabIndex = 7;
            // 
            // useTilesCheckBox
            // 
            this.useTilesCheckBox.AutoSize = true;
            this.useTilesCheckBox.Location = new System.Drawing.Point(10, 93);
            this.useTilesCheckBox.Name = "useTilesCheckBox";
            this.useTilesCheckBox.Size = new System.Drawing.Size(70, 17);
            this.useTilesCheckBox.TabIndex = 8;
            this.useTilesCheckBox.Text = "Use Tiles";
            this.useTilesCheckBox.UseVisualStyleBackColor = true;
            this.useTilesCheckBox.CheckedChanged += new System.EventHandler(this.useTilesCheckBox_CheckedChanged);
            // 
            // tileWidthNumericUpDown
            // 
            this.tileWidthNumericUpDown.Location = new System.Drawing.Point(140, 93);
            this.tileWidthNumericUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.tileWidthNumericUpDown.Name = "tileWidthNumericUpDown";
            this.tileWidthNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.tileWidthNumericUpDown.TabIndex = 9;
            this.tileWidthNumericUpDown.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // tileHeightNumericUpDown
            // 
            this.tileHeightNumericUpDown.Location = new System.Drawing.Point(211, 93);
            this.tileHeightNumericUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.tileHeightNumericUpDown.Name = "tileHeightNumericUpDown";
            this.tileHeightNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.tileHeightNumericUpDown.TabIndex = 10;
            this.tileHeightNumericUpDown.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "X";
            // 
            // lossyGroupBox
            // 
            this.lossyGroupBox.Controls.Add(this.compressionRatioLabel);
            this.lossyGroupBox.Controls.Add(this.label7);
            this.lossyGroupBox.Controls.Add(this.compressionRatioNumericUpDown);
            this.lossyGroupBox.Controls.Add(this.compressionRatioRadioButton);
            this.lossyGroupBox.Controls.Add(this.imageDataSizeNumericUpDown);
            this.lossyGroupBox.Controls.Add(this.imageDataSizeRadioButton);
            this.lossyGroupBox.Location = new System.Drawing.Point(6, 44);
            this.lossyGroupBox.Name = "lossyGroupBox";
            this.lossyGroupBox.Size = new System.Drawing.Size(262, 70);
            this.lossyGroupBox.TabIndex = 14;
            this.lossyGroupBox.TabStop = false;
            // 
            // compressionRatioLabel
            // 
            this.compressionRatioLabel.AutoSize = true;
            this.compressionRatioLabel.Location = new System.Drawing.Point(216, 43);
            this.compressionRatioLabel.Name = "compressionRatioLabel";
            this.compressionRatioLabel.Size = new System.Drawing.Size(34, 13);
            this.compressionRatioLabel.TabIndex = 19;
            this.compressionRatioLabel.Text = "(1 : 1)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "KBytes";
            // 
            // compressionRatioNumericUpDown
            // 
            this.compressionRatioNumericUpDown.Location = new System.Drawing.Point(134, 41);
            this.compressionRatioNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.compressionRatioNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.compressionRatioNumericUpDown.Name = "compressionRatioNumericUpDown";
            this.compressionRatioNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.compressionRatioNumericUpDown.TabIndex = 6;
            this.compressionRatioNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.compressionRatioNumericUpDown.ValueChanged += new System.EventHandler(this.compressionRatioNumericUpDown_ValueChanged);
            // 
            // compressionRatioRadioButton
            // 
            this.compressionRatioRadioButton.AutoSize = true;
            this.compressionRatioRadioButton.Location = new System.Drawing.Point(4, 41);
            this.compressionRatioRadioButton.Name = "compressionRatioRadioButton";
            this.compressionRatioRadioButton.Size = new System.Drawing.Size(113, 17);
            this.compressionRatioRadioButton.TabIndex = 18;
            this.compressionRatioRadioButton.TabStop = true;
            this.compressionRatioRadioButton.Text = "Compression Ratio";
            this.compressionRatioRadioButton.UseVisualStyleBackColor = true;
            this.compressionRatioRadioButton.CheckedChanged += new System.EventHandler(this.compressionRatioRadioButton_CheckedChanged);
            // 
            // imageDataSizeNumericUpDown
            // 
            this.imageDataSizeNumericUpDown.Location = new System.Drawing.Point(134, 15);
            this.imageDataSizeNumericUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.imageDataSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.imageDataSizeNumericUpDown.Name = "imageDataSizeNumericUpDown";
            this.imageDataSizeNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.imageDataSizeNumericUpDown.TabIndex = 4;
            this.imageDataSizeNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // imageDataSizeRadioButton
            // 
            this.imageDataSizeRadioButton.AutoSize = true;
            this.imageDataSizeRadioButton.Location = new System.Drawing.Point(4, 18);
            this.imageDataSizeRadioButton.Name = "imageDataSizeRadioButton";
            this.imageDataSizeRadioButton.Size = new System.Drawing.Size(103, 17);
            this.imageDataSizeRadioButton.TabIndex = 16;
            this.imageDataSizeRadioButton.TabStop = true;
            this.imageDataSizeRadioButton.Text = "Image Data Size";
            this.imageDataSizeRadioButton.UseVisualStyleBackColor = true;
            this.imageDataSizeRadioButton.CheckedChanged += new System.EventHandler(this.imageDataSizeRadioButton_CheckedChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(67, 264);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 15;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(148, 264);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // lossyCompressionCheckBox
            // 
            this.lossyCompressionCheckBox.AutoSize = true;
            this.lossyCompressionCheckBox.Location = new System.Drawing.Point(10, 42);
            this.lossyCompressionCheckBox.Name = "lossyCompressionCheckBox";
            this.lossyCompressionCheckBox.Size = new System.Drawing.Size(53, 17);
            this.lossyCompressionCheckBox.TabIndex = 17;
            this.lossyCompressionCheckBox.Text = "Lossy";
            this.lossyCompressionCheckBox.UseVisualStyleBackColor = true;
            this.lossyCompressionCheckBox.CheckedChanged += new System.EventHandler(this.lossyCompressionCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.formatComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.qualityLayersNumericUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.progressionOrderComboBox);
            this.groupBox1.Controls.Add(this.tileHeightNumericUpDown);
            this.groupBox1.Controls.Add(this.useTilesCheckBox);
            this.groupBox1.Controls.Add(this.tileWidthNumericUpDown);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 124);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Structure";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.waveletTransformCheckBox);
            this.groupBox2.Controls.Add(this.lossyCompressionCheckBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.waveletLevelsNumericUpDown);
            this.groupBox2.Controls.Add(this.lossyGroupBox);
            this.groupBox2.Location = new System.Drawing.Point(8, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 120);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compression";
            // 
            // waveletTransformCheckBox
            // 
            this.waveletTransformCheckBox.AutoSize = true;
            this.waveletTransformCheckBox.Location = new System.Drawing.Point(10, 19);
            this.waveletTransformCheckBox.Name = "waveletTransformCheckBox";
            this.waveletTransformCheckBox.Size = new System.Drawing.Size(116, 17);
            this.waveletTransformCheckBox.TabIndex = 18;
            this.waveletTransformCheckBox.Text = "Wavelet Transform";
            this.waveletTransformCheckBox.UseVisualStyleBackColor = true;
            this.waveletTransformCheckBox.CheckedChanged += new System.EventHandler(this.waveletTransformCheckBox_CheckedChanged);
            // 
            // Jpeg2000EncoderSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(288, 293);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Jpeg2000EncoderSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JPEG 2000 Encoder Settings";
            ((System.ComponentModel.ISupportInitialize)(this.waveletLevelsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qualityLayersNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileHeightNumericUpDown)).EndInit();
            this.lossyGroupBox.ResumeLayout(false);
            this.lossyGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressionRatioNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageDataSizeNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox formatComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown waveletLevelsNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown qualityLayersNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox progressionOrderComboBox;
        private System.Windows.Forms.CheckBox useTilesCheckBox;
        private System.Windows.Forms.NumericUpDown tileWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown tileHeightNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox lossyGroupBox;
        private System.Windows.Forms.RadioButton compressionRatioRadioButton;
        private System.Windows.Forms.RadioButton imageDataSizeRadioButton;
        private System.Windows.Forms.NumericUpDown imageDataSizeNumericUpDown;
        private System.Windows.Forms.NumericUpDown compressionRatioNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox lossyCompressionCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label compressionRatioLabel;
        private System.Windows.Forms.CheckBox waveletTransformCheckBox;
    }
}