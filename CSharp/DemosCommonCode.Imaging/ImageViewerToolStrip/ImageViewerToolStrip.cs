using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Toolbar for image viewer.
    /// </summary>
    public partial class ImageViewerToolStrip : ToolStrip
    {

        #region Fields

        /// <summary>
        /// Available zoom values.
        /// </summary>
        int[] _zoomValues = new int[] { 1, 5, 10, 25, 50, 75, 100, 125, 150, 200, 400, 600, 800, 1000, 2000, 4000, 8000, 10000, 20000, 50000, 100000 };

        /// <summary>
        /// Current scale mode menu item.
        /// </summary>
        ToolStripMenuItem _currentScaleModeMenuItem;

        /// <summary>
        /// Indicates when AssociatedZoomTrackBar value is sets.
        /// </summary>
        bool _setAssociatedZoomTrackBarValue = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageViewerToolStrip"/> class.
        /// </summary>
        public ImageViewerToolStrip()
            : base()
        {
            InitializeComponent();

            CanNavigate = true;

            _currentScaleModeMenuItem = normalToolStripMenuItem;
            normalToolStripMenuItem.Checked = true;

            _openButtonEnabled = openButton.Enabled;
            _saveButtonEnabled = saveButton.Enabled;
            _scanButtonEnabled = scanButton.Enabled;
            _printButtonEnabled = printButton.Enabled;
            _captureFromCameraButtonEnabled = captureFromCameraButton.Enabled;

            selectedPageIndexTextBox.KeyPress += new KeyPressEventHandler(selectedPageIndexTextBox_KeyPress);
            zoomValueTextBox.KeyPress += new KeyPressEventHandler(zoomValueTextBox_KeyPress);

            UpdateSeparatorsVisibility();
        }

        #endregion



        #region Properties

        ImageViewer _imageViewer = null;
        /// <summary>
        /// Gets or sets an image viewer associated with this toolstrip.
        /// </summary>
        [Browsable(true)]
        public ImageViewer ImageViewer
        {
            get
            {
                return _imageViewer;
            }
            set
            {
                if (DesignMode || ImagingEnvironment.IsInDesignMode)
                {
                    _imageViewer = value;
                }
                else
                {
                    if (_imageViewer != null)
                    {
                        // unsubscribe from the ImagesChanging/ImagesChanged events of the viewer
                        _imageViewer.ImagesChanging -= new EventHandler(imageViewer_ImagesChanging);
                        _imageViewer.ImagesChanged -= new EventHandler(imageViewer_ImagesChanged);
                        // unsubscribe from the ImageCollectionChanged event of image collection of the viewer
                        _imageViewer.Images.ImageCollectionChanged -= new EventHandler<ImageCollectionChangeEventArgs>(Images_CollectionChangedSafely);
                        // unsubscribe from the FocusedIndexChanged event of the viewer
                        _imageViewer.FocusedIndexChanged -= new EventHandler<FocusedIndexChangedEventArgs>(imageViewer_FocusedIndexChanged);
                        // unsubscribe from the ZoomChanged event of the viewer
                        _imageViewer.ZoomChanged -= new EventHandler<ZoomChangedEventArgs>(imageViewer_ZoomChanged);
                    }

                    _imageViewer = value;

                    if (_imageViewer != null)
                    {
                        // subscribe to the ImagesChanging/ImagesChanged events of the viewer
                        _imageViewer.ImagesChanging += new EventHandler(imageViewer_ImagesChanging);
                        _imageViewer.ImagesChanged += new EventHandler(imageViewer_ImagesChanged);
                        // subscribe to the ImageCollectionChanged event of image collection of the viewer
                        _imageViewer.Images.ImageCollectionChanged += new EventHandler<ImageCollectionChangeEventArgs>(Images_CollectionChangedSafely);
                        // subscribe to the FocusedIndexChanged event of the viewer
                        _imageViewer.FocusedIndexChanged += new EventHandler<FocusedIndexChangedEventArgs>(imageViewer_FocusedIndexChanged);
                        // subscribe to the ZoomChanged event of the viewer
                        _imageViewer.ZoomChanged += new EventHandler<ZoomChangedEventArgs>(imageViewer_ZoomChanged);

                        if (UseImageViewerImages)
                            pageCountLabel.Text = PageCount.ToString(CultureInfo.InvariantCulture);
                    }

                    if (_imageViewer != null)
                        imageViewer_FocusedIndexChanged(this, new FocusedIndexChangedEventArgs(_imageViewer.FocusedIndex));


                    UpdateTextBoxZoom();

                    UpdateAssociatedZoomTrackBar();

                    UpdateImageViewerSizeMode();
                }
            }
        }


        bool _useImageViewerImages = true;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar synchronizes with image collection of image viewer.
        /// </summary>
        [Browsable(false)]
        public bool UseImageViewerImages
        {
            get
            {
                return _useImageViewerImages;
            }
            set
            {
                _useImageViewerImages = value;
            }
        }

        TrackBar _associatedZoomTrackBar;
        /// <summary>
        /// Gets or sets a zoom trackbar associated with this toolbar.
        /// </summary>
        [Browsable(true)]
        public TrackBar AssociatedZoomTrackBar
        {
            get
            {
                return _associatedZoomTrackBar;
            }
            set
            {
                if (_associatedZoomTrackBar != null)
                {
                    _associatedZoomTrackBar.ValueChanged -= new EventHandler(associatedZoomTrackBar_ValueChanged);
                    _associatedZoomTrackBar.Scroll -= new EventHandler(associatedZoomTrackBar_Scroll);
                }

                _associatedZoomTrackBar = value;

                if (_associatedZoomTrackBar != null)
                {
                    _associatedZoomTrackBar.ValueChanged += new EventHandler(associatedZoomTrackBar_ValueChanged);
                    _associatedZoomTrackBar.Scroll += new EventHandler(associatedZoomTrackBar_Scroll);
                }
            }
        }

        bool _canOpenFile = true;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar has button for loading of image from file.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        public bool CanOpenFile
        {
            get
            {
                return _canOpenFile;
            }
            set
            {
                _canOpenFile = value;
                openButton.Visible = value;

                UpdateSeparatorsVisibility();
            }
        }

        bool _openButtonEnabled;
        /// <summary>
        /// Gets or sets a value indicating whether the button for loading of image from is enabled.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        public bool OpenButtonEnabled
        {
            get
            {
                return _openButtonEnabled;
            }
            set
            {
                _openButtonEnabled = value;
                openButton.Enabled = value;
            }
        }

        bool _canSaveFile = true;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar has button for saving of image to a file.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        public bool CanSaveFile
        {
            get
            {
                return _canSaveFile;
            }
            set
            {
                _canSaveFile = value;

                saveButton.Visible = value;

                UpdateSeparatorsVisibility();
            }
        }

        bool _saveButtonEnabled;
        /// <summary>
        /// Gets or sets a value indicating whether the button for saving of image is enabled.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        public bool SaveButtonEnabled
        {
            get
            {
                return _saveButtonEnabled;
            }
            set
            {
                _saveButtonEnabled = value;
                saveButton.Enabled = value;
            }
        }

        bool _canScan = false;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar has button for acquiring of image from scanner.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        public bool CanScan
        {
            get
            {
                return _canScan;
            }
            set
            {
                _canScan = value;

                scanButton.Visible = value;

                UpdateSeparatorsVisibility();
            }
        }

        bool _scanButtonEnabled;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar has enabled button
        /// for image acquisition from scanner.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        public bool ScanButtonEnabled
        {
            get
            {
                return _scanButtonEnabled;
            }
            set
            {
                _scanButtonEnabled = value;

                scanButton.Enabled = value;
            }
        }

        bool _canCaptureFromCamera = false;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar has button for capturing of image
        /// from camera.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        public bool CanCaptureFromCamera
        {
            get
            {
                return _canCaptureFromCamera;
            }
            set
            {
                _canCaptureFromCamera = value;

                captureFromCameraButton.Visible = value;

                UpdateSeparatorsVisibility();
            }
        }

        bool _captureFromCameraButtonEnabled;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar has enabled button
        /// for image acquisition from scanner.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        public bool CaptureFromCameraButtonEnabled
        {
            get
            {
                return _captureFromCameraButtonEnabled;
            }
            set
            {
                _captureFromCameraButtonEnabled = value;

                captureFromCameraButton.Enabled = value;
            }
        }

        bool _canPrint = true;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar has button for printing of image.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        public bool CanPrint
        {
            get
            {
                return _canPrint;
            }
            set
            {
                _canPrint = value;

                printButton.Visible = value;

                UpdateSeparatorsVisibility();
            }
        }

        bool _printButtonEnabled;
        /// <summary>
        /// Gets or sets a value indicating whether the button for printing of image is enabled.
        /// </summary>
        public bool PrintButtonEnabled
        {
            get
            {
                return _printButtonEnabled;
            }
            set
            {
                _printButtonEnabled = value;
                printButton.Enabled = value;
            }
        }

        bool _canNavigate = true;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar has button for image navigation.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        public bool CanNavigate
        {
            get
            {
                return _canNavigate;
            }
            set
            {
                _canNavigate = value;

                firstPageButton.Visible = value;
                previousPageButton.Visible = value;
                selectedPageIndexTextBox.Visible = value;
                slashLabel.Visible = value;
                pageCountLabel.Visible = value;
                nextPageButton.Visible = value;
                lastPageButton.Visible = value;

                UpdateSeparatorsVisibility();
            }
        }

        bool _isNavigateEnabled = true;
        /// <summary>
        /// Gets or sets a value indicating whether image navigation buttons are
        /// enabled in the toolbar.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(true)]
        public bool IsNavigateEnabled
        {
            get
            {
                return _isNavigateEnabled;
            }
            set
            {
                firstPageButton.Enabled = value;
                previousPageButton.Enabled = value;
                selectedPageIndexTextBox.Enabled = value;
                slashLabel.Enabled = value;
                pageCountLabel.Enabled = value;
                nextPageButton.Enabled = value;
                lastPageButton.Enabled = value;
                navigationSeparator.Enabled = value;

                _isNavigateEnabled = value;
            }
        }

        bool _canChangeZoom = true;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar has buttons for changing of image zoom in viewer.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        public bool CanChangeZoom
        {
            get
            {
                return _canChangeZoom;
            }
            set
            {
                _canChangeZoom = value;

                zoomOutButton.Visible = value;
                zoomValueTextBox.Visible = value;
                zoomModesButton.Visible = value;
                zoomInButton.Visible = value;

                UpdateSeparatorsVisibility();
            }
        }

        bool _canChangeSizeMode = true;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar has buttons for image size mode changing.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        public bool CanChangeSizeMode
        {
            get
            {
                return _canChangeSizeMode;
            }
            set
            {
                _canChangeSizeMode = value;

                normalToolStripMenuItem.Visible = value;
                bestFitToolStripMenuItem.Visible = value;
                fitToHeightToolStripMenuItem.Visible = value;
                fitToWidthToolStripMenuItem.Visible = value;
                pixelToPixelToolStripMenuItem.Visible = value;
                scaleToolStripMenuItem.Visible = value;
                zoomModesSeparator.Visible = value;

                UpdateSeparatorsVisibility();
            }
        }

        bool _isChangeSizeModeEnabled = true;
        /// <summary>
        /// Gets or sets a value indicating whether image size mode changing buttons are
        /// enabled in the toolbar.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(true)]
        public bool IsChangeSizeModeEnabled
        {
            get
            {
                return _isChangeSizeModeEnabled;
            }
            set
            {
                normalToolStripMenuItem.Enabled = value;
                bestFitToolStripMenuItem.Enabled = value;
                fitToHeightToolStripMenuItem.Enabled = value;
                fitToWidthToolStripMenuItem.Enabled = value;
                pixelToPixelToolStripMenuItem.Enabled = value;
                scaleToolStripMenuItem.Enabled = value;

                _isChangeSizeModeEnabled = value;
            }
        }

        int _pageCount;
        /// <summary>
        /// Gets or sets the image count.
        /// </summary>
        [Browsable(false)]
        public int PageCount
        {
            get
            {
                if (UseImageViewerImages)
                {
                    if (_imageViewer != null)
                        return _imageViewer.Images.Count;
                    else
                        return 0;
                }
                else
                    return _pageCount;
            }
            set
            {
                if (!UseImageViewerImages)
                {
                    if (value >= 0)
                    {
                        if (value == 0)
                            _selectedPageIndex = -1;
                        _pageCount = value;
                        pageCountLabel.Text = PageCount.ToString(CultureInfo.InvariantCulture);
                        UpdateUI();
                    }
                }
            }
        }

        int _selectedPageIndex = -1;
        /// <summary>
        /// Gets or sets an index of selected image.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(-1)]
        public int SelectedPageIndex
        {
            get
            {
                return _selectedPageIndex;
            }
            set
            {
                if (_selectedPageIndex == value && (_imageViewer == null || _imageViewer.Images.Count > 0))
                    return;

                UpdateSelectedPageIndex(value);

                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region UI

        #region Main strip

        /// <summary>
        /// Handles the Click event of openButton object.
        /// </summary>
        private void openButton_Click(object sender, EventArgs e)
        {
            // raise open file event
            if (OpenFile != null)
            {
                ((ToolStripButton)sender).Enabled = false;
                try
                {
                    OpenFile(sender, e);
                }
                finally
                {
                    ((ToolStripButton)sender).Enabled = true;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of saveButton object.
        /// </summary>
        private void saveButton_Click(object sender, System.EventArgs e)
        {
            // raise save file event
            if (SaveFile != null)
            {
                ((ToolStripButton)sender).Enabled = false;
                try
                {
                    SaveFile(sender, e);
                }
                finally
                {
                    ((ToolStripButton)sender).Enabled = true;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of scanButton object.
        /// </summary>
        private void scanButton_Click(object sender, System.EventArgs e)
        {
            // raise scan image event
            if (Scan != null)
            {
                ((ToolStripButton)sender).Enabled = false;
                try
                {
                    Scan(sender, e);
                }
                finally
                {
                    ((ToolStripButton)sender).Enabled = true;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of captureFromCameraButton object.
        /// </summary>
        private void captureFromCameraButton_Click(object sender, System.EventArgs e)
        {
            // raise capture from camera event
            if (CaptureFromCamera != null)
            {
                ((ToolStripButton)sender).Enabled = false;
                try
                {
                    CaptureFromCamera(sender, e);
                }
                finally
                {
                    ((ToolStripButton)sender).Enabled = true;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of printButton object.
        /// </summary>
        private void printButton_Click(object sender, System.EventArgs e)
        {
            // raise print event
            if (Print != null)
            {
                ((ToolStripButton)sender).Enabled = false;
                try
                {
                    Print(sender, e);
                }
                finally
                {
                    ((ToolStripButton)sender).Enabled = true;
                }
            }
        }

        #endregion


        #region Navigation

        /// <summary>
        /// Handles the Click event of firstPageButton object.
        /// </summary>
        private void firstPageButton_Click(object sender, System.EventArgs e)
        {
            // move the focus in image viewer to the first image
            SelectedPageIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of previousPageButton object.
        /// </summary>
        private void previousPageButton_Click(object sender, System.EventArgs e)
        {
            // move the focus in image viewer to the previous image
            SelectedPageIndex--;
        }

        /// <summary>
        /// Handles the Click event of nextPageButton object.
        /// </summary>
        private void nextPageButton_Click(object sender, System.EventArgs e)
        {
            // move the focus in image viewer to the next image
            SelectedPageIndex++;
        }

        /// <summary>
        /// Handles the Click event of lastPageButton object.
        /// </summary>
        private void lastPageButton_Click(object sender, System.EventArgs e)
        {
            // move the focus in image viewer to the last image
            SelectedPageIndex = PageCount - 1;
        }

        /// <summary>
        /// Handles the KeyPress event of textBoxPages object.
        /// </summary>
        private void textBoxPages_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if enter is pressed
            if (e.KeyChar == '\xD')
            {
                int value;
                // if entered index is not correct
                if (int.TryParse(((ToolStripTextBox)sender).Text, out value) && value > 0 && value <= PageCount)
                {
                    // set last page index
                    SelectedPageIndex = value - 1;
                }
                // if entered index is correct
                else
                {
                    // update selected page index
                    UpdateSelectedPageIndex(_selectedPageIndex);

                    // update user interface
                    UpdateUI();
                }
            }
        }

        /// <summary>
        /// Handles the KeyPress event of selectedPageIndexTextBox object.
        /// </summary>
        private void selectedPageIndexTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if current symbol is not number
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        /// <summary>
        /// Handles the LostFocus event of selectedPageIndexTextBox object.
        /// </summary>
        private void selectedPageIndexTextBox_LostFocus(object sender, System.EventArgs e)
        {
            // update selected page index
            UpdateSelectedPageIndex(_selectedPageIndex);
            // update user interface
            UpdateUI();
        }

        #endregion


        #region Scale mode

        /// <summary>
        /// Handles the Click event of zoomOutButton object.
        /// </summary>
        private void zoomOutButton_Click(object sender, System.EventArgs e)
        {
            // if zoom value in image viewer greater than minimum zoom value
            if (_imageViewer.Zoom > _zoomValues[0])
            {
                _currentScaleModeMenuItem.Checked = false;
                // set zoom size mode to the image viewer
                _imageViewer.SizeMode = ImageSizeMode.Zoom;

                int index = 0;
                // search current zoom value in array of available zoom values
                while (index < _zoomValues.Length && _zoomValues[index] < _imageViewer.Zoom)
                {
                    index++;
                }
                // set zoom value
                _imageViewer.Zoom = _zoomValues[index - 1];

                // update value in zoom text box
                UpdateTextBoxZoom();
            }
        }

        /// <summary>
        /// Handles the Click event of zoomInButton object.
        /// </summary>
        private void zoomInButton_Click(object sender, System.EventArgs e)
        {
            // if zoom value in image viewer less than maximum zoom value
            if (_imageViewer.Zoom < _zoomValues[_zoomValues.Length - 1])
            {
                _currentScaleModeMenuItem.Checked = false;
                // set zoom size mode to the image viewer
                _imageViewer.SizeMode = ImageSizeMode.Zoom;

                int index = 0;
                // search current zoom value in array of available zoom values
                while (_zoomValues[index] <= _imageViewer.Zoom)
                {
                    index++;
                }
                // set zoom value
                _imageViewer.Zoom = _zoomValues[index];

                // update value in zoom text box
                UpdateTextBoxZoom();
            }
        }

        /// <summary>
        /// Handles the KeyPress event of zoomTextBox object.
        /// </summary>
        private void zoomTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if Enter key is pressed
            if (e.KeyChar == '\xD')
            {
                // get zoom value
                string sourceText = ((ToolStripTextBox)sender).Text.Replace("%", "");

                _currentScaleModeMenuItem.Checked = false;
                // set zoom size mode to the image viewer
                _imageViewer.SizeMode = ImageSizeMode.Zoom;

                int value;
                if (int.TryParse(sourceText, out value) && value > 0)
                {
                    // set zoom value
                    _imageViewer.Zoom = value;
                }

                // update value in zoom text box
                UpdateTextBoxZoom();
            }
        }

        /// <summary>
        /// Handles the KeyPress event of zoomValueTextBox object.
        /// </summary>
        private void zoomValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if current symbol is not number or percentage symbol
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '%')
                e.Handled = true;
        }

        /// <summary>
        /// Handles the LostFocus event of zoomValueTextBox object.
        /// </summary>
        private void zoomValueTextBox_LostFocus(object sender, System.EventArgs e)
        {
            // update zoom text box
            UpdateTextBoxZoom();
        }

        /// <summary>
        /// Handles the Click event of ImageScale object.
        /// </summary>
        private void ImageScale_Click(object sender, EventArgs e)
        {
            _currentScaleModeMenuItem.Checked = false;
            _currentScaleModeMenuItem = (ToolStripMenuItem)sender;

            // if "Normal" image size mode must be used in viewer
            if (_currentScaleModeMenuItem == normalToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Normal;
            }
            // if "BestFit" image size mode must be used in viewer
            else if (_currentScaleModeMenuItem == bestFitToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.BestFit;
            }
            // if "FitToWidth" image size mode must be used in viewer
            else if (_currentScaleModeMenuItem == fitToWidthToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.FitToWidth;
            }
            // if "FitToHeight" image size mode must be used in viewer
            else if (_currentScaleModeMenuItem == fitToHeightToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.FitToHeight;
            }
            // if "Zoom" image size mode must be used in viewer
            else if (_currentScaleModeMenuItem == scaleToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
            }
            // if the viewer zoom must be set to 25%
            else if (_currentScaleModeMenuItem == scale25ToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
                _imageViewer.Zoom = 25;
            }
            // if the viewer zoom must be set to 50%
            else if (_currentScaleModeMenuItem == scale50ToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
                _imageViewer.Zoom = 50;
            }
            // if the viewer zoom must be set to 100%
            else if (_currentScaleModeMenuItem == scale100ToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
                _imageViewer.Zoom = 100;
            }
            // if the viewer zoom must be set to 200%
            else if (_currentScaleModeMenuItem == scale200ToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
                _imageViewer.Zoom = 200;
            }
            // if the viewer zoom must be set to 400%
            else if (_currentScaleModeMenuItem == scale400ToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
                _imageViewer.Zoom = 400;
            }
            // if "PixelToPixel" image size mode must be used in viewer
            else if (_currentScaleModeMenuItem == pixelToPixelToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.PixelToPixel;
            }

            _currentScaleModeMenuItem.Checked = true;

            UpdateTextBoxZoom();
        }

        #endregion


        #region Zoom trackbar

        /// <summary>
        /// Handles the ValueChanged event of associatedZoomTrackBar object.
        /// </summary>
        private void associatedZoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (_setAssociatedZoomTrackBarValue)
                return;
            // update image viewer zoom
            _imageViewer.SizeMode = ImageSizeMode.Zoom;
            _imageViewer.Zoom = AssociatedZoomTrackBar.Value;
        }

        /// <summary>
        /// Handles the Scroll event of associatedZoomTrackBar object.
        /// </summary>
        private void associatedZoomTrackBar_Scroll(object sender, EventArgs e)
        {
            // update image viewer zoom
            _imageViewer.SizeMode = ImageSizeMode.Zoom;
            _imageViewer.Zoom = AssociatedZoomTrackBar.Value;
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Handles the ImagesChanging event of imageViewer object.
        /// </summary>
        private void imageViewer_ImagesChanging(object sender, EventArgs e)
        {
            if (UseImageViewerImages)
            {
                if (_imageViewer != null)
                    // unsubscribe from the ImageCollectionChanged event of image collection of the viewer
                    _imageViewer.Images.ImageCollectionChanged -= new EventHandler<ImageCollectionChangeEventArgs>(Images_CollectionChangedSafely);
            }
        }

        /// <summary>
        /// Handles the ImagesChanged event of imageViewer object.
        /// </summary>
        private void imageViewer_ImagesChanged(object sender, EventArgs e)
        {
            if (UseImageViewerImages)
                // subscribe to the ImageCollectionChanged event of image collection of the viewer
                _imageViewer.Images.ImageCollectionChanged += new EventHandler<ImageCollectionChangeEventArgs>(Images_CollectionChangedSafely);
        }

        /// <summary>
        /// Handles the FocusedIndexChanged event of imageViewer object.
        /// </summary>
        private void imageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            // if selected page index must be updated
            if (UseImageViewerImages && _imageViewer != null)
                // update selected page index
                SelectedPageIndex = e.FocusedIndex;

            UpdateUI();
        }

        /// <summary>
        /// Handles the ZoomChanged event of imageViewer object.
        /// </summary>
        private void imageViewer_ZoomChanged(object sender, ZoomChangedEventArgs e)
        {
            // update zoom text box
            UpdateTextBoxZoom();
            // update zoom track bar
            UpdateAssociatedZoomTrackBar();
            // update image viewer size mode
            UpdateImageViewerSizeMode();
        }

        #endregion

        #endregion


        #region Update UI

        /// <summary>
        /// Updates the user interface of this tool strip.
        /// </summary>
        private void UpdateUI()
        {
            if (_imageViewer == null)
                return;

            bool isImageLoaded = _imageViewer.Image != null;

            // navigation buttons
            if (_canNavigate)
            {
                bool hasPages = PageCount > 0;
                firstPageButton.Enabled = hasPages && _isNavigateEnabled && this.SelectedPageIndex > 0;
                previousPageButton.Enabled = hasPages && _isNavigateEnabled && this.SelectedPageIndex > 0;
                nextPageButton.Enabled = hasPages && _isNavigateEnabled && this.SelectedPageIndex < (this.PageCount - 1);
                lastPageButton.Enabled = hasPages && _isNavigateEnabled && this.SelectedPageIndex < (this.PageCount - 1);

                selectedPageIndexTextBox.Enabled = isImageLoaded && _isNavigateEnabled && this.PageCount > 1;
                if (hasPages)
                    selectedPageIndexTextBox.Text = String.Format("{0}", _selectedPageIndex + 1);
                else
                    selectedPageIndexTextBox.Text = "";
            }

            // zoom buttons
            zoomInButton.Enabled = isImageLoaded;
            zoomOutButton.Enabled = isImageLoaded;
            zoomValueTextBox.Enabled = isImageLoaded;
            zoomModesButton.Enabled = isImageLoaded;

            if (zoomValueTextBox.Enabled)
                UpdateTextBoxZoom();

            //
            if (UseImageViewerImages)
                pageCountLabel.Text = PageCount.ToString();
        }

        /// <summary>
        /// Updates the separators visibility.
        /// </summary>
        private void UpdateSeparatorsVisibility()
        {
            ToolStripSeparator lastVisibleSeparator = null;

            if (CanOpenFile || CanSaveFile)
            {
                openSaveSeparator.Visible = true;
                lastVisibleSeparator = openSaveSeparator;
            }
            else
            {
                openSaveSeparator.Visible = false;
            }


            if (CanScan || CanCaptureFromCamera)
            {
                scanCaptureSeparator.Visible = true;
                lastVisibleSeparator = scanCaptureSeparator;
            }
            else
            {
                scanCaptureSeparator.Visible = false;
            }


            if (CanPrint)
            {
                printSeparator.Visible = true;
                lastVisibleSeparator = printSeparator;
            }
            else
            {
                printSeparator.Visible = false;
            }


            if (CanNavigate)
            {
                navigationSeparator.Visible = true;
                lastVisibleSeparator = navigationSeparator;
            }
            else
            {
                navigationSeparator.Visible = false;
            }
        }

        #endregion
   

        /// <summary>
        /// Updates the selected page index.
        /// </summary>
        /// <param name="index">The selected page index.</param>
        private void UpdateSelectedPageIndex(int index)
        {
            if (index > PageCount - 1)
                index = PageCount - 1;

            if (index < -1)
                index = -1;

            _selectedPageIndex = index;

            if (PageIndexChanged != null)
                PageIndexChanged(this, new PageIndexChangedEventArgs(index));

            if (this.UseImageViewerImages && _imageViewer.FocusedIndex != index)
                _imageViewer.FocusedIndex = index;
        }

        /// <summary>
        /// Updates zoom value in zoom text box.
        /// </summary>
        private void UpdateTextBoxZoom()
        {
            if (_imageViewer == null)
            {
                zoomValueTextBox.Text = string.Empty;
            }
            else
            {
                zoomValueTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0}%", _imageViewer.Zoom);
            }
        }

        /// <summary>
        /// Updates the <see cref="AssociatedZoomTrackBar"/> value.
        /// </summary>
        private void UpdateAssociatedZoomTrackBar()
        {
            if (AssociatedZoomTrackBar != null && _imageViewer != null)
            {
                _setAssociatedZoomTrackBarValue = true;
                AssociatedZoomTrackBar.Value = Math.Min(_imageViewer.Zoom, AssociatedZoomTrackBar.Maximum);
                toolTip.SetToolTip(AssociatedZoomTrackBar,
                    AssociatedZoomTrackBar.Value.ToString(CultureInfo.InvariantCulture) + "%");
                _setAssociatedZoomTrackBarValue = false;
            }
        }

        /// <summary>
        /// Updates the image viewer size mode.
        /// </summary>
        private void UpdateImageViewerSizeMode()
        {
            if (_imageViewer == null)
                return;

            _currentScaleModeMenuItem.Checked = false;
            switch (_imageViewer.SizeMode)
            {
                case ImageSizeMode.BestFit:
                    _currentScaleModeMenuItem = bestFitToolStripMenuItem;
                    break;
                case ImageSizeMode.FitToHeight:
                    _currentScaleModeMenuItem = fitToHeightToolStripMenuItem;
                    break;
                case ImageSizeMode.FitToWidth:
                    _currentScaleModeMenuItem = fitToWidthToolStripMenuItem;
                    break;
                case ImageSizeMode.Normal:
                    _currentScaleModeMenuItem = normalToolStripMenuItem;
                    break;
                case ImageSizeMode.PixelToPixel:
                    _currentScaleModeMenuItem = pixelToPixelToolStripMenuItem;
                    break;
                case ImageSizeMode.Zoom:
                    _currentScaleModeMenuItem = scaleToolStripMenuItem;
                    break;
            }

            _currentScaleModeMenuItem.Checked = true;
        }

        /// <summary>
        /// Updates the user interface.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageCollectionChangeEventArgs"/> instance containing the event data.</param>
        private void Images_CollectionChangedSafely(object sender, ImageCollectionChangeEventArgs e)
        {
            if (UseImageViewerImages)
            {
                if (_imageViewer.InvokeRequired)
                    _imageViewer.Invoke(new Images_CollectionChangedSafelyDelegate(Images_CollectionChangedSafely), new object[] { sender, e });
                else
                    UpdateUI();
            }
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when file must be opened.
        /// </summary>
        [Browsable(true)]
        public event EventHandler OpenFile;

        /// <summary>
        /// Occurs when file must be saved.
        /// </summary>
        [Browsable(true)]
        public event EventHandler SaveFile;

        /// <summary>
        /// Occurs when image must be scanned.
        /// </summary>
        [Browsable(true)]
        public event EventHandler Scan;

        /// <summary>
        /// Occurs when image must be captured from camera.
        /// </summary>
        [Browsable(true)]
        public event EventHandler CaptureFromCamera;

        /// <summary>
        /// Occurs when image must be printed.
        /// </summary>
        [Browsable(true)]
        public event EventHandler Print;

        /// <summary>
        /// Occurs when page index is changed.
        /// </summary>
        [Browsable(true)]
        public event EventHandler<PageIndexChangedEventArgs> PageIndexChanged;

        #endregion



        #region Delegates

        /// <summary>
        /// The delegate for <see cref="Images_CollectionChangedSafely(object, ImageCollectionChangeEventArgs)"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ImageCollectionChangeEventArgs"/> instance containing the event data.</param>
        delegate void Images_CollectionChangedSafelyDelegate(object sender, ImageCollectionChangeEventArgs e);

        #endregion

    }
}
