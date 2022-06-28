
namespace DemosCommonCode.CustomControls
{
    partial class ColorSampleControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorSampleControl));
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.colorNameLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundPanel.SuspendLayout();
            this.colorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BackColor = System.Drawing.Color.Transparent;
            this.backgroundPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backgroundPanel.BackgroundImage")));
            this.backgroundPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundPanel.Controls.Add(this.colorPanel);
            this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.backgroundPanel.Margin = new System.Windows.Forms.Padding(0);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(34, 26);
            this.backgroundPanel.TabIndex = 4;
            // 
            // colorPanel
            // 
            this.colorPanel.Controls.Add(this.colorNameLabel);
            this.colorPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.colorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPanel.Location = new System.Drawing.Point(0, 0);
            this.colorPanel.Margin = new System.Windows.Forms.Padding(0);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(32, 24);
            this.colorPanel.TabIndex = 0;
            this.colorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            this.colorPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseDoubleClick);
            // 
            // colorNameLabel
            // 
            this.colorNameLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.colorNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorNameLabel.Location = new System.Drawing.Point(0, 0);
            this.colorNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.colorNameLabel.Name = "colorNameLabel";
            this.colorNameLabel.Size = new System.Drawing.Size(32, 24);
            this.colorNameLabel.TabIndex = 0;
            this.colorNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.colorNameLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorNameLabel_MouseClick);
            this.colorNameLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.colorNameLabel_MouseDoubleClick);
            // 
            // ColorSampleControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backgroundPanel);
            this.Name = "ColorSampleControl";
            this.Size = new System.Drawing.Size(34, 26);
            this.CursorChanged += new System.EventHandler(this.ColorSampleControl_CursorChanged);
            this.backgroundPanel.ResumeLayout(false);
            this.colorPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Label colorNameLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}