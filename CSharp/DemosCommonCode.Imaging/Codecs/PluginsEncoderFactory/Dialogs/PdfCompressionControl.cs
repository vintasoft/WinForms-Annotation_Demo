using System;
using System.ComponentModel;
using System.Windows.Forms;

#if !REMOVE_PDF_PLUGIN
using Vintasoft.Imaging.Pdf;
#endif
using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.ImageProcessing;

namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    /// <summary>
    /// A control that allows to edit the PDF compression settings.
    /// </summary>
    public partial class PdfCompressionControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfCompressionControl"/> class.
        /// </summary>
        public PdfCompressionControl()
        {
            InitializeComponent();

            if (!AvailableEncoders.IsEncoderAvailable("Jbig2"))
                compressionJbig2RadioButton.Enabled = false;
            if (!AvailableEncoders.IsEncoderAvailable("Jpeg2000"))
                compressionJpeg2000RadioButton.Enabled = false;

            foreach (BinarizationMode mode in Enum.GetValues(typeof(BinarizationMode)))
                binarizationModeComboBox.Items.Add(mode);
        }

        #endregion



        #region Properties

#if !REMOVE_PDF_PLUGIN
        PdfCompression _compression = PdfCompression.Auto;
        /// <summary>
        /// Gets or sets the PDF compression.
        /// </summary>
        [DefaultValue(PdfCompression.Auto)]
        public PdfCompression Compression
        {
            get
            {
                return _compression;
            }
            set
            {
                _compression = value;
                UpdateUI();
            }
        }
#endif

        /// <summary>
        /// Gets or sets a value indicating whether the 'Auto' compression can be used.
        /// </summary>
        [DefaultValue(true)]
        public bool CanUseAutoCompression
        {
            get
            {
                return compressionAutoRadioButton.Visible;
            }
            set
            {
                compressionAutoRadioButton.Visible = value;
            }
        }

#if !REMOVE_PDF_PLUGIN
        PdfCompressionSettings _compressionSettings = new PdfCompressionSettings();
        /// <summary>
        /// Gets or sets the PDF compression settings.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue((object)null)]
        public PdfCompressionSettings CompressionSettings
        {
            get
            {
                return _compressionSettings;
            }
            set
            {
                _compressionSettings = value;
                UpdateUI();
            }
        }
#endif

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the CheckedChanged event of CompressionRadioButton object.
        /// </summary>
        private void compressionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            // if 'Auto' compression must be used
            if (compressionAutoRadioButton.Checked)
                _compression = PdfCompression.Auto;
            // if 'CcittFax' compression must be used
            else if (compressionCcittRadioButton.Checked)
                _compression = PdfCompression.CcittFax;
            // if 'JBIG2' compression must be used
            else if (compressionJbig2RadioButton.Checked)
                _compression = PdfCompression.Jbig2;
            // if 'JPEG2000' compression must be used
            else if (compressionJpeg2000RadioButton.Checked)
                _compression = PdfCompression.Jpeg2000;
            // if 'Jpeg' compression must be used
            else if (compressionJpegRadioButton.Checked)
                _compression = PdfCompression.Jpeg;
            // if 'Lzw' compression must be used
            else if (compressionLzwRadioButton.Checked)
                _compression = PdfCompression.Lzw;
            // if compression should not be used
            else if (compressionNoneRadioButton.Checked)
                _compression = PdfCompression.None;
            // if 'Zip' compression must be used
            else if (compressionZipRadioButton.Checked)
                _compression = PdfCompression.Zip;
            // if 'Jpeg' and 'Zip' compression must be used
            else if (compressionJpegZipRadioButton.Checked)
                _compression = PdfCompression.Jpeg | PdfCompression.Zip;
#endif
            UpdateUI();
        }

        /// <summary>
        /// Handles the ValueChanged event of JpegQualityNumericUpDown object.
        /// </summary>
        private void jpegQualityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            // update compression jpeg quality
            _compressionSettings.JpegQuality = (int)jpegQualityNumericUpDown.Value;
#endif
        }

        /// <summary>
        /// Handles the CheckedChanged event of JpegGrayscaleCheckBox object.
        /// </summary>
        private void jpegGrayscaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            // if 'Jpeg' image must be saved as grayscale image
            if (jpegGrayscaleCheckBox.Checked)
                _compressionSettings.JpegSaveAsGrayscale = true;
            else
                _compressionSettings.JpegSaveAsGrayscale = false;
#endif
        }

        /// <summary>
        /// Handles the CheckedChanged event of Jbig2UseGlobalsCheckBox object.
        /// </summary>
        private void jbig2UseGlobalsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            // if JBIG2 must be used global settings
            if (jbig2UseGlobalsCheckBox.Checked)
                _compressionSettings.Jbig2UseGlobals = true;
            else
                _compressionSettings.Jbig2UseGlobals = false;
#endif
        }

        /// <summary>
        /// Handles the ValueChanged event of ZipLevelNumericUpDown object.
        /// </summary>
        private void zipLevelNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            // update the 'Zip' compression level
            _compressionSettings.ZipCompressionLevel = (int)zipLevelNumericUpDown.Value;
#endif
        }

        /// <summary>
        /// Handles the Click event of Jpeg2000SettingsButton object.
        /// </summary>
        private void jpeg2000SettingsButton_Click(object sender, EventArgs e)
        {
            // create JPEG2000 encoding settings
            using (Jpeg2000EncoderSettingsForm jpeg2000SettingsDialog = new Jpeg2000EncoderSettingsForm())
            {
#if !REMOVE_PDF_PLUGIN
                jpeg2000SettingsDialog.EncoderSettings = _compressionSettings.Jpeg2000Settings;
#endif
                // show dialog
                jpeg2000SettingsDialog.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of Jbig2SettingsButton object.
        /// </summary>
        private void jbig2SettingsButton_Click(object sender, EventArgs e)
        {
            // create JBIG2 encoding settings
            using (Jbig2EncoderSettingsForm jbig2SettingsDialog = new Jbig2EncoderSettingsForm())
            {
#if !REMOVE_PDF_PLUGIN
                jbig2SettingsDialog.EncoderSettings = _compressionSettings.Jbig2Settings;
#endif
                jbig2SettingsDialog.AppendExistingDocumentEnabled = false;

                // show dialog
                jbig2SettingsDialog.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of BinarizationModeComboBox object.
        /// </summary>
        private void binarizationModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get binarization mode
            BinarizationMode mode = (BinarizationMode)binarizationModeComboBox.SelectedItem;
#if !REMOVE_PDF_PLUGIN
            _compressionSettings.BinarizationCommand.BinarizationMode = mode;
#endif

            if (mode == BinarizationMode.Threshold)
            {
                thresholdNumericUpDown.Visible = true;
                thresholdLabel.Visible = true;
            }
            else
            {
                thresholdNumericUpDown.Visible = false;
                thresholdLabel.Visible = false;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of ThresholdNumericUpDown object.
        /// </summary>
        private void thresholdNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            // update binarization threshold
            _compressionSettings.BinarizationCommand.Threshold = (int)thresholdNumericUpDown.Value;
#endif
        }

        #endregion


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            jpeg2000CompressionSettingsGroupBox.Visible = false;
            jpegCompressionSettingsGroupBox.Visible = false;
            jbig2CompressionSettingsGroupBox.Visible = false;
            zipCompressionSettingsGroupBox.Visible = false;
            binarizationGroupBox.Visible = false;
#if !REMOVE_PDF_PLUGIN
            if (_compressionSettings != null)
            {
                switch (_compression)
                {
                    case PdfCompression.Auto:
                        zipCompressionSettingsGroupBox.Visible = true;
                        break;
                    case PdfCompression.Jpeg:
                        jpegCompressionSettingsGroupBox.Visible = true;
                        break;
                    case PdfCompression.Jpeg2000:
                        jpeg2000CompressionSettingsGroupBox.Visible = true;
                        break;
                    case PdfCompression.Jbig2:
                        jbig2CompressionSettingsGroupBox.Visible = true;
                        break;
                    case PdfCompression.CcittFax:
                        binarizationGroupBox.Visible = true;
                        break;
                    case PdfCompression.Zip:
                        zipCompressionSettingsGroupBox.Visible = true;
                        break;
                    case PdfCompression.Zip | PdfCompression.Jpeg:
                        zipCompressionSettingsGroupBox.Visible = true;
                        jpegCompressionSettingsGroupBox.Visible = true;
                        break;
                }
                jpegQualityNumericUpDown.Value = _compressionSettings.JpegQuality;
                jpegGrayscaleCheckBox.Checked = _compressionSettings.JpegSaveAsGrayscale;
                jbig2UseGlobalsCheckBox.Checked = _compressionSettings.Jbig2UseGlobals;
                zipLevelNumericUpDown.Value = _compressionSettings.ZipCompressionLevel;
                binarizationModeComboBox.SelectedItem = _compressionSettings.BinarizationCommand.BinarizationMode;
                thresholdNumericUpDown.Value = _compressionSettings.BinarizationCommand.Threshold;
            }
            if (_compression == PdfCompression.Auto)
                compressionAutoRadioButton.Checked = true;
            else if (_compression == PdfCompression.CcittFax)
                compressionCcittRadioButton.Checked = true;
            else if (_compression == PdfCompression.Jbig2)
                compressionJbig2RadioButton.Checked = true;
            else if (_compression == PdfCompression.Jpeg2000)
                compressionJpeg2000RadioButton.Checked = true;
            else if (_compression == PdfCompression.Jpeg)
                compressionJpegRadioButton.Checked = true;
            else if (_compression == PdfCompression.Lzw)
                compressionLzwRadioButton.Checked = true;
            else if (_compression == PdfCompression.None)
                compressionNoneRadioButton.Checked = true;
            else if (_compression == PdfCompression.Zip)
                compressionZipRadioButton.Checked = true;
            else if (_compression == (PdfCompression.Zip | PdfCompression.Jpeg) ||
                _compression == (PdfCompression.Zip | PdfCompression.Jpeg | PdfCompression.Predictor))
                compressionJpegZipRadioButton.Checked = true;
#endif
        }

        #endregion

    }
}

