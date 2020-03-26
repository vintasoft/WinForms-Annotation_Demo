namespace DemosCommonCode.CustomControls
{
    partial class AnchorTypeEditorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topLeftRadioButton = new System.Windows.Forms.RadioButton();
            this.topRadioButton = new System.Windows.Forms.RadioButton();
            this.topRightRadioButton = new System.Windows.Forms.RadioButton();
            this.leftRadioButton = new System.Windows.Forms.RadioButton();
            this.centerRadioButton = new System.Windows.Forms.RadioButton();
            this.rightRadioButton = new System.Windows.Forms.RadioButton();
            this.bottomLeftRadioButton = new System.Windows.Forms.RadioButton();
            this.bottomRadioButton = new System.Windows.Forms.RadioButton();
            this.bottomRightRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // topLeftRadioButton
            // 
            this.topLeftRadioButton.Location = new System.Drawing.Point(6, 6);
            this.topLeftRadioButton.Name = "topLeftRadioButton";
            this.topLeftRadioButton.Size = new System.Drawing.Size(13, 13);
            this.topLeftRadioButton.TabIndex = 0;
            this.topLeftRadioButton.UseVisualStyleBackColor = true;
            this.topLeftRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // topRadioButton
            // 
            this.topRadioButton.Location = new System.Drawing.Point(25, 6);
            this.topRadioButton.Name = "topRadioButton";
            this.topRadioButton.Size = new System.Drawing.Size(13, 13);
            this.topRadioButton.TabIndex = 0;
            this.topRadioButton.UseVisualStyleBackColor = true;
            this.topRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // topRightRadioButton
            // 
            this.topRightRadioButton.Location = new System.Drawing.Point(44, 6);
            this.topRightRadioButton.Name = "topRightRadioButton";
            this.topRightRadioButton.Size = new System.Drawing.Size(13, 13);
            this.topRightRadioButton.TabIndex = 0;
            this.topRightRadioButton.UseVisualStyleBackColor = true;
            this.topRightRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // leftRadioButton
            // 
            this.leftRadioButton.Location = new System.Drawing.Point(6, 25);
            this.leftRadioButton.Name = "leftRadioButton";
            this.leftRadioButton.Size = new System.Drawing.Size(13, 13);
            this.leftRadioButton.TabIndex = 0;
            this.leftRadioButton.UseVisualStyleBackColor = true;
            this.leftRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // centerRadioButton
            // 
            this.centerRadioButton.Checked = true;
            this.centerRadioButton.Location = new System.Drawing.Point(25, 25);
            this.centerRadioButton.Name = "centerRadioButton";
            this.centerRadioButton.Size = new System.Drawing.Size(13, 13);
            this.centerRadioButton.TabIndex = 0;
            this.centerRadioButton.TabStop = true;
            this.centerRadioButton.UseVisualStyleBackColor = true;
            this.centerRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rightRadioButton
            // 
            this.rightRadioButton.Location = new System.Drawing.Point(44, 25);
            this.rightRadioButton.Name = "rightRadioButton";
            this.rightRadioButton.Size = new System.Drawing.Size(13, 13);
            this.rightRadioButton.TabIndex = 0;
            this.rightRadioButton.UseVisualStyleBackColor = true;
            this.rightRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // bottomLeftRadioButton
            // 
            this.bottomLeftRadioButton.Location = new System.Drawing.Point(6, 44);
            this.bottomLeftRadioButton.Name = "bottomLeftRadioButton";
            this.bottomLeftRadioButton.Size = new System.Drawing.Size(13, 13);
            this.bottomLeftRadioButton.TabIndex = 0;
            this.bottomLeftRadioButton.UseVisualStyleBackColor = true;
            this.bottomLeftRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // bottomRadioButton
            // 
            this.bottomRadioButton.Location = new System.Drawing.Point(25, 44);
            this.bottomRadioButton.Name = "bottomRadioButton";
            this.bottomRadioButton.Size = new System.Drawing.Size(13, 13);
            this.bottomRadioButton.TabIndex = 0;
            this.bottomRadioButton.UseVisualStyleBackColor = true;
            this.bottomRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // bottomRightRadioButton
            // 
            this.bottomRightRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.bottomRightRadioButton.Location = new System.Drawing.Point(44, 44);
            this.bottomRightRadioButton.Name = "bottomRightRadioButton";
            this.bottomRightRadioButton.Size = new System.Drawing.Size(13, 13);
            this.bottomRightRadioButton.TabIndex = 0;
            this.bottomRightRadioButton.UseVisualStyleBackColor = false;
            this.bottomRightRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // AnchorTypeEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bottomRightRadioButton);
            this.Controls.Add(this.rightRadioButton);
            this.Controls.Add(this.topRightRadioButton);
            this.Controls.Add(this.bottomRadioButton);
            this.Controls.Add(this.centerRadioButton);
            this.Controls.Add(this.topRadioButton);
            this.Controls.Add(this.bottomLeftRadioButton);
            this.Controls.Add(this.leftRadioButton);
            this.Controls.Add(this.topLeftRadioButton);
            this.Name = "AnchorTypeEditorControl";
            this.Size = new System.Drawing.Size(63, 63);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton topLeftRadioButton;
        private System.Windows.Forms.RadioButton topRadioButton;
        private System.Windows.Forms.RadioButton topRightRadioButton;
        private System.Windows.Forms.RadioButton leftRadioButton;
        private System.Windows.Forms.RadioButton centerRadioButton;
        private System.Windows.Forms.RadioButton rightRadioButton;
        private System.Windows.Forms.RadioButton bottomLeftRadioButton;
        private System.Windows.Forms.RadioButton bottomRadioButton;
        private System.Windows.Forms.RadioButton bottomRightRadioButton;
    }
}