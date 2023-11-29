namespace AnnotationDemo
{
    partial class FillSignatureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FillSignatureForm));
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard1 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance1 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance2 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance3 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance4 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance5 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailCaption thumbnailCaption1 = new Vintasoft.Imaging.UI.ThumbnailCaption();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.addSignatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addInitialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.annotatedThumbnailViewer1 = new Vintasoft.Imaging.Annotation.UI.AnnotatedThumbnailViewer();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(176, 492);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(257, 492);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = resources.GetString("openFileDialog1.Filter");
            this.openFileDialog1.FilterIndex = 5;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "TIFF File(*.tiff;*.tif)|*.tiff;*.tif|Binary Annotations(*.vsab)|*.vsab|XMP Annota" +
    "tions(*.xmp)|*.xmp|WANG Annotations(*.wng)|*.wng";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripSplitButton,
            this.removeToolStripSplitButton,
            this.saveToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(344, 53);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addToolStripSplitButton
            // 
            this.addToolStripSplitButton.AutoSize = false;
            this.addToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSignatureToolStripMenuItem,
            this.addInitialsToolStripMenuItem,
            this.addTitleToolStripMenuItem,
            this.toolStripSeparator1,
            this.addFromFileToolStripMenuItem});
            this.addToolStripSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripSplitButton.Image")));
            this.addToolStripSplitButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addToolStripSplitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripSplitButton.Name = "addToolStripSplitButton";
            this.addToolStripSplitButton.Size = new System.Drawing.Size(50, 50);
            this.addToolStripSplitButton.Text = "Add";
            this.addToolStripSplitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addToolStripSplitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.addToolStripSplitButton.ButtonClick += new System.EventHandler(this.addToolStripSplitButton_ButtonClick);
            // 
            // addSignatureToolStripMenuItem
            // 
            this.addSignatureToolStripMenuItem.Name = "addSignatureToolStripMenuItem";
            this.addSignatureToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addSignatureToolStripMenuItem.Text = "Add Signature...";
            this.addSignatureToolStripMenuItem.Click += new System.EventHandler(this.addSignatureToolStripMenuItem_Click);
            // 
            // addInitialsToolStripMenuItem
            // 
            this.addInitialsToolStripMenuItem.Name = "addInitialsToolStripMenuItem";
            this.addInitialsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addInitialsToolStripMenuItem.Text = "Add Initials...";
            this.addInitialsToolStripMenuItem.Click += new System.EventHandler(this.addInitialsToolStripMenuItem_Click);
            // 
            // addTitleToolStripMenuItem
            // 
            this.addTitleToolStripMenuItem.Name = "addTitleToolStripMenuItem";
            this.addTitleToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addTitleToolStripMenuItem.Text = "Add Title...";
            this.addTitleToolStripMenuItem.Click += new System.EventHandler(this.addTitleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // addFromFileToolStripMenuItem
            // 
            this.addFromFileToolStripMenuItem.Name = "addFromFileToolStripMenuItem";
            this.addFromFileToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addFromFileToolStripMenuItem.Text = "Add From File...";
            this.addFromFileToolStripMenuItem.Click += new System.EventHandler(this.addFromFileToolStripMenuItem_Click);
            // 
            // removeToolStripSplitButton
            // 
            this.removeToolStripSplitButton.AutoSize = false;
            this.removeToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.removeAllToolStripMenuItem});
            this.removeToolStripSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripSplitButton.Image")));
            this.removeToolStripSplitButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.removeToolStripSplitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.removeToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeToolStripSplitButton.Name = "removeToolStripSplitButton";
            this.removeToolStripSplitButton.Size = new System.Drawing.Size(60, 50);
            this.removeToolStripSplitButton.Text = "Remove";
            this.removeToolStripSplitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.removeToolStripSplitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.removeToolStripSplitButton.ButtonClick += new System.EventHandler(this.removeToolStripSplitButton_ButtonClick);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripSplitButton_ButtonClick);
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.removeAllToolStripMenuItem.Text = "Remove All";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.removeAllToolStripMenuItem_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.AutoSize = false;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(50, 50);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // annotatedThumbnailViewer1
            // 
            this.annotatedThumbnailViewer1.AllowDrop = true;
            this.annotatedThumbnailViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.annotatedThumbnailViewer1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.annotatedThumbnailViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.annotatedThumbnailViewer1.Clipboard = winFormsSystemClipboard1;
            thumbnailAppearance1.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance1.BorderColor = System.Drawing.Color.Gray;
            thumbnailAppearance1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance1.BorderWidth = 1;
            this.annotatedThumbnailViewer1.FocusedThumbnailAppearance = thumbnailAppearance1;
            thumbnailAppearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance2.BorderWidth = 2;
            this.annotatedThumbnailViewer1.HoveredThumbnailAppearance = thumbnailAppearance2;
            this.annotatedThumbnailViewer1.ImageRotationAngle = 0;
            this.annotatedThumbnailViewer1.Location = new System.Drawing.Point(12, 56);
            this.annotatedThumbnailViewer1.Name = "annotatedThumbnailViewer1";
            thumbnailAppearance3.BackColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance3.BorderWidth = 0;
            this.annotatedThumbnailViewer1.NotReadyThumbnailAppearance = thumbnailAppearance3;
            thumbnailAppearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(238)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(222)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance4.BorderWidth = 1;
            this.annotatedThumbnailViewer1.SelectedThumbnailAppearance = thumbnailAppearance4;
            this.annotatedThumbnailViewer1.Size = new System.Drawing.Size(320, 430);
            this.annotatedThumbnailViewer1.TabIndex = 5;
            this.annotatedThumbnailViewer1.Text = "annotatedThumbnailViewer1";
            thumbnailAppearance5.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance5.BorderWidth = 1;
            this.annotatedThumbnailViewer1.ThumbnailAppearance = thumbnailAppearance5;
            thumbnailCaption1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            thumbnailCaption1.Padding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            thumbnailCaption1.TextColor = System.Drawing.Color.Black;
            this.annotatedThumbnailViewer1.ThumbnailCaption = thumbnailCaption1;
            this.annotatedThumbnailViewer1.ThumbnailControlPadding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            this.annotatedThumbnailViewer1.ThumbnailImagePadding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            this.annotatedThumbnailViewer1.ThumbnailMargin = new System.Windows.Forms.Padding(3);
            this.annotatedThumbnailViewer1.ThumbnailSize = new System.Drawing.Size(100, 100);
            // 
            // FillSignatureForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(344, 527);
            this.Controls.Add(this.annotatedThumbnailViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FillSignatureForm";
            this.Text = "Fill And Sign";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton removeToolStripSplitButton;
        private System.Windows.Forms.ToolStripSplitButton addToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem addFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSignatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addInitialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Vintasoft.Imaging.Annotation.UI.AnnotatedThumbnailViewer annotatedThumbnailViewer1;
    }
}