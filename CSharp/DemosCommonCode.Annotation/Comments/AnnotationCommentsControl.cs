using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Annotation.Comments;
using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Annotation.UI.Comments;
using Vintasoft.Imaging.Annotation.UI.VisualTools;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Represents a user control that displays annotation comments of focused page in image viewer.
    /// </summary>
    public partial class AnnotationCommentsControl : UserControl
    {

        #region Fields

        /// <summary>
        /// The annotation comment builder.
        /// </summary>
        AnnotationCommentBuilder _annotationCommentBuilder;

        /// <summary>
        /// A value indicating whether the comment tool was enabled (<see cref="CommentVisualTool.IsEnabled"/>) before annotation building is started.
        /// </summary>
        bool _commentToolEnabledBeforeAnnotationBuilding = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnotationCommentsControl"/> class.
        /// </summary>
        public AnnotationCommentsControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the image viewer.
        /// </summary>
        public ImageViewer ImageViewer
        {
            get
            {
                return commentsControl1.ImageViewer;
            }
            set
            {
                commentsControl1.ImageViewer = value;
            }
        }

        AnnotationVisualTool _annotationTool;
        /// <summary>
        /// Gets or sets the PDF annotation tool.
        /// </summary>
        public AnnotationVisualTool AnnotationTool
        {
            get
            {
                return _annotationTool;
            }
            set
            {
                if (_annotationTool != null)
                {
                    _annotationTool.AnnotationBuildingStarted -= AnnotationTool_AnnotationBuildingStarted;
                    _annotationTool.AnnotationBuildingFinished -= AnnotationTool_AnnotationBuildingFinished;
                    _annotationTool.FocusedAnnotationViewChanged -= AnnotationTool_FocusedAnnotationViewChanged;
                    _annotationTool.MouseDoubleClick -= AnnotationTool_MouseDoubleClick;
                }

                _annotationTool = value;

                if (_annotationTool != null)
                {
                    _annotationTool.AnnotationBuildingStarted += AnnotationTool_AnnotationBuildingStarted;
                    _annotationTool.AnnotationBuildingFinished += AnnotationTool_AnnotationBuildingFinished;
                    _annotationTool.FocusedAnnotationViewChanged += AnnotationTool_FocusedAnnotationViewChanged;
                    _annotationTool.MouseDoubleClick += AnnotationTool_MouseDoubleClick;
                }

                UpdateUI();

                UpdateAnnotationCommentBuilder();
            }
        }

        /// <summary>
        /// Gets or sets the comment visual tool.
        /// </summary>
        public CommentVisualTool CommentTool
        {
            get
            {
                return commentsControl1.CommentTool;
            }
            set
            {
                if (value != null)
                {
                    commentsControl1.CommentTool = value;
                    commentsControl1.CommentController = value.CommentController;

                    // disable selection of comments in viewer using mouse because this control controls selection of comments by yourself
                    value.SelectCommentControlOnMouseClick = false;
                    value.SelectCommentControlOnMouseDoubleClick = false;
                }
                else
                {
                    commentsControl1.CommentTool = null;
                    commentsControl1.CommentController = null;
                }

                UpdateUI();

                UpdateAnnotationCommentBuilder();
            }
        }

        /// <summary>
        /// Gets a value indicating whether comments are visible on image viewer.
        /// </summary>
        public bool IsCommentsOnViewerVisible
        {
            get
            {
                return commentsControl1.IsCommentsOnViewerVisible;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Updates the user interface of this control.
        /// </summary>
        private void UpdateUI()
        {
            if (AnnotationTool == null || CommentTool == null)
            {
                mainPanel.Enabled = false;
            }
            else
            {
                mainPanel.Enabled = true;

                bool isAnnotationFocused = AnnotationTool.FocusedAnnotationView != null;
                bool isInteractionModeAuthor = AnnotationTool.AnnotationInteractionMode == AnnotationInteractionMode.Author;
                bool isCommentSelected = isAnnotationFocused && AnnotationTool.FocusedAnnotationView.Data.Comment != null;

                addNewCommentButton.Enabled = isInteractionModeAuthor;
                removeCommentFromAnnotationButton.Enabled = isAnnotationFocused && isCommentSelected && isInteractionModeAuthor;
                addCommentToAnnotationButton.Enabled = isAnnotationFocused && isInteractionModeAuthor;
            }
        }

        /// <summary>
        /// Updates the annotation comment builder.
        /// </summary>
        private void UpdateAnnotationCommentBuilder()
        {
            if (CommentTool != null && AnnotationTool != null)
                _annotationCommentBuilder = new AnnotationCommentBuilder(CommentTool, AnnotationTool);
            else
                _annotationCommentBuilder = null;
        }

        /// <summary>
        /// "Add New Comment" button is clicked.
        /// </summary>
        private void addNewCommentButton_Click(object sender, EventArgs e)
        {
            if (CommentTool.Enabled)
            {
                _annotationCommentBuilder.AddNewComment();

                UpdateUI();
            }
        }

        /// <summary>
        /// "Add Comment To Annotation" button is clicked.
        /// </summary>
        private void addCommentToAnnotationButton_Click(object sender, EventArgs e)
        {
            if (CommentTool.Enabled)
            {
                _annotationCommentBuilder.AddCommentToAnnotation(AnnotationTool.FocusedAnnotationView);

                UpdateUI();
            }
        }

        /// <summary>
        /// "Remove Comment From Annotation" button is clicked.
        /// </summary>
        private void removeCommentFromAnnotationButton_Click(object sender, EventArgs e)
        {
            if (CommentTool.Enabled)
            {
                // remove comment from selected annotation
                AnnotationTool.FocusedAnnotationView.Data.Comment.Remove();

                UpdateUI();
            }
        }

        /// <summary>
        /// "Close All Comments" button is clicked.
        /// </summary>
        private void closeAllCommentsButton_Click(object sender, EventArgs e)
        {
            CommentCollection comments =
                CommentTool.CommentController.GetComments(ImageViewer.Image);

            foreach (Comment comment in comments)
                comment.IsOpen = false;
        }

        /// <summary>
        /// Annotation building is started.
        /// </summary>
        private void AnnotationTool_AnnotationBuildingStarted(object sender, AnnotationViewEventArgs e)
        {
            if (commentsControl1.IsCommentsOnViewerVisible &&
                AnnotationTool.AnnotationInteractionMode == AnnotationInteractionMode.Author)
            {
                _commentToolEnabledBeforeAnnotationBuilding = CommentTool.Enabled;

                CommentTool.Enabled = false;

                UpdateUI();
            }
        }

        /// <summary>
        /// Annotation building is finished.
        /// </summary>
        private void AnnotationTool_AnnotationBuildingFinished(object sender, AnnotationViewEventArgs e)
        {
            if (commentsControl1.IsCommentsOnViewerVisible &&
                AnnotationTool.AnnotationInteractionMode == AnnotationInteractionMode.Author)
            {
                CommentTool.Enabled = _commentToolEnabledBeforeAnnotationBuilding;

                UpdateUI();
            }

            SelectComment(e.AnnotationView);
        }

        /// <summary>
        /// Focused annotation is changed.
        /// </summary>
        private void AnnotationTool_FocusedAnnotationViewChanged(object sender, Vintasoft.Imaging.Annotation.UI.AnnotationViewChangedEventArgs e)
        {
            SelectComment(e.NewValue);

            UpdateUI();
        }

        /// <summary>
        /// Mouse is double clicked in viewer.
        /// </summary>
        private void AnnotationTool_MouseDoubleClick(object sender, Vintasoft.Imaging.UI.VisualTools.VisualToolMouseEventArgs e)
        {
            if (CommentTool != null && e.Button == AnnotationTool.ActionButton)
            {
                // find annnotation view
                AnnotationView view = AnnotationTool.FindAnnotationView(e.X, e.Y);

                // if annotation contains the annotation
                if (view != null && view.Data.Comment != null)
                {
                    // get annotation comment
                    Comment comment = view.Data.Comment;
                    // find comment control
                    ICommentControl commentControl = CommentTool.FindCommentControl(comment);

                    // if comment control is found
                    if (commentControl != null)
                    {
                        if (CommentTool.SelectedComment != commentControl)
                            CommentTool.SelectedComment = commentControl;

                        // open comment
                        comment.IsOpen = true;
                    }
                }
            }
        }

        /// <summary>
        /// Selects the comment of specified annotation view.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SelectComment(AnnotationView view)
        {
            if (view == null)
            {
                CommentTool.SelectedComment = null;
            }
            else
            {
                if (view.Data.Comment != null)
                    CommentTool.SelectedComment = CommentTool.FindCommentControl(view.Data.Comment);
            }
        }

        #endregion

    }
}
