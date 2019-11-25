using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

using Vintasoft.Data;
using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.Print;
#if !REMOVE_PDF_PLUGIN
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
#endif
using Vintasoft.Imaging.Spelling;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UIActions;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Undo;
using Vintasoft.Imaging.Utils;

using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.Formatters;
#if REMOVE_PDF_PLUGIN
using Vintasoft.Imaging.Annotation.Print;
#else
using Vintasoft.Imaging.Annotation.Pdf;
using Vintasoft.Imaging.Annotation.Pdf.Print;
#endif
using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Annotation.UI.Undo;
using Vintasoft.Imaging.Annotation.UI.VisualTools;
using Vintasoft.Imaging.Annotation.UI.VisualTools.UserInteraction;

using DemosCommonCode;
using DemosCommonCode.Annotation;
using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Imaging.Codecs.Dialogs;
using DemosCommonCode.Imaging.ColorManagement;
using DemosCommonCode.Spelling;
#if !REMOVE_PDF_PLUGIN
using DemosCommonCode.Pdf;
#endif

namespace AnnotationDemo
{
    /// <summary>
    /// Main form of Annotation Demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Constants

        /// <summary>
        /// The value, in screen pixels, that defines how annotation position will be changed when user pressed arrow key.
        /// </summary>
        const int ANNOTATION_KEYBOARD_MOVE_DELTA = 2;

        /// <summary>
        /// The value, in screen pixels, that defines how annotation size will be changed when user pressed "+/-" key.
        /// </summary>
        const int ANNOTATION_KEYBOARD_RESIZE_DELTA = 4;

        #endregion



        #region Fields

        /// <summary>
        /// Template of application title.
        /// </summary>
        string _titlePrefix = "VintaSoft Annotation Demo v" + ImagingGlobalSettings.ProductVersion + " - {0}";

        /// <summary>
        /// Selected "View - Image scale mode" menu item.
        /// </summary>
        ToolStripMenuItem _imageScaleModeSelectedMenuItem;

        /// <summary>
        /// Name of the first image file in image collection of image viewer.
        /// </summary>
        string _sourceFilename;
        /// <summary>
        /// Determines that file is opened in read-only mode.
        /// </summary>
        bool _isFileReadOnlyMode = false;

        /// <summary>
        /// Start time of image loading.
        /// </summary>
        DateTime _imageLoadingStartTime;
        /// <summary>
        /// Time of image loading.
        /// </summary>
        TimeSpan _imageLoadingTime = TimeSpan.Zero;

        /// <summary>
        /// Filename where image collection must be saved.
        /// </summary>
        string _saveFilename;

        /// <summary>
        /// Annotated image print document.
        /// </summary>
        ImagePrintDocument _annotatedImagePrintDocument;
        /// <summary>
        /// Print manager.
        /// </summary>
        ImageViewerPrintManager _thumbnailViewerPrintManager;

        /// <summary>
        /// Annotation visual tool.
        /// </summary>
        VisualTool _annotationVisualTool;

        /// <summary>
        /// List of initialized annotations.
        /// </summary>
        List<AnnotationData> _initializedAnnotations = new List<AnnotationData>();

        /// <summary>
        /// Last focused annotation.
        /// </summary>
        AnnotationData _focusedAnnotationData = null;

        /// <summary>
        /// Determines that transforming of annotation is started.
        /// </summary>
        bool _isAnnotationTransforming = false;

        /// <summary>
        /// Logger of annotation's changes.
        /// </summary>
        AnnotationsLogger _annotationLogger;

        /// <summary>
        /// Dictionary: the tool strip menu item => the annotation type.
        /// </summary>
        Dictionary<ToolStripMenuItem, AnnotationType> _toolStripMenuItemToAnnotationType =
            new Dictionary<ToolStripMenuItem, AnnotationType>();

        /// <summary>
        /// Manager of interaction areas.
        /// </summary>
        AnnotationInteractionAreaAppearanceManager _interactionAreaAppearanceManager;

        /// <summary>
        /// Handler of changes of annotation's IRuler.UnitOfMeasure property.
        /// </summary>
        RulerAnnotationPropertyChangedEventHandler _rulerAnnotationPropertyChangedEventHandler;

        /// <summary>
        /// Form with annotation history.
        /// </summary>
        UndoManagerHistoryForm _historyForm;

        /// <summary>
        /// The data storage of undo monitor.
        /// </summary>
        IDataStorage _dataStorage;

        /// <summary>
        /// The undo manager.
        /// </summary>
        CompositeUndoManager _undoManager;

        /// <summary>
        /// The undo monitor of annotation viewer.
        /// </summary>
        CustomAnnotationViewerUndoMonitor _annotationViewerUndoMonitor;

        /// <summary>
        /// Determines that form of application is closing.
        /// </summary>
        bool _isFormClosing = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            Jbig2AssemblyLoader.Load();
            Jpeg2000AssemblyLoader.Load();
            DicomAssemblyLoader.Load();
            PdfAnnotationsAssemblyLoader.Load();

            InitializeAddAnnotationMenuItems();

            // init "View => Image Display Mode" menu
            singlePageToolStripMenuItem.Tag = ImageViewerDisplayMode.SinglePage;
            twoColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoColumns;
            singleContinuousRowToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousRow;
            singleContinuousColumnToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousColumn;
            twoContinuousRowsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousRows;
            twoContinuousColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousColumns;


            visualToolsToolStrip1.MandatoryVisualTool = annotationViewer1.VisualTool;
            visualToolsToolStrip1.ImageViewer = annotationViewer1;
            _annotationVisualTool = annotationViewer1.VisualTool;
            annotationViewer1.MouseMove += new MouseEventHandler(annotationViewer1_MouseMove);

            _interactionAreaAppearanceManager = new AnnotationInteractionAreaAppearanceManager();
            _interactionAreaAppearanceManager.VisualTool = annotationViewer1.AnnotationVisualTool;
            annotationViewer1.AnnotationVisualTool.SpellChecker = SpellCheckTools.CreateSpellCheckManager();

            //
            CloseCurrentFile();
            //
            DemosTools.SetDemoImagesFolder(openFileDialog1);

            //
            annotationViewer1.KeyPress += new KeyPressEventHandler(annotationViewer1_KeyPress);
            annotationViewer1.FocusedAnnotationViewChanged += new EventHandler<AnnotationViewChangedEventArgs>(annotationViewer1_SelectedAnnotationChanged);
            annotationViewer1.SelectedAnnotations.Changed += new EventHandler(SelectedAnnotations_Changed);
            annotationViewer1.AnnotationInteractionModeChanged += new EventHandler<AnnotationInteractionModeChangedEventArgs>(annotationViewer1_AnnotationInteractionModeChanged);
            annotationViewer1.AnnotationVisualTool.ActiveInteractionControllerChanged += new PropertyChangedEventHandler<IInteractionController>(AnnotationVisualTool_ActiveInteractionControllerChanged);
            annotationViewer1.AutoScrollPositionExChanging += new EventHandler<PropertyChangingEventArgs<PointF>>(annotationViewer1_AutoScrollPositionExChanging);
            annotationViewer1.AnnotationBuildingStarted += new EventHandler<AnnotationViewEventArgs>(annotationViewer1_AnnotationBuildingStarted);
            annotationViewer1.AnnotationBuildingFinished += new EventHandler<AnnotationViewEventArgs>(annotationViewer1_AnnotationBuildingFinished);
            annotationViewer1.AnnotationBuildingCanceled += new EventHandler<AnnotationViewEventArgs>(annotationViewer1_AnnotationBuildingCanceled);
            //
            annotationViewer1.Images.ImageCollectionSavingProgress += new EventHandler<ProgressEventArgs>(SavingProgress);
            annotationViewer1.Images.ImageCollectionSavingFinished += new EventHandler(images_ImageCollectionSavingFinished);
            annotationViewer1.Images.ImageSavingException += new EventHandler<ExceptionEventArgs>(Images_ImageSavingException);

            // create annotated image print document
#if REMOVE_PDF_PLUGIN
            _annotatedImagePrintDocument = new AnnotatedImagePrintDocument(thumbnailViewer1.AnnotationDataController);
#else
            _annotatedImagePrintDocument = new AnnotatedPdfPrintDocument(thumbnailViewer1.AnnotationDataController);
#endif
            _annotatedImagePrintDocument.Center = false;
            _annotatedImagePrintDocument.DistanceBetweenImages = 0;
            _annotatedImagePrintDocument.PrintScaleMode = PrintScaleMode.None;

            this.printDialog1.Document = _annotatedImagePrintDocument;

            // create the print manager
            _thumbnailViewerPrintManager = new ImageViewerPrintManager(
                thumbnailViewer1, _annotatedImagePrintDocument, printDialog1);

            // remember current image scale mode
            _imageScaleModeSelectedMenuItem = bestFitToolStripMenuItem;


            annotationInteractionModeToolStripComboBox.Items.Add(AnnotationInteractionMode.None);
            annotationInteractionModeToolStripComboBox.Items.Add(AnnotationInteractionMode.View);
            annotationInteractionModeToolStripComboBox.Items.Add(AnnotationInteractionMode.Author);
            // set interaction mode to the Author 
            annotationInteractionModeToolStripComboBox.SelectedItem = AnnotationInteractionMode.Author;

            _undoManager = new CompositeUndoManager();
            _undoManager.UndoLevel = 100;
            _undoManager.IsEnabled = false;
            _undoManager.Changed += new EventHandler<UndoManagerChangedEventArgs>(annotationUndoManager_Changed);
            _undoManager.Navigated += new EventHandler<UndoManagerNavigatedEventArgs>(annotationUndoManager_Navigated);

            _annotationViewerUndoMonitor = new CustomAnnotationViewerUndoMonitor(_undoManager, annotationViewer1);
            _annotationViewerUndoMonitor.ShowHistoryForDisplayedImages =
                showHistoryForDisplayedImagesToolStripMenuItem.Checked;

            // update the UI
            UpdateUI();

            DemosTools.CatchVisualToolExceptions(annotationViewer1);


            // create handler of changes of annotation's IRuler.UnitOfMeasure property
            _rulerAnnotationPropertyChangedEventHandler = new RulerAnnotationPropertyChangedEventHandler(annotationViewer1);


            // register view for mark annotation data
            AnnotationViewFactory.RegisterViewForAnnotationData(
               typeof(MarkAnnotationData),
               typeof(MarkAnnotationView));
            // register view for triangle annotation data
            AnnotationViewFactory.RegisterViewForAnnotationData(
                typeof(TriangleAnnotationData),
                typeof(TriangleAnnotationView));

            annotationViewer1.AnnotationDataController.AnnotationDataDeserializationException += new EventHandler<AnnotationDataDeserializationExceptionEventArgs>(AnnotationDataController_AnnotationDataDeserializationException);
#if !REMOVE_PDF_PLUGIN
            // enable PDF Password Dialog
            PdfAuthenticateTools.EnableAuthenticateRequest = true;
            // set CustomFontProgramsController for all opened PDF documents
            PdfFontProgramsTools.UseCustomFontProgramsController = true;
#endif

            // define custom serialization binder for correct deserialization of TriangleAnnotation v6.1 and earlier
            AnnotationSerializationBinder.Current = new CustomAnnotationSerializationBinder();

            moveAnnotationsBetweenImagesToolStripMenuItem.Checked = annotationViewer1.CanMoveAnnotationsBetweenImages;

            SelectionVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            MeasurementVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            ZoomVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            ImageProcessingVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            CustomVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
        }

        #endregion



        #region Properties

        bool _isFileOpening = false;
        internal bool IsFileOpening
        {
            get
            {
                return _isFileOpening;
            }
            set
            {
                _isFileOpening = value;

                if (InvokeRequired)
                    InvokeUpdateUI();
                else
                    UpdateUI();
            }
        }

        bool _isFileSaving = false;
        internal bool IsFileSaving
        {
            get
            {
                return _isFileSaving;
            }
            set
            {
                _isFileSaving = value;

                if (InvokeRequired)
                    InvokeUpdateUI();
                else
                    UpdateUI();
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Initializes the "Annotation" -> "Menu" menu items.
        /// </summary>
        private void InitializeAddAnnotationMenuItems()
        {
            _toolStripMenuItemToAnnotationType.Clear();

            _toolStripMenuItemToAnnotationType.Add(rectangleToolStripMenuItem, AnnotationType.Rectangle);
            _toolStripMenuItemToAnnotationType.Add(ellipseToolStripMenuItem, AnnotationType.Ellipse);
            _toolStripMenuItemToAnnotationType.Add(highlightToolStripMenuItem, AnnotationType.Highlight);
            _toolStripMenuItemToAnnotationType.Add(textHighlightToolStripMenuItem, AnnotationType.TextHighlight);
            _toolStripMenuItemToAnnotationType.Add(embeddedImageToolStripMenuItem, AnnotationType.EmbeddedImage);
            _toolStripMenuItemToAnnotationType.Add(referencedImageToolStripMenuItem, AnnotationType.ReferencedImage);
            _toolStripMenuItemToAnnotationType.Add(textToolStripMenuItem, AnnotationType.Text);
            _toolStripMenuItemToAnnotationType.Add(stickyNoteToolStripMenuItem, AnnotationType.StickyNote);
            _toolStripMenuItemToAnnotationType.Add(freeTextToolStripMenuItem, AnnotationType.FreeText);
            _toolStripMenuItemToAnnotationType.Add(rubberStampToolStripMenuItem, AnnotationType.RubberStamp);
            _toolStripMenuItemToAnnotationType.Add(linkToolStripMenuItem, AnnotationType.Link);
            _toolStripMenuItemToAnnotationType.Add(lineToolStripMenuItem, AnnotationType.Line);
            _toolStripMenuItemToAnnotationType.Add(linesToolStripMenuItem, AnnotationType.Lines);
            _toolStripMenuItemToAnnotationType.Add(linesWithInterpolationToolStripMenuItem, AnnotationType.LinesWithInterpolation);
            _toolStripMenuItemToAnnotationType.Add(freehandLinesToolStripMenuItem, AnnotationType.FreehandLines);
            _toolStripMenuItemToAnnotationType.Add(polygonToolStripMenuItem, AnnotationType.Polygon);
            _toolStripMenuItemToAnnotationType.Add(polygonWithInterpolationToolStripMenuItem, AnnotationType.PolygonWithInterpolation);
            _toolStripMenuItemToAnnotationType.Add(freehandPolygonToolStripMenuItem, AnnotationType.FreehandPolygon);
            _toolStripMenuItemToAnnotationType.Add(rulerToolStripMenuItem, AnnotationType.Ruler);
            _toolStripMenuItemToAnnotationType.Add(rulersToolStripMenuItem, AnnotationType.Rulers);
            _toolStripMenuItemToAnnotationType.Add(angleToolStripMenuItem, AnnotationType.Angle);
            _toolStripMenuItemToAnnotationType.Add(triangleCustomAnnotationToolStripMenuItem, AnnotationType.Triangle);
            _toolStripMenuItemToAnnotationType.Add(markCustomAnnotationToolStripMenuItem, AnnotationType.Mark);
        }


        #region Main form

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process. </param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process. </param>
        /// <returns>
        /// <b>true</b> if the character was processed by the control; otherwise, <b>false</b>.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (annotationViewer1.Focused && annotationViewer1.VisualTool != null)
            {
                if (!annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                {
                    if (keyData == Keys.Tab)
                    {
                        if (annotationViewer1.VisualTool.PerformNextItemSelection(true))
                            return true;
                    }
                    else if (keyData == (Keys.Shift | Keys.Tab))
                    {
                        if (annotationViewer1.VisualTool.PerformNextItemSelection(false))
                            return true;
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Main form is shown.
        /// </summary>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            // process command line of the application
            string[] appArgs = Environment.GetCommandLineArgs();
            if (appArgs.Length > 0)
            {
                Application.DoEvents();
                if (appArgs.Length == 2)
                {
                    try
                    {
                        OpenFile(appArgs[1]);
                    }
                    catch
                    {
                        CloseCurrentFile();
                    }
                }
                else
                {
                    for (int i = 1; i < appArgs.Length; i++)
                    {
                        try
                        {
                            annotationViewer1.Images.Add(appArgs[i]);
                        }
                        catch
                        {
                        }
                    }
                }

                // update the UI
                UpdateUI();
            }
        }

        /// <summary>
        /// Main form is closing.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isFormClosing = true;
        }

        /// <summary>
        /// Main form is closed.
        /// </summary>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseCurrentFile();

            _annotationViewerUndoMonitor.Dispose();
            _undoManager.Dispose();

            if (_dataStorage != null)
                _dataStorage.Dispose();

            _interactionAreaAppearanceManager.Dispose();

            AnnotationVisualTool annotationVisualTool = annotationViewer1.AnnotationVisualTool;
            if (annotationVisualTool.SpellChecker != null)
            {
                SpellCheckManager manager = annotationVisualTool.SpellChecker;
                annotationVisualTool.SpellChecker = null;
                SpellCheckTools.DisposeSpellCheckManagerAndEngines(manager);
            }
        }

        #endregion


        #region UI state

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            // get the current status of application
            bool isFileOpening = IsFileOpening;
            bool isFileLoaded = _sourceFilename != null;
            bool isFileReadOnlyMode = _isFileReadOnlyMode;
            bool isFileEmpty = true;
            if (annotationViewer1.Images != null)
                isFileEmpty = annotationViewer1.Images.Count <= 0;
            bool isFileSaving = IsFileSaving;
            bool isImageSelected = annotationViewer1.Image != null;
            bool isAnnotationEmpty = true;
            if (isImageSelected)
                isAnnotationEmpty = annotationViewer1.AnnotationDataController[annotationViewer1.FocusedIndex].Count <= 0;
            bool isAnnotationSelected = annotationViewer1.FocusedAnnotationView != null || annotationViewer1.SelectedAnnotations.Count > 0;
            bool isAnnotationBuilding = annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding;
            bool isInteractionModeAuthor = annotationViewer1.AnnotationInteractionMode == AnnotationInteractionMode.Author;
            bool isCanUndo = _undoManager.UndoCount > 0 && !annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding;
            bool isCanRedo = _undoManager.RedoCount > 0 && !annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding;

            // "File" menu
            fileToolStripMenuItem.Enabled = !isFileOpening && !isFileSaving;
            saveCurrentFileToolStripMenuItem.Enabled = isFileLoaded && !isFileEmpty && !isFileReadOnlyMode;
            saveAsToolStripMenuItem.Enabled = !isFileEmpty;
            saveToToolStripMenuItem.Enabled = !isFileEmpty;
            closeToolStripMenuItem.Enabled = isFileLoaded;
            printToolStripMenuItem.Enabled = !isFileEmpty;

            // "View" menu
            viewerToolStrip.Enabled = !isFileOpening && !isFileSaving;
            moveAnnotationsBetweenImagesToolStripMenuItem.Enabled =
                annotationViewer1.DisplayMode != ImageViewerDisplayMode.SinglePage;

            // update "View => Image Display Mode" menu
            singlePageToolStripMenuItem.Checked = false;
            twoColumnsToolStripMenuItem.Checked = false;
            singleContinuousRowToolStripMenuItem.Checked = false;
            singleContinuousColumnToolStripMenuItem.Checked = false;
            twoContinuousRowsToolStripMenuItem.Checked = false;
            twoContinuousColumnsToolStripMenuItem.Checked = false;
            switch (annotationViewer1.DisplayMode)
            {
                case ImageViewerDisplayMode.SinglePage:
                    singlePageToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoColumns:
                    twoColumnsToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.SingleContinuousRow:
                    singleContinuousRowToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.SingleContinuousColumn:
                    singleContinuousColumnToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoContinuousRows:
                    twoContinuousRowsToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoContinuousColumns:
                    twoContinuousColumnsToolStripMenuItem.Checked = true;
                    break;
            }
            spellCheckSettingsToolStripMenuItem.Enabled = annotationViewer1.AnnotationVisualTool.SpellChecker != null;

            // "Edit" menu
            editToolStripMenuItem.Enabled = !isFileEmpty;
            if (!editToolStripMenuItem.Enabled)
                CloseHistoryForm();
            enableUndoRedoToolStripMenuItem.Checked = _undoManager.IsEnabled;
            undoToolStripMenuItem.Enabled = _undoManager.IsEnabled && !isFileOpening && !isFileSaving && isCanUndo;
            redoToolStripMenuItem.Enabled = _undoManager.IsEnabled && !isFileOpening && !isFileSaving && isCanRedo;
            undoRedoSettingsToolStripMenuItem.Enabled = _undoManager.IsEnabled && !isFileOpening && !isFileSaving &&
                !annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding;
            historyDialogToolStripMenuItem.Enabled = _undoManager.IsEnabled && !isFileOpening && !isFileSaving;

            // "Annotations" menu
            //
            annotationsInfoToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;
            //
            interactionModeToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;
            //
            loadFromFileToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;
            //
            addAnnotationToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty && isInteractionModeAuthor;
            buildAnnotationsContinuouslyToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;
            //
            bringToBackToolStripMenuItem1.Enabled = !isFileOpening && !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding;
            bringToFrontToolStripMenuItem1.Enabled = !isFileOpening && !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding;
            //
            multiSelectToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;
            //
            groupSelectedToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding;
            groupAllToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding;
            //
            rotateImageWithAnnotationsToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;
            burnAnnotationsOnImageToolStripMenuItem.Enabled = !isAnnotationEmpty;
            cloneImageWithAnnotationsToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;
            //
            saveToFileToolStripMenuItem.Enabled = !isAnnotationEmpty;

            // annotation viewer context menu
            annoViewerMenu.Enabled = !isFileOpening && !isFileEmpty;
            saveImageWithAnnotationsToolStripMenuItem.Enabled = !isAnnotationEmpty;
            burnAnnotationsOnImage2ToolStripMenuItem.Enabled = !isAnnotationEmpty;
            copyImageToClipboardToolStripMenuItem.Enabled = isImageSelected;
            deleteImageToolStripMenuItem.Enabled = isImageSelected && !isFileSaving;
            bringToBackToolStripMenuItem.Enabled = isAnnotationSelected;
            bringToFrontToolStripMenuItem.Enabled = isAnnotationSelected;

            // annotation tool strip 
            annotationsToolStrip1.Enabled = !isFileOpening && !isFileEmpty;

            // selection mode
            selectionModeToolStrip.Enabled = !isFileOpening && !isFileEmpty;

            // zoom
            zoomTrackBar.Enabled = !isFileOpening && !isFileEmpty;

            // thumbnailViewer1 & annotationViewer1 & propertyGrid1 & annotationComboBox
            zoomPanel.Enabled = !IsFileOpening && !isFileEmpty;
            if (annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                annotationComboBox.Enabled = false;
            else
                annotationComboBox.Enabled = true;

            // viewer tool strip
            viewerToolStrip.Enabled = !isFileOpening;
            viewerToolStrip.SaveButtonEnabled = !isFileEmpty && !IsFileSaving;
            viewerToolStrip.PrintButtonEnabled = !isFileEmpty && !IsFileSaving;

            //
            string str = Path.GetFileName(_sourceFilename);
            if (_isFileReadOnlyMode)
                str += " [Read Only]";
            Text = string.Format(_titlePrefix, str);
        }

        /// <summary>
        /// Update UI safely.
        /// </summary>
        private void InvokeUpdateUI()
        {
            if (InvokeRequired)
                Invoke(new UpdateUIDelegate(UpdateUI));
            else
                UpdateUI();
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Clears image collection of image viewer and
        /// adds image(s) to an image collection of image viewer.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFileOpening = true;

            CodecsFileFilters.SetFilters(openFileDialog1);

            // select image file
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // clear image collection of the image viewer if necessary
                if (annotationViewer1.Images.Count > 0)
                {
                    annotationViewer1.Images.ClearAndDisposeItems();
                }

                // add image file to image collection of the image viewer
                try
                {
                    OpenFile(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            IsFileOpening = false;
        }

        /// <summary>
        /// Adds image(s) to an image collection of image viewer.
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFileOpening = true;

            CodecsFileFilters.SetFilters(openFileDialog1);

            openFileDialog1.Multiselect = true;

            // select image file(s)
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // add image file(s) to image collection of the image viewer
                try
                {
                    foreach (string fileName in openFileDialog1.FileNames)
                        annotationViewer1.Images.Add(fileName);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            openFileDialog1.Multiselect = false;

            IsFileOpening = false;
        }

        /// <summary>
        /// Saves image collection with annotations to the first source of image collection,
        /// i.e. saves modified image collection with annotations back to the source file.
        /// </summary>
        private void saveCurrentImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImageCollectionToSourceFile();
        }

        /// <summary>
        /// Saves image collection with annotations of image viewer to new source and
        /// switches to the new source.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImageCollectionToMultipageImageFile(true);
        }

        /// <summary>
        /// Saves image collection with annotations of image viewer to new source and
        /// do NOT switch to the new source.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImageCollectionToMultipageImageFile(false);
        }

        /// <summary>
        /// Closes the current image file.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCurrentFile();

            // update the UI
            UpdateUI();
        }


        /// <summary>
        /// Prints images with annotations.
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thumbnailViewerPrintManager.Print();
        }


        /// <summary>
        /// Exits the application.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region 'Edit' menu

        /// <summary>
        /// Enables/disables the undo manager.
        /// </summary>
        private void enableUndoRedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isUndoManagerEnabled = _undoManager.IsEnabled ^ true;


            if (!isUndoManagerEnabled)
            {
                CloseHistoryForm();

                _undoManager.Clear();
            }

            _undoManager.IsEnabled = isUndoManagerEnabled;

            UpdateUndoRedoMenu(_undoManager);

            // update UI
            UpdateUI();
        }

        /// <summary>
        /// Undoes changes in annotation collection or annotation.
        /// </summary>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                return;

            _undoManager.Undo(1);
            UpdateUI();
        }

        /// <summary>
        /// Redoes changes in annotation collection or annotation.
        /// </summary>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                return;

            _undoManager.Redo(1);
            UpdateUI();
        }

        /// <summary>
        /// Edits the undo manager settings.
        /// </summary>
        private void undoRedoSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataStorage dataStorage = _dataStorage;

            if (dataStorage is CompositeDataStorage)
            {
                CompositeDataStorage compositeStorage = (CompositeDataStorage)dataStorage;
                dataStorage = compositeStorage.Storages[0];
            }

            using (UndoManagerSettingsForm dlg = new UndoManagerSettingsForm(_undoManager, dataStorage))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Owner = this;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.DataStorage != dataStorage)
                    {
                        IDataStorage prevDataStorage = _dataStorage;

                        if (dlg.DataStorage is CompressedImageStorage)
                        {
                            _dataStorage = new CompositeDataStorage(
                                dlg.DataStorage,
                                new CloneableObjectStorageInMemory());
                        }
                        else
                        {
                            _dataStorage = dlg.DataStorage;
                        }

                        _undoManager.Clear();
                        _undoManager.DataStorage = _dataStorage;

                        _annotationViewerUndoMonitor.DataStorage = _dataStorage;

                        if (prevDataStorage != null)
                            prevDataStorage.Dispose();
                    }
                    UpdateUndoRedoMenu(_undoManager);
                }
            }
        }

        /// <summary>
        /// Enables/disables showing history for the displayed images.
        /// </summary>
        private void showHistoryForDisplayedImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHistoryForDisplayedImagesToolStripMenuItem.Checked ^= true;

            _annotationViewerUndoMonitor.ShowHistoryForDisplayedImages =
                showHistoryForDisplayedImagesToolStripMenuItem.Checked;
        }

        #endregion


        #region 'View' menu

        /// <summary>
        /// Changes image display mode of image viewer.
        /// </summary>
        private void ImageDisplayMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem imageDisplayModeMenuItem = (ToolStripMenuItem)sender;
            annotationViewer1.DisplayMode = (ImageViewerDisplayMode)imageDisplayModeMenuItem.Tag;
            UpdateUI();
        }

        /// <summary>
        /// Changes settings of thumbanil viewer.
        /// </summary>
        private void thumbnailViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThumbnailViewerSettingsForm viewerSettingsDialog = new ThumbnailViewerSettingsForm(thumbnailViewer1);
            viewerSettingsDialog.ShowDialog();
        }

        /// <summary>
        /// Enables/disables usage of bounding box during creation/transformation of annotation.
        /// </summary>
        private void boundAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.IsAnnotationBoundingRectEnabled = boundAnnotationsToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Enables/disables the ability to move annotations between images.
        /// </summary>
        private void moveAnnotationsBetweenImagesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            annotationViewer1.CanMoveAnnotationsBetweenImages = moveAnnotationsBetweenImagesToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Changes settings of annotation viewer.
        /// </summary>
        private void annotationViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageViewerSettingsForm viewerSettingsDialog = new ImageViewerSettingsForm(annotationViewer1);
            viewerSettingsDialog.ShowDialog();
            UpdateUI();
        }

        /// <summary>
        /// Sets an image size mode.
        /// </summary>
        private void imageSizeMode_Click(object sender, EventArgs e)
        {
            // disable previously checked menu
            _imageScaleModeSelectedMenuItem.Checked = false;

            //
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            switch (item.Text)
            {
                case "Normal":
                    annotationViewer1.SizeMode = ImageSizeMode.Normal;
                    break;
                case "Best fit":
                    annotationViewer1.SizeMode = ImageSizeMode.BestFit;
                    break;
                case "Fit to width":
                    annotationViewer1.SizeMode = ImageSizeMode.FitToWidth;
                    break;
                case "Fit to height":
                    annotationViewer1.SizeMode = ImageSizeMode.FitToHeight;
                    break;
                case "Pixel to Pixel":
                    annotationViewer1.SizeMode = ImageSizeMode.PixelToPixel;
                    break;
                case "Scale":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    break;
                case "25%":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    annotationViewer1.Zoom = 25;
                    break;
                case "50%":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    annotationViewer1.Zoom = 50;
                    break;
                case "100%":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    annotationViewer1.Zoom = 100;
                    break;
                case "200%":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    annotationViewer1.Zoom = 200;
                    break;
                case "400%":
                    annotationViewer1.SizeMode = ImageSizeMode.Zoom;
                    annotationViewer1.Zoom = 400;
                    break;
            }

            _imageScaleModeSelectedMenuItem = item;
            _imageScaleModeSelectedMenuItem.Checked = true;
        }

        /// <summary>
        /// Enables/disables logging of annotation's changes.
        /// </summary>
        private void showEventsLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showEventsLogToolStripMenuItem.Checked = !showEventsLogToolStripMenuItem.Checked;
            splitContainer4.Panel2Collapsed = !showEventsLogToolStripMenuItem.Checked;

            if (_annotationLogger == null)
                _annotationLogger = new AnnotationsLogger(annotationViewer1, annotationEventsLog);

            _annotationLogger.IsEnabled = showEventsLogToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Show settings of interaction area.
        /// </summary>
        private void interactionPointsAppearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (InteractionAreaAppearanceManagerForm dialog = new InteractionAreaAppearanceManagerForm())
            {
                dialog.InteractionAreaSettings = _interactionAreaAppearanceManager;
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Edits the color management settings.
        /// </summary>
        private void colorManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorManagementSettingsForm.EditColorManagement(annotationViewer1);
        }

        /// <summary>
        /// Edits the spell check settings.
        /// </summary>
        private void spellCheckSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SpellCheckManagerSettingsForm dialog = new SpellCheckManagerSettingsForm(
                annotationViewer1.AnnotationVisualTool.SpellChecker))
            {
                dialog.Owner = this;

                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Edits the spell check view settings.
        /// </summary>
        private void spellCheckViewSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SpellCheckManagerViewSettingsForm dialog = new SpellCheckManagerViewSettingsForm())
            {
                dialog.InteractionAreaSettings = _interactionAreaAppearanceManager;
                dialog.ShowDialog();
            }
        }

        #endregion


        #region 'Annotation' menu

        /// <summary>
        /// "Annotations" menu is opening.
        /// </summary>
        private void annotationsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            // annotation viewer has the focused annotation AND focused annotation is line-based annotation
            if (annotationViewer1.FocusedAnnotationView != null && annotationViewer1.FocusedAnnotationView is LineAnnotationViewBase)
            {
                SetIsEnabled(transformationModeToolStripMenuItem, true);
                UpdateTransformationMenu();
            }
            else
            {
                SetIsEnabled(transformationModeToolStripMenuItem, false);
            }

            UpdateEditMenuItems();
        }

        /// <summary>
        /// "Annotations" menu is closed.
        /// </summary>
        private void annotationsToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            EnableEditMenuItems();
        }

        /// <summary>
        /// Shows information about annotation collections of all images.
        /// </summary>
        private void annotationsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationsInfoForm ai = new AnnotationsInfoForm(annotationViewer1.AnnotationDataController);
            ai.ShowDialog();
        }


        #region Interaction Mode

        /// <summary>
        /// Changes the annotation interaction mode to None.
        /// </summary>
        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.AnnotationInteractionMode = AnnotationInteractionMode.None;
        }

        /// <summary>
        /// Changes the annotation interaction mode to View.
        /// </summary>
        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            annotationViewer1.AnnotationInteractionMode = AnnotationInteractionMode.View;
        }

        /// <summary>
        /// Changes the annotation interaction mode to Author.
        /// </summary>
        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.AnnotationInteractionMode = AnnotationInteractionMode.Author;
        }

        #endregion


        #region Transformation Mode

        /// <summary>
        /// Sets "Enabled" property in a tool strip menu item and in its sub items.
        /// </summary>
        /// <param name="item">Tool strip menu item.</param>
        /// <param name="isEnabled">Determines if tool strip menu item is enabled.</param>
        private void SetIsEnabled(ToolStripMenuItem item, bool isEnabled)
        {
            item.Enabled = isEnabled;
            foreach (ToolStripMenuItem subitem in item.DropDownItems)
            {
                subitem.Enabled = isEnabled;
            }
        }

        /// <summary>
        /// Updates "Annotations -> Transformation Mode" menu. 
        /// </summary>
        private void UpdateTransformationMenu()
        {
            // checks which tramsformation mode selected for focused annotation
            GripMode mode = ((LineAnnotationViewBase)annotationViewer1.FocusedAnnotationView).GripMode;
            rectangularToolStripMenuItem.Checked = mode == GripMode.Rectangular;
            pointsToolStripMenuItem.Checked = mode == GripMode.Points;
            rectangularAndPointsToolStripMenuItem.Checked = mode == GripMode.RectangularAndPoints;
        }

        /// <summary>
        /// Sets "rectangular" transformation mode for focused annotation.
        /// </summary>
        private void rectangularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((LineAnnotationViewBase)annotationViewer1.FocusedAnnotationView).GripMode = GripMode.Rectangular;
            UpdateTransformationMenu();
        }

        /// <summary>
        /// Sets "points" transformation mode for focused annotation. 
        /// </summary>
        private void pointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((LineAnnotationViewBase)annotationViewer1.FocusedAnnotationView).GripMode = GripMode.Points;
            UpdateTransformationMenu();
        }

        /// <summary>
        /// Sets "rectangular and points" transformation mode for focused annotation.
        /// </summary>
        private void rectangularAndPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((LineAnnotationViewBase)annotationViewer1.FocusedAnnotationView).GripMode = GripMode.RectangularAndPoints;
            UpdateTransformationMenu();
        }

        #endregion


        #region Load and Save annotations

        /// <summary>
        /// Loads annotation collection from file.
        /// </summary>
        private void loadAnnotationsFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFileOpening = true;

            AnnotationDemosTools.LoadAnnotationsFromFile(annotationViewer1, openFileDialog1, _undoManager);

            IsFileOpening = false;
        }

        /// <summary>
        /// Saves annotation collection to a file.
        /// </summary>
        private void saveAnnotationsToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFileSaving = true;

            AnnotationDemosTools.SaveAnnotationsToFile(annotationViewer1, saveFileDialog1);

            IsFileSaving = false;
        }

        #endregion


        /// <summary>
        /// Starts the annotation building.
        /// </summary>
        private void addAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationType annotationType = _toolStripMenuItemToAnnotationType[(ToolStripMenuItem)sender];

            // start new annotation building process and specify that this is the first process
            annotationsToolStrip1.AddAndBuildAnnotation(annotationType);
        }

        /// <summary>
        /// Enables/disables the continuous building of annotations.
        /// </summary>
        private void buildAnnotationsContinuouslyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            annotationsToolStrip1.NeedBuildAnnotationsContinuously = buildAnnotationsContinuouslyToolStripMenuItem.Checked;
        }


        #region UI actions

        /// <summary>
        /// Enables the UI action items in "Edit" menu.
        /// </summary>
        private void EnableEditMenuItems()
        {
            cutToolStripMenuItem.Enabled = true;
            copyToolStripMenuItem.Enabled = true;
            pasteToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
            deleteAllToolStripMenuItem.Enabled = true;
            selectAllToolStripMenuItem.Enabled = true;
            deselectAllToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Cuts selected annotation.
        /// </summary>
        private void cutAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get UI action
            CutItemUIAction cutUIAction = GetUIAction<CutItemUIAction>(annotationViewer1.VisualTool);
            // if UI action is not empty AND UI action is enabled
            if (cutUIAction != null && cutUIAction.IsEnabled)
            {
                // begin the composite undo action
                _undoManager.BeginCompositeAction("AnnotationViewCollection: Cut");

                try
                {
                    cutUIAction.Execute();
                }
                finally
                {
                    // end the composite undo action
                    _undoManager.EndCompositeAction();
                }
            }

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Copies selected annotation.
        /// </summary>
        private void copyAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get UI action
            CopyItemUIAction copyUIAction = GetUIAction<CopyItemUIAction>(annotationViewer1.VisualTool);
            // if UI action is not empty AND UI action is enabled
            if (copyUIAction != null && copyUIAction.IsEnabled)
            {
                // execute action
                copyUIAction.Execute();
            }

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Pastes annotations from "internal" buffer and makes them active.
        /// </summary>
        private void pasteAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get UI action
            PasteItemWithOffsetUIAction pasteUIAction = GetUIAction<PasteItemWithOffsetUIAction>(annotationViewer1.VisualTool);
            // if UI action is not empty AND UI action is enabled
            if (pasteUIAction != null && pasteUIAction.IsEnabled)
            {
                pasteUIAction.OffsetX = 20;
                pasteUIAction.OffsetY = 20;

                _undoManager.BeginCompositeAction("AnnotationViewCollection: Paste");

                try
                {
                    pasteUIAction.Execute();
                }
                finally
                {
                    _undoManager.EndCompositeAction();
                }
            }

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Removes selected annotation from annotation collection.
        /// </summary>
        private void deleteAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if thumbnail viewer is focused
            if (thumbnailViewer1.Focused)
            {
                thumbnailViewer1.DoDelete();
            }
            else
            {
                // delete the selected annotation from image
                DeleteAnnotation(false);
            }

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Removes all annotations from annotation collection.
        /// </summary>
        private void deleteAllAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // delete all annotations from image
            DeleteAnnotation(true);

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Updates the UI action items in "Edit" menu.
        /// </summary>
        private void UpdateEditMenuItems()
        {
            // if the thumbnail viewer has the input focus
            if (thumbnailViewer1.Focused)
            {
                UpdateEditMenuItem(cutToolStripMenuItem, null, "Cut");
                UpdateEditMenuItem(copyToolStripMenuItem, null, "Copy");
                UpdateEditMenuItem(pasteToolStripMenuItem, null, "Paste");
                deleteToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Text = "Delete Page(s)";
                deleteAllToolStripMenuItem.Enabled = false;
                deleteAllToolStripMenuItem.Text = "Delete All";
                bool isFileEmpty = true;
                if (annotationViewer1.Images != null)
                    isFileEmpty = annotationViewer1.Images.Count <= 0;
                selectAllToolStripMenuItem.Enabled = !isFileEmpty && !IsFileOpening;
                selectAllToolStripMenuItem.Text = "Select All Pages";
                UpdateEditMenuItem(deselectAllToolStripMenuItem, null, "Deselect All");
            }
            // if the thumbnail viewer does NOT have the input focus
            else
            {
                UpdateEditMenuItem(cutToolStripMenuItem, GetUIAction<CutItemUIAction>(annotationViewer1.VisualTool), "Cut");
                UpdateEditMenuItem(copyToolStripMenuItem, GetUIAction<CopyItemUIAction>(annotationViewer1.VisualTool), "Copy");
                UpdateEditMenuItem(pasteToolStripMenuItem, GetUIAction<PasteItemUIAction>(annotationViewer1.VisualTool), "Paste");
                UpdateEditMenuItem(deleteToolStripMenuItem, GetUIAction<DeleteItemUIAction>(annotationViewer1.VisualTool), "Delete");
                UpdateEditMenuItem(deleteAllToolStripMenuItem, GetUIAction<DeleteAllItemsUIAction>(annotationViewer1.VisualTool), "Delete All");
                UpdateEditMenuItem(selectAllToolStripMenuItem, GetUIAction<SelectAllItemsUIAction>(annotationViewer1.VisualTool), "Select All");
                UpdateEditMenuItem(deselectAllToolStripMenuItem, GetUIAction<DeselectAllItemsUIAction>(annotationViewer1.VisualTool), "Deselect All");
            }

        }

        /// <summary>
        /// Updates the UI action item in "Edit" menu.
        /// </summary>
        /// <param name="menuItem">The "Edit" menu item.</param>
        /// <param name="uiAction">The UI action, which is associated with the "Edit" menu item.</param>
        /// <param name="defaultText">The default text for the "Edit" menu item.</param>
        private void UpdateEditMenuItem(ToolStripMenuItem editMenuItem, UIAction uiAction, string defaultText)
        {
            // if UI action is specified AND UI action is enabled
            if (uiAction != null && uiAction.IsEnabled)
            {
                // enable the menu item
                editMenuItem.Enabled = true;
                // set text to the menu item
                editMenuItem.Text = uiAction.Name;
            }
            else
            {
                // disable the menu item
                editMenuItem.Enabled = false;
                // set the default text to the menu item
                editMenuItem.Text = defaultText;
            }
        }

        /// <summary>
        /// Returns the UI action of the visual tool.
        /// </summary>
        /// <param name="visualTool">Visual tool.</param>
        /// <returns>The UI action of the visual tool.</returns>
        private T GetUIAction<T>(VisualTool visualTool)
            where T : UIAction
        {
            IList<UIAction> uiActions = null;
            // if visual tool has actions
            if (TryGetCurrentToolActions(visualTool, out uiActions))
            {
                // for each action in list
                foreach (UIAction uiAction in uiActions)
                {
                    if (uiAction is T)
                        return (T)uiAction;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Returns the UI actions of visual tool.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        /// <param name="uiActions">The list of UI actions supported by the current visual tool.</param>
        /// <returns>
        /// <b>true</b> - UI actions are found; otherwise, <b>false</b>.
        /// </returns>
        private bool TryGetCurrentToolActions(
            VisualTool visualTool,
            out IList<UIAction> uiActions)
        {
            uiActions = null;
            ISupportUIActions currentToolWithUIActions = visualTool as ISupportUIActions;
            if (currentToolWithUIActions != null)
                uiActions = currentToolWithUIActions.GetSupportedUIActions();

            return uiActions != null;
        }


        /// <summary>
        /// Brings the selected annotation to the first position in annotation collection.
        /// </summary>
        private void bringToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.CancelAnnotationBuilding();

            annotationViewer1.BringFocusedAnnotationToBack();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Brings the selected annotation to the last position in annotation collection.
        /// </summary>
        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.CancelAnnotationBuilding();

            annotationViewer1.BringFocusedAnnotationToFront();

            // update the UI
            UpdateUI();
        }


        /// <summary>
        /// Enables/disables multi selection of annotations in viewer.
        /// </summary>
        private void multiSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.AnnotationMultiSelect = multiSelectToolStripMenuItem.Checked;
            UpdateUI();
        }

        /// <summary>
        /// Selects all annotations of annotation collection.
        /// </summary>
        private void selectAllAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.CancelAnnotationBuilding();

            // if thumbnail viewer is focused
            if (thumbnailViewer1.Focused)
            {
                thumbnailViewer1.DoSelectAll();
            }
            else
            {
                // get UI action
                SelectAllItemsUIAction selectAllUIAction = GetUIAction<SelectAllItemsUIAction>(annotationViewer1.VisualTool);
                // if UI action is not empty AND UI action is enabled
                if (selectAllUIAction != null && selectAllUIAction.IsEnabled)
                {
                    // execute UI action
                    selectAllUIAction.Execute();
                }
            }

            UpdateUI();
        }

        /// <summary>
        /// Deselects all annotations of annotation collection.
        /// </summary>
        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.CancelAnnotationBuilding();

            // if thumbnail viewer is not focused
            if (!thumbnailViewer1.Focused)
            {
                // get UI action
                DeselectAllItemsUIAction deselectAllUIAction = GetUIAction<DeselectAllItemsUIAction>(annotationViewer1.VisualTool);
                // if UI action is not empty AND UI action is enabled
                if (deselectAllUIAction != null && deselectAllUIAction.IsEnabled)
                {
                    // execute UI action
                    deselectAllUIAction.Execute();
                }
            }

            UpdateUI();
        }


        /// <summary>
        /// Groups/ungroups selected annotations of annotation collection.
        /// </summary>
        private void groupSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationDemosTools.GroupUngroupSelectedAnnotations(annotationViewer1, _undoManager);
        }

        /// <summary>
        /// Groups all annotations of annotation collection.
        /// </summary>
        private void groupAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationDemosTools.GroupAllAnnotations(annotationViewer1, _undoManager);
        }

        #endregion


        #region Rotate, Burn, Clone

        /// <summary>
        /// Rotates image with annotations.
        /// </summary>
        private void rotateImageWithAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationDemosTools.RotateImageWithAnnotations(annotationViewer1, _undoManager, _dataStorage);
        }

        /// <summary>
        /// Burns an annotation collection on image.
        /// </summary>
        private void burnAnnotationsOnImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                AnnotationDemosTools.BurnAnnotationsOnImage(annotationViewer1, _undoManager, _dataStorage);

                // update the UI
                UpdateUI();

            }
            catch (ImageProcessingException ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Burn annotations on image", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                Cursor = Cursors.Default;
                DemosTools.ShowErrorMessage(exc);
            }
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Clones image with annotations.
        /// </summary>
        private void cloneImageWithAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationViewer1.CancelAnnotationBuilding();

            annotationViewer1.AnnotationDataController.CloneImageWithAnnotations(annotationViewer1.FocusedIndex, annotationViewer1.Images.Count);
            annotationViewer1.FocusedIndex = annotationViewer1.Images.Count - 1;
        }

        #endregion

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Shows the About dialog.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxForm dlg = new AboutBoxForm();
            dlg.ShowDialog();
        }

        #endregion


        #region Context menu

        /// <summary>
        /// Saves focused image with annotations to a file.
        /// </summary>
        private void saveImageWithAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFocusedImageToNewImageFile();
        }

        /// <summary>
        /// Copies focused image with annotations to clipboard.
        /// </summary>
        private void copyImageToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationDemosTools.CopyImageToClipboard(annotationViewer1);
        }

        /// <summary>
        /// Deletes focused image.
        /// </summary>
        private void deleteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteImages();

            // update the UI
            UpdateUI();
        }

        #endregion


        #region Annotation viewer

        /// <summary>
        /// Handles the MouseMove event of the annotationViewer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance
        /// containing the event data.</param>
        private void annotationViewer1_MouseMove(object sender, MouseEventArgs e)
        {
            // if viewer must be scrolled when annotation is moved
            if (scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Checked)
            {
                // if left mouse button is pressed
                if (e.Button == MouseButtons.Left)
                {
                    // get the interaction controller of annotation viewer
                    IInteractionController interactionController =
                        annotationViewer1.AnnotationVisualTool.ActiveInteractionController;
                    // if user interacts with annotation
                    if (interactionController != null && interactionController.IsInteracting)
                    {
                        const int delta = 20;

                        // get the "visible area" of annotation viewer
                        Rectangle rect = annotationViewer1.ClientRectangle;
                        // remove "border" from the "visible area"
                        rect.Inflate(-delta, -delta);

                        // if mouse is located in "border"
                        if (!rect.Contains(e.Location))
                        {
                            // calculate how to scroll the annotation viewer
                            int deltaX = 0;
                            if (e.X < delta)
                                deltaX = -(delta - e.X);
                            if (e.X > delta + rect.Width)
                                deltaX = -(delta + rect.Width - e.X);
                            int deltaY = 0;
                            if (e.Y < delta)
                                deltaY = -(delta - e.Y);
                            if (e.Y > delta + rect.Height)
                                deltaY = -(delta + rect.Height - e.Y);

                            // get the auto scroll position of annotation viewer
                            Point autoScrollPosition = new Point(Math.Abs(annotationViewer1.AutoScrollPosition.X), Math.Abs(annotationViewer1.AutoScrollPosition.Y));

                            // calculate new auto scroll position
                            if (annotationViewer1.AutoScrollMinSize.Width > 0 && deltaX != 0)
                                autoScrollPosition.X += deltaX;
                            if (annotationViewer1.AutoScrollMinSize.Height > 0 && deltaY != 0)
                                autoScrollPosition.Y += deltaY;

                            // if auto scroll position is changed
                            if (autoScrollPosition != annotationViewer1.AutoScrollPosition)
                                // set new auto scroll position
                                annotationViewer1.AutoScrollPosition = autoScrollPosition;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The scroll position of the annotation viewer is changing.
        /// </summary>
        private void annotationViewer1_AutoScrollPositionExChanging(object sender, PropertyChangingEventArgs<PointF> e)
        {
            // if viewer must be scrolled when annotation is moved
            if (scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Checked)
            {
                // get the interaction controller of annotation viewer
                IInteractionController interactionController =
                    annotationViewer1.AnnotationVisualTool.ActiveInteractionController;
                // if user interacts with annotation
                if (interactionController != null && interactionController.IsInteracting)
                {
                    // get bounding box of displayed images
                    RectangleF displayedImagesBBox = annotationViewer1.GetDisplayedImagesBoundingBox();

                    // get the scroll position
                    PointF scrollPosition = e.NewValue;

                    // cut the coordinates for getting coordinates inside the focused image
                    scrollPosition.X = Math.Max(displayedImagesBBox.X, Math.Min(scrollPosition.X, displayedImagesBBox.Right));
                    scrollPosition.Y = Math.Max(displayedImagesBBox.Y, Math.Min(scrollPosition.Y, displayedImagesBBox.Bottom));

                    // update the scroll position
                    e.NewValue = scrollPosition;
                }
            }
        }

        /// <summary>
        /// AnnotationData deserialization exception handler.
        /// </summary>
        void AnnotationDataController_AnnotationDataDeserializationException(object sender, Vintasoft.Imaging.Annotation.AnnotationDataDeserializationExceptionEventArgs e)
        {
            DemosTools.ShowErrorMessage("AnnotationData deserialization exception", e.Exception);
        }

        /// <summary>
        /// Catches a visual tool exception.
        /// </summary>
        void annotationViewer1_VisualToolException(object sender, ExceptionEventArgs e)
        {
            DemosTools.ShowErrorMessage(e.Exception);
        }

        /// <summary>
        /// Image loading in viewer is started.
        /// </summary>
        private void annotationViewer1_ImageLoading(object sender, ImageLoadingEventArgs e)
        {
            progressBarImageLoading.Visible = true;
            toolStripStatusLabelLoadingImage.Visible = true;
            _imageLoadingStartTime = DateTime.Now;
        }

        /// <summary>
        /// Image loading in viewer is in progress.
        /// </summary>
        private void annotationViewer1_ImageLoadingProgress(object sender, ProgressEventArgs e)
        {
            if (_isFormClosing)
            {
                e.Cancel = true;
                return;
            }
            progressBarImageLoading.Value = e.Progress;
        }

        /// <summary>
        /// Image loading in viewer is finished.
        /// </summary>
        private void annotationViewer1_ImageLoaded(object sender, ImageLoadedEventArgs e)
        {
            _imageLoadingTime = DateTime.Now.Subtract(_imageLoadingStartTime);

            progressBarImageLoading.Visible = false;
            toolStripStatusLabelLoadingImage.Visible = false;


            //
            VintasoftImage image = annotationViewer1.Image;

            // show error message if not critical error occurs during image loading
            string imageLoadingErrorString = "";
            if (image.LoadingError)
                imageLoadingErrorString = string.Format("[{0}] ", image.LoadingErrorString);
            // show information about the image
            imageInfoStatusLabel.Text = string.Format("{0} Width={1}; Height={2}; PixelFormat={3}; Resolution={4}", imageLoadingErrorString, image.Width, image.Height, image.PixelFormat, image.Resolution);

            // if image loading time more than 0
            if (_imageLoadingTime != TimeSpan.Zero)
                // show information about image loading time
                imageInfoStatusLabel.Text = string.Format("[Loading time: {0}ms] {1}", _imageLoadingTime.TotalMilliseconds, imageInfoStatusLabel.Text);

            // if image has annotations
            if (image.Metadata.AnnotationsFormat != AnnotationsFormat.None)
                // show information about format of annotations
                imageInfoStatusLabel.Text = string.Format("[AnnotationsFormat: {0}] {1}", image.Metadata.AnnotationsFormat, imageInfoStatusLabel.Text);


            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Key is down in annotation viewer.
        /// </summary>
        private void annotationViewer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (deleteToolStripMenuItem.Enabled &&
                e.KeyCode == Keys.Delete &&
                e.Modifiers == Keys.None)
            {
                // delete the selected annotation from image
                DeleteAnnotation(false);

                // update the UI
                UpdateUI();
            }
            else if (annotationViewer1.Focused &&
                annotationViewer1.FocusedAnnotationView != null)
            {
                // get transformation from AnnotationViewer space to DIP space
                AffineMatrix matrix = annotationViewer1.GetTransformFromControlToDip();
                PointF deltaVector = PointFAffineTransform.TransformVector(matrix, new PointF(ANNOTATION_KEYBOARD_MOVE_DELTA, ANNOTATION_KEYBOARD_MOVE_DELTA));
                PointF resizeVector = PointFAffineTransform.TransformVector(matrix, new PointF(ANNOTATION_KEYBOARD_RESIZE_DELTA, ANNOTATION_KEYBOARD_RESIZE_DELTA));

                // current annotation properties 
                PointF location = annotationViewer1.FocusedAnnotationView.Location;
                SizeF size = annotationViewer1.FocusedAnnotationView.Size;

                switch (e.KeyData)
                {
                    case Keys.Up:
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X, location.Y - deltaVector.Y);
                        e.Handled = true;
                        break;
                    case Keys.Down:
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X, location.Y + deltaVector.Y);
                        e.Handled = true;
                        break;
                    case Keys.Right:
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X + deltaVector.X, location.Y);
                        e.Handled = true;
                        break;
                    case Keys.Left:
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X - deltaVector.X, location.Y);
                        e.Handled = true;
                        break;
                    case Keys.Add:
                        annotationViewer1.FocusedAnnotationView.Size = new SizeF(size.Width + resizeVector.X, size.Height + resizeVector.Y);
                        e.Handled = true;
                        break;
                    case Keys.Subtract:
                        if (size.Width > resizeVector.X)
                            annotationViewer1.FocusedAnnotationView.Size = new SizeF(size.Width - resizeVector.X, size.Height);

                        size = annotationViewer1.FocusedAnnotationView.Size;

                        if (size.Height > resizeVector.Y)
                            annotationViewer1.FocusedAnnotationView.Size = new SizeF(size.Width, size.Height - resizeVector.Y);
                        e.Handled = true;
                        break;
                }
                propertyGrid1.Refresh();
            }
        }

        /// <summary>
        /// Key is pressed in viewer.
        /// </summary>
        private void annotationViewer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if Enter key (13) pressed
            if (e.KeyChar == '\xD')
            {
                if (annotationViewer1.IsAnnotationBuilding)
                    annotationViewer1.FinishAnnotationBuilding();
            }
            // if ESC key (27) pressed
            else if (e.KeyChar == '\x1B')
            {
                if (annotationViewer1.IsAnnotationBuilding)
                    annotationViewer1.CancelAnnotationBuilding();
            }
        }

        /// <summary>
        /// Annotation interaction mode of viewer is changed.
        /// </summary>
        void annotationViewer1_AnnotationInteractionModeChanged(object sender, AnnotationInteractionModeChangedEventArgs e)
        {
            annotationInteractionModeNoneToolStripMenuItem.Checked = false;
            annotationInteractionModeViewToolStripMenuItem.Checked = false;
            annotationInteractionModeAuthorToolStripMenuItem.Checked = false;

            AnnotationInteractionMode annotationInteractionMode = e.NewValue;
            switch (annotationInteractionMode)
            {
                case AnnotationInteractionMode.None:
                    annotationInteractionModeNoneToolStripMenuItem.Checked = true;
                    break;

                case AnnotationInteractionMode.View:
                    annotationInteractionModeViewToolStripMenuItem.Checked = true;
                    break;

                case AnnotationInteractionMode.Author:
                    annotationInteractionModeAuthorToolStripMenuItem.Checked = true;
                    break;
            }

            annotationInteractionModeToolStripComboBox.SelectedItem = annotationInteractionMode;

            // update the UI
            UpdateUI();
        }

        #endregion


        #region Thumbnail viewer

        /// <summary>
        /// Loading of thumbnails is in progress.
        /// </summary>
        private void thumbnailViewer1_ThumbnailsLoadingProgress(object sender, ThumbnailsLoadingProgressEventArgs e)
        {
            actionLabel.Text = "Creating thumbnails:";
            progressBar1.Value = e.Progress;
            progressBar1.Visible = true;
            actionLabel.Visible = true;
            if (progressBar1.Value == 100)
            {
                progressBar1.Visible = false;
                actionLabel.Visible = false;
            }
        }

        #endregion


        #region Annotations's combobox AND annotation's property grid

        /// <summary>
        /// Fills combobox with information about annotations of image.
        /// </summary>
        private void FillAnnotationComboBox()
        {
            annotationComboBox.Items.Clear();

            if (annotationViewer1.FocusedIndex >= 0)
            {
                AnnotationDataCollection annotations = annotationViewer1.AnnotationDataController[annotationViewer1.FocusedIndex];
                for (int i = 0; i < annotations.Count; i++)
                {
                    annotationComboBox.Items.Add(string.Format("[{0}] {1}", i, annotations[i].GetType().Name));
                    if (annotationViewer1.FocusedAnnotationData == annotations[i])
                        annotationComboBox.SelectedIndex = i;
                }
            }
        }

        /// <summary>
        /// Shows information about annotation in property grid.
        /// </summary>
        private void ShowAnnotationProperties(AnnotationView annotation)
        {
            if (propertyGrid1.SelectedObject != annotation)
                propertyGrid1.SelectedObject = annotation;
            else if (!_isAnnotationTransforming)
                propertyGrid1.Refresh();
        }

        /// <summary>
        /// Handler of the DropDown event of the ComboBox of annotations.
        /// </summary>
        private void annotationComboBox_DropDown(object sender, EventArgs e)
        {
            FillAnnotationComboBox();
        }

        /// <summary>
        /// Selected annotation is changed using annotation's combobox.
        /// </summary>
        private void annotationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (annotationViewer1.FocusedIndex != -1 && annotationComboBox.SelectedIndex != -1)
            {
                annotationViewer1.FocusedAnnotationData = annotationViewer1.AnnotationDataCollection[annotationComboBox.SelectedIndex];
            }
        }

        void annotationViewer1_SelectedAnnotationChanged(object sender, AnnotationViewChangedEventArgs e)
        {
            FillAnnotationComboBox();
            ShowAnnotationProperties(annotationViewer1.FocusedAnnotationView);

            // update the UI
            UpdateUI();
        }

        void SelectedAnnotations_Changed(object sender, EventArgs e)
        {
            // update the UI
            UpdateUI();
        }

        #endregion


        #region File manipulation

        /// <summary>
        /// Opens stream of the image file and
        /// adds stream of image file to the image collection of image viewer - this allows
        /// to save modified multipage image files back to the source.
        /// </summary>
        private void OpenFile(string filename)
        {
            CloseSource();
            OpenSourceStream(filename);

            // add images of new file to image collection of image viewer asynchronously
            Thread openFileThread = new Thread(OpenFileAsynchronously);
            openFileThread.IsBackground = true;
            openFileThread.Start();
        }

        /// <summary>
        /// Adds images of new file to image collection of image viewer asynchronously.
        /// </summary>
        private void OpenFileAsynchronously()
        {
            try
            {
                annotationViewer1.Images.Add(_sourceFilename, _isFileReadOnlyMode);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
                Invoke(new CloseCurrentFileDelegate(CloseCurrentFile));
            }

            // update the UI
            InvokeUpdateUI();
        }

        /// <summary>
        /// Closes current image file.
        /// </summary>
        private void CloseCurrentFile()
        {
            this.Text = string.Format(_titlePrefix, "(Untitled)");
            annotationViewer1.Images.ClearAndDisposeItems();
            CloseSource();
        }

        /// <summary>
        /// Opens stream of the image file.
        /// </summary>
        private void OpenSourceStream(string filename)
        {
            _sourceFilename = Path.GetFullPath(filename);
            _isFileReadOnlyMode = false;
            Stream stream = null;
            try
            {
                stream = new FileStream(_sourceFilename, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
            if (stream == null)
            {
                _isFileReadOnlyMode = true;
            }
            else
            {
                stream.Close();
                stream.Dispose();
            }
        }

        /// <summary>
        /// Closes stream of the image file.
        /// </summary>
        private void CloseSource()
        {
            _sourceFilename = null;
        }

        #endregion


        #region Image manipulation

        /// <summary>
        /// Deletes selected images or focused image.
        /// </summary>
        private void DeleteImages()
        {
            // get an array of selected images
            int[] selectedIndices = thumbnailViewer1.SelectedIndices.ToArray();
            VintasoftImage[] selectedImages;
            // if selection is present
            if (selectedIndices.Length > 0)
            {
                selectedImages = new VintasoftImage[selectedIndices.Length];
                for (int i = 0; i < selectedIndices.Length; i++)
                    selectedImages[i] = thumbnailViewer1.Images[selectedIndices[i]];
            }
            // if selection is not present
            else
            {
                // if there is no focused image
                if (thumbnailViewer1.FocusedIndex == -1)
                    return;

                // if there is focused image
                selectedIndices = new int[1];
                selectedIndices[0] = annotationViewer1.FocusedIndex;
                selectedImages = new VintasoftImage[1];
                selectedImages[0] = annotationViewer1.Image;
            }

            // remove selected images from the image collection
            thumbnailViewer1.Images.RemoveRange(selectedIndices);

            // dispose selected images
            for (int i = 0; i < selectedImages.Length; i++)
                selectedImages[i].Dispose();
        }

        #endregion


        #region Annotation interaction mode

        /// <summary>
        /// Annotation interaction mode is changed using combobox.
        /// </summary>
        private void annotationInteractionModeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            annotationViewer1.AnnotationInteractionMode =
                (AnnotationInteractionMode)annotationInteractionModeToolStripComboBox.SelectedItem;

            EnableUndoRedoMenu();
            if (_historyForm != null)
                _historyForm.CanNavigateOnHistory = true;
        }

        #endregion


        #region Annotation

        /// <summary>
        /// AnnotationViewer.FocusedAnnotationViewChanged event handler.
        /// </summary>
        private void annotationViewer1_FocusedAnnotationViewChanged(
            object sender,
            AnnotationViewChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                AnnotationData oldValue = e.OldValue.Data;
                while (oldValue is CompositeAnnotationData)
                {
                    CompositeAnnotationData compositeData = (CompositeAnnotationData)oldValue;

                    if (compositeData is StickyNoteAnnotationData)
                    {
                        compositeData.PropertyChanged -= new EventHandler<ObjectPropertyChangedEventArgs>(compositeData_PropertyChanged);
                    }

                    foreach (AnnotationData data in compositeData)
                    {
                        oldValue = data;
                        break;
                    }
                }
                oldValue.PropertyChanged -= new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
            }
            if (e.NewValue != null)
            {
                AnnotationData newValue = e.NewValue.Data;
                while (newValue is CompositeAnnotationData)
                {
                    CompositeAnnotationData compositeData = (CompositeAnnotationData)newValue;

                    if (compositeData is StickyNoteAnnotationData)
                    {
                        compositeData.PropertyChanged += new EventHandler<ObjectPropertyChangedEventArgs>(compositeData_PropertyChanged);
                    }

                    foreach (AnnotationData data in compositeData)
                    {
                        newValue = data;
                        break;
                    }
                }
                newValue.PropertyChanged += new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
                // store last focused annotation
                _focusedAnnotationData = newValue;
            }
        }

        /// <summary>
        /// AnnotationViewer.FocusedAnnotationView.PropertyChanged event handler.
        /// </summary>
        private void FocusedAnnotationData_PropertyChanged(
            object sender,
            ObjectPropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Location" && annotationViewer1.SelectedAnnotations.Count > 1)
            {
                AnnotationView focusedView = annotationViewer1.AnnotationVisualTool.FocusedAnnotationView;
                if (focusedView != null && focusedView.InteractionController != null)
                {
                    InteractionArea focusedArea = focusedView.InteractionController.FocusedInteractionArea;
                    if (focusedArea != null && focusedArea.InteractionName == "Move")
                    {
                        System.Drawing.PointF oldValue = (System.Drawing.PointF)e.OldValue;
                        System.Drawing.PointF newValue = (System.Drawing.PointF)e.NewValue;
                        System.Drawing.PointF locationDelta = new System.Drawing.PointF(newValue.X - oldValue.X, newValue.Y - oldValue.Y);
                        AnnotationData[] annotations = new AnnotationData[annotationViewer1.SelectedAnnotations.Count];
                        for (int i = 0; i < annotationViewer1.SelectedAnnotations.Count; i++)
                            annotations[i] = annotationViewer1.SelectedAnnotations[i].Data;
                        AnnotationDemosTools.ChangeAnnotationsLocation(locationDelta, annotations, (AnnotationData)sender);
                    }
                }
            }
        }

        private void compositeData_PropertyChanged(object sender, ObjectPropertyChangedEventArgs e)
        {
            StickyNoteAnnotationData stickyNote = sender as StickyNoteAnnotationData;
            if (stickyNote != null)
            {
                if (e.PropertyName == "CollapsedType" || e.PropertyName == "IsCollapsed")
                {
                    if (_focusedAnnotationData != null)
                    {
                        _focusedAnnotationData.PropertyChanged -= new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
                    }

                    foreach (AnnotationData data in stickyNote)
                    {
                        _focusedAnnotationData = data;
                        _focusedAnnotationData.PropertyChanged += new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Begins initialization of the specified annotation.
        /// </summary>
        private void BeginInit(AnnotationData annotation)
        {
            if (!_initializedAnnotations.Contains(annotation))
            {
                _initializedAnnotations.Add(annotation);
                annotation.BeginInit();
            }
        }

        /// <summary>
        /// Ends initialization of the specified annotation.
        /// </summary>
        private void EndInit(AnnotationData annotation)
        {
            if (_initializedAnnotations.Contains(annotation))
            {
                _initializedAnnotations.Remove(annotation);
                annotation.EndInit();
            }
        }

        /// <summary>
        /// Annotation transforming is started.
        /// </summary>
        private void annotationViewer1_AnnotationTransformingStarted(
            object sender,
            AnnotationViewEventArgs e)
        {
            _isAnnotationTransforming = true;

            // if annotation transformation is NOT shown in the thumbnail viewer
            if (!showAnnotationTransformationOnThumbnailToolStripMenuItem.Checked)
            {
                // begin the initialization of annotation
                BeginInit(e.AnnotationView.Data);
                // for each view of annotation
                foreach (AnnotationView view in annotationViewer1.SelectedAnnotations)
                    // begin the initialization of annotation view
                    BeginInit(view.Data);
            }
        }

        /// <summary>
        /// Annotation transforming is finished.
        /// </summary>
        private void annotationViewer1_AnnotationTransformingFinished(
            object sender,
            AnnotationViewEventArgs e)
        {
            _isAnnotationTransforming = false;

            // end the initialization of annotation
            EndInit(e.AnnotationView.Data);
            // for each view of annotation
            foreach (AnnotationView view in annotationViewer1.SelectedAnnotations)
                // end the initialization of annotation view
                EndInit(view.Data);

            // refresh the property grid
            propertyGrid1.Refresh();
        }

        /// <summary>
        /// Deletes the selected annotation or all annotations from image.
        /// </summary>
        /// <param name="deleteAll">Determines that all annotations must be deleted from image.</param>
        private void DeleteAnnotation(bool deleteAll)
        {
            annotationViewer1.CancelAnnotationBuilding();

            // get UI action
            UIAction deleteUIAction = null;
            if (deleteAll)
                deleteUIAction = GetUIAction<DeleteAllItemsUIAction>(annotationViewer1.VisualTool);
            else
                deleteUIAction = GetUIAction<DeleteItemUIAction>(annotationViewer1.VisualTool);

            // if UI action is not empty  AND UI action is enabled
            if (deleteUIAction != null && deleteUIAction.IsEnabled)
            {
                string actionName = "AnnotationViewCollection: Delete";
                if (deleteAll)
                    actionName = actionName + " All";
                _undoManager.BeginCompositeAction(actionName);

                try
                {
                    deleteUIAction.Execute();
                }
                finally
                {
                    _undoManager.EndCompositeAction();
                }
            }

            UpdateUI();
        }

        /// <summary>
        /// Changed the interaction controller of annotation tool.
        /// </summary>
        void AnnotationVisualTool_ActiveInteractionControllerChanged(
            object sender,
            PropertyChangedEventArgs<IInteractionController> e)
        {
            TextObjectTextBoxTransformer oldTextObjectTextBoxTransformer = GetTextObjectTextBoxTransformer(e.OldValue);
            if (oldTextObjectTextBoxTransformer != null)
            {
                oldTextObjectTextBoxTransformer.TextBoxShown -= TextObjectTextBoxTransformer_TextBoxShown;
                oldTextObjectTextBoxTransformer.TextBoxClosed -= TextObjectTextBoxTransformer_TextBoxClosed;
            }

            TextObjectTextBoxTransformer newTextObjectTextBoxTransformer = GetTextObjectTextBoxTransformer(e.NewValue);
            if (newTextObjectTextBoxTransformer != null)
            {
                newTextObjectTextBoxTransformer.TextBoxShown +=
                    new EventHandler<TextObjectTextBoxTransformerEventArgs>(TextObjectTextBoxTransformer_TextBoxShown);
                newTextObjectTextBoxTransformer.TextBoxClosed +=
                    new EventHandler<TextObjectTextBoxTransformerEventArgs>(TextObjectTextBoxTransformer_TextBoxClosed);
            }
        }

        /// <summary>
        /// Returns the <see cref="Vintasoft.Imaging.UI.VisualTools.UserInteraction.TextObjectTextBoxTransformer"/>
        /// from <see cref="IInteractionController"/>.
        /// </summary>
        /// <param name="controller">The controller.</param>
        private TextObjectTextBoxTransformer GetTextObjectTextBoxTransformer(
            IInteractionController controller)
        {
            if (controller is TextObjectTextBoxTransformer)
                return (TextObjectTextBoxTransformer)controller;

            if (controller is CompositeInteractionController)
            {
                CompositeInteractionController compositeInteractionController = (CompositeInteractionController)controller;

                foreach (IInteractionController item in compositeInteractionController.Items)
                {
                    TextObjectTextBoxTransformer transformer = GetTextObjectTextBoxTransformer(item);
                    if (transformer != null)
                        return transformer;
                }
            }

            return null;
        }

        /// <summary>
        /// Text box of focused annotation is shown.
        /// </summary>
        private void TextObjectTextBoxTransformer_TextBoxShown(object sender, TextObjectTextBoxTransformerEventArgs e)
        {
            cutToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Text box of focused annotation is closed.
        /// </summary>
        private void TextObjectTextBoxTransformer_TextBoxClosed(object sender, TextObjectTextBoxTransformerEventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Annotation building is started.
        /// </summary>
        private void annotationViewer1_AnnotationBuildingStarted(object sender, AnnotationViewEventArgs e)
        {
            annotationComboBox.Enabled = false;

            DisableUndoRedoMenu();
            if (_historyForm != null)
                _historyForm.CanNavigateOnHistory = false;
        }

        /// <summary>
        /// Annotation building is canceled.
        /// </summary>
        private void annotationViewer1_AnnotationBuildingCanceled(object sender, AnnotationViewEventArgs e)
        {
            annotationComboBox.Enabled = true;

            EnableUndoRedoMenu();
            if (_historyForm != null)
                _historyForm.CanNavigateOnHistory = true;
        }

        /// <summary>
        /// Annotation building is finished.
        /// </summary>
        private void annotationViewer1_AnnotationBuildingFinished(object sender, AnnotationViewEventArgs e)
        {
            bool isBuildingFinished = true;

            if (annotationsToolStrip1.NeedBuildAnnotationsContinuously)
            {
                if (annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                    isBuildingFinished = false;
            }

            if (isBuildingFinished)
            {
                annotationComboBox.Enabled = true;

                EnableUndoRedoMenu();
                if (_historyForm != null)
                    _historyForm.CanNavigateOnHistory = true;
            }
        }

        #endregion


        #region Annotation undo manager

        /// <summary>
        /// Updates the "Undo/Redo" menu.
        /// </summary>
        private void UpdateUndoRedoMenu(UndoManager undoManager)
        {
            bool canUndo = false;
            bool canRedo = false;

            if (undoManager != null && undoManager.IsEnabled)
            {
                if (!annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                {
                    canUndo = undoManager.UndoCount > 0;
                    canRedo = undoManager.RedoCount > 0;
                }
            }


            string undoMenuItemText = "Undo";
            if (canUndo)
                undoMenuItemText = string.Format("Undo {0}", undoManager.UndoDescription).Trim();

            undoToolStripMenuItem.Enabled = canUndo;
            undoToolStripMenuItem.Text = undoMenuItemText;


            string redoMenuItemText = "Redo";
            if (canRedo)
                redoMenuItemText = string.Format("Redo {0}", undoManager.RedoDescription).Trim();

            redoToolStripMenuItem.Enabled = canRedo;
            redoToolStripMenuItem.Text = redoMenuItemText;
        }

        /// <summary>
        /// Enables the undo redo menu.
        /// </summary>
        private void EnableUndoRedoMenu()
        {
            UpdateUndoRedoMenu(_undoManager);
            undoRedoSettingsToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Disables the undo redo menu.
        /// </summary>
        private void DisableUndoRedoMenu()
        {
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;
            undoRedoSettingsToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Annotation undo manager is changed.
        /// </summary>
        private void annotationUndoManager_Changed(object sender, UndoManagerChangedEventArgs e)
        {
            UpdateUndoRedoMenu((UndoManager)sender);
        }

        /// <summary>
        /// Annotation undo manager is navigated.
        /// </summary>
        private void annotationUndoManager_Navigated(object sender, UndoManagerNavigatedEventArgs e)
        {
            UpdateUndoRedoMenu((UndoManager)sender);
            UpdateUI();
        }

        /// <summary>
        /// "Annotation history" menu is clicked.
        /// </summary>
        private void annotationHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyDialogToolStripMenuItem.Checked ^= true;

            if (historyDialogToolStripMenuItem.Checked)
                // show the image processing history form
                ShowHistoryForm();
            else
                // close the image processing history form
                CloseHistoryForm();
        }

        /// <summary>
        /// Shows the history form.
        /// </summary>
        private void ShowHistoryForm()
        {
            if (annotationViewer1.Image == null)
                return;

            _historyForm = new UndoManagerHistoryForm(this, _undoManager);
            _historyForm.CanNavigateOnHistory = !annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding;
            _historyForm.FormClosed += new FormClosedEventHandler(historyForm_FormClosed);
            _historyForm.Show();
        }

        /// <summary>
        /// Closes the history form.
        /// </summary>
        private void CloseHistoryForm()
        {
            if (_historyForm != null)
                _historyForm.Close();
        }

        /// <summary>
        /// History form is closed.
        /// </summary>
        private void historyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            historyDialogToolStripMenuItem.Checked = false;
            _historyForm = null;
        }

        #endregion


        #region Save image(s)

        /// <summary>
        /// Saves image collection with annotations to the first source of image collection,
        /// i.e. saves modified image collection with annotations back to the source file.
        /// </summary>
        private void SaveImageCollectionToSourceFile()
        {
            // cancel annotation building
            annotationViewer1.CancelAnnotationBuilding();

            // if focused image is NOT correct
            if (!AnnotationDemosTools.CheckImage(annotationViewer1))
                return;

            EncoderBase encoder = null;
            try
            {
                // specify that image file saving is started
                IsFileSaving = true;

                // if image collection contains several images
                if (annotationViewer1.Images.Count > 1)
                    // get multipage encoder
                    encoder = GetMultipageEncoder(_sourceFilename, true, false);
                // if image collection contains single image
                else
                    // get single- or multipage encoder
                    encoder = GetEncoder(_sourceFilename, true);
                // if encoder is found
                if (encoder != null)
                {
                    encoder.SaveAndSwitchSource = true;

                    // save image collection to a file
                    annotationViewer1.Images.SaveAsync(_sourceFilename, encoder);
                }
                // if encoder is NOT found
                else
                    // open save file dialog and save image collection to the new multipage image file
                    SaveImageCollectionToMultipageImageFile(true);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
            finally
            {
                // specify that image file saving is finished
                IsFileSaving = false;
            }
        }

        /// <summary>
        /// Opens the save file dialog and saves image collection to the new multipage image file.
        /// </summary>
        private void SaveImageCollectionToMultipageImageFile(bool saveAs)
        {
            // cancel annotation building
            annotationViewer1.CancelAnnotationBuilding();

            // if focused image is NOT correct
            if (!AnnotationDemosTools.CheckImage(annotationViewer1))
                return;

            // specify that image file saving is started
            IsFileSaving = true;

            bool multipage = annotationViewer1.Images.Count > 1;

            // set file filters in file saving dialog
            CodecsFileFilters.SetFiltersWithAnnotations(saveFileDialog1, multipage);
            // show the file saving dialog
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EncoderBase encoder = null;
                try
                {
                    string saveFilename = Path.GetFullPath(saveFileDialog1.FileName);
                    // if multiple images must be saved
                    if (multipage)
                        // get image encoder for multi page image file
                        encoder = GetMultipageEncoder(saveFilename, true, saveAs);
                    // if single image must be saved
                    else
                        // get image encoder for single page image file
                        encoder = GetEncoder(saveFilename, true);
                    // if encoder is found
                    if (encoder != null)
                    {
                        if (saveAs)
                            _saveFilename = saveFilename;
                        encoder.SaveAndSwitchSource = saveAs;

                        // save images to an image file
                        annotationViewer1.Images.SaveAsync(saveFilename, encoder);
                    }
                    else
                        DemosTools.ShowErrorMessage("Image encoder is not found.");
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                    // specify that image file saving is finished
                    IsFileSaving = false;
                }
                if (!saveAs)
                    // specify that image file saving is finished
                    IsFileSaving = false;
            }
            else
            {
                // specify that image file saving is finished
                IsFileSaving = false;
            }
        }

        /// <summary>
        /// Opens the save file dialog and saves focused image to the new image file.
        /// </summary>
        private void SaveFocusedImageToNewImageFile()
        {
            // cancel annotation building
            annotationViewer1.CancelAnnotationBuilding();

            // if focused image is NOT correct
            if (!AnnotationDemosTools.CheckImage(annotationViewer1))
                return;

            // specify that image file saving is started
            IsFileSaving = true;

            // set file filters in file saving dialog
            CodecsFileFilters.SetFiltersWithAnnotations(saveFileDialog1, false);
            saveFileDialog1.FileName = "";
            // show the file saving dialog
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string fileName = Path.GetFullPath(saveFileDialog1.FileName);
                    // set encoder parameters, if necessary
                    EncoderBase encoder = GetEncoder(fileName, true);
                    // if encoder is found
                    if (encoder != null)
                    {
                        encoder.SaveAndSwitchSource = false;

                        // save images to an image file
                        annotationViewer1.Image.Save(fileName, encoder, SavingProgress);
                    }
                    else
                        DemosTools.ShowErrorMessage("Image encoder is not found.");
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }

            // specify that image file saving is finished
            IsFileSaving = false;
        }


        /// <summary>
        /// Returns the encoder for saving of single image.
        /// </summary>
        private EncoderBase GetEncoder(string filename, bool showSettingsDialog)
        {
            // get multipage encoder
            MultipageEncoderBase multipageEncoder = GetMultipageEncoder(filename, showSettingsDialog, false);
            // if multipage encoder is found
            if (multipageEncoder != null)
                // return multipage encoder
                return multipageEncoder;

            switch (Path.GetExtension(filename).ToUpperInvariant())
            {
                case ".JPG":
                case ".JPEG":
                    JpegEncoder jpegEncoder = new JpegEncoder();

                    if (showSettingsDialog)
                    {
                        jpegEncoder.Settings.AnnotationsFormat = AnnotationsFormat.VintasoftBinary;

                        JpegEncoderSettingsForm jpegEncoderSettingsDlg = new JpegEncoderSettingsForm();
                        jpegEncoderSettingsDlg.EditAnnotationSettings = true;
                        jpegEncoderSettingsDlg.EncoderSettings = jpegEncoder.Settings;
                        if (jpegEncoderSettingsDlg.ShowDialog() != DialogResult.OK)
                            throw new Exception("Saving canceled.");
                    }

                    return jpegEncoder;

                case ".PNG":
                    PngEncoder pngEncoder = new PngEncoder();

                    if (showSettingsDialog)
                    {
                        pngEncoder.Settings.AnnotationsFormat = AnnotationsFormat.VintasoftBinary;

                        PngEncoderSettingsForm pngEncoderSettingsDlg = new PngEncoderSettingsForm();
                        pngEncoderSettingsDlg.EditAnnotationSettings = true;
                        pngEncoderSettingsDlg.EncoderSettings = pngEncoder.Settings;
                        if (pngEncoderSettingsDlg.ShowDialog() != DialogResult.OK)
                            throw new Exception("Saving canceled.");
                    }

                    return pngEncoder;

                // if annotations are not supported
                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns the multipage encoder for saving of image collection.
        /// </summary>
        private MultipageEncoderBase GetMultipageEncoder(
            string filename,
            bool showSettingsDialog,
            bool switchTo)
        {
            bool isFileExist = File.Exists(filename) && !switchTo;
            switch (Path.GetExtension(filename).ToUpperInvariant())
            {
#if !REMOVE_PDF_PLUGIN
                case ".PDF":
                    IPdfEncoder pdfEncoder = (IPdfEncoder)AvailableEncoders.CreateEncoderByName("Pdf");

                    if (showSettingsDialog)
                    {
                        pdfEncoder.Settings.AnnotationsFormat = AnnotationsFormat.VintasoftBinary;

                        PdfEncoderSettingsForm pdfEncoderSettingsDlg = new PdfEncoderSettingsForm();
                        pdfEncoderSettingsDlg.AppendExistingDocumentEnabled = isFileExist;
                        pdfEncoderSettingsDlg.CanEditAnnotationSettings = true;
                        pdfEncoderSettingsDlg.EncoderSettings = pdfEncoder.Settings;
                        if (pdfEncoderSettingsDlg.ShowDialog() != DialogResult.OK)
                            throw new Exception("Saving canceled.");
                    }

                    return (MultipageEncoderBase)pdfEncoder;
#endif

                case ".TIF":
                case ".TIFF":
                    TiffEncoder tiffEncoder = new TiffEncoder();

                    if (showSettingsDialog)
                    {
                        tiffEncoder.Settings.AnnotationsFormat = AnnotationsFormat.VintasoftBinary;

                        TiffEncoderSettingsForm tiffEncoderSettingsDlg = new TiffEncoderSettingsForm();
                        tiffEncoderSettingsDlg.CanAddImagesToExistingFile = isFileExist;
                        tiffEncoderSettingsDlg.EditAnnotationSettings = true;
                        tiffEncoderSettingsDlg.EncoderSettings = tiffEncoder.Settings;
                        if (tiffEncoderSettingsDlg.ShowDialog() != DialogResult.OK)
                            throw new Exception("Saving canceled.");
                    }

                    return tiffEncoder;
            }

            return null;
        }

        /// <summary>
        /// Image collection saving is in-progress.
        /// </summary>
        private void SavingProgress(object sender, ProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new SavingProgressDelegate(SavingProgress), sender, e);
            }
            else
            {
                actionLabel.Text = "Saving:";
                progressBar1.Value = e.Progress;
                progressBar1.Visible = e.Progress != 100;
                actionLabel.Visible = true;
            }
        }

        /// <summary>
        /// Image collection is saved.
        /// </summary>
        private void images_ImageCollectionSavingFinished(object sender, EventArgs e)
        {
            if (_saveFilename != null)
            {
                CloseSource();
                _sourceFilename = _saveFilename;
                _saveFilename = null;
                _isFileReadOnlyMode = false;
            }

            IsFileSaving = false;
        }

        /// <summary>
        /// Image saving error occurs.
        /// </summary>
        private void Images_ImageSavingException(object sender, ExceptionEventArgs e)
        {
            DemosTools.ShowErrorMessage(e.Exception);
        }

        #endregion

        #endregion



        #region Delegates

        private delegate void UpdateUIDelegate();

        private delegate void CloseCurrentFileDelegate();

        private delegate void SavingProgressDelegate(object sender, ProgressEventArgs e);

        #endregion

    }
}
