namespace DemosCommonCode.CustomControls
{
    partial class ColorPanelControl
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
            this.components = new System.ComponentModel.Container();
            this.colorButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.defaultColorButton = new System.Windows.Forms.Button();
            this.colorSampleControl = new DemosCommonCode.CustomControls.ColorSampleControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorButton
            // 
            this.colorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton.Location = new System.Drawing.Point(84, 0);
            this.colorButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(25, 22);
            this.colorButton.TabIndex = 1;
            this.colorButton.Text = "...";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.defaultColorButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorSampleControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(137, 22);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // defaultColorButton
            // 
            this.defaultColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultColorButton.Location = new System.Drawing.Point(112, 0);
            this.defaultColorButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.defaultColorButton.Name = "defaultColorButton";
            this.defaultColorButton.Size = new System.Drawing.Size(25, 22);
            this.defaultColorButton.TabIndex = 2;
            this.defaultColorButton.Text = "X";
            this.defaultColorButton.UseVisualStyleBackColor = true;
            this.defaultColorButton.Visible = false;
            this.defaultColorButton.Click += new System.EventHandler(this.defaultColorButton_Click);
            // 
            // colorSampleControl
            // 
            this.colorSampleControl.Color = System.Drawing.Color.Transparent;
            this.colorSampleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorSampleControl.Location = new System.Drawing.Point(0, 0);
            this.colorSampleControl.Margin = new System.Windows.Forms.Padding(0);
            this.colorSampleControl.Name = "colorSampleControl";
            this.colorSampleControl.Size = new System.Drawing.Size(81, 22);
            this.colorSampleControl.TabIndex = 3;
            this.colorSampleControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorSampleControl_MouseClick);
            this.colorSampleControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorSampleControl_MouseDoubleClick);
            // 
            // ColorPanelControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ColorPanelControl";
            this.Size = new System.Drawing.Size(137, 22);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button defaultColorButton;
        private ColorSampleControl colorSampleControl;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}