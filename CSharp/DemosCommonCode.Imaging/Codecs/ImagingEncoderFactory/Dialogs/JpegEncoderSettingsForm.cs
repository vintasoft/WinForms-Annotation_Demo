using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Encoders;

namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    /// <summary>
    /// A form that allows to view and edit the JPEG encoder settings.
    /// </summary>
    public partial class JpegEncoderSettingsForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JpegEncoderSettingsForm"/> class.
        /// </summary>
        public JpegEncoderSettingsForm()
        {
            InitializeComponent();

            EditAnnotationSettings = false;

        } 

        #endregion



        #region Properties

        JpegEncoderSettings _encoderSettings;
        /// <summary>
        /// Gets or sets JPEG encoder settings.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JpegEncoderSettings EncoderSettings
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
        /// Creates the encoder settings.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (EncoderSettings == null)
            {
                JpegEncoderSettings settings = new JpegEncoderSettings();
                settings.GenerateOptimalHuffmanTables = true;
                EncoderSettings = settings;
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // update encoder settings
            SetEncoderSettings();

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of buttonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        /// <summary> 
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            jpegGrayscaleCheckBox.Checked = EncoderSettings.SaveAsGrayscale;
            jpegQualityNumericUpDown.Value = EncoderSettings.Quality;
            disableSubsamplingCheckBox.Checked = EncoderSettings.IsSubsamplingDisabled;
            optimizeHuffmanTablesCheckBox.Checked = EncoderSettings.GenerateOptimalHuffmanTables;
            createThumbnailCheckBox.Checked = EncoderSettings.CreateThumbnail;
            saveCommentsCheckBox.Checked = EncoderSettings.SaveComments;
            copyExifMetadataCheckBox.Checked = EncoderSettings.CopyExifMetadata;
            copyUnkwonwnApplicationMetadataCheckBox.Checked = EncoderSettings.CopyUnknownApplicationMetadata;

            annotationsBinaryCheckBox.Checked = (EncoderSettings.AnnotationsFormat & AnnotationsFormat.VintasoftBinary) != 0;
            annotationXmpCheckBox.Checked = (EncoderSettings.AnnotationsFormat & AnnotationsFormat.VintasoftXmp) != 0;
        }

        /// <summary>
        /// Updates the encoder settings.
        /// </summary>
        private void SetEncoderSettings()
        {
            EncoderSettings.SaveAsGrayscale = jpegGrayscaleCheckBox.Checked;
            EncoderSettings.Quality = (int)jpegQualityNumericUpDown.Value;
            EncoderSettings.IsSubsamplingDisabled = disableSubsamplingCheckBox.Checked;
            EncoderSettings.GenerateOptimalHuffmanTables = optimizeHuffmanTablesCheckBox.Checked;
            EncoderSettings.CreateThumbnail = createThumbnailCheckBox.Checked;
            EncoderSettings.SaveComments = saveCommentsCheckBox.Checked;
            EncoderSettings.CopyExifMetadata = copyExifMetadataCheckBox.Checked;
            EncoderSettings.CopyUnknownApplicationMetadata = copyUnkwonwnApplicationMetadataCheckBox.Checked;
            if (EditAnnotationSettings)
            {
                EncoderSettings.AnnotationsFormat = AnnotationsFormat.None;
                if (annotationsBinaryCheckBox.Checked)
                    EncoderSettings.AnnotationsFormat |= AnnotationsFormat.VintasoftBinary;
                if (annotationXmpCheckBox.Checked)
                    EncoderSettings.AnnotationsFormat |= AnnotationsFormat.VintasoftXmp;
            }
        }

        #endregion

        #endregion

    }
}
