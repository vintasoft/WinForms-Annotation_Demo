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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.optimizeImageDrawingCheckBox = new System.Windows.Forms.CheckBox();
            this.drawSharpImageBordersCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.horizontalResolutionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.verticalResolutionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.smoothingModeComboBox = new System.Windows.Forms.ComboBox();
            this.interpolationModeComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.customSettingsGroupBox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalResolutionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalResolutionNumericUpDown)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultCheckBox
            // 
            this.defaultCheckBox.AutoSize = true;
            this.defaultCheckBox.Location = new System.Drawing.Point(12, 12);
            this.defaultCheckBox.Name = "defaultCheckBox";
            this.defaultCheckBox.Size = new System.Drawing.Size(101, 17);
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
            this.customSettingsGroupBox.AutoSize = true;
            this.customSettingsGroupBox.Controls.Add(this.tableLayoutPanel4);
            this.customSettingsGroupBox.Location = new System.Drawing.Point(12, 35);
            this.customSettingsGroupBox.Name = "customSettingsGroupBox";
            this.customSettingsGroupBox.Size = new System.Drawing.Size(235, 181);
            this.customSettingsGroupBox.TabIndex = 1;
            this.customSettingsGroupBox.TabStop = false;
            this.customSettingsGroupBox.Text = "Custom Settings";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.optimizeImageDrawingCheckBox, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.drawSharpImageBordersCheckBox, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(229, 162);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // optimizeImageDrawingCheckBox
            // 
            this.optimizeImageDrawingCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.optimizeImageDrawingCheckBox.AutoSize = true;
            this.optimizeImageDrawingCheckBox.Location = new System.Drawing.Point(3, 139);
            this.optimizeImageDrawingCheckBox.Name = "optimizeImageDrawingCheckBox";
            this.optimizeImageDrawingCheckBox.Size = new System.Drawing.Size(140, 17);
            this.optimizeImageDrawingCheckBox.TabIndex = 10;
            this.optimizeImageDrawingCheckBox.Text = "Optimize Image Drawing";
            this.optimizeImageDrawingCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawSharpImageBordersCheckBox
            // 
            this.drawSharpImageBordersCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.drawSharpImageBordersCheckBox.AutoSize = true;
            this.drawSharpImageBordersCheckBox.Location = new System.Drawing.Point(3, 111);
            this.drawSharpImageBordersCheckBox.Name = "drawSharpImageBordersCheckBox";
            this.drawSharpImageBordersCheckBox.Size = new System.Drawing.Size(153, 17);
            this.drawSharpImageBordersCheckBox.TabIndex = 11;
            this.drawSharpImageBordersCheckBox.Text = "Draw Sharp Image Borders";
            this.drawSharpImageBordersCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.horizontalResolutionNumericUpDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.verticalResolutionNumericUpDown, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(229, 53);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Horizontal Resolution";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vertical Resolution";
            // 
            // horizontalResolutionNumericUpDown
            // 
            this.horizontalResolutionNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.horizontalResolutionNumericUpDown.Location = new System.Drawing.Point(139, 3);
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
            this.horizontalResolutionNumericUpDown.MinimumSize = new System.Drawing.Size(60, 0);
            this.horizontalResolutionNumericUpDown.Name = "horizontalResolutionNumericUpDown";
            this.horizontalResolutionNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.horizontalResolutionNumericUpDown.TabIndex = 4;
            this.horizontalResolutionNumericUpDown.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // verticalResolutionNumericUpDown
            // 
            this.verticalResolutionNumericUpDown.AccessibleName = "";
            this.verticalResolutionNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.verticalResolutionNumericUpDown.Location = new System.Drawing.Point(139, 29);
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
            this.verticalResolutionNumericUpDown.MinimumSize = new System.Drawing.Size(60, 0);
            this.verticalResolutionNumericUpDown.Name = "verticalResolutionNumericUpDown";
            this.verticalResolutionNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.verticalResolutionNumericUpDown.TabIndex = 5;
            this.verticalResolutionNumericUpDown.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "dpi";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "dpi";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.smoothingModeComboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.interpolationModeComboBox, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 53);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(229, 53);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Smoothing Mode";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Interpolation Mode";
            // 
            // smoothingModeComboBox
            // 
            this.smoothingModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.smoothingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smoothingModeComboBox.FormattingEnabled = true;
            this.smoothingModeComboBox.Location = new System.Drawing.Point(104, 3);
            this.smoothingModeComboBox.MinimumSize = new System.Drawing.Size(120, 0);
            this.smoothingModeComboBox.Name = "smoothingModeComboBox";
            this.smoothingModeComboBox.Size = new System.Drawing.Size(122, 21);
            this.smoothingModeComboBox.TabIndex = 7;
            // 
            // interpolationModeComboBox
            // 
            this.interpolationModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.interpolationModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationModeComboBox.FormattingEnabled = true;
            this.interpolationModeComboBox.Location = new System.Drawing.Point(104, 29);
            this.interpolationModeComboBox.MinimumSize = new System.Drawing.Size(120, 0);
            this.interpolationModeComboBox.Name = "interpolationModeComboBox";
            this.interpolationModeComboBox.Size = new System.Drawing.Size(122, 21);
            this.interpolationModeComboBox.TabIndex = 8;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(91, 221);
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
            this.buttonCancel.Location = new System.Drawing.Point(171, 221);
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
            this.AutoSize = true;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(257, 256);
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
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalResolutionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalResolutionNumericUpDown)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}