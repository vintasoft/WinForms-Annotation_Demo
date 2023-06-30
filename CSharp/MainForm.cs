using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Vintasoft.Data;
using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Encoders;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.Print;
using Vintasoft.Imaging.Spelling;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UIActions;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Undo;

using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.Formatters;
using Vintasoft.Imaging.Annotation.Comments;
#if REMOVE_PDF_PLUGIN
using Vintasoft.Imaging.Annotation.Print;
#else
using Vintasoft.Imaging.Annotation.Pdf.Print;
#endif
using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Annotation.UI.Comments;
using Vintasoft.Imaging.Annotation.UI.VisualTools;

using DemosCommonCode;
using DemosCommonCode.Annotation;
using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Imaging.Codecs.Dialogs;
using DemosCommonCode.Imaging.ColorManagement;
using DemosCommonCode.Spelling;

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

        /// <summary>
        /// The comment visual tool.
        /// </summary>
        CommentVisualTool _commentVisualTool;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // load assemblies
            Jbig2AssemblyLoader.Load();
            Jpeg2000AssemblyLoader.Load();
            DicomAssemblyLoader.Load();
            PdfAnnotationsAssemblyLoader.Load();

            // register type editors
            ImagingTypeEditorRegistrator.Register();
            AnnotationTypeEditorRegistrator.Register();

#if !REMOVE_OFFICE_PLUGIN
            AnnotationOfficeUIAssembly.Init();

            DemosCommonCode.Office.OfficeDocumentVisualEditorForm documentVisualEditorForm = new DemosCommonCode.Office.OfficeDocumentVisualEditorForm();
            documentVisualEditorForm.Owner = this;
            documentVisualEditorForm.AddVisualTool(annotationViewer1.AnnotationVisualTool);
#endif

            // set CustomFontProgramsController for all opened documents
            CustomFontProgramsController.SetDefaultFontProgramsController();

            annotationViewer1.AnnotationVisualTool.ChangeFocusedItemBeforeInteraction = true;

            InitializeAddAnnotationMenuItems();

            // init "View => Image Display Mode" menu
            singlePageToolStripMenuItem.Tag = ImageViewerDisplayMode.SinglePage;
            twoColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoColumns;
            singleContinuousRowToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousRow;
            singleContinuousColumnToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousColumn;
            twoContinuousRowsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousRows;
            twoContinuousColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousColumns;

            // create comment controllers
            AnnotationCommentController annotationCommentController = new AnnotationCommentController(annotationViewer1.AnnotationDataController);
            ImageViewerCommentController imageViewerCommentsController = new ImageViewerCommentController(annotationCommentController);

            // create comment visual tool
            _commentVisualTool = new CommentVisualTool(imageViewerCommentsController, new CommentControlFactory());
            commentsControl1.ImageViewer = annotationViewer1;
            commentsControl1.CommentTool = _commentVisualTool;
            commentsControl1.AnnotationTool = annotationViewer1.AnnotationVisualTool;

            // add comment visual tool to the annotation viewer
            annotationViewer1.VisualTool = new CompositeVisualTool(
                _commentVisualTool,
#if !REMOVE_OFFICE_PLUGIN
               new Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction.OfficeDocumentVisualEditorTextTool(),
#endif
                annotationViewer1.VisualTool);
            visualToolsToolStrip1.MandatoryVisualTool = annotationViewer1.VisualTool;
            visualToolsToolStrip1.ImageViewer = annotationViewer1;

            // "None" action of visual tools tool strip
            NoneAction noneAction = visualToolsToolStrip1.FindAction<NoneAction>();
            noneAction.Activated += NoneAction_Activated;
            noneAction.Deactivated += NoneAction_Deactivated;

            // initialize annotation tool strip
            annotationsToolStrip1.AnnotationViewer = annotationViewer1;
            annotationsToolStrip1.CommentBuilder = new AnnotationCommentBuilder(_commentVisualTool, annotationViewer1.AnnotationVisualTool);
            annotationViewer1.MouseMove += new MouseEventHandler(annotationViewer1_MouseMove);

            // create interaction area appearance manager
            _interactionAreaAppearanceManager = new AnnotationInteractionAreaAppearanceManager();
            _interactionAreaAppearanceManager.VisualTool = annotationViewer1.AnnotationVisualTool;
            // create spell check manager
            annotationViewer1.AnnotationVisualTool.SpellChecker = SpellCheckTools.CreateSpellCheckManager();

            CloseCurrentFile();
            // set path to demo images folder to filde dialog
            DemosTools.SetTestFilesFolder(openFileDialog1);

            // subscribe to the annotation viewer events
            annotationViewer1.KeyPress += new KeyPressEventHandler(annotationViewer1_KeyPress);
            annotationViewer1.FocusedAnnotationViewChanged += new EventHandler<AnnotationViewChangedEventArgs>(annotationViewer1_SelectedAnnotationChanged);
            annotationViewer1.SelectedAnnotations.Changed += new EventHandler(SelectedAnnotations_Changed);
            annotationViewer1.AnnotationInteractionModeChanged += new EventHandler<AnnotationInteractionModeChangedEventArgs>(annotationViewer1_AnnotationInteractionModeChanged);
            annotationViewer1.AnnotationVisualTool.ActiveInteractionControllerChanged += new PropertyChangedEventHandler<IInteractionController>(AnnotationVisualTool_ActiveInteractionControllerChanged);
            annotationViewer1.AutoScrollPositionExChanging += new PropertyChangingEventHandler<PointF>(annotationViewer1_AutoScrollPositionExChanging);
            annotationViewer1.AnnotationBuildingStarted += new EventHandler<AnnotationViewEventArgs>(annotationViewer1_AnnotationBuildingStarted);
            annotationViewer1.AnnotationBuildingFinished += new EventHandler<AnnotationViewEventArgs>(annotationViewer1_AnnotationBuildingFinished);
            annotationViewer1.AnnotationBuildingCanceled += new EventHandler<AnnotationViewEventArgs>(annotationViewer1_AnnotationBuildingCanceled);
            // subscribe to the image collection events
            annotationViewer1.Images.ImageCollectionChanged += new EventHandler<ImageCollectionChangeEventArgs>(annotationViewer1_Images_ImageCollectionChanged);
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

            // initialize the annotation interaction mode tool strip
            annotationInteractionModeToolStripComboBox.Items.Add(AnnotationInteractionMode.None);
            annotationInteractionModeToolStripComboBox.Items.Add(AnnotationInteractionMode.View);
            annotationInteractionModeToolStripComboBox.Items.Add(AnnotationInteractionMode.Author);
            // set interaction mode to the Author 
            annotationInteractionModeToolStripComboBox.SelectedItem = AnnotationInteractionMode.Author;

            // create undo manager
            _undoManager = new CompositeUndoManager();
            _undoManager.UndoLevel = 100;
            _undoManager.IsEnabled = false;
            // subscribe to undo manager events
            _undoManager.Changed += new EventHandler<UndoManagerChangedEventArgs>(annotationUndoManager_Changed);
            _undoManager.Navigated += new EventHandler<UndoManagerNavigatedEventArgs>(annotationUndoManager_Navigated);

            // create annotation viewer undo monitor 
            _annotationViewerUndoMonitor = new CustomAnnotationViewerUndoMonitor(_undoManager, annotationViewer1);
            _annotationViewerUndoMonitor.ShowHistoryForDisplayedImages =
                showHistoryForDisplayedImagesToolStripMenuItem.Checked;

            // initialize color management in viewer
            ColorManagementHelper.EnableColorManagement(annotationViewer1);

            // update the UI
            UpdateUI();

            // subscribe visual tool exceptions
            DemosTools.CatchVisualToolExceptions(annotationViewer1);


            // register view for mark annotation data
            AnnotationViewFactory.RegisterViewForAnnotationData(
               typeof(MarkAnnotationData),
               typeof(MarkAnnotationView));
            // register view for triangle annotation data
            AnnotationViewFactory.RegisterViewForAnnotationData(
                typeof(TriangleAnnotationData),
                typeof(TriangleAnnotationView));

            annotationViewer1.AnnotationDataController.AnnotationDataDeserializationException +=
                new EventHandler<AnnotationDataDeserializationExceptionEventArgs>(AnnotationDataController_AnnotationDataDeserializationException);

            DocumentPasswordForm.EnableAuthentication(annotationViewer1);

            // define custom serialization binder for correct deserialization of TriangleAnnotation v6.1 and earlier
            AnnotationSerializationBinder.Current = new CustomAnnotationSerializationBinder();

            moveAnnotationsBetweenImagesToolStripMenuItem.Checked = annotationViewer1.CanMoveAnnotationsBetweenImages;

            // add visual tools to visual tools tool strip
            SelectionVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            MeasurementVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            ZoomVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            ImageProcessingVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            CustomVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
        }

        #endregion



        #region Properties

        bool _isFileOpening = false;
        /// <summary>
        /// Gets or sets a value indicating whether the file is opening.
        /// </summary>
        /// <value>
        /// <b>True</b> - the file is opening;
        /// <b>false</b> - the file is NOT opening.
        /// </value>
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
        /// <summary>
        /// Gets or sets a value indicating whether the file is saving.
        /// </summary>
        /// <value>
        /// <b>True</b> - the file is saving;
        /// <b>false</b> - the file is NOT saving.
        /// </value>
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

        #region PROTECTED

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// <b>true</b> if the character was processed by the control; otherwise, <b>false</b>.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // if annotation viewer is selected
            if (annotationViewer1.Focused && annotationViewer1.VisualTool != null)
            {
                // if annotation is not building
                if (!annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                {
                    // if selection must be moved to the next annotation
                    if (keyData == Keys.Tab)
                    {
                        // move selection
                        if (annotationViewer1.VisualTool.PerformNextItemSelection(true))
                            return true;
                    }
                    // if selection must be moved to the previous annotation
                    else if (keyData == (Keys.Shift | Keys.Tab))
                    {
                        // move selection
                        if (annotationViewer1.VisualTool.PerformNextItemSelection(false))
                            return true;
                    }
                }
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.Add))
            {
                RotateViewClockwise();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.Subtract))
            {
                RotateViewCounterClockwise();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion


        #region PRIVATE

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


        #region UI

        #region Main form

        /// <summary>
        /// Handles the Shown event of MainForm object.
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
                        // open file
                        OpenFile(appArgs[1]);
                    }
                    catch
                    {
                        CloseCurrentFile();
                    }
                }
                else
                {
                    // open files

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
        /// Handles the FormClosing event of MainForm object.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isFormClosing)
            {
                // the application form is closing
                _isFormClosing = true;

                // wait to file saving
                while (IsFileSaving)
                {
                    Application.DoEvents();
                    Thread.Sleep(1);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Handles the FormClosed event of MainForm object.
        /// </summary>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // close current file
            CloseCurrentFile();

            // remove unmanaged resources of annotation undo monitor
            _annotationViewerUndoMonitor.Dispose();
            _undoManager.Dispose();

            // if data storrage exist
            if (_dataStorage != null)
                // remove unmanager resources of data storage
                _dataStorage.Dispose();

            // remove unmanager resources of interaction area appearance manager
            _interactionAreaAppearanceManager.Dispose();

            AnnotationVisualTool annotationVisualTool = annotationViewer1.AnnotationVisualTool;
            // if spell checker is not removed
            if (annotationVisualTool.SpellChecker != null)
            {
                // remove unmanager resources of spell checker
                SpellCheckManager manager = annotationVisualTool.SpellChecker;
                annotationVisualTool.SpellChecker = null;
                SpellCheckTools.DisposeSpellCheckManagerAndEngines(manager);
            }
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Handles the Click event of OpenToolStripMenuItem object.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open file
            OpenFile();
        }

        /// <summary>
        /// Handles the OpenFile event of ViewerToolStrip object.
        /// </summary>
        private void viewerToolStrip_OpenFile(object sender, EventArgs e)
        {
            // open file
            OpenFile();
        }

        /// <summary>
        /// Handles the Click event of AddToolStripMenuItem object.
        /// </summary>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFileOpening = true;

            // set open file dialog filters
            CodecsFileFilters.SetOpenFileDialogFilter(openFileDialog1);
            // enable file dialog multi-select
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
        /// Handles the Click event of SaveCurrentImageToolStripMenuItem object.
        /// </summary>
        private void saveCurrentImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // save image collection to the source file
            SaveImageCollectionToSourceFile();
        }

        /// <summary>
        /// Handles the Click event of SaveAsToolStripMenuItem object.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // save image collection to a file
            SaveImageCollectionToMultipageImageFile(true);
        }

        /// <summary>
        /// Handles the SaveFile event of ViewerToolStrip object.
        /// </summary>
        private void viewerToolStrip_SaveFile(object sender, EventArgs e)
        {
            // save image collection to a file
            SaveImageCollectionToMultipageImageFile(true);
        }

        /// <summary>
        /// Handles the Click event of SaveToolStripMenuItem object.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // save image collection to a file
            SaveImageCollectionToMultipageImageFile(false);
        }

        /// <summary>
        /// Handles the Click event of CloseToolStripMenuItem object.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // close current file
            CloseCurrentFile();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of PrintToolStripMenuItem object.
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }

        /// <summary>
        /// Handles the Print event of ViewerToolStrip object.
        /// </summary>
        private void viewerToolStrip_Print(object sender, EventArgs e)
        {
            Print();
        }

        /// <summary>
        /// Handles the Click event of ExitToolStripMenuItem object.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exit application
            Application.Exit();
        }

        #endregion


        #region 'Edit' menu

        /// <summary>
        /// Handles the Click event of EnableUndoRedoToolStripMenuItem object.
        /// </summary>
        private void enableUndoRedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isUndoManagerEnabled = _undoManager.IsEnabled ^ true;

            // if undo manager must be disabled
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
        /// Handles the Click event of UndoToolStripMenuItem object.
        /// </summary>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if focused annotation is building
            if (annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                return;

            _undoManager.Undo(1);
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of RedoToolStripMenuItem object.
        /// </summary>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if focused annotation is building
            if (annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                return;

            _undoManager.Redo(1);
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of UndoRedoSettingsToolStripMenuItem object.
        /// </summary>
        private void undoRedoSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get data storage
            IDataStorage dataStorage = _dataStorage;

            // if data storage is composite
            if (dataStorage is CompositeDataStorage)
            {
                // get first data storage from composite data storage
                CompositeDataStorage compositeStorage = (CompositeDataStorage)dataStorage;
                dataStorage = compositeStorage.Storages[0];
            }

            // create undo manager settings dialog
            using (UndoManagerSettingsForm dlg = new UndoManagerSettingsForm(_undoManager, dataStorage))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Owner = this;

                // if dialog is success
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // if data data storage must be changed
                    if (dlg.DataStorage != dataStorage)
                    {
                        // get previous data storage
                        IDataStorage prevDataStorage = _dataStorage;

                        // if the current storage can only store images
                        if (dlg.DataStorage is CompressedImageStorage)
                        {
                            // create storage fom clonable objects
                            _dataStorage = new CompositeDataStorage(
                                dlg.DataStorage,
                                new CloneableObjectStorageInMemory());
                        }
                        else
                        {
                            _dataStorage = dlg.DataStorage;
                        }

                        // remove history
                        _undoManager.Clear();
                        // update data storage
                        _undoManager.DataStorage = _dataStorage;
                        _annotationViewerUndoMonitor.DataStorage = _dataStorage;

                        // if previous data storage must be removed
                        if (prevDataStorage != null)
                            prevDataStorage.Dispose();
                    }

                    // update undo manager menu
                    UpdateUndoRedoMenu(_undoManager);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of ShowHistoryForDisplayedImagesToolStripMenuItem object.
        /// </summary>
        private void showHistoryForDisplayedImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if undo manager is enabled
            if (showHistoryForDisplayedImagesToolStripMenuItem.Checked)
            {
                // disable undo manager

                showHistoryForDisplayedImagesToolStripMenuItem.Checked = false;
                _annotationViewerUndoMonitor.ShowHistoryForDisplayedImages = false;
            }
            else
            {
                // enable undo manager

                showHistoryForDisplayedImagesToolStripMenuItem.Checked = true;
                _annotationViewerUndoMonitor.ShowHistoryForDisplayedImages = true;
            }
        }

        #endregion


        #region 'View' menu

        /// <summary>
        /// Handles the Click event of ImageDisplayMode object.
        /// </summary>
        private void ImageDisplayMode_Click(object sender, EventArgs e)
        {
            // get current tool strip menu item
            ToolStripMenuItem imageDisplayModeMenuItem = (ToolStripMenuItem)sender;
            // update image viewer display mode
            annotationViewer1.DisplayMode = (ImageViewerDisplayMode)imageDisplayModeMenuItem.Tag;
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of ThumbnailViewerSettingsToolStripMenuItem object.
        /// </summary>
        private void thumbnailViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create thumbnail viewer settings forms
            using (ThumbnailViewerSettingsForm viewerSettingsDialog = new ThumbnailViewerSettingsForm(thumbnailViewer1))
            {
                viewerSettingsDialog.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of BoundAnnotationsToolStripMenuItem object.
        /// </summary>
        private void boundAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // enable/disable the ability to restrict annotation transformation in annotation bounding rect
            annotationViewer1.IsAnnotationBoundingRectEnabled = boundAnnotationsToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of MoveAnnotationsBetweenImagesToolStripMenuItem object.
        /// </summary>
        private void moveAnnotationsBetweenImagesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // enable/disable the ability to move annotations between images
            annotationViewer1.CanMoveAnnotationsBetweenImages = moveAnnotationsBetweenImagesToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the Click event of RotateClockwiseToolStripMenuItem object.
        /// </summary>
        private void rotateClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewClockwise();
        }

        /// <summary>
        /// Handles the Click event of RotateCounterclockwiseToolStripMenuItem object.
        /// </summary>
        private void rotateCounterclockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewCounterClockwise();
        }

        /// <summary>
        /// Handles the Click event of AnnotationViewerSettingsToolStripMenuItem object.
        /// </summary>
        private void annotationViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create image viewer settings form
            using (ImageViewerSettingsForm viewerSettingsDialog = new ImageViewerSettingsForm(annotationViewer1))
            {
                viewerSettingsDialog.ShowDialog();
                UpdateUI();
            }
        }

        /// <summary>
        /// Handles the Click event of ImageSizeMode object.
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
        /// Handles the Click event of ShowEventsLogToolStripMenuItem object.
        /// </summary>
        private void showEventsLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // update user interface

            showEventsLogToolStripMenuItem.Checked = !showEventsLogToolStripMenuItem.Checked;
            splitContainer4.Panel2Collapsed = !showEventsLogToolStripMenuItem.Checked;

            // if annotation logger does NOT exist
            if (_annotationLogger == null)
                // create annotation logger
                _annotationLogger = new AnnotationsLogger(annotationViewer1, annotationEventsLog);

            // enable/disable the annotation logger
            _annotationLogger.IsEnabled = showEventsLogToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the Click event of InteractionPointsAppearanceToolStripMenuItem object.
        /// </summary>
        private void interactionPointsAppearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create  interaction area appearance manager form
            using (InteractionAreaAppearanceManagerForm dialog = new InteractionAreaAppearanceManagerForm())
            {
                dialog.InteractionAreaSettings = _interactionAreaAppearanceManager;
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of ColorManagementToolStripMenuItem object.
        /// </summary>
        private void colorManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show color manager edit form
            ColorManagementSettingsForm.EditColorManagement(annotationViewer1);
        }

        /// <summary>
        /// Handles the Click event of SpellCheckSettingsToolStripMenuItem object.
        /// </summary>
        private void spellCheckSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create spell check manager setting form
            using (SpellCheckManagerSettingsForm dialog = new SpellCheckManagerSettingsForm(
                annotationViewer1.AnnotationVisualTool.SpellChecker))
            {
                dialog.Owner = this;

                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of SpellCheckViewSettingsToolStripMenuItem object.
        /// </summary>
        private void spellCheckViewSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create spell check manager view setting form
            using (SpellCheckManagerViewSettingsForm dialog = new SpellCheckManagerViewSettingsForm())
            {
                dialog.InteractionAreaSettings = _interactionAreaAppearanceManager;
                dialog.ShowDialog();
            }
        }

        #endregion


        #region 'Annotation' menu

        /// <summary>
        /// Handles the DropDownOpening event of AnnotationsToolStripMenuItem object.
        /// </summary>
        private void annotationsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            // if annotation viewer has the focused annotation AND focused annotation is line-based annotation
            if (annotationViewer1.FocusedAnnotationView != null && annotationViewer1.FocusedAnnotationView is LineAnnotationViewBase)
            {
                // enable transformation mode tool strip menu items
                SetIsEnabled(transformationModeToolStripMenuItem, true);
                // update transformation menu items
                UpdateTransformationMenu();
            }
            else
            {
                // disable transformation mode tool strip menu items
                SetIsEnabled(transformationModeToolStripMenuItem, false);
            }

            UpdateEditMenuItems();
        }

        /// <summary>
        /// Handles the DropDownClosed event of AnnotationsToolStripMenuItem object.
        /// </summary>
        private void annotationsToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            // enable the items of edit menu
            EnableEditMenuItems();
        }

        /// <summary>
        /// Handles the Click event of AnnotationsInfoToolStripMenuItem object.
        /// </summary>
        private void annotationsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create annotation information form
            using (AnnotationsInfoForm annotationInformationForm = new AnnotationsInfoForm(annotationViewer1.AnnotationDataController))
            {
                annotationInformationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of AddAnnotationToolStripMenuItem object.
        /// </summary>
        private void addAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnotationType annotationType = _toolStripMenuItemToAnnotationType[(ToolStripMenuItem)sender];

            // start new annotation building process and specify that this is the first process
            annotationsToolStrip1.AddAndBuildAnnotation(annotationType);
        }

        /// <summary>
        /// Handles the CheckedChanged event of BuildAnnotationsContinuouslyToolStripMenuItem object.
        /// </summary>
        private void buildAnnotationsContinuouslyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            annotationsToolStrip1.NeedBuildAnnotationsContinuously = buildAnnotationsContinuouslyToolStripMenuItem.Checked;
        }


        #region Interaction Mode

        /// <summary>
        /// Handles the Click event of NoneToolStripMenuItem object.
        /// </summary>
        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // disable the interaction with annotations in annotation viewer
            annotationViewer1.AnnotationInteractionMode = AnnotationInteractionMode.None;
        }

        /// <summary>
        /// Handles the Click event of ViewToolStripMenuItem1 object.
        /// </summary>
        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // set the "View" annotation interaction mode for annotation viewer
            annotationViewer1.AnnotationInteractionMode = AnnotationInteractionMode.View;
        }

        /// <summary>
        /// Handles the Click event of AuthorToolStripMenuItem object.
        /// </summary>
        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // set the "Author" annotation interaction mode for annotation viewer
            annotationViewer1.AnnotationInteractionMode = AnnotationInteractionMode.Author;
        }

        #endregion


        #region Transformation Mode

        /// <summary>
        /// Handles the Click event of RectangularToolStripMenuItem object.
        /// </summary>
        private void rectangularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // update the line annotation base grip mode
            ((LineAnnotationViewBase)annotationViewer1.FocusedAnnotationView).GripMode = GripMode.Rectangular;
            UpdateTransformationMenu();
        }

        /// <summary>
        /// Handles the Click event of PointsToolStripMenuItem object.
        /// </summary>
        private void pointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // update the line annotation base grip mode
            ((LineAnnotationViewBase)annotationViewer1.FocusedAnnotationView).GripMode = GripMode.Points;
            UpdateTransformationMenu();
        }

        /// <summary>
        /// Handles the Click event of RectangularAndPointsToolStripMenuItem object.
        /// </summary>
        private void rectangularAndPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // update the line annotation base grip mode
            ((LineAnnotationViewBase)annotationViewer1.FocusedAnnotationView).GripMode = GripMode.RectangularAndPoints;
            UpdateTransformationMenu();
        }

        #endregion


        #region Load and save annotations

        /// <summary>
        /// Handles the Click event of LoadAnnotationsFromFileToolStripMenuItem object.
        /// </summary>
        private void loadAnnotationsFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFileOpening = true;

            // load annotations from file
            AnnotationDemosTools.LoadAnnotationsFromFile(annotationViewer1, openFileDialog1, _undoManager);

            IsFileOpening = false;
        }

        /// <summary>
        /// Handles the Click event of SaveAnnotationsToFileToolStripMenuItem object.
        /// </summary>
        private void saveAnnotationsToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsFileSaving = true;

            // save annotations to file
            AnnotationDemosTools.SaveAnnotationsToFile(annotationViewer1, saveFileDialog1);

            IsFileSaving = false;
        }

        #endregion


        #region UI actions

        /// <summary>
        /// Handles the Click event of CutAnnotationToolStripMenuItem object.
        /// </summary>
        private void cutAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // cut selected annotation
            CutAnnotation();
        }

        /// <summary>
        /// Handles the Click event of CopyAnnotationToolStripMenuItem object.
        /// </summary>
        private void copyAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // cope selected annotation
            CopyAnnotation();
        }

        /// <summary>
        /// Handles the Click event of PasteAnnotationToolStripMenuItem object.
        /// </summary>
        private void pasteAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // paste annotations from "internal" buffer and makes them active
            PasteAnnotation();
        }

        /// <summary>
        /// Handles the Click event of PasteAnnotationInMousePositionToolStripMenuItem object.
        /// </summary>
        private void pasteAnnotationInMousePositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // paste annotations from "internal" buffer to mouse position and makes them active.
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            PasteAnnotationInMousePosition((ContextMenuStrip)menuItem.Owner);
        }

        /// <summary>
        /// Handles the Click event of DeleteAnnotationToolStripMenuItem object.
        /// </summary>
        private void deleteAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if thumbnail viewer is focused
            if (thumbnailViewer1.Focused)
            {
                // remove selected thumbnail
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
        /// Handles the Click event of DeleteAllAnnotationsToolStripMenuItem object.
        /// </summary>
        private void deleteAllAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // delete all annotations from image
            DeleteAnnotation(true);

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of BringToBackToolStripMenuItem object.
        /// </summary>
        private void bringToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // cancel the selected annotation building
            annotationViewer1.CancelAnnotationBuilding();

            // bring the selected annotation to the first position in annotation collection
            annotationViewer1.BringFocusedAnnotationToBack();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of BringToFrontToolStripMenuItem object.
        /// </summary>
        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // cancel the selected annotation building
            annotationViewer1.CancelAnnotationBuilding();

            // bring the selected annotation to the last position in annotation collection
            annotationViewer1.BringFocusedAnnotationToFront();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of MultiSelectToolStripMenuItem object.
        /// </summary>
        private void multiSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // enable/disable multi selection of annotations in viewer
            annotationViewer1.AnnotationMultiSelect = multiSelectToolStripMenuItem.Checked;
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of SelectAllAnnotationsToolStripMenuItem object.
        /// </summary>
        private void selectAllAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // select all annotations of annotation collection
            SelectAllAnnotations();
        }

        /// <summary>
        /// Handles the Click event of DeselectAllToolStripMenuItem object.
        /// </summary>
        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // cancel the selected annotation building
            annotationViewer1.CancelAnnotationBuilding();

            // if thumbnail viewer is not focused
            if (!thumbnailViewer1.Focused)
            {
                // get UI action
                DeselectAllItemsUIAction deselectAllUIAction = GetUIAction<DeselectAllItemsUIAction>(annotationViewer1.VisualTool);
                // if UI action is not empty AND UI action is enabled
                if (deselectAllUIAction != null && deselectAllUIAction.IsEnabled)
                {
                    // deselect all annotations of annotation collection
                    deselectAllUIAction.Execute();
                }
            }

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of GroupSelectedToolStripMenuItem object.
        /// </summary>
        private void groupSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // group/ungroup selected annotations of annotation collection
            AnnotationDemosTools.GroupUngroupSelectedAnnotations(annotationViewer1, _undoManager);
        }

        /// <summary>
        /// Handles the Click event of GroupAllToolStripMenuItem object.
        /// </summary>
        private void groupAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // group all annotations of annotation collection
            AnnotationDemosTools.GroupAllAnnotations(annotationViewer1, _undoManager);
        }

        #endregion


        #region Rotate, Burn, Clone

        /// <summary>
        /// Handles the Click event of RotateImageWithAnnotationsToolStripMenuItem object.
        /// </summary>
        private void rotateImageWithAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // rotate image with annotations
            AnnotationDemosTools.RotateImageWithAnnotations(annotationViewer1, _undoManager, _dataStorage);
        }

        /// <summary>
        /// Handles the Click event of BurnAnnotationsOnImageToolStripMenuItem object.
        /// </summary>
        private void burnAnnotationsOnImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // burn annotations on image
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
        /// Handles the Click event of CloneImageWithAnnotationsToolStripMenuItem object.
        /// </summary>
        private void cloneImageWithAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // cancel the selected annotation building
            annotationViewer1.CancelAnnotationBuilding();

            // clone image with annotations
            annotationViewer1.AnnotationDataController.CloneImageWithAnnotations(annotationViewer1.FocusedIndex, annotationViewer1.Images.Count);
            annotationViewer1.FocusedIndex = annotationViewer1.Images.Count - 1;
        }

        #endregion

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Handles the Click event of AboutToolStripMenuItem object.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm dlg = new AboutBoxForm())
            {
                // show the About dialog
                dlg.ShowDialog();
            }
        }

        #endregion


        #region Context menu

        /// <summary>
        /// Handles the Click event of SaveImageWithAnnotationsToolStripMenuItem object.
        /// </summary>
        private void saveImageWithAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // save focused image with annotations to a file
            SaveFocusedImageToNewImageFile();
        }

        /// <summary>
        /// Handles the Click event of CopyImageToClipboardToolStripMenuItem object.
        /// </summary>
        private void copyImageToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // copy focused image with annotations to clipboard
            AnnotationDemosTools.CopyImageToClipboard(annotationViewer1);
        }

        /// <summary>
        /// Handles the Click event of DeleteImageToolStripMenuItem object.
        /// </summary>
        private void deleteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // delete focused image
            DeleteImages();

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Opening event of AnnotationMenu object.
        /// </summary>
        private void annotationMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateContextMenuItem(cutAnnotationToolStripMenuItem, GetUIAction<CutItemUIAction>(annotationViewer1.VisualTool));
            UpdateContextMenuItem(copyAnnotationToolStripMenuItem, GetUIAction<CopyItemUIAction>(annotationViewer1.VisualTool));
            UpdateContextMenuItem(pasteAnnotationToolStripMenuItem, GetUIAction<PasteItemUIAction>(annotationViewer1.VisualTool));
            UpdateContextMenuItem(deleteAnnotationToolStripMenuItem, GetUIAction<DeleteItemUIAction>(annotationViewer1.VisualTool));
        }

        /// <summary>
        /// Handles the Opening event of AnnotationViewerMenu object.
        /// </summary>
        private void annotationViewerMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateContextMenuItem(pasteToolStripMenuItem2, GetUIAction<PasteItemUIAction>(annotationViewer1.VisualTool));
        }

        #endregion


        #region Annotation viewer

        /// <summary>
        /// Handles the MouseMove event of AnnotationViewer1 object.
        /// </summary>
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
                            PointF autoScrollPosition = new PointF(Math.Abs(annotationViewer1.AutoScrollPositionEx.X), Math.Abs(annotationViewer1.AutoScrollPositionEx.Y));

                            // calculate new auto scroll position
                            if ((!annotationViewer1.AutoScroll || annotationViewer1.AutoScrollMinSize.Width > 0) && deltaX != 0)
                                autoScrollPosition.X += deltaX;
                            if ((!annotationViewer1.AutoScroll || annotationViewer1.AutoScrollMinSize.Height > 0) && deltaY != 0)
                                autoScrollPosition.Y += deltaY;

                            // if auto scroll position is changed
                            if (autoScrollPosition != annotationViewer1.AutoScrollPosition)
                            {
                                // set new auto scroll position
                                annotationViewer1.AutoScrollPositionEx = autoScrollPosition;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the AutoScrollPositionExChanging event of AnnotationViewer1 object.
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
        /// Handles the AnnotationDataDeserializationException event of AnnotationDataController object.
        /// </summary>
        private void AnnotationDataController_AnnotationDataDeserializationException(
            object sender,
            Vintasoft.Imaging.Annotation.AnnotationDataDeserializationExceptionEventArgs e)
        {
            // show the annotation data deserialization exception
            DemosTools.ShowErrorMessage("AnnotationData deserialization exception", e.Exception);
        }

        /// <summary>
        /// Handles the VisualToolException event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_VisualToolException(object sender, ExceptionEventArgs e)
        {
            // catch a visual tool exception
            DemosTools.ShowErrorMessage(e.Exception);
        }

        /// <summary>
        /// Handles the ImageLoading event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_ImageLoading(object sender, ImageLoadingEventArgs e)
        {
            // update user interface

            progressBarImageLoading.Visible = true;
            toolStripStatusLabelLoadingImage.Visible = true;
            _imageLoadingStartTime = DateTime.Now;
        }

        /// <summary>
        /// Handles the ImageLoadingProgress event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_ImageLoadingProgress(object sender, ProgressEventArgs e)
        {
            if (_isFormClosing)
            {
                e.Cancel = true;
                return;
            }
            // update image loading progress
            progressBarImageLoading.Value = e.Progress;
        }

        /// <summary>
        /// Handles the ImageLoaded event of AnnotationViewer1 object.
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
        /// Handles the KeyDown event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_KeyDown(object sender, KeyEventArgs e)
        {
            // if 'Control' is pressed
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.X:
                        // if annotation can be cut
                        if (cutToolStripMenuItem.Enabled)
                        {
                            CutAnnotation();

                            e.Handled = true;
                        }
                        break;

                    case Keys.C:
                        // if annotation can be copy
                        if (copyToolStripMenuItem.Enabled)
                        {
                            CopyAnnotation();

                            e.Handled = true;
                        }
                        break;

                    case Keys.V:
                        // if annotation can be past
                        if (pasteToolStripMenuItem.Enabled)
                        {
                            PasteAnnotation();

                            e.Handled = true;
                        }
                        break;

                    case Keys.A:
                        // if annotation can be select
                        if (selectAllToolStripMenuItem.Enabled)
                        {
                            SelectAllAnnotations();

                            e.Handled = true;
                        }
                        break;
                }
            }
            // if annotation must be removed
            else if (
                (CanInteractWithFocusedAnnotationUseKeyboard() || annotationViewer1.FocusedAnnotationView == null) &&
                deleteToolStripMenuItem.Enabled &&
                e.KeyCode == Keys.Delete && e.Modifiers == Keys.None)
            {
                // delete the selected annotation from image
                DeleteAnnotation(false);

                // update the UI
                UpdateUI();

                e.Handled = true;
            }

            // if annotation is focused
            if (!e.Handled && annotationViewer1.Focused &&
                annotationViewer1.FocusedAnnotationView != null &&
                CanInteractWithFocusedAnnotationUseKeyboard())
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
                        // move annotation up
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X, location.Y - deltaVector.Y);
                        e.Handled = true;
                        break;
                    case Keys.Down:
                        // move annotation down
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X, location.Y + deltaVector.Y);
                        e.Handled = true;
                        break;
                    case Keys.Right:
                        // move annotation right
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X + deltaVector.X, location.Y);
                        e.Handled = true;
                        break;
                    case Keys.Left:
                        // move annotation left
                        annotationViewer1.FocusedAnnotationView.Location = new PointF(location.X - deltaVector.X, location.Y);
                        e.Handled = true;
                        break;
                    case Keys.Add:
                        // increase annotation
                        annotationViewer1.FocusedAnnotationView.Size = new SizeF(size.Width + resizeVector.X, size.Height + resizeVector.Y);
                        e.Handled = true;
                        break;
                    case Keys.Subtract:
                        // reduce annotation

                        if (size.Width > resizeVector.X)
                            annotationViewer1.FocusedAnnotationView.Size = new SizeF(size.Width - resizeVector.X, size.Height);

                        size = annotationViewer1.FocusedAnnotationView.Size;

                        if (size.Height > resizeVector.Y)
                            annotationViewer1.FocusedAnnotationView.Size = new SizeF(size.Width, size.Height - resizeVector.Y);
                        e.Handled = true;
                        break;
                }
                // update annotations property grid
                annotationsPropertyGrid1.Refresh();
            }
        }

        /// <summary>
        /// Determines whether can move focused annotation use keyboard.
        /// </summary>
        private bool CanInteractWithFocusedAnnotationUseKeyboard()
        {
            if (annotationViewer1.FocusedAnnotationView == null)
                return false;

#if !REMOVE_OFFICE_PLUGIN
            Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction.OfficeDocumentVisualEditor documentEditor =
                UserInteractionVisualTool.GetActiveInteractionController<Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction.OfficeDocumentVisualEditor>(annotationViewer1.VisualTool);
            if (documentEditor != null && documentEditor.IsEditingEnabled)
            {
                return false;
            }
#endif
            return true;
        }

        /// <summary>
        /// Handles the KeyPress event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if Enter key (13) pressed
            if (e.KeyChar == '\xD')
            {
                // if focused annotation is building
                if (annotationViewer1.IsAnnotationBuilding)
                    // finish annotation building
                    annotationViewer1.FinishAnnotationBuilding();
            }
            // if ESC key (27) pressed
            else if (e.KeyChar == '\x1B')
            {
                // if focused annotation is building
                if (annotationViewer1.IsAnnotationBuilding)
                    // cancel annotation building
                    annotationViewer1.CancelAnnotationBuilding();
            }
        }

        /// <summary>
        /// Handles the AnnotationInteractionModeChanged event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_AnnotationInteractionModeChanged(object sender, AnnotationInteractionModeChangedEventArgs e)
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

            // update the annotation interaction mode
            annotationInteractionModeToolStripComboBox.SelectedItem = annotationInteractionMode;

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the ImageCollectionChanged event of Images property of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_Images_ImageCollectionChanged(object sender, ImageCollectionChangeEventArgs e)
        {
            // update the UI
            InvokeUpdateUI();
        }

        #endregion


        #region Thumbnail viewer

        /// <summary>
        /// Handles the ThumbnailsLoadingProgress event of ThumbnailViewer1 object.
        /// </summary>
        private void thumbnailViewer1_ThumbnailsLoadingProgress(object sender, ThumbnailsLoadingProgressEventArgs e)
        {
            // update user interface

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
        /// Handles the DropDown event of AnnotationComboBox object.
        /// </summary>
        private void annotationComboBox_DropDown(object sender, EventArgs e)
        {
            // update the annotation's combobox
            FillAnnotationComboBox();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of AnnotationComboBox object.
        /// </summary>
        private void annotationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (annotationViewer1.FocusedIndex != -1 && annotationComboBox.SelectedIndex != -1)
            {
                // selected annotation index is changed using annotation's combobox
                annotationViewer1.FocusedAnnotationData = annotationViewer1.AnnotationDataCollection[annotationComboBox.SelectedIndex];
            }
        }

        /// <summary>
        /// Handles the SelectedAnnotationChanged event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_SelectedAnnotationChanged(object sender, AnnotationViewChangedEventArgs e)
        {
            // fill annotation combo box
            FillAnnotationComboBox();
            // show the annotation properties in annotation property grid
            ShowAnnotationProperties(annotationViewer1.FocusedAnnotationView);

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Handles the Changed event of SelectedAnnotations object.
        /// </summary>
        private void SelectedAnnotations_Changed(object sender, EventArgs e)
        {
            // update the UI
            UpdateUI();
        }

        #endregion


        #region Annotation interaction mode

        /// <summary>
        /// Handles the SelectedIndexChanged event of AnnotationInteractionModeToolStripComboBox object.
        /// </summary>
        private void annotationInteractionModeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update annotation interaction mode
            annotationViewer1.AnnotationInteractionMode =
                (AnnotationInteractionMode)annotationInteractionModeToolStripComboBox.SelectedItem;

            // enable undo redo menu
            EnableUndoRedoMenu();
            if (_historyForm != null)
                _historyForm.CanNavigateOnHistory = true;
        }

        #endregion


        #region Annotation

        /// <summary>
        /// Handles the FocusedAnnotationViewChanged event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_FocusedAnnotationViewChanged(
            object sender,
            AnnotationViewChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                // get old annotation data
                AnnotationData currentData = e.OldValue.Data;
                // while current annotation data is composite
                while (currentData is CompositeAnnotationData)
                {
                    CompositeAnnotationData compositeData = (CompositeAnnotationData)currentData;

                    // if current annotation data is sticky note annotation
                    if (compositeData is StickyNoteAnnotationData)
                    {
                        compositeData.PropertyChanged -= new EventHandler<ObjectPropertyChangedEventArgs>(compositeData_PropertyChanged);
                    }

                    foreach (AnnotationData data in compositeData)
                    {
                        currentData = data;
                        break;
                    }
                }
                currentData.PropertyChanged -= new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
            }

            if (e.NewValue != null)
            {
                // get new annotation data
                AnnotationData currentData = e.NewValue.Data;
                // while current annotation data is composite
                while (currentData is CompositeAnnotationData)
                {
                    CompositeAnnotationData compositeData = (CompositeAnnotationData)currentData;

                    // if current annotation data is sticky note annotation
                    if (compositeData is StickyNoteAnnotationData)
                    {
                        compositeData.PropertyChanged += new EventHandler<ObjectPropertyChangedEventArgs>(compositeData_PropertyChanged);
                    }

                    foreach (AnnotationData data in compositeData)
                    {
                        currentData = data;
                        break;
                    }
                }
                currentData.PropertyChanged += new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
                // store last focused annotation
                _focusedAnnotationData = currentData;
            }
        }

        /// <summary>
        /// Handles the AnnotationTransformingStarted event of AnnotationViewer1 object.
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
        /// Handles the AnnotationTransformingFinished event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_AnnotationTransformingFinished(object sender, AnnotationViewEventArgs e)
        {
            _isAnnotationTransforming = false;

            // end the initialization of annotation
            EndInit(e.AnnotationView.Data);
            // for each view of annotation
            foreach (AnnotationView view in annotationViewer1.SelectedAnnotations)
                // end the initialization of annotation view
                EndInit(view.Data);

            // refresh the property grid
            annotationsPropertyGrid1.Refresh();
        }

        /// <summary>
        /// Handles the ActiveInteractionControllerChanged event of AnnotationVisualTool object.
        /// </summary>
        private void AnnotationVisualTool_ActiveInteractionControllerChanged(object sender, PropertyChangedEventArgs<IInteractionController> e)
        {
            // get text box transformer of old text object
            TextObjectTextBoxTransformer oldTextObjectTextBoxTransformer = GetTextObjectTextBoxTransformer(e.OldValue);
            if (oldTextObjectTextBoxTransformer != null)
            {
                // unsubscribe from text object transformer events

                oldTextObjectTextBoxTransformer.TextBoxShown -= TextObjectTextBoxTransformer_TextBoxShown;
                oldTextObjectTextBoxTransformer.TextBoxClosed -= TextObjectTextBoxTransformer_TextBoxClosed;
            }

            // get text box transformer of new text object
            TextObjectTextBoxTransformer newTextObjectTextBoxTransformer = GetTextObjectTextBoxTransformer(e.NewValue);
            if (newTextObjectTextBoxTransformer != null)
            {
                // subscribe to text object transformer events

                newTextObjectTextBoxTransformer.TextBoxShown +=
                    new EventHandler<TextObjectTextBoxTransformerEventArgs>(TextObjectTextBoxTransformer_TextBoxShown);
                newTextObjectTextBoxTransformer.TextBoxClosed +=
                    new EventHandler<TextObjectTextBoxTransformerEventArgs>(TextObjectTextBoxTransformer_TextBoxClosed);
            }
        }

        /// <summary>
        /// Handles the AnnotationBuildingStarted event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_AnnotationBuildingStarted(object sender, AnnotationViewEventArgs e)
        {
            // disable annotation combo box
            annotationComboBox.Enabled = false;

            // disable annotation history
            DisableUndoRedoMenu();

            // if history form is shown
            if (_historyForm != null)
                // disable navigation on history
                _historyForm.CanNavigateOnHistory = false;
        }

        /// <summary>
        /// Handles the AnnotationBuildingCanceled event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_AnnotationBuildingCanceled(object sender, AnnotationViewEventArgs e)
        {
            // enable annotation combo box
            annotationComboBox.Enabled = true;

            // enable annotation history
            EnableUndoRedoMenu();

            // if history form is shown
            if (_historyForm != null)
                // disable navigation on history
                _historyForm.CanNavigateOnHistory = true;
        }

        /// <summary>
        /// Handles the AnnotationBuildingFinished event of AnnotationViewer1 object.
        /// </summary>
        private void annotationViewer1_AnnotationBuildingFinished(object sender, AnnotationViewEventArgs e)
        {
            // the value indicate whether the annotation buinding is finished
            bool isBuildingFinished = true;

            // if the annotations must be built continuously
            if (annotationsToolStrip1.NeedBuildAnnotationsContinuously)
            {
                // if focused annotation is building
                if (annotationViewer1.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                    isBuildingFinished = false;
            }

            // if annotation buiding is finished
            if (isBuildingFinished)
            {
                annotationComboBox.Enabled = true;

                EnableUndoRedoMenu();
                if (_historyForm != null)
                    _historyForm.CanNavigateOnHistory = true;
            }
        }

        /// <summary>
        /// Handles the Deactivated event of NoneAction object.
        /// </summary>
        private void NoneAction_Deactivated(object sender, EventArgs e)
        {
            // disable the comment visual tool
            _commentVisualTool.Enabled = false;
        }

        /// <summary>
        /// Handles the Activated event of NoneAction object.
        /// </summary>
        private void NoneAction_Activated(object sender, EventArgs e)
        {
            // enable the comment visual tool
            _commentVisualTool.Enabled = true;
        }

        #endregion


        #region Annotation undo manager

        /// <summary>
        /// Handles the Click event of AnnotationHistoryToolStripMenuItem object.
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
        /// Handles the FormClosed event of HistoryForm object.
        /// </summary>
        private void historyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // disable history dialog tool strip item
            historyDialogToolStripMenuItem.Checked = false;
            _historyForm = null;
        }

        #endregion


        #region Save image(s)

        /// <summary>
        /// Handles the ImageCollectionSavingFinished event of Images object.
        /// </summary>
        private void images_ImageCollectionSavingFinished(object sender, EventArgs e)
        {
            if (_saveFilename != null)
            {
                // close source
                CloseSource();
                _sourceFilename = _saveFilename;
                _saveFilename = null;
                _isFileReadOnlyMode = false;
            }

            IsFileSaving = false;
        }

        /// <summary>
        /// Handles the ImageSavingException event of Images object.
        /// </summary>
        private void Images_ImageSavingException(object sender, ExceptionEventArgs e)
        {
            // show image saving error
            DemosTools.ShowErrorMessage(e.Exception);
        }

        #endregion 

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
            bool isAnnotationFocused = annotationViewer1.FocusedAnnotationView != null;
            bool isAnnotationSelected = annotationViewer1.SelectedAnnotations.Count > 0;
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

            annotationsInfoToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;

            interactionModeToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;

            loadFromFileToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;

            addAnnotationToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty && isInteractionModeAuthor;
            buildAnnotationsContinuouslyToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;

            bringToBackToolStripMenuItem1.Enabled = !isFileOpening && !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding;
            bringToFrontToolStripMenuItem1.Enabled = !isFileOpening && !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding;

            multiSelectToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;

            groupSelectedToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding;
            groupAllToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty && isInteractionModeAuthor && !isAnnotationBuilding;

            rotateImageWithAnnotationsToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;
            burnAnnotationsOnImageToolStripMenuItem.Enabled = !isAnnotationEmpty;
            cloneImageWithAnnotationsToolStripMenuItem.Enabled = !isFileOpening && !isFileEmpty;

            saveToFileToolStripMenuItem.Enabled = !isAnnotationEmpty;

            // annotation viewer context menu
            annotationMenu.Enabled = !isFileOpening && !isFileEmpty;
            saveImageWithAnnotationsToolStripMenuItem.Enabled = !isAnnotationEmpty;
            burnAnnotationsOnImage2ToolStripMenuItem.Enabled = !isAnnotationEmpty;
            copyImageToClipboardToolStripMenuItem.Enabled = isImageSelected;
            deleteImageToolStripMenuItem.Enabled = isImageSelected && !isFileSaving;
            bringToBackToolStripMenuItem.Enabled = isAnnotationFocused || isAnnotationSelected;
            bringToFrontToolStripMenuItem.Enabled = isAnnotationFocused || isAnnotationSelected;

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

            // update annotation demo title
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
                BeginInvoke(new UpdateUIDelegate(UpdateUI));
            else
                UpdateUI();
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Opens the file.
        /// </summary>
        private void OpenFile()
        {
            IsFileOpening = true;

            // set open file dialog filters
            CodecsFileFilters.SetOpenFileDialogFilter(openFileDialog1);

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
        /// Prints images.
        /// </summary>
        private void Print()
        {
            // print thumbnail viewer images
            _thumbnailViewerPrintManager.Print();
        }

        #endregion


        #region 'View' menu

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees clockwise.
        /// </summary>
        private void RotateViewClockwise()
        {
            if (annotationViewer1.ImageRotationAngle != 270)
            {
                annotationViewer1.ImageRotationAngle += 90;
                thumbnailViewer1.ImageRotationAngle += 90;
            }
            else
            {
                annotationViewer1.ImageRotationAngle = 0;
                thumbnailViewer1.ImageRotationAngle = 0;
            }
        }

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees counterclockwise.
        /// </summary>
        private void RotateViewCounterClockwise()
        {
            if (annotationViewer1.ImageRotationAngle != 0)
            {
                annotationViewer1.ImageRotationAngle -= 90;
                thumbnailViewer1.ImageRotationAngle -= 90;
            }
            else
            {
                annotationViewer1.ImageRotationAngle = 270;
                thumbnailViewer1.ImageRotationAngle = 270;
            }
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

        #endregion


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
        private void CutAnnotation()
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
        private void CopyAnnotation()
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
        private void PasteAnnotation()
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
        /// Pastes annotations from "internal" buffer to them mouse position and makes them active.
        /// </summary>
        /// <param name="sourceMenuStrip">The source context menu strip.</param>
        private void PasteAnnotationInMousePosition(ContextMenuStrip sourceMenuStrip)
        {
            // get mouse position on image in DIP
            PointF mousePositionOnImageInDip = annotationViewer1.PointFromControlToDip(
                annotationViewer1.PointToClient(sourceMenuStrip.PointToScreen(new Point(0, 0))));

            annotationViewer1.PasteAnnotationsFromClipboard(mousePositionOnImageInDip);
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
        /// Updates the UI action item in context menu.
        /// </summary>
        /// <param name="menuItem">The context menu item.</param>
        /// <param name="uiAction">The UI action, which is associated with the "Edit" menu item.</param>
        private void UpdateContextMenuItem(ToolStripMenuItem editMenuItem, UIAction uiAction)
        {
            // if UI action is specified AND UI action is enabled
            if (uiAction != null && uiAction.IsEnabled)
            {
                // enable the menu item
                editMenuItem.Enabled = true;
            }
            else
            {
                // disable the menu item
                editMenuItem.Enabled = false;
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
            ISupportUIActions actionSource = visualTool as ISupportUIActions;
            if (actionSource != null)
                return UIAction.GetFirstUIAction<T>(actionSource);
            return default(T);
        }

        /// <summary>
        /// Selects all annotations.
        /// </summary>
        private void SelectAllAnnotations()
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
        /// <param name="annotation">The annotation.</param>
        private void ShowAnnotationProperties(AnnotationView annotation)
        {
            if (annotationsPropertyGrid1.SelectedObject != annotation)
                annotationsPropertyGrid1.SelectedObject = annotation;
            else if (!_isAnnotationTransforming)
                annotationsPropertyGrid1.Refresh();
        }

        #endregion


        #region File manipulation

        /// <summary>
        /// Opens stream of the image file and adds stream of image file to the image collection of image viewer - this allows
        /// to save modified multipage image files back to the source.
        /// </summary>
        /// <param name="filename">The file path.</param>
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
                UseWaitCursor = true;
                annotationViewer1.Images.Add(_sourceFilename, _isFileReadOnlyMode);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
                Invoke(new CloseCurrentFileDelegate(CloseCurrentFile));
            }

            UseWaitCursor = false;

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
        /// <param name="filename">The file path.</param>
        private void OpenSourceStream(string filename)
        {
            // get full path to specified filename
            _sourceFilename = Path.GetFullPath(filename);
            _isFileReadOnlyMode = false;
            Stream stream = null;
            try
            {
                // open stream
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


        #region Annotation

        /// <summary>
        /// The focused annotation data property is changed.
        /// </summary>
        private void FocusedAnnotationData_PropertyChanged(
            object sender,
            ObjectPropertyChangedEventArgs e)
        {
            // if 'Location' property of several annotations was changed
            if (e.PropertyName == "Location" && annotationViewer1.SelectedAnnotations.Count > 1)
            {
                // get focused annotation
                AnnotationView focusedView = annotationViewer1.AnnotationVisualTool.FocusedAnnotationView;
                if (focusedView != null && focusedView.InteractionController != null)
                {
                    // get focused interaction area
                    InteractionArea focusedArea = focusedView.InteractionController.FocusedInteractionArea;
                    // if annotation is moved
                    if (focusedArea != null && focusedArea.InteractionName == "Move")
                    {
                        // move all selected annotations

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
            // if comment is changed
            else if (e.PropertyName == "Comment")
            {
                // update the UI
                UpdateUI();
            }
        }

        /// <summary>
        /// Subscribes to the <see cref="StickyNoteAnnotationData"/> events.
        /// </summary>
        private void compositeData_PropertyChanged(object sender, ObjectPropertyChangedEventArgs e)
        {
            StickyNoteAnnotationData stickyNote = sender as StickyNoteAnnotationData;
            // if sticky note annotation property is changed
            if (stickyNote != null)
            {
                // if annotation collapsed type is changed or annotation is collapsed
                if (e.PropertyName == "CollapsedType" || e.PropertyName == "IsCollapsed")
                {
                    // if focused annotation exists
                    if (_focusedAnnotationData != null)
                    {
                        // unsubscribe from  PropertyChanged event of focused annotation
                        _focusedAnnotationData.PropertyChanged -= new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
                    }

                    // for each annotation, which is embedded in sticky note annotation
                    foreach (AnnotationData data in stickyNote)
                    {
                        // set annotation as focused annotation
                        _focusedAnnotationData = data;
                        // subscribe to the  PropertyChanged event of focused annotation
                        _focusedAnnotationData.PropertyChanged += new EventHandler<ObjectPropertyChangedEventArgs>(FocusedAnnotationData_PropertyChanged);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Begins initialization of the specified annotation.
        /// </summary>
        /// <param name="annotation">The annotation.</param>
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
        /// <param name="annotation">The annotation.</param>
        private void EndInit(AnnotationData annotation)
        {
            if (_initializedAnnotations.Contains(annotation))
            {
                _initializedAnnotations.Remove(annotation);
                annotation.EndInit();
            }
        }

        /// <summary>
        /// Deletes the selected annotation or all annotations from image.
        /// </summary>
        /// <param name="deleteAll">Determines that all annotations must be deleted from image.</param>
        private void DeleteAnnotation(bool deleteAll)
        {
            annotationViewer1.CancelAnnotationBuilding();

            // get UI action
            UIAction deleteUIAction;
            if (deleteAll)
                deleteUIAction = GetUIAction<DeleteAllItemsUIAction>(annotationViewer1.VisualTool);
            else
                deleteUIAction = GetUIAction<DeleteItemUIAction>(annotationViewer1.VisualTool);

            // if UI action is not empty  AND UI action is enabled
            if (deleteUIAction != null && deleteUIAction.IsEnabled)
            {
                string actionName = "AnnotationViewCollection: Delete";
                if (deleteAll)
                    actionName += " All";
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

        #endregion


        #region Annotation undo manager

        /// <summary>
        /// Updates the "Undo/Redo" menu.
        /// </summary>
        /// <param name="undoManager">The undo manager.</param>
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

            EncoderBase encoder;
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
        /// <param name="saveAndSwitchSource">The value indicating whether the image collection should be switched to the source after saving.</param>
        private void SaveImageCollectionToMultipageImageFile(bool saveAndSwitchSource)
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
            CodecsFileFilters.SetSaveFileDialogFilter(saveFileDialog1, multipage, true);
            // show the file saving dialog
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EncoderBase encoder;
                try
                {
                    string saveFilename = Path.GetFullPath(saveFileDialog1.FileName);
                    // if multiple images must be saved
                    if (multipage)
                        // get image encoder for multi page image file
                        encoder = GetMultipageEncoder(saveFilename, true, saveAndSwitchSource);
                    // if single image must be saved
                    else
                        // get image encoder for single page image file
                        encoder = GetEncoder(saveFilename, true);
                    // if encoder is found
                    if (encoder != null)
                    {
                        if (saveAndSwitchSource)
                            _saveFilename = saveFilename;
                        encoder.SaveAndSwitchSource = saveAndSwitchSource;

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
                if (!saveAndSwitchSource)
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
            CodecsFileFilters.SetSaveFileDialogFilter(saveFileDialog1, false, true);
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
        /// Returns an encoder for saving of single image.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="showSettingsDialog">A value indicating whether the encoder settings dialog must be shown.</param>
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

                        using (JpegEncoderSettingsForm jpegEncoderSettingsDlg = new JpegEncoderSettingsForm())
                        {
                            jpegEncoderSettingsDlg.EditAnnotationSettings = true;
                            jpegEncoderSettingsDlg.EncoderSettings = jpegEncoder.Settings;
                            if (jpegEncoderSettingsDlg.ShowDialog() != DialogResult.OK)
                                throw new Exception("Saving canceled.");
                        }
                    }

                    return jpegEncoder;

                case ".PNG":
                    PngEncoder pngEncoder = new PngEncoder();

                    if (showSettingsDialog)
                    {
                        pngEncoder.Settings.AnnotationsFormat = AnnotationsFormat.VintasoftBinary;

                        using (PngEncoderSettingsForm pngEncoderSettingsDlg = new PngEncoderSettingsForm())
                        {
                            pngEncoderSettingsDlg.EditAnnotationSettings = true;
                            pngEncoderSettingsDlg.EncoderSettings = pngEncoder.Settings;
                            if (pngEncoderSettingsDlg.ShowDialog() != DialogResult.OK)
                                throw new Exception("Saving canceled.");
                        }
                    }

                    return pngEncoder;

                // if annotations are not supported
                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns a multipage encoder for saving of image collection.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="showSettingsDialog">A value indicating whether the encoder settings dialog must be shown.</param>
        /// <param name="saveAndSwitchSource">A value indicating whether the image collection should be switched to the source after saving.</param>
        private MultipageEncoderBase GetMultipageEncoder(
            string filename,
            bool showSettingsDialog,
            bool saveAndSwitchSource)
        {
            bool isFileExist = File.Exists(filename) && !saveAndSwitchSource;
            switch (Path.GetExtension(filename).ToUpperInvariant())
            {
#if !REMOVE_PDF_PLUGIN
                case ".PDF":
                    IPdfEncoder pdfEncoder = (IPdfEncoder)AvailableEncoders.CreateEncoderByName("Pdf");

                    if (showSettingsDialog)
                    {
                        pdfEncoder.Settings.AnnotationsFormat = AnnotationsFormat.VintasoftBinary;

                        using (PdfEncoderSettingsForm pdfEncoderSettingsDlg = new PdfEncoderSettingsForm())
                        {
                            pdfEncoderSettingsDlg.AppendExistingDocumentEnabled = isFileExist;
                            pdfEncoderSettingsDlg.CanEditAnnotationSettings = true;
                            pdfEncoderSettingsDlg.EncoderSettings = pdfEncoder.Settings;
                            if (pdfEncoderSettingsDlg.ShowDialog() != DialogResult.OK)
                                throw new Exception("Saving canceled.");
                        }
                    }

                    return (MultipageEncoderBase)pdfEncoder;
#endif

                case ".TIF":
                case ".TIFF":
                    TiffEncoder tiffEncoder = new TiffEncoder();

                    if (showSettingsDialog)
                    {
                        tiffEncoder.Settings.AnnotationsFormat = AnnotationsFormat.VintasoftBinary;

                        using (TiffEncoderSettingsForm tiffEncoderSettingsDlg = new TiffEncoderSettingsForm())
                        {
                            tiffEncoderSettingsDlg.CanAddImagesToExistingFile = isFileExist;
                            tiffEncoderSettingsDlg.EditAnnotationSettings = true;
                            tiffEncoderSettingsDlg.EncoderSettings = tiffEncoder.Settings;
                            if (tiffEncoderSettingsDlg.ShowDialog() != DialogResult.OK)
                                throw new Exception("Saving canceled.");
                        }
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

        #endregion

        #endregion

        #endregion



        #region Delegates

        /// <summary>
        /// The delegate for <see cref="UpdateUI"/> method.
        /// </summary>
        private delegate void UpdateUIDelegate();

        /// <summary>
        /// The delegate for <see cref="CloseCurrentFile"/> method.
        /// </summary>
        private delegate void CloseCurrentFileDelegate();

        /// <summary>
        /// The delegate for <see cref="SavingProgress"/> method.
        /// </summary>
        private delegate void SavingProgressDelegate(object sender, ProgressEventArgs e);

        #endregion

    }
}
