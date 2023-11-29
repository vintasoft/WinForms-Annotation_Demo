namespace AnnotationDemo
{
    partial class AddSignatureForm
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
            this.components = new System.ComponentModel.Container();
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard1 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings1 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSignatureForm));
            this.annotationViewer1 = new Vintasoft.Imaging.Annotation.UI.AnnotationViewer();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.freehandToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.textToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stampToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.imageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fontToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // annotationViewer1
            // 
            this.annotationViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.annotationViewer1.AnnotationAuthorContextMenuStrip = null;
            this.annotationViewer1.AnnotationBoundingRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.annotationViewer1.AnnotationMultiSelect = false;
            this.annotationViewer1.AnnotationViewContextMenuStrip = null;
            this.annotationViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.annotationViewer1.CanMoveAnnotationsBetweenImages = false;
            this.annotationViewer1.Clipboard = winFormsSystemClipboard1;
            this.annotationViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.annotationViewer1.ImageRenderingSettings = renderingSettings1;
            this.annotationViewer1.ImageRotationAngle = 0;
            this.annotationViewer1.Location = new System.Drawing.Point(12, 56);
            this.annotationViewer1.Name = "annotationViewer1";
            this.annotationViewer1.ShortcutCopy = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.Size = new System.Drawing.Size(714, 362);
            this.annotationViewer1.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.annotationViewer1.TabIndex = 1;
            this.annotationViewer1.Text = "annotationViewer1";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(570, 424);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(651, 424);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freehandToolStripButton,
            this.textToolStripButton,
            this.stampToolStripButton,
            this.imageToolStripButton,
            this.toolStripSeparator1,
            this.clearToolStripButton,
            this.toolStripSeparator2,
            this.fontToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(738, 53);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // freehandToolStripButton
            // 
            this.freehandToolStripButton.AutoSize = false;
            this.freehandToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("freehandToolStripButton.Image")));
            this.freehandToolStripButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.freehandToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.freehandToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.freehandToolStripButton.Name = "freehandToolStripButton";
            this.freehandToolStripButton.Size = new System.Drawing.Size(61, 50);
            this.freehandToolStripButton.Text = "Freehand";
            this.freehandToolStripButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.freehandToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.freehandToolStripButton.ToolTipText = "Add Freehand";
            this.freehandToolStripButton.Click += new System.EventHandler(this.freehandToolStripButton_Click);
            // 
            // textToolStripButton
            // 
            this.textToolStripButton.AutoSize = false;
            this.textToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("textToolStripButton.Image")));
            this.textToolStripButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.textToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.textToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textToolStripButton.Name = "textToolStripButton";
            this.textToolStripButton.Size = new System.Drawing.Size(61, 50);
            this.textToolStripButton.Text = "Text";
            this.textToolStripButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.textToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.textToolStripButton.ToolTipText = "Add Text";
            this.textToolStripButton.Click += new System.EventHandler(this.textToolStripButton_Click);
            // 
            // stampToolStripButton
            // 
            this.stampToolStripButton.AutoSize = false;
            this.stampToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stampToolStripButton.Image")));
            this.stampToolStripButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.stampToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stampToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stampToolStripButton.Name = "stampToolStripButton";
            this.stampToolStripButton.Size = new System.Drawing.Size(61, 50);
            this.stampToolStripButton.Text = "Stamp";
            this.stampToolStripButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.stampToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.stampToolStripButton.ToolTipText = "Add Stamp";
            this.stampToolStripButton.Click += new System.EventHandler(this.stampToolStripButton_Click);
            // 
            // imageToolStripButton
            // 
            this.imageToolStripButton.AutoSize = false;
            this.imageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("imageToolStripButton.Image")));
            this.imageToolStripButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.imageToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imageToolStripButton.Name = "imageToolStripButton";
            this.imageToolStripButton.Size = new System.Drawing.Size(61, 50);
            this.imageToolStripButton.Text = "Image";
            this.imageToolStripButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.imageToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.imageToolStripButton.ToolTipText = "Add Image";
            this.imageToolStripButton.Click += new System.EventHandler(this.imageToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // clearToolStripButton
            // 
            this.clearToolStripButton.AutoSize = false;
            this.clearToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clearToolStripButton.Image")));
            this.clearToolStripButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.clearToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearToolStripButton.Name = "clearToolStripButton";
            this.clearToolStripButton.Size = new System.Drawing.Size(61, 50);
            this.clearToolStripButton.Text = "Clear";
            this.clearToolStripButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.clearToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.clearToolStripButton.ToolTipText = "Clear Template";
            this.clearToolStripButton.Click += new System.EventHandler(this.clearToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // fontToolStripButton
            // 
            this.fontToolStripButton.AutoSize = false;
            this.fontToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fontToolStripButton.Image")));
            this.fontToolStripButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.fontToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fontToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontToolStripButton.Name = "fontToolStripButton";
            this.fontToolStripButton.Size = new System.Drawing.Size(61, 50);
            this.fontToolStripButton.Text = "Font";
            this.fontToolStripButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.fontToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.fontToolStripButton.ToolTipText = "Font Properties";
            this.fontToolStripButton.Click += new System.EventHandler(this.fontToolStripButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.propertiesToolStripMenuItem.Text = "Properties...";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 432);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Name:";
            // 
            // nameComboBox
            // 
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(57, 429);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(174, 21);
            this.nameComboBox.TabIndex = 7;
            // 
            // AddSignatureForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(738, 459);
            this.Controls.Add(this.nameComboBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.annotationViewer1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddSignatureForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Vintasoft.Imaging.Annotation.UI.AnnotationViewer annotationViewer1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton freehandToolStripButton;
        private System.Windows.Forms.ToolStripButton textToolStripButton;
        private System.Windows.Forms.ToolStripButton imageToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton clearToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton fontToolStripButton;
        private System.Windows.Forms.ToolStripButton stampToolStripButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox nameComboBox;
    }
}