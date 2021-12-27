
namespace DemosCommonCode.Office
{
    partial class OfficeDocumentVisualEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfficeDocumentVisualEditorForm));
            this.officeDocumentStrip = new System.Windows.Forms.ToolStrip();
            this.chartsButton = new System.Windows.Forms.ToolStripButton();
            this.increaseContentScaleButton = new System.Windows.Forms.ToolStripButton();
            this.decreaseContentScaleButton = new System.Windows.Forms.ToolStripButton();
            this.fontPropertiesVisualEditorToolStrip = new DemosCommonCode.Office.OfficeDocumentFontPropertiesVisualEditorToolStrip();
            this.paragraphPropertiesVisualEditorToolStrip = new DemosCommonCode.Office.OfficeDocumentParagraphPropertiesVisualEditorToolStrip();
            this.textPropertiesVisualEditorToolStrip = new DemosCommonCode.Office.OfficeDocumentTextPropertiesVisualEditorToolStrip();
            this.officeDocumentStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // officeDocumentStrip
            // 
            this.officeDocumentStrip.AutoSize = false;
            this.officeDocumentStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.officeDocumentStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.officeDocumentStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartsButton,
            this.increaseContentScaleButton,
            this.decreaseContentScaleButton});
            this.officeDocumentStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.officeDocumentStrip.Location = new System.Drawing.Point(2, 2);
            this.officeDocumentStrip.Name = "officeDocumentStrip";
            this.officeDocumentStrip.Size = new System.Drawing.Size(251, 27);
            this.officeDocumentStrip.TabIndex = 1;
            this.officeDocumentStrip.Text = "toolStrip1";
            // 
            // chartsButton
            // 
            this.chartsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chartsButton.Image = ((System.Drawing.Image)(resources.GetObject("chartsButton.Image")));
            this.chartsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.chartsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chartsButton.Name = "chartsButton";
            this.chartsButton.Size = new System.Drawing.Size(23, 20);
            this.chartsButton.Text = "Charts...";
            this.chartsButton.Click += new System.EventHandler(this.chartsButton_Click);
            // 
            // increaseContentScaleButton
            // 
            this.increaseContentScaleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.increaseContentScaleButton.Image = ((System.Drawing.Image)(resources.GetObject("increaseContentScaleButton.Image")));
            this.increaseContentScaleButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.increaseContentScaleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.increaseContentScaleButton.Name = "increaseContentScaleButton";
            this.increaseContentScaleButton.Size = new System.Drawing.Size(23, 22);
            this.increaseContentScaleButton.Text = "toolStripButton2";
            this.increaseContentScaleButton.ToolTipText = "Increase content scale";
            this.increaseContentScaleButton.Click += new System.EventHandler(this.increaseContentScaleButton_Click);
            // 
            // decreaseContentScaleButton
            // 
            this.decreaseContentScaleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.decreaseContentScaleButton.Image = ((System.Drawing.Image)(resources.GetObject("decreaseContentScaleButton.Image")));
            this.decreaseContentScaleButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.decreaseContentScaleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.decreaseContentScaleButton.Name = "decreaseContentScaleButton";
            this.decreaseContentScaleButton.Size = new System.Drawing.Size(23, 22);
            this.decreaseContentScaleButton.Text = "toolStripButton3";
            this.decreaseContentScaleButton.ToolTipText = "Decrease content scale";
            this.decreaseContentScaleButton.Click += new System.EventHandler(this.decreaseContentScaleButton_Click);
            // 
            // fontPropertiesVisualEditorToolStrip
            // 
            this.fontPropertiesVisualEditorToolStrip.AutoSize = false;
            this.fontPropertiesVisualEditorToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.fontPropertiesVisualEditorToolStrip.Enabled = false;
            this.fontPropertiesVisualEditorToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fontPropertiesVisualEditorToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.fontPropertiesVisualEditorToolStrip.Location = new System.Drawing.Point(2, 29);
            this.fontPropertiesVisualEditorToolStrip.Name = "fontPropertiesVisualEditorToolStrip";
            this.fontPropertiesVisualEditorToolStrip.Size = new System.Drawing.Size(251, 25);
            this.fontPropertiesVisualEditorToolStrip.TabIndex = 2;
            this.fontPropertiesVisualEditorToolStrip.Text = "officeDocumentFontPropertiesVisualEditorToolStrip1";
            // 
            // paragraphPropertiesVisualEditorToolStrip
            // 
            this.paragraphPropertiesVisualEditorToolStrip.AutoSize = false;
            this.paragraphPropertiesVisualEditorToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.paragraphPropertiesVisualEditorToolStrip.Enabled = false;
            this.paragraphPropertiesVisualEditorToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.paragraphPropertiesVisualEditorToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.paragraphPropertiesVisualEditorToolStrip.Location = new System.Drawing.Point(2, 79);
            this.paragraphPropertiesVisualEditorToolStrip.Name = "paragraphPropertiesVisualEditorToolStrip";
            this.paragraphPropertiesVisualEditorToolStrip.Size = new System.Drawing.Size(251, 25);
            this.paragraphPropertiesVisualEditorToolStrip.TabIndex = 3;
            this.paragraphPropertiesVisualEditorToolStrip.Text = "officeDocumentParagraphPropertiesVisualEditorToolStrip1";
            // 
            // textPropertiesVisualEditorToolStrip
            // 
            this.textPropertiesVisualEditorToolStrip.AutoSize = false;
            this.textPropertiesVisualEditorToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.textPropertiesVisualEditorToolStrip.Enabled = false;
            this.textPropertiesVisualEditorToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.textPropertiesVisualEditorToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.textPropertiesVisualEditorToolStrip.Location = new System.Drawing.Point(2, 54);
            this.textPropertiesVisualEditorToolStrip.Name = "textPropertiesVisualEditorToolStrip";
            this.textPropertiesVisualEditorToolStrip.Size = new System.Drawing.Size(251, 25);
            this.textPropertiesVisualEditorToolStrip.TabIndex = 4;
            this.textPropertiesVisualEditorToolStrip.Text = "officeDocumentTextPropertiesVisualEditorToolStrip1";
            // 
            // OfficeDocumentVisualEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(254, 106);
            this.Controls.Add(this.textPropertiesVisualEditorToolStrip);
            this.Controls.Add(this.paragraphPropertiesVisualEditorToolStrip);
            this.Controls.Add(this.fontPropertiesVisualEditorToolStrip);
            this.Controls.Add(this.officeDocumentStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OfficeDocumentVisualEditorForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Document Editor Toolbox";
            this.TopMost = true;
            this.officeDocumentStrip.ResumeLayout(false);
            this.officeDocumentStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip officeDocumentStrip;
        private System.Windows.Forms.ToolStripButton chartsButton;
        private System.Windows.Forms.ToolStripButton increaseContentScaleButton;
        private System.Windows.Forms.ToolStripButton decreaseContentScaleButton;
        private OfficeDocumentFontPropertiesVisualEditorToolStrip fontPropertiesVisualEditorToolStrip;
        private OfficeDocumentParagraphPropertiesVisualEditorToolStrip paragraphPropertiesVisualEditorToolStrip;
        private OfficeDocumentTextPropertiesVisualEditorToolStrip textPropertiesVisualEditorToolStrip;
    }
}