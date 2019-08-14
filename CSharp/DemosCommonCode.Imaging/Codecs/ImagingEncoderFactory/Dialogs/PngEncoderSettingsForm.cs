using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs;
using Vintasoft.Imaging.Codecs.Encoders;

namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    /// <summary>
    /// A form that allows to view and edit the PNG encoder settings.
    /// </summary>
    public partial class PngEncoderSettingsForm : Form
    {
        
        #region Constructors

        public PngEncoderSettingsForm()
        {
            InitializeComponent();

            filterMethodComboBox.Items.Add(PngFilterMethod.None);
            filterMethodComboBox.Items.Add(PngFilterMethod.Auto);
            filterMethodComboBox.Items.Add(PngFilterMethod.Sub);
            filterMethodComboBox.Items.Add(PngFilterMethod.Up);
            filterMethodComboBox.Items.Add(PngFilterMethod.Average);
            filterMethodComboBox.Items.Add(PngFilterMethod.Paeth);
            filterMethodComboBox.Items.Add(PngFilterMethod.Adaptive);

            for (int i = 0; i <= 9; i++)
                compressionLevelComboBox.Items.Add(i);
        }

        #endregion



        #region Properties

        PngEncoderSettings _encoderSettings;
        /// <summary>
        /// Gets or sets PNG encoder settings.
        /// </summary>
        public PngEncoderSettings EncoderSettings
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
                    UpdateUI();
                }
            }
        }

        public bool EditAnnotationSettings
        {
            get
            {
                return settingsTabControl.TabPages.Contains(annotationsTabPage);
            }
            set
            {
                if (EditAnnotationSettings != value)
                {
                    if (value)
                        settingsTabControl.TabPages.Add(annotationsTabPage);
                    else
                        settingsTabControl.TabPages.Remove(annotationsTabPage);
                }
            }
        }

        #endregion



        #region Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (EncoderSettings == null)
            {
                EncoderSettings = PngEncoderSettings.Fast;
                fastRadioButton.Checked = true;
            }
        }

        private void UpdateUI()
        {
            if (EncoderSettings.Equals(PngEncoderSettings.BestSpeed))
                bestSpeedRadioButton.Checked = true;
            else if (EncoderSettings.Equals(PngEncoderSettings.Fast))
                fastRadioButton.Checked = true;
            else if (EncoderSettings.Equals(PngEncoderSettings.Normal))
                normalRadioButton.Checked = true;
            else if (EncoderSettings.Equals(PngEncoderSettings.BestCompression))
                bestCompressionRadioButton.Checked = true;
            else
                customRadioButton.Checked = true;

            customGroupBox.Enabled = customRadioButton.Checked;
            filterMethodComboBox.SelectedItem = EncoderSettings.FilterMethod;
            compressionLevelComboBox.SelectedItem = EncoderSettings.CompressionLevel;

            if (EditAnnotationSettings)
            {
                annotationsBinaryCheckBox.Checked = (EncoderSettings.AnnotationsFormat | AnnotationsFormat.VintasoftBinary) != 0;
            }
        }

        private void SetEncoderSettings()
        {
            if (bestSpeedRadioButton.Checked == true)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.BestSpeed.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.BestSpeed.CompressionLevel;
            }
            else if (fastRadioButton.Checked == true)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.Fast.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.Fast.CompressionLevel;
            }
            else if (normalRadioButton.Checked == true)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.Normal.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.Normal.CompressionLevel;
            }
            else if (bestCompressionRadioButton.Checked == true)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.BestCompression.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.BestCompression.CompressionLevel;
            }
            else
            {
                EncoderSettings.FilterMethod = (PngFilterMethod)filterMethodComboBox.SelectedItem;
                EncoderSettings.CompressionLevel = (int)compressionLevelComboBox.SelectedItem;
            }

            EncoderSettings.AnnotationsFormat = AnnotationsFormat.None;
            if (annotationsBinaryCheckBox.Checked)
                EncoderSettings.AnnotationsFormat |= AnnotationsFormat.VintasoftBinary;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SetEncoderSettings();

            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bestSpeedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bestSpeedRadioButton.Checked)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.BestSpeed.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.BestSpeed.CompressionLevel;
            }
        }

        private void fastRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fastRadioButton.Checked)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.Fast.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.Fast.CompressionLevel;
            }
        }

        private void normalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (normalRadioButton.Checked)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.Normal.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.Normal.CompressionLevel;
            }
        }

        private void bestCompressionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bestCompressionRadioButton.Checked)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.BestCompression.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.BestCompression.CompressionLevel;
            }
        }

        private void customRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (customRadioButton.Checked)
                customGroupBox.Enabled = true;
        }

        #endregion

    }
}
