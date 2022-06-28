namespace DemosCommonCode.Imaging
{
    partial class ImageViewerSettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.focusPointAnchorTypeEditor = new DemosCommonCode.CustomControls.AnchorTypeEditorControl();
            this.focusPointIsFixedCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.minImageSizeWhenZoomBufferUsedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rendererCacheSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.viewerBufferSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.renderingQualityComboBox = new System.Windows.Forms.ComboBox();
            this.renderingSettingsButton = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.renderingRequirementsButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.renderOnlyVisibleImagesCheckBox = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.maxThreadsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.previewIntervalOfVectorImagesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.vectorRenderingQualityFactorTrackBar = new System.Windows.Forms.TrackBar();
            this.imagesDisplayModeGroupBox = new System.Windows.Forms.GroupBox();
            this.multipageDisplayModeComboBox = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.focusedImageAppearanceButton = new System.Windows.Forms.Button();
            this.imageAppearanceButton = new System.Windows.Forms.Button();
            this.useImageAppearancesInSinglepageModeCheckBox = new System.Windows.Forms.CheckBox();
            this.imagesPaddingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.imagesInRowColumnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.layoutDirectionComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.keyboardNavigationGroupBox = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.keyboardNavigationZoomStepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.keyboardNavigationScrollStepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.keyboardNavigationCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.imageAnchorTypeEditor = new DemosCommonCode.CustomControls.AnchorTypeEditorControl();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minImageSizeWhenZoomBufferUsedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rendererCacheSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewerBufferSizeNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxThreadsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewIntervalOfVectorImagesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorRenderingQualityFactorTrackBar)).BeginInit();
            this.imagesDisplayModeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagesPaddingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagesInRowColumnNumericUpDown)).BeginInit();
            this.keyboardNavigationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyboardNavigationZoomStepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyboardNavigationScrollStepNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.focusPointAnchorTypeEditor);
            this.groupBox1.Controls.Add(this.focusPointIsFixedCheckBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(11, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Focus point";
            // 
            // focusPointAnchorTypeEditor
            // 
            this.focusPointAnchorTypeEditor.Location = new System.Drawing.Point(177, 14);
            this.focusPointAnchorTypeEditor.Name = "focusPointAnchorTypeEditor";
            this.focusPointAnchorTypeEditor.SelectedAnchorType = ((Vintasoft.Imaging.AnchorType)((((Vintasoft.Imaging.AnchorType.Top | Vintasoft.Imaging.AnchorType.Bottom) 
            | Vintasoft.Imaging.AnchorType.Left) 
            | Vintasoft.Imaging.AnchorType.Right)));
            this.focusPointAnchorTypeEditor.Size = new System.Drawing.Size(63, 63);
            this.focusPointAnchorTypeEditor.TabIndex = 8;
            // 
            // focusPointIsFixedCheckBox
            // 
            this.focusPointIsFixedCheckBox.AutoSize = true;
            this.focusPointIsFixedCheckBox.Location = new System.Drawing.Point(6, 78);
            this.focusPointIsFixedCheckBox.Name = "focusPointIsFixedCheckBox";
            this.focusPointIsFixedCheckBox.Size = new System.Drawing.Size(51, 17);
            this.focusPointIsFixedCheckBox.TabIndex = 7;
            this.focusPointIsFixedCheckBox.Text = "Fixed";
            this.focusPointIsFixedCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Anchor";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.minImageSizeWhenZoomBufferUsedNumericUpDown);
            this.groupBox3.Controls.Add(this.rendererCacheSizeNumericUpDown);
            this.groupBox3.Controls.Add(this.viewerBufferSizeNumericUpDown);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(371, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 81);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buffering";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(317, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Megapixels";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(317, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Megabytes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(317, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Megapixels";
            // 
            // minImageSizeWhenZoomBufferUsedNumericUpDown
            // 
            this.minImageSizeWhenZoomBufferUsedNumericUpDown.Location = new System.Drawing.Point(245, 55);
            this.minImageSizeWhenZoomBufferUsedNumericUpDown.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.minImageSizeWhenZoomBufferUsedNumericUpDown.Name = "minImageSizeWhenZoomBufferUsedNumericUpDown";
            this.minImageSizeWhenZoomBufferUsedNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.minImageSizeWhenZoomBufferUsedNumericUpDown.TabIndex = 9;
            // 
            // rendererCacheSizeNumericUpDown
            // 
            this.rendererCacheSizeNumericUpDown.Location = new System.Drawing.Point(245, 11);
            this.rendererCacheSizeNumericUpDown.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.rendererCacheSizeNumericUpDown.Name = "rendererCacheSizeNumericUpDown";
            this.rendererCacheSizeNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.rendererCacheSizeNumericUpDown.TabIndex = 10;
            // 
            // viewerBufferSizeNumericUpDown
            // 
            this.viewerBufferSizeNumericUpDown.Location = new System.Drawing.Point(245, 33);
            this.viewerBufferSizeNumericUpDown.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.viewerBufferSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.viewerBufferSizeNumericUpDown.Name = "viewerBufferSizeNumericUpDown";
            this.viewerBufferSizeNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.viewerBufferSizeNumericUpDown.TabIndex = 8;
            this.viewerBufferSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Min Image Size when Zoom Buffer used";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Renderer Cache Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Viewer Buffer Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Image Anchor";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Rendering quality";
            // 
            // renderingQualityComboBox
            // 
            this.renderingQualityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.renderingQualityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.renderingQualityComboBox.FormattingEnabled = true;
            this.renderingQualityComboBox.Location = new System.Drawing.Point(245, 21);
            this.renderingQualityComboBox.Name = "renderingQualityComboBox";
            this.renderingQualityComboBox.Size = new System.Drawing.Size(134, 21);
            this.renderingQualityComboBox.TabIndex = 6;
            // 
            // renderingSettingsButton
            // 
            this.renderingSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.renderingSettingsButton.Location = new System.Drawing.Point(10, 49);
            this.renderingSettingsButton.Name = "renderingSettingsButton";
            this.renderingSettingsButton.Size = new System.Drawing.Size(370, 23);
            this.renderingSettingsButton.TabIndex = 7;
            this.renderingSettingsButton.Text = "Image Rendering Settings...";
            this.renderingSettingsButton.UseVisualStyleBackColor = true;
            this.renderingSettingsButton.Click += new System.EventHandler(this.renderingSettingsButton_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(592, 421);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(81, 23);
            this.buttonOk.TabIndex = 9;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(679, 421);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Background Color";
            // 
            // renderingRequirementsButton
            // 
            this.renderingRequirementsButton.Location = new System.Drawing.Point(9, 79);
            this.renderingRequirementsButton.Name = "renderingRequirementsButton";
            this.renderingRequirementsButton.Size = new System.Drawing.Size(370, 23);
            this.renderingRequirementsButton.TabIndex = 14;
            this.renderingRequirementsButton.Text = "Partial/Progressive Rendering Requirements...";
            this.renderingRequirementsButton.UseVisualStyleBackColor = true;
            this.renderingRequirementsButton.Click += new System.EventHandler(this.renderingRequirementsButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.renderOnlyVisibleImagesCheckBox);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.maxThreadsNumericUpDown);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.previewIntervalOfVectorImagesNumericUpDown);
            this.groupBox2.Controls.Add(this.renderingSettingsButton);
            this.groupBox2.Controls.Add(this.renderingQualityComboBox);
            this.groupBox2.Controls.Add(this.renderingRequirementsButton);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.vectorRenderingQualityFactorTrackBar);
            this.groupBox2.Location = new System.Drawing.Point(371, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 240);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rendering";
            // 
            // renderOnlyVisibleImagesCheckBox
            // 
            this.renderOnlyVisibleImagesCheckBox.AutoSize = true;
            this.renderOnlyVisibleImagesCheckBox.Location = new System.Drawing.Point(9, 216);
            this.renderOnlyVisibleImagesCheckBox.Name = "renderOnlyVisibleImagesCheckBox";
            this.renderOnlyVisibleImagesCheckBox.Size = new System.Drawing.Size(151, 17);
            this.renderOnlyVisibleImagesCheckBox.TabIndex = 16;
            this.renderOnlyVisibleImagesCheckBox.Text = "Render only visible images";
            this.renderOnlyVisibleImagesCheckBox.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 194);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 13);
            this.label20.TabIndex = 24;
            this.label20.Text = "Max threads";
            // 
            // maxThreadsNumericUpDown
            // 
            this.maxThreadsNumericUpDown.Location = new System.Drawing.Point(240, 192);
            this.maxThreadsNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxThreadsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxThreadsNumericUpDown.Name = "maxThreadsNumericUpDown";
            this.maxThreadsNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.maxThreadsNumericUpDown.TabIndex = 23;
            this.maxThreadsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(336, 170);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Highest";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(238, 170);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Normal";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(200, 26);
            this.label13.TabIndex = 18;
            this.label13.Text = "Rendering quality factor of vector images\r\n(when rendering enabled)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(167, 26);
            this.label12.TabIndex = 17;
            this.label12.Text = "Preview interval of loading images\r\n(when rendering enabled)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(315, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Milliseconds";
            // 
            // previewIntervalOfVectorImagesNumericUpDown
            // 
            this.previewIntervalOfVectorImagesNumericUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.previewIntervalOfVectorImagesNumericUpDown.Location = new System.Drawing.Point(240, 114);
            this.previewIntervalOfVectorImagesNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.previewIntervalOfVectorImagesNumericUpDown.Name = "previewIntervalOfVectorImagesNumericUpDown";
            this.previewIntervalOfVectorImagesNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.previewIntervalOfVectorImagesNumericUpDown.TabIndex = 15;
            this.previewIntervalOfVectorImagesNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // vectorRenderingQualityFactorTrackBar
            // 
            this.vectorRenderingQualityFactorTrackBar.AutoSize = false;
            this.vectorRenderingQualityFactorTrackBar.Location = new System.Drawing.Point(240, 140);
            this.vectorRenderingQualityFactorTrackBar.Maximum = 4;
            this.vectorRenderingQualityFactorTrackBar.Name = "vectorRenderingQualityFactorTrackBar";
            this.vectorRenderingQualityFactorTrackBar.Size = new System.Drawing.Size(132, 31);
            this.vectorRenderingQualityFactorTrackBar.TabIndex = 19;
            // 
            // imagesDisplayModeGroupBox
            // 
            this.imagesDisplayModeGroupBox.Controls.Add(this.multipageDisplayModeComboBox);
            this.imagesDisplayModeGroupBox.Controls.Add(this.label19);
            this.imagesDisplayModeGroupBox.Controls.Add(this.focusedImageAppearanceButton);
            this.imagesDisplayModeGroupBox.Controls.Add(this.imageAppearanceButton);
            this.imagesDisplayModeGroupBox.Controls.Add(this.useImageAppearancesInSinglepageModeCheckBox);
            this.imagesDisplayModeGroupBox.Controls.Add(this.imagesPaddingNumericUpDown);
            this.imagesDisplayModeGroupBox.Controls.Add(this.imagesInRowColumnNumericUpDown);
            this.imagesDisplayModeGroupBox.Controls.Add(this.label18);
            this.imagesDisplayModeGroupBox.Controls.Add(this.label17);
            this.imagesDisplayModeGroupBox.Controls.Add(this.layoutDirectionComboBox);
            this.imagesDisplayModeGroupBox.Controls.Add(this.label14);
            this.imagesDisplayModeGroupBox.Location = new System.Drawing.Point(11, 216);
            this.imagesDisplayModeGroupBox.Name = "imagesDisplayModeGroupBox";
            this.imagesDisplayModeGroupBox.Size = new System.Drawing.Size(354, 193);
            this.imagesDisplayModeGroupBox.TabIndex = 16;
            this.imagesDisplayModeGroupBox.TabStop = false;
            this.imagesDisplayModeGroupBox.Text = "Images Display Mode";
            // 
            // multipageDisplayModeComboBox
            // 
            this.multipageDisplayModeComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.multipageDisplayModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.multipageDisplayModeComboBox.FormattingEnabled = true;
            this.multipageDisplayModeComboBox.Location = new System.Drawing.Point(183, 17);
            this.multipageDisplayModeComboBox.Name = "multipageDisplayModeComboBox";
            this.multipageDisplayModeComboBox.Size = new System.Drawing.Size(165, 21);
            this.multipageDisplayModeComboBox.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(117, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Multipage display mode";
            // 
            // focusedImageAppearanceButton
            // 
            this.focusedImageAppearanceButton.Location = new System.Drawing.Point(183, 132);
            this.focusedImageAppearanceButton.Name = "focusedImageAppearanceButton";
            this.focusedImageAppearanceButton.Size = new System.Drawing.Size(165, 23);
            this.focusedImageAppearanceButton.TabIndex = 13;
            this.focusedImageAppearanceButton.Text = "Focused Image Appearance...";
            this.focusedImageAppearanceButton.UseVisualStyleBackColor = true;
            this.focusedImageAppearanceButton.Click += new System.EventHandler(this.focusedImageAppearance_Click);
            // 
            // imageAppearanceButton
            // 
            this.imageAppearanceButton.Location = new System.Drawing.Point(9, 132);
            this.imageAppearanceButton.Name = "imageAppearanceButton";
            this.imageAppearanceButton.Size = new System.Drawing.Size(165, 23);
            this.imageAppearanceButton.TabIndex = 12;
            this.imageAppearanceButton.Text = "Image Appearance...";
            this.imageAppearanceButton.UseVisualStyleBackColor = true;
            this.imageAppearanceButton.Click += new System.EventHandler(this.imageAppearance_Click);
            // 
            // useImageAppearancesInSinglepageModeCheckBox
            // 
            this.useImageAppearancesInSinglepageModeCheckBox.AutoSize = true;
            this.useImageAppearancesInSinglepageModeCheckBox.Location = new System.Drawing.Point(9, 161);
            this.useImageAppearancesInSinglepageModeCheckBox.Name = "useImageAppearancesInSinglepageModeCheckBox";
            this.useImageAppearancesInSinglepageModeCheckBox.Size = new System.Drawing.Size(238, 17);
            this.useImageAppearancesInSinglepageModeCheckBox.TabIndex = 11;
            this.useImageAppearancesInSinglepageModeCheckBox.Text = "Use image appearances in single-page mode";
            this.useImageAppearancesInSinglepageModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // imagesPaddingNumericUpDown
            // 
            this.imagesPaddingNumericUpDown.Location = new System.Drawing.Point(291, 100);
            this.imagesPaddingNumericUpDown.Name = "imagesPaddingNumericUpDown";
            this.imagesPaddingNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.imagesPaddingNumericUpDown.TabIndex = 6;
            // 
            // imagesInRowColumnNumericUpDown
            // 
            this.imagesInRowColumnNumericUpDown.Location = new System.Drawing.Point(291, 74);
            this.imagesInRowColumnNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.imagesInRowColumnNumericUpDown.Name = "imagesInRowColumnNumericUpDown";
            this.imagesInRowColumnNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.imagesInRowColumnNumericUpDown.TabIndex = 5;
            this.imagesInRowColumnNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 102);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Images padding";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Images in row/column";
            // 
            // layoutDirectionComboBox
            // 
            this.layoutDirectionComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.layoutDirectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layoutDirectionComboBox.FormattingEnabled = true;
            this.layoutDirectionComboBox.Location = new System.Drawing.Point(183, 44);
            this.layoutDirectionComboBox.Name = "layoutDirectionComboBox";
            this.layoutDirectionComboBox.Size = new System.Drawing.Size(165, 21);
            this.layoutDirectionComboBox.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Layout direction";
            // 
            // keyboardNavigationGroupBox
            // 
            this.keyboardNavigationGroupBox.Controls.Add(this.label22);
            this.keyboardNavigationGroupBox.Controls.Add(this.keyboardNavigationZoomStepNumericUpDown);
            this.keyboardNavigationGroupBox.Controls.Add(this.label21);
            this.keyboardNavigationGroupBox.Controls.Add(this.keyboardNavigationScrollStepNumericUpDown);
            this.keyboardNavigationGroupBox.Location = new System.Drawing.Point(371, 336);
            this.keyboardNavigationGroupBox.Name = "keyboardNavigationGroupBox";
            this.keyboardNavigationGroupBox.Size = new System.Drawing.Size(389, 73);
            this.keyboardNavigationGroupBox.TabIndex = 8;
            this.keyboardNavigationGroupBox.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 47);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(155, 13);
            this.label22.TabIndex = 27;
            this.label22.Text = "Keyboard navigation zoom step";
            // 
            // keyboardNavigationZoomStepNumericUpDown
            // 
            this.keyboardNavigationZoomStepNumericUpDown.Location = new System.Drawing.Point(315, 45);
            this.keyboardNavigationZoomStepNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.keyboardNavigationZoomStepNumericUpDown.Name = "keyboardNavigationZoomStepNumericUpDown";
            this.keyboardNavigationZoomStepNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.keyboardNavigationZoomStepNumericUpDown.TabIndex = 26;
            this.keyboardNavigationZoomStepNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(174, 13);
            this.label21.TabIndex = 16;
            this.label21.Text = "Keyboard navigation scroll step (px)";
            // 
            // keyboardNavigationScrollStepNumericUpDown
            // 
            this.keyboardNavigationScrollStepNumericUpDown.Location = new System.Drawing.Point(315, 19);
            this.keyboardNavigationScrollStepNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.keyboardNavigationScrollStepNumericUpDown.Name = "keyboardNavigationScrollStepNumericUpDown";
            this.keyboardNavigationScrollStepNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.keyboardNavigationScrollStepNumericUpDown.TabIndex = 16;
            this.keyboardNavigationScrollStepNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // keyboardNavigationCheckBox
            // 
            this.keyboardNavigationCheckBox.AutoSize = true;
            this.keyboardNavigationCheckBox.Location = new System.Drawing.Point(383, 334);
            this.keyboardNavigationCheckBox.Name = "keyboardNavigationCheckBox";
            this.keyboardNavigationCheckBox.Size = new System.Drawing.Size(123, 17);
            this.keyboardNavigationCheckBox.TabIndex = 25;
            this.keyboardNavigationCheckBox.Text = "Keyboard navigation";
            this.keyboardNavigationCheckBox.UseVisualStyleBackColor = true;
            this.keyboardNavigationCheckBox.CheckedChanged += new System.EventHandler(this.keyboardNavigationCheckBox_CheckedChanged);
            // 
            // backgroundColorPanelControl
            // 
            this.backgroundColorPanelControl.CanEditAlphaChannel = false;
            this.backgroundColorPanelControl.Color = System.Drawing.SystemColors.Control;
            this.backgroundColorPanelControl.ColorButtonMargin = 6;
            this.backgroundColorPanelControl.ColorButtonWidth = 32;
            this.backgroundColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.backgroundColorPanelControl.Location = new System.Drawing.Point(194, 78);
            this.backgroundColorPanelControl.Name = "backgroundColorPanelControl";
            this.backgroundColorPanelControl.Size = new System.Drawing.Size(165, 22);
            this.backgroundColorPanelControl.TabIndex = 8;
            // 
            // imageAnchorTypeEditor
            // 
            this.imageAnchorTypeEditor.Location = new System.Drawing.Point(188, 6);
            this.imageAnchorTypeEditor.Name = "imageAnchorTypeEditor";
            this.imageAnchorTypeEditor.SelectedAnchorType = ((Vintasoft.Imaging.AnchorType)((((Vintasoft.Imaging.AnchorType.Top | Vintasoft.Imaging.AnchorType.Bottom) 
            | Vintasoft.Imaging.AnchorType.Left) 
            | Vintasoft.Imaging.AnchorType.Right)));
            this.imageAnchorTypeEditor.Size = new System.Drawing.Size(63, 63);
            this.imageAnchorTypeEditor.TabIndex = 26;
            // 
            // ImageViewerSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(765, 450);
            this.Controls.Add(this.imageAnchorTypeEditor);
            this.Controls.Add(this.keyboardNavigationCheckBox);
            this.Controls.Add(this.keyboardNavigationGroupBox);
            this.Controls.Add(this.imagesDisplayModeGroupBox);
            this.Controls.Add(this.backgroundColorPanelControl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageViewerSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Viewer Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minImageSizeWhenZoomBufferUsedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rendererCacheSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewerBufferSizeNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxThreadsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewIntervalOfVectorImagesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorRenderingQualityFactorTrackBar)).EndInit();
            this.imagesDisplayModeGroupBox.ResumeLayout(false);
            this.imagesDisplayModeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagesPaddingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagesInRowColumnNumericUpDown)).EndInit();
            this.keyboardNavigationGroupBox.ResumeLayout(false);
            this.keyboardNavigationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyboardNavigationZoomStepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyboardNavigationScrollStepNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox focusPointIsFixedCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox renderingQualityComboBox;
        private System.Windows.Forms.Button renderingSettingsButton;
        private System.Windows.Forms.NumericUpDown rendererCacheSizeNumericUpDown;
        private System.Windows.Forms.NumericUpDown viewerBufferSizeNumericUpDown;
        private System.Windows.Forms.NumericUpDown minImageSizeWhenZoomBufferUsedNumericUpDown;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button renderingRequirementsButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown previewIntervalOfVectorImagesNumericUpDown;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar vectorRenderingQualityFactorTrackBar;
        private System.Windows.Forms.Label label13;
        private DemosCommonCode.CustomControls.ColorPanelControl backgroundColorPanelControl;
        private System.Windows.Forms.GroupBox imagesDisplayModeGroupBox;
        private System.Windows.Forms.CheckBox useImageAppearancesInSinglepageModeCheckBox;
        private System.Windows.Forms.NumericUpDown imagesPaddingNumericUpDown;
        private System.Windows.Forms.NumericUpDown imagesInRowColumnNumericUpDown;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox layoutDirectionComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button focusedImageAppearanceButton;
        private System.Windows.Forms.Button imageAppearanceButton;
        private System.Windows.Forms.ComboBox multipageDisplayModeComboBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown maxThreadsNumericUpDown;
        private System.Windows.Forms.CheckBox renderOnlyVisibleImagesCheckBox;
        private System.Windows.Forms.GroupBox keyboardNavigationGroupBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown keyboardNavigationScrollStepNumericUpDown;
        private System.Windows.Forms.CheckBox keyboardNavigationCheckBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown keyboardNavigationZoomStepNumericUpDown;
        private DemosCommonCode.CustomControls.AnchorTypeEditorControl imageAnchorTypeEditor;
        private DemosCommonCode.CustomControls.AnchorTypeEditorControl focusPointAnchorTypeEditor;
    }
}