using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Annotation.UI.VisualTools;
using Vintasoft.Imaging.Annotation.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.UI.WinForms.Controls;

using DemosCommonCode.CustomControls;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Imaging;
#if !REMOVE_OFFICE_PLUGIN
using DemosCommonCode.Office;
#endif
using Vintasoft.Imaging.Codecs.Decoders;

#if !REMOVE_OFFICE_PLUGIN
using Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Office.OpenXml.Editor;
#endif

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// A Windows toolbar that allows to add annotations to an image in viewer.
    /// </summary>
    public class AnnotationsToolStrip : ToolStrip
    {

        #region Nested classes

        /// <summary>
        /// Contains information about button.
        /// </summary>
        private abstract class ButtonInfo
        {

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ButtonInfo"/> class.
            /// </summary>
            /// <param name="name">The button name.</param>
            /// <param name="dropDownItems">The drop down items of button.</param>
            internal ButtonInfo(string name, params ButtonInfo[] dropDownItems)
            {
                _name = name;
                _dropDownItems = dropDownItems;
            }

            #endregion



            #region Properties

            string _name = string.Empty;
            /// <summary>
            /// Gets the button name.
            /// </summary>
            internal string Name
            {
                get
                {
                    return _name;
                }
            }

            ButtonInfo[] _dropDownItems;
            /// <summary>
            /// Gets the drop down items of button.
            /// </summary>
            internal ButtonInfo[] DropDownItems
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
            /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
            public override string ToString()
            {
                return Name;
            }

            #endregion

        }

        /// <summary>
        /// Contains information about separator.
        /// </summary>
        private class SeparatorButtonInfo : ButtonInfo
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="SeparatorButtonInfo"/> class.
            /// </summary>
            internal SeparatorButtonInfo()
                : base("SEPARATOR")
            {
            }

        }

        /// <summary>
        /// Contains information about annotation button.
        /// </summary>
        private class AnnotationButtonInfo : ButtonInfo
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="AnnotationButtonInfo"/> class.
            /// </summary>
            /// <param name="annotationType">The annotation type.</param>
            /// <param name="dropDownItems">The drop down items of annotation button.</param>
            internal AnnotationButtonInfo(
                AnnotationType annotationType,
                params ButtonInfo[] dropDownItems)
                : base(AnnotationNameFactory.GetAnnotationName(annotationType), dropDownItems)
            {
                _annotationType = annotationType;
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

        }

        /// <summary>
        /// Contains information about custom button.
        /// </summary>
        private class CustomButtonInfo : ButtonInfo
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomButtonInfo"/> class.
            /// </summary>
            /// <param name="name">The button name.</param>
            /// <param name="iconName">The button icon name.</param>
            /// <param name="buttonClickHandler">The button click event handler.</param>
            /// <param name="dropDownItems">The drop down items of button.</param>
            internal CustomButtonInfo(
                string name,
                string iconName,
                EventHandler buttonClickHandler,
                params ButtonInfo[] dropDownItems)
                : base(name, dropDownItems)
            {
                _iconName = iconName;
                _buttonClickHandler = buttonClickHandler;
            }



            string _iconName;
            /// <summary>
            /// Gets the button icon name.
            /// </summary>
            internal string IconName
            {
                get
                {
                    return _iconName;
                }
            }

            EventHandler _buttonClickHandler;
            /// <summary>
            /// Gets the button click event handler.
            /// </summary>
            internal EventHandler ButtonClickHandler
            {
                get
                {
                    return _buttonClickHandler;
                }
            }

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
        /// Dictionary: annotation data => annotation view.
        /// </summary>
        Dictionary<AnnotationData, AnnotationView> _annotationDataToAnnotationView =
            new Dictionary<AnnotationData, AnnotationView>();

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
            InitializeButtons();

            AnnotationViewer = null;
        }

        #endregion



        #region Properties

        AnnotationViewer _annotationViewer;
        /// <summary>
        /// Gets or sets the <see cref="AnnotationViewer"/>, which is associated with
        /// this <see cref="AnnotationsToolStrip"/>.
        /// </summary>        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

        AnnotationCommentBuilder _commentBuilder = null;
        /// <summary>
        /// Gets or sets the comment builder.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public AnnotationCommentBuilder CommentBuilder
        {
            get
            {
                return _commentBuilder;
            }
            set
            {
                _commentBuilder = value;
            }
        }

        bool _needBuildAnnotationsContinuously = false;
        /// <summary>
        /// Gets or sets a value indicating whether the annotations must be built continuously.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
                }
                else
                {
                    if (annotationType != AnnotationType.Unknown)
                        EndAnnotationBuilding();
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

        #region UI

        /// <summary>
        /// Handles the Click event of buildAnnotationButton object.
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
        /// Handles the Click event of AddNewCommentButton object.
        /// </summary>
        private void AddNewCommentButton_Click(object sender, EventArgs e)
        {
            if (_commentBuilder != null &&
                _commentBuilder.CommentVisualTool != null &&
                _commentBuilder.CommentVisualTool.Enabled)
                _commentBuilder.AddNewComment();
        }

        /// <summary>
        /// Handles the Click event of AddCommentToAnnotationButton object.
        /// </summary>
        private void AddCommentToAnnotationButton_Click(object sender, EventArgs e)
        {
            if (_commentBuilder != null &&
                _commentBuilder.CommentVisualTool != null &&
                _commentBuilder.CommentVisualTool.Enabled &&
                AnnotationViewer.FocusedAnnotationData != null)
                _commentBuilder.AddCommentToAnnotation(AnnotationViewer.FocusedAnnotationData);
        }


        #region #region Annotation viewer

        /// <summary>
        /// Handles the AnnotationBuildingCanceled event of annotationViewer object.
        /// </summary>
        private void annotationViewer_AnnotationBuildingCanceled(object sender, AnnotationViewEventArgs e)
        {
            if (_isInteractionModeChanging)
                return;

            _embeddedOrReferencedImageFileName = string.Empty;
            EndAnnotationBuilding();
        }

        /// <summary>
        /// Handles the AnnotationBuildingFinished event of annotationViewer object.
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

#if !REMOVE_OFFICE_PLUGIN
                    // if is chart annotation
                    if (_buildingAnnotationType == AnnotationType.Chart)
                    {
                        e.AnnotationView.InteractionController = e.AnnotationView.Transformer;
                        OfficeDocumentVisualEditor visualEditor = CompositeInteractionController.FindInteractionController<OfficeDocumentVisualEditor>(e.AnnotationView.InteractionController);
                        if (visualEditor != null)
                        {
                            OpenXmlDocumentChartDataForm chartForm = new OpenXmlDocumentChartDataForm();
                            chartForm.Location = FindForm().Location;
                            chartForm.VisualEditor = visualEditor;
                            chartForm.ShowDialog();
                        }
                    }
#endif

                    // stop building
                    EndAnnotationBuilding();
                }

            }
        }

        /// <summary>
        /// Handles the AnnotationInteractionModeChanging event of annotationViewer object.
        /// </summary>
        private void annotationViewer_AnnotationInteractionModeChanging(
            object sender,
            AnnotationInteractionModeChangingEventArgs e)
        {
            // cancel the annotation building
            AnnotationViewer.CancelAnnotationBuilding();
        }

        /// <summary>
        /// Handles the AnnotationViewCollectionChanged event of the AnnotationViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="AnnotationViewCollectionChangedEventArgs"/> instance containing the event data.</param>
        private void annotationViewer_AnnotationViewCollectionChanged(
            object sender,
            AnnotationViewCollectionChangedEventArgs e)
        {
            // is previous annotation collection exists
            if (e.OldValue != null)
            {
                // unsubscribe from annotation collection changed event
                e.OldValue.DataCollection.Changed -= AnnotationDataCollection_Changed;

                // for each annotation in previous annotation collection
                foreach (AnnotationView annotationView in e.OldValue)
                {
                    // unsubscribe from the Link annotation events
                    UnsubscribeFromLinkAnnotationViewEvents(annotationView);
                }
            }

            // is new annotation collection exists
            if (e.NewValue != null)
            {
                // subscribe to annotation collection changed event
                e.NewValue.DataCollection.Changed +=
                    new CollectionChangeEventHandler<AnnotationData>(AnnotationDataCollection_Changed);

                // for each annotation in new annotation collection
                foreach (AnnotationView annotationView in e.NewValue)
                {
                    // subscribe to the Link annotation events
                    SubscribeToLinkAnnotationViewEvents(annotationView);
                }
            }
        }

        /// <summary>
        /// Handles the FocusedIndexChanging event of annotationViewer object.
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

        /// <summary>
        /// Handles the Changed event of the AnnotationDataCollection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CollectionChangeEventArgs{AnnotationData}"/> instance containing the event data.</param>
        private void AnnotationDataCollection_Changed(
            object sender,
            CollectionChangeEventArgs<AnnotationData> e)
        {
            if (e.Action == CollectionChangeActionType.Clear ||
                e.Action == CollectionChangeActionType.ClearAndAddItems)
            {
                foreach (AnnotationView view in _annotationDataToAnnotationView.Values)
                {
                    // unsubscribe from the Link annotation events
                    UnsubscribeFromLinkAnnotationViewEvents(view);
                }

                _annotationDataToAnnotationView.Clear();
            }
            else
            {
                // if annotation was deleted
                if (e.OldValue != null)
                {
                    // if annotation dictionary contains annotation data
                    if (_annotationDataToAnnotationView.ContainsKey(e.OldValue))
                    {
                        // unsubscribe from the Link annotation events
                        UnsubscribeFromLinkAnnotationViewEvents(_annotationDataToAnnotationView[e.OldValue]);

                        // remove annotation data from dictionary
                        _annotationDataToAnnotationView.Remove(e.OldValue);
                    }
                }
            }

            // if annotation was added
            if (e.NewValue != null)
            {
                // get annotation view
                AnnotationView annotationView = _annotationViewer.AnnotationViewCollection.FindView(e.NewValue);

                // if annotation view found
                if (annotationView != null)
                {
                    // add annotation data in the annotation dictionary
                    _annotationDataToAnnotationView.Add(e.NewValue, annotationView);

                    // subscribe to the Link annotation events
                    SubscribeToLinkAnnotationViewEvents(annotationView);
                }
            }
        }

        #endregion

        #endregion


        #region Initialization

        /// <summary>
        /// Initializes the buttons.
        /// </summary>
        private void InitializeButtons()
        {
            // create information about annotation buttons of this tool strip

            ButtonInfo[] buttonInfos = {
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

                // -----
                new SeparatorButtonInfo(),


                // Embedded Image
                new AnnotationButtonInfo(AnnotationType.EmbeddedImage),

                // Referenced Image
                new AnnotationButtonInfo(AnnotationType.ReferencedImage),

                // -----
                new SeparatorButtonInfo(),

                // Empty Document Annotation
                new AnnotationButtonInfo(AnnotationType.EmptyDocument),
                
                // Chart Annotation
                new AnnotationButtonInfo(AnnotationType.Chart),

                // Office Annotation
                new AnnotationButtonInfo(AnnotationType.OfficeDocument),

                // -----
                new SeparatorButtonInfo(),
                

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

                // -----
                new SeparatorButtonInfo(),

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

                // Inc
                new AnnotationButtonInfo(AnnotationType.Ink),

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

                new SeparatorButtonInfo(),


                // Triangle
                new AnnotationButtonInfo(AnnotationType.Triangle,
                    // Triangle -> Cloud Triangle
                    new AnnotationButtonInfo(AnnotationType.CloudTriangle)),

                // Mark
                new AnnotationButtonInfo(AnnotationType.Mark),

                // -----
                new SeparatorButtonInfo(),

                new CustomButtonInfo(
                    "Add New Comment",
                    "AddNewComment",
                    AddNewCommentButton_Click),

                new CustomButtonInfo(
                    "Add New Comment To Annotation",
                    "AddNewCommentToAnnotation",
                    AddCommentToAnnotationButton_Click),
            };

            _toolStripItemToAnnotationType.Clear();
            _annotationTypeToToolStripItem.Clear();

            // initialize the buttons of this tool strip
            InitializeButtons(Items, buttonInfos);
        }

        /// <summary>
        /// Initializes the buttons.
        /// </summary>
        /// <param name="buttonCollection">The button collection to which new button must be added.</param>
        /// <param name="buttonInfos">Information about buttons.</param>
        private void InitializeButtons(ToolStripItemCollection buttonCollection, ButtonInfo[] buttonInfos)
        {
            foreach (ButtonInfo annotationButtonInfo in buttonInfos)
                InitializeButton(buttonCollection, annotationButtonInfo);
        }

        /// <summary>
        /// Creates the button and adds the button to the collection of buttons.
        /// </summary>
        /// <param name="buttonCollection">The button collection to which new button must be added.</param>
        /// <param name="buttonInfo">An information about button.</param>
        private void InitializeButton(ToolStripItemCollection buttonCollection, ButtonInfo buttonInfo)
        {
            ToolStripItem annotationButton = null;

            if (buttonInfo is SeparatorButtonInfo)
            {
                annotationButton = new ToolStripSeparator();
            }
            else if (buttonInfo is AnnotationButtonInfo)
            {
                AnnotationButtonInfo annotationButtonInfo = (AnnotationButtonInfo)buttonInfo;

                AnnotationType annotationType = annotationButtonInfo.AnnotationType;

                annotationButton = CreateButton(
                    buttonCollection,
                    AnnotationNameFactory.GetAnnotationName(annotationType),
                    AnnotationIconNameFactory.GetAnnotationIconName(annotationType),
                    buildAnnotationButton_Click,
                    buttonInfo.DropDownItems);

                _toolStripItemToAnnotationType.Add(annotationButton, annotationType);
                _annotationTypeToToolStripItem.Add(annotationType, annotationButton);
            }
            else if (buttonInfo is CustomButtonInfo)
            {
                CustomButtonInfo customButton = (CustomButtonInfo)buttonInfo;

                annotationButton = CreateButton(
                    buttonCollection,
                    customButton.Name,
                    customButton.IconName,
                    customButton.ButtonClickHandler,
                    customButton.DropDownItems);
            }
            else
            {
                throw new NotImplementedException();
            }

            annotationButton.Tag = buttonInfo;
            buttonCollection.Add(annotationButton);
        }

        /// <summary>
        /// Creates the button.
        /// </summary>
        /// <param name="buttonCollection">The button collection.</param>
        /// <param name="buttonName">The button name.</param>
        /// <param name="buttonIconName">The button icon name.</param>
        /// <param name="buttonClickHandler">The button click event handler.</param>
        /// <param name="children">The button children.</param>
        private ToolStripItem CreateButton(
            ToolStripItemCollection buttonCollection,
            string buttonName,
            string buttonIconName,
            EventHandler buttonClickHandler,
            ButtonInfo[] children)
        {
            ToolStripItemDisplayStyle displayStyle = ToolStripItemDisplayStyle.ImageAndText;

            ToolStripItem button = null;
            if (buttonCollection == Items)
            {
                displayStyle = ToolStripItemDisplayStyle.Image;

                if (children == null || children.Length == 0)
                    button = new ToolStripButton(buttonName);
                else
                    button = new CheckedToolStripSplitButton(buttonName);
            }
            else
            {
                button = new ToolStripMenuItem(buttonName);
            }

            if (children != null && children.Length > 0)
            {
                ToolStripDropDownItem dropDownItem = button as ToolStripDropDownItem;

                if (dropDownItem != null)
                    InitializeButtons(dropDownItem.DropDownItems, children);
            }

            button.ImageTransparentColor = Color.Magenta;
            button.Name = buttonName;
            button.ToolTipText = buttonName;

            if (buttonClickHandler != null)
            {
                ToolStripSplitButton splitButton = button as ToolStripSplitButton;
                if (splitButton != null)
                    splitButton.ButtonClick += new EventHandler(buttonClickHandler);
                else
                    button.Click += new EventHandler(buttonClickHandler);
            }

            if (!string.IsNullOrEmpty(buttonIconName))
            {
                string iconName = buttonIconName;
                if (!Path.HasExtension(iconName))
                    iconName += ".png";
                string pathToIcon = "DemosCommonCode.Annotation.Icons." + iconName;

                button.Image = DemosResourcesManager.GetResourceAsBitmap(pathToIcon);
            }

            button.DisplayStyle = displayStyle;
            button.ImageScaling = ToolStripItemImageScaling.None;

            return button;
        }

        #endregion


        #region Annotations

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

#if !REMOVE_OFFICE_PLUGIN
            Vintasoft.Imaging.Annotation.Office.OfficeAnnotationData officeAnnotation;
#endif

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

#if !REMOVE_OFFICE_PLUGIN

                case AnnotationType.OfficeDocument:
                    try
                    {
                        Stream documentStream = OfficeDemosTools.SelectOfficeDocument();
                        if (documentStream == null)
                            return null;
                        data = new Vintasoft.Imaging.Annotation.Office.OfficeAnnotationData(documentStream, true);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage("Office annotation", ex);
                        return null;
                    }
                    break;

                case AnnotationType.EmptyDocument:
                    officeAnnotation = new Vintasoft.Imaging.Annotation.Office.OfficeAnnotationData(DemosResourcesManager.GetResourceAsStream("EmptyDocument.docx"), true);
                    officeAnnotation.AutoHeight = true;
                    data = officeAnnotation;
                    break;

                case AnnotationType.Chart:
                    try
                    {
                        Stream documentStream = OfficeDemosTools.SelectChartResource();
                        if (documentStream == null)
                            return null;
                        officeAnnotation = new Vintasoft.Imaging.Annotation.Office.OfficeAnnotationData(documentStream, true);
                        officeAnnotation.UseGraphicObjectRelativeSize = true;
                        data = officeAnnotation;
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage("Chart annotation", ex);
                        return null;
                    }
                    break;
#endif

                case AnnotationType.EmbeddedImage:
                    if (string.IsNullOrEmpty(_embeddedOrReferencedImageFileName))
                        _embeddedOrReferencedImageFileName = GetImageFilePath();

                    if (string.IsNullOrEmpty(_embeddedOrReferencedImageFileName))
                        return null;

                    VintasoftImage embeddedImage;
                    try
                    {
                        embeddedImage = new VintasoftImage(_embeddedOrReferencedImageFileName, true);
                    }
                    catch (Exception ex)
                    {
                        _embeddedOrReferencedImageFileName = string.Empty;
                        DemosTools.ShowErrorMessage("Embedded annotation", ex);
                        return null;
                    }

                    data = new EmbeddedImageAnnotationData(embeddedImage, true);
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

                case AnnotationType.Ink:
                    data = new InkAnnotationData();
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
        private void SubscribeToLinkAnnotationViewEvents(AnnotationView view)
        {
            if (view != null)
            {
                if (view is LinkAnnotationView)
                {
                    ((LinkAnnotationView)view).LinkClicked += new EventHandler<AnnotationLinkClickedEventArgs>(OnLinkClicked);
                }
                else if (view is CompositeAnnotationView)
                {
                    foreach (AnnotationView child in (CompositeAnnotationView)view)
                        SubscribeToLinkAnnotationViewEvents(child);
                }
            }
        }

        /// <summary>
        /// Unsubscribes from the link annotation view events.
        /// </summary>
        /// <param name="linkView">The link view.</param>
        private void UnsubscribeFromLinkAnnotationViewEvents(AnnotationView view)
        {
            if (view != null)
            {
                if (view is LinkAnnotationView)
                {
                    ((LinkAnnotationView)view).LinkClicked -= OnLinkClicked;
                }
                else if (view is CompositeAnnotationView)
                {
                    foreach (AnnotationView child in (CompositeAnnotationView)view)
                        UnsubscribeFromLinkAnnotationViewEvents(child);
                }
            }
        }

        /// <summary>
        /// Opens the link of link annotation.
        /// </summary>
        private void OnLinkClicked(object sender, AnnotationLinkClickedEventArgs e)
        {
            // open the link
            DemosTools.OpenBrowser(e.LinkText);
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

            annotationViewer.AnnotationVisualTool.Deactivated += AnnotationVisualTool_Deactivated;
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

            annotationViewer.AnnotationVisualTool.Deactivated -= AnnotationVisualTool_Deactivated;
        }

        /// <summary>
        /// Annotation visual tool is deactivated.
        /// </summary>
        private void AnnotationVisualTool_Deactivated(object sender, EventArgs e)
        {
            EndAnnotationBuilding();
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
                CodecsFileFilters.SetOpenFileDialogFilter(_openImageDialog);
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
