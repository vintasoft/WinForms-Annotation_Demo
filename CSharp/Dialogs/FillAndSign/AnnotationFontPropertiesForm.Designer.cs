namespace AnnotationDemo
{
    partial class AnnotationFontPropertiesForm
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
            this.fontFamilyNameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fontSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.isBoldCheckBox = new System.Windows.Forms.CheckBox();
            this.isItalicCheckBox = new System.Windows.Forms.CheckBox();
            this.isStrikeoutCheckBox = new System.Windows.Forms.CheckBox();
            this.isUnderlineCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.fontColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // fontFamilyNameComboBox
            // 
            this.fontFamilyNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontFamilyNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontFamilyNameComboBox.FormattingEnabled = true;
            this.fontFamilyNameComboBox.Location = new System.Drawing.Point(48, 11);
            this.fontFamilyNameComboBox.Name = "fontFamilyNameComboBox";
            this.fontFamilyNameComboBox.Size = new System.Drawing.Size(223, 21);
            this.fontFamilyNameComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Font";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Size";
            // 
            // fontSizeNumericUpDown
            // 
            this.fontSizeNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontSizeNumericUpDown.Location = new System.Drawing.Point(49, 38);
            this.fontSizeNumericUpDown.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.fontSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontSizeNumericUpDown.Name = "fontSizeNumericUpDown";
            this.fontSizeNumericUpDown.Size = new System.Drawing.Size(222, 20);
            this.fontSizeNumericUpDown.TabIndex = 3;
            this.fontSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // isBoldCheckBox
            // 
            this.isBoldCheckBox.AutoSize = true;
            this.isBoldCheckBox.Location = new System.Drawing.Point(49, 92);
            this.isBoldCheckBox.Name = "isBoldCheckBox";
            this.isBoldCheckBox.Size = new System.Drawing.Size(47, 17);
            this.isBoldCheckBox.TabIndex = 4;
            this.isBoldCheckBox.Text = "Bold";
            this.isBoldCheckBox.UseVisualStyleBackColor = true;
            // 
            // isItalicCheckBox
            // 
            this.isItalicCheckBox.AutoSize = true;
            this.isItalicCheckBox.Location = new System.Drawing.Point(49, 115);
            this.isItalicCheckBox.Name = "isItalicCheckBox";
            this.isItalicCheckBox.Size = new System.Drawing.Size(48, 17);
            this.isItalicCheckBox.TabIndex = 5;
            this.isItalicCheckBox.Text = "Italic";
            this.isItalicCheckBox.UseVisualStyleBackColor = true;
            // 
            // isStrikeoutCheckBox
            // 
            this.isStrikeoutCheckBox.AutoSize = true;
            this.isStrikeoutCheckBox.Location = new System.Drawing.Point(49, 138);
            this.isStrikeoutCheckBox.Name = "isStrikeoutCheckBox";
            this.isStrikeoutCheckBox.Size = new System.Drawing.Size(68, 17);
            this.isStrikeoutCheckBox.TabIndex = 6;
            this.isStrikeoutCheckBox.Text = "Strikeout";
            this.isStrikeoutCheckBox.UseVisualStyleBackColor = true;
            // 
            // isUnderlineCheckBox
            // 
            this.isUnderlineCheckBox.AutoSize = true;
            this.isUnderlineCheckBox.Location = new System.Drawing.Point(49, 161);
            this.isUnderlineCheckBox.Name = "isUnderlineCheckBox";
            this.isUnderlineCheckBox.Size = new System.Drawing.Size(71, 17);
            this.isUnderlineCheckBox.TabIndex = 7;
            this.isUnderlineCheckBox.Text = "Underline";
            this.isUnderlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(115, 186);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(196, 186);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Color";
            // 
            // fontColorPanelControl
            // 
            this.fontColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.fontColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.fontColorPanelControl.Location = new System.Drawing.Point(49, 64);
            this.fontColorPanelControl.Name = "fontColorPanelControl";
            this.fontColorPanelControl.Size = new System.Drawing.Size(222, 22);
            this.fontColorPanelControl.TabIndex = 11;
            // 
            // AnnotationFontPropertiesForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(283, 221);
            this.Controls.Add(this.fontColorPanelControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.isUnderlineCheckBox);
            this.Controls.Add(this.isStrikeoutCheckBox);
            this.Controls.Add(this.isItalicCheckBox);
            this.Controls.Add(this.isBoldCheckBox);
            this.Controls.Add(this.fontSizeNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fontFamilyNameComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AnnotationFontPropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Font Properties";
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fontFamilyNameComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown fontSizeNumericUpDown;
        private System.Windows.Forms.CheckBox isBoldCheckBox;
        private System.Windows.Forms.CheckBox isItalicCheckBox;
        private System.Windows.Forms.CheckBox isStrikeoutCheckBox;
        private System.Windows.Forms.CheckBox isUnderlineCheckBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private DemosCommonCode.CustomControls.ColorPanelControl fontColorPanelControl;
    }
}