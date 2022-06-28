using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.Codecs.ImageFiles.Png;

namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    /// <summary>
    /// A form that allows to view and edit the PNG encoder settings.
    /// </summary>
    public partial class PngEncoderSettingsForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PngEncoderSettingsForm"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the annotation format must be changed.
        /// </summary>
        /// <value>
        /// <b>True</b> if annotation format must be changed; otherwise, <b>false</b>.
        /// </value>
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

        #region PROTECTED

        /// <summary>
        /// Creates the encoder settings.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (EncoderSettings == null)
            {
                EncoderSettings = PngEncoderSettings.Fast;
                fastRadioButton.Checked = true;
            }
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of ButtonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // update encoder settings
            SetEncoderSettings();

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of ButtonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the CheckedChanged event of BestSpeedRadioButton object.
        /// </summary>
        private void bestSpeedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // if best speed encoding should be set
            if (bestSpeedRadioButton.Checked)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.BestSpeed.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.BestSpeed.CompressionLevel;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of FastRadioButton object.
        /// </summary>
        private void fastRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // if fast speed encoding should be set
            if (fastRadioButton.Checked)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.Fast.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.Fast.CompressionLevel;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of NormalRadioButton object.
        /// </summary>
        private void normalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // if normal speed encoding should be set
            if (normalRadioButton.Checked)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.Normal.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.Normal.CompressionLevel;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of BestCompressionRadioButton object.
        /// </summary>
        private void bestCompressionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // if best image compression should be set
            if (bestCompressionRadioButton.Checked)
            {
                EncoderSettings.FilterMethod = PngEncoderSettings.BestCompression.FilterMethod;
                EncoderSettings.CompressionLevel = PngEncoderSettings.BestCompression.CompressionLevel;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of CustomRadioButton object.
        /// </summary>
        private void customRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // if custom encoding should be set
            if (customRadioButton.Checked)
                // enable custom settings UI
                customGroupBox.Enabled = true;
        }

        #endregion


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
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

            adam7InterlacingCheckBox.Checked = EncoderSettings.InterlaceMethod == PngInterlaceMethod.Adam7;

            if (EditAnnotationSettings)
            {
                annotationsBinaryCheckBox.Checked = (EncoderSettings.AnnotationsFormat | AnnotationsFormat.VintasoftBinary) != 0;
            }
        }

        /// <summary>
        /// Updates the encoder settings.
        /// </summary>
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

            if (adam7InterlacingCheckBox.Checked)
                EncoderSettings.InterlaceMethod = PngInterlaceMethod.Adam7;
            else
                EncoderSettings.InterlaceMethod = PngInterlaceMethod.NoInterlace;

            EncoderSettings.AnnotationsFormat = AnnotationsFormat.None;
            if (annotationsBinaryCheckBox.Checked)
                EncoderSettings.AnnotationsFormat |= AnnotationsFormat.VintasoftBinary;
        }

        #endregion

        #endregion

    }
}
