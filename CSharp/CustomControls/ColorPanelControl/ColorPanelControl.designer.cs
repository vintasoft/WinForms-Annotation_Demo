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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPanelControl));
            this.colorButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.defaultColorButton = new System.Windows.Forms.Button();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.colorNameLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.backgroundPanel.SuspendLayout();
            this.colorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorButton
            // 
            this.colorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton.Location = new System.Drawing.Point(89, 0);
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
            this.tableLayoutPanel1.Controls.Add(this.backgroundPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(142, 22);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // defaultColorButton
            // 
            this.defaultColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultColorButton.Location = new System.Drawing.Point(117, 0);
            this.defaultColorButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.defaultColorButton.Name = "defaultColorButton";
            this.defaultColorButton.Size = new System.Drawing.Size(25, 22);
            this.defaultColorButton.TabIndex = 2;
            this.defaultColorButton.Text = "X";
            this.defaultColorButton.UseVisualStyleBackColor = true;
            this.defaultColorButton.Visible = false;
            this.defaultColorButton.Click += new System.EventHandler(this.defaultColorButton_Click);
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BackColor = System.Drawing.Color.Transparent;
            this.backgroundPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backgroundPanel.BackgroundImage")));
            this.backgroundPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundPanel.Controls.Add(this.colorPanel);
            this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundPanel.Location = new System.Drawing.Point(0, 1);
            this.backgroundPanel.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(86, 20);
            this.backgroundPanel.TabIndex = 3;
            // 
            // colorPanel
            // 
            this.colorPanel.Controls.Add(this.colorNameLabel);
            this.colorPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPanel.Location = new System.Drawing.Point(0, 0);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(84, 18);
            this.colorPanel.TabIndex = 0;
            this.colorPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseDoubleClick);
            // 
            // colorNameLabel
            // 
            this.colorNameLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorNameLabel.Location = new System.Drawing.Point(0, 0);
            this.colorNameLabel.Name = "colorNameLabel";
            this.colorNameLabel.Size = new System.Drawing.Size(84, 18);
            this.colorNameLabel.TabIndex = 0;
            this.colorNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.colorNameLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseDoubleClick);
            // 
            // ColorPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ColorPanelControl";
            this.Size = new System.Drawing.Size(142, 22);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.backgroundPanel.ResumeLayout(false);
            this.colorPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button defaultColorButton;
        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Label colorNameLabel;
    }
}
