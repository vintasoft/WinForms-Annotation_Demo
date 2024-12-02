using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.Codecs.ImageFiles.Tiff;
using Vintasoft.Imaging.ImageProcessing;

namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    /// <summary>
    /// A form that allows to view and edit the TIFF encoder settings.
    /// </summary>
    public partial class TiffEncoderSettingsForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TiffEncoderSettingsForm"/> class.
        /// </summary>
        public TiffEncoderSettingsForm()
        {
            InitializeComponent();

            EditAnnotationSettings = false;
            CanAddImagesToExistingFile = false;

            foreach (BinarizationMode mode in Enum.GetValues(typeof(BinarizationMode)))
                binarizationModeComboBox.Items.Add(mode);
        }

        #endregion



        #region Properties

        TiffEncoderSettings _encoderSettings;
        /// <summary>
        /// Gets or sets TIFF encoder settings.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TiffEncoderSettings EncoderSettings
        {
            get
            {
                return _encoderSettings;
            }
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException();

                if (_encoderSettings != value)
                {
                    _encoderSettings = value;

                    InitializeUI();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether encoder can add images to the existing TIFF file.
        /// </summary>
        /// <value>
        /// <b>True</b> - encoder can add images to the existing TIFF file;
        /// <b>false</b> - encoder can NOT add images to the existing TIFF file.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanAddImagesToExistingFile
        {
            get
            {
                return addImagesToExistingFileCheckBox.Enabled;
            }
            set
            {
                addImagesToExistingFileCheckBox.Enabled = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether encoder must add images to the existing TIFF file.
        /// </summary>
        /// <value>
        /// <b>True</b> - encoder must add images to the existing TIFF file;
        /// <b>false</b> - encoder must delete the existing TIFF file if necessary, create new TIFF file and add images to the new TIFF file.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AddImagesToExistingFile
        {
            get
            {
                return addImagesToExistingFileCheckBox.Checked;
            }
            set
            {
                addImagesToExistingFileCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the annotation format must be changed.
        /// </summary>
        /// <value>
        /// <b>True</b> if annotation format must be changed; otherwise, <b>false</b>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EditAnnotationSettings
        {
            get
            {
                return tabControl1.TabPages.Contains(annotationsTabPage);
            }
            set
            {
                if (EditAnnotationSettings != value)
                {
                    if (value)
                        tabControl1.TabPages.Add(annotationsTabPage);
                    else
                        tabControl1.TabPages.Remove(annotationsTabPage);
                }
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (EncoderSettings == null)
                EncoderSettings = new TiffEncoderSettings();
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the ValueChanged event of tileWidthNumericUpDown object.
        /// </summary>
        private void tileWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // if tile width is not corrent
            if ((tileWidthNumericUpDown.Value % 16) != 0)
            {
                // show message
                MessageBox.Show("Tile width must be multiple 16.");
                // calculate corrent tile width
                tileWidthNumericUpDown.Value = (int)(tileWidthNumericUpDown.Value / 16) * 16;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of tileHeightNumericUpDown object.
        /// </summary>
        private void tileHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // if tile height is not corrent
            if ((tileHeightNumericUpDown.Value % 16) != 0)
            {
                // show message
                MessageBox.Show("Tile height must be multiple 16.");
                // calculate corrent tile width
                tileHeightNumericUpDown.Value = (int)(tileHeightNumericUpDown.Value / 16) * 16;
            }
        }

        /// <summary>
        /// Handles the Click event of jpeg2000SettingsButton object.
        /// </summary>
        private void jpeg2000SettingsButton_Click(object sender, EventArgs e)
        {
            // create JPEG2000 encoder settings form
            using (Jpeg2000EncoderSettingsForm dialog = new Jpeg2000EncoderSettingsForm())
            {
                // set current JPEG2000 encoder settings
                dialog.EncoderSettings = EncoderSettings.Jpeg2000EncoderSettings;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // update JPEG2000 encoder settings

                    EncoderSettings.Jpeg2000EncoderSettings.CompressionRatio = dialog.EncoderSettings.CompressionRatio;
                    EncoderSettings.Jpeg2000EncoderSettings.CompressionType = dialog.EncoderSettings.CompressionType;
                    EncoderSettings.Jpeg2000EncoderSettings.EncodeAlphaChannelInPalette = dialog.EncoderSettings.EncodeAlphaChannelInPalette;
                    EncoderSettings.Jpeg2000EncoderSettings.FileFormat = dialog.EncoderSettings.FileFormat;
                    EncoderSettings.Jpeg2000EncoderSettings.FileSize = dialog.EncoderSettings.FileSize;
                    EncoderSettings.Jpeg2000EncoderSettings.ProgressionOrder = dialog.EncoderSettings.ProgressionOrder;
                    EncoderSettings.Jpeg2000EncoderSettings.QualityLayers = dialog.EncoderSettings.QualityLayers;
                    EncoderSettings.Jpeg2000EncoderSettings.TileHeight = dialog.EncoderSettings.TileHeight;
                    EncoderSettings.Jpeg2000EncoderSettings.TileWidth = dialog.EncoderSettings.TileWidth;
                    EncoderSettings.Jpeg2000EncoderSettings.WaveletLevels = dialog.EncoderSettings.WaveletLevels;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // update encoder settings
            SetEncoderSettings();

            // if annotations must be saved to 'WANG' format
            if (EditAnnotationSettings && _encoderSettings.AnnotationsFormat == AnnotationsFormat.Wang)
            {
                // if dialog closing must be canceled
                if (MessageBox.Show(
                    "Important: some data from annotations will be lost. Do you want to continue anyway?",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of binarizationModeComboBox object.
        /// </summary>
        private void binarizationModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if the image should be binarized using a threshold
            if ((BinarizationMode)binarizationModeComboBox.SelectedItem == BinarizationMode.Threshold)
            {
                // enable user interface

                binarizationThresholdNumericUpDown.Visible = true;
                binarizationThresholdLabel.Visible = true;
            }
            else
            {
                // disable user interface

                binarizationThresholdNumericUpDown.Visible = false;
                binarizationThresholdLabel.Visible = false;
            }
        }

        #endregion


        /// <summary>
        /// Initialize the user interface of this form.
        /// </summary>
        private void InitializeUI()
        {
            // compression
            switch (EncoderSettings.Compression)
            {
                case TiffCompression.None:
                    noneCompressionRadioButton.Checked = true;
                    break;

                case TiffCompression.CcittGroup3:
                case TiffCompression.CcittGroup4:
                    ccitt4CompressionRadioButton.Checked = true;
                    break;

                case TiffCompression.Lzw:
                    lzwCompressionRadioButton.Checked = true;
                    break;
                case TiffCompression.Zip:
                    zipCompressionRadioButton.Checked = true;
                    break;

                case TiffCompression.Jpeg:
                    jpegCompressionRadioButton.Checked = true;
                    break;
                case TiffCompression.Jpeg2000:
                    jpeg2000CompressionRadioButton.Checked = true;
                    break;

                default:
                    autoCompressionRadioButton.Checked = true;
                    break;
            }

            // strips and tiles
            rowsPerStripNumericUpDown.Value = EncoderSettings.RowsPerStrip;
            tileWidthNumericUpDown.Value = EncoderSettings.TileSize.Width;
            tileHeightNumericUpDown.Value = EncoderSettings.TileSize.Height;

            // JPEG advanced settings
            jpegGrayscaleCheckBox.Checked = EncoderSettings.SaveJpegAsGrayscale;
            jpegQualityNumericUpDown.Value = EncoderSettings.JpegQuality;
            // LZW advanced settings
            lzwUsePredictorCheckBox.Checked = EncoderSettings.UsePredictor;
            // ZIP advanced settings
            zipUsePredictorCheckBox.Checked = EncoderSettings.UsePredictor;
            zipLevelNumericUpDown.Value = EncoderSettings.ZipLevel;

            binarizationModeComboBox.SelectedItem = EncoderSettings.BinarizationCommand.BinarizationMode;
            binarizationThresholdNumericUpDown.Value = EncoderSettings.BinarizationCommand.Threshold;

            // annotation settings
            annotationsBinaryCheckBox.Checked = (_encoderSettings.AnnotationsFormat & AnnotationsFormat.VintasoftBinary) != 0;
            annotationXmpCheckBox.Checked = (_encoderSettings.AnnotationsFormat & AnnotationsFormat.VintasoftXmp) != 0;
            annotationWangCheckBox.Checked = (_encoderSettings.AnnotationsFormat & AnnotationsFormat.Wang) != 0;

            // metadata settings
            copyCommonMetadataCheckBox.Checked = EncoderSettings.CopyCommonMetadata;
            copyExifMetadataCheckBox.Checked = EncoderSettings.CopyExifMetadata;
            copyGpsMetadataCheckBox.Checked = EncoderSettings.CopyGpsMetadata;

            // file format
            if (EncoderSettings.FileFormat == TiffFileFormat.LittleEndian)
                littleEndianRadioButton.Checked = true;
            else
                bigEndianRadioButton.Checked = true;
            // file version
            if (EncoderSettings.FileVersion == TiffFileVersion.StandardTIFF)
                standardTiffRadioButton.Checked = true;
            else
                bigTiffRadioButton.Checked = true;

        }

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            jpegCompressionAdvancedSettingsGroupBox.Visible = jpegCompressionRadioButton.Checked;
            jpeg2000CompressionAdvancedSettingsGroupBox.Visible = jpeg2000CompressionRadioButton.Checked;
            lzwCompressionAdvancedSettingsGroupBox.Visible = lzwCompressionRadioButton.Checked;
            zipCompressionAdvancedSettingsGroupBox.Visible = zipCompressionRadioButton.Checked;
            binarizationAdvancedSettingsGroupBox.Visible = ccitt4CompressionRadioButton.Checked;

            rowsPerStripLabel.Visible = useStripsRadioButton.Checked;
            rowsPerStripNumericUpDown.Visible = useStripsRadioButton.Checked;
            tileWidthLabel.Visible = useTilesRadioButton.Checked;
            tileWidthNumericUpDown.Visible = useTilesRadioButton.Checked;
            tileHeightLabel.Visible = useTilesRadioButton.Checked;
            tileHeightNumericUpDown.Visible = useTilesRadioButton.Checked;
        }

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void UpdateUI(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Updates the encoder settings.
        /// </summary>
        private void SetEncoderSettings()
        {
            // compression
            if (autoCompressionRadioButton.Checked)
                EncoderSettings.Compression = TiffCompression.Auto;
            else if (noneCompressionRadioButton.Checked)
                EncoderSettings.Compression = TiffCompression.None;
            else if (ccitt4CompressionRadioButton.Checked)
            {
                EncoderSettings.Compression = TiffCompression.CcittGroup4;
                EncoderSettings.BinarizationCommand.BinarizationMode = (BinarizationMode)binarizationModeComboBox.SelectedItem;
                EncoderSettings.BinarizationCommand.Threshold = (int)binarizationThresholdNumericUpDown.Value;
            }
            else if (lzwCompressionRadioButton.Checked)
                EncoderSettings.Compression = TiffCompression.Lzw;
            else if (zipCompressionRadioButton.Checked)
                EncoderSettings.Compression = TiffCompression.Zip;
            else if (jpegCompressionRadioButton.Checked)
                EncoderSettings.Compression = TiffCompression.Jpeg;
            else if (jpeg2000CompressionRadioButton.Checked)
                EncoderSettings.Compression = TiffCompression.Jpeg2000;

            // strips & tiles
            EncoderSettings.UseStrips = useStripsRadioButton.Checked;
            EncoderSettings.RowsPerStrip = (int)rowsPerStripNumericUpDown.Value;
            EncoderSettings.UseTiles = useTilesRadioButton.Checked;
            EncoderSettings.TileSize = new Size((int)tileWidthNumericUpDown.Value, (int)tileHeightNumericUpDown.Value);

            // JPEG advanced settings
            EncoderSettings.JpegQuality = (int)jpegQualityNumericUpDown.Value;
            EncoderSettings.SaveJpegAsGrayscale = jpegGrayscaleCheckBox.Checked;
            // LZW advanced settings
            if (lzwCompressionRadioButton.Checked)
                EncoderSettings.UsePredictor = lzwUsePredictorCheckBox.Checked;
            // ZIP advanced settings
            if (zipCompressionRadioButton.Checked)
                EncoderSettings.UsePredictor = zipUsePredictorCheckBox.Checked;
            EncoderSettings.ZipLevel = (int)zipLevelNumericUpDown.Value;

            // annotations
            if (EditAnnotationSettings)
            {
                EncoderSettings.AnnotationsFormat = AnnotationsFormat.None;
                if (annotationsBinaryCheckBox.Checked)
                    EncoderSettings.AnnotationsFormat |= AnnotationsFormat.VintasoftBinary;
                if (annotationXmpCheckBox.Checked)
                    EncoderSettings.AnnotationsFormat |= AnnotationsFormat.VintasoftXmp;
                if (annotationWangCheckBox.Checked)
                    EncoderSettings.AnnotationsFormat |= AnnotationsFormat.Wang;
            }

            // metadata
            EncoderSettings.CopyCommonMetadata = copyCommonMetadataCheckBox.Checked;
            EncoderSettings.CopyExifMetadata = copyExifMetadataCheckBox.Checked;
            EncoderSettings.CopyGpsMetadata = copyGpsMetadataCheckBox.Checked;

            // file format
            if (littleEndianRadioButton.Checked)
                EncoderSettings.FileFormat = TiffFileFormat.LittleEndian;
            else
                EncoderSettings.FileFormat = TiffFileFormat.BigEndian;
            // file version
            if (standardTiffRadioButton.Checked)
                EncoderSettings.FileVersion = TiffFileVersion.StandardTIFF;
            else
                EncoderSettings.FileVersion = TiffFileVersion.BigTIFF;
        }

        #endregion

        #endregion

    }
}
