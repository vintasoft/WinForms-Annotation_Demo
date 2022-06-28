namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    partial class Jbig2EncoderSettingsForm
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
            this.appendCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mmrRadioButton = new System.Windows.Forms.RadioButton();
            this.arithmeticRadioButton = new System.Windows.Forms.RadioButton();
            this.useLossyCheckBox = new System.Windows.Forms.CheckBox();
            this.symbolDictionaryGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sdSizeComboBox = new System.Windows.Forms.ComboBox();
            this.lossyGroupBox = new System.Windows.Forms.GroupBox();
            this.inaccuracyPercentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.useSymbolDictionaryCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.symbolDictionaryGroupBox.SuspendLayout();
            this.lossyGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inaccuracyPercentNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // appendCheckBox
            // 
            this.appendCheckBox.AutoSize = true;
            this.appendCheckBox.Location = new System.Drawing.Point(8, 12);
            this.appendCheckBox.Name = "appendCheckBox";
            this.appendCheckBox.Size = new System.Drawing.Size(184, 19);
            this.appendCheckBox.TabIndex = 10;
            this.appendCheckBox.Text = "Append to existing document";
            this.appendCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.useLossyCheckBox);
            this.groupBox1.Controls.Add(this.symbolDictionaryGroupBox);
            this.groupBox1.Controls.Add(this.lossyGroupBox);
            this.groupBox1.Location = new System.Drawing.Point(8, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 186);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compression";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mmrRadioButton);
            this.groupBox2.Controls.Add(this.arithmeticRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(8, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 50);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bitmap encoding algorithm";
            // 
            // mmrRadioButton
            // 
            this.mmrRadioButton.AutoSize = true;
            this.mmrRadioButton.Location = new System.Drawing.Point(124, 19);
            this.mmrRadioButton.Name = "mmrRadioButton";
            this.mmrRadioButton.Size = new System.Drawing.Size(99, 19);
            this.mmrRadioButton.TabIndex = 3;
            this.mmrRadioButton.Text = "Mmr (CCITT4)";
            this.mmrRadioButton.UseVisualStyleBackColor = true;
            // 
            // arithmeticRadioButton
            // 
            this.arithmeticRadioButton.AutoSize = true;
            this.arithmeticRadioButton.Checked = true;
            this.arithmeticRadioButton.Location = new System.Drawing.Point(6, 19);
            this.arithmeticRadioButton.Name = "arithmeticRadioButton";
            this.arithmeticRadioButton.Size = new System.Drawing.Size(112, 19);
            this.arithmeticRadioButton.TabIndex = 2;
            this.arithmeticRadioButton.TabStop = true;
            this.arithmeticRadioButton.Text = "MQ (Arithmetic)";
            this.arithmeticRadioButton.UseVisualStyleBackColor = true;
            // 
            // useLossyCheckBox
            // 
            this.useLossyCheckBox.AutoSize = true;
            this.useLossyCheckBox.Location = new System.Drawing.Point(14, 71);
            this.useLossyCheckBox.Name = "useLossyCheckBox";
            this.useLossyCheckBox.Size = new System.Drawing.Size(55, 19);
            this.useLossyCheckBox.TabIndex = 7;
            this.useLossyCheckBox.Text = "Lossy";
            this.useLossyCheckBox.UseVisualStyleBackColor = true;
            this.useLossyCheckBox.CheckedChanged += new System.EventHandler(this.compressionLossyCheckBox_CheckedChanged);
            // 
            // symbolDictionaryGroupBox
            // 
            this.symbolDictionaryGroupBox.Controls.Add(this.label2);
            this.symbolDictionaryGroupBox.Controls.Add(this.sdSizeComboBox);
            this.symbolDictionaryGroupBox.Location = new System.Drawing.Point(8, 128);
            this.symbolDictionaryGroupBox.Name = "symbolDictionaryGroupBox";
            this.symbolDictionaryGroupBox.Size = new System.Drawing.Size(231, 50);
            this.symbolDictionaryGroupBox.TabIndex = 14;
            this.symbolDictionaryGroupBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dictionary size";
            // 
            // sdSizeComboBox
            // 
            this.sdSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sdSizeComboBox.FormattingEnabled = true;
            this.sdSizeComboBox.Items.AddRange(new object[] {
            "500",
            "1000",
            "3000",
            "6500",
            "10000"});
            this.sdSizeComboBox.Location = new System.Drawing.Point(138, 17);
            this.sdSizeComboBox.Name = "sdSizeComboBox";
            this.sdSizeComboBox.Size = new System.Drawing.Size(85, 23);
            this.sdSizeComboBox.TabIndex = 6;
            // 
            // lossyGroupBox
            // 
            this.lossyGroupBox.Controls.Add(this.inaccuracyPercentNumericUpDown);
            this.lossyGroupBox.Controls.Add(this.label1);
            this.lossyGroupBox.Location = new System.Drawing.Point(8, 72);
            this.lossyGroupBox.Name = "lossyGroupBox";
            this.lossyGroupBox.Size = new System.Drawing.Size(231, 50);
            this.lossyGroupBox.TabIndex = 15;
            this.lossyGroupBox.TabStop = false;
            // 
            // inaccuracyPercentNumericUpDown
            // 
            this.inaccuracyPercentNumericUpDown.Location = new System.Drawing.Point(138, 18);
            this.inaccuracyPercentNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inaccuracyPercentNumericUpDown.Name = "inaccuracyPercentNumericUpDown";
            this.inaccuracyPercentNumericUpDown.Size = new System.Drawing.Size(85, 23);
            this.inaccuracyPercentNumericUpDown.TabIndex = 8;
            this.inaccuracyPercentNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Inaccuracy percent";
            // 
            // useSymbolDictionaryCheckBox
            // 
            this.useSymbolDictionaryCheckBox.AutoSize = true;
            this.useSymbolDictionaryCheckBox.Checked = true;
            this.useSymbolDictionaryCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useSymbolDictionaryCheckBox.Location = new System.Drawing.Point(22, 162);
            this.useSymbolDictionaryCheckBox.Name = "useSymbolDictionaryCheckBox";
            this.useSymbolDictionaryCheckBox.Size = new System.Drawing.Size(122, 19);
            this.useSymbolDictionaryCheckBox.TabIndex = 0;
            this.useSymbolDictionaryCheckBox.Text = "Symbol dictionary";
            this.useSymbolDictionaryCheckBox.UseVisualStyleBackColor = true;
            this.useSymbolDictionaryCheckBox.CheckedChanged += new System.EventHandler(this.checkBoxUseSD_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(125, 227);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(44, 227);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 12;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // Jbig2EncoderSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(260, 259);
            this.Controls.Add(this.useSymbolDictionaryCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.appendCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Jbig2EncoderSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JBIG 2 Encoder Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.symbolDictionaryGroupBox.ResumeLayout(false);
            this.symbolDictionaryGroupBox.PerformLayout();
            this.lossyGroupBox.ResumeLayout(false);
            this.lossyGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inaccuracyPercentNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox appendCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox symbolDictionaryGroupBox;
        private System.Windows.Forms.CheckBox useSymbolDictionaryCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sdSizeComboBox;
        private System.Windows.Forms.GroupBox lossyGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox useLossyCheckBox;
        private System.Windows.Forms.NumericUpDown inaccuracyPercentNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton mmrRadioButton;
        private System.Windows.Forms.RadioButton arithmeticRadioButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}