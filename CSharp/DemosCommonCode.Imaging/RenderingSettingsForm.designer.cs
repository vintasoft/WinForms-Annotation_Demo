namespace DemosCommonCode.Imaging
{
    partial class RenderingSettingsForm
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
            this.defaultCheckBox = new System.Windows.Forms.CheckBox();
            this.customSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.drawSharpImageBordersCheckBox = new System.Windows.Forms.CheckBox();
            this.optimizeImageDrawingCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.interpolationModeComboBox = new System.Windows.Forms.ComboBox();
            this.smoothingModeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.verticalResolutionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.horizontalResolutionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.customSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticalResolutionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalResolutionNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultCheckBox
            // 
            this.defaultCheckBox.AutoSize = true;
            this.defaultCheckBox.Location = new System.Drawing.Point(12, 12);
            this.defaultCheckBox.Name = "defaultCheckBox";
            this.defaultCheckBox.Size = new System.Drawing.Size(109, 19);
            this.defaultCheckBox.TabIndex = 0;
            this.defaultCheckBox.Text = "Default Settings";
            this.defaultCheckBox.UseVisualStyleBackColor = true;
            this.defaultCheckBox.CheckedChanged += new System.EventHandler(this.defaultCheckBox_CheckedChanged);
            // 
            // customSettingsGroupBox
            // 
            this.customSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customSettingsGroupBox.Controls.Add(this.drawSharpImageBordersCheckBox);
            this.customSettingsGroupBox.Controls.Add(this.optimizeImageDrawingCheckBox);
            this.customSettingsGroupBox.Controls.Add(this.label6);
            this.customSettingsGroupBox.Controls.Add(this.interpolationModeComboBox);
            this.customSettingsGroupBox.Controls.Add(this.smoothingModeComboBox);
            this.customSettingsGroupBox.Controls.Add(this.label5);
            this.customSettingsGroupBox.Controls.Add(this.verticalResolutionNumericUpDown);
            this.customSettingsGroupBox.Controls.Add(this.horizontalResolutionNumericUpDown);
            this.customSettingsGroupBox.Controls.Add(this.label4);
            this.customSettingsGroupBox.Controls.Add(this.label3);
            this.customSettingsGroupBox.Controls.Add(this.label2);
            this.customSettingsGroupBox.Controls.Add(this.label1);
            this.customSettingsGroupBox.Location = new System.Drawing.Point(12, 35);
            this.customSettingsGroupBox.Name = "customSettingsGroupBox";
            this.customSettingsGroupBox.Size = new System.Drawing.Size(275, 164);
            this.customSettingsGroupBox.TabIndex = 1;
            this.customSettingsGroupBox.TabStop = false;
            this.customSettingsGroupBox.Text = "Custom Settings";
            // 
            // drawSharpImageBordersCheckBox
            // 
            this.drawSharpImageBordersCheckBox.AutoSize = true;
            this.drawSharpImageBordersCheckBox.Location = new System.Drawing.Point(9, 120);
            this.drawSharpImageBordersCheckBox.Name = "drawSharpImageBordersCheckBox";
            this.drawSharpImageBordersCheckBox.Size = new System.Drawing.Size(165, 19);
            this.drawSharpImageBordersCheckBox.TabIndex = 11;
            this.drawSharpImageBordersCheckBox.Text = "Draw Sharp Image Borders";
            this.drawSharpImageBordersCheckBox.UseVisualStyleBackColor = true;
            // 
            // optimizeImageDrawingCheckBox
            // 
            this.optimizeImageDrawingCheckBox.AutoSize = true;
            this.optimizeImageDrawingCheckBox.Location = new System.Drawing.Point(9, 141);
            this.optimizeImageDrawingCheckBox.Name = "optimizeImageDrawingCheckBox";
            this.optimizeImageDrawingCheckBox.Size = new System.Drawing.Size(157, 19);
            this.optimizeImageDrawingCheckBox.TabIndex = 10;
            this.optimizeImageDrawingCheckBox.Text = "Optimize Image Drawing";
            this.optimizeImageDrawingCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Interpolation Mode";
            // 
            // interpolationModeComboBox
            // 
            this.interpolationModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationModeComboBox.FormattingEnabled = true;
            this.interpolationModeComboBox.Location = new System.Drawing.Point(119, 93);
            this.interpolationModeComboBox.Name = "interpolationModeComboBox";
            this.interpolationModeComboBox.Size = new System.Drawing.Size(150, 23);
            this.interpolationModeComboBox.TabIndex = 8;
            // 
            // smoothingModeComboBox
            // 
            this.smoothingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smoothingModeComboBox.FormattingEnabled = true;
            this.smoothingModeComboBox.Location = new System.Drawing.Point(119, 66);
            this.smoothingModeComboBox.Name = "smoothingModeComboBox";
            this.smoothingModeComboBox.Size = new System.Drawing.Size(150, 23);
            this.smoothingModeComboBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "dpi";
            // 
            // verticalResolutionNumericUpDown
            // 
            this.verticalResolutionNumericUpDown.AccessibleName = "";
            this.verticalResolutionNumericUpDown.Location = new System.Drawing.Point(133, 38);
            this.verticalResolutionNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.verticalResolutionNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.verticalResolutionNumericUpDown.Name = "verticalResolutionNumericUpDown";
            this.verticalResolutionNumericUpDown.Size = new System.Drawing.Size(67, 23);
            this.verticalResolutionNumericUpDown.TabIndex = 5;
            this.verticalResolutionNumericUpDown.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // horizontalResolutionNumericUpDown
            // 
            this.horizontalResolutionNumericUpDown.Location = new System.Drawing.Point(133, 14);
            this.horizontalResolutionNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.horizontalResolutionNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.horizontalResolutionNumericUpDown.Name = "horizontalResolutionNumericUpDown";
            this.horizontalResolutionNumericUpDown.Size = new System.Drawing.Size(67, 23);
            this.horizontalResolutionNumericUpDown.TabIndex = 4;
            this.horizontalResolutionNumericUpDown.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vertical Resolution";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Smoothing Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "dpi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Horizontal Resolution";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(131, 207);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(74, 27);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(211, 207);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 27);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // RenderingSettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(297, 242);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.customSettingsGroupBox);
            this.Controls.Add(this.defaultCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenderingSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rendering Settings";
            this.customSettingsGroupBox.ResumeLayout(false);
            this.customSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticalResolutionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalResolutionNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox defaultCheckBox;
        private System.Windows.Forms.GroupBox customSettingsGroupBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox interpolationModeComboBox;
        private System.Windows.Forms.ComboBox smoothingModeComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown verticalResolutionNumericUpDown;
        private System.Windows.Forms.NumericUpDown horizontalResolutionNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox optimizeImageDrawingCheckBox;
        private System.Windows.Forms.CheckBox drawSharpImageBordersCheckBox;
    }
}