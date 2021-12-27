using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI;

#if !REMOVE_ANNOTATION_PLUGIN
using Vintasoft.Imaging.Annotation.Comments;
using Vintasoft.Imaging.Annotation.UI.VisualTools;
using Vintasoft.Imaging.Annotation.UI.Comments;
#endif

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Represents a user control that displays comments of focused page of image viewer.
    /// </summary>
    public partial class CommentsControl : UserControl
    {

        #region Contructors

#if !REMOVE_ANNOTATION_PLUGIN
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsControl"/> class.
        /// </summary>
        public CommentsControl()
        {
            InitializeComponent();
        }
#endif

        #endregion



        #region Properties

        ImageViewer _imageViewer;
        /// <summary>
        /// Gets or sets the image viewer.
        /// </summary>
        public ImageViewer ImageViewer
        {
            get
            {
                return _imageViewer;
            }
            set
            {
                if (_imageViewer != value)
                {
                    if (_imageViewer != null)
                    {
                        _imageViewer.FocusedIndexChanged -= ImageViewer_FocusedIndexChanged;
                    }
                    _imageViewer = value;
                    if (_imageViewer != null)
                    {
                        _imageViewer.FocusedIndexChanged += ImageViewer_FocusedIndexChanged;
                    }
#if !REMOVE_ANNOTATION_PLUGIN
                    if (_commentController != null)
                        _commentController.ImageViewer = ImageViewer;

                    UpdateComments();
#endif
                }
            }
        }

#if !REMOVE_ANNOTATION_PLUGIN
        CommentCollection _comments;
        /// <summary>
        /// Gets the comments that displayed in control.
        /// </summary>
        public CommentCollection Comments
        {
            get
            {
                return _comments;
            }
        }


        ImageViewerCommentController _commentController;
        /// <summary>
        /// Gets or sets the comment controller.
        /// </summary>
        [DefaultValue((object)null)]
        public ImageViewerCommentController CommentController
        {
            get
            {
                return _commentController;
            }
            set
            {
                if (_commentController != null)
                {
                    _commentController.ImageCommentsChanged -= CommentController_ImageCommentsChanged;
                }

                _commentController = value;

                if (_commentController != null)
                {
                    _commentController.ImageCommentsChanged += CommentController_ImageCommentsChanged;
                    _commentController.ImageViewer = ImageViewer;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether comments are visible on image viewer.
        /// </summary>
        public bool IsCommentsOnViewerVisible
        {
            get
            {
                return visibleOnViewerCheckBox.Checked;
            }
        }

        CommentVisualTool _commentTool;
        /// <summary>
        /// Gets or sets the comment visual tool.
        /// </summary>
        [DefaultValue((object)null)]
        public virtual CommentVisualTool CommentTool
        {
            get
            {
                return _commentTool;
            }
            set
            {
                _commentTool = value;
                if (value != null)
                {
                    visibleOnViewerCheckBox.Enabled = true;
                    visibleOnViewerCheckBox.Checked = value.Enabled;
                }
                else
                {
                    visibleOnViewerCheckBox.Enabled = false;
                    visibleOnViewerCheckBox.Checked = false;
                }
            }
        }
#endif

        #endregion



        #region Methods

#if !REMOVE_ANNOTATION_PLUGIN

        #region PUBLIC

        /// <summary>
        /// Searches the comment control for specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        public ICommentControl FindCommentControl(Comment comment)
        {
            foreach (ICommentControl control in commentsLayoutPanel.Controls)
            {
                ICommentControl result = control.FindCommentControl(comment);
                if (result != null)
                    return result;
            }
            return null;
        }

        /// <summary>
        /// Searches the comment control for specified comment source.
        /// </summary>
        /// <param name="source">The comment source.</param>
        public ICommentControl FindControlCommentBySource(object source)
        {
            foreach (ICommentControl control in commentsLayoutPanel.Controls)
            {
                Comment comment = control.Comment.FindCommentBySource(source);
                if (comment != null)
                {
                    ICommentControl result = control.FindCommentControl(comment);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Raises the <see cref="E:SizeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SuspendLayout();
            foreach (Control control in commentsLayoutPanel.Controls)
                SetCommentControlSize(control);
            ResumeLayout();
        }

        #endregion
#endif

        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the IsCommentSelectedChanged event of CommentControl object.
        /// </summary>
        private void CommentControl_IsCommentSelectedChanged(object sender, PropertyChangedEventArgs<bool> e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            if (CommentTool != null)
            {
                // get comment control
                ICommentControl control = CommentTool.FindCommentControl(((CommentControl)sender).Comment);
                // if comment control is found
                if (control != null)
                {
                    // if comment must be selected
                    if (e.NewValue)
                        // select the comment
                        control.IsCommentSelected = true;
                    else
                        // deselect the comment
                        control.IsCommentSelected = false;
                }
            }
#endif
        }

        /// <summary>
        /// Handles the CheckedChanged event of VisibleOnViewerCheckBox object.
        /// </summary>
        private void visibleOnViewerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            if (CommentTool != null)
            {
                // if comments must he shown
                if (visibleOnViewerCheckBox.Checked)
                    // show the comments
                    CommentTool.Enabled = true;
                else
                    // hide the comments
                    CommentTool.Enabled = false;
            }
#endif
        }

#endregion


#if !REMOVE_ANNOTATION_PLUGIN
        /// <summary>
        /// Handles the ImageCommentsChanged event of the CommentController.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageEventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void CommentController_ImageCommentsChanged(object sender, ImageEventArgs e)
        {
            if (e.Image == ImageViewer.Image)
                UpdateComments();
        }
#endif

        /// <summary>
        /// Handles the FocusedIndexChanged event of the ImageViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FocusedIndexChangedEventArgs"/> instance containing the event data.</param>
        private void ImageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            UpdateComments();
#endif
        }

#if !REMOVE_ANNOTATION_PLUGIN
        /// <summary>
        /// Handles the Comments.Changed event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CollectionChangeEventArgs{Comment}"/> instance containing the event data.</param>
        private void Comments_Changed(object sender, CollectionChangeEventArgs<Comment> e)
        {
            if (InvokeRequired)
            {
                Invoke(new CollectionChangeEventHandler<Comment>(Comments_Changed), sender, e);
            }
            else
            {
                if (e.Action == CollectionChangeActionType.RemoveItem)
                {
                    Control control = (Control)FindCommentControl(e.OldValue);
                    if (control != null)
                    {
                        commentsLayoutPanel.Controls.Remove(control);
                        ((CommentControl)control).Comment = null;
                        ((CommentControl)control).Dispose();
                    }
                }
                else if (e.Action == CollectionChangeActionType.InsertItem)
                {
                    AddCommentControl(e.NewValue);
                }
            }
        }

        /// <summary>
        /// Updates the comments.
        /// </summary>
        private void UpdateComments()
        {
            if (InvokeRequired)
            {
                Invoke(new ThreadStart(UpdateComments));
                return;
            }

            ClearCommentsPanel();
            if (ImageViewer == null || ImageViewer.Image == null)
                return;
            CommentCollection comments = _commentController.GetComments(ImageViewer.Image);
            if (comments != _comments)
            {
                if (_comments != null)
                    _comments.Changed -= Comments_Changed;
                _comments = comments;
                if (comments != null)
                {
                    comments.Changed += Comments_Changed;
                    foreach (Comment comment in comments)
                    {
                        AddCommentControl(comment);
                    }
                }
            }
        }

        /// <summary>
        /// Adds the comment control for specified commment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        private void AddCommentControl(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException();
            CommentControl control = new CommentControl();
            control.Comment = comment;
            control.AutoHeight = true;
            control.CanClose = false;
            control.CanExpand = true;
            SetCommentControlSize(control);
            control.IsCommentSelectedChanged += CommentControl_IsCommentSelectedChanged;
            commentsLayoutPanel.Controls.Add(control);
        }

        /// <summary>
        /// Sets the size of the comment control.
        /// </summary>
        /// <param name="control">The control.</param>
        private void SetCommentControlSize(Control control)
        {
            control.Size = new Size(
                commentsLayoutPanel.Width - 2 - control.Margin.Horizontal - SystemInformation.VerticalScrollBarWidth,
                control.Size.Height);
        }

        /// <summary>
        /// Clears the comments panel.
        /// </summary>
        private void ClearCommentsPanel()
        {
            Control[] controls = new Control[commentsLayoutPanel.Controls.Count];
            commentsLayoutPanel.Controls.CopyTo(controls, 0);
            commentsLayoutPanel.Controls.Clear();
            foreach (Control control in controls)
                if (control is CommentControl)
                {
                    ((CommentControl)control).Comment = null;
                    control.Dispose();
                }

        }
#endif

#endregion

#endregion

    }
}
