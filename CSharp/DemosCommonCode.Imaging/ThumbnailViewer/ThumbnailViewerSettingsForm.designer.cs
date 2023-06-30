namespace DemosCommonCode.Imaging
{
    partial class ThumbnailViewerSettingsForm
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.thumbnailSizeComboBox = new System.Windows.Forms.ComboBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.generateOnlyVisibleThumbnailsCheckBox = new System.Windows.Forms.CheckBox();
            this.thumbnailFlowStyleComboBox = new System.Windows.Forms.ComboBox();
            this.flowStyleLabel = new System.Windows.Forms.Label();
            this.thumbnailColumnsCountComboBox = new System.Windows.Forms.ComboBox();
            this.columnsCountLabel = new System.Windows.Forms.Label();
            this.scaleLabel = new System.Windows.Forms.Label();
            this.thumbnailScaleComboBox = new System.Windows.Forms.ComboBox();
            this.thumbnailAppearanceGroupBox = new System.Windows.Forms.GroupBox();
            this.thumbnailAppearanceBorderColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.thumbnailAppearanceBackColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.borderStyleValueLabel = new System.Windows.Forms.Label();
            this.borderWidthValueLabel = new System.Windows.Forms.Label();
            this.editThumbnailAppearanceButton = new System.Windows.Forms.Button();
            this.borderStyleLabel = new System.Windows.Forms.Label();
            this.borderWidthLabel = new System.Windows.Forms.Label();
            this.borderColorLabel = new System.Windows.Forms.Label();
            this.backColorLabel = new System.Windows.Forms.Label();
            this.thumbnailAppearanceComboBox = new System.Windows.Forms.ComboBox();
            this.thumbnailViewerGroupBox = new System.Windows.Forms.GroupBox();
            this.thumbnailViewerBackColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.thumbnailRenderingThreadCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.thumbnailRenderThreadCountLabel = new System.Windows.Forms.Label();
            this.thumbnailViewerBackColorLabel = new System.Windows.Forms.Label();
            this.thumbnailsGroupBox = new System.Windows.Forms.GroupBox();
            this.imagePaddingGroupBox = new System.Windows.Forms.GroupBox();
            this.imagePaddingEditorControl = new DemosCommonCode.CustomControls.PaddingFEditorControl();
            this.thumbnailViewerBackColorDialog = new System.Windows.Forms.ColorDialog();
            this.thumbnailCaptionGroupBox = new System.Windows.Forms.GroupBox();
            this.captionAnchorTypeEditor = new DemosCommonCode.CustomControls.AnchorTypeEditorControl();
            this.captionFormatHelpButton = new System.Windows.Forms.Button();
            this.captionFormatTextBox = new System.Windows.Forms.TextBox();
            this.captionFontlabel = new System.Windows.Forms.Label();
            this.captionFontSelectButton = new System.Windows.Forms.Button();
            this.captionTextColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.captionTextColorLabel = new System.Windows.Forms.Label();
            this.captionAnchorLable = new System.Windows.Forms.Label();
            this.captionFormatLabel = new System.Windows.Forms.Label();
            this.captionPaddingGroupBox = new System.Windows.Forms.GroupBox();
            this.captionPaddingFEditorControl = new DemosCommonCode.CustomControls.PaddingFEditorControl();
            this.captionIsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.captionFontDialog = new System.Windows.Forms.FontDialog();
            this.thumbnailControlGroupBox = new System.Windows.Forms.GroupBox();
            this.showThumbnailCheckBoxCheckBox = new System.Windows.Forms.CheckBox();
            this.thumbnailControlAnchorTypeEditor = new DemosCommonCode.CustomControls.AnchorTypeEditorControl();
            this.thumbnailControlAnchorLabel = new System.Windows.Forms.Label();
            this.thumbnailControlPaddingGroupBox = new System.Windows.Forms.GroupBox();
            this.thumbnailControlPaddingFEditorControl = new DemosCommonCode.CustomControls.PaddingFEditorControl();
            this.thumbnailsAnchorEditorControl = new DemosCommonCode.CustomControls.AnchorTypeEditorControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.thumbnailAppearanceGroupBox.SuspendLayout();
            this.thumbnailViewerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailRenderingThreadCountNumericUpDown)).BeginInit();
            this.thumbnailsGroupBox.SuspendLayout();
            this.imagePaddingGroupBox.SuspendLayout();
            this.thumbnailCaptionGroupBox.SuspendLayout();
            this.captionPaddingGroupBox.SuspendLayout();
            this.thumbnailControlGroupBox.SuspendLayout();
            this.thumbnailControlPaddingGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(167, 623);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(81, 23);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(261, 623);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // thumbnailSizeComboBox
            // 
            this.thumbnailSizeComboBox.FormattingEnabled = true;
            this.thumbnailSizeComboBox.Items.AddRange(new object[] {
            "32 x 32",
            "64 x 64",
            "100 x 100",
            "128 x 128",
            "256 x 256",
            "512 x 512",
            "1024 x 1024"});
            this.thumbnailSizeComboBox.Location = new System.Drawing.Point(90, 17);
            this.thumbnailSizeComboBox.Name = "thumbnailSizeComboBox";
            this.thumbnailSizeComboBox.Size = new System.Drawing.Size(123, 21);
            this.thumbnailSizeComboBox.TabIndex = 12;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(12, 20);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(27, 13);
            this.sizeLabel.TabIndex = 13;
            this.sizeLabel.Text = "Size";
            // 
            // generateOnlyVisibleThumbnailsCheckBox
            // 
            this.generateOnlyVisibleThumbnailsCheckBox.AutoSize = true;
            this.generateOnlyVisibleThumbnailsCheckBox.Location = new System.Drawing.Point(15, 19);
            this.generateOnlyVisibleThumbnailsCheckBox.Name = "generateOnlyVisibleThumbnailsCheckBox";
            this.generateOnlyVisibleThumbnailsCheckBox.Size = new System.Drawing.Size(177, 17);
            this.generateOnlyVisibleThumbnailsCheckBox.TabIndex = 14;
            this.generateOnlyVisibleThumbnailsCheckBox.Text = "Generate only visible thumbnails";
            this.generateOnlyVisibleThumbnailsCheckBox.UseVisualStyleBackColor = true;
            // 
            // thumbnailFlowStyleComboBox
            // 
            this.thumbnailFlowStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thumbnailFlowStyleComboBox.FormattingEnabled = true;
            this.thumbnailFlowStyleComboBox.Location = new System.Drawing.Point(116, 40);
            this.thumbnailFlowStyleComboBox.Name = "thumbnailFlowStyleComboBox";
            this.thumbnailFlowStyleComboBox.Size = new System.Drawing.Size(129, 21);
            this.thumbnailFlowStyleComboBox.TabIndex = 15;
            this.thumbnailFlowStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.thumbnailFlowStyleComboBox_SelectedIndexChanged);
            // 
            // flowStyleLabel
            // 
            this.flowStyleLabel.AutoSize = true;
            this.flowStyleLabel.Location = new System.Drawing.Point(12, 43);
            this.flowStyleLabel.Name = "flowStyleLabel";
            this.flowStyleLabel.Size = new System.Drawing.Size(55, 13);
            this.flowStyleLabel.TabIndex = 16;
            this.flowStyleLabel.Text = "Flow Style";
            // 
            // thumbnailColumnsCountComboBox
            // 
            this.thumbnailColumnsCountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thumbnailColumnsCountComboBox.FormattingEnabled = true;
            this.thumbnailColumnsCountComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.thumbnailColumnsCountComboBox.Location = new System.Drawing.Point(116, 69);
            this.thumbnailColumnsCountComboBox.Name = "thumbnailColumnsCountComboBox";
            this.thumbnailColumnsCountComboBox.Size = new System.Drawing.Size(129, 21);
            this.thumbnailColumnsCountComboBox.TabIndex = 17;
            // 
            // columnsCountLabel
            // 
            this.columnsCountLabel.AutoSize = true;
            this.columnsCountLabel.Location = new System.Drawing.Point(12, 72);
            this.columnsCountLabel.Name = "columnsCountLabel";
            this.columnsCountLabel.Size = new System.Drawing.Size(78, 13);
            this.columnsCountLabel.TabIndex = 18;
            this.columnsCountLabel.Text = "Columns Count";
            // 
            // scaleLabel
            // 
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.Location = new System.Drawing.Point(12, 49);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(34, 13);
            this.scaleLabel.TabIndex = 20;
            this.scaleLabel.Text = "Scale";
            // 
            // thumbnailScaleComboBox
            // 
            this.thumbnailScaleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thumbnailScaleComboBox.FormattingEnabled = true;
            this.thumbnailScaleComboBox.Location = new System.Drawing.Point(90, 46);
            this.thumbnailScaleComboBox.Name = "thumbnailScaleComboBox";
            this.thumbnailScaleComboBox.Size = new System.Drawing.Size(123, 21);
            this.thumbnailScaleComboBox.TabIndex = 19;
            // 
            // thumbnailAppearanceGroupBox
            // 
            this.thumbnailAppearanceGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.thumbnailAppearanceGroupBox.Controls.Add(this.thumbnailAppearanceBorderColorPanelControl);
            this.thumbnailAppearanceGroupBox.Controls.Add(this.thumbnailAppearanceBackColorPanelControl);
            this.thumbnailAppearanceGroupBox.Controls.Add(this.borderStyleValueLabel);
            this.thumbnailAppearanceGroupBox.Controls.Add(this.borderWidthValueLabel);
            this.thumbnailAppearanceGroupBox.Controls.Add(this.editThumbnailAppearanceButton);
            this.thumbnailAppearanceGroupBox.Controls.Add(this.borderStyleLabel);
            this.thumbnailAppearanceGroupBox.Controls.Add(this.borderWidthLabel);
            this.thumbnailAppearanceGroupBox.Controls.Add(this.borderColorLabel);
            this.thumbnailAppearanceGroupBox.Controls.Add(this.backColorLabel);
            this.thumbnailAppearanceGroupBox.Controls.Add(this.thumbnailAppearanceComboBox);
            this.thumbnailAppearanceGroupBox.Location = new System.Drawing.Point(280, 10);
            this.thumbnailAppearanceGroupBox.Name = "thumbnailAppearanceGroupBox";
            this.thumbnailAppearanceGroupBox.Size = new System.Drawing.Size(225, 157);
            this.thumbnailAppearanceGroupBox.TabIndex = 21;
            this.thumbnailAppearanceGroupBox.TabStop = false;
            this.thumbnailAppearanceGroupBox.Text = "Thumbnail Appearance";
            // 
            // thumbnailAppearanceBorderColorPanelControl
            // 
            this.thumbnailAppearanceBorderColorPanelControl.CanSetColor = false;
            this.thumbnailAppearanceBorderColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.thumbnailAppearanceBorderColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.thumbnailAppearanceBorderColorPanelControl.Location = new System.Drawing.Point(109, 74);
            this.thumbnailAppearanceBorderColorPanelControl.Name = "thumbnailAppearanceBorderColorPanelControl";
            this.thumbnailAppearanceBorderColorPanelControl.ShowColorName = true;
            this.thumbnailAppearanceBorderColorPanelControl.Size = new System.Drawing.Size(101, 23);
            this.thumbnailAppearanceBorderColorPanelControl.TabIndex = 31;
            // 
            // thumbnailAppearanceBackColorPanelControl
            // 
            this.thumbnailAppearanceBackColorPanelControl.CanSetColor = false;
            this.thumbnailAppearanceBackColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.thumbnailAppearanceBackColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.thumbnailAppearanceBackColorPanelControl.Location = new System.Drawing.Point(109, 45);
            this.thumbnailAppearanceBackColorPanelControl.Name = "thumbnailAppearanceBackColorPanelControl";
            this.thumbnailAppearanceBackColorPanelControl.ShowColorName = true;
            this.thumbnailAppearanceBackColorPanelControl.Size = new System.Drawing.Size(101, 23);
            this.thumbnailAppearanceBackColorPanelControl.TabIndex = 30;
            // 
            // borderStyleValueLabel
            // 
            this.borderStyleValueLabel.Location = new System.Drawing.Point(109, 129);
            this.borderStyleValueLabel.Name = "borderStyleValueLabel";
            this.borderStyleValueLabel.Size = new System.Drawing.Size(103, 19);
            this.borderStyleValueLabel.TabIndex = 29;
            this.borderStyleValueLabel.Text = "borderStyleValue";
            // 
            // borderWidthValueLabel
            // 
            this.borderWidthValueLabel.Location = new System.Drawing.Point(109, 104);
            this.borderWidthValueLabel.Name = "borderWidthValueLabel";
            this.borderWidthValueLabel.Size = new System.Drawing.Size(103, 17);
            this.borderWidthValueLabel.TabIndex = 28;
            this.borderWidthValueLabel.Text = "borderWidthValue";
            // 
            // editThumbnailAppearanceButton
            // 
            this.editThumbnailAppearanceButton.Location = new System.Drawing.Point(109, 16);
            this.editThumbnailAppearanceButton.Name = "editThumbnailAppearanceButton";
            this.editThumbnailAppearanceButton.Size = new System.Drawing.Size(103, 23);
            this.editThumbnailAppearanceButton.TabIndex = 27;
            this.editThumbnailAppearanceButton.Text = "Edit...";
            this.editThumbnailAppearanceButton.UseVisualStyleBackColor = true;
            this.editThumbnailAppearanceButton.Click += new System.EventHandler(this.editThumbnailAppearanceButton_Click);
            // 
            // borderStyleLabel
            // 
            this.borderStyleLabel.AutoSize = true;
            this.borderStyleLabel.Location = new System.Drawing.Point(8, 131);
            this.borderStyleLabel.Name = "borderStyleLabel";
            this.borderStyleLabel.Size = new System.Drawing.Size(64, 13);
            this.borderStyleLabel.TabIndex = 26;
            this.borderStyleLabel.Text = "Border Style";
            // 
            // borderWidthLabel
            // 
            this.borderWidthLabel.AutoSize = true;
            this.borderWidthLabel.Location = new System.Drawing.Point(8, 104);
            this.borderWidthLabel.Name = "borderWidthLabel";
            this.borderWidthLabel.Size = new System.Drawing.Size(69, 13);
            this.borderWidthLabel.TabIndex = 25;
            this.borderWidthLabel.Text = "Border Width";
            // 
            // borderColorLabel
            // 
            this.borderColorLabel.AutoSize = true;
            this.borderColorLabel.Location = new System.Drawing.Point(8, 77);
            this.borderColorLabel.Name = "borderColorLabel";
            this.borderColorLabel.Size = new System.Drawing.Size(65, 13);
            this.borderColorLabel.TabIndex = 23;
            this.borderColorLabel.Text = "Border Color";
            // 
            // backColorLabel
            // 
            this.backColorLabel.AutoSize = true;
            this.backColorLabel.Location = new System.Drawing.Point(8, 48);
            this.backColorLabel.Name = "backColorLabel";
            this.backColorLabel.Size = new System.Drawing.Size(56, 13);
            this.backColorLabel.TabIndex = 21;
            this.backColorLabel.Text = "BackColor";
            // 
            // thumbnailAppearanceComboBox
            // 
            this.thumbnailAppearanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thumbnailAppearanceComboBox.FormattingEnabled = true;
            this.thumbnailAppearanceComboBox.Location = new System.Drawing.Point(8, 17);
            this.thumbnailAppearanceComboBox.Name = "thumbnailAppearanceComboBox";
            this.thumbnailAppearanceComboBox.Size = new System.Drawing.Size(85, 21);
            this.thumbnailAppearanceComboBox.TabIndex = 20;
            this.thumbnailAppearanceComboBox.SelectedIndexChanged += new System.EventHandler(this.thumbnailAppearanceComboBox_SelectedIndexChanged);
            // 
            // thumbnailViewerGroupBox
            // 
            this.thumbnailViewerGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.thumbnailViewerGroupBox.Controls.Add(this.thumbnailViewerBackColorPanelControl);
            this.thumbnailViewerGroupBox.Controls.Add(this.thumbnailRenderingThreadCountNumericUpDown);
            this.thumbnailViewerGroupBox.Controls.Add(this.thumbnailRenderThreadCountLabel);
            this.thumbnailViewerGroupBox.Controls.Add(this.thumbnailViewerBackColorLabel);
            this.thumbnailViewerGroupBox.Controls.Add(this.generateOnlyVisibleThumbnailsCheckBox);
            this.thumbnailViewerGroupBox.Controls.Add(this.flowStyleLabel);
            this.thumbnailViewerGroupBox.Controls.Add(this.thumbnailFlowStyleComboBox);
            this.thumbnailViewerGroupBox.Controls.Add(this.thumbnailColumnsCountComboBox);
            this.thumbnailViewerGroupBox.Controls.Add(this.columnsCountLabel);
            this.thumbnailViewerGroupBox.Location = new System.Drawing.Point(12, 10);
            this.thumbnailViewerGroupBox.Name = "thumbnailViewerGroupBox";
            this.thumbnailViewerGroupBox.Size = new System.Drawing.Size(262, 157);
            this.thumbnailViewerGroupBox.TabIndex = 22;
            this.thumbnailViewerGroupBox.TabStop = false;
            this.thumbnailViewerGroupBox.Text = "Thumbnail Viewer";
            // 
            // thumbnailViewerBackColorPanelControl
            // 
            this.thumbnailViewerBackColorPanelControl.CanEditAlphaChannel = false;
            this.thumbnailViewerBackColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.thumbnailViewerBackColorPanelControl.ColorButtonMargin = 8;
            this.thumbnailViewerBackColorPanelControl.ColorButtonWidth = 28;
            this.thumbnailViewerBackColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.thumbnailViewerBackColorPanelControl.Location = new System.Drawing.Point(116, 98);
            this.thumbnailViewerBackColorPanelControl.Name = "thumbnailViewerBackColorPanelControl";
            this.thumbnailViewerBackColorPanelControl.ShowColorName = true;
            this.thumbnailViewerBackColorPanelControl.Size = new System.Drawing.Size(129, 23);
            this.thumbnailViewerBackColorPanelControl.TabIndex = 27;
            // 
            // thumbnailRenderingThreadCountNumericUpDown
            // 
            this.thumbnailRenderingThreadCountNumericUpDown.Location = new System.Drawing.Point(214, 127);
            this.thumbnailRenderingThreadCountNumericUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.thumbnailRenderingThreadCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thumbnailRenderingThreadCountNumericUpDown.Name = "thumbnailRenderingThreadCountNumericUpDown";
            this.thumbnailRenderingThreadCountNumericUpDown.Size = new System.Drawing.Size(31, 20);
            this.thumbnailRenderingThreadCountNumericUpDown.TabIndex = 26;
            this.thumbnailRenderingThreadCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // thumbnailRenderThreadCountLabel
            // 
            this.thumbnailRenderThreadCountLabel.AutoSize = true;
            this.thumbnailRenderThreadCountLabel.Location = new System.Drawing.Point(12, 131);
            this.thumbnailRenderThreadCountLabel.Name = "thumbnailRenderThreadCountLabel";
            this.thumbnailRenderThreadCountLabel.Size = new System.Drawing.Size(176, 13);
            this.thumbnailRenderThreadCountLabel.TabIndex = 25;
            this.thumbnailRenderThreadCountLabel.Text = "Thumbnail Rendering Thread Count";
            // 
            // thumbnailViewerBackColorLabel
            // 
            this.thumbnailViewerBackColorLabel.AutoSize = true;
            this.thumbnailViewerBackColorLabel.Location = new System.Drawing.Point(12, 102);
            this.thumbnailViewerBackColorLabel.Name = "thumbnailViewerBackColorLabel";
            this.thumbnailViewerBackColorLabel.Size = new System.Drawing.Size(59, 13);
            this.thumbnailViewerBackColorLabel.TabIndex = 19;
            this.thumbnailViewerBackColorLabel.Text = "Back Color";
            // 
            // thumbnailsGroupBox
            // 
            this.thumbnailsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.thumbnailsGroupBox.Controls.Add(this.groupBox1);
            this.thumbnailsGroupBox.Controls.Add(this.thumbnailSizeComboBox);
            this.thumbnailsGroupBox.Controls.Add(this.sizeLabel);
            this.thumbnailsGroupBox.Controls.Add(this.thumbnailScaleComboBox);
            this.thumbnailsGroupBox.Controls.Add(this.scaleLabel);
            this.thumbnailsGroupBox.Controls.Add(this.imagePaddingGroupBox);
            this.thumbnailsGroupBox.Location = new System.Drawing.Point(12, 172);
            this.thumbnailsGroupBox.Name = "thumbnailsGroupBox";
            this.thumbnailsGroupBox.Size = new System.Drawing.Size(493, 122);
            this.thumbnailsGroupBox.TabIndex = 23;
            this.thumbnailsGroupBox.TabStop = false;
            this.thumbnailsGroupBox.Text = "Thumbnails";
            // 
            // imagePaddingGroupBox
            // 
            this.imagePaddingGroupBox.Controls.Add(this.imagePaddingEditorControl);
            this.imagePaddingGroupBox.Location = new System.Drawing.Point(221, 10);
            this.imagePaddingGroupBox.Name = "imagePaddingGroupBox";
            this.imagePaddingGroupBox.Size = new System.Drawing.Size(141, 102);
            this.imagePaddingGroupBox.TabIndex = 26;
            this.imagePaddingGroupBox.TabStop = false;
            this.imagePaddingGroupBox.Text = "Image Padding";
            // 
            // imagePaddingEditorControl
            // 
            this.imagePaddingEditorControl.Location = new System.Drawing.Point(6, 19);
            this.imagePaddingEditorControl.MaximumSize = new System.Drawing.Size(128, 75);
            this.imagePaddingEditorControl.MinimumSize = new System.Drawing.Size(128, 75);
            this.imagePaddingEditorControl.Name = "imagePaddingEditorControl";
            this.imagePaddingEditorControl.Size = new System.Drawing.Size(128, 75);
            this.imagePaddingEditorControl.TabIndex = 24;
            // 
            // thumbnailCaptionGroupBox
            // 
            this.thumbnailCaptionGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.thumbnailCaptionGroupBox.Controls.Add(this.captionAnchorTypeEditor);
            this.thumbnailCaptionGroupBox.Controls.Add(this.captionFormatHelpButton);
            this.thumbnailCaptionGroupBox.Controls.Add(this.captionFormatTextBox);
            this.thumbnailCaptionGroupBox.Controls.Add(this.captionFontlabel);
            this.thumbnailCaptionGroupBox.Controls.Add(this.captionFontSelectButton);
            this.thumbnailCaptionGroupBox.Controls.Add(this.captionTextColorPanelControl);
            this.thumbnailCaptionGroupBox.Controls.Add(this.captionTextColorLabel);
            this.thumbnailCaptionGroupBox.Controls.Add(this.captionAnchorLable);
            this.thumbnailCaptionGroupBox.Controls.Add(this.captionFormatLabel);
            this.thumbnailCaptionGroupBox.Controls.Add(this.captionPaddingGroupBox);
            this.thumbnailCaptionGroupBox.Location = new System.Drawing.Point(12, 300);
            this.thumbnailCaptionGroupBox.Name = "thumbnailCaptionGroupBox";
            this.thumbnailCaptionGroupBox.Size = new System.Drawing.Size(493, 181);
            this.thumbnailCaptionGroupBox.TabIndex = 24;
            this.thumbnailCaptionGroupBox.TabStop = false;
            // 
            // captionAnchorTypeEditor
            // 
            this.captionAnchorTypeEditor.Location = new System.Drawing.Point(116, 53);
            this.captionAnchorTypeEditor.Name = "captionAnchorTypeEditor";
            this.captionAnchorTypeEditor.SelectedAnchorType = ((Vintasoft.Imaging.AnchorType)((((Vintasoft.Imaging.AnchorType.Top | Vintasoft.Imaging.AnchorType.Bottom) 
            | Vintasoft.Imaging.AnchorType.Left) 
            | Vintasoft.Imaging.AnchorType.Right)));
            this.captionAnchorTypeEditor.Size = new System.Drawing.Size(63, 63);
            this.captionAnchorTypeEditor.TabIndex = 33;
            // 
            // captionFormatHelpButton
            // 
            this.captionFormatHelpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.captionFormatHelpButton.Location = new System.Drawing.Point(440, 24);
            this.captionFormatHelpButton.Name = "captionFormatHelpButton";
            this.captionFormatHelpButton.Size = new System.Drawing.Size(38, 21);
            this.captionFormatHelpButton.TabIndex = 25;
            this.captionFormatHelpButton.Text = "?";
            this.captionFormatHelpButton.UseVisualStyleBackColor = true;
            this.captionFormatHelpButton.Click += new System.EventHandler(this.captionFormatHelpButton_Click);
            // 
            // captionFormatTextBox
            // 
            this.captionFormatTextBox.Location = new System.Drawing.Point(116, 24);
            this.captionFormatTextBox.Name = "captionFormatTextBox";
            this.captionFormatTextBox.Size = new System.Drawing.Size(318, 20);
            this.captionFormatTextBox.TabIndex = 29;
            // 
            // captionFontlabel
            // 
            this.captionFontlabel.AutoSize = true;
            this.captionFontlabel.Location = new System.Drawing.Point(12, 154);
            this.captionFontlabel.Name = "captionFontlabel";
            this.captionFontlabel.Size = new System.Drawing.Size(67, 13);
            this.captionFontlabel.TabIndex = 31;
            this.captionFontlabel.Text = "Caption Font";
            // 
            // captionFontSelectButton
            // 
            this.captionFontSelectButton.Location = new System.Drawing.Point(116, 150);
            this.captionFontSelectButton.Name = "captionFontSelectButton";
            this.captionFontSelectButton.Size = new System.Drawing.Size(129, 23);
            this.captionFontSelectButton.TabIndex = 30;
            this.captionFontSelectButton.Text = "Select Font...";
            this.captionFontSelectButton.Click += new System.EventHandler(this.captionFontSelectButton_Click);
            // 
            // captionTextColorPanelControl
            // 
            this.captionTextColorPanelControl.CanEditAlphaChannel = false;
            this.captionTextColorPanelControl.Color = System.Drawing.Color.Black;
            this.captionTextColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.captionTextColorPanelControl.Location = new System.Drawing.Point(116, 122);
            this.captionTextColorPanelControl.Name = "captionTextColorPanelControl";
            this.captionTextColorPanelControl.Size = new System.Drawing.Size(129, 22);
            this.captionTextColorPanelControl.TabIndex = 27;
            // 
            // captionTextColorLabel
            // 
            this.captionTextColorLabel.AutoSize = true;
            this.captionTextColorLabel.Location = new System.Drawing.Point(12, 126);
            this.captionTextColorLabel.Name = "captionTextColorLabel";
            this.captionTextColorLabel.Size = new System.Drawing.Size(94, 13);
            this.captionTextColorLabel.TabIndex = 21;
            this.captionTextColorLabel.Text = "Caption Text Color";
            // 
            // captionAnchorLable
            // 
            this.captionAnchorLable.AutoSize = true;
            this.captionAnchorLable.Location = new System.Drawing.Point(12, 77);
            this.captionAnchorLable.Name = "captionAnchorLable";
            this.captionAnchorLable.Size = new System.Drawing.Size(80, 13);
            this.captionAnchorLable.TabIndex = 21;
            this.captionAnchorLable.Text = "Caption Anchor";
            // 
            // captionFormatLabel
            // 
            this.captionFormatLabel.AutoSize = true;
            this.captionFormatLabel.Location = new System.Drawing.Point(12, 27);
            this.captionFormatLabel.Name = "captionFormatLabel";
            this.captionFormatLabel.Size = new System.Drawing.Size(78, 13);
            this.captionFormatLabel.TabIndex = 21;
            this.captionFormatLabel.Text = "Caption Format";
            // 
            // captionPaddingGroupBox
            // 
            this.captionPaddingGroupBox.Controls.Add(this.captionPaddingFEditorControl);
            this.captionPaddingGroupBox.Location = new System.Drawing.Point(268, 53);
            this.captionPaddingGroupBox.Name = "captionPaddingGroupBox";
            this.captionPaddingGroupBox.Size = new System.Drawing.Size(210, 102);
            this.captionPaddingGroupBox.TabIndex = 32;
            this.captionPaddingGroupBox.TabStop = false;
            this.captionPaddingGroupBox.Text = "Padding";
            // 
            // captionPaddingFEditorControl
            // 
            this.captionPaddingFEditorControl.Location = new System.Drawing.Point(44, 19);
            this.captionPaddingFEditorControl.MaximumSize = new System.Drawing.Size(128, 75);
            this.captionPaddingFEditorControl.MinimumSize = new System.Drawing.Size(128, 75);
            this.captionPaddingFEditorControl.Name = "captionPaddingFEditorControl";
            this.captionPaddingFEditorControl.Size = new System.Drawing.Size(128, 75);
            this.captionPaddingFEditorControl.TabIndex = 28;
            // 
            // captionIsVisibleCheckBox
            // 
            this.captionIsVisibleCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.captionIsVisibleCheckBox.AutoSize = true;
            this.captionIsVisibleCheckBox.Checked = true;
            this.captionIsVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.captionIsVisibleCheckBox.Location = new System.Drawing.Point(19, 299);
            this.captionIsVisibleCheckBox.Name = "captionIsVisibleCheckBox";
            this.captionIsVisibleCheckBox.Size = new System.Drawing.Size(114, 17);
            this.captionIsVisibleCheckBox.TabIndex = 0;
            this.captionIsVisibleCheckBox.Text = "Thumbnail Caption";
            this.captionIsVisibleCheckBox.UseVisualStyleBackColor = true;
            this.captionIsVisibleCheckBox.CheckedChanged += new System.EventHandler(this.captionIsVisibleCheckBox_CheckedChanged);
            // 
            // thumbnailControlGroupBox
            // 
            this.thumbnailControlGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.thumbnailControlGroupBox.Controls.Add(this.showThumbnailCheckBoxCheckBox);
            this.thumbnailControlGroupBox.Controls.Add(this.thumbnailControlAnchorTypeEditor);
            this.thumbnailControlGroupBox.Controls.Add(this.thumbnailControlAnchorLabel);
            this.thumbnailControlGroupBox.Controls.Add(this.thumbnailControlPaddingGroupBox);
            this.thumbnailControlGroupBox.Location = new System.Drawing.Point(12, 487);
            this.thumbnailControlGroupBox.Name = "thumbnailControlGroupBox";
            this.thumbnailControlGroupBox.Size = new System.Drawing.Size(493, 122);
            this.thumbnailControlGroupBox.TabIndex = 27;
            this.thumbnailControlGroupBox.TabStop = false;
            this.thumbnailControlGroupBox.Text = "Thumbnail Control";
            // 
            // showThumbnailCheckBoxCheckBox
            // 
            this.showThumbnailCheckBoxCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.showThumbnailCheckBoxCheckBox.AutoSize = true;
            this.showThumbnailCheckBoxCheckBox.Checked = true;
            this.showThumbnailCheckBoxCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showThumbnailCheckBoxCheckBox.Location = new System.Drawing.Point(15, 24);
            this.showThumbnailCheckBoxCheckBox.Name = "showThumbnailCheckBoxCheckBox";
            this.showThumbnailCheckBoxCheckBox.Size = new System.Drawing.Size(157, 17);
            this.showThumbnailCheckBoxCheckBox.TabIndex = 29;
            this.showThumbnailCheckBoxCheckBox.Text = "Show Thumbnail CheckBox";
            this.showThumbnailCheckBoxCheckBox.UseVisualStyleBackColor = true;
            // 
            // thumbnailControlAnchorTypeEditor
            // 
            this.thumbnailControlAnchorTypeEditor.Location = new System.Drawing.Point(116, 48);
            this.thumbnailControlAnchorTypeEditor.Name = "thumbnailControlAnchorTypeEditor";
            this.thumbnailControlAnchorTypeEditor.SelectedAnchorType = ((Vintasoft.Imaging.AnchorType)((((Vintasoft.Imaging.AnchorType.Top | Vintasoft.Imaging.AnchorType.Bottom) 
            | Vintasoft.Imaging.AnchorType.Left) 
            | Vintasoft.Imaging.AnchorType.Right)));
            this.thumbnailControlAnchorTypeEditor.Size = new System.Drawing.Size(63, 63);
            this.thumbnailControlAnchorTypeEditor.TabIndex = 34;
            // 
            // thumbnailControlAnchorLabel
            // 
            this.thumbnailControlAnchorLabel.AutoSize = true;
            this.thumbnailControlAnchorLabel.Location = new System.Drawing.Point(12, 71);
            this.thumbnailControlAnchorLabel.Name = "thumbnailControlAnchorLabel";
            this.thumbnailControlAnchorLabel.Size = new System.Drawing.Size(77, 13);
            this.thumbnailControlAnchorLabel.TabIndex = 20;
            this.thumbnailControlAnchorLabel.Text = "Control Anchor";
            // 
            // thumbnailControlPaddingGroupBox
            // 
            this.thumbnailControlPaddingGroupBox.Controls.Add(this.thumbnailControlPaddingFEditorControl);
            this.thumbnailControlPaddingGroupBox.Location = new System.Drawing.Point(268, 14);
            this.thumbnailControlPaddingGroupBox.Name = "thumbnailControlPaddingGroupBox";
            this.thumbnailControlPaddingGroupBox.Size = new System.Drawing.Size(210, 102);
            this.thumbnailControlPaddingGroupBox.TabIndex = 26;
            this.thumbnailControlPaddingGroupBox.TabStop = false;
            this.thumbnailControlPaddingGroupBox.Text = "Control Padding";
            // 
            // thumbnailControlPaddingFEditorControl
            // 
            this.thumbnailControlPaddingFEditorControl.Location = new System.Drawing.Point(44, 19);
            this.thumbnailControlPaddingFEditorControl.MaximumSize = new System.Drawing.Size(128, 75);
            this.thumbnailControlPaddingFEditorControl.MinimumSize = new System.Drawing.Size(128, 75);
            this.thumbnailControlPaddingFEditorControl.Name = "thumbnailControlPaddingFEditorControl";
            this.thumbnailControlPaddingFEditorControl.Size = new System.Drawing.Size(128, 75);
            this.thumbnailControlPaddingFEditorControl.TabIndex = 24;
            // 
            // thumbnailsAnchorEditorControl
            // 
            this.thumbnailsAnchorEditorControl.Location = new System.Drawing.Point(27, 22);
            this.thumbnailsAnchorEditorControl.Name = "thumbnailsAnchorEditorControl";
            this.thumbnailsAnchorEditorControl.SelectedAnchorType = ((Vintasoft.Imaging.AnchorType)((((Vintasoft.Imaging.AnchorType.Top | Vintasoft.Imaging.AnchorType.Bottom) 
            | Vintasoft.Imaging.AnchorType.Left) 
            | Vintasoft.Imaging.AnchorType.Right)));
            this.thumbnailsAnchorEditorControl.Size = new System.Drawing.Size(63, 63);
            this.thumbnailsAnchorEditorControl.TabIndex = 34;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.thumbnailsAnchorEditorControl);
            this.groupBox1.Location = new System.Drawing.Point(369, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 102);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thumbnails Anchor";
            // 
            // ThumbnailViewerSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(517, 653);
            this.Controls.Add(this.thumbnailControlGroupBox);
            this.Controls.Add(this.captionIsVisibleCheckBox);
            this.Controls.Add(this.thumbnailCaptionGroupBox);
            this.Controls.Add(this.thumbnailsGroupBox);
            this.Controls.Add(this.thumbnailViewerGroupBox);
            this.Controls.Add(this.thumbnailAppearanceGroupBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThumbnailViewerSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thumbnail Viewer Settings";
            this.thumbnailAppearanceGroupBox.ResumeLayout(false);
            this.thumbnailAppearanceGroupBox.PerformLayout();
            this.thumbnailViewerGroupBox.ResumeLayout(false);
            this.thumbnailViewerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailRenderingThreadCountNumericUpDown)).EndInit();
            this.thumbnailsGroupBox.ResumeLayout(false);
            this.thumbnailsGroupBox.PerformLayout();
            this.imagePaddingGroupBox.ResumeLayout(false);
            this.thumbnailCaptionGroupBox.ResumeLayout(false);
            this.thumbnailCaptionGroupBox.PerformLayout();
            this.captionPaddingGroupBox.ResumeLayout(false);
            this.thumbnailControlGroupBox.ResumeLayout(false);
            this.thumbnailControlGroupBox.PerformLayout();
            this.thumbnailControlPaddingGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox thumbnailSizeComboBox;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.CheckBox generateOnlyVisibleThumbnailsCheckBox;
        private System.Windows.Forms.ComboBox thumbnailFlowStyleComboBox;
        private System.Windows.Forms.Label flowStyleLabel;
        private System.Windows.Forms.ComboBox thumbnailColumnsCountComboBox;
        private System.Windows.Forms.Label columnsCountLabel;
        private System.Windows.Forms.Label scaleLabel;
        private System.Windows.Forms.ComboBox thumbnailScaleComboBox;
        private System.Windows.Forms.GroupBox thumbnailAppearanceGroupBox;
        private System.Windows.Forms.ComboBox thumbnailAppearanceComboBox;
        private System.Windows.Forms.Label backColorLabel;
        private System.Windows.Forms.Label borderColorLabel;
        private System.Windows.Forms.Label borderWidthLabel;
        private System.Windows.Forms.Label borderStyleLabel;
        private System.Windows.Forms.Button editThumbnailAppearanceButton;
        private System.Windows.Forms.Label borderStyleValueLabel;
        private System.Windows.Forms.Label borderWidthValueLabel;
        private System.Windows.Forms.GroupBox thumbnailViewerGroupBox;
        private System.Windows.Forms.GroupBox thumbnailsGroupBox;
        private System.Windows.Forms.Label thumbnailViewerBackColorLabel;
        private System.Windows.Forms.ColorDialog thumbnailViewerBackColorDialog;
        private System.Windows.Forms.NumericUpDown thumbnailRenderingThreadCountNumericUpDown;
        private System.Windows.Forms.Label thumbnailRenderThreadCountLabel;
        private DemosCommonCode.CustomControls.ColorPanelControl thumbnailViewerBackColorPanelControl;
        private DemosCommonCode.CustomControls.ColorPanelControl thumbnailAppearanceBackColorPanelControl;
        private DemosCommonCode.CustomControls.ColorPanelControl thumbnailAppearanceBorderColorPanelControl;
        private DemosCommonCode.CustomControls.PaddingFEditorControl imagePaddingEditorControl;
        private System.Windows.Forms.GroupBox thumbnailCaptionGroupBox;
        private System.Windows.Forms.CheckBox captionIsVisibleCheckBox;
        private System.Windows.Forms.Label captionFormatLabel;
        private System.Windows.Forms.Label captionAnchorLable;
        private DemosCommonCode.CustomControls.ColorPanelControl captionTextColorPanelControl;
        private System.Windows.Forms.Label captionTextColorLabel;
        private DemosCommonCode.CustomControls.PaddingFEditorControl captionPaddingFEditorControl;
        private System.Windows.Forms.TextBox captionFormatTextBox;
        private System.Windows.Forms.Label captionFontlabel;
        private System.Windows.Forms.Button captionFontSelectButton;
        private System.Windows.Forms.FontDialog captionFontDialog;
        private System.Windows.Forms.GroupBox captionPaddingGroupBox;
        private System.Windows.Forms.GroupBox imagePaddingGroupBox;
        private System.Windows.Forms.Button captionFormatHelpButton;
        private DemosCommonCode.CustomControls.AnchorTypeEditorControl captionAnchorTypeEditor;
        private System.Windows.Forms.GroupBox thumbnailControlGroupBox;
        private CustomControls.AnchorTypeEditorControl thumbnailControlAnchorTypeEditor;
        private System.Windows.Forms.Label thumbnailControlAnchorLabel;
        private System.Windows.Forms.GroupBox thumbnailControlPaddingGroupBox;
        private CustomControls.PaddingFEditorControl thumbnailControlPaddingFEditorControl;
        private System.Windows.Forms.CheckBox showThumbnailCheckBoxCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomControls.AnchorTypeEditorControl thumbnailsAnchorEditorControl;
    }
}