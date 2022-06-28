
namespace DemosCommonCode.Office
{
    partial class OpenXmlParagraphPropertiesForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textJustificationComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.firstLineIndentationComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rightIndentationComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.leftIndentationComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lineHeightComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.spacingAfterComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.spacingBeforeComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fillColorPanel = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.keepLinesCheckBox = new System.Windows.Forms.CheckBox();
            this.keepNextCheckBox = new System.Windows.Forms.CheckBox();
            this.widowControlCheckBox = new System.Windows.Forms.CheckBox();
            this.pageBreakBeforeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(191, 340);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(110, 340);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Text Justification";
            // 
            // textJustificationComboBox
            // 
            this.textJustificationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textJustificationComboBox.FormattingEnabled = true;
            this.textJustificationComboBox.Location = new System.Drawing.Point(15, 25);
            this.textJustificationComboBox.Name = "textJustificationComboBox";
            this.textJustificationComboBox.Size = new System.Drawing.Size(120, 21);
            this.textJustificationComboBox.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.firstLineIndentationComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rightIndentationComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.leftIndentationComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(5, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 107);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Indentation";
            // 
            // firstLineIndentationComboBox
            // 
            this.firstLineIndentationComboBox.FormattingEnabled = true;
            this.firstLineIndentationComboBox.Items.AddRange(new object[] {
            "0"});
            this.firstLineIndentationComboBox.Location = new System.Drawing.Point(9, 32);
            this.firstLineIndentationComboBox.Name = "firstLineIndentationComboBox";
            this.firstLineIndentationComboBox.Size = new System.Drawing.Size(121, 21);
            this.firstLineIndentationComboBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "First Line (Points)";
            // 
            // rightIndentationComboBox
            // 
            this.rightIndentationComboBox.FormattingEnabled = true;
            this.rightIndentationComboBox.Items.AddRange(new object[] {
            "0"});
            this.rightIndentationComboBox.Location = new System.Drawing.Point(136, 76);
            this.rightIndentationComboBox.Name = "rightIndentationComboBox";
            this.rightIndentationComboBox.Size = new System.Drawing.Size(121, 21);
            this.rightIndentationComboBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Right (Points)";
            // 
            // leftIndentationComboBox
            // 
            this.leftIndentationComboBox.FormattingEnabled = true;
            this.leftIndentationComboBox.Items.AddRange(new object[] {
            "0"});
            this.leftIndentationComboBox.Location = new System.Drawing.Point(9, 76);
            this.leftIndentationComboBox.Name = "leftIndentationComboBox";
            this.leftIndentationComboBox.Size = new System.Drawing.Size(121, 21);
            this.leftIndentationComboBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Left (Points)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lineHeightComboBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.spacingAfterComboBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.spacingBeforeComboBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(5, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 107);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Spacing";
            // 
            // lineHeightComboBox
            // 
            this.lineHeightComboBox.FormattingEnabled = true;
            this.lineHeightComboBox.Items.AddRange(new object[] {
            "1",
            "1.08",
            "1.5",
            "2"});
            this.lineHeightComboBox.Location = new System.Drawing.Point(10, 32);
            this.lineHeightComboBox.Name = "lineHeightComboBox";
            this.lineHeightComboBox.Size = new System.Drawing.Size(121, 21);
            this.lineHeightComboBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Line height factor";
            // 
            // spacingAfterComboBox
            // 
            this.spacingAfterComboBox.FormattingEnabled = true;
            this.spacingAfterComboBox.Items.AddRange(new object[] {
            "0"});
            this.spacingAfterComboBox.Location = new System.Drawing.Point(136, 76);
            this.spacingAfterComboBox.Name = "spacingAfterComboBox";
            this.spacingAfterComboBox.Size = new System.Drawing.Size(121, 21);
            this.spacingAfterComboBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "After (Points)";
            // 
            // spacingBeforeComboBox
            // 
            this.spacingBeforeComboBox.FormattingEnabled = true;
            this.spacingBeforeComboBox.Items.AddRange(new object[] {
            "0"});
            this.spacingBeforeComboBox.Location = new System.Drawing.Point(9, 76);
            this.spacingBeforeComboBox.Name = "spacingBeforeComboBox";
            this.spacingBeforeComboBox.Size = new System.Drawing.Size(121, 21);
            this.spacingBeforeComboBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Before (Points)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Color";
            // 
            // fillColorPanel
            // 
            this.fillColorPanel.CanEditAlphaChannel = false;
            this.fillColorPanel.Color = System.Drawing.Color.Transparent;
            this.fillColorPanel.DefaultColor = System.Drawing.Color.Empty;
            this.fillColorPanel.Location = new System.Drawing.Point(141, 24);
            this.fillColorPanel.Name = "fillColorPanel";
            this.fillColorPanel.Size = new System.Drawing.Size(121, 23);
            this.fillColorPanel.TabIndex = 15;
            // 
            // keepLinesCheckBox
            // 
            this.keepLinesCheckBox.AutoSize = true;
            this.keepLinesCheckBox.Location = new System.Drawing.Point(15, 283);
            this.keepLinesCheckBox.Name = "keepLinesCheckBox";
            this.keepLinesCheckBox.Size = new System.Drawing.Size(79, 17);
            this.keepLinesCheckBox.TabIndex = 16;
            this.keepLinesCheckBox.Text = "Keep Lines";
            this.keepLinesCheckBox.UseVisualStyleBackColor = true;
            // 
            // keepNextCheckBox
            // 
            this.keepNextCheckBox.AutoSize = true;
            this.keepNextCheckBox.Location = new System.Drawing.Point(141, 283);
            this.keepNextCheckBox.Name = "keepNextCheckBox";
            this.keepNextCheckBox.Size = new System.Drawing.Size(76, 17);
            this.keepNextCheckBox.TabIndex = 17;
            this.keepNextCheckBox.Text = "Keep Next";
            this.keepNextCheckBox.UseVisualStyleBackColor = true;
            // 
            // widowControlCheckBox
            // 
            this.widowControlCheckBox.AutoSize = true;
            this.widowControlCheckBox.Location = new System.Drawing.Point(15, 306);
            this.widowControlCheckBox.Name = "widowControlCheckBox";
            this.widowControlCheckBox.Size = new System.Drawing.Size(95, 17);
            this.widowControlCheckBox.TabIndex = 18;
            this.widowControlCheckBox.Text = "Widow Control";
            this.widowControlCheckBox.UseVisualStyleBackColor = true;
            // 
            // pageBreakBeforeCheckBox
            // 
            this.pageBreakBeforeCheckBox.AutoSize = true;
            this.pageBreakBeforeCheckBox.Location = new System.Drawing.Point(141, 306);
            this.pageBreakBeforeCheckBox.Name = "pageBreakBeforeCheckBox";
            this.pageBreakBeforeCheckBox.Size = new System.Drawing.Size(116, 17);
            this.pageBreakBeforeCheckBox.TabIndex = 19;
            this.pageBreakBeforeCheckBox.Text = "Page Break Before";
            this.pageBreakBeforeCheckBox.UseVisualStyleBackColor = true;
            // 
            // OpenXmlParagraphPropertiesForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(278, 375);
            this.Controls.Add(this.pageBreakBeforeCheckBox);
            this.Controls.Add(this.widowControlCheckBox);
            this.Controls.Add(this.keepNextCheckBox);
            this.Controls.Add(this.keepLinesCheckBox);
            this.Controls.Add(this.fillColorPanel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textJustificationComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenXmlParagraphPropertiesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Paragraph Properties";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox textJustificationComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox firstLineIndentationComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox rightIndentationComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox leftIndentationComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox lineHeightComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox spacingAfterComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox spacingBeforeComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private CustomControls.ColorPanelControl fillColorPanel;
        private System.Windows.Forms.CheckBox keepLinesCheckBox;
        private System.Windows.Forms.CheckBox keepNextCheckBox;
        private System.Windows.Forms.CheckBox widowControlCheckBox;
        private System.Windows.Forms.CheckBox pageBreakBeforeCheckBox;
    }
}