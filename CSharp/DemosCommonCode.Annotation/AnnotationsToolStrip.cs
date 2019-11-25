using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Annotation.UI.VisualTools;
using Vintasoft.Imaging.Annotation.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

using DemosCommonCode.CustomControls;
using DemosCommonCode.Imaging.Codecs;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// A Windows toolbar that allows to add annotations to an image in viewer.
    /// </summary>
    public class AnnotationsToolStrip : ToolStrip
    {

        #region Nested classes

        /// <summary>
        /// Contains information about annotation button.
        /// </summary>
        private class AnnotationButtonInfo
        {

            #region Constructors

            /// <summary>
            /// Initializes the <see cref="AnnotationButtonInfo"/> class.
            /// </summary>
            static AnnotationButtonInfo()
            {
                _separator = new AnnotationButtonInfo(AnnotationType.Unknown);
                _separator._name = "SEPARATOR";
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="AnnotationButtonInfo"/> class.
            /// </summary>
            /// <param name="annotationType">The annotation type.</param>
            /// <param name="dropDownItems">The drop down items of annotation button.</param>
            internal AnnotationButtonInfo(
                AnnotationType annotationType,
                params AnnotationButtonInfo[] dropDownItems)
            {
                _annotationType = annotationType;
                _name = AnnotationNameFactory.GetAnnotationName(annotationType);

                _dropDownItems = dropDownItems;
            }

            #endregion



            #region Properties

            static AnnotationButtonInfo _separator;
            /// <summary>
            /// Gets the separator.
            /// </summary>
            internal static AnnotationButtonInfo Separator
            {
                get
                {
                    return _separator;
                }
            }


            string _name = string.Empty;
            /// <summary>
            /// Gets the annotation button name.
            /// </summary>
            internal string Name
            {
                get
                {
                    return _name;
                }
            }

            AnnotationType _annotationType = AnnotationType.Unknown;
            /// <summary>
            /// Gets the annotation type.
            /// </summary>
            internal AnnotationType AnnotationType
            {
                get
                {
                    return _annotationType;
                }
            }

            AnnotationButtonInfo[] _dropDownItems = new AnnotationButtonInfo[0];
            /// <summary>
            /// Gets the drop down items of annotation button.
            /// </summary>
            internal AnnotationButtonInfo[] DropDownItems
            {
                get
                {
                    return _dropDownItems;
                }
            }

            #endregion



            #region Methods

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            public override string ToString()
            {
                return Name;
            }

            #endregion

        }

        #endregion



        #region Fields

        /// <summary>
        /// Dictionary: the tool strip menu item => the annotation type.
        /// </summary>
        Dictionary<ToolStripItem, AnnotationType> _toolStripItemToAnnotationType =
            new Dictionary<ToolStripItem, AnnotationType>();

        /// <summary>
        /// Dictionary: the annotation type => the tool strip menu item.
        /// </summary>
        Dictionary<AnnotationType, ToolStripItem> _annotationTypeToToolStripItem =
            new Dictionary<AnnotationType, ToolStripItem>();

        /// <summary>
        /// The open image file dialog.
        /// </summary>
        OpenFileDialog _openImageDialog;

        /// <summary>
        /// The default visual tool of annotation viewer.
        /// </summary>
        VisualTool _annotationViewerDefaultVisualTool;

        /// <summary>
        /// The annotation button, which is currently checked in the control.
        /// </summary>
        ToolStripItem _checkedAnnotationButton = null;

        /// <summary>
        /// The type of annotation, which is building now.
        /// </summary>
        AnnotationType _buildingAnnotationType = AnnotationType.Unknown;

        /// <summary>
        /// The name of image file for embedded or referenced image annotation.
        /// </summary>
        /// <remarks>
        /// This field is used when annotations must be built continuously.
        /// </remarks>
        string _embeddedOrReferencedImageFileName = null;

        /// <summary>
        /// Indicates that the interaction mode is changing.
        /// </summary>
        bool _isInteractionModeChanging = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnotationsToolStrip"/> class.
        /// </summary>
        public AnnotationsToolStrip()
            : base()
        {
            InitializeAnnotationButtons();

            AnnotationViewer = null;
        }

        #endregion



        #region Properties

        AnnotationViewer _annotationViewer;
        /// <summary>
        /// Gets or sets the <see cref="AnnotationViewer"/>, which is associated with
        /// this <see cref="AnnotationsToolStrip"/>.
        /// </summary>        
        public AnnotationViewer AnnotationViewer
        {
            get
            {
                return _annotationViewer;
            }
            set
            {
                UnsubscribeFromAnnotationViewerEvents(_annotationViewer);

                _annotationViewer = value;
                if (_annotationViewer != null)
                    // save reference to the default visual tool of annotation viewer
                    _annotationViewerDefaultVisualTool = _annotationViewer.VisualTool;

                SubscribeToAnnotationViewerEvents(_annotationViewer);
            }
        }

        bool _needBuildAnnotationsContinuously = false;
        /// <summary>
        /// Gets or sets a value indicating whether the annotations must be built continuously.
        /// </summary>
        public bool NeedBuildAnnotationsContinuously
        {
            get
            {
                return _needBuildAnnotationsContinuously;
            }
            set
            {
                _needBuildAnnotationsContinuously = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Adds an annotation to an image and starts the annotation building.
        /// </summary>
        /// <param name="annotationType">The annotation type.</param>
        /// <returns>
        /// The annotation view.
        /// </returns>
        public AnnotationView AddAndBuildAnnotation(AnnotationType annotationType)
        {
            // if annotation viewer is not specified
            if (AnnotationViewer == null || AnnotationViewer.Image == null)
                return null;

            // if current visual tool of annotation viewer differs from the default visual tool of annotation viewer
            if (_annotationViewer.VisualTool != _annotationViewerDefaultVisualTool)
            {
                // set the default visual tool of annotation viewer as current visual tool
                _annotationViewer.VisualTool = _annotationViewerDefaultVisualTool;
            }

            // if the focused annotation is building
            if (AnnotationViewer.AnnotationVisualTool.IsFocusedAnnotationBuilding)
                // cancel building of focused annotation
                AnnotationViewer.AnnotationVisualTool.CancelAnnotationBuilding();


            _isInteractionModeChanging = true;
            // use the Author mode for annotation visual tool
            _annotationViewer.AnnotationInteractionMode = AnnotationInteractionMode.Author;
            _isInteractionModeChanging = false;


            AnnotationView annotationView = null;
            try
            {
                // save the annotation type
                _buildingAnnotationType = annotationType;

                // select the annotation button
                SelectAnnotationButton(annotationType);

                // create the annotation view
                annotationView = CreateAnnotationView(annotationType);

                // if annotation view is created
                if (annotationView != null)
                {
                    // start the annotation building
                    AnnotationViewer.AddAndBuildAnnotation(annotationView);

                    // if annotation is link annotation
                    if (annotationView is LinkAnnotationView)
                    {
                        // subscribe to the Link annotation events
                        SubscribeToLinkAnnotationViewEvents((LinkAnnotationView)annotationView);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                // show error message
                DemosTools.ShowErrorMessage("Building annotation", ex);

                // unselect annotation button
                SelectAnnotationButton(AnnotationType.Unknown);

                annotationView = null;
            }

            return annotationView;
        }

        #endregion


        #region PRIVATE

        #region Initialization

        /// <summary>
        /// Initializes the annotations buttons.
        /// </summary>
        private void InitializeAnnotationButtons()
        {
            // create information about annotation buttons of this tool strip

            AnnotationButtonInfo[] annotationButtonInfos = {

                // Rectangle
                new AnnotationButtonInfo(AnnotationType.Rectangle,
                    // Rectangle -> Cloud Rectangle
                    new AnnotationButtonInfo(AnnotationType.CloudRectangle)),

                // Ellipse
                new AnnotationButtonInfo(AnnotationType.Ellipse,
                    // Ellipse -> Cloud Ellipse
                    new AnnotationButtonInfo(AnnotationType.CloudEllipse)),

                // Highlight
                new AnnotationButtonInfo(AnnotationType.Highlight,
                    // Highlight -> Cloud Highlight
                    new AnnotationButtonInfo(AnnotationType.CloudHighlight)),

                // Text Highlight
                new AnnotationButtonInfo(AnnotationType.TextHighlight,
                    // Text Highlight -> Freehand Higlight
                    new AnnotationButtonInfo(AnnotationType.FreehandHighlight),
                    // Text Highlight -> Polygon Highlight
                    new AnnotationButtonInfo(AnnotationType.PolygonHighlight),
                    // Text Highlight -> Freehand Polygon Highlight
                    new AnnotationButtonInfo(AnnotationType.FreehandPolygonHighlight)),

                AnnotationButtonInfo.Separator,


                // Embedded Image
                new AnnotationButtonInfo(AnnotationType.EmbeddedImage),

                // Referenced Image
                new AnnotationButtonInfo(AnnotationType.ReferencedImage),

                AnnotationButtonInfo.Separator,
                

                // Text
                new AnnotationButtonInfo(AnnotationType.Text,
                    // Text -> Cloud Text
                    new AnnotationButtonInfo(AnnotationType.CloudText)),

                // Sticky Note
                new AnnotationButtonInfo(AnnotationType.StickyNote),

                // Free Text
                new AnnotationButtonInfo(AnnotationType.FreeText,
                    // Free Text -> Cloud Free Text
                    new AnnotationButtonInfo(AnnotationType.CloudFreeText)),

                // Rubber Stamp
                new AnnotationButtonInfo(AnnotationType.RubberStamp),

                // Link
                new AnnotationButtonInfo(AnnotationType.Link),

                // Arrow
                new AnnotationButtonInfo(AnnotationType.Arrow),

                // Double Arrow
                new AnnotationButtonInfo(AnnotationType.DoubleArrow),

                AnnotationButtonInfo.Separator,


                // Line
                new AnnotationButtonInfo(AnnotationType.Line),

                // Lines
                new AnnotationButtonInfo(AnnotationType.Lines,
                    // Lines -> Cloud Lines
                    new AnnotationButtonInfo(AnnotationType.CloudLines),
                    // Lines -> Triangle Lines
                    new AnnotationButtonInfo(AnnotationType.TriangleLines)),

                // Lines with Interpolation
                new AnnotationButtonInfo(AnnotationType.LinesWithInterpolation,
                    // Lines with Interpolation -> Cloud Lines with Interpolation
                    new AnnotationButtonInfo(AnnotationType.CloudLinesWithInterpolation)),

                // Freehand Lines
                new AnnotationButtonInfo(AnnotationType.FreehandLines),

                // Polygon
                new AnnotationButtonInfo(AnnotationType.Polygon,                    
                    // Polygon -> Cloud Polygon
                    new AnnotationButtonInfo(AnnotationType.CloudPolygon),
                    // Polygon -> Triangle Polygon 
                    new AnnotationButtonInfo(AnnotationType.TrianglePolygon)),

                // Polygon with Interpolation
                new AnnotationButtonInfo(AnnotationType.PolygonWithInterpolation,
                    // Polygon with Interpolation -> Cloud Polygon with Interpolation
                    new AnnotationButtonInfo(AnnotationType.CloudPolygonWithInterpolation)),

                // Freehand Polygon
                new AnnotationButtonInfo(AnnotationType.FreehandPolygon),

                // Ruler
                new AnnotationButtonInfo(AnnotationType.Ruler),

                // Rulers
                new AnnotationButtonInfo(AnnotationType.Rulers),

                // Angle
                new AnnotationButtonInfo(AnnotationType.Angle),
                
                // Arc
                new AnnotationButtonInfo(AnnotationType.Arc,
                    // Arc -> With Arrow
                    new AnnotationButtonInfo(AnnotationType.ArcWithArrow),
                    // Arc -> With Double Arrow
                    new AnnotationButtonInfo(AnnotationType.ArcWithDoubleArrow)),
                
                AnnotationButtonInfo.Separator,


                // Triangle
                new AnnotationButtonInfo(AnnotationType.Triangle,
                    // Triangle -> Cloud Triangle
                    new AnnotationButtonInfo(AnnotationType.CloudTriangle)),

                // Mark
                new AnnotationButtonInfo(AnnotationType.Mark),
            };


            ComponentResourceManager resources = new ComponentResourceManager(typeof(AnnotationsToolStrip));

            _toolStripItemToAnnotationType.Clear();
            _annotationTypeToToolStripItem.Clear();

            // initialize the annotation buttons of this tool strip
            InitializeAnnotationButtons(Items, annotationButtonInfos, resources);
        }

        /// <summary>
        /// Initializes the annotation buttons.
        /// </summary>
        /// <param name="annotationButtonCollection">The annotation button collection to which new annotation button must be added.</param>
        /// <param name="annotationButtonInfos">Information about annotation buttons.</param>
        /// <param name="resources">The resources, which contain the annotation button image.</param>
        private void InitializeAnnotationButtons(
            ToolStripItemCollection annotationButtonCollection,
            AnnotationButtonInfo[] annotationButtonInfos,
            ComponentResourceManager resources)
        {
            foreach (AnnotationButtonInfo annotationButtonInfo in annotationButtonInfos)
                InitializeAnnotationButton(annotationButtonCollection, annotationButtonInfo, resources);
        }

        /// <summary>
        /// Creates the annotation button and adds the button to the collection of annotation buttons.
        /// </summary>
        /// <param name="annotationButtonCollection">The annotation button collection to which new annotation button must be added.</param>
        /// <param name="annotationButtonInfo">An information about annotation button.</param>
        /// <param name="resources">The resources, which contain the annotation button image.</param>
        private void InitializeAnnotationButton(
            ToolStripItemCollection annotationButtonCollection,
            AnnotationButtonInfo annotationButtonInfo,
            ComponentResourceManager resources)
        {
            string annotationButtonName = annotationButtonInfo.Name;
            AnnotationType annotationType = annotationButtonInfo.AnnotationType;
            AnnotationButtonInfo[] annotationButtonChildren = annotationButtonInfo.DropDownItems;

            ToolStripItem annotationButton = null;

            if (annotationButtonInfo == AnnotationButtonInfo.Separator)
            {
                annotationButton = new ToolStripSeparator();
            }
            else
            {
                ToolStripItemDisplayStyle displayStyle = ToolStripItemDisplayStyle.ImageAndText;
                bool addToRoot = annotationButtonCollection == Items;

                if (addToRoot)
                {
                    displayStyle = ToolStripItemDisplayStyle.Image;

                    if (annotationButtonChildren.Length == 0)
                        annotationButton = new ToolStripButton(annotationButtonName);
                    else
                        annotationButton = new CheckedToolStripSplitButton(annotationButtonName);
                }
                else
                {
                    annotationButton = new ToolStripMenuItem(annotationButtonName);
                }

                ToolStripDropDownItem dropDownItem = annotationButton as ToolStripDropDownItem;

                if (dropDownItem != null)
                    InitializeAnnotationButtons(dropDownItem.DropDownItems, annotationButtonChildren, resources);

                annotationButton.ImageTransparentColor = Color.Magenta;
                annotationButton.Name = annotationButtonName;
                annotationButton.ToolTipText = annotationButtonName;
                annotationButton.Tag = annotationButtonInfo;

                ToolStripSplitButton splitButton = annotationButton as ToolStripSplitButton;
                if (splitButton != null)
                    splitButton.ButtonClick += new EventHandler(buildAnnotationButton_Click);
                else
                    annotationButton.Click += new EventHandler(buildAnnotationButton_Click);

                annotationButton.Image = resources.GetObject(annotationButtonName) as Image;
                annotationButton.DisplayStyle = displayStyle;
                annotationButton.ImageScaling = ToolStripItemImageScaling.None;

                _toolStripItemToAnnotationType.Add(annotationButton, annotationType);
                _annotationTypeToToolStripItem.Add(annotationType, annotationButton);
            }

            annotationButtonCollection.Add(annotationButton);
        }

        #endregion


        #region Annotations

        /// <summary>
        /// "Build annotation" button is clicked.
        /// </summary>
        private void buildAnnotationButton_Click(object sender, EventArgs e)
        {
            ToolStripItem annotationButton = (ToolStripItem)sender;
            // get the annotation type
            AnnotationType annotationType = _toolStripItemToAnnotationType[annotationButton];

            // if annotation building must be stopped
            if (annotationType == _buildingAnnotationType ||
                (sender is CheckedToolStripSplitButton &&
                ((CheckedToolStripSplitButton)sender).Checked))
            {
                // stop the annotation buiding
                annotationType = AnnotationType.Unknown;
            }

            // add and build annotation
            AddAndBuildAnnotation(annotationType);
        }

        /// <summary> 
        /// Creates an annotation view for specified annotation type.
        /// </summary>
        /// <param name="annotationType">The annotation type.</param>
        /// <returns>
        /// The annotation view.
        /// </returns>
        private AnnotationView CreateAnnotationView(AnnotationType annotationType)
        {
            AnnotationData data = null;
            AnnotationView view = null;

            switch (annotationType)
            {
                case AnnotationType.Rectangle:
                    data = new RectangleAnnotationData();
                    break;

                case AnnotationType.CloudRectangle:
                    view = CreateAnnotationView(AnnotationType.Rectangle);
                    SetLineStyle(view, AnnotationLineStyle.Cloud);
                    break;

                case AnnotationType.Ellipse:
                    data = new EllipseAnnotationData();
                    break;

                case AnnotationType.CloudEllipse:
                    view = CreateAnnotationView(AnnotationType.Ellipse);
                    SetLineStyle(view, AnnotationLineStyle.Cloud);
                    break;

                case AnnotationType.Highlight:
                    data = new HighlightAnnotationData();
                    break;

                case AnnotationType.CloudHighlight:
                    view = CreateAnnotationView(AnnotationType.Highlight);
                    SetLineStyle(view, AnnotationLineStyle.Cloud);
                    break;

                case AnnotationType.FreehandHighlight:
                    view = CreateAnnotationView(AnnotationType.FreehandLines);
                    LinesAnnotationView linesView = (LinesAnnotationView)view;
                    linesView.BlendingMode = BlendingMode.Multiply;
                    linesView.Outline.Width = 12;
                    linesView.Outline.Color = Color.Yellow;
                    break;

                case AnnotationType.PolygonHighlight:
                    view = CreateAnnotationView(AnnotationType.Polygon);
                    PolygonAnnotationView polygonView = (PolygonAnnotationView)view;
                    polygonView.Border = false;
                    polygonView.BlendingMode = BlendingMode.Multiply;
                    polygonView.FillBrush = new AnnotationSolidBrush(Color.Yellow);
                    break;

                case AnnotationType.FreehandPolygonHighlight:
                    view = CreateAnnotationView(AnnotationType.FreehandPolygon);
                    PolygonAnnotationView freehandPolygonView = (PolygonAnnotationView)view;
                    freehandPolygonView.Border = false;
                    freehandPolygonView.BlendingMode = BlendingMode.Multiply;
                    freehandPolygonView.FillBrush = new AnnotationSolidBrush(Color.Yellow);
                    break;

                case AnnotationType.TextHighlight:
                    HighlightAnnotationData textHighlight = new HighlightAnnotationData();
                    textHighlight.Border = false;
                    textHighlight.Outline.Color = Color.Yellow;
                    textHighlight.FillBrush = new AnnotationSolidBrush(Color.FromArgb(255, 255, 128));
                    textHighlight.BlendingMode = BlendingMode.Multiply;
                    data = textHighlight;
                    break;

                case AnnotationType.ReferencedImage:
                    if (string.IsNullOrEmpty(_embeddedOrReferencedImageFileName))
                        _embeddedOrReferencedImageFileName = GetImageFilePath();

                    ReferencedImageAnnotationData referencedImage = new ReferencedImageAnnotationData();
                    referencedImage.Filename = _embeddedOrReferencedImageFileName;
                    data = referencedImage;
                    break;

                case AnnotationType.EmbeddedImage:
                    if (string.IsNullOrEmpty(_embeddedOrReferencedImageFileName))
                        _embeddedOrReferencedImageFileName = GetImageFilePath();

                    try
                    {
                        VintasoftImage embeddedImage = new VintasoftImage(_embeddedOrReferencedImageFileName, true);

                        data = new EmbeddedImageAnnotationData(embeddedImage, true);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage("Embedded annotation", ex);
                        return null;
                    }
                    break;

                case AnnotationType.Text:
                    TextAnnotationData text = new TextAnnotationData();
                    text.Text = "Text";
                    data = text;
                    break;

                case AnnotationType.CloudText:
                    view = CreateAnnotationView(AnnotationType.Text);
                    SetLineStyle(view, AnnotationLineStyle.Cloud);
                    break;

                case AnnotationType.StickyNote:
                    StickyNoteAnnotationData stickyNote = new StickyNoteAnnotationData();
                    stickyNote.FillBrush = new AnnotationSolidBrush(Color.Yellow);
                    data = stickyNote;
                    break;

                case AnnotationType.FreeText:
                    FreeTextAnnotationData freeText = new FreeTextAnnotationData();
                    freeText.Text = "Free Text";
                    data = freeText;
                    break;

                case AnnotationType.CloudFreeText:
                    view = CreateAnnotationView(AnnotationType.FreeText);
                    SetLineStyle(view, AnnotationLineStyle.Cloud);
                    break;

                case AnnotationType.RubberStamp:
                    StampAnnotationData stamp = new StampAnnotationData();
                    stamp.Text = "Rubber stamp";
                    data = stamp;
                    break;

                case AnnotationType.Link:
                    data = new LinkAnnotationData();
                    break;

                case AnnotationType.Arrow:
                    data = new ArrowAnnotationData();
                    break;

                case AnnotationType.DoubleArrow:
                    ArrowAnnotationData doubleArrow = new ArrowAnnotationData();
                    doubleArrow.BothCaps = true;
                    data = doubleArrow;
                    break;

                case AnnotationType.Line:
                    data = new LineAnnotationData();
                    break;

                case AnnotationType.Lines:
                    data = new LinesAnnotationData();
                    break;

                case AnnotationType.CloudLines:
                    view = CreateAnnotationView(AnnotationType.Lines);
                    SetLineStyle(view, AnnotationLineStyle.Cloud);
                    break;

                case AnnotationType.TriangleLines:
                    view = CreateAnnotationView(AnnotationType.Lines);
                    SetLineStyle(view, AnnotationLineStyle.Triangle);
                    break;

                case AnnotationType.LinesWithInterpolation:
                    LinesAnnotationData lines = new LinesAnnotationData();
                    lines.UseInterpolation = true;
                    data = lines;
                    break;

                case AnnotationType.CloudLinesWithInterpolation:
                    view = CreateAnnotationView(AnnotationType.LinesWithInterpolation);
                    SetLineStyle(view, AnnotationLineStyle.Cloud);
                    break;

                case AnnotationType.FreehandLines:
                    view = AnnotationViewFactory.CreateView(new LinesAnnotationData());
                    PointBasedAnnotationFreehandBuilder builder =
                        new PointBasedAnnotationFreehandBuilder((IPointBasedAnnotation)view, 1, 1);
                    builder.FinishBuildingByDoubleMouseClick = false;
                    view.Builder = builder;
                    break;

                case AnnotationType.Polygon:
                    data = new PolygonAnnotationData();
                    break;

                case AnnotationType.CloudPolygon:
                    view = CreateAnnotationView(AnnotationType.Polygon);
                    SetLineStyle(view, AnnotationLineStyle.Cloud);
                    break;

                case AnnotationType.TrianglePolygon:
                    view = CreateAnnotationView(AnnotationType.Polygon);
                    SetLineStyle(view, AnnotationLineStyle.Triangle);
                    break;

                case AnnotationType.PolygonWithInterpolation:
                    PolygonAnnotationData polygonWithInterpolation = new PolygonAnnotationData();
                    polygonWithInterpolation.UseInterpolation = true;
                    data = polygonWithInterpolation;
                    break;

                case AnnotationType.CloudPolygonWithInterpolation:
                    view = CreateAnnotationView(AnnotationType.PolygonWithInterpolation);
                    SetLineStyle(view, AnnotationLineStyle.Cloud);
                    break;

                case AnnotationType.FreehandPolygon:
                    view = AnnotationViewFactory.CreateView(new PolygonAnnotationData());
                    view.Builder = new PointBasedAnnotationFreehandBuilder((IPointBasedAnnotation)view, 2, 1);
                    break;

                case AnnotationType.Ruler:
                    data = new RulerAnnotationData();
                    break;

                case AnnotationType.Rulers:
                    data = new RulersAnnotationData();
                    break;

                case AnnotationType.Angle:
                    data = new AngleAnnotationData();
                    break;

                case AnnotationType.Triangle:
                    data = new TriangleAnnotationData();
                    break;

                case AnnotationType.CloudTriangle:
                    view = CreateAnnotationView(AnnotationType.Triangle);
                    SetLineStyle(view, AnnotationLineStyle.Cloud);
                    break;

                case AnnotationType.Mark:
                    data = new MarkAnnotationData();
                    break;

                case AnnotationType.Arc:
                    data = new ArcAnnotationData();
                    break;

                case AnnotationType.ArcWithArrow:
                    data = new ArcAnnotationData();
                    data.Outline.StartCap.Style = LineCapStyles.Arrow;
                    break;

                case AnnotationType.ArcWithDoubleArrow:
                    data = new ArcAnnotationData();
                    data.Outline.StartCap.Style = LineCapStyles.Arrow;
                    data.Outline.EndCap.Style = LineCapStyles.Arrow;
                    break;

                default:
                    return null;
            }

            // if the annotation view is created
            if (view != null)
                return view;

            // create the annotation view for specified annotation data
            return AnnotationViewFactory.CreateView(data);
        }

        /// <summary>
        /// Subscribes to the link annotation view events.
        /// </summary>
        /// <param name="linkView">The link view.</param>
        private void SubscribeToLinkAnnotationViewEvents(LinkAnnotationView linkView)
        {
            linkView.LinkClicked += new EventHandler<AnnotationLinkClickedEventArgs>(OnLinkClicked);
        }

        /// <summary>
        /// Unsubscribes from the link annotation view events.
        /// </summary>
        /// <param name="linkView">The link view.</param>
        private void UnsubscribeFromLinkAnnotationViewEvents(LinkAnnotationView linkView)
        {
            linkView.LinkClicked -= OnLinkClicked;
        }

        /// <summary>
        /// Opens the link of link annotation.
        /// </summary>
        private void OnLinkClicked(object sender, AnnotationLinkClickedEventArgs e)
        {
            // open the link
            Process.Start("iexplore.exe", e.LinkText);
        }

        /// <summary>
        /// Ends the annotation building.
        /// </summary>
        private void EndAnnotationBuilding()
        {
            _buildingAnnotationType = AnnotationType.Unknown;

            SelectAnnotationButton(AnnotationType.Unknown);
        }

        #endregion


        #region Annotation viewer

        /// <summary>
        /// Subscribes to the annotation viewer events.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        private void SubscribeToAnnotationViewerEvents(AnnotationViewer annotationViewer)
        {
            if (annotationViewer == null)
                return;

            annotationViewer.FocusedIndexChanging +=
                new EventHandler<FocusedIndexChangedEventArgs>(annotationViewer_FocusedIndexChanging);

            annotationViewer.AnnotationInteractionModeChanging +=
                new EventHandler<AnnotationInteractionModeChangingEventArgs>(annotationViewer_AnnotationInteractionModeChanging);
            annotationViewer.AnnotationViewCollectionChanged +=
                new EventHandler<AnnotationViewCollectionChangedEventArgs>(annotationViewer_AnnotationViewCollectionChanged);

            annotationViewer.AnnotationBuildingFinished +=
                new EventHandler<AnnotationViewEventArgs>(annotationViewer_AnnotationBuildingFinished);
            annotationViewer.AnnotationBuildingCanceled +=
                new EventHandler<AnnotationViewEventArgs>(annotationViewer_AnnotationBuildingCanceled);
        }

        /// <summary>
        /// Unsubscribes from the annotation viewer events.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        private void UnsubscribeFromAnnotationViewerEvents(AnnotationViewer annotationViewer)
        {
            if (annotationViewer == null)
                return;

            annotationViewer.FocusedIndexChanging -= annotationViewer_FocusedIndexChanging;

            annotationViewer.AnnotationInteractionModeChanging -= annotationViewer_AnnotationInteractionModeChanging;
            annotationViewer.AnnotationViewCollectionChanged -= annotationViewer_AnnotationViewCollectionChanged;

            annotationViewer.AnnotationBuildingFinished -= annotationViewer_AnnotationBuildingFinished;
            annotationViewer.AnnotationBuildingCanceled -= annotationViewer_AnnotationBuildingCanceled;
        }

        /// <summary>
        /// Annotation building is canceled.
        /// </summary>
        private void annotationViewer_AnnotationBuildingCanceled(object sender, AnnotationViewEventArgs e)
        {
            if (_isInteractionModeChanging)
                return;

            _embeddedOrReferencedImageFileName = string.Empty;
            EndAnnotationBuilding();
        }

        /// <summary>
        /// Annotation building is finished.
        /// </summary>
        private void annotationViewer_AnnotationBuildingFinished(object sender, AnnotationViewEventArgs e)
        {
            // if annotation view collection is not specified
            if (AnnotationViewer.AnnotationViewCollection == null)
            {
                EndAnnotationBuilding();
                return;
            }

            if (!AnnotationViewer.AnnotationViewCollection.Contains(e.AnnotationView))
                return;

            // if buiding annotation type is specified
            if (_buildingAnnotationType != AnnotationType.Unknown)
            {
                // if building annotation is "Freehand lines"
                if (_buildingAnnotationType == AnnotationType.FreehandLines)
                {
                    // if annotation has less than 2 points
                    if (((LinesAnnotationData)e.AnnotationView.Data).Points.Count < 2)
                    {
                        // cancel the annotation building
                        AnnotationViewer.CancelAnnotationBuilding();
                        _buildingAnnotationType = AnnotationType.FreehandLines;
                    }
                }

                // if next annotation should be built
                if (AnnotationViewer.AnnotationInteractionMode == AnnotationInteractionMode.Author &&
                    NeedBuildAnnotationsContinuously)
                {
                    // if interaction controller of focused annotation must be changed
                    if (AnnotationViewer.FocusedAnnotationView != null)
                    {
                        // set transformer as interaction controller to the focused annotation view
                        AnnotationViewer.FocusedAnnotationView.InteractionController =
                            AnnotationViewer.FocusedAnnotationView.Transformer;
                    }

                    // build next annotation
                    AddAndBuildAnnotation(_buildingAnnotationType);
                }
                else
                {
                    // clear file name of refereced image annotation
                    _embeddedOrReferencedImageFileName = string.Empty;

                    // stop building
                    EndAnnotationBuilding();
                }
            }
        }

        /// <summary>
        /// Interaction mode of annotation is changing.
        /// </summary>
        private void annotationViewer_AnnotationInteractionModeChanging(
            object sender,
            AnnotationInteractionModeChangingEventArgs e)
        {
            // cancel the annotation building
            AnnotationViewer.CancelAnnotationBuilding();
        }

        /// <summary>
        /// Annotation view collection is changed.
        /// </summary>
        private void annotationViewer_AnnotationViewCollectionChanged(
            object sender,
            AnnotationViewCollectionChangedEventArgs e)
        {
            // is previous annotation collection exists
            if (e.OldValue != null)
            {
                // for each annotation in previous annotation collection
                foreach (AnnotationView annotationView in e.OldValue)
                {
                    // if annotation is link annotation
                    if (annotationView is LinkAnnotationView)
                    {
                        // unsubscribe from the Link annotation events
                        UnsubscribeFromLinkAnnotationViewEvents((LinkAnnotationView)annotationView);
                    }
                }
            }

            // is new annotation collection exists
            if (e.NewValue != null)
            {
                // for each annotation in new annotation collection
                foreach (AnnotationView annotationView in e.NewValue)
                {
                    // if annotation is link annotation
                    if (annotationView is LinkAnnotationView)
                    {
                        // subscribe to the Link annotation events
                        SubscribeToLinkAnnotationViewEvents((LinkAnnotationView)annotationView);
                    }
                }
            }
        }

        /// <summary>
        /// Focused image is changing in viewer.
        /// </summary>
        private void annotationViewer_FocusedIndexChanging(object sender, FocusedIndexChangedEventArgs e)
        {
            // get the annotation tool
            AnnotationVisualTool annotationVisualTool = AnnotationViewer.AnnotationVisualTool;
            if (annotationVisualTool != null)
            {
                // if viewer has focused annotation
                if (annotationVisualTool.FocusedAnnotationView != null)
                {
                    // if focused annotation is building
                    if (annotationVisualTool.FocusedAnnotationView.IsBuilding)
                    {
                        // cancel the annotation building
                        annotationVisualTool.CancelAnnotationBuilding();
                    }
                }
            }
        }

        #endregion


        #region Common

        /// <summary>
        /// Returns a path to an image file.
        /// </summary>
        /// <returns>
        /// A path to an image file.
        /// </returns>
        private string GetImageFilePath()
        {
            // if dialog is not created
            if (_openImageDialog == null)
            {
                // create dialog
                _openImageDialog = new OpenFileDialog();
                // set the available image formats
                CodecsFileFilters.SetFilters(_openImageDialog);
            }

            string result = null;
            // if image file is selected
            if (_openImageDialog.ShowDialog() == DialogResult.OK)
                result = _openImageDialog.FileName;

            return result;
        }

        /// <summary>
        /// Selects the button of specified annotation type.
        /// </summary>
        /// <param name="annotationType">The annotation type.</param>
        private void SelectAnnotationButton(AnnotationType annotationType)
        {
            // if previous button exists
            if (_checkedAnnotationButton != null)
            {
                // uncheck the previous button
                SetAnnotationButtonCheckState(_checkedAnnotationButton, false);
                _checkedAnnotationButton = null;
            }

            // if button must be checked
            if (annotationType != AnnotationType.Unknown)
            {
                // get the button for check
                _checkedAnnotationButton = _annotationTypeToToolStripItem[annotationType];
                // check the button
                SetAnnotationButtonCheckState(_checkedAnnotationButton, true);
            }
        }

        /// <summary>
        /// Sets the checked state of annotation button.
        /// </summary>
        /// <param name="annotationButton">The annotation button.</param>
        /// <param name="isAnnotationButtonChecked">Indicates that annotation button is checked.</param>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if ckecked property of <i>item</i> is not found.
        /// </exception>
        private void SetAnnotationButtonCheckState(ToolStripItem annotationButton, bool isAnnotationButtonChecked)
        {
            if (annotationButton is ToolStripButton)
                ((ToolStripButton)annotationButton).Checked = isAnnotationButtonChecked;
            else if (annotationButton is CheckedToolStripSplitButton)
                ((CheckedToolStripSplitButton)annotationButton).Checked = isAnnotationButtonChecked;
            else if (annotationButton is ToolStripMenuItem)
                ((ToolStripMenuItem)annotationButton).Checked = isAnnotationButtonChecked;
            else
                throw new NotImplementedException();

            if (annotationButton.OwnerItem != null)
                SetAnnotationButtonCheckState(annotationButton.OwnerItem, isAnnotationButtonChecked);
        }

        /// <summary>
        /// Sets the annotation line style.
        /// </summary>
        /// <param name="view">The view of annotation.</param>
        /// <param name="lineStyle">The line style.</param>
        private void SetLineStyle(AnnotationView view, AnnotationLineStyle lineStyle)
        {
            if (view == null)
                return;

            if (view is RectangleAnnotationView)
                ((RectangleAnnotationView)view).LineStyle = lineStyle;
            else if (view is LinesAnnotationView)
                ((LinesAnnotationView)view).LineStyle = lineStyle;
            else if (view is PolygonAnnotationView)
                ((PolygonAnnotationView)view).LineStyle = lineStyle;
            else if (view is TextAnnotationView)
                ((TextAnnotationView)view).LineStyle = lineStyle;
            else if (view is FreeTextAnnotationView)
                ((FreeTextAnnotationView)view).LineStyle = lineStyle;
        }

        #endregion

        #endregion

        #endregion

    }
}
