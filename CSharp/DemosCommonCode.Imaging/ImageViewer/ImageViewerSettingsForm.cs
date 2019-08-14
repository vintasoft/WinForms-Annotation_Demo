using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs;
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

            object[] aStyles = new object[]
            {
                AnchorType.None,
                AnchorType.Left | AnchorType.Top,
                AnchorType.Top,
                AnchorType.Top | AnchorType.Right,
                AnchorType.Right,
                AnchorType.Bottom | AnchorType.Right,
                AnchorType.Bottom,
                AnchorType.Bottom | AnchorType.Left,
                AnchorType.Left,
            };

            // init "Image Anchor"
            imageAnchorComboBox.Items.AddRange(aStyles);
            focusPointAnchorComboBox.Items.AddRange(aStyles);

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

        /// <summary>
        /// Shows settings of the image viewer.
        /// </summary>
        private void ShowSettings()
        {
            // image anchor
            imageAnchorComboBox.SelectedItem = _viewer.ImageAnchor;

            // rendering quality
            renderingQualityComboBox.SelectedItem = _viewer.RenderingQuality;

            // focus point
            focusPointAnchorComboBox.SelectedItem = _viewer.FocusPointAnchor;
            focusPointIsFixedCheckBox.Checked = _viewer.IsFocusPointFixed;

            // buffering
            rendererCacheSizeNumericUpDown.Value = (int)Math.Round(_viewer.RendererCacheSize);
            viewerBufferSizeNumericUpDown.Value = (int)Math.Round(_viewer.ViewerBufferSize);
            minImageSizeWhenZoomBufferUsedNumericUpDown.Value = (int)Math.Round(_viewer.MinImageSizeWhenZoomBufferUsed);

            // backgroud color
            backgoundColorPanelControl.Color = _viewer.BackColor;

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
        /// Sets settings to the image viewer.
        /// </summary>
        private void SetSettings()
        {
            // image anchor
            _viewer.ImageAnchor = (AnchorType)imageAnchorComboBox.SelectedItem;

            // rendering quality
            _viewer.RenderingQuality = (ImageRenderingQuality)renderingQualityComboBox.SelectedItem;

            // focus point
            _viewer.FocusPointAnchor = (AnchorType)focusPointAnchorComboBox.SelectedItem;
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
            _viewer.BackColor = backgoundColorPanelControl.Color;

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

        /// <summary>
        /// Shows Rendering Settings Form.
        /// </summary>
        private void renderingSettingsButton_Click(object sender, EventArgs e)
        {
            using (RenderingSettingsForm renderingSettingsDialog = 
                new RenderingSettingsForm(_renderingSettings))
            {
                if (renderingSettingsDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    _renderingSettings = renderingSettingsDialog.RenderingSettings;
            }
        }

        /// <summary>
        /// "Ok" button is clicked.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // set settings to the image viewer
            SetSettings();

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// "Cancel" button is clicked.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Shows a form that allows to view and edit the rendering requirements.
        /// </summary>
        private void renderingRequirementsButton_Click(object sender, EventArgs e)
        {
            if (_renderingRequirements == null)
                _renderingRequirements = new ImageRenderingRequirements(_viewer.RenderingRequirements);
            using (ImageRenderingRequirementsForm renderingRequirements =
                new ImageRenderingRequirementsForm(_renderingRequirements))
            {
                if (renderingRequirements.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    _renderingRequirements = renderingRequirements.RenderingRequirements;
            }
        }

        /// <summary>
        /// Shows a form that allows to view and edit the appearance of not focused image.
        /// </summary>
        private void imageAppearance_Click(object sender, EventArgs e)
        {
            if (_imageAppearance == null)
                _imageAppearance = new ThumbnailAppearance(_viewer.ImageAppearance);
            using (ThumbnailAppearanceSettingsForm imageAppearance = 
                new ThumbnailAppearanceSettingsForm(_imageAppearance, "Not Focused Image Appearance Settings"))
            {
                imageAppearance.ShowDialog();
            }
        }

        /// <summary>
        /// Shows a form that allows to view and edit the appearance of focused image.
        /// </summary>
        private void focusedImageAppearance_Click(object sender, EventArgs e)
        {
            if (_focusedImageAppearance == null)
                _focusedImageAppearance = new ThumbnailAppearance(_viewer.FocusedImageAppearance);
            using (ThumbnailAppearanceSettingsForm focusedImageAppearance =
                new ThumbnailAppearanceSettingsForm(_focusedImageAppearance, "Focused Image Appearance Settings"))
            {
                focusedImageAppearance.ShowDialog();
            }
        }

        /// <summary> 
        /// The keyboard navigation visibility is changed.
        /// </summary>
        private void keyboardNavigationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            keyboardNavigationGroupBox.Enabled = keyboardNavigationCheckBox.Checked;
        }

        #endregion
    }
}
