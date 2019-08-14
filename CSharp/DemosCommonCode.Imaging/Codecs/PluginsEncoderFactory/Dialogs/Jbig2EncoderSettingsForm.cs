using System;
using System.Windows.Forms;
using Vintasoft.Imaging.Codecs;
using Vintasoft.Imaging.Codecs.Encoders;

namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    /// <summary>
    /// A form that allows to view and edit the JBIG2 encoder settings.
    /// </summary>
    public partial class Jbig2EncoderSettingsForm : Form
    {
        
        #region Constructors

        public Jbig2EncoderSettingsForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Determines that existing document should be append.
        /// </summary>
        public bool AppendExistingDocument
        {
            get
            {
                return appendCheckBox.Checked;
            }
            set
            {
                appendCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="AppendExistingDocument"/> is enabled.
        /// </summary>
        public bool AppendExistingDocumentEnabled
        {
            get
            {
                return appendCheckBox.Enabled;
            }
            set
            {
                appendCheckBox.Enabled = value;
            }
        }

        
        Jbig2EncoderSettings _encoderSettings;
        /// <summary>
        /// Gets or sets JBIG 2 encoder settings.
        /// </summary>
        public Jbig2EncoderSettings EncoderSettings
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


        #endregion



        #region Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (EncoderSettings == null)
                EncoderSettings = new Jbig2EncoderSettings();
        }

        private void compressionLossyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lossyGroupBox.Enabled = useLossyCheckBox.Checked;
        }

        private void checkBoxUseSD_CheckedChanged(object sender, EventArgs e)
        {
            symbolDictionaryGroupBox.Enabled = useSymbolDictionaryCheckBox.Checked;
        }

        private void UpdateUI()
        {
            if (EncoderSettings.UseMmr)
                mmrRadioButton.Checked = true;
            else
                arithmeticRadioButton.Checked = true;
            useLossyCheckBox.Checked = EncoderSettings.Lossy;
            inaccuracyPercentNumericUpDown.Value = EncoderSettings.Inaccuracy;
            useSymbolDictionaryCheckBox.Checked = EncoderSettings.UseSymbolDictionary;
            string symbolDictionarySize = EncoderSettings.SymbolDictionarySize.ToString();
            if (!sdSizeComboBox.Items.Contains(symbolDictionarySize))
                sdSizeComboBox.Items.Add(symbolDictionarySize);
            sdSizeComboBox.SelectedItem = symbolDictionarySize;
            lossyGroupBox.Enabled = useLossyCheckBox.Checked;
            symbolDictionaryGroupBox.Enabled = useSymbolDictionaryCheckBox.Checked;
        }

        private void SetEncoderSettings()
        {
            EncoderSettings.UseMmr = mmrRadioButton.Checked;
            EncoderSettings.Lossy = useLossyCheckBox.Checked;
            EncoderSettings.Inaccuracy = (int)inaccuracyPercentNumericUpDown.Value;
            EncoderSettings.UseSymbolDictionary = useSymbolDictionaryCheckBox.Checked;
            EncoderSettings.SymbolDictionarySize = Int32.Parse((string)sdSizeComboBox.SelectedItem);
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

        #endregion

    }
}
