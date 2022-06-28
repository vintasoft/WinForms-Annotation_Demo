namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    partial class JpegEncoderSettingsForm
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
            this.jpegGrayscaleCheckBox = new System.Windows.Forms.CheckBox();
            this.jpegQualityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.disableSubsamplingCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.compressionTabPage = new System.Windows.Forms.TabPage();
            this.saveCommentsCheckBox = new System.Windows.Forms.CheckBox();
            this.optimizeHuffmanTablesCheckBox = new System.Windows.Forms.CheckBox();
            this.copyUnkwonwnApplicationMetadataCheckBox = new System.Windows.Forms.CheckBox();
            this.createThumbnailCheckBox = new System.Windows.Forms.CheckBox();
            this.copyExifMetadataCheckBox = new System.Windows.Forms.CheckBox();
            this.annotationsTabPage = new System.Windows.Forms.TabPage();
            this.annotationXmpCheckBox = new System.Windows.Forms.CheckBox();
            this.annotationsBinaryCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityNumericUpDown)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.compressionTabPage.SuspendLayout();
            this.annotationsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // jpegGrayscaleCheckBox
            // 
            this.jpegGrayscaleCheckBox.AutoSize = true;
            this.jpegGrayscaleCheckBox.Location = new System.Drawing.Point(6, 33);
            this.jpegGrayscaleCheckBox.Name = "jpegGrayscaleCheckBox";
            this.jpegGrayscaleCheckBox.Size = new System.Drawing.Size(117, 19);
            this.jpegGrayscaleCheckBox.TabIndex = 12;
            this.jpegGrayscaleCheckBox.Text = "Grayscale (8 bpp)";
            this.jpegGrayscaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // jpegQualityNumericUpDown
            // 
            this.jpegQualityNumericUpDown.Location = new System.Drawing.Point(63, 7);
            this.jpegQualityNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.jpegQualityNumericUpDown.Name = "jpegQualityNumericUpDown";
            this.jpegQualityNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.jpegQualityNumericUpDown.TabIndex = 1;
            this.jpegQualityNumericUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quality";
            // 
            // disableSubsamplingCheckBox
            // 
            this.disableSubsamplingCheckBox.AutoSize = true;
            this.disableSubsamplingCheckBox.Location = new System.Drawing.Point(6, 56);
            this.disableSubsamplingCheckBox.Name = "disableSubsamplingCheckBox";
            this.disableSubsamplingCheckBox.Size = new System.Drawing.Size(135, 19);
            this.disableSubsamplingCheckBox.TabIndex = 13;
            this.disableSubsamplingCheckBox.Text = "Disable subsampling";
            this.disableSubsamplingCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.compressionTabPage);
            this.tabControl1.Controls.Add(this.annotationsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(235, 227);
            this.tabControl1.TabIndex = 8;
            // 
            // compressionTabPage
            // 
            this.compressionTabPage.Controls.Add(this.saveCommentsCheckBox);
            this.compressionTabPage.Controls.Add(this.optimizeHuffmanTablesCheckBox);
            this.compressionTabPage.Controls.Add(this.copyUnkwonwnApplicationMetadataCheckBox);
            this.compressionTabPage.Controls.Add(this.createThumbnailCheckBox);
            this.compressionTabPage.Controls.Add(this.copyExifMetadataCheckBox);
            this.compressionTabPage.Controls.Add(this.disableSubsamplingCheckBox);
            this.compressionTabPage.Controls.Add(this.jpegGrayscaleCheckBox);
            this.compressionTabPage.Controls.Add(this.label1);
            this.compressionTabPage.Controls.Add(this.jpegQualityNumericUpDown);
            this.compressionTabPage.Location = new System.Drawing.Point(4, 24);
            this.compressionTabPage.Name = "compressionTabPage";
            this.compressionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.compressionTabPage.Size = new System.Drawing.Size(227, 199);
            this.compressionTabPage.TabIndex = 0;
            this.compressionTabPage.Text = "Compression";
            this.compressionTabPage.UseVisualStyleBackColor = true;
            // 
            // saveCommentsCheckBox
            // 
            this.saveCommentsCheckBox.AutoSize = true;
            this.saveCommentsCheckBox.Location = new System.Drawing.Point(6, 125);
            this.saveCommentsCheckBox.Name = "saveCommentsCheckBox";
            this.saveCommentsCheckBox.Size = new System.Drawing.Size(110, 19);
            this.saveCommentsCheckBox.TabIndex = 18;
            this.saveCommentsCheckBox.Text = "Save comments";
            this.saveCommentsCheckBox.UseVisualStyleBackColor = true;
            // 
            // optimizeHuffmanTablesCheckBox
            // 
            this.optimizeHuffmanTablesCheckBox.AutoSize = true;
            this.optimizeHuffmanTablesCheckBox.Location = new System.Drawing.Point(6, 79);
            this.optimizeHuffmanTablesCheckBox.Name = "optimizeHuffmanTablesCheckBox";
            this.optimizeHuffmanTablesCheckBox.Size = new System.Drawing.Size(159, 19);
            this.optimizeHuffmanTablesCheckBox.TabIndex = 17;
            this.optimizeHuffmanTablesCheckBox.Text = "Optimize Huffman tables";
            this.optimizeHuffmanTablesCheckBox.UseVisualStyleBackColor = true;
            // 
            // copyUnkwonwnApplicationMetadataCheckBox
            // 
            this.copyUnkwonwnApplicationMetadataCheckBox.AutoSize = true;
            this.copyUnkwonwnApplicationMetadataCheckBox.Location = new System.Drawing.Point(6, 171);
            this.copyUnkwonwnApplicationMetadataCheckBox.Name = "copyUnkwonwnApplicationMetadataCheckBox";
            this.copyUnkwonwnApplicationMetadataCheckBox.Size = new System.Drawing.Size(222, 19);
            this.copyUnkwonwnApplicationMetadataCheckBox.TabIndex = 16;
            this.copyUnkwonwnApplicationMetadataCheckBox.Text = "Copy unknown application metadata";
            this.copyUnkwonwnApplicationMetadataCheckBox.UseVisualStyleBackColor = true;
            // 
            // createThumbnailCheckBox
            // 
            this.createThumbnailCheckBox.AutoSize = true;
            this.createThumbnailCheckBox.Location = new System.Drawing.Point(6, 102);
            this.createThumbnailCheckBox.Name = "createThumbnailCheckBox";
            this.createThumbnailCheckBox.Size = new System.Drawing.Size(118, 19);
            this.createThumbnailCheckBox.TabIndex = 15;
            this.createThumbnailCheckBox.Text = "Create thumbnail";
            this.createThumbnailCheckBox.UseVisualStyleBackColor = true;
            // 
            // copyExifMetadataCheckBox
            // 
            this.copyExifMetadataCheckBox.AutoSize = true;
            this.copyExifMetadataCheckBox.Location = new System.Drawing.Point(6, 148);
            this.copyExifMetadataCheckBox.Name = "copyExifMetadataCheckBox";
            this.copyExifMetadataCheckBox.Size = new System.Drawing.Size(132, 19);
            this.copyExifMetadataCheckBox.TabIndex = 14;
            this.copyExifMetadataCheckBox.Text = "Copy EXIF metadata";
            this.copyExifMetadataCheckBox.UseVisualStyleBackColor = true;
            // 
            // annotationsTabPage
            // 
            this.annotationsTabPage.Controls.Add(this.annotationXmpCheckBox);
            this.annotationsTabPage.Controls.Add(this.annotationsBinaryCheckBox);
            this.annotationsTabPage.Location = new System.Drawing.Point(4, 24);
            this.annotationsTabPage.Name = "annotationsTabPage";
            this.annotationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.annotationsTabPage.Size = new System.Drawing.Size(227, 199);
            this.annotationsTabPage.TabIndex = 1;
            this.annotationsTabPage.Text = "Annotations Format";
            this.annotationsTabPage.UseVisualStyleBackColor = true;
            // 
            // annotationXmpCheckBox
            // 
            this.annotationXmpCheckBox.AutoSize = true;
            this.annotationXmpCheckBox.Location = new System.Drawing.Point(8, 31);
            this.annotationXmpCheckBox.Name = "annotationXmpCheckBox";
            this.annotationXmpCheckBox.Size = new System.Drawing.Size(101, 19);
            this.annotationXmpCheckBox.TabIndex = 12;
            this.annotationXmpCheckBox.Text = "Vintasoft XMP";
            this.annotationXmpCheckBox.UseVisualStyleBackColor = true;
            // 
            // annotationsBinaryCheckBox
            // 
            this.annotationsBinaryCheckBox.AutoSize = true;
            this.annotationsBinaryCheckBox.Location = new System.Drawing.Point(8, 8);
            this.annotationsBinaryCheckBox.Name = "annotationsBinaryCheckBox";
            this.annotationsBinaryCheckBox.Size = new System.Drawing.Size(109, 19);
            this.annotationsBinaryCheckBox.TabIndex = 11;
            this.annotationsBinaryCheckBox.Text = "Vintasoft Binary";
            this.annotationsBinaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(116, 236);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(35, 236);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 11;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // JpegEncoderSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(235, 267);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JpegEncoderSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JPEG Encoder Settings";
            ((System.ComponentModel.ISupportInitialize)(this.jpegQualityNumericUpDown)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.compressionTabPage.ResumeLayout(false);
            this.compressionTabPage.PerformLayout();
            this.annotationsTabPage.ResumeLayout(false);
            this.annotationsTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox jpegGrayscaleCheckBox;
        private System.Windows.Forms.NumericUpDown jpegQualityNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox disableSubsamplingCheckBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage compressionTabPage;
        private System.Windows.Forms.TabPage annotationsTabPage;
        private System.Windows.Forms.CheckBox annotationXmpCheckBox;
        private System.Windows.Forms.CheckBox annotationsBinaryCheckBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox createThumbnailCheckBox;
        private System.Windows.Forms.CheckBox copyExifMetadataCheckBox;
        private System.Windows.Forms.CheckBox copyUnkwonwnApplicationMetadataCheckBox;
        private System.Windows.Forms.CheckBox saveCommentsCheckBox;
        private System.Windows.Forms.CheckBox optimizeHuffmanTablesCheckBox;
    }
}