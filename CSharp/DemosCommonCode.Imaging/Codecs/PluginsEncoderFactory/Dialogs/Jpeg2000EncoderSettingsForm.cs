using System;
using System.Windows.Forms;
using Vintasoft.Imaging.Codecs.ImageFiles.Jpeg2000;
using Vintasoft.Imaging.Codecs;
using Vintasoft.Imaging.Codecs.Encoders;

namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    /// <summary>
    /// A form that allows to view and edit the JPEG2000 encoder settings.
    /// </summary>
    public partial class Jpeg2000EncoderSettingsForm : Form
    {

        #region Constructors

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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (EncoderSettings == null)
                EncoderSettings = new Jpeg2000EncoderSettings();
        }

        private void compressionRatioNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            compressionRatioLabel.Text = string.Format("(1 : {0})", compressionRatioNumericUpDown.Value);
        }

        private void waveletTransformCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            waveletLevelsNumericUpDown.Enabled = waveletTransformCheckBox.Checked;
            if (waveletLevelsNumericUpDown.Value == 0)
                waveletLevelsNumericUpDown.Value = 5;
        }

        private void UpdateUI()
        {
            formatComboBox.SelectedItem = _encoderSettings.FileFormat;            
            waveletLevelsNumericUpDown.Value = _encoderSettings.WaveletLevels;
            waveletTransformCheckBox.Checked = _encoderSettings.WaveletLevels > 0;
            qualityLayersNumericUpDown.Value = _encoderSettings.QualityLayers.Length;
            progressionOrderComboBox.SelectedItem = _encoderSettings.ProgressionOrder;
            useTilesCheckBox.Checked = _encoderSettings.TileWidth != 0 && _encoderSettings.TileHeight != 0;
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

        private void UpdateEnabledState(object sender, EventArgs e)
        {
            UpdateEnabledState();
        }
       

        private void UpdateEnabledState()
        {
            lossyGroupBox.Enabled = lossyCompressionCheckBox.Checked;
            imageDataSizeNumericUpDown.Enabled = imageDataSizeRadioButton.Checked;
            compressionRatioNumericUpDown.Enabled = compressionRatioRadioButton.Checked;
            tileWidthNumericUpDown.Enabled = useTilesCheckBox.Checked;
            tileHeightNumericUpDown.Enabled = useTilesCheckBox.Checked;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                SetEncoderSettings();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion       

    }
}
