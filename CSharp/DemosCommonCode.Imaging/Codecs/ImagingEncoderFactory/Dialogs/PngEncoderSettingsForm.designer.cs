namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    partial class PngEncoderSettingsForm
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
            this.customGroupBox = new System.Windows.Forms.GroupBox();
            this.filterMethodComboBox = new System.Windows.Forms.ComboBox();
            this.compressionLevelComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customRadioButton = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.bestCompressionRadioButton = new System.Windows.Forms.RadioButton();
            this.normalRadioButton = new System.Windows.Forms.RadioButton();
            this.fastRadioButton = new System.Windows.Forms.RadioButton();
            this.bestSpeedRadioButton = new System.Windows.Forms.RadioButton();
            this.settingsTabControl = new System.Windows.Forms.TabControl();
            this.compressionTabPage = new System.Windows.Forms.TabPage();
            this.annotationsTabPage = new System.Windows.Forms.TabPage();
            this.annotationsBinaryCheckBox = new System.Windows.Forms.CheckBox();
            this.adam7InterlacingCheckBox = new System.Windows.Forms.CheckBox();
            this.customGroupBox.SuspendLayout();
            this.settingsTabControl.SuspendLayout();
            this.compressionTabPage.SuspendLayout();
            this.annotationsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // customGroupBox
            // 
            this.customGroupBox.Controls.Add(this.filterMethodComboBox);
            this.customGroupBox.Controls.Add(this.compressionLevelComboBox);
            this.customGroupBox.Controls.Add(this.label2);
            this.customGroupBox.Controls.Add(this.label1);
            this.customGroupBox.Location = new System.Drawing.Point(129, 4);
            this.customGroupBox.Name = "customGroupBox";
            this.customGroupBox.Size = new System.Drawing.Size(206, 86);
            this.customGroupBox.TabIndex = 11;
            this.customGroupBox.TabStop = false;
            // 
            // filterMethodComboBox
            // 
            this.filterMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterMethodComboBox.FormattingEnabled = true;
            this.filterMethodComboBox.Location = new System.Drawing.Point(112, 22);
            this.filterMethodComboBox.Name = "filterMethodComboBox";
            this.filterMethodComboBox.Size = new System.Drawing.Size(88, 21);
            this.filterMethodComboBox.TabIndex = 5;
            // 
            // compressionLevelComboBox
            // 
            this.compressionLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compressionLevelComboBox.FormattingEnabled = true;
            this.compressionLevelComboBox.Location = new System.Drawing.Point(113, 52);
            this.compressionLevelComboBox.Name = "compressionLevelComboBox";
            this.compressionLevelComboBox.Size = new System.Drawing.Size(88, 21);
            this.compressionLevelComboBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter method";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Compression level";
            // 
            // customRadioButton
            // 
            this.customRadioButton.AutoSize = true;
            this.customRadioButton.Location = new System.Drawing.Point(135, 2);
            this.customRadioButton.Name = "customRadioButton";
            this.customRadioButton.Size = new System.Drawing.Size(60, 17);
            this.customRadioButton.TabIndex = 4;
            this.customRadioButton.TabStop = true;
            this.customRadioButton.Text = "Custom";
            this.customRadioButton.UseVisualStyleBackColor = true;
            this.customRadioButton.CheckedChanged += new System.EventHandler(this.customRadioButton_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(182, 162);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(101, 162);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // bestCompressionRadioButton
            // 
            this.bestCompressionRadioButton.AutoSize = true;
            this.bestCompressionRadioButton.Location = new System.Drawing.Point(6, 69);
            this.bestCompressionRadioButton.Name = "bestCompressionRadioButton";
            this.bestCompressionRadioButton.Size = new System.Drawing.Size(108, 17);
            this.bestCompressionRadioButton.TabIndex = 3;
            this.bestCompressionRadioButton.Text = "Best compression";
            this.bestCompressionRadioButton.UseVisualStyleBackColor = true;
            this.bestCompressionRadioButton.CheckedChanged += new System.EventHandler(this.bestCompressionRadioButton_CheckedChanged);
            // 
            // normalRadioButton
            // 
            this.normalRadioButton.AutoSize = true;
            this.normalRadioButton.Location = new System.Drawing.Point(6, 48);
            this.normalRadioButton.Name = "normalRadioButton";
            this.normalRadioButton.Size = new System.Drawing.Size(58, 17);
            this.normalRadioButton.TabIndex = 2;
            this.normalRadioButton.Text = "Normal";
            this.normalRadioButton.UseVisualStyleBackColor = true;
            this.normalRadioButton.CheckedChanged += new System.EventHandler(this.normalRadioButton_CheckedChanged);
            // 
            // fastRadioButton
            // 
            this.fastRadioButton.AutoSize = true;
            this.fastRadioButton.Location = new System.Drawing.Point(6, 27);
            this.fastRadioButton.Name = "fastRadioButton";
            this.fastRadioButton.Size = new System.Drawing.Size(45, 17);
            this.fastRadioButton.TabIndex = 1;
            this.fastRadioButton.Text = "Fast";
            this.fastRadioButton.UseVisualStyleBackColor = true;
            this.fastRadioButton.CheckedChanged += new System.EventHandler(this.fastRadioButton_CheckedChanged);
            // 
            // bestSpeedRadioButton
            // 
            this.bestSpeedRadioButton.AutoSize = true;
            this.bestSpeedRadioButton.Location = new System.Drawing.Point(6, 6);
            this.bestSpeedRadioButton.Name = "bestSpeedRadioButton";
            this.bestSpeedRadioButton.Size = new System.Drawing.Size(78, 17);
            this.bestSpeedRadioButton.TabIndex = 0;
            this.bestSpeedRadioButton.Text = "Best speed";
            this.bestSpeedRadioButton.UseVisualStyleBackColor = true;
            this.bestSpeedRadioButton.CheckedChanged += new System.EventHandler(this.bestSpeedRadioButton_CheckedChanged);
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Controls.Add(this.compressionTabPage);
            this.settingsTabControl.Controls.Add(this.annotationsTabPage);
            this.settingsTabControl.Location = new System.Drawing.Point(7, 9);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(350, 147);
            this.settingsTabControl.TabIndex = 12;
            // 
            // compressionTabPage
            // 
            this.compressionTabPage.Controls.Add(this.adam7InterlacingCheckBox);
            this.compressionTabPage.Controls.Add(this.bestSpeedRadioButton);
            this.compressionTabPage.Controls.Add(this.fastRadioButton);
            this.compressionTabPage.Controls.Add(this.normalRadioButton);
            this.compressionTabPage.Controls.Add(this.bestCompressionRadioButton);
            this.compressionTabPage.Controls.Add(this.customRadioButton);
            this.compressionTabPage.Controls.Add(this.customGroupBox);
            this.compressionTabPage.Location = new System.Drawing.Point(4, 22);
            this.compressionTabPage.Name = "compressionTabPage";
            this.compressionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.compressionTabPage.Size = new System.Drawing.Size(342, 121);
            this.compressionTabPage.TabIndex = 0;
            this.compressionTabPage.Text = "Compression";
            this.compressionTabPage.UseVisualStyleBackColor = true;
            // 
            // annotationsTabPage
            // 
            this.annotationsTabPage.Controls.Add(this.annotationsBinaryCheckBox);
            this.annotationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.annotationsTabPage.Name = "annotationsTabPage";
            this.annotationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.annotationsTabPage.Size = new System.Drawing.Size(342, 101);
            this.annotationsTabPage.TabIndex = 1;
            this.annotationsTabPage.Text = "Annotations Format";
            this.annotationsTabPage.UseVisualStyleBackColor = true;
            // 
            // annotationsBinaryCheckBox
            // 
            this.annotationsBinaryCheckBox.AutoSize = true;
            this.annotationsBinaryCheckBox.Location = new System.Drawing.Point(6, 6);
            this.annotationsBinaryCheckBox.Name = "annotationsBinaryCheckBox";
            this.annotationsBinaryCheckBox.Size = new System.Drawing.Size(99, 17);
            this.annotationsBinaryCheckBox.TabIndex = 12;
            this.annotationsBinaryCheckBox.Text = "Vintasoft Binary";
            this.annotationsBinaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // adam7InterlacingCheckBox
            // 
            this.adam7InterlacingCheckBox.AutoSize = true;
            this.adam7InterlacingCheckBox.Location = new System.Drawing.Point(6, 100);
            this.adam7InterlacingCheckBox.Name = "adam7InterlacingCheckBox";
            this.adam7InterlacingCheckBox.Size = new System.Drawing.Size(110, 17);
            this.adam7InterlacingCheckBox.TabIndex = 12;
            this.adam7InterlacingCheckBox.Text = "Adam7 Interlace";
            this.adam7InterlacingCheckBox.UseVisualStyleBackColor = true;
            // 
            // PngEncoderSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(365, 196);
            this.Controls.Add(this.settingsTabControl);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PngEncoderSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PNG Encoder Settings";
            this.customGroupBox.ResumeLayout(false);
            this.customGroupBox.PerformLayout();
            this.settingsTabControl.ResumeLayout(false);
            this.compressionTabPage.ResumeLayout(false);
            this.compressionTabPage.PerformLayout();
            this.annotationsTabPage.ResumeLayout(false);
            this.annotationsTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox customGroupBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ComboBox filterMethodComboBox;
        private System.Windows.Forms.ComboBox compressionLevelComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton customRadioButton;
        private System.Windows.Forms.RadioButton bestCompressionRadioButton;
        private System.Windows.Forms.RadioButton normalRadioButton;
        private System.Windows.Forms.RadioButton fastRadioButton;
        private System.Windows.Forms.RadioButton bestSpeedRadioButton;
        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage compressionTabPage;
        private System.Windows.Forms.TabPage annotationsTabPage;
        private System.Windows.Forms.CheckBox annotationsBinaryCheckBox;
        private System.Windows.Forms.CheckBox adam7InterlacingCheckBox;
    }
}