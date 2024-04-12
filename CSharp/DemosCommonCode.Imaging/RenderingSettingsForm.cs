using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.Drawing;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit the rendering settings.
    /// </summary>
    public partial class RenderingSettingsForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderingSettingsForm"/> class.
        /// </summary>
        /// <param name="renderingSettings">The rendering settings.</param>
        public RenderingSettingsForm(RenderingSettings renderingSettings)
        {
            InitializeComponent();

            if (renderingSettings == null)
                renderingSettings = RenderingSettings.Empty;

            _renderingSettings = renderingSettings;

            interpolationModeComboBox.Items.Add(ImageInterpolationMode.Bicubic);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.Bilinear);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.HighQualityBicubic);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.HighQualityBilinear);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.NearestNeighbor);

            smoothingModeComboBox.Items.Add(DrawingSmoothingMode.AntiAlias);
            smoothingModeComboBox.Items.Add(DrawingSmoothingMode.None);

            // if rendering settings are empty
            if (renderingSettings.IsEmpty || renderingSettings.Resolution.IsEmpty())
            {
                defaultCheckBox.Checked = true;
                smoothingModeComboBox.SelectedItem = DrawingSmoothingMode.AntiAlias;
                interpolationModeComboBox.SelectedItem = ImageInterpolationMode.HighQualityBilinear;
                optimizeImageDrawingCheckBox.Checked = true;
                drawSharpImageBordersCheckBox.Checked = true;
            }
            else
            {
                defaultCheckBox.Checked = false;
                smoothingModeComboBox.SelectedItem = renderingSettings.SmoothingMode;
                interpolationModeComboBox.SelectedItem = renderingSettings.InterpolationMode;
                horizontalResolutionNumericUpDown.Value = (int)renderingSettings.Resolution.Horizontal;
                verticalResolutionNumericUpDown.Value = (int)renderingSettings.Resolution.Vertical;
                optimizeImageDrawingCheckBox.Checked = renderingSettings.OptimizeImageDrawing;
                drawSharpImageBordersCheckBox.Checked = renderingSettings.DrawSharpImageBorders;
            }
        }

        #endregion



        #region Properties

        RenderingSettings _renderingSettings;
        /// <summary>
        /// Gets the rendering settings.
        /// </summary>
        public RenderingSettings RenderingSettings
        {
            get
            {
                return _renderingSettings;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Sets the rendering settings if necessary.
        /// </summary>
        /// <param name="images">The images.</param>
        /// <param name="encoder">The encoder.</param>
        /// <param name="defaultRenderingSettings">The default rendering settings.</param>
        public static void SetRenderingSettingsIfNeed(
            ImageCollection images, EncoderBase encoder, RenderingSettings defaultRenderingSettings)
        {
            if (encoder == null || !(encoder is IPdfEncoder))
            {
                for (int i = 0; i < images.Count; i++)
                {
                    if (images[i].IsVectorImage)
                    {
                        RenderingSettingsForm settingsForm = new RenderingSettingsForm(defaultRenderingSettings.CreateClone());
                        if (settingsForm.ShowDialog() == DialogResult.OK)
                            images.SetRenderingSettings(settingsForm.RenderingSettings);
                        else
                            return;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the rendering settings if necessary.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="encoder">The encoder.</param>
        /// <param name="defaultRenderingSettings">The default rendering settings.</param>
        public static void SetRenderingSettingsIfNeed(
            VintasoftImage image, EncoderBase encoder, RenderingSettings defaultRenderingSettings)
        {
            if (encoder == null || !(encoder is IPdfEncoder))
            {
                if (image.IsVectorImage)
                {
                    RenderingSettingsForm settingsForm = new RenderingSettingsForm(defaultRenderingSettings.CreateClone());
                    if (settingsForm.ShowDialog() == DialogResult.OK)
                        image.RenderingSettings = settingsForm.RenderingSettings;
                }
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // if default rendering settings must be used
            if (defaultCheckBox.Checked)
            {
                RenderingSettings.Empty.CopyTo(_renderingSettings);
            }
            else
            {
                // get rendering resolution
                _renderingSettings.Resolution = new Resolution(
                    (float)horizontalResolutionNumericUpDown.Value,
                    (float)verticalResolutionNumericUpDown.Value);
                // get rendering interpolation mode
                _renderingSettings.InterpolationMode = (ImageInterpolationMode)interpolationModeComboBox.SelectedItem;
                // get rendering smotthing mode
                _renderingSettings.SmoothingMode = (DrawingSmoothingMode)smoothingModeComboBox.SelectedItem;

                // optimize image drawing
                _renderingSettings.OptimizeImageDrawing = optimizeImageDrawingCheckBox.Checked;

                // drawing sharp image borders
                _renderingSettings.DrawSharpImageBorders = drawSharpImageBordersCheckBox.Checked;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Handles the CheckedChanged event of defaultCheckBox object.
        /// </summary>
        private void defaultCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if the default rendering settings must be used
            if (defaultCheckBox.Checked)
                customSettingsGroupBox.Enabled = false;
            else
                customSettingsGroupBox.Enabled = true;
        }

        #endregion

        #endregion

    }
}
