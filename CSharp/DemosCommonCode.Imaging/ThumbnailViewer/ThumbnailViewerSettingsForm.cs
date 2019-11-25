using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.UI;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to edit the thumbnail viewer settings.
    /// </summary>
    public partial class ThumbnailViewerSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// The thumbnail viewer;
        /// </summary>
        ThumbnailViewer _viewer;

        /// <summary>
        /// The "Normal" appearance of thumbnail.
        /// </summary>
        ThumbnailAppearance _normalThumbnailAppearance;

        /// <summary>
        /// The "Focused" appearance of thumbnail.
        /// </summary>
        ThumbnailAppearance _focusedThumbnailAppearance;

        /// <summary>
        /// The "Hovered" appearance of thumbnail.
        /// </summary>
        ThumbnailAppearance _hoveredThumbnailAppearance;

        /// <summary>
        /// The "Selected" appearance of thumbnail.
        /// </summary>
        ThumbnailAppearance _selectedThumbnailAppearance;

        /// <summary>
        /// The "NotReady" appearance of thumbnail.
        /// </summary>
        ThumbnailAppearance _notReadyThumbnailAppearance;

        #endregion



        #region Constructors

        /// <summary>
        /// Prevents a default instance of
        /// the <see cref="ThumbnailViewerSettingsForm"/> class from being created.
        /// </summary>
        private ThumbnailViewerSettingsForm()
        {
            InitializeComponent();

            thumbnailFlowStyleComboBox.Items.Add(ThumbnailFlowStyle.WrappedRows);
            thumbnailFlowStyleComboBox.Items.Add(ThumbnailFlowStyle.SingleRow);
            thumbnailFlowStyleComboBox.Items.Add(ThumbnailFlowStyle.SingleColumn);
            thumbnailFlowStyleComboBox.Items.Add(ThumbnailFlowStyle.FixedColumns);

            thumbnailScaleComboBox.Items.Add(ThumbnailScale.Smallest);
            thumbnailScaleComboBox.Items.Add(ThumbnailScale.Small);
            thumbnailScaleComboBox.Items.Add(ThumbnailScale.Normal);
            thumbnailScaleComboBox.Items.Add(ThumbnailScale.Large);

            thumbnailAppearanceComboBox.Items.Add("Normal");
            thumbnailAppearanceComboBox.Items.Add("Focused");
            thumbnailAppearanceComboBox.Items.Add("Hovered");
            thumbnailAppearanceComboBox.Items.Add("Selected");
            thumbnailAppearanceComboBox.Items.Add("Not ready");
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ThumbnailViewerSettingsForm"/> class.
        /// </summary>
        /// <param name="viewer">The thumbnail viewer.</param>
        public ThumbnailViewerSettingsForm(ThumbnailViewer viewer)
            : this()
        {
            _viewer = viewer;
            _normalThumbnailAppearance = new ThumbnailAppearance(viewer.ThumbnailAppearance);
            _focusedThumbnailAppearance = new ThumbnailAppearance(viewer.FocusedThumbnailAppearance);
            _hoveredThumbnailAppearance = new ThumbnailAppearance(viewer.HoveredThumbnailAppearance);
            _selectedThumbnailAppearance = new ThumbnailAppearance(viewer.SelectedThumbnailAppearance);
            _notReadyThumbnailAppearance = new ThumbnailAppearance(viewer.NotReadyThumbnailAppearance);
            thumbnailAppearanceComboBox.SelectedIndex = 0;
            ShowSettings();
        }

        #endregion



        #region Methods

        /// <summary>
        /// Shows the settings of thumbnail viewer.
        /// </summary>
        private void ShowSettings()
        {
            generateOnlyVisibleThumbnailsCheckBox.Checked = _viewer.GenerateOnlyVisibleThumbnails;
            thumbnailSizeComboBox.Text = String.Format("{0} x {1}",
                _viewer.ThumbnailSize.Width, _viewer.ThumbnailSize.Height);
            thumbnailFlowStyleComboBox.SelectedItem = _viewer.ThumbnailFlowStyle;
            thumbnailColumnsCountComboBox.SelectedIndex = _viewer.ThumbnailFixedColumnCount - 1;
            thumbnailScaleComboBox.SelectedItem = _viewer.ThumbnailScale;
            thumbnailViewerBackColorPanelControl.Color = _viewer.BackColor;
            thumbnailRenderingThreadCountNumericUpDown.Value = _viewer.ThumbnailRenderingThreadCount;
            imagePaddingEditorControl.PaddingValue = _viewer.ThumbnailImagePadding;

            captionIsVisibleCheckBox.Checked = _viewer.ThumbnailCaption.IsVisible;

            captionPaddingFEditorControl.PaddingValue = _viewer.ThumbnailCaption.Padding;
            captionAnchorTypeEditor.SelectedAnchorType = _viewer.ThumbnailCaption.Anchor;
            captionFormatTextBox.Text = _viewer.ThumbnailCaption.CaptionFormat;
            captionTextColorPanelControl.Color = _viewer.ThumbnailCaption.TextColor;
            captionFontDialog.Font = _viewer.ThumbnailCaption.Font;

        }

        /// <summary>
        /// Saves the settings of thumbnail viewer.
        /// </summary>
        private bool SetSettings()
        {
            _viewer.GenerateOnlyVisibleThumbnails = generateOnlyVisibleThumbnailsCheckBox.Checked;

            // Thumbnail Size
            try
            {
                string[] sizeStrings = thumbnailSizeComboBox.Text.Split('x');
                int width;
                int height;
                if (sizeStrings.Length == 1)
                {
                    width = Convert.ToInt32(sizeStrings[0]);
                    height = width;
                }
                else
                {
                    width = Convert.ToInt32(sizeStrings[0]);
                    height = Convert.ToInt32(sizeStrings[1]);
                }
                _viewer.ThumbnailSize = new Size(width, height);
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e);
                return false;
            }

            if ((ThumbnailFlowStyle)thumbnailFlowStyleComboBox.SelectedItem == ThumbnailFlowStyle.FixedColumns)
                _viewer.ThumbnailFixedColumnCount = (int)thumbnailColumnsCountComboBox.SelectedIndex + 1;
            _viewer.ThumbnailFlowStyle = (ThumbnailFlowStyle)thumbnailFlowStyleComboBox.SelectedItem;
            _viewer.ThumbnailScale = (ThumbnailScale)thumbnailScaleComboBox.SelectedItem;
            _viewer.BackColor = thumbnailViewerBackColorPanelControl.Color;
            _viewer.ThumbnailRenderingThreadCount = (int)thumbnailRenderingThreadCountNumericUpDown.Value;

            _viewer.ThumbnailAppearance = _normalThumbnailAppearance;
            _viewer.FocusedThumbnailAppearance = _focusedThumbnailAppearance;
            _viewer.HoveredThumbnailAppearance = _hoveredThumbnailAppearance;
            _viewer.SelectedThumbnailAppearance = _selectedThumbnailAppearance;
            _viewer.NotReadyThumbnailAppearance = _notReadyThumbnailAppearance;

            _viewer.ThumbnailImagePadding = imagePaddingEditorControl.PaddingValue;

            _viewer.ThumbnailCaption.IsVisible = captionIsVisibleCheckBox.Checked;
            _viewer.ThumbnailCaption.Padding = captionPaddingFEditorControl.PaddingValue;
            _viewer.ThumbnailCaption.TextColor = captionTextColorPanelControl.Color;
            _viewer.ThumbnailCaption.CaptionFormat = captionFormatTextBox.Text;
            _viewer.ThumbnailCaption.Anchor = captionAnchorTypeEditor.SelectedAnchorType;
            _viewer.ThumbnailCaption.Font = captionFontDialog.Font;

            return true;
        }

        /// <summary>
        /// "OK" button is clicked.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (SetSettings())
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
        /// Selected appearance of thumbnail is changed.
        /// </summary>
        private void thumbnailAppearanceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (thumbnailAppearanceComboBox.SelectedIndex)
            {
                case 0:
                    InitAppearance(_normalThumbnailAppearance);
                    break;
                case 1:
                    InitAppearance(_focusedThumbnailAppearance);
                    break;
                case 2:
                    InitAppearance(_hoveredThumbnailAppearance);
                    break;
                case 3:
                    InitAppearance(_selectedThumbnailAppearance);
                    break;
                case 4:
                    InitAppearance(_notReadyThumbnailAppearance);
                    break;
            }
        }

        /// <summary>
        /// Shows settings of the appearance.
        /// </summary>
        /// <param name="thumbnailAppearance">The appearance of thumbnail.</param>
        private void InitAppearance(ThumbnailAppearance thumbnailAppearance)
        {
            thumbnailAppearanceBackColorPanelControl.Color = thumbnailAppearance.BackColor;
            thumbnailAppearanceBorderColorPanelControl.Color = thumbnailAppearance.BorderColor;
            borderWidthValueLabel.Text = thumbnailAppearance.BorderWidth.ToString();
            borderStyleValueLabel.Text = thumbnailAppearance.BorderStyle.ToString();
        }

        /// <summary>
        /// Edits settings of the appearance.
        /// </summary>
        private void editThumbnailAppearanceButton_Click(object sender, EventArgs e)
        {
            ThumbnailAppearance appearance = null;
            switch (thumbnailAppearanceComboBox.SelectedIndex)
            {
                case 0:
                    appearance = _normalThumbnailAppearance;
                    break;
                case 1:
                    appearance = _focusedThumbnailAppearance;
                    break;
                case 2:
                    appearance = _hoveredThumbnailAppearance;
                    break;
                case 3:
                    appearance = _selectedThumbnailAppearance;
                    break;
                case 4:
                    appearance = _notReadyThumbnailAppearance;
                    break;
            }

            ThumbnailAppearanceSettingsForm thumbnailAppearanceSettingsDialog =
                new ThumbnailAppearanceSettingsForm(appearance);

            if (thumbnailAppearanceSettingsDialog.ShowDialog() == DialogResult.OK)
                InitAppearance(appearance);
        }

        /// <summary>
        /// The flow style of thumbnail viewer is changed.
        /// </summary>
        private void thumbnailFlowStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ThumbnailFlowStyle)thumbnailFlowStyleComboBox.SelectedItem == ThumbnailFlowStyle.FixedColumns)
            {
                thumbnailColumnsCountComboBox.Enabled = true;
            }
            else
            {
                thumbnailColumnsCountComboBox.Enabled = false;
            }
        }

        /// <summary>
        /// The thumbnail caption visibility is changed.
        /// </summary>
        private void captionIsVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            thumbnailCaptionGroupBox.Enabled = captionIsVisibleCheckBox.Checked;
        }

        /// <summary>
        /// Shows the dialog for editing the font of the thumbnail caption.
        /// </summary>
        private void captionFontSelectButton_Click(object sender, EventArgs e)
        {
            captionFontDialog.ShowDialog();
        }

        /// <summary>
        /// Shows information about ThumbnailCaption.CaptionFormat property.
        /// </summary>
        private void captionFormatHelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Examples:\n" +
                "'File {Filename}, page {PageNumber}'\n" +
                "'{ImageSizeMpx:f2} MPX'\n" +
                "\n" +
                "List of predefined format variables:\n" +
                "{PageNumber} - page number, in source image file\n" +
                "{PageIndex} - page index, in source image file\n" +
                "{ImageNumber} - image number, in image collection\n" +
                "{ImageIndex} - image index, in image collection\n" +
                "{Filename} - filename without directory\n" +
                "{FullFilename} - full filename\n" +
                "{DirectoryName} - directory name\n" +
                "{DecoderName} - decoder name\n" +
                "{ImageWidthPx} - source image width, in pixels\n" +
                "{ImageHeightPx} - source image height, in pixels\n" +
                "{ImageSizeMpx} - source image size, in megapixels\n" +
                "{ImageHRes} - source image horizontal resolution, in DPI\n" +
                "{ImageVRes} - source image vertical resolution, in DPI\n" +
                "{ImageBitsPerPixel} - source image bits per pixel",
                "ThumbnailCaption.CaptionFormat property");
        }

        #endregion

    }
}
