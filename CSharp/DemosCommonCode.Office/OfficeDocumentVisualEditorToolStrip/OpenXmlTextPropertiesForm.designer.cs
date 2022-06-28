
namespace DemosCommonCode.Office
{
    partial class OpenXmlTextPropertiesForm
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.fontListBox = new System.Windows.Forms.ListBox();
            this.fontStyleListBox = new System.Windows.Forms.ListBox();
            this.fontSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.underlineComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.subscriptCheckBox = new System.Windows.Forms.CheckBox();
            this.superscriptCheckBox = new System.Windows.Forms.CheckBox();
            this.strikeoutCheckBox = new System.Windows.Forms.CheckBox();
            this.doubleStrikeoutcheckBox = new System.Windows.Forms.CheckBox();
            this.horizontalScaleComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.characterSpacingComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.underlineColorPanel = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.fontColorPanel = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.textHighlightComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(167, 362);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(248, 362);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // fontListBox
            // 
            this.fontListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fontListBox.FormattingEnabled = true;
            this.fontListBox.Location = new System.Drawing.Point(12, 25);
            this.fontListBox.Name = "fontListBox";
            this.fontListBox.Size = new System.Drawing.Size(213, 186);
            this.fontListBox.TabIndex = 2;
            // 
            // fontStyleListBox
            // 
            this.fontStyleListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fontStyleListBox.FormattingEnabled = true;
            this.fontStyleListBox.Items.AddRange(new object[] {
            "Ordinary",
            "Bold",
            "Italic",
            "Bold Italic"});
            this.fontStyleListBox.Location = new System.Drawing.Point(230, 51);
            this.fontStyleListBox.Name = "fontStyleListBox";
            this.fontStyleListBox.Size = new System.Drawing.Size(93, 69);
            this.fontStyleListBox.TabIndex = 3;
            // 
            // fontSizeComboBox
            // 
            this.fontSizeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fontSizeComboBox.FormattingEnabled = true;
            this.fontSizeComboBox.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "28",
            "36",
            "48",
            "72"});
            this.fontSizeComboBox.Location = new System.Drawing.Point(230, 25);
            this.fontSizeComboBox.Name = "fontSizeComboBox";
            this.fontSizeComboBox.Size = new System.Drawing.Size(93, 21);
            this.fontSizeComboBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Font";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Size";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Font Color";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Underline";
            // 
            // underlineComboBox
            // 
            this.underlineComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.underlineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.underlineComboBox.FormattingEnabled = true;
            this.underlineComboBox.Location = new System.Drawing.Point(12, 281);
            this.underlineComboBox.Name = "underlineComboBox";
            this.underlineComboBox.Size = new System.Drawing.Size(150, 21);
            this.underlineComboBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Underline Color";
            // 
            // subscriptCheckBox
            // 
            this.subscriptCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.subscriptCheckBox.AutoSize = true;
            this.subscriptCheckBox.Location = new System.Drawing.Point(231, 126);
            this.subscriptCheckBox.Name = "subscriptCheckBox";
            this.subscriptCheckBox.Size = new System.Drawing.Size(70, 17);
            this.subscriptCheckBox.TabIndex = 13;
            this.subscriptCheckBox.Text = "Subscript";
            this.subscriptCheckBox.UseVisualStyleBackColor = true;
            this.subscriptCheckBox.CheckedChanged += new System.EventHandler(this.subscriptCheckBox_CheckedChanged);
            // 
            // superscriptCheckBox
            // 
            this.superscriptCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.superscriptCheckBox.AutoSize = true;
            this.superscriptCheckBox.Location = new System.Drawing.Point(231, 149);
            this.superscriptCheckBox.Name = "superscriptCheckBox";
            this.superscriptCheckBox.Size = new System.Drawing.Size(79, 17);
            this.superscriptCheckBox.TabIndex = 14;
            this.superscriptCheckBox.Text = "Superscript";
            this.superscriptCheckBox.UseVisualStyleBackColor = true;
            this.superscriptCheckBox.CheckedChanged += new System.EventHandler(this.superscriptCheckBox_CheckedChanged);
            // 
            // strikeoutCheckBox
            // 
            this.strikeoutCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.strikeoutCheckBox.AutoSize = true;
            this.strikeoutCheckBox.Location = new System.Drawing.Point(231, 172);
            this.strikeoutCheckBox.Name = "strikeoutCheckBox";
            this.strikeoutCheckBox.Size = new System.Drawing.Size(68, 17);
            this.strikeoutCheckBox.TabIndex = 15;
            this.strikeoutCheckBox.Text = "Strikeout";
            this.strikeoutCheckBox.UseVisualStyleBackColor = true;
            this.strikeoutCheckBox.CheckedChanged += new System.EventHandler(this.strikeoutCheckBox_CheckedChanged);
            // 
            // doubleStrikeoutcheckBox
            // 
            this.doubleStrikeoutcheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleStrikeoutcheckBox.AutoSize = true;
            this.doubleStrikeoutcheckBox.Location = new System.Drawing.Point(231, 195);
            this.doubleStrikeoutcheckBox.Name = "doubleStrikeoutcheckBox";
            this.doubleStrikeoutcheckBox.Size = new System.Drawing.Size(103, 17);
            this.doubleStrikeoutcheckBox.TabIndex = 16;
            this.doubleStrikeoutcheckBox.Text = "Double strikeout";
            this.doubleStrikeoutcheckBox.UseVisualStyleBackColor = true;
            this.doubleStrikeoutcheckBox.CheckedChanged += new System.EventHandler(this.doubleStrikeoutcheckBox_CheckedChanged);
            // 
            // horizontalScaleComboBox
            // 
            this.horizontalScaleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.horizontalScaleComboBox.FormattingEnabled = true;
            this.horizontalScaleComboBox.Items.AddRange(new object[] {
            "0.5",
            "0.75",
            "1",
            "1.25",
            "1.5",
            "2"});
            this.horizontalScaleComboBox.Location = new System.Drawing.Point(12, 325);
            this.horizontalScaleComboBox.Name = "horizontalScaleComboBox";
            this.horizontalScaleComboBox.Size = new System.Drawing.Size(150, 21);
            this.horizontalScaleComboBox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Horizontal Scale";
            // 
            // characterSpacingComboBox
            // 
            this.characterSpacingComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.characterSpacingComboBox.FormattingEnabled = true;
            this.characterSpacingComboBox.Items.AddRange(new object[] {
            "-5",
            "-1",
            "0",
            "1",
            "5"});
            this.characterSpacingComboBox.Location = new System.Drawing.Point(175, 325);
            this.characterSpacingComboBox.Name = "characterSpacingComboBox";
            this.characterSpacingComboBox.Size = new System.Drawing.Size(150, 21);
            this.characterSpacingComboBox.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Character Spacing (Points)";
            // 
            // underlineColorPanel
            // 
            this.underlineColorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.underlineColorPanel.CanEditAlphaChannel = false;
            this.underlineColorPanel.Color = System.Drawing.Color.Transparent;
            this.underlineColorPanel.DefaultColor = System.Drawing.Color.Empty;
            this.underlineColorPanel.Location = new System.Drawing.Point(175, 280);
            this.underlineColorPanel.Name = "underlineColorPanel";
            this.underlineColorPanel.Size = new System.Drawing.Size(150, 22);
            this.underlineColorPanel.TabIndex = 12;
            // 
            // fontColorPanel
            // 
            this.fontColorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fontColorPanel.CanEditAlphaChannel = false;
            this.fontColorPanel.Color = System.Drawing.Color.Transparent;
            this.fontColorPanel.DefaultColor = System.Drawing.Color.Empty;
            this.fontColorPanel.Location = new System.Drawing.Point(12, 236);
            this.fontColorPanel.Name = "fontColorPanel";
            this.fontColorPanel.Size = new System.Drawing.Size(150, 22);
            this.fontColorPanel.TabIndex = 7;
            // 
            // textHighlightComboBox
            // 
            this.textHighlightComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textHighlightComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textHighlightComboBox.FormattingEnabled = true;
            this.textHighlightComboBox.Location = new System.Drawing.Point(175, 237);
            this.textHighlightComboBox.Name = "textHighlightComboBox";
            this.textHighlightComboBox.Size = new System.Drawing.Size(150, 21);
            this.textHighlightComboBox.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Text Highlight";
            // 
            // OpenXmlTextPropertiesForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(335, 397);
            this.Controls.Add(this.textHighlightComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.characterSpacingComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.horizontalScaleComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.doubleStrikeoutcheckBox);
            this.Controls.Add(this.strikeoutCheckBox);
            this.Controls.Add(this.superscriptCheckBox);
            this.Controls.Add(this.subscriptCheckBox);
            this.Controls.Add(this.underlineColorPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.underlineComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fontColorPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fontSizeComboBox);
            this.Controls.Add(this.fontStyleListBox);
            this.Controls.Add(this.fontListBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenXmlTextPropertiesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Font Properties";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListBox fontListBox;
        private System.Windows.Forms.ListBox fontStyleListBox;
        private System.Windows.Forms.ComboBox fontSizeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControls.ColorPanelControl fontColorPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox underlineComboBox;
        private System.Windows.Forms.Label label5;
        private CustomControls.ColorPanelControl underlineColorPanel;
        private System.Windows.Forms.CheckBox subscriptCheckBox;
        private System.Windows.Forms.CheckBox superscriptCheckBox;
        private System.Windows.Forms.CheckBox strikeoutCheckBox;
        private System.Windows.Forms.CheckBox doubleStrikeoutcheckBox;
        private System.Windows.Forms.ComboBox horizontalScaleComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox characterSpacingComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox textHighlightComboBox;
        private System.Windows.Forms.Label label8;
    }
}