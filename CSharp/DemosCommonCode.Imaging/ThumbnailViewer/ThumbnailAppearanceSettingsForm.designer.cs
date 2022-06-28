namespace DemosCommonCode.Imaging
{
    partial class ThumbnailAppearanceSettingsForm
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
            this.borderStyleLabel = new System.Windows.Forms.Label();
            this.borderWidthLabel = new System.Windows.Forms.Label();
            this.borderColorLabel = new System.Windows.Forms.Label();
            this.backColorLabel = new System.Windows.Forms.Label();
            this.borderWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.borderStyleComboBox = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.backColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.borderColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // borderStyleLabel
            // 
            this.borderStyleLabel.AutoSize = true;
            this.borderStyleLabel.Location = new System.Drawing.Point(11, 91);
            this.borderStyleLabel.Name = "borderStyleLabel";
            this.borderStyleLabel.Size = new System.Drawing.Size(70, 15);
            this.borderStyleLabel.TabIndex = 35;
            this.borderStyleLabel.Text = "Border Style";
            // 
            // borderWidthLabel
            // 
            this.borderWidthLabel.AutoSize = true;
            this.borderWidthLabel.Location = new System.Drawing.Point(11, 64);
            this.borderWidthLabel.Name = "borderWidthLabel";
            this.borderWidthLabel.Size = new System.Drawing.Size(77, 15);
            this.borderWidthLabel.TabIndex = 34;
            this.borderWidthLabel.Text = "Border Width";
            // 
            // borderColorLabel
            // 
            this.borderColorLabel.AutoSize = true;
            this.borderColorLabel.Location = new System.Drawing.Point(12, 36);
            this.borderColorLabel.Name = "borderColorLabel";
            this.borderColorLabel.Size = new System.Drawing.Size(74, 15);
            this.borderColorLabel.TabIndex = 32;
            this.borderColorLabel.Text = "Border Color";
            // 
            // backColorLabel
            // 
            this.backColorLabel.AutoSize = true;
            this.backColorLabel.Location = new System.Drawing.Point(12, 9);
            this.backColorLabel.Name = "backColorLabel";
            this.backColorLabel.Size = new System.Drawing.Size(64, 15);
            this.backColorLabel.TabIndex = 30;
            this.backColorLabel.Text = "Back Color";
            // 
            // borderWidthNumericUpDown
            // 
            this.borderWidthNumericUpDown.Location = new System.Drawing.Point(105, 62);
            this.borderWidthNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.borderWidthNumericUpDown.Name = "borderWidthNumericUpDown";
            this.borderWidthNumericUpDown.Size = new System.Drawing.Size(92, 23);
            this.borderWidthNumericUpDown.TabIndex = 40;
            // 
            // borderStyleComboBox
            // 
            this.borderStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.borderStyleComboBox.FormattingEnabled = true;
            this.borderStyleComboBox.Location = new System.Drawing.Point(105, 88);
            this.borderStyleComboBox.Name = "borderStyleComboBox";
            this.borderStyleComboBox.Size = new System.Drawing.Size(92, 23);
            this.borderStyleComboBox.TabIndex = 41;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(144, 128);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 23);
            this.buttonCancel.TabIndex = 43;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(45, 128);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(81, 23);
            this.buttonOk.TabIndex = 42;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.okButton_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.SolidColorOnly = true;
            // 
            // backColorPanelControl
            // 
            this.backColorPanelControl.CanSetDefaultColor = true;
            this.backColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.backColorPanelControl.ColorButtonMargin = 5;
            this.backColorPanelControl.ColorButtonWidth = 24;
            this.backColorPanelControl.DefaultColor = System.Drawing.Color.Transparent;
            this.backColorPanelControl.DefaultColorButtonMargin = 2;
            this.backColorPanelControl.DefaultColorButtonWidth = 24;
            this.backColorPanelControl.Location = new System.Drawing.Point(105, 5);
            this.backColorPanelControl.Name = "backColorPanelControl";
            this.backColorPanelControl.Size = new System.Drawing.Size(147, 21);
            this.backColorPanelControl.TabIndex = 45;
            // 
            // borderColorPanelControl
            // 
            this.borderColorPanelControl.CanSetDefaultColor = true;
            this.borderColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.borderColorPanelControl.ColorButtonMargin = 5;
            this.borderColorPanelControl.ColorButtonWidth = 24;
            this.borderColorPanelControl.DefaultColor = System.Drawing.Color.Transparent;
            this.borderColorPanelControl.DefaultColorButtonMargin = 2;
            this.borderColorPanelControl.DefaultColorButtonWidth = 24;
            this.borderColorPanelControl.Location = new System.Drawing.Point(105, 32);
            this.borderColorPanelControl.Name = "borderColorPanelControl";
            this.borderColorPanelControl.Size = new System.Drawing.Size(147, 21);
            this.borderColorPanelControl.TabIndex = 44;
            // 
            // ThumbnailAppearanceSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(265, 158);
            this.Controls.Add(this.backColorPanelControl);
            this.Controls.Add(this.borderColorPanelControl);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.borderStyleComboBox);
            this.Controls.Add(this.borderWidthNumericUpDown);
            this.Controls.Add(this.borderStyleLabel);
            this.Controls.Add(this.borderWidthLabel);
            this.Controls.Add(this.borderColorLabel);
            this.Controls.Add(this.backColorLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThumbnailAppearanceSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thumbnail Appearance Settings";
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label borderStyleLabel;
        private System.Windows.Forms.Label borderWidthLabel;
        private System.Windows.Forms.Label borderColorLabel;
        private System.Windows.Forms.Label backColorLabel;
        private System.Windows.Forms.NumericUpDown borderWidthNumericUpDown;
        private System.Windows.Forms.ComboBox borderStyleComboBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private DemosCommonCode.CustomControls.ColorPanelControl borderColorPanelControl;
        private DemosCommonCode.CustomControls.ColorPanelControl backColorPanelControl;
    }
}