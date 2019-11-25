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
        int[] _zoomValues = new int[] { 1, 5, 10, 25, 50, 75, 100, 125, 150, 200, 400, 600, 800, 1000, 2000, 4000, 8000, 10000 };

        /// <summary>
        /// Current scale mode menu item.
        /// </summary>
        ToolStripMenuItem _currentScaleModeMenuItem;

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

            _images_CollectionChangedEventThreadSafe = new Images_CollectionChangedThreadSafeDelegate(Images_CollectionChangedSafely);

            _saveButtonEnabled = saveButton.Enabled;
            _scanButtonEnabled = scanButton.Enabled;
            _printButtonEnabled = printButton.Enabled;

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
                if (LicenseManager.CurrentContext.UsageMode == LicenseUsageMode.Designtime)
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
                    _associatedZoomTrackBar.ValueChanged -= new EventHandler(_associatedZoomTrackBar_ValueChanged);
                    _associatedZoomTrackBar.Scroll -= new EventHandler(_associatedZoomTrackBar_Scroll);
                }

                _associatedZoomTrackBar = value;

                if (_associatedZoomTrackBar != null)
                {
                    _associatedZoomTrackBar.ValueChanged += new EventHandler(_associatedZoomTrackBar_ValueChanged);
                    _associatedZoomTrackBar.Scroll += new EventHandler(_associatedZoomTrackBar_Scroll);
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

        bool _scanButtonEnabled;
        /// <summary>
        /// Gets or sets a value indicating whether the toolbar has enabled button
        /// for image acquisition from scanner.
        /// </summary>
        [Browsable(false)]
        public bool IsScanEnabled
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

        #region PRIVATE

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
                firstPageButton.Enabled = isImageLoaded && _isNavigateEnabled && this.SelectedPageIndex > 0;
                previousPageButton.Enabled = isImageLoaded && _isNavigateEnabled && this.SelectedPageIndex > 0;
                nextPageButton.Enabled = isImageLoaded && _isNavigateEnabled && this.SelectedPageIndex < (this.PageCount - 1);
                lastPageButton.Enabled = isImageLoaded && _isNavigateEnabled && this.SelectedPageIndex < (this.PageCount - 1);

                selectedPageIndexTextBox.Enabled = isImageLoaded && _isNavigateEnabled && this.PageCount > 1;
                if (isImageLoaded)
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


        #region Main strip

        private void openButton_Click(object sender, System.EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            button.Enabled = false;
            try
            {
                if (OpenFile != null)
                    OpenFile(sender, e);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            button.Enabled = false;
            try
            {
                if (SaveFile != null)
                    SaveFile(sender, e);
            }
            finally
            {
                button.Enabled = SaveButtonEnabled;
            }
        }

        private void scanButton_Click(object sender, System.EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            button.Enabled = false;
            try
            {
                if (Scan != null)
                    Scan(sender, e);
            }
            finally
            {
                button.Enabled = IsScanEnabled;
            }
        }

        private void captureFromCameraButton_Click(object sender, System.EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            button.Enabled = false;
            try
            {
                if (CaptureFromCamera != null)
                    CaptureFromCamera(sender, e);
            }
            finally
            {
                button.Enabled = true;
            }
        }

        private void printButton_Click(object sender, System.EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            button.Enabled = false;
            try
            {
                if (Print != null)
                    Print(sender, e);
            }
            finally
            {
                button.Enabled = PrintButtonEnabled;
            }
        }



        #endregion


        #region Navigation

        /// <summary>
        /// Moves the focus in image viewer to the first image.
        /// </summary>
        private void firstPageButton_Click(object sender, System.EventArgs e)
        {
            SelectedPageIndex = 0;
        }

        /// <summary>
        /// Moves the focus in image viewer to the previous image.
        /// </summary>
        private void previousPageButton_Click(object sender, System.EventArgs e)
        {
            SelectedPageIndex--;
        }

        /// <summary>
        /// Moves the focus in image viewer to the next image.
        /// </summary>
        private void nextPageButton_Click(object sender, System.EventArgs e)
        {
            SelectedPageIndex++;
        }

        /// <summary>
        /// Moves the focus in image viewer to the last image.
        /// </summary>
        private void lastPageButton_Click(object sender, System.EventArgs e)
        {
            SelectedPageIndex = PageCount - 1;
        }

        /// <summary>
        /// Changes the focus in image viewer from current image to new image according to entered page index value.
        /// </summary>
        /// <remarks>
        /// This method does not change focus if entered page index value is not correct.
        /// </remarks>
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

        private void selectedPageIndexTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) &&
                e.KeyChar != '\b')
                e.Handled = true;
        }

        /// <summary>
        /// Returns focused page index to the selected index text box.
        /// </summary>
        private void selectedPageIndexTextBox_LostFocus(object sender, System.EventArgs e)
        {
            UpdateSelectedPageIndex(_selectedPageIndex);
            UpdateUI();
        }

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

        #endregion


        #region Scale mode

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
        /// Decreases zoom value.
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
        /// Increases zoom value.
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
        /// Changes zoom when new value entered in zoom text box.
        /// </summary>
        private void zoomTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if enter is pressed
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

        private void zoomValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != '\b' &&
                e.KeyChar != '%')
                e.Handled = true;
        }

        /// <summary>
        /// Returns zoom value to the zoom text box. 
        /// </summary>
        private void zoomValueTextBox_LostFocus(object sender, System.EventArgs e)
        {
            UpdateTextBoxZoom();
        }

        /// <summary>
        /// Changes image scale mode of image viewer.
        /// </summary>
        private void ImageScale_Click(object sender, EventArgs e)
        {
            _currentScaleModeMenuItem.Checked = false;
            _currentScaleModeMenuItem = (ToolStripMenuItem)sender;

            if (_currentScaleModeMenuItem == normalToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Normal;
            }
            else if (_currentScaleModeMenuItem == bestFitToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.BestFit;
            }
            else if (_currentScaleModeMenuItem == fitToWidthToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.FitToWidth;
            }
            else if (_currentScaleModeMenuItem == fitToHeightToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.FitToHeight;
            }
            else if (_currentScaleModeMenuItem == scaleToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
            }
            else if (_currentScaleModeMenuItem == scale25ToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
                _imageViewer.Zoom = 25;
            }
            else if (_currentScaleModeMenuItem == scale50ToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
                _imageViewer.Zoom = 50;
            }
            else if (_currentScaleModeMenuItem == scale100ToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
                _imageViewer.Zoom = 100;
            }
            else if (_currentScaleModeMenuItem == scale200ToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
                _imageViewer.Zoom = 200;
            }
            else if (_currentScaleModeMenuItem == scale400ToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.Zoom;
                _imageViewer.Zoom = 400;
            }
            else if (_currentScaleModeMenuItem == pixelToPixelToolStripMenuItem)
            {
                _imageViewer.SizeMode = ImageSizeMode.PixelToPixel;
            }

            _currentScaleModeMenuItem.Checked = true;

            UpdateTextBoxZoom();
        }

        #endregion


        #region Zoom trackbar

        private void _associatedZoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _imageViewer.Zoom = AssociatedZoomTrackBar.Value;
        }

        private void _associatedZoomTrackBar_Scroll(object sender, EventArgs e)
        {
            _imageViewer.SizeMode = ImageSizeMode.Zoom;
            _imageViewer.Zoom = AssociatedZoomTrackBar.Value;
        }

        #endregion


        #region Image viewer

        private void imageViewer_ImagesChanging(object sender, EventArgs e)
        {
            if (UseImageViewerImages)
            {
                if (_imageViewer != null)
                    // unsubscribe from the ImageCollectionChanged event of image collection of the viewer
                    _imageViewer.Images.ImageCollectionChanged -= new EventHandler<ImageCollectionChangeEventArgs>(Images_CollectionChangedSafely);
            }
        }

        private void imageViewer_ImagesChanged(object sender, EventArgs e)
        {
            if (UseImageViewerImages)
                // subscribe to the ImageCollectionChanged event of image collection of the viewer
                _imageViewer.Images.ImageCollectionChanged += new EventHandler<ImageCollectionChangeEventArgs>(Images_CollectionChangedSafely);
        }

        private void imageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            //
            if (UseImageViewerImages && _imageViewer != null)
                //
                SelectedPageIndex = e.FocusedIndex;

            UpdateUI();
        }

        private void UpdateAssociatedZoomTrackBar()
        {
            if (AssociatedZoomTrackBar != null && _imageViewer != null)
            {
                AssociatedZoomTrackBar.Value = Math.Min(_imageViewer.Zoom, AssociatedZoomTrackBar.Maximum);
                toolTip.SetToolTip(AssociatedZoomTrackBar,
                    AssociatedZoomTrackBar.Value.ToString(CultureInfo.InvariantCulture) + "%");
            }
        }

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

        private void imageViewer_ZoomChanged(object sender, ZoomChangedEventArgs e)
        {
            UpdateTextBoxZoom();

            UpdateAssociatedZoomTrackBar();

            UpdateImageViewerSizeMode();
        }

        #endregion


        #region Image collection

        private void Images_CollectionChanged(object sender, ImageCollectionChangeEventArgs e)
        {
            UpdateUI();
        }

        private void Images_CollectionChangedSafely(object sender, ImageCollectionChangeEventArgs e)
        {
            if (UseImageViewerImages)
            {
                if (_imageViewer.InvokeRequired)
                    _imageViewer.Invoke(_images_CollectionChangedEventThreadSafe, new object[] { sender, e });
                else
                    this.Images_CollectionChanged(sender, e);
            }
        }

        #endregion

        #endregion

        #endregion



        #region Events

        [Browsable(true)]
        public event EventHandler OpenFile;

        [Browsable(true)]
        public event EventHandler SaveFile;

        [Browsable(true)]
        public event EventHandler Scan;

        [Browsable(true)]
        public event EventHandler CaptureFromCamera;

        [Browsable(true)]
        public event EventHandler Print;

        [Browsable(true)]
        public event EventHandler<PageIndexChangedEventArgs> PageIndexChanged;

        #endregion



        #region Delegates

        delegate void Images_CollectionChangedThreadSafeDelegate(object sender, ImageCollectionChangeEventArgs e);
        Images_CollectionChangedThreadSafeDelegate _images_CollectionChangedEventThreadSafe;

        #endregion

    }
}
