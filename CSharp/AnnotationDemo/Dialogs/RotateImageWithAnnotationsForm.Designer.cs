namespace AnnotationDemo
{
	partial class RotateImageWithAnnotationsForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.angleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.angleLabel = new System.Windows.Forms.Label();
            this.blackBackgroundRadioButton = new System.Windows.Forms.RadioButton();
            this.whiteBackgroundRadioButton = new System.Windows.Forms.RadioButton();
            this.autoDetectBackgroundRadioButton = new System.Windows.Forms.RadioButton();
            this.backgroundColorGroupBox = new System.Windows.Forms.GroupBox();
            this.transparentBackgroundRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).BeginInit();
            this.backgroundColorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(36, 118);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(117, 118);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // angleNumericUpDown
            // 
            this.angleNumericUpDown.Location = new System.Drawing.Point(94, 12);
            this.angleNumericUpDown.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.angleNumericUpDown.Minimum = new decimal(new int[] {
            359,
            0,
            0,
            -2147483648});
            this.angleNumericUpDown.Name = "angleNumericUpDown";
            this.angleNumericUpDown.Size = new System.Drawing.Size(84, 20);
            this.angleNumericUpDown.TabIndex = 0;
            this.angleNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // angleLabel
            // 
            this.angleLabel.AutoSize = true;
            this.angleLabel.Location = new System.Drawing.Point(50, 14);
            this.angleLabel.Name = "angleLabel";
            this.angleLabel.Size = new System.Drawing.Size(37, 13);
            this.angleLabel.TabIndex = 3;
            this.angleLabel.Text = "Angle:";
            // 
            // blackBackgroundRadioButton
            // 
            this.blackBackgroundRadioButton.AutoSize = true;
            this.blackBackgroundRadioButton.Location = new System.Drawing.Point(17, 19);
            this.blackBackgroundRadioButton.Name = "blackBackgroundRadioButton";
            this.blackBackgroundRadioButton.Size = new System.Drawing.Size(52, 17);
            this.blackBackgroundRadioButton.TabIndex = 4;
            this.blackBackgroundRadioButton.Text = "Black";
            this.blackBackgroundRadioButton.UseVisualStyleBackColor = true;
            // 
            // whiteBackgroundRadioButton
            // 
            this.whiteBackgroundRadioButton.AutoSize = true;
            this.whiteBackgroundRadioButton.Checked = true;
            this.whiteBackgroundRadioButton.Location = new System.Drawing.Point(110, 19);
            this.whiteBackgroundRadioButton.Name = "whiteBackgroundRadioButton";
            this.whiteBackgroundRadioButton.Size = new System.Drawing.Size(53, 17);
            this.whiteBackgroundRadioButton.TabIndex = 5;
            this.whiteBackgroundRadioButton.TabStop = true;
            this.whiteBackgroundRadioButton.Text = "White";
            this.whiteBackgroundRadioButton.UseVisualStyleBackColor = true;
            // 
            // autoDetectBackgroundRadioButton
            // 
            this.autoDetectBackgroundRadioButton.AutoSize = true;
            this.autoDetectBackgroundRadioButton.Location = new System.Drawing.Point(110, 42);
            this.autoDetectBackgroundRadioButton.Name = "autoDetectBackgroundRadioButton";
            this.autoDetectBackgroundRadioButton.Size = new System.Drawing.Size(80, 17);
            this.autoDetectBackgroundRadioButton.TabIndex = 6;
            this.autoDetectBackgroundRadioButton.Text = "Auto detect";
            this.autoDetectBackgroundRadioButton.UseVisualStyleBackColor = true;
            // 
            // backgroundColorGroupBox
            // 
            this.backgroundColorGroupBox.Controls.Add(this.transparentBackgroundRadioButton);
            this.backgroundColorGroupBox.Controls.Add(this.blackBackgroundRadioButton);
            this.backgroundColorGroupBox.Controls.Add(this.autoDetectBackgroundRadioButton);
            this.backgroundColorGroupBox.Controls.Add(this.whiteBackgroundRadioButton);
            this.backgroundColorGroupBox.Location = new System.Drawing.Point(15, 38);
            this.backgroundColorGroupBox.Name = "backgroundColorGroupBox";
            this.backgroundColorGroupBox.Size = new System.Drawing.Size(198, 69);
            this.backgroundColorGroupBox.TabIndex = 7;
            this.backgroundColorGroupBox.TabStop = false;
            this.backgroundColorGroupBox.Text = "Background color";
            // 
            // transparentBackgroundRadioButton
            // 
            this.transparentBackgroundRadioButton.AutoSize = true;
            this.transparentBackgroundRadioButton.Location = new System.Drawing.Point(16, 42);
            this.transparentBackgroundRadioButton.Name = "transparentBackgroundRadioButton";
            this.transparentBackgroundRadioButton.Size = new System.Drawing.Size(82, 17);
            this.transparentBackgroundRadioButton.TabIndex = 7;
            this.transparentBackgroundRadioButton.Text = "Transparent";
            this.transparentBackgroundRadioButton.UseVisualStyleBackColor = true;
            // 
            // RotateImageWithAnnotationsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(229, 153);
            this.Controls.Add(this.backgroundColorGroupBox);
            this.Controls.Add(this.angleLabel);
            this.Controls.Add(this.angleNumericUpDown);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotateImageWithAnnotationsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rotate image with annotations";
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).EndInit();
            this.backgroundColorGroupBox.ResumeLayout(false);
            this.backgroundColorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label angleLabel;
		private System.Windows.Forms.NumericUpDown angleNumericUpDown;
		private System.Windows.Forms.RadioButton blackBackgroundRadioButton;
		private System.Windows.Forms.RadioButton whiteBackgroundRadioButton;
		private System.Windows.Forms.RadioButton autoDetectBackgroundRadioButton;
		private System.Windows.Forms.GroupBox backgroundColorGroupBox;
        private System.Windows.Forms.RadioButton transparentBackgroundRadioButton;
	}
}