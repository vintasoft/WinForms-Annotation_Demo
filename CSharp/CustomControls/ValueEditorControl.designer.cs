namespace DemosCommonCode.CustomControls
{
    partial class ValueEditorControl
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
            this.valueGroupBox = new System.Windows.Forms.GroupBox();
            this.maxValueLabel = new System.Windows.Forms.Label();
            this.minValueLabel = new System.Windows.Forms.Label();
            this.valueTrackBar = new System.Windows.Forms.TrackBar();
            this.resetButton = new System.Windows.Forms.Button();
            this.valueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.valueGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // valueGroupBox
            // 
            this.valueGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.valueGroupBox.Controls.Add(this.maxValueLabel);
            this.valueGroupBox.Controls.Add(this.minValueLabel);
            this.valueGroupBox.Controls.Add(this.valueTrackBar);
            this.valueGroupBox.Controls.Add(this.resetButton);
            this.valueGroupBox.Controls.Add(this.valueNumericUpDown);
            this.valueGroupBox.Location = new System.Drawing.Point(3, 3);
            this.valueGroupBox.Name = "valueGroupBox";
            this.valueGroupBox.Size = new System.Drawing.Size(329, 71);
            this.valueGroupBox.TabIndex = 0;
            this.valueGroupBox.TabStop = false;
            this.valueGroupBox.Text = "groupBox";
            // 
            // maxValueLabel
            // 
            this.maxValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.maxValueLabel.AutoSize = true;
            this.maxValueLabel.Location = new System.Drawing.Point(210, 43);
            this.maxValueLabel.Name = "maxValueLabel";
            this.maxValueLabel.Size = new System.Drawing.Size(25, 13);
            this.maxValueLabel.TabIndex = 57;
            this.maxValueLabel.Text = "100";
            // 
            // minValueLabel
            // 
            this.minValueLabel.AutoSize = true;
            this.minValueLabel.Location = new System.Drawing.Point(8, 43);
            this.minValueLabel.Name = "minValueLabel";
            this.minValueLabel.Size = new System.Drawing.Size(13, 13);
            this.minValueLabel.TabIndex = 56;
            this.minValueLabel.Text = "0";
            // 
            // valueTrackBar
            // 
            this.valueTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTrackBar.LargeChange = 2;
            this.valueTrackBar.Location = new System.Drawing.Point(6, 14);
            this.valueTrackBar.Maximum = 100;
            this.valueTrackBar.Name = "valueTrackBar";
            this.valueTrackBar.Size = new System.Drawing.Size(236, 45);
            this.valueTrackBar.TabIndex = 55;
            this.valueTrackBar.TickFrequency = 5;
            this.valueTrackBar.Scroll += new System.EventHandler(this.valueTrackBar_Scroll);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(250, 38);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 22);
            this.resetButton.TabIndex = 54;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // valueNumericUpDown
            // 
            this.valueNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueNumericUpDown.AutoSize = true;
            this.valueNumericUpDown.Location = new System.Drawing.Point(250, 12);
            this.valueNumericUpDown.Name = "valueNumericUpDown";
            this.valueNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.valueNumericUpDown.TabIndex = 53;
            this.valueNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valueNumericUpDown.ValueChanged += new System.EventHandler(this.valueNumericUpDown_ValueChanged);
            // 
            // ValueEditorControl
            // 
            this.Controls.Add(this.valueGroupBox);
            this.Name = "ValueEditorControl";
            this.Size = new System.Drawing.Size(335, 76);
            this.valueGroupBox.ResumeLayout(false);
            this.valueGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox valueGroupBox;
        private System.Windows.Forms.Label maxValueLabel;
        private System.Windows.Forms.Label minValueLabel;
        private System.Windows.Forms.TrackBar valueTrackBar;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.NumericUpDown valueNumericUpDown;
    }
}
