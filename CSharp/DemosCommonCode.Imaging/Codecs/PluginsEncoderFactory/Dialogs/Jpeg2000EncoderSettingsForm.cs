using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.Codecs.ImageFiles.Jpeg2000;

namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    /// <summary>
    /// A form that allows to view and edit the JPEG2000 encoder settings.
    /// </summary>
    public partial class Jpeg2000EncoderSettingsForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Jpeg2000EncoderSettingsForm"/> class.
        /// </summary>
        public Jpeg2000EncoderSettingsForm()
        {
            InitializeComponent();
            
            formatComboBox.Items.Add(Jpeg2000FileFormat.Jp2File);
            formatComboBox.Items.Add(Jpeg2000FileFormat.Codestream);

            progressionOrderComboBox.Items.Add(ProgressionOrder.CPRL);
            progressionOrderComboBox.Items.Add(ProgressionOrder.LRCP);
            progressionOrderComboBox.Items.Add(ProgressionOrder.PCRL);
            progressionOrderComboBox.Items.Add(ProgressionOrder.RLCP);
            progressionOrderComboBox.Items.Add(ProgressionOrder.RPCL);
        }

        #endregion



        #region Properties

        Jpeg2000EncoderSettings _encoderSettings;
        /// <summary>
        /// Gets or sets the JPEG 2000 Encoder Settings.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Jpeg2000EncoderSettings EncoderSettings
        {
            get
            {
                return _encoderSettings;
            }
            set
            {
                if (value == null)
                    value = new Jpeg2000EncoderSettings();
                _encoderSettings = value;
                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Form is loaded.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (EncoderSettings == null)
                EncoderSettings = new Jpeg2000EncoderSettings();
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the ValueChanged event of compressionRatioNumericUpDown object.
        /// </summary>
        private void compressionRatioNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // update the "Compression ratio" label
            compressionRatioLabel.Text = string.Format("(1 : {0})", compressionRatioNumericUpDown.Value);
        }

        /// <summary>
        /// Handles the CheckedChanged event of waveletTransformCheckBox object.
        /// </summary>
        private void waveletTransformCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (waveletTransformCheckBox.Checked)
                waveletLevelsNumericUpDown.Enabled = true;
            else
                waveletLevelsNumericUpDown.Enabled = false;

            if (waveletLevelsNumericUpDown.Value == 0)
                waveletLevelsNumericUpDown.Value = 5;
        }

        /// <summary>
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                // update encoder settings
                SetEncoderSettings();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of buttonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the CheckedChanged event of lossyCompressionCheckBox object.
        /// </summary>
        private void lossyCompressionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEnabledState();
        }

        /// <summary>
        /// Handles the CheckedChanged event of imageDataSizeRadioButton object.
        /// </summary>
        private void imageDataSizeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEnabledState();
        }

        /// <summary>
        /// Handles the CheckedChanged event of compressionRatioRadioButton object.
        /// </summary>
        private void compressionRatioRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEnabledState();
        }

        /// <summary>
        /// Handles the CheckedChanged event of useTilesCheckBox object.
        /// </summary>
        private void useTilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEnabledState();
        }

        #endregion


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            formatComboBox.SelectedItem = _encoderSettings.FileFormat;
            waveletLevelsNumericUpDown.Value = _encoderSettings.WaveletLevels;
            waveletTransformCheckBox.Checked = _encoderSettings.WaveletLevels > 0;
            qualityLayersNumericUpDown.Value = _encoderSettings.QualityLayers.Length;
            progressionOrderComboBox.SelectedItem = _encoderSettings.ProgressionOrder;
            useTilesCheckBox.Checked = _encoderSettings.TileWidth != 0 || _encoderSettings.TileHeight != 0;
            lossyCompressionCheckBox.Checked = _encoderSettings.CompressionType == Jpeg2000CompressionType.Lossy;
            if (useTilesCheckBox.Checked)
            {
                tileWidthNumericUpDown.Value = Math.Max(tileWidthNumericUpDown.Minimum, _encoderSettings.TileWidth);
                tileHeightNumericUpDown.Value = Math.Max(tileHeightNumericUpDown.Minimum, _encoderSettings.TileHeight);
            }
            compressionRatioNumericUpDown.Value = (int)Math.Round(_encoderSettings.CompressionRatio);
            if (_encoderSettings.FileSize == 0)
                compressionRatioRadioButton.Checked = true;
            else
                imageDataSizeRadioButton.Checked = true;

            UpdateEnabledState();
        }

        /// <summary>
        /// Updates the enabled state of UI controls.
        /// </summary>
        private void UpdateEnabledState()
        {
            lossyGroupBox.Enabled = lossyCompressionCheckBox.Checked;
            imageDataSizeNumericUpDown.Enabled = imageDataSizeRadioButton.Checked;
            compressionRatioNumericUpDown.Enabled = compressionRatioRadioButton.Checked;
            tileWidthNumericUpDown.Enabled = useTilesCheckBox.Checked;
            tileHeightNumericUpDown.Enabled = useTilesCheckBox.Checked;
        }

        /// <summary>
        /// Updates the encoder settings.
        /// </summary>
        private void SetEncoderSettings()
        {
            _encoderSettings.FileFormat = (Jpeg2000FileFormat)formatComboBox.SelectedItem;
            if (waveletTransformCheckBox.Checked)
                _encoderSettings.WaveletLevels = (int)waveletLevelsNumericUpDown.Value;
            else
                _encoderSettings.WaveletLevels = 0;
            _encoderSettings.QualityLayers = new double[(int)qualityLayersNumericUpDown.Value];
            for (int i = 0; i < _encoderSettings.QualityLayers.Length; i++)
                _encoderSettings.QualityLayers[i] = 1;
            _encoderSettings.ProgressionOrder = (ProgressionOrder)progressionOrderComboBox.SelectedItem;
            if (lossyCompressionCheckBox.Checked)
                _encoderSettings.CompressionType = Jpeg2000CompressionType.Lossy;
            else
                _encoderSettings.CompressionType = Jpeg2000CompressionType.Lossless;
            if (useTilesCheckBox.Checked)
            {
                _encoderSettings.TileWidth = (int)tileWidthNumericUpDown.Value;
                _encoderSettings.TileHeight = (int)tileHeightNumericUpDown.Value;
            }
            else
            {
                _encoderSettings.TileWidth = 0;
                _encoderSettings.TileHeight = 0;
            }
            if (_encoderSettings.CompressionType == Jpeg2000CompressionType.Lossy)
            {
                if (imageDataSizeRadioButton.Checked)
                {
                    _encoderSettings.FileSize = (int)imageDataSizeNumericUpDown.Value * 1024;
                }
                else
                {
                    _encoderSettings.FileSize = 0;
                    _encoderSettings.CompressionRatio = (double)compressionRatioNumericUpDown.Value;
                }
            }
        }

        #endregion

        #endregion

    }
}
