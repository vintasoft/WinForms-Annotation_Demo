namespace DemosCommonCode.Imaging
{
    partial class MagnifierToolSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.widthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.heightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.zoomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.borderColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.borderWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ellipticalOutlineCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grayscaleCheckBox = new System.Windows.Forms.CheckBox();
            this.oilPaintingCheckBox = new System.Windows.Forms.CheckBox();
            this.posterizeCheckBox = new System.Windows.Forms.CheckBox();
            this.invertCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.showVisualToolsCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Zoom";
            // 
            // widthNumericUpDown
            // 
            this.widthNumericUpDown.Location = new System.Drawing.Point(60, 6);
            this.widthNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.widthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumericUpDown.Name = "widthNumericUpDown";
            this.widthNumericUpDown.Size = new System.Drawing.Size(78, 23);
            this.widthNumericUpDown.TabIndex = 3;
            this.widthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // heightNumericUpDown
            // 
            this.heightNumericUpDown.Location = new System.Drawing.Point(60, 32);
            this.heightNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.heightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNumericUpDown.Name = "heightNumericUpDown";
            this.heightNumericUpDown.Size = new System.Drawing.Size(78, 23);
            this.heightNumericUpDown.TabIndex = 4;
            this.heightNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // zoomNumericUpDown
            // 
            this.zoomNumericUpDown.Location = new System.Drawing.Point(60, 58);
            this.zoomNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.zoomNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.zoomNumericUpDown.Name = "zoomNumericUpDown";
            this.zoomNumericUpDown.Size = new System.Drawing.Size(78, 23);
            this.zoomNumericUpDown.TabIndex = 5;
            this.zoomNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.borderColorPanelControl);
            this.groupBox1.Controls.Add(this.borderWidthNumericUpDown);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(171, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 77);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Border";
            // 
            // borderColorPanelControl
            // 
            this.borderColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.borderColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.borderColorPanelControl.Location = new System.Drawing.Point(58, 22);
            this.borderColorPanelControl.Name = "borderColorPanelControl";
            this.borderColorPanelControl.Size = new System.Drawing.Size(105, 22);
            this.borderColorPanelControl.TabIndex = 4;
            // 
            // borderWidthNumericUpDown
            // 
            this.borderWidthNumericUpDown.Location = new System.Drawing.Point(58, 52);
            this.borderWidthNumericUpDown.Name = "borderWidthNumericUpDown";
            this.borderWidthNumericUpDown.Size = new System.Drawing.Size(78, 23);
            this.borderWidthNumericUpDown.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Color";
            // 
            // ellipticalOutlineCheckBox
            // 
            this.ellipticalOutlineCheckBox.AutoSize = true;
            this.ellipticalOutlineCheckBox.Location = new System.Drawing.Point(12, 85);
            this.ellipticalOutlineCheckBox.Name = "ellipticalOutlineCheckBox";
            this.ellipticalOutlineCheckBox.Size = new System.Drawing.Size(112, 19);
            this.ellipticalOutlineCheckBox.TabIndex = 7;
            this.ellipticalOutlineCheckBox.Text = "Elliptical Outline";
            this.ellipticalOutlineCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grayscaleCheckBox);
            this.groupBox2.Controls.Add(this.oilPaintingCheckBox);
            this.groupBox2.Controls.Add(this.posterizeCheckBox);
            this.groupBox2.Controls.Add(this.invertCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 69);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Processing ";
            // 
            // grayscaleCheckBox
            // 
            this.grayscaleCheckBox.AutoSize = true;
            this.grayscaleCheckBox.Location = new System.Drawing.Point(165, 43);
            this.grayscaleCheckBox.Name = "grayscaleCheckBox";
            this.grayscaleCheckBox.Size = new System.Drawing.Size(76, 19);
            this.grayscaleCheckBox.TabIndex = 3;
            this.grayscaleCheckBox.Text = "Grayscale";
            this.grayscaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // oilPaintingCheckBox
            // 
            this.oilPaintingCheckBox.AutoSize = true;
            this.oilPaintingCheckBox.Location = new System.Drawing.Point(165, 20);
            this.oilPaintingCheckBox.Name = "oilPaintingCheckBox";
            this.oilPaintingCheckBox.Size = new System.Drawing.Size(88, 19);
            this.oilPaintingCheckBox.TabIndex = 2;
            this.oilPaintingCheckBox.Text = "Oil Painting";
            this.oilPaintingCheckBox.UseVisualStyleBackColor = true;
            // 
            // posterizeCheckBox
            // 
            this.posterizeCheckBox.AutoSize = true;
            this.posterizeCheckBox.Location = new System.Drawing.Point(6, 43);
            this.posterizeCheckBox.Name = "posterizeCheckBox";
            this.posterizeCheckBox.Size = new System.Drawing.Size(73, 19);
            this.posterizeCheckBox.TabIndex = 1;
            this.posterizeCheckBox.Text = "Posterize";
            this.posterizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // invertCheckBox
            // 
            this.invertCheckBox.AutoSize = true;
            this.invertCheckBox.Location = new System.Drawing.Point(6, 20);
            this.invertCheckBox.Name = "invertCheckBox";
            this.invertCheckBox.Size = new System.Drawing.Size(56, 19);
            this.invertCheckBox.TabIndex = 0;
            this.invertCheckBox.Text = "Invert";
            this.invertCheckBox.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(181, 183);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 9;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(263, 183);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(141, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "(px)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "(px)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "(%)";
            // 
            // showVisualToolsCheckBox
            // 
            this.showVisualToolsCheckBox.AutoSize = true;
            this.showVisualToolsCheckBox.Location = new System.Drawing.Point(171, 85);
            this.showVisualToolsCheckBox.Name = "showVisualToolsCheckBox";
            this.showVisualToolsCheckBox.Size = new System.Drawing.Size(119, 19);
            this.showVisualToolsCheckBox.TabIndex = 15;
            this.showVisualToolsCheckBox.Text = "Show Visual Tools";
            this.showVisualToolsCheckBox.UseVisualStyleBackColor = true;
            // 
            // MagnifierToolSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(348, 213);
            this.Controls.Add(this.showVisualToolsCheckBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ellipticalOutlineCheckBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zoomNumericUpDown);
            this.Controls.Add(this.heightNumericUpDown);
            this.Controls.Add(this.widthNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MagnifierToolSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Magnifier Tool Settings";
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown widthNumericUpDown;
        private System.Windows.Forms.NumericUpDown heightNumericUpDown;
        private System.Windows.Forms.NumericUpDown zoomNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ellipticalOutlineCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DemosCommonCode.CustomControls.ColorPanelControl borderColorPanelControl;
        private System.Windows.Forms.NumericUpDown borderWidthNumericUpDown;
        private System.Windows.Forms.CheckBox oilPaintingCheckBox;
        private System.Windows.Forms.CheckBox posterizeCheckBox;
        private System.Windows.Forms.CheckBox invertCheckBox;
        private System.Windows.Forms.CheckBox grayscaleCheckBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox showVisualToolsCheckBox;
    }
}