namespace DemosCommonCode.CustomControls
{
    partial class PaddingFEditorControl
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
            this.rightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bottomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.allNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.topNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.leftNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.rightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // rightNumericUpDown
            // 
            this.rightNumericUpDown.Location = new System.Drawing.Point(89, 28);
            this.rightNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.rightNumericUpDown.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.rightNumericUpDown.Name = "rightNumericUpDown";
            this.rightNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.rightNumericUpDown.TabIndex = 15;
            this.rightNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // bottomNumericUpDown
            // 
            this.bottomNumericUpDown.Location = new System.Drawing.Point(46, 54);
            this.bottomNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.bottomNumericUpDown.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.bottomNumericUpDown.Name = "bottomNumericUpDown";
            this.bottomNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.bottomNumericUpDown.TabIndex = 14;
            this.bottomNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // allNumericUpDown
            // 
            this.allNumericUpDown.Location = new System.Drawing.Point(46, 28);
            this.allNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.allNumericUpDown.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.allNumericUpDown.Name = "allNumericUpDown";
            this.allNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.allNumericUpDown.TabIndex = 13;
            this.allNumericUpDown.ValueChanged += new System.EventHandler(this.allNumericUpDown_ValueChanged);
            // 
            // topNumericUpDown
            // 
            this.topNumericUpDown.Location = new System.Drawing.Point(46, 2);
            this.topNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.topNumericUpDown.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.topNumericUpDown.Name = "topNumericUpDown";
            this.topNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.topNumericUpDown.TabIndex = 12;
            this.topNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // leftNumericUpDown
            // 
            this.leftNumericUpDown.Location = new System.Drawing.Point(3, 28);
            this.leftNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.leftNumericUpDown.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.leftNumericUpDown.Name = "leftNumericUpDown";
            this.leftNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.leftNumericUpDown.TabIndex = 11;
            this.leftNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(17, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(95, 55);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // PaddingPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rightNumericUpDown);
            this.Controls.Add(this.bottomNumericUpDown);
            this.Controls.Add(this.allNumericUpDown);
            this.Controls.Add(this.topNumericUpDown);
            this.Controls.Add(this.leftNumericUpDown);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(128, 75);
            this.MinimumSize = new System.Drawing.Size(128, 75);
            this.Name = "PaddingPanelControl";
            this.Size = new System.Drawing.Size(128, 75);
            ((System.ComponentModel.ISupportInitialize)(this.rightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown rightNumericUpDown;
        private System.Windows.Forms.NumericUpDown bottomNumericUpDown;
        private System.Windows.Forms.NumericUpDown allNumericUpDown;
        private System.Windows.Forms.NumericUpDown topNumericUpDown;
        private System.Windows.Forms.NumericUpDown leftNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
