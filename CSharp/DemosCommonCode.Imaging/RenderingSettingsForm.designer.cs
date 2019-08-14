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
            this.cbDefault = new System.Windows.Forms.CheckBox();
            this.gbCustomSettings = new System.Windows.Forms.GroupBox();
            this.optimizeImageDrawingCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.interpolationModeComboBox = new System.Windows.Forms.ComboBox();
            this.smoothingModeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.verticalResolution = new System.Windows.Forms.NumericUpDown();
            this.horizontalResolution = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.gbCustomSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticalResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalResolution)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDefault
            // 
            this.cbDefault.AutoSize = true;
            this.cbDefault.Location = new System.Drawing.Point(12, 12);
            this.cbDefault.Name = "cbDefault";
            this.cbDefault.Size = new System.Drawing.Size(101, 17);
            this.cbDefault.TabIndex = 0;
            this.cbDefault.Text = "Default Settings";
            this.cbDefault.UseVisualStyleBackColor = true;
            this.cbDefault.CheckedChanged += new System.EventHandler(this.cbDefault_CheckedChanged);
            // 
            // gbCustomSettings
            // 
            this.gbCustomSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCustomSettings.Controls.Add(this.optimizeImageDrawingCheckBox);
            this.gbCustomSettings.Controls.Add(this.label6);
            this.gbCustomSettings.Controls.Add(this.interpolationModeComboBox);
            this.gbCustomSettings.Controls.Add(this.smoothingModeComboBox);
            this.gbCustomSettings.Controls.Add(this.label5);
            this.gbCustomSettings.Controls.Add(this.verticalResolution);
            this.gbCustomSettings.Controls.Add(this.horizontalResolution);
            this.gbCustomSettings.Controls.Add(this.label4);
            this.gbCustomSettings.Controls.Add(this.label3);
            this.gbCustomSettings.Controls.Add(this.label2);
            this.gbCustomSettings.Controls.Add(this.label1);
            this.gbCustomSettings.Location = new System.Drawing.Point(12, 35);
            this.gbCustomSettings.Name = "gbCustomSettings";
            this.gbCustomSettings.Size = new System.Drawing.Size(275, 144);
            this.gbCustomSettings.TabIndex = 1;
            this.gbCustomSettings.TabStop = false;
            this.gbCustomSettings.Text = "Custom Settings";
            // 
            // optimizeImageDrawingCheckBox
            // 
            this.optimizeImageDrawingCheckBox.AutoSize = true;
            this.optimizeImageDrawingCheckBox.Location = new System.Drawing.Point(9, 121);
            this.optimizeImageDrawingCheckBox.Name = "optimizeImageDrawingCheckBox";
            this.optimizeImageDrawingCheckBox.Size = new System.Drawing.Size(140, 17);
            this.optimizeImageDrawingCheckBox.TabIndex = 10;
            this.optimizeImageDrawingCheckBox.Text = "Optimize Image Drawing";
            this.optimizeImageDrawingCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Interpolation Mode";
            // 
            // interpolationModeComboBox
            // 
            this.interpolationModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationModeComboBox.FormattingEnabled = true;
            this.interpolationModeComboBox.Location = new System.Drawing.Point(119, 93);
            this.interpolationModeComboBox.Name = "interpolationModeComboBox";
            this.interpolationModeComboBox.Size = new System.Drawing.Size(150, 21);
            this.interpolationModeComboBox.TabIndex = 8;
            // 
            // smoothingModeComboBox
            // 
            this.smoothingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smoothingModeComboBox.FormattingEnabled = true;
            this.smoothingModeComboBox.Location = new System.Drawing.Point(119, 66);
            this.smoothingModeComboBox.Name = "smoothingModeComboBox";
            this.smoothingModeComboBox.Size = new System.Drawing.Size(150, 21);
            this.smoothingModeComboBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "dpi";
            // 
            // verticalResolution
            // 
            this.verticalResolution.AccessibleName = "";
            this.verticalResolution.Location = new System.Drawing.Point(119, 40);
            this.verticalResolution.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.verticalResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.verticalResolution.Name = "verticalResolution";
            this.verticalResolution.Size = new System.Drawing.Size(67, 20);
            this.verticalResolution.TabIndex = 5;
            this.verticalResolution.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // horizontalResolution
            // 
            this.horizontalResolution.Location = new System.Drawing.Point(119, 14);
            this.horizontalResolution.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.horizontalResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.horizontalResolution.Name = "horizontalResolution";
            this.horizontalResolution.Size = new System.Drawing.Size(67, 20);
            this.horizontalResolution.TabIndex = 4;
            this.horizontalResolution.Value = new decimal(new int[] {
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
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vertical Resolution";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Smoothing Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "dpi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Horizontal Resolution";
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(131, 187);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(74, 27);
            this.btOk.TabIndex = 2;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(211, 187);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 27);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // RenderingSettingsForm
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(297, 222);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.gbCustomSettings);
            this.Controls.Add(this.cbDefault);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenderingSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rendering Settings";
            this.gbCustomSettings.ResumeLayout(false);
            this.gbCustomSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verticalResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalResolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbDefault;
        private System.Windows.Forms.GroupBox gbCustomSettings;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.ComboBox interpolationModeComboBox;
        private System.Windows.Forms.ComboBox smoothingModeComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown verticalResolution;
        private System.Windows.Forms.NumericUpDown horizontalResolution;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.CheckBox optimizeImageDrawingCheckBox;
    }
}