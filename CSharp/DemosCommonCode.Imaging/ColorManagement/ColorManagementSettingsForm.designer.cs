namespace DemosCommonCode.Imaging.ColorManagement
{
    partial class ColorManagementSettingsForm
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
            this.inputProfilesGroupBox = new System.Windows.Forms.GroupBox();
            this.removeInputGrayscaleButton = new System.Windows.Forms.Button();
            this.removeInputRgbButton = new System.Windows.Forms.Button();
            this.removeInputCmykButton = new System.Windows.Forms.Button();
            this.inputGrayscaleTextBox = new System.Windows.Forms.TextBox();
            this.useEmbeddedProfilesCheckBox = new System.Windows.Forms.CheckBox();
            this.inputRgbTextBox = new System.Windows.Forms.TextBox();
            this.inputCmykTextBox = new System.Windows.Forms.TextBox();
            this.inputGrayscaleLabel = new System.Windows.Forms.Label();
            this.inputRgbLabel = new System.Windows.Forms.Label();
            this.inputCmykLabel = new System.Windows.Forms.Label();
            this.setInputProfileButton = new System.Windows.Forms.Button();
            this.editColorTransformsButton = new System.Windows.Forms.Button();
            this.enableColorManagementCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.outputProfilesGroupBox = new System.Windows.Forms.GroupBox();
            this.removeOutputGrayscaleButton = new System.Windows.Forms.Button();
            this.removeOutputRgbButton = new System.Windows.Forms.Button();
            this.outputGrayscaleTextBox = new System.Windows.Forms.TextBox();
            this.outputRgbTextBox = new System.Windows.Forms.TextBox();
            this.outputGrayscaleLabel = new System.Windows.Forms.Label();
            this.outputRgbLabel = new System.Windows.Forms.Label();
            this.setOutputProfileButton = new System.Windows.Forms.Button();
            this.intentComboBox = new System.Windows.Forms.ComboBox();
            this.intentLabel = new System.Windows.Forms.Label();
            this.blackPointCompensationCheckBox = new System.Windows.Forms.CheckBox();
            this.decodingSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inputProfilesGroupBox.SuspendLayout();
            this.outputProfilesGroupBox.SuspendLayout();
            this.decodingSettingsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputProfilesGroupBox
            // 
            this.inputProfilesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputProfilesGroupBox.Controls.Add(this.removeInputGrayscaleButton);
            this.inputProfilesGroupBox.Controls.Add(this.removeInputRgbButton);
            this.inputProfilesGroupBox.Controls.Add(this.removeInputCmykButton);
            this.inputProfilesGroupBox.Controls.Add(this.inputGrayscaleTextBox);
            this.inputProfilesGroupBox.Controls.Add(this.useEmbeddedProfilesCheckBox);
            this.inputProfilesGroupBox.Controls.Add(this.inputRgbTextBox);
            this.inputProfilesGroupBox.Controls.Add(this.inputCmykTextBox);
            this.inputProfilesGroupBox.Controls.Add(this.inputGrayscaleLabel);
            this.inputProfilesGroupBox.Controls.Add(this.inputRgbLabel);
            this.inputProfilesGroupBox.Controls.Add(this.inputCmykLabel);
            this.inputProfilesGroupBox.Controls.Add(this.setInputProfileButton);
            this.inputProfilesGroupBox.Location = new System.Drawing.Point(6, 19);
            this.inputProfilesGroupBox.Name = "inputProfilesGroupBox";
            this.inputProfilesGroupBox.Size = new System.Drawing.Size(565, 121);
            this.inputProfilesGroupBox.TabIndex = 0;
            this.inputProfilesGroupBox.TabStop = false;
            this.inputProfilesGroupBox.Text = "Input color profiles (to PCSXYZ)";
            // 
            // removeInputGrayscaleButton
            // 
            this.removeInputGrayscaleButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeInputGrayscaleButton.Location = new System.Drawing.Point(539, 95);
            this.removeInputGrayscaleButton.Name = "removeInputGrayscaleButton";
            this.removeInputGrayscaleButton.Size = new System.Drawing.Size(20, 20);
            this.removeInputGrayscaleButton.TabIndex = 14;
            this.removeInputGrayscaleButton.Text = "X";
            this.removeInputGrayscaleButton.UseVisualStyleBackColor = true;
            this.removeInputGrayscaleButton.Click += new System.EventHandler(this.removeInputGrayscaleButton_Click);
            // 
            // removeInputRgbButton
            // 
            this.removeInputRgbButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeInputRgbButton.Location = new System.Drawing.Point(539, 72);
            this.removeInputRgbButton.Name = "removeInputRgbButton";
            this.removeInputRgbButton.Size = new System.Drawing.Size(20, 20);
            this.removeInputRgbButton.TabIndex = 13;
            this.removeInputRgbButton.Text = "X";
            this.removeInputRgbButton.UseVisualStyleBackColor = true;
            this.removeInputRgbButton.Click += new System.EventHandler(this.removeInputRgbButton_Click);
            // 
            // removeInputCmykButton
            // 
            this.removeInputCmykButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeInputCmykButton.Location = new System.Drawing.Point(539, 49);
            this.removeInputCmykButton.Name = "removeInputCmykButton";
            this.removeInputCmykButton.Size = new System.Drawing.Size(20, 20);
            this.removeInputCmykButton.TabIndex = 12;
            this.removeInputCmykButton.Text = "X";
            this.removeInputCmykButton.UseVisualStyleBackColor = true;
            this.removeInputCmykButton.Click += new System.EventHandler(this.removeInputCmykButton_Click);
            // 
            // inputGrayscaleTextBox
            // 
            this.inputGrayscaleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputGrayscaleTextBox.Location = new System.Drawing.Point(97, 95);
            this.inputGrayscaleTextBox.Name = "inputGrayscaleTextBox";
            this.inputGrayscaleTextBox.ReadOnly = true;
            this.inputGrayscaleTextBox.Size = new System.Drawing.Size(436, 23);
            this.inputGrayscaleTextBox.TabIndex = 11;
            // 
            // useEmbeddedProfilesCheckBox
            // 
            this.useEmbeddedProfilesCheckBox.AutoSize = true;
            this.useEmbeddedProfilesCheckBox.Location = new System.Drawing.Point(264, 24);
            this.useEmbeddedProfilesCheckBox.Name = "useEmbeddedProfilesCheckBox";
            this.useEmbeddedProfilesCheckBox.Size = new System.Drawing.Size(173, 19);
            this.useEmbeddedProfilesCheckBox.TabIndex = 5;
            this.useEmbeddedProfilesCheckBox.Text = "Use embedded input profile";
            this.useEmbeddedProfilesCheckBox.UseVisualStyleBackColor = true;
            // 
            // inputRgbTextBox
            // 
            this.inputRgbTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputRgbTextBox.Location = new System.Drawing.Point(97, 72);
            this.inputRgbTextBox.Name = "inputRgbTextBox";
            this.inputRgbTextBox.ReadOnly = true;
            this.inputRgbTextBox.Size = new System.Drawing.Size(436, 23);
            this.inputRgbTextBox.TabIndex = 10;
            // 
            // inputCmykTextBox
            // 
            this.inputCmykTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputCmykTextBox.Location = new System.Drawing.Point(97, 49);
            this.inputCmykTextBox.Name = "inputCmykTextBox";
            this.inputCmykTextBox.ReadOnly = true;
            this.inputCmykTextBox.Size = new System.Drawing.Size(436, 23);
            this.inputCmykTextBox.TabIndex = 9;
            // 
            // inputGrayscaleLabel
            // 
            this.inputGrayscaleLabel.AutoSize = true;
            this.inputGrayscaleLabel.Location = new System.Drawing.Point(7, 98);
            this.inputGrayscaleLabel.Name = "inputGrayscaleLabel";
            this.inputGrayscaleLabel.Size = new System.Drawing.Size(57, 15);
            this.inputGrayscaleLabel.TabIndex = 8;
            this.inputGrayscaleLabel.Text = "Grayscale";
            // 
            // inputRgbLabel
            // 
            this.inputRgbLabel.AutoSize = true;
            this.inputRgbLabel.Location = new System.Drawing.Point(7, 75);
            this.inputRgbLabel.Name = "inputRgbLabel";
            this.inputRgbLabel.Size = new System.Drawing.Size(29, 15);
            this.inputRgbLabel.TabIndex = 7;
            this.inputRgbLabel.Text = "RGB";
            // 
            // inputCmykLabel
            // 
            this.inputCmykLabel.AutoSize = true;
            this.inputCmykLabel.Location = new System.Drawing.Point(7, 52);
            this.inputCmykLabel.Name = "inputCmykLabel";
            this.inputCmykLabel.Size = new System.Drawing.Size(40, 15);
            this.inputCmykLabel.TabIndex = 6;
            this.inputCmykLabel.Text = "CMYK";
            // 
            // setInputProfileButton
            // 
            this.setInputProfileButton.Location = new System.Drawing.Point(97, 20);
            this.setInputProfileButton.Name = "setInputProfileButton";
            this.setInputProfileButton.Size = new System.Drawing.Size(158, 23);
            this.setInputProfileButton.TabIndex = 4;
            this.setInputProfileButton.Text = "Set input profile...";
            this.setInputProfileButton.UseVisualStyleBackColor = true;
            this.setInputProfileButton.Click += new System.EventHandler(this.setInputProfileButton_Click);
            // 
            // editColorTransformsButton
            // 
            this.editColorTransformsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editColorTransformsButton.Location = new System.Drawing.Point(6, 20);
            this.editColorTransformsButton.Name = "editColorTransformsButton";
            this.editColorTransformsButton.Size = new System.Drawing.Size(188, 23);
            this.editColorTransformsButton.TabIndex = 3;
            this.editColorTransformsButton.Text = "Edit color transforms...";
            this.editColorTransformsButton.UseVisualStyleBackColor = true;
            this.editColorTransformsButton.Click += new System.EventHandler(this.editColorTransformsButton_Click);
            // 
            // enableColorManagementCheckBox
            // 
            this.enableColorManagementCheckBox.AutoSize = true;
            this.enableColorManagementCheckBox.Location = new System.Drawing.Point(9, 6);
            this.enableColorManagementCheckBox.Name = "enableColorManagementCheckBox";
            this.enableColorManagementCheckBox.Size = new System.Drawing.Size(165, 19);
            this.enableColorManagementCheckBox.TabIndex = 0;
            this.enableColorManagementCheckBox.Text = "Enable color management";
            this.enableColorManagementCheckBox.UseVisualStyleBackColor = true;
            this.enableColorManagementCheckBox.CheckedChanged += new System.EventHandler(this.enableColorManagementCheckBox_CheckedChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(221, 348);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(305, 348);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // outputProfilesGroupBox
            // 
            this.outputProfilesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputProfilesGroupBox.Controls.Add(this.removeOutputGrayscaleButton);
            this.outputProfilesGroupBox.Controls.Add(this.removeOutputRgbButton);
            this.outputProfilesGroupBox.Controls.Add(this.outputGrayscaleTextBox);
            this.outputProfilesGroupBox.Controls.Add(this.outputRgbTextBox);
            this.outputProfilesGroupBox.Controls.Add(this.outputGrayscaleLabel);
            this.outputProfilesGroupBox.Controls.Add(this.outputRgbLabel);
            this.outputProfilesGroupBox.Controls.Add(this.setOutputProfileButton);
            this.outputProfilesGroupBox.Location = new System.Drawing.Point(6, 146);
            this.outputProfilesGroupBox.Name = "outputProfilesGroupBox";
            this.outputProfilesGroupBox.Size = new System.Drawing.Size(565, 96);
            this.outputProfilesGroupBox.TabIndex = 12;
            this.outputProfilesGroupBox.TabStop = false;
            this.outputProfilesGroupBox.Text = "Output color profiles (from PCSXYZ)";
            // 
            // removeOutputGrayscaleButton
            // 
            this.removeOutputGrayscaleButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeOutputGrayscaleButton.Location = new System.Drawing.Point(539, 69);
            this.removeOutputGrayscaleButton.Name = "removeOutputGrayscaleButton";
            this.removeOutputGrayscaleButton.Size = new System.Drawing.Size(20, 20);
            this.removeOutputGrayscaleButton.TabIndex = 16;
            this.removeOutputGrayscaleButton.Text = "X";
            this.removeOutputGrayscaleButton.UseVisualStyleBackColor = true;
            this.removeOutputGrayscaleButton.Click += new System.EventHandler(this.removeOutputGrayscaleButton_Click);
            // 
            // removeOutputRgbButton
            // 
            this.removeOutputRgbButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeOutputRgbButton.Location = new System.Drawing.Point(539, 46);
            this.removeOutputRgbButton.Name = "removeOutputRgbButton";
            this.removeOutputRgbButton.Size = new System.Drawing.Size(20, 20);
            this.removeOutputRgbButton.TabIndex = 15;
            this.removeOutputRgbButton.Text = "X";
            this.removeOutputRgbButton.UseVisualStyleBackColor = true;
            this.removeOutputRgbButton.Click += new System.EventHandler(this.removeOutputRgbButton_Click);
            // 
            // outputGrayscaleTextBox
            // 
            this.outputGrayscaleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputGrayscaleTextBox.Location = new System.Drawing.Point(97, 69);
            this.outputGrayscaleTextBox.Name = "outputGrayscaleTextBox";
            this.outputGrayscaleTextBox.ReadOnly = true;
            this.outputGrayscaleTextBox.Size = new System.Drawing.Size(436, 23);
            this.outputGrayscaleTextBox.TabIndex = 11;
            // 
            // outputRgbTextBox
            // 
            this.outputRgbTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputRgbTextBox.Location = new System.Drawing.Point(97, 46);
            this.outputRgbTextBox.Name = "outputRgbTextBox";
            this.outputRgbTextBox.ReadOnly = true;
            this.outputRgbTextBox.Size = new System.Drawing.Size(436, 23);
            this.outputRgbTextBox.TabIndex = 10;
            // 
            // outputGrayscaleLabel
            // 
            this.outputGrayscaleLabel.AutoSize = true;
            this.outputGrayscaleLabel.Location = new System.Drawing.Point(7, 71);
            this.outputGrayscaleLabel.Name = "outputGrayscaleLabel";
            this.outputGrayscaleLabel.Size = new System.Drawing.Size(57, 15);
            this.outputGrayscaleLabel.TabIndex = 8;
            this.outputGrayscaleLabel.Text = "Grayscale";
            // 
            // outputRgbLabel
            // 
            this.outputRgbLabel.AutoSize = true;
            this.outputRgbLabel.Location = new System.Drawing.Point(7, 48);
            this.outputRgbLabel.Name = "outputRgbLabel";
            this.outputRgbLabel.Size = new System.Drawing.Size(29, 15);
            this.outputRgbLabel.TabIndex = 7;
            this.outputRgbLabel.Text = "RGB";
            // 
            // setOutputProfileButton
            // 
            this.setOutputProfileButton.Location = new System.Drawing.Point(96, 19);
            this.setOutputProfileButton.Name = "setOutputProfileButton";
            this.setOutputProfileButton.Size = new System.Drawing.Size(157, 23);
            this.setOutputProfileButton.TabIndex = 4;
            this.setOutputProfileButton.Text = "Set output profile...";
            this.setOutputProfileButton.UseVisualStyleBackColor = true;
            this.setOutputProfileButton.Click += new System.EventHandler(this.setOutputProfileButton_Click);
            // 
            // intentComboBox
            // 
            this.intentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intentComboBox.FormattingEnabled = true;
            this.intentComboBox.Location = new System.Drawing.Point(112, 248);
            this.intentComboBox.Name = "intentComboBox";
            this.intentComboBox.Size = new System.Drawing.Size(156, 23);
            this.intentComboBox.TabIndex = 13;
            // 
            // intentLabel
            // 
            this.intentLabel.AutoSize = true;
            this.intentLabel.Location = new System.Drawing.Point(11, 256);
            this.intentLabel.Name = "intentLabel";
            this.intentLabel.Size = new System.Drawing.Size(95, 15);
            this.intentLabel.TabIndex = 14;
            this.intentLabel.Text = "Rendering intent";
            // 
            // blackPointCompensationCheckBox
            // 
            this.blackPointCompensationCheckBox.AutoSize = true;
            this.blackPointCompensationCheckBox.Location = new System.Drawing.Point(14, 282);
            this.blackPointCompensationCheckBox.Name = "blackPointCompensationCheckBox";
            this.blackPointCompensationCheckBox.Size = new System.Drawing.Size(186, 19);
            this.blackPointCompensationCheckBox.TabIndex = 15;
            this.blackPointCompensationCheckBox.Text = "Use black point compensation";
            this.blackPointCompensationCheckBox.UseVisualStyleBackColor = true;
            // 
            // decodingSettingsGroupBox
            // 
            this.decodingSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.decodingSettingsGroupBox.Controls.Add(this.groupBox1);
            this.decodingSettingsGroupBox.Controls.Add(this.inputProfilesGroupBox);
            this.decodingSettingsGroupBox.Controls.Add(this.blackPointCompensationCheckBox);
            this.decodingSettingsGroupBox.Controls.Add(this.intentLabel);
            this.decodingSettingsGroupBox.Controls.Add(this.outputProfilesGroupBox);
            this.decodingSettingsGroupBox.Controls.Add(this.intentComboBox);
            this.decodingSettingsGroupBox.Enabled = false;
            this.decodingSettingsGroupBox.Location = new System.Drawing.Point(9, 29);
            this.decodingSettingsGroupBox.Name = "decodingSettingsGroupBox";
            this.decodingSettingsGroupBox.Size = new System.Drawing.Size(577, 312);
            this.decodingSettingsGroupBox.TabIndex = 16;
            this.decodingSettingsGroupBox.TabStop = false;
            this.decodingSettingsGroupBox.Text = "Color management decode settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.editColorTransformsButton);
            this.groupBox1.Location = new System.Drawing.Point(371, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 56);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced settings";
            // 
            // ColorManagementSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(598, 378);
            this.Controls.Add(this.decodingSettingsGroupBox);
            this.Controls.Add(this.enableColorManagementCheckBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorManagementSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color Management Settings";
            this.inputProfilesGroupBox.ResumeLayout(false);
            this.inputProfilesGroupBox.PerformLayout();
            this.outputProfilesGroupBox.ResumeLayout(false);
            this.outputProfilesGroupBox.PerformLayout();
            this.decodingSettingsGroupBox.ResumeLayout(false);
            this.decodingSettingsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox inputProfilesGroupBox;
        private System.Windows.Forms.CheckBox enableColorManagementCheckBox;
        private System.Windows.Forms.Button editColorTransformsButton;
        private System.Windows.Forms.Button setInputProfileButton;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox useEmbeddedProfilesCheckBox;
        private System.Windows.Forms.Label inputCmykLabel;
        private System.Windows.Forms.TextBox inputGrayscaleTextBox;
        private System.Windows.Forms.TextBox inputRgbTextBox;
        private System.Windows.Forms.TextBox inputCmykTextBox;
        private System.Windows.Forms.Label inputGrayscaleLabel;
        private System.Windows.Forms.Label inputRgbLabel;
        private System.Windows.Forms.GroupBox outputProfilesGroupBox;
        private System.Windows.Forms.TextBox outputGrayscaleTextBox;
        private System.Windows.Forms.TextBox outputRgbTextBox;
        private System.Windows.Forms.Label outputGrayscaleLabel;
        private System.Windows.Forms.Label outputRgbLabel;
        private System.Windows.Forms.Button setOutputProfileButton;
        private System.Windows.Forms.ComboBox intentComboBox;
        private System.Windows.Forms.Label intentLabel;
        private System.Windows.Forms.CheckBox blackPointCompensationCheckBox;
        private System.Windows.Forms.GroupBox decodingSettingsGroupBox;
        private System.Windows.Forms.Button removeInputCmykButton;
        private System.Windows.Forms.Button removeInputGrayscaleButton;
        private System.Windows.Forms.Button removeInputRgbButton;
        private System.Windows.Forms.Button removeOutputGrayscaleButton;
        private System.Windows.Forms.Button removeOutputRgbButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}