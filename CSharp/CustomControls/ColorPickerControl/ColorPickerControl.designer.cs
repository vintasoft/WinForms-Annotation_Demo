
namespace DemosCommonCode.CustomControls
{
    partial class ColorPickerControl
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
            this.lockRgbCheckBox = new System.Windows.Forms.CheckBox();
            this.colorSampleControl = new DemosCommonCode.CustomControls.ColorSampleControl();
            this.channelRedValueEditorControl = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.channelGreenValueEditorControl = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.channelBlueValueEditorControl = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.channelAlphaValueEditorControl = new DemosCommonCode.CustomControls.ValueEditorControl();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.hexValueTextBox = new System.Windows.Forms.TextBox();
            this.hexValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lockRgbCheckBox
            // 
            this.lockRgbCheckBox.AutoSize = true;
            this.lockRgbCheckBox.Location = new System.Drawing.Point(18, 330);
            this.lockRgbCheckBox.Name = "lockRgbCheckBox";
            this.lockRgbCheckBox.Size = new System.Drawing.Size(123, 17);
            this.lockRgbCheckBox.TabIndex = 30;
            this.lockRgbCheckBox.Text = "Lock RGB Channels";
            this.lockRgbCheckBox.UseVisualStyleBackColor = true;
            // 
            // colorSampleControl
            // 
            this.colorSampleControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSampleControl.Color = System.Drawing.Color.Transparent;
            this.colorSampleControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorSampleControl.Location = new System.Drawing.Point(285, 327);
            this.colorSampleControl.Name = "colorSampleControl";
            this.colorSampleControl.Size = new System.Drawing.Size(73, 21);
            this.colorSampleControl.TabIndex = 41;
            this.colorSampleControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorSampleControl_MouseClick);
            // 
            // channelRedValueEditorControl
            // 
            this.channelRedValueEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelRedValueEditorControl.Location = new System.Drawing.Point(3, 0);
            this.channelRedValueEditorControl.MaxValue = 255F;
            this.channelRedValueEditorControl.Name = "channelRedValueEditorControl";
            this.channelRedValueEditorControl.Size = new System.Drawing.Size(364, 76);
            this.channelRedValueEditorControl.TabIndex = 42;
            this.channelRedValueEditorControl.ValueName = "Red";
            this.channelRedValueEditorControl.ValueUnitOfMeasure = "";
            this.channelRedValueEditorControl.ValueChanged += new System.EventHandler(this.channelValueEditorControl_ValueChanged);
            // 
            // channelGreenValueEditorControl
            // 
            this.channelGreenValueEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelGreenValueEditorControl.Location = new System.Drawing.Point(3, 82);
            this.channelGreenValueEditorControl.MaxValue = 255F;
            this.channelGreenValueEditorControl.Name = "channelGreenValueEditorControl";
            this.channelGreenValueEditorControl.Size = new System.Drawing.Size(364, 76);
            this.channelGreenValueEditorControl.TabIndex = 43;
            this.channelGreenValueEditorControl.ValueName = "Green";
            this.channelGreenValueEditorControl.ValueUnitOfMeasure = "";
            this.channelGreenValueEditorControl.ValueChanged += new System.EventHandler(this.channelValueEditorControl_ValueChanged);
            // 
            // channelBlueValueEditorControl
            // 
            this.channelBlueValueEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelBlueValueEditorControl.Location = new System.Drawing.Point(3, 164);
            this.channelBlueValueEditorControl.MaxValue = 255F;
            this.channelBlueValueEditorControl.Name = "channelBlueValueEditorControl";
            this.channelBlueValueEditorControl.Size = new System.Drawing.Size(364, 76);
            this.channelBlueValueEditorControl.TabIndex = 44;
            this.channelBlueValueEditorControl.ValueName = "Blue";
            this.channelBlueValueEditorControl.ValueUnitOfMeasure = "";
            this.channelBlueValueEditorControl.ValueChanged += new System.EventHandler(this.channelValueEditorControl_ValueChanged);
            // 
            // channelAlphaValueEditorControl
            // 
            this.channelAlphaValueEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelAlphaValueEditorControl.Location = new System.Drawing.Point(3, 246);
            this.channelAlphaValueEditorControl.MaxValue = 255F;
            this.channelAlphaValueEditorControl.Name = "channelAlphaValueEditorControl";
            this.channelAlphaValueEditorControl.Size = new System.Drawing.Size(364, 76);
            this.channelAlphaValueEditorControl.TabIndex = 45;
            this.channelAlphaValueEditorControl.ValueName = "Alpha";
            this.channelAlphaValueEditorControl.ValueUnitOfMeasure = "";
            this.channelAlphaValueEditorControl.ValueChanged += new System.EventHandler(this.channelValueEditorControl_ValueChanged);
            // 
            // hexValueTextBox
            // 
            this.hexValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hexValueTextBox.Location = new System.Drawing.Point(206, 328);
            this.hexValueTextBox.MaxLength = 8;
            this.hexValueTextBox.Name = "hexValueTextBox";
            this.hexValueTextBox.Size = new System.Drawing.Size(73, 20);
            this.hexValueTextBox.TabIndex = 48;
            this.hexValueTextBox.Text = "FFFFFFFF";
            this.hexValueTextBox.WordWrap = false;
            this.hexValueTextBox.TextChanged += new System.EventHandler(this.hexValueTextBox_TextChanged);
            this.hexValueTextBox.Leave += new System.EventHandler(this.hexValueTextBox_Leave);
            // 
            // hexValueLabel
            // 
            this.hexValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hexValueLabel.Location = new System.Drawing.Point(136, 326);
            this.hexValueLabel.Name = "hexValueLabel";
            this.hexValueLabel.Size = new System.Drawing.Size(70, 22);
            this.hexValueLabel.TabIndex = 49;
            this.hexValueLabel.Text = "Hex (ARGB):";
            this.hexValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ColorPickerControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hexValueLabel);
            this.Controls.Add(this.hexValueTextBox);
            this.Controls.Add(this.channelAlphaValueEditorControl);
            this.Controls.Add(this.channelBlueValueEditorControl);
            this.Controls.Add(this.channelGreenValueEditorControl);
            this.Controls.Add(this.channelRedValueEditorControl);
            this.Controls.Add(this.colorSampleControl);
            this.Controls.Add(this.lockRgbCheckBox);
            this.MinimumSize = new System.Drawing.Size(370, 353);
            this.Name = "ColorPickerControl";
            this.Size = new System.Drawing.Size(370, 353);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox lockRgbCheckBox;
        private ColorSampleControl colorSampleControl;
        private ValueEditorControl channelRedValueEditorControl;
        private ValueEditorControl channelGreenValueEditorControl;
        private ValueEditorControl channelBlueValueEditorControl;
        private ValueEditorControl channelAlphaValueEditorControl;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TextBox hexValueTextBox;
        private System.Windows.Forms.Label hexValueLabel;
    }
}