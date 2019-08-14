using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Codecs.Encoders;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit the rendering settings.
    /// </summary>
    public partial class RenderingSettingsForm : Form
    {

        #region Constructor

        public RenderingSettingsForm(RenderingSettings renderingSettings)
        {
            InitializeComponent();

            if (renderingSettings == null)
                renderingSettings = RenderingSettings.Empty;

            _renderingSettings = renderingSettings;

            interpolationModeComboBox.Items.Add(InterpolationMode.Bicubic);
            interpolationModeComboBox.Items.Add(InterpolationMode.Bilinear);
            interpolationModeComboBox.Items.Add(InterpolationMode.Default);
            interpolationModeComboBox.Items.Add(InterpolationMode.High);
            interpolationModeComboBox.Items.Add(InterpolationMode.HighQualityBicubic);
            interpolationModeComboBox.Items.Add(InterpolationMode.HighQualityBilinear);
            interpolationModeComboBox.Items.Add(InterpolationMode.Low);
            interpolationModeComboBox.Items.Add(InterpolationMode.NearestNeighbor);

            smoothingModeComboBox.Items.Add(SmoothingMode.AntiAlias);
            smoothingModeComboBox.Items.Add(SmoothingMode.Default);
            smoothingModeComboBox.Items.Add(SmoothingMode.HighQuality);
            smoothingModeComboBox.Items.Add(SmoothingMode.HighSpeed);
            smoothingModeComboBox.Items.Add(SmoothingMode.None);

            if (renderingSettings.IsEmpty || renderingSettings.Resolution.IsEmpty())
            {
                cbDefault.Checked = true;
                smoothingModeComboBox.SelectedItem = SmoothingMode.HighQuality;
                interpolationModeComboBox.SelectedItem = InterpolationMode.HighQualityBilinear;
                optimizeImageDrawingCheckBox.Checked = true;
            }
            else
            {
                cbDefault.Checked = false;
                smoothingModeComboBox.SelectedItem = renderingSettings.SmoothingMode;
                interpolationModeComboBox.SelectedItem = renderingSettings.InterpolationMode;
                horizontalResolution.Value = (int)renderingSettings.Resolution.Horizontal;
                verticalResolution.Value = (int)renderingSettings.Resolution.Vertical;
                optimizeImageDrawingCheckBox.Checked = renderingSettings.OptimizeImageDrawing;
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

        public static void SetRenderingSettingsIfNeed(ImageCollection images, EncoderBase encoder, RenderingSettings defaultRenderingSettings)
        {
            if (encoder == null || !(encoder is IPdfEncoder))
            {
                for (int i = 0; i < images.Count; i++)
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

        public static void SetRenderingSettingsIfNeed(VintasoftImage image, EncoderBase encoder, RenderingSettings defaultRenderingSettings)
        {
            if (encoder == null || !(encoder is IPdfEncoder))
            {
                if (image.SourceInfo.DecoderName == "Pdf")
                {
                    RenderingSettingsForm settingsForm = new RenderingSettingsForm(defaultRenderingSettings.CreateClone());
                    if (settingsForm.ShowDialog() == DialogResult.OK)
                        image.RenderingSettings = settingsForm.RenderingSettings;
                }
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (cbDefault.Checked)
                _renderingSettings = Vintasoft.Imaging.Codecs.Decoders.RenderingSettings.Empty;
            else
            {
                _renderingSettings = new RenderingSettings(
                    (float)horizontalResolution.Value,
                    (float)verticalResolution.Value,
                    (InterpolationMode)interpolationModeComboBox.SelectedItem,
                    (SmoothingMode)smoothingModeComboBox.SelectedItem);
                _renderingSettings.OptimizeImageDrawing = optimizeImageDrawingCheckBox.Checked;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void cbDefault_CheckedChanged(object sender, EventArgs e)
        {
            gbCustomSettings.Enabled = !cbDefault.Checked;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Abort;
            Close();
        }

        #endregion

    }
}