using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.ImageRendering;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and change settings of the image viewer.
    /// </summary>
    public partial class ImageViewerSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// The image viewer.
        /// </summary>
        ImageViewer _viewer;

        /// <summary>
        /// The rendering settings of image viewer.
        /// </summary>
        RenderingSettings _renderingSettings;

        /// <summary>
        /// The rendering requirements of image in image viewer.
        /// </summary>
        ImageRenderingRequirements _renderingRequirements;

        /// <summary>
        /// The image appearance of image viewer.
        /// </summary>
        ThumbnailAppearance _imageAppearance;

        /// <summary>
        /// The focused image appearance of image viewer.
        /// </summary>
        ThumbnailAppearance _focusedImageAppearance;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageViewerSettingsForm"/> class.
        /// </summary>
        public ImageViewerSettingsForm()
        {
            InitializeComponent();

            // init "Rendering quality"
            renderingQualityComboBox.Items.Add(ImageRenderingQuality.Low);
            renderingQualityComboBox.Items.Add(ImageRenderingQuality.Normal);
            renderingQualityComboBox.Items.Add(ImageRenderingQuality.High);

            // init "Layout direction"
            layoutDirectionComboBox.Items.Add(ImagesLayoutDirection.Horizontal);
            layoutDirectionComboBox.Items.Add(ImagesLayoutDirection.Vertical);

            // init "Multipage display mode"
            multipageDisplayModeComboBox.Items.Add(ImageViewerMultipageDisplayMode.FixedImages);
            multipageDisplayModeComboBox.Items.Add(ImageViewerMultipageDisplayMode.FixedImagesContinuous);
            multipageDisplayModeComboBox.Items.Add(ImageViewerMultipageDisplayMode.AllImages);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageViewerSettingsForm"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer.</param>
        public ImageViewerSettingsForm(ImageViewer viewer)
            : this()
        {
            _viewer = viewer;
            ShowSettings();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether multipage settings can be edited.
        /// </summary>
        public bool CanEditMultipageSettings
        {
            get
            {
                return imagesDisplayModeGroupBox.Visible;
            }
            set
            {
                imagesDisplayModeGroupBox.Visible = value;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of RenderingSettingsButton object.
        /// </summary>
        private void renderingSettingsButton_Click(object sender, EventArgs e)
        {
            // create rendering settings dialog
            using (RenderingSettingsForm renderingSettingsDialog =
                new RenderingSettingsForm(_renderingSettings))
            {
                // if rendering setting must be updated
                if (renderingSettingsDialog.ShowDialog() == DialogResult.OK)
                    // update rendering settings
                    _renderingSettings = renderingSettingsDialog.RenderingSettings;
            }
        }

        /// <summary>
        /// Handles the Click event of ButtonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // apply settings to the image viewer
            ApplySettings();

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of RenderingRequirementsButton object.
        /// </summary>
        private void renderingRequirementsButton_Click(object sender, EventArgs e)
        {
            // if rendering requirement does not exist
            if (_renderingRequirements == null)
                // create rendering requirement
                _renderingRequirements = new ImageRenderingRequirements(_viewer.RenderingRequirements);

            // create rendering requirements form
            using (ImageRenderingRequirementsForm renderingRequirements =
                new ImageRenderingRequirementsForm(_renderingRequirements))
            {
                // if rendering requirements muust be changed
                if (renderingRequirements.ShowDialog() == DialogResult.OK)
                    // update rendering requrements
                    _renderingRequirements = renderingRequirements.RenderingRequirements;
            }
        }

        /// <summary>
        /// Handles the Click event of ImageAppearance object.
        /// </summary>
        private void imageAppearance_Click(object sender, EventArgs e)
        {
            // if image appearance does not exist
            if (_imageAppearance == null)
                // create image appearance
                _imageAppearance = new ThumbnailAppearance(_viewer.ImageAppearance);

            // create image appearance settings form
            using (ThumbnailAppearanceSettingsForm dialog =
                new ThumbnailAppearanceSettingsForm(_imageAppearance, "Not Focused Image Appearance Settings"))
            {
                // show dialog
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of FocusedImageAppearance object.
        /// </summary>
        private void focusedImageAppearance_Click(object sender, EventArgs e)
        {
            // if focused image appearance does not exist
            if (_focusedImageAppearance == null)
                // create focused image appearance
                _focusedImageAppearance = new ThumbnailAppearance(_viewer.FocusedImageAppearance);

            // create image appearance settings form
            using (ThumbnailAppearanceSettingsForm dialog =
                new ThumbnailAppearanceSettingsForm(_focusedImageAppearance, "Focused Image Appearance Settings"))
            {
                // show dialog
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of KeyboardNavigationCheckBox object.
        /// </summary>
        private void keyboardNavigationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if keyboard navigation must be enabled
            if (keyboardNavigationCheckBox.Checked)
                keyboardNavigationGroupBox.Enabled = true;
            else
                keyboardNavigationGroupBox.Enabled = false;
        }

        #endregion


        /// <summary>
        /// Shows settings of the image viewer.
        /// </summary>
        private void ShowSettings()
        {
            // image anchor
            imageAnchorTypeEditor.SelectedAnchorType = _viewer.ImageAnchor;

            // rendering quality
            renderingQualityComboBox.SelectedItem = _viewer.RenderingQuality;

            // focus point
            focusPointAnchorTypeEditor.SelectedAnchorType = _viewer.FocusPointAnchor;
            focusPointIsFixedCheckBox.Checked = _viewer.IsFocusPointFixed;

            // buffering
            rendererCacheSizeNumericUpDown.Value = (int)Math.Round(_viewer.RendererCacheSize);
            viewerBufferSizeNumericUpDown.Value = (int)Math.Round(_viewer.ViewerBufferSize);
            minImageSizeWhenZoomBufferUsedNumericUpDown.Value = (int)Math.Round(_viewer.MinImageSizeWhenZoomBufferUsed);

            // backgroud color
            backgroundColorPanelControl.Color = _viewer.BackColor;

            // rendering
            _renderingSettings = _viewer.ImageRenderingSettings;
            previewIntervalOfVectorImagesNumericUpDown.Value = _viewer.IntermediateImagePreviewInterval;
            vectorRenderingQualityFactorTrackBar.Value = (int)((_viewer.VectorRenderingQualityFactor - 1) * 4f);
            maxThreadsNumericUpDown.Value = _viewer.MaxThreadsForRendering;
            renderOnlyVisibleImagesCheckBox.Checked = _viewer.RenderOnlyVisibleImages;

            // image display mode
            multipageDisplayModeComboBox.SelectedItem = _viewer.MultipageDisplayMode;
            layoutDirectionComboBox.SelectedItem = _viewer.MultipageDisplayLayoutDirection;
            imagesInRowColumnNumericUpDown.Value = _viewer.MultipageDisplayRowCount;
            imagesPaddingNumericUpDown.Value = (decimal)_viewer.MultipageDisplayImagePadding.All;
            _imageAppearance = _viewer.ImageAppearance;
            _focusedImageAppearance = _viewer.FocusedImageAppearance;
            useImageAppearancesInSinglepageModeCheckBox.Checked = _viewer.UseImageAppearancesInSinglePageMode;

            // keyboard
            keyboardNavigationCheckBox.Checked = _viewer.IsKeyboardNavigationEnabled;
            keyboardNavigationGroupBox.Enabled = keyboardNavigationCheckBox.Checked;
            keyboardNavigationScrollStepNumericUpDown.Value = _viewer.KeyboardNavigationScrollStep;
            keyboardNavigationZoomStepNumericUpDown.Value = (decimal)_viewer.KeyboardNavigationZoomStep;
        }

        /// <summary>
        /// Applies settings to the image viewer.
        /// </summary>
        private void ApplySettings()
        {
            // image anchor
            _viewer.ImageAnchor = imageAnchorTypeEditor.SelectedAnchorType;

            // rendering quality
            _viewer.RenderingQuality = (ImageRenderingQuality)renderingQualityComboBox.SelectedItem;

            // focus point
            _viewer.FocusPointAnchor = focusPointAnchorTypeEditor.SelectedAnchorType;
            _viewer.IsFocusPointFixed = focusPointIsFixedCheckBox.Checked;

            // buffering
            _viewer.RendererCacheSize = (int)rendererCacheSizeNumericUpDown.Value;
            _viewer.ViewerBufferSize = (int)viewerBufferSizeNumericUpDown.Value;
            _viewer.MinImageSizeWhenZoomBufferUsed = (int)minImageSizeWhenZoomBufferUsedNumericUpDown.Value;

            // rendering
            _viewer.VectorRenderingQualityFactor =
                1 + (vectorRenderingQualityFactorTrackBar.Value / 4f);

            if (_renderingSettings != null)
            {
                if (_viewer.ImageRenderingSettings == null)
                {
                    _viewer.ImageRenderingSettings = _renderingSettings.CreateClone();
                }
                else
                {
                    _viewer.ImageRenderingSettings.InterpolationMode = _renderingSettings.InterpolationMode;
                    _viewer.ImageRenderingSettings.SmoothingMode = _renderingSettings.SmoothingMode;
                    _viewer.ImageRenderingSettings.Resolution = _renderingSettings.Resolution;
                    _viewer.ImageRenderingSettings.OptimizeImageDrawing = _renderingSettings.OptimizeImageDrawing;
                }
            }

            if (_renderingRequirements != null)
                _viewer.RenderingRequirements = _renderingRequirements;

            _viewer.IntermediateImagePreviewInterval = (int)previewIntervalOfVectorImagesNumericUpDown.Value;

            _viewer.MaxThreadsForRendering = (int)maxThreadsNumericUpDown.Value;

            _viewer.RenderOnlyVisibleImages = renderOnlyVisibleImagesCheckBox.Checked;

            // backgroud color
            _viewer.BackColor = backgroundColorPanelControl.Color;

            // image display mode
            _viewer.MultipageDisplayMode = (ImageViewerMultipageDisplayMode)multipageDisplayModeComboBox.SelectedItem;
            _viewer.MultipageDisplayLayoutDirection = (ImagesLayoutDirection)layoutDirectionComboBox.SelectedItem;
            _viewer.MultipageDisplayRowCount = (int)imagesInRowColumnNumericUpDown.Value;
            _viewer.MultipageDisplayImagePadding = new PaddingF((float)imagesPaddingNumericUpDown.Value);
            _viewer.ImageAppearance = _imageAppearance;
            _viewer.FocusedImageAppearance = _focusedImageAppearance;
            _viewer.UseImageAppearancesInSinglePageMode = useImageAppearancesInSinglepageModeCheckBox.Checked;

            // keyboard
            _viewer.IsKeyboardNavigationEnabled = keyboardNavigationCheckBox.Checked;
            _viewer.KeyboardNavigationScrollStep = (int)keyboardNavigationScrollStepNumericUpDown.Value;
            _viewer.KeyboardNavigationZoomStep = (float)keyboardNavigationZoomStepNumericUpDown.Value;
        }

        #endregion

    }
}
