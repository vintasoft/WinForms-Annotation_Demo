
using System;
using System.Windows.Forms;
using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.Codecs.ImageFiles.Jpeg2000;
using Vintasoft.Imaging.ImageProcessing.Info;
#if !REMOVE_PDF_PLUGIN
using Vintasoft.Imaging.Pdf;
#endif

namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    /// <summary>
    /// A control that allows to view and edit the PDF image compression.
    /// </summary>
    public partial class PdfImageCompressionControl : UserControl
    {

        #region Fields

        /// <summary>
        /// Indicates that the MRC compression profile is initializing.
        /// </summary>
        bool _isMrcCompressionProfileInitializing = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfMrcCompressionControl"/> class.
        /// </summary>
        public PdfImageCompressionControl()
        {
            InitializeComponent();

#if REMOVE_DOCCLEANUP_PLUGIN
            compressionMrcRadioButton.Visible = false;
            compressionImageRadioButton.Checked = true;
#endif
        }

        #endregion



        #region Properties

        bool _isMrcCompressionOnly = false;
        /// <summary>
        /// Gets or sets a value that indicates whether PDF document can be compressed
        /// with MRC compression only.
        /// </summary>
        /// <value>
        /// <b>true</b> - PDF document can be compressed with MRC compression only;
        /// <b>false</b> - PDF document can be compressed with or without MRC compression.
        /// </value>
        public bool IsMrcCompressionOnly
        {
            get
            {
                return _isMrcCompressionOnly;
            }
            set
            {
                compressionImageRadioButton.Visible = !value;
                compressionMrcRadioButton.Visible = !value;
                compressionMrcRadioButton.Checked = value;
                UpdateUI();

                _isMrcCompressionOnly = value;
            }
        }

#if !REMOVE_PDF_PLUGIN
        /// <summary>
        /// Gets or sets the PDF compression settings.
        /// </summary>
        public PdfCompression Compression
        {
            get
            {
                return pdfImageCompressionControl.Compression;
            }
            set
            {
                pdfImageCompressionControl.Compression = value;
            }
        }

        /// <summary>
        /// Gets or sets the PDF compression settings.
        /// </summary>
        public PdfCompressionSettings CompressionSettings
        {
            get
            {
                return pdfImageCompressionControl.CompressionSettings;
            }
            set
            {
                pdfImageCompressionControl.CompressionSettings = value;
            }
        }

#if !REMOVE_DOCCLEANUP_PLUGIN
        PdfMrcCompressionSettings _mrcCompressionSettings = null;
        /// <summary>
        /// Gets or sets the PDF MRC compression settings.
        /// </summary>
        public PdfMrcCompressionSettings MrcCompressionSettings
        {
            get
            {
                return _mrcCompressionSettings;
            }
            set
            {
                _mrcCompressionSettings = value;
                if (value != null)
                {
                    mrcBackgroundCompressionControl.Compression = value.BackgroundLayerCompression;
                    mrcBackgroundCompressionControl.CompressionSettings = value.BackgroundLayerCompressionSettings;
                    mrcImagesCompressionControl.Compression = value.ImagesLayerCompression;
                    mrcImagesCompressionControl.CompressionSettings = value.ImagesLayerCompressionSettings;
                    mrcMaskCompressionControl.Compression = value.MaskCompression;
                    mrcMaskCompressionControl.CompressionSettings = value.MaskCompressionSettings;
                    mrcFrontCompressionControl.Compression = value.FrontLayerCompression;
                    mrcFrontCompressionControl.CompressionSettings = value.FrontLayerCompressionSettings;
                }
            }
        }
#endif
#endif

        #endregion



        #region Methods

        /// <summary>
        /// Compression type is changed.
        /// </summary>
        private void compressionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            if (compressionMrcRadioButton.Checked)
            {
                if (MrcCompressionSettings != null)
                    MrcCompressionSettings.EnableMrcCompression = true;
                else
                    mrcCompressionProfileComboBox.SelectedIndex = 2;
            }
            else
            {
                if (MrcCompressionSettings != null)
                    MrcCompressionSettings.EnableMrcCompression = false;
            }
#endif
            UpdateUI();
        }


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            if (_mrcCompressionSettings != null && _mrcCompressionSettings.EnableMrcCompression)
            {
                compressionMrcRadioButton.Checked = true;
                compressionImageRadioButton.Checked = false;
                mrcUseImagesLayerRadioButton.Checked = _mrcCompressionSettings.CreateImagesLayer;
                mrcNotUseImagesLayerRadioButton.Checked = !_mrcCompressionSettings.CreateImagesLayer;
                mrcUseFrontCheckBox.Checked = _mrcCompressionSettings.CreateFrontLayer;
                mrcHiQualityMaskCheckBox.Checked = _mrcCompressionSettings.HiQualityMask;
                mrcHiQualityFrontLayerCheckBox.Checked = _mrcCompressionSettings.HiQualityFrontLayer;
                mrcHiQualityFrontLayerCheckBox.Enabled = _mrcCompressionSettings.CreateFrontLayer;
                mrcUseBackgroundLayerCheckBox.Checked = _mrcCompressionSettings.CreateBackgroundLayer;
                mrcImageSegmentationCheckBox.Checked = _mrcCompressionSettings.ImageSegmentation != null;
                mrcImageSegmentationSettingsButton.Enabled = _mrcCompressionSettings.ImageSegmentation != null;
                mrcBackgroundCompressionControl.Enabled = _mrcCompressionSettings.CreateBackgroundLayer;
                mrcImagesCompressionControl.Enabled = _mrcCompressionSettings.CreateImagesLayer;
                mrcFrontCompressionControl.Enabled = _mrcCompressionSettings.CreateFrontLayer;
            }
            else
            {
                compressionMrcRadioButton.Checked = false;
                compressionImageRadioButton.Checked = true;
            }
#endif
            mrcCompressionSettingsGroupBox.Visible = compressionMrcRadioButton.Checked;
            mrcCompressionProfileComboBox.Visible = compressionMrcRadioButton.Checked;
            pdfImageCompressionControl.Visible = compressionImageRadioButton.Checked;
        }

        /// <summary>
        /// Synchronizes the <see cref="EncoderSettings"/> property with UI.
        /// </summary>
        private void SyncEncoderSettingsWithUI()
        {
#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            if (compressionMrcRadioButton.Checked)
            {
                if (_mrcCompressionSettings == null)
                    _mrcCompressionSettings = new PdfMrcCompressionSettings();
                _mrcCompressionSettings.EnableMrcCompression = true;
                _mrcCompressionSettings.CreateImagesLayer = mrcUseImagesLayerRadioButton.Checked;
                _mrcCompressionSettings.CreateBackgroundLayer = mrcUseBackgroundLayerCheckBox.Checked;
                _mrcCompressionSettings.HiQualityMask = mrcHiQualityMaskCheckBox.Checked;
                _mrcCompressionSettings.HiQualityFrontLayer = mrcHiQualityFrontLayerCheckBox.Checked;
                _mrcCompressionSettings.CreateFrontLayer = mrcUseFrontCheckBox.Checked;
                _mrcCompressionSettings.BackgroundLayerCompression = mrcBackgroundCompressionControl.Compression;
                _mrcCompressionSettings.BackgroundLayerCompressionSettings = mrcBackgroundCompressionControl.CompressionSettings;
                _mrcCompressionSettings.ImagesLayerCompression = mrcImagesCompressionControl.Compression;
                _mrcCompressionSettings.ImagesLayerCompressionSettings = mrcImagesCompressionControl.CompressionSettings;
                _mrcCompressionSettings.MaskCompression = mrcMaskCompressionControl.Compression;
                _mrcCompressionSettings.MaskCompressionSettings = mrcMaskCompressionControl.CompressionSettings;
                _mrcCompressionSettings.FrontLayerCompression = mrcFrontCompressionControl.Compression;
                _mrcCompressionSettings.FrontLayerCompressionSettings = mrcFrontCompressionControl.CompressionSettings;
                if (mrcImageSegmentationCheckBox.Checked)
                {
                    if (_mrcCompressionSettings.ImageSegmentation == null)
                        _mrcCompressionSettings.ImageSegmentation = new Vintasoft.Imaging.ImageProcessing.Info.ImageSegmentationCommand();
                }
                else
                {
                    _mrcCompressionSettings.ImageSegmentation = null;
                }
            }
            else
            {
                if (_mrcCompressionSettings != null)
                    _mrcCompressionSettings.EnableMrcCompression = false;
            }
#endif
        }


        /// <summary>
        /// "Use front layer" checkbox state is changed.
        /// </summary>
        private void mrcUseFrontCheckBox_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            _mrcCompressionSettings.CreateFrontLayer = mrcUseFrontCheckBox.Checked;
#endif
            OnMrcCompressionChanged();
            UpdateUI();
        }

        /// <summary>
        /// "High quality mask" checkbox state is changed.
        /// </summary>
        private void mrcHiQualityMaskCheckBox_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            _mrcCompressionSettings.HiQualityMask = mrcHiQualityMaskCheckBox.Checked;
#endif
            OnMrcCompressionChanged();
            UpdateUI();
        }

        /// <summary>
        /// "High quality front layer" checkbox state is changed.
        /// </summary>
        private void mrcHiQualityFrontLayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            _mrcCompressionSettings.HiQualityFrontLayer = mrcHiQualityFrontLayerCheckBox.Checked;
#endif
            OnMrcCompressionChanged();
            UpdateUI();
        }

        /// <summary>
        /// "Use background layer" checkbox state is changed.
        /// </summary>
        private void mrcUseBackgroundLayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            _mrcCompressionSettings.CreateBackgroundLayer = mrcUseBackgroundLayerCheckBox.Checked;
#endif
            OnMrcCompressionChanged();
            UpdateUI();
        }

        /// <summary>
        /// "Detect images" checkbox state is changed.
        /// </summary>
        private void mrcImageSegmentationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mrcImageSegmentationCheckBox.Checked)
            {
#if !REMOVE_DOCCLEANUP_PLUGIN && !REMOVE_PDF_PLUGIN
                _mrcCompressionSettings.ImageSegmentation = new Vintasoft.Imaging.ImageProcessing.Info.ImageSegmentationCommand();
#endif
                mrcUseImagesLayerRadioButton.Enabled = true;
                mrcNotUseImagesLayerRadioButton.Enabled = true;
            }
            else
            {
#if !REMOVE_DOCCLEANUP_PLUGIN && !REMOVE_PDF_PLUGIN
                _mrcCompressionSettings.ImageSegmentation = null;
#endif
                mrcUseImagesLayerRadioButton.Enabled = false;
                mrcNotUseImagesLayerRadioButton.Enabled = false;
            }
            UpdateUI();
        }

        /// <summary>
        /// "Detect images -> background layer" radio button state is changed.
        /// </summary>
        private void mrcNotUseImagesLayerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            _mrcCompressionSettings.CreateImagesLayer = !mrcNotUseImagesLayerRadioButton.Checked;
#endif
            OnMrcCompressionChanged();
            UpdateUI();
        }

        /// <summary>
        /// "Detect images -> images layer (each image as resource)" radio button state is changed.
        /// </summary>
        private void mrcUseImagesLayerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            _mrcCompressionSettings.CreateImagesLayer = mrcUseImagesLayerRadioButton.Checked;
#endif
            OnMrcCompressionChanged();
            UpdateUI();
        }

        /// <summary>
        /// MRC compression settings is changed.
        /// </summary>
        private void OnMrcCompressionChanged()
        {
            if (!_isMrcCompressionProfileInitializing)
                mrcCompressionProfileComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Sets the MRC compression settings from predefined profile.
        /// </summary>
        private void mrcCompressionProfileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mrcCompressionProfileComboBox.SelectedIndex == 0)
                return;

#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
            PdfMrcCompressionSettings settings = new PdfMrcCompressionSettings();

            _isMrcCompressionProfileInitializing = true;

            switch (mrcCompressionProfileComboBox.SelectedIndex)
            {
                // Document with images, best quality
                case 1:
                    settings.CreateBackgroundLayer = true;
                    settings.BackgroundLayerCompression = PdfCompression.Jpeg | PdfCompression.Zip;
                    settings.BackgroundLayerCompressionSettings.JpegQuality = 60;
                    settings.ImageSegmentation = new ImageSegmentationCommand();
                    settings.CreateImagesLayer = false;

                    settings.HiQualityMask = true;
                    settings.MaskCompression = PdfCompression.Jbig2;
                    settings.MaskCompressionSettings.Jbig2Settings.Lossy = true;

                    settings.CreateFrontLayer = true;
                    settings.HiQualityFrontLayer = true;
                    settings.FrontLayerCompression = PdfCompression.Jpeg2000;
                    settings.FrontLayerCompressionSettings.Jpeg2000Settings.CompressionRatio = 300 * 3;
                    settings.FrontLayerCompressionSettings.Jpeg2000Settings.CompressionType = Jpeg2000CompressionType.Lossy;
                    break;

                // Document with images, optimal
                case 2:
                    settings.CreateBackgroundLayer = true;
                    settings.BackgroundLayerCompression = PdfCompression.Jpeg | PdfCompression.Zip;
                    settings.BackgroundLayerCompressionSettings.JpegQuality = 35;

                    settings.ImageSegmentation = new ImageSegmentationCommand();
                    settings.CreateImagesLayer = false;

                    settings.HiQualityMask = true;
                    settings.MaskCompression = PdfCompression.Jbig2;
                    settings.MaskCompressionSettings.Jbig2Settings.Lossy = true;

                    settings.CreateFrontLayer = true;
                    settings.HiQualityFrontLayer = true;
                    settings.FrontLayerCompression = PdfCompression.Jpeg | PdfCompression.Zip;
                    settings.FrontLayerCompressionSettings.JpegQuality = 25;
                    settings.FrontLayerCompressionSettings.Jpeg2000Settings.CompressionRatio = 400 * 3;
                    settings.FrontLayerCompressionSettings.Jpeg2000Settings.CompressionType = Jpeg2000CompressionType.Lossy;
                    break;

                // Document with images, best compression
                case 3:
                    settings.CreateBackgroundLayer = true;
                    settings.BackgroundLayerCompression = PdfCompression.Jpeg | PdfCompression.Zip;
                    settings.BackgroundLayerCompressionSettings.JpegQuality = 20;

                    settings.ImageSegmentation = new ImageSegmentationCommand();
                    settings.CreateImagesLayer = false;

                    settings.HiQualityMask = false;
                    settings.MaskCompression = PdfCompression.Jbig2;
                    settings.MaskCompressionSettings.Jbig2Settings.Lossy = true;

                    settings.CreateFrontLayer = true;
                    settings.HiQualityFrontLayer = false;
                    settings.FrontLayerCompression = PdfCompression.Zip;
                    break;

                // Document, best quality
                case 4:
                    settings.CreateBackgroundLayer = true;
                    settings.BackgroundLayerCompression = PdfCompression.Jpeg | PdfCompression.Zip;
                    settings.BackgroundLayerCompressionSettings.JpegQuality = 30;

                    settings.ImageSegmentation = null;
                    settings.CreateImagesLayer = false;

                    settings.HiQualityMask = true;
                    settings.MaskCompression = PdfCompression.Jbig2;
                    settings.MaskCompressionSettings.Jbig2Settings.Lossy = true;

                    settings.CreateFrontLayer = true;
                    settings.HiQualityFrontLayer = true;
                    settings.FrontLayerCompression = PdfCompression.Jpeg2000;
                    settings.FrontLayerCompressionSettings.Jpeg2000Settings.CompressionRatio = 300 * 3;
                    settings.FrontLayerCompressionSettings.Jpeg2000Settings.CompressionType = Jpeg2000CompressionType.Lossy;
                    break;

                // Document, optimal
                case 5:
                    settings.CreateBackgroundLayer = true;
                    settings.BackgroundLayerCompression = PdfCompression.Jpeg | PdfCompression.Zip;
                    settings.BackgroundLayerCompressionSettings.JpegQuality = 25;

                    settings.ImageSegmentation = null;
                    settings.CreateImagesLayer = false;

                    settings.HiQualityMask = true;
                    settings.MaskCompression = PdfCompression.Jbig2;
                    settings.MaskCompressionSettings.Jbig2Settings.Lossy = true;

                    settings.CreateFrontLayer = true;
                    settings.HiQualityFrontLayer = false;
                    settings.FrontLayerCompression = PdfCompression.Jpeg2000;
                    settings.FrontLayerCompressionSettings.Jpeg2000Settings.CompressionRatio = 350 * 3;
                    settings.FrontLayerCompressionSettings.Jpeg2000Settings.CompressionType = Jpeg2000CompressionType.Lossy;
                    break;

                // Document, best compression
                case 6:
                    settings.CreateBackgroundLayer = true;
                    settings.BackgroundLayerCompression = PdfCompression.Jpeg | PdfCompression.Zip;
                    settings.BackgroundLayerCompressionSettings.JpegQuality = 20;

                    settings.ImageSegmentation = null;
                    settings.CreateImagesLayer = false;

                    settings.HiQualityMask = false;
                    settings.MaskCompression = PdfCompression.Jbig2;
                    settings.MaskCompressionSettings.Jbig2Settings.Lossy = true;

                    settings.CreateFrontLayer = true;
                    settings.HiQualityFrontLayer = false;
                    settings.FrontLayerCompression = PdfCompression.Jpeg2000;
                    settings.FrontLayerCompressionSettings.Jpeg2000Settings.CompressionRatio = 450 * 3;
                    settings.FrontLayerCompressionSettings.Jpeg2000Settings.CompressionType = Jpeg2000CompressionType.Lossy;
                    break;
            }
            MrcCompressionSettings = settings;
#endif
            UpdateUI();

            _isMrcCompressionProfileInitializing = false;
        }

        /// <summary>
        /// Shows the dialog for editing the image segmentation settings.
        /// </summary>
        private void mrcImageSegmentationSettingsButton_Click(object sender, EventArgs e)
        {
#if !REMOVE_DOCCLEANUP_PLUGIN && !REMOVE_PDF_PLUGIN
            using (PropertyGridForm dialog = new PropertyGridForm(MrcCompressionSettings.ImageSegmentation, "Image segmentation settings"))
            {
                dialog.ShowDialog();
            }
#endif
        }

        /// <summary>
        /// Updates User Interface.
        /// </summary>
        private void UpdateUI_Handler(object sender, EventArgs e)
        {

        }

        #endregion
    }
}

