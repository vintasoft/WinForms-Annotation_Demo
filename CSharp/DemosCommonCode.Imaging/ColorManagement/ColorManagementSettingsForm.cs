using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.ColorManagement;
using Vintasoft.Imaging.ColorManagement.Icc;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Imaging.ColorManagement
{
    /// <summary>
    /// A form that allows to view and edit the color management decode settings.
    /// </summary>
    public partial class ColorManagementSettingsForm : Form
    {

        #region Constants

        /// <summary>
        /// Default input CMYK ICC profile.
        /// </summary>
        public const string DEFAULT_INPUT_CMYK_PROFILE = "DefaultCMYK.icc";

        #endregion



        #region Fields

        /// <summary>
        /// Open file dialog for selecting ICC file.
        /// </summary>
        OpenFileDialog _openIccFileDialog;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorManagementSettingsForm"/> class.
        /// </summary>
        public ColorManagementSettingsForm()
        {
            InitializeComponent();

            intentComboBox.Items.Add(RenderingIntent.Perceptual);
            intentComboBox.Items.Add(RenderingIntent.MediaRelativeColorimetric);
            intentComboBox.Items.Add(RenderingIntent.Saturation);
            intentComboBox.Items.Add(RenderingIntent.IccAbsoluteColorimetric);
            intentComboBox.SelectedItem = RenderingIntent.Perceptual;

            RemoveProfileDescription(inputCmykTextBox);
            RemoveProfileDescription(inputRgbTextBox);
            RemoveProfileDescription(inputGrayscaleTextBox);
            RemoveProfileDescription(outputRgbTextBox);
            RemoveProfileDescription(outputGrayscaleTextBox);

            _openIccFileDialog = new OpenFileDialog();
            _openIccFileDialog.Filter = "ICC profiles|*.icc;*.icm|All files|*.*";
            _openIccFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        }

        #endregion



        #region Properties

        ColorManagementDecodeSettings _colorManagementSettings;
        /// <summary>
        /// Gets or sets a color management decode settings.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ColorManagementDecodeSettings ColorManagementSettings
        {
            get
            {
                SetSettings();
                return _colorManagementSettings;
            }
            set
            {
                _colorManagementSettings = value;
                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Edits a color management settings of specified image viewer.
        /// </summary>
        public static bool EditColorManagement(ImageViewerBase imageViewer)
        {
            using (ColorManagementSettingsForm colorManagementSettingsForm = new ColorManagementSettingsForm())
            {
                if (imageViewer.ImageDecodingSettings == null)
                    colorManagementSettingsForm.ColorManagementSettings = null;
                else
                    colorManagementSettingsForm.ColorManagementSettings = imageViewer.ImageDecodingSettings.ColorManagement;

                colorManagementSettingsForm.TopMost = true;

                if (colorManagementSettingsForm.ShowDialog() == DialogResult.OK)
                {
                    DecodingSettings settings = imageViewer.ImageDecodingSettings;
                    if (settings == null)
                        settings = new DecodingSettings();

                    settings.ColorManagement = colorManagementSettingsForm.ColorManagementSettings;
                    imageViewer.ImageDecodingSettings = settings;

                    // reload images in image viewer
                    DemosTools.ReloadImagesInViewer(imageViewer);

                    return true;
                }

                return false;
            }
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of setInputProfileButton object.
        /// </summary>
        private void setInputProfileButton_Click(object sender, EventArgs e)
        {
            // if input ICC profile is selected
            if (_openIccFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // create ICC profile
                    IccProfile iccProfile = new IccProfile(_openIccFileDialog.FileName);
                    _openIccFileDialog.InitialDirectory = Path.GetDirectoryName(_openIccFileDialog.FileName);
                    IccProfile oldIccProfile = null;

                    switch (iccProfile.DeviceColorSpace)
                    {
                        case ColorSpaceType.CMYK:
                            oldIccProfile = _colorManagementSettings.InputCmykProfile;
                            _colorManagementSettings.InputCmykProfile = iccProfile;
                            ShowProfileDescription(inputCmykTextBox, iccProfile);
                            break;

                        case ColorSpaceType.sRGB:
                            oldIccProfile = _colorManagementSettings.InputRgbProfile;
                            _colorManagementSettings.InputRgbProfile = iccProfile;
                            ShowProfileDescription(inputRgbTextBox, iccProfile);
                            break;

                        case ColorSpaceType.Gray:
                            oldIccProfile = _colorManagementSettings.InputGrayscaleProfile;
                            _colorManagementSettings.InputGrayscaleProfile = iccProfile;
                            ShowProfileDescription(inputGrayscaleTextBox, iccProfile);
                            break;

                        default:
                            iccProfile.Dispose();
                            throw new Exception(string.Format("Unexpected profile color space: {0}.", iccProfile.DeviceColorSpace));
                    }

                    if (oldIccProfile != null)
                        oldIccProfile.Dispose();
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of setOutputProfileButton object.
        /// </summary>
        private void setOutputProfileButton_Click(object sender, EventArgs e)
        {
            // if output ICC profile is selected
            if (_openIccFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IccProfile iccProfile = new IccProfile(_openIccFileDialog.FileName);
                    _openIccFileDialog.InitialDirectory = Path.GetDirectoryName(_openIccFileDialog.FileName);
                    IccProfile oldIccProfile = null;

                    switch (iccProfile.DeviceColorSpace)
                    {
                        case ColorSpaceType.sRGB:
                            oldIccProfile = _colorManagementSettings.OutputRgbProfile;
                            _colorManagementSettings.OutputRgbProfile = iccProfile;
                            ShowProfileDescription(outputRgbTextBox, iccProfile);
                            break;

                        case ColorSpaceType.Gray:
                            oldIccProfile = _colorManagementSettings.OutputGrayscaleProfile;
                            _colorManagementSettings.OutputGrayscaleProfile = iccProfile;
                            ShowProfileDescription(outputGrayscaleTextBox, iccProfile);
                            break;

                        default:
                            iccProfile.Dispose();
                            throw new Exception(string.Format("Unexpected profile color space: {0}.", iccProfile.DeviceColorSpace));
                    }

                    if (oldIccProfile != null)
                        oldIccProfile.Dispose();
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of removeInputCmykButton object.
        /// </summary>
        private void removeInputCmykButton_Click(object sender, EventArgs e)
        {
            // get input CMYK profile
            IccProfile profile = _colorManagementSettings.InputCmykProfile;
            // if CMYK profile is exist
            if (profile != null)
            {
                // remove input CMYK profile
                _colorManagementSettings.InputCmykProfile = null;
                profile.Dispose();
            }
            // update user interface
            RemoveProfileDescription(inputCmykTextBox);
        }

        /// <summary>
        /// Handles the Click event of removeInputRgbButton object.
        /// </summary>
        private void removeInputRgbButton_Click(object sender, EventArgs e)
        {
            // get input RGB profile
            IccProfile profile = _colorManagementSettings.InputRgbProfile;
            // if RGB profile is exist
            if (profile != null)
            {
                // remove input RGB profile
                _colorManagementSettings.InputRgbProfile = null;
                profile.Dispose();
            }
            // update user interface
            RemoveProfileDescription(inputRgbTextBox);
        }

        /// <summary>
        /// Handles the Click event of removeInputGrayscaleButton object.
        /// </summary>
        private void removeInputGrayscaleButton_Click(object sender, EventArgs e)
        {
            // get input grayscale profile
            IccProfile profile = _colorManagementSettings.InputGrayscaleProfile;
            // if grayscale profile is exist
            if (profile != null)
            {
                // remove input grayscale profile
                _colorManagementSettings.InputGrayscaleProfile = null;
                profile.Dispose();
            }
            // update user interface
            RemoveProfileDescription(inputGrayscaleTextBox);
        }

        /// <summary>
        /// Handles the Click event of removeOutputRgbButton object.
        /// </summary>
        private void removeOutputRgbButton_Click(object sender, EventArgs e)
        {
            // get output RGB profile
            IccProfile profile = _colorManagementSettings.OutputRgbProfile;
            // if RGB profile is exist
            if (profile != null)
            {
                // remove output RGB profile
                _colorManagementSettings.OutputRgbProfile = null;
                profile.Dispose();
            }
            // update user interface
            RemoveProfileDescription(outputRgbTextBox);
        }

        /// <summary>
        /// Handles the Click event of removeOutputGrayscaleButton object.
        /// </summary>
        private void removeOutputGrayscaleButton_Click(object sender, EventArgs e)
        {
            // get output grayscale profile
            IccProfile profile = _colorManagementSettings.OutputGrayscaleProfile;
            // if grayscale profile is exist
            if (profile != null)
            {
                // remove output grayscale profile
                _colorManagementSettings.OutputGrayscaleProfile = null;
                profile.Dispose();
            }
            // update user interface
            RemoveProfileDescription(outputGrayscaleTextBox);
        }

        /// <summary>
        /// Handles the Click event of editColorTransformsButton object.
        /// </summary>
        private void editColorTransformsButton_Click(object sender, EventArgs e)
        {
            // create color transform editor
            using (ColorTransformSetEditorForm editorForm = new ColorTransformSetEditorForm(_colorManagementSettings.ColorSpaceTransforms))
            {
                editorForm.TopMost = TopMost;

                // if color transform must be updated
                if (editorForm.ShowDialog() == DialogResult.OK)
                {
                    _colorManagementSettings.ColorSpaceTransforms.Clear();
                    _colorManagementSettings.ColorSpaceTransforms.AddRange(editorForm.ColorTransformSet.ToArray());
                }
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of enableColorManagementCheckBox object.
        /// </summary>
        private void enableColorManagementCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if color managment must be used
            if (enableColorManagementCheckBox.Checked)
            {
                // enable decoding settings user interface
                decodingSettingsGroupBox.Enabled = true;

                // if color managment settings must be created
                if (_colorManagementSettings == null)
                {
                    // create color managment settings
                    ColorManagementDecodeSettings settings = new ColorManagementDecodeSettings();
                    // load default profiles
                    LoadDefaultInputCmykProfile(settings);
                    // update color managment settings
                    ColorManagementSettings = settings;
                }
            }
            else
            {
                // disable decoding settings user interface
                decodingSettingsGroupBox.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // update color managment settings
            SetSettings();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of buttonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            if (_colorManagementSettings == null)
            {
                enableColorManagementCheckBox.Checked = false;
            }
            else
            {
                enableColorManagementCheckBox.Checked = true;

                useEmbeddedProfilesCheckBox.Checked = _colorManagementSettings.UseEmbeddedInputProfile;
                blackPointCompensationCheckBox.Checked = _colorManagementSettings.UseBlackPointCompensation;
                intentComboBox.SelectedItem = _colorManagementSettings.RenderingIntent;

                if (_colorManagementSettings.InputCmykProfile != null)
                    ShowProfileDescription(inputCmykTextBox, _colorManagementSettings.InputCmykProfile);

                if (_colorManagementSettings.InputRgbProfile != null)
                    ShowProfileDescription(inputRgbTextBox, _colorManagementSettings.InputRgbProfile);

                if (_colorManagementSettings.InputGrayscaleProfile != null)
                    ShowProfileDescription(inputGrayscaleTextBox, _colorManagementSettings.InputGrayscaleProfile);

                if (_colorManagementSettings.OutputRgbProfile != null)
                    ShowProfileDescription(outputRgbTextBox, _colorManagementSettings.OutputRgbProfile);

                if (_colorManagementSettings.OutputGrayscaleProfile != null)
                    ShowProfileDescription(outputGrayscaleTextBox, _colorManagementSettings.OutputGrayscaleProfile);
            }
        }

        /// <summary>
        /// Sets curent settings to <see cref="ColorManagementSettings"/> property.
        /// </summary>
        private void SetSettings()
        {
            if (enableColorManagementCheckBox.Checked)
            {
                if (useEmbeddedProfilesCheckBox.Checked)
                    _colorManagementSettings.UseEmbeddedInputProfile = true;
                else
                    _colorManagementSettings.UseEmbeddedInputProfile = false;
                if (blackPointCompensationCheckBox.Checked)
                    _colorManagementSettings.UseBlackPointCompensation = true;
                else
                    _colorManagementSettings.UseBlackPointCompensation = false;
                _colorManagementSettings.RenderingIntent = (RenderingIntent)intentComboBox.SelectedItem;
            }
            else
            {
                _colorManagementSettings = null;
            }
        }

        /// <summary>
        /// Loads the default input CMYK ICC profile.
        /// </summary>
        private void LoadDefaultInputCmykProfile(ColorManagementDecodeSettings settings)
        {
            try
            {
                // search directories
                string[] directories = new string[]
                    {
                        "",
                        @"..\..\..\..\Bin\DotNet4\AnyCPU\",
                    };

                // search profile
                string defaultInputCmykFilename = "";
                foreach (string dir in directories)
                {
                    string profileDirectory = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), dir));
                    if (File.Exists(Path.Combine(profileDirectory, DEFAULT_INPUT_CMYK_PROFILE)))
                    {
                        defaultInputCmykFilename = Path.Combine(profileDirectory, DEFAULT_INPUT_CMYK_PROFILE);
                        break;
                    }
                }

                // if profile was found
                if (defaultInputCmykFilename != "")
                    settings.InputCmykProfile = new IccProfile(defaultInputCmykFilename);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Shows the profile description in specified text box.
        /// </summary>
        private void ShowProfileDescription(TextBox textBox, IccProfile profile)
        {
            textBox.Text = profile.ToString();
        }

        /// <summary>
        /// Removed the profile description from specified text box.
        /// </summary>
        private void RemoveProfileDescription(TextBox textBox)
        {
            textBox.Text = "(none)";
        }

        #endregion

        #endregion

    }
}
