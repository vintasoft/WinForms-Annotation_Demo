using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Codecs;

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

        /// <summary>
        /// Compression radio button is checked.
        /// </summary>
        private void compressionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            if (compressionAutoRadioButton.Checked)
                _compression = PdfCompression.Auto;
            else if (compressionCcittRadioButton.Checked)
                _compression = PdfCompression.CcittFax;
            else if (compressionJbig2RadioButton.Checked)
                _compression = PdfCompression.Jbig2;
            else if (compressionJpeg2000RadioButton.Checked)
                _compression = PdfCompression.Jpeg2000;
            else if (compressionJpegRadioButton.Checked)
                _compression = PdfCompression.Jpeg;
            else if (compressionLzwRadioButton.Checked)
                _compression = PdfCompression.Lzw;
            else if (compressionNoneRadioButton.Checked)
                _compression = PdfCompression.None;
            else if (compressionZipRadioButton.Checked)
                _compression = PdfCompression.Zip;
            else if (compressionJpegZipRadioButton.Checked)
                _compression = PdfCompression.Jpeg | PdfCompression.Zip;
#endif
            UpdateUI();
        }

        /// <summary>
        /// JPEG quality is changed.
        /// </summary>
        private void jpegQualityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            _compressionSettings.JpegQuality = (int)jpegQualityNumericUpDown.Value;
#endif
        }

        /// <summary>
        /// JPEG grayscale flag is changed.
        /// </summary>
        private void jpegGrayscaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            _compressionSettings.JpegSaveAsGrayscale = jpegGrayscaleCheckBox.Checked;
#endif
        }

        /// <summary>
        /// JBIG2 UseGlobals flag is changed.
        /// </summary>
        private void jbig2UseGlobalsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            _compressionSettings.Jbig2UseGlobals = jbig2UseGlobalsCheckBox.Checked;
#endif
        }

        /// <summary>
        /// Zip compression level is changed.
        /// </summary>
        private void zipLevelNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            _compressionSettings.ZipCompressionLevel = (int)zipLevelNumericUpDown.Value;
#endif
        }


        /// <summary>
        /// Shows the JPEG2000 settings dialog.
        /// </summary>
        private void jpeg2000SettingsButton_Click(object sender, EventArgs e)
        {
            using (Jpeg2000EncoderSettingsForm jpeg2000SettingsDialog = new Jpeg2000EncoderSettingsForm())
            {
#if !REMOVE_PDF_PLUGIN
                jpeg2000SettingsDialog.EncoderSettings = _compressionSettings.Jpeg2000Settings;
#endif
                jpeg2000SettingsDialog.ShowDialog();
            }
        }

        /// <summary>
        /// Shows the JBIG2 settings dialog.
        /// </summary>
        private void jbig2SettingsButton_Click(object sender, EventArgs e)
        {
            using (Jbig2EncoderSettingsForm jbig2SettingsDialog = new Jbig2EncoderSettingsForm())
            {
#if !REMOVE_PDF_PLUGIN
                jbig2SettingsDialog.EncoderSettings = _compressionSettings.Jbig2Settings;
#endif
                jbig2SettingsDialog.AppendExistingDocumentEnabled = false;
                jbig2SettingsDialog.ShowDialog();
            }
        }

        private void binarizationModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void thresholdNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
#if !REMOVE_PDF_PLUGIN
            _compressionSettings.BinarizationCommand.Threshold = (int)thresholdNumericUpDown.Value;
#endif
        }

        #endregion

    }
}

