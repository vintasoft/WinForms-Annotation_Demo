
namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    partial class PdfImageCompressionControl
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
            this.mrcCompressionProfileComboBox = new System.Windows.Forms.ComboBox();
            this.compressionImageRadioButton = new System.Windows.Forms.RadioButton();
            this.compressionMrcRadioButton = new System.Windows.Forms.RadioButton();
            this.mrcCompressionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.mrcTabControl = new System.Windows.Forms.TabControl();
            this.mrcCommonTabPage = new System.Windows.Forms.TabPage();
            this.mrcImageSegmentationSettingsButton = new System.Windows.Forms.Button();
            this.mrcHiQualityFrontLayerCheckBox = new System.Windows.Forms.CheckBox();
            this.mrcUseImagesLayerRadioButton = new System.Windows.Forms.RadioButton();
            this.mrcNotUseImagesLayerRadioButton = new System.Windows.Forms.RadioButton();
            this.mrcImageSegmentationCheckBox = new System.Windows.Forms.CheckBox();
            this.mrcUseBackgroundLayerCheckBox = new System.Windows.Forms.CheckBox();
            this.mrcHiQualityMaskCheckBox = new System.Windows.Forms.CheckBox();
            this.mrcUseFrontCheckBox = new System.Windows.Forms.CheckBox();
            this.mrcBackgroundTabPage = new System.Windows.Forms.TabPage();
            this.mrcBackgroundCompressionControl = new DemosCommonCode.Imaging.Codecs.Dialogs.PdfCompressionControl();
            this.mrcImagesTabPage = new System.Windows.Forms.TabPage();
            this.mrcImagesCompressionControl = new DemosCommonCode.Imaging.Codecs.Dialogs.PdfCompressionControl();
            this.mrcMaskTabPage = new System.Windows.Forms.TabPage();
            this.mrcMaskCompressionControl = new DemosCommonCode.Imaging.Codecs.Dialogs.PdfCompressionControl();
            this.mrcFrontTabPage = new System.Windows.Forms.TabPage();
            this.mrcFrontCompressionControl = new DemosCommonCode.Imaging.Codecs.Dialogs.PdfCompressionControl();
            this.pdfCompressionControl = new DemosCommonCode.Imaging.Codecs.Dialogs.PdfCompressionControl();
            this.mrcCompressionSettingsGroupBox.SuspendLayout();
            this.mrcTabControl.SuspendLayout();
            this.mrcCommonTabPage.SuspendLayout();
            this.mrcBackgroundTabPage.SuspendLayout();
            this.mrcImagesTabPage.SuspendLayout();
            this.mrcMaskTabPage.SuspendLayout();
            this.mrcFrontTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mrcCompressionProfileComboBox
            // 
            this.mrcCompressionProfileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mrcCompressionProfileComboBox.FormattingEnabled = true;
            this.mrcCompressionProfileComboBox.Items.AddRange(new object[] {
            "Custom",
            "Document with images, best quality",
            "Document with images, optimal",
            "Document with images, best compression",
            "Document, best quality",
            "Document, optimal",
            "Document, best compression"});
            this.mrcCompressionProfileComboBox.Location = new System.Drawing.Point(133, 2);
            this.mrcCompressionProfileComboBox.Name = "mrcCompressionProfileComboBox";
            this.mrcCompressionProfileComboBox.Size = new System.Drawing.Size(254, 23);
            this.mrcCompressionProfileComboBox.TabIndex = 23;
            this.mrcCompressionProfileComboBox.SelectedIndexChanged += new System.EventHandler(this.mrcCompressionProfileComboBox_SelectedIndexChanged);
            // 
            // compressionImageRadioButton
            // 
            this.compressionImageRadioButton.AutoSize = true;
            this.compressionImageRadioButton.Location = new System.Drawing.Point(0, 3);
            this.compressionImageRadioButton.Name = "compressionImageRadioButton";
            this.compressionImageRadioButton.Size = new System.Drawing.Size(58, 19);
            this.compressionImageRadioButton.TabIndex = 26;
            this.compressionImageRadioButton.Text = "Image";
            this.compressionImageRadioButton.UseVisualStyleBackColor = true;
            this.compressionImageRadioButton.CheckedChanged += new System.EventHandler(this.compressionRadioButton_CheckedChanged);
            // 
            // compressionMrcRadioButton
            // 
            this.compressionMrcRadioButton.AutoSize = true;
            this.compressionMrcRadioButton.Location = new System.Drawing.Point(64, 3);
            this.compressionMrcRadioButton.Name = "compressionMrcRadioButton";
            this.compressionMrcRadioButton.Size = new System.Drawing.Size(51, 19);
            this.compressionMrcRadioButton.TabIndex = 25;
            this.compressionMrcRadioButton.Text = "MRC";
            this.compressionMrcRadioButton.UseVisualStyleBackColor = true;
            this.compressionMrcRadioButton.CheckedChanged += new System.EventHandler(this.compressionRadioButton_CheckedChanged);
            // 
            // mrcCompressionSettingsGroupBox
            // 
            this.mrcCompressionSettingsGroupBox.Controls.Add(this.mrcTabControl);
            this.mrcCompressionSettingsGroupBox.Location = new System.Drawing.Point(3, 24);
            this.mrcCompressionSettingsGroupBox.Name = "mrcCompressionSettingsGroupBox";
            this.mrcCompressionSettingsGroupBox.Size = new System.Drawing.Size(384, 202);
            this.mrcCompressionSettingsGroupBox.TabIndex = 24;
            this.mrcCompressionSettingsGroupBox.TabStop = false;
            this.mrcCompressionSettingsGroupBox.Text = "MRC layers compression settings";
            this.mrcCompressionSettingsGroupBox.Visible = false;
            // 
            // mrcTabControl
            // 
            this.mrcTabControl.Controls.Add(this.mrcCommonTabPage);
            this.mrcTabControl.Controls.Add(this.mrcBackgroundTabPage);
            this.mrcTabControl.Controls.Add(this.mrcImagesTabPage);
            this.mrcTabControl.Controls.Add(this.mrcMaskTabPage);
            this.mrcTabControl.Controls.Add(this.mrcFrontTabPage);
            this.mrcTabControl.Location = new System.Drawing.Point(3, 16);
            this.mrcTabControl.Name = "mrcTabControl";
            this.mrcTabControl.SelectedIndex = 0;
            this.mrcTabControl.Size = new System.Drawing.Size(375, 178);
            this.mrcTabControl.TabIndex = 0;
            // 
            // mrcCommonTabPage
            // 
            this.mrcCommonTabPage.Controls.Add(this.mrcImageSegmentationSettingsButton);
            this.mrcCommonTabPage.Controls.Add(this.mrcHiQualityFrontLayerCheckBox);
            this.mrcCommonTabPage.Controls.Add(this.mrcUseImagesLayerRadioButton);
            this.mrcCommonTabPage.Controls.Add(this.mrcNotUseImagesLayerRadioButton);
            this.mrcCommonTabPage.Controls.Add(this.mrcImageSegmentationCheckBox);
            this.mrcCommonTabPage.Controls.Add(this.mrcUseBackgroundLayerCheckBox);
            this.mrcCommonTabPage.Controls.Add(this.mrcHiQualityMaskCheckBox);
            this.mrcCommonTabPage.Controls.Add(this.mrcUseFrontCheckBox);
            this.mrcCommonTabPage.Location = new System.Drawing.Point(4, 24);
            this.mrcCommonTabPage.Name = "mrcCommonTabPage";
            this.mrcCommonTabPage.Size = new System.Drawing.Size(367, 150);
            this.mrcCommonTabPage.TabIndex = 4;
            this.mrcCommonTabPage.Text = "Common";
            this.mrcCommonTabPage.UseVisualStyleBackColor = true;
            // 
            // mrcImageSegmentationSettingsButton
            // 
            this.mrcImageSegmentationSettingsButton.Location = new System.Drawing.Point(220, 21);
            this.mrcImageSegmentationSettingsButton.Name = "mrcImageSegmentationSettingsButton";
            this.mrcImageSegmentationSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.mrcImageSegmentationSettingsButton.TabIndex = 31;
            this.mrcImageSegmentationSettingsButton.Text = "Settings...";
            this.mrcImageSegmentationSettingsButton.UseVisualStyleBackColor = true;
            this.mrcImageSegmentationSettingsButton.Click += new System.EventHandler(this.mrcImageSegmentationSettingsButton_Click);
            // 
            // mrcHiQualityFrontLayerCheckBox
            // 
            this.mrcHiQualityFrontLayerCheckBox.AutoSize = true;
            this.mrcHiQualityFrontLayerCheckBox.Location = new System.Drawing.Point(31, 113);
            this.mrcHiQualityFrontLayerCheckBox.Name = "mrcHiQualityFrontLayerCheckBox";
            this.mrcHiQualityFrontLayerCheckBox.Size = new System.Drawing.Size(148, 19);
            this.mrcHiQualityFrontLayerCheckBox.TabIndex = 30;
            this.mrcHiQualityFrontLayerCheckBox.Text = "High quality front layer";
            this.mrcHiQualityFrontLayerCheckBox.UseVisualStyleBackColor = true;
            this.mrcHiQualityFrontLayerCheckBox.Click += new System.EventHandler(this.mrcHiQualityFrontLayerCheckBox_CheckedChanged);
            // 
            // mrcUseImagesLayerRadioButton
            // 
            this.mrcUseImagesLayerRadioButton.AutoSize = true;
            this.mrcUseImagesLayerRadioButton.Location = new System.Drawing.Point(30, 56);
            this.mrcUseImagesLayerRadioButton.Name = "mrcUseImagesLayerRadioButton";
            this.mrcUseImagesLayerRadioButton.Size = new System.Drawing.Size(225, 19);
            this.mrcUseImagesLayerRadioButton.TabIndex = 29;
            this.mrcUseImagesLayerRadioButton.Text = "images layer (each image as resource)";
            this.mrcUseImagesLayerRadioButton.UseVisualStyleBackColor = true;
            this.mrcUseImagesLayerRadioButton.CheckedChanged += new System.EventHandler(this.mrcUseImagesLayerRadioButton_CheckedChanged);
            // 
            // mrcNotUseImagesLayerRadioButton
            // 
            this.mrcNotUseImagesLayerRadioButton.AutoSize = true;
            this.mrcNotUseImagesLayerRadioButton.Location = new System.Drawing.Point(30, 38);
            this.mrcNotUseImagesLayerRadioButton.Name = "mrcNotUseImagesLayerRadioButton";
            this.mrcNotUseImagesLayerRadioButton.Size = new System.Drawing.Size(117, 19);
            this.mrcNotUseImagesLayerRadioButton.TabIndex = 28;
            this.mrcNotUseImagesLayerRadioButton.Text = "background layer";
            this.mrcNotUseImagesLayerRadioButton.UseVisualStyleBackColor = true;
            this.mrcNotUseImagesLayerRadioButton.CheckedChanged += new System.EventHandler(this.mrcNotUseImagesLayerRadioButton_CheckedChanged);
            // 
            // mrcImageSegmentationCheckBox
            // 
            this.mrcImageSegmentationCheckBox.AutoSize = true;
            this.mrcImageSegmentationCheckBox.Location = new System.Drawing.Point(11, 23);
            this.mrcImageSegmentationCheckBox.Name = "mrcImageSegmentationCheckBox";
            this.mrcImageSegmentationCheckBox.Size = new System.Drawing.Size(190, 19);
            this.mrcImageSegmentationCheckBox.TabIndex = 27;
            this.mrcImageSegmentationCheckBox.Text = "Detect images, place images to";
            this.mrcImageSegmentationCheckBox.UseVisualStyleBackColor = true;
            this.mrcImageSegmentationCheckBox.CheckedChanged += new System.EventHandler(this.mrcImageSegmentationCheckBox_CheckedChanged);
            // 
            // mrcUseBackgroundLayerCheckBox
            // 
            this.mrcUseBackgroundLayerCheckBox.AutoSize = true;
            this.mrcUseBackgroundLayerCheckBox.Location = new System.Drawing.Point(11, 5);
            this.mrcUseBackgroundLayerCheckBox.Name = "mrcUseBackgroundLayerCheckBox";
            this.mrcUseBackgroundLayerCheckBox.Size = new System.Drawing.Size(140, 19);
            this.mrcUseBackgroundLayerCheckBox.TabIndex = 26;
            this.mrcUseBackgroundLayerCheckBox.Text = "Use background layer";
            this.mrcUseBackgroundLayerCheckBox.UseVisualStyleBackColor = true;
            this.mrcUseBackgroundLayerCheckBox.CheckedChanged += new System.EventHandler(this.mrcUseBackgroundLayerCheckBox_CheckedChanged);
            // 
            // mrcHiQualityMaskCheckBox
            // 
            this.mrcHiQualityMaskCheckBox.AutoSize = true;
            this.mrcHiQualityMaskCheckBox.Location = new System.Drawing.Point(11, 76);
            this.mrcHiQualityMaskCheckBox.Name = "mrcHiQualityMaskCheckBox";
            this.mrcHiQualityMaskCheckBox.Size = new System.Drawing.Size(122, 19);
            this.mrcHiQualityMaskCheckBox.TabIndex = 25;
            this.mrcHiQualityMaskCheckBox.Text = "High quality mask";
            this.mrcHiQualityMaskCheckBox.UseVisualStyleBackColor = true;
            this.mrcHiQualityMaskCheckBox.CheckedChanged += new System.EventHandler(this.mrcHiQualityMaskCheckBox_CheckedChanged);
            // 
            // mrcUseFrontCheckBox
            // 
            this.mrcUseFrontCheckBox.AutoSize = true;
            this.mrcUseFrontCheckBox.Location = new System.Drawing.Point(11, 95);
            this.mrcUseFrontCheckBox.Name = "mrcUseFrontCheckBox";
            this.mrcUseFrontCheckBox.Size = new System.Drawing.Size(191, 19);
            this.mrcUseFrontCheckBox.TabIndex = 24;
            this.mrcUseFrontCheckBox.Text = "Use front layer (text color layer)";
            this.mrcUseFrontCheckBox.UseVisualStyleBackColor = true;
            this.mrcUseFrontCheckBox.CheckedChanged += new System.EventHandler(this.mrcUseFrontCheckBox_CheckedChanged);
            // 
            // mrcBackgroundTabPage
            // 
            this.mrcBackgroundTabPage.Controls.Add(this.mrcBackgroundCompressionControl);
            this.mrcBackgroundTabPage.Location = new System.Drawing.Point(4, 24);
            this.mrcBackgroundTabPage.Name = "mrcBackgroundTabPage";
            this.mrcBackgroundTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mrcBackgroundTabPage.Size = new System.Drawing.Size(367, 150);
            this.mrcBackgroundTabPage.TabIndex = 0;
            this.mrcBackgroundTabPage.Text = "Background";
            this.mrcBackgroundTabPage.UseVisualStyleBackColor = true;
            // 
            // mrcBackgroundCompressionControl
            // 
            this.mrcBackgroundCompressionControl.CanUseAutoCompression = false;
            this.mrcBackgroundCompressionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mrcBackgroundCompressionControl.Location = new System.Drawing.Point(3, 3);
            this.mrcBackgroundCompressionControl.Name = "mrcBackgroundCompressionControl";
            this.mrcBackgroundCompressionControl.Size = new System.Drawing.Size(361, 144);
            this.mrcBackgroundCompressionControl.TabIndex = 0;
            // 
            // mrcImagesTabPage
            // 
            this.mrcImagesTabPage.Controls.Add(this.mrcImagesCompressionControl);
            this.mrcImagesTabPage.Location = new System.Drawing.Point(4, 24);
            this.mrcImagesTabPage.Name = "mrcImagesTabPage";
            this.mrcImagesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mrcImagesTabPage.Size = new System.Drawing.Size(367, 150);
            this.mrcImagesTabPage.TabIndex = 1;
            this.mrcImagesTabPage.Text = "Images";
            this.mrcImagesTabPage.UseVisualStyleBackColor = true;
            // 
            // mrcImagesCompressionControl
            // 
            this.mrcImagesCompressionControl.CanUseAutoCompression = false;
            this.mrcImagesCompressionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mrcImagesCompressionControl.Location = new System.Drawing.Point(3, 3);
            this.mrcImagesCompressionControl.Name = "mrcImagesCompressionControl";
            this.mrcImagesCompressionControl.Size = new System.Drawing.Size(361, 144);
            this.mrcImagesCompressionControl.TabIndex = 0;
            // 
            // mrcMaskTabPage
            // 
            this.mrcMaskTabPage.Controls.Add(this.mrcMaskCompressionControl);
            this.mrcMaskTabPage.Location = new System.Drawing.Point(4, 24);
            this.mrcMaskTabPage.Name = "mrcMaskTabPage";
            this.mrcMaskTabPage.Size = new System.Drawing.Size(367, 150);
            this.mrcMaskTabPage.TabIndex = 2;
            this.mrcMaskTabPage.Text = "Mask";
            this.mrcMaskTabPage.UseVisualStyleBackColor = true;
            // 
            // mrcMaskCompressionControl
            // 
            this.mrcMaskCompressionControl.CanUseAutoCompression = false;
            this.mrcMaskCompressionControl.Location = new System.Drawing.Point(3, 3);
            this.mrcMaskCompressionControl.Name = "mrcMaskCompressionControl";
            this.mrcMaskCompressionControl.Size = new System.Drawing.Size(361, 144);
            this.mrcMaskCompressionControl.TabIndex = 1;
            // 
            // mrcFrontTabPage
            // 
            this.mrcFrontTabPage.Controls.Add(this.mrcFrontCompressionControl);
            this.mrcFrontTabPage.Location = new System.Drawing.Point(4, 24);
            this.mrcFrontTabPage.Name = "mrcFrontTabPage";
            this.mrcFrontTabPage.Size = new System.Drawing.Size(367, 150);
            this.mrcFrontTabPage.TabIndex = 3;
            this.mrcFrontTabPage.Text = "Front";
            this.mrcFrontTabPage.UseVisualStyleBackColor = true;
            // 
            // mrcFrontCompressionControl
            // 
            this.mrcFrontCompressionControl.CanUseAutoCompression = false;
            this.mrcFrontCompressionControl.Location = new System.Drawing.Point(3, 3);
            this.mrcFrontCompressionControl.Name = "mrcFrontCompressionControl";
            this.mrcFrontCompressionControl.Size = new System.Drawing.Size(361, 144);
            this.mrcFrontCompressionControl.TabIndex = 1;
            // 
            // pdfImageCompressionControl
            // 
            this.pdfCompressionControl.Location = new System.Drawing.Point(13, 48);
            this.pdfCompressionControl.Name = "pdfImageCompressionControl";
            this.pdfCompressionControl.Size = new System.Drawing.Size(364, 166);
            this.pdfCompressionControl.TabIndex = 27;
            // 
            // PdfMrcCompressionControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.mrcCompressionProfileComboBox);
            this.Controls.Add(this.compressionImageRadioButton);
            this.Controls.Add(this.compressionMrcRadioButton);
            this.Controls.Add(this.mrcCompressionSettingsGroupBox);
            this.Controls.Add(this.pdfCompressionControl);
            this.Name = "PdfMrcCompressionControl";
            this.Size = new System.Drawing.Size(390, 226);
            this.mrcCompressionSettingsGroupBox.ResumeLayout(false);
            this.mrcTabControl.ResumeLayout(false);
            this.mrcCommonTabPage.ResumeLayout(false);
            this.mrcCommonTabPage.PerformLayout();
            this.mrcBackgroundTabPage.ResumeLayout(false);
            this.mrcImagesTabPage.ResumeLayout(false);
            this.mrcMaskTabPage.ResumeLayout(false);
            this.mrcFrontTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox mrcCompressionProfileComboBox;
        private System.Windows.Forms.RadioButton compressionImageRadioButton;
        private System.Windows.Forms.RadioButton compressionMrcRadioButton;
        private System.Windows.Forms.GroupBox mrcCompressionSettingsGroupBox;
        private System.Windows.Forms.TabControl mrcTabControl;
        private System.Windows.Forms.TabPage mrcCommonTabPage;
        private System.Windows.Forms.Button mrcImageSegmentationSettingsButton;
        private System.Windows.Forms.CheckBox mrcHiQualityFrontLayerCheckBox;
        private System.Windows.Forms.RadioButton mrcUseImagesLayerRadioButton;
        private System.Windows.Forms.RadioButton mrcNotUseImagesLayerRadioButton;
        private System.Windows.Forms.CheckBox mrcImageSegmentationCheckBox;
        private System.Windows.Forms.CheckBox mrcUseBackgroundLayerCheckBox;
        private System.Windows.Forms.CheckBox mrcHiQualityMaskCheckBox;
        private System.Windows.Forms.CheckBox mrcUseFrontCheckBox;
        private System.Windows.Forms.TabPage mrcBackgroundTabPage;
        private global::DemosCommonCode.Imaging.Codecs.Dialogs.PdfCompressionControl mrcBackgroundCompressionControl;
        private System.Windows.Forms.TabPage mrcImagesTabPage;
        private global::DemosCommonCode.Imaging.Codecs.Dialogs.PdfCompressionControl mrcImagesCompressionControl;
        private System.Windows.Forms.TabPage mrcMaskTabPage;
        private global::DemosCommonCode.Imaging.Codecs.Dialogs.PdfCompressionControl mrcMaskCompressionControl;
        private System.Windows.Forms.TabPage mrcFrontTabPage;
        private global::DemosCommonCode.Imaging.Codecs.Dialogs.PdfCompressionControl mrcFrontCompressionControl;
        private global::DemosCommonCode.Imaging.Codecs.Dialogs.PdfCompressionControl pdfCompressionControl;
    }
}