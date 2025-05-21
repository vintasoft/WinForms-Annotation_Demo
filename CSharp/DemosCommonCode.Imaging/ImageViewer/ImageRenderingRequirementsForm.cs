using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using Vintasoft.Imaging.ImageRendering;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit the image rendering requirements.
    /// </summary>
    public partial class ImageRenderingRequirementsForm : Form
    {

        #region Fields

        /// <summary>
        /// Dictionary: codec name => the image size in megapixels.
        /// </summary>
        Dictionary<string, float> _codecNameToImageSizeInMegapixels = new Dictionary<string, float>();

        /// <summary>
        /// Dictionary: codec name => the image size in megabytes.
        /// </summary>
        Dictionary<string, float> _codecNameToImageSizeInMegabytes  = new Dictionary<string, float>();

        /// <summary>
        /// The available codec names.
        /// </summary>
        string[] _codecNames = new string[] { "Bmp", "Jpeg", "Jpeg2000", "Tiff", "Png", "Pdf", "Psd", "Svg", "Docx", "Xlsx", "Wmf", "Emf" };

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageRenderingRequirementsForm"/> class.
        /// </summary>
        public ImageRenderingRequirementsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageRenderingRequirementsForm"/> class.
        /// </summary>
        /// <param name="renderingRequirements">The rendering requirements.</param>
        public ImageRenderingRequirementsForm(ImageRenderingRequirements renderingRequirements)
            : this()
        {
            _renderingRequirements = renderingRequirements;

            ShowSettings();
        }

        #endregion



        #region Properties

        ImageRenderingRequirements _renderingRequirements;
        /// <summary>
        /// Gets the current rendering requirements.
        /// </summary>
        public ImageRenderingRequirements RenderingRequirements
        {
            get
            {
                return _renderingRequirements;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // for each codec in codecs
            for (int i = 0; i < _codecNames.Length; i++)
            {
                // get codec
                string codec = _codecNames[i];
                // if codec has rendering requirement
                if (_codecNameToImageSizeInMegapixels.ContainsKey(codec))
                {
                    // if current codec is "TIFF"
                    if (codec == "Tiff")
                        _renderingRequirements.SetRequirement(codec, new TiffRenderingRequirement(_codecNameToImageSizeInMegapixels[codec]));
                    else
                        _renderingRequirements.SetRequirement(codec, new ImageSizeRenderingRequirement(_codecNameToImageSizeInMegapixels[codec]));
                }
                else if (_codecNameToImageSizeInMegabytes.ContainsKey(codec))
                {
                    // if current codec is "TIFF"
                    if (codec == "Tiff")
                        _renderingRequirements.SetRequirement(codec, new TiffMemoryUsageRenderingRequirement(_codecNameToImageSizeInMegabytes[codec]));
                    else
                        _renderingRequirements.SetRequirement(codec, new MemoryUsageRenderingRequirement(_codecNameToImageSizeInMegabytes[codec]));
                }
                else
                {
                    _renderingRequirements.SetRequirement(codec, null);
                }
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the TextChanged event of imageSizeComboBox object.
        /// </summary>
        private void imageSizeComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // update requirement image size for selected codec
                string codecName = (string)codecComboBox.SelectedItem;
                float value = float.Parse(imageSizeComboBox.Text, CultureInfo.InvariantCulture);
                if (_codecNameToImageSizeInMegapixels.ContainsKey(codecName))
                    _codecNameToImageSizeInMegapixels[codecName] = value;
                if (_codecNameToImageSizeInMegabytes.ContainsKey(codecName))
                    _codecNameToImageSizeInMegabytes[codecName] = value;
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of codecComboBox object.
        /// </summary>
        private void codecComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateImageSizeComboBox();
        }

        /// <summary>
        /// Handles the Click event of removeButton object.
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            // get selected codec
            string codec = codecComboBox.SelectedItem.ToString();
            // if selected codec contains image size requirement
            if (_codecNameToImageSizeInMegapixels.ContainsKey(codec) || _codecNameToImageSizeInMegabytes.ContainsKey(codec))
            {
                // remove image size requirement
                _codecNameToImageSizeInMegapixels.Remove(codec);
                _codecNameToImageSizeInMegabytes.Remove(codec);
                codecComboBox.Items.Remove(codec);
                codecComboBox.SelectedIndex = codecComboBox.Items.Count - 1;
                UpdateUI();
            }
        }

        /// <summary>
        /// Handles the Click event of addButton object.
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            // create image size rendering requirement
            using (ImageRenderingRequirementAddForm dialog = new ImageRenderingRequirementAddForm())
            {
                // if rendering requirement must be created
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // get codec
                    string codec = dialog.Codec;
                    // get image size requirement size
                    float value = dialog.ImageSize;

                    // if rendering requirement must be updated
                    if (_codecNameToImageSizeInMegapixels.ContainsKey(codec))
                    {
                        _codecNameToImageSizeInMegapixels[codec] = value;
                    }
                    else if (_codecNameToImageSizeInMegabytes.ContainsKey(codec))
                    {
                        _codecNameToImageSizeInMegabytes[codec] = value;
                    }
                    // if rendering requirement must be added
                    else
                    {
                        _codecNameToImageSizeInMegapixels.Add(codec, value);
                        codecComboBox.Items.Add(codec);
                    }

                    // update user interface
                    UpdateUI();

                    // if current codec is selected
                    if (codecComboBox.SelectedItem != null &&
                        codecComboBox.SelectedItem.ToString() == codec)
                    {
                        // update image size rendering requirement
                        UpdateImageSizeComboBox();
                    }
                    else
                    {
                        // select the current codec
                        codecComboBox.SelectedItem = codec;
                    }
                }
            }
        }

        #endregion


        /// <summary>
        /// Shows the <see cref="RenderingRequirements"/> settings.
        /// </summary>
        private void ShowSettings()
        {
            // for each codec in available codecs
            for (int i = 0; i < _codecNames.Length; i++)
            {
                // get image size rendering requirements
                ImageSizeRenderingRequirement sizeRequirement =
                    _renderingRequirements.GetRequirement(_codecNames[i]) as ImageSizeRenderingRequirement;
                if (sizeRequirement != null)
                {
                    codecComboBox.Items.Add(_codecNames[i]);
                    _codecNameToImageSizeInMegapixels.Add(_codecNames[i], sizeRequirement.ImageSize);
                }

                // get memory usage rendering requirements
                MemoryUsageRenderingRequirement memoryRequirement =
                    _renderingRequirements.GetRequirement(_codecNames[i]) as MemoryUsageRenderingRequirement;
                if (memoryRequirement != null)
                {
                    codecComboBox.Items.Add(_codecNames[i]);
                    _codecNameToImageSizeInMegabytes.Add(_codecNames[i], memoryRequirement.MemorySize);
                }
            }

            if (codecComboBox.Items.Count > 0)
                codecComboBox.SelectedIndex = 0;
            UpdateUI();
        }

        /// <summary>
        /// Initialize the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            bool isEmptyRenderingRequirments = _codecNameToImageSizeInMegapixels.Count == 0;

            codecComboBox.Enabled = !isEmptyRenderingRequirments;
            imageSizeComboBox.Enabled = !isEmptyRenderingRequirments;
            removeButton.Enabled = !isEmptyRenderingRequirments;
        }

        /// <summary>
        /// Updates the image size rendering requirement combo box.
        /// </summary>
        private void UpdateImageSizeComboBox()
        {
            string codecName = (string)codecComboBox.SelectedItem;
            // update image size requirement for selected codec
            if (_codecNameToImageSizeInMegapixels.ContainsKey(codecName))
            {
                imageSizeComboBox.Text = _codecNameToImageSizeInMegapixels[codecName].ToString(CultureInfo.InvariantCulture);
                sizeTypeLabel.Text = "Megapixels";
            }
            else if (_codecNameToImageSizeInMegabytes.ContainsKey(codecName))
            {
                imageSizeComboBox.Text = _codecNameToImageSizeInMegabytes[codecName].ToString(CultureInfo.InvariantCulture);
                sizeTypeLabel.Text = "Megabytes";
            }
        }

        #endregion

    }
}
