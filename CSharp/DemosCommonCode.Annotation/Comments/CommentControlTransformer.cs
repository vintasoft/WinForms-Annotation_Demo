#if !REMOVE_ANNOTATION_PLUGIN
using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Represents an interaction transformer that transforms <see cref="CommentControl"/>.
    /// </summary>
    public class CommentControlTransformer : RectObjectTransformer, IDisposable
    {

        #region Fields

        /// <summary>
        /// The image viewer.
        /// </summary>
        ImageViewer _imageViewer;

        /// <summary>
        /// Previous cursor of image viewer.
        /// </summary>
        Cursor _imageViewerPreviousCursor = null;

        /// <summary>
        /// A value indicating whether the <see cref="CommentControl"/> content is hidden.
        /// </summary>
        bool _isCommentControlContentHidden = false;
        
        /// <summary>
        /// A value indicating whether error occurs during updating of control visibility.
        /// </summary>
        bool _hasVisibilityUpdatingError = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentControlTransformer"/> class.
        /// </summary>
        /// <param name="commentControl">The comment control.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <i>commentControl</i> is <b>null</b>.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown if image viewer is not found.</exception>
        public CommentControlTransformer(CommentControl commentControl)
        {
            if (commentControl == null)
                throw new ArgumentNullException();

            _commentControl = commentControl;

            _imageViewer = GetImageViewer(commentControl);

            if (_imageViewer == null)
                throw new InvalidOperationException("The image viewer is not found.");

            SizeChangeMargin = 6;
            LocationChangeTopMargin = Math.Max(1, commentControl.TopPanelSize.Height);

            SubscribeToControlEvents(commentControl);

            ShowMoveCursor = false;
        }

        #endregion



        #region Properties

        CommentControl _commentControl;
        /// <summary>
        /// Gets the comment control.
        /// </summary>
        public CommentControl CommentControl
        {
            get
            {
                return _commentControl;
            }
        }

        bool _hideContentOnTransform = true;
        /// <summary>
        /// Gets or sets a value indicating whether transformer hides content when transformation performs.
        /// </summary>
        /// <value>
        /// <b>True</b> - transformer must hide the comment control content and set the control background to <see cref="TransformBackgroundColor"/> color when transformation performs;<br/>
        /// <b>false</b> - transformer must not change the comment control content when transformation performs.<br />
        /// Default value is <b>True</b>.
        /// </value>
        /// <remarks>
        /// By default transformer hides the comment control content for increasing the performance.
        /// </remarks>
        /// <seealso cref="TransformBackgroundColor"/>
        public bool HideContentOnTransform
        {
            get
            {
                return _hideContentOnTransform;
            }
            set
            {
                _hideContentOnTransform = value;
            }
        }

        Color _transformBackgroundColor = Color.FromArgb(204, 224, 236);
        /// <summary>
        /// Gets or sets the color of the background when comment control is transforming.
        /// </summary>
        /// <seealso cref="HideContentOnTransform"/>
        public Color TransformBackgroundColor
        {
            get
            {
                return _transformBackgroundColor;
            }
            set
            {
                _transformBackgroundColor = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Releases all resources used by this <see cref="CommentControlTransformer"/> object.
        /// </summary>
        public void Dispose()
        {
            UnsubscribeFromControlEvents(CommentControl);
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Returns the rectangle of an object in pixels.
        /// </summary>
        /// <returns>
        /// Object <see cref="Rectangle" /> in pixels.
        /// </returns>
        protected override Rectangle GetRect()
        {
            return new Rectangle(
                CommentControl.Left,
                CommentControl.Top,
                CommentControl.Width,
                CommentControl.Height);
        }

        /// <summary>
        /// Sets the new rectangle of an object in pixels.
        /// </summary>
        /// <param name="rect">The new rectangle of an object in pixels.</param>
        protected override void SetRect(Rectangle rect)
        {
            VintasoftImage image = _imageViewer.Image;

            if (image != null)
            {
                // get transform from control to the device independent pixels (DIP)
                AffineMatrix matrix = _imageViewer.GetTransformFromControlToDip();

                // convert location to the DIP
                PointF locationInDip = PointFAffineTransform.TransformPoint(matrix, rect.Location);

                if (HideContentOnTransform)
                {
                    // if comment control content is visible
                    if (!_isCommentControlContentHidden)
                    {
                        // hide comment control content
                        UpdateCommentControlContentVisibility(false);
                        _isCommentControlContentHidden = true;
                    }
                }

                // update comment bounding box
                CommentControl.Comment.BoundingBox = new RectangleF(locationInDip, rect.Size);
            }
        }

        /// <summary>
        /// Returns the minimum object size in pixels.
        /// </summary>
        /// <returns>
        /// Minimum object <see cref="Size" /> in pixels.
        /// </returns>
        protected override Size GetMinSize()
        {
            return new Size(150, 47);
        }

        /// <summary>
        /// Returns the bounding box of the object's parent container in pixels.
        /// </summary>
        /// <returns>
        /// <see cref="Rectangle" /> of the objec't container in pixels.
        /// </returns>
        protected override Rectangle GetBoundingBox()
        {
            return CommentControl.Parent.ClientRectangle;
        }

        #endregion


        #region PRIVATE 

        /// <summary>
        /// Updates the <see cref="CommentControl"/> content visibility.
        /// </summary>
        /// <param name="value">Indicates whether the <see cref="CommentControl"/> content is visible.</param>
        private void UpdateCommentControlContentVisibility(bool value)
        {
            if (value)
            {
                CommentControl.UpdateUI();
                CommentControl.SetSize();
            }
            else
            {
                CommentControl.BackColor = TransformBackgroundColor;
            }

            try
            {
                foreach (Control control in CommentControl.Controls)
                    control.Visible = value;
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                if (!_hasVisibilityUpdatingError)
                {
                    // WinForms generates Win32Exception if 15 or more FlowLayoutPanel are nested

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _hasVisibilityUpdatingError = true;
                }
            }

            CommentControl.Update();
        }

        /// <summary>
        /// Returns the <see cref="ImageViewer"/>.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>
        /// The <see cref="ImageViewer"/>.
        /// </returns>
        private ImageViewer GetImageViewer(Control control)
        {
            if (control == null)
                return null;

            if (control is ImageViewer)
                return (ImageViewer)control;

            if (control.Parent == null)
                return null;

            return GetImageViewer(control.Parent);
        }

        /// <summary>
        /// Subscribes to <see cref="Control"/> events.
        /// </summary>
        /// <param name="control">The control.</param>
        private void SubscribeToControlEvents(Control control)
        {
            if (control is Button)
                return;

            control.MouseEnter += Control_MouseEnter;
            control.MouseMove += Control_MouseMove;
            control.MouseDown += Control_MouseDown;
            control.MouseUp += Control_MouseUp;
            control.MouseLeave += Control_MouseLeave;

            foreach (Control child in control.Controls)
                SubscribeToControlEvents(child);
        }

        /// <summary>
        /// Unsubscribes from the <see cref="Control"/> events.
        /// </summary>
        /// <param name="control">The control.</param>
        private void UnsubscribeFromControlEvents(Control control)
        {
            if (control is Button)
                return;

            control.MouseEnter -= Control_MouseEnter;
            control.MouseMove -= Control_MouseMove;
            control.MouseDown -= Control_MouseDown;
            control.MouseUp -= Control_MouseUp;
            control.MouseLeave -= Control_MouseLeave;

            foreach (Control child in control.Controls)
                UnsubscribeFromControlEvents(child);
        }

        /// <summary>
        /// The mouse pointer enters the control.
        /// </summary>
        private void Control_MouseEnter(object sender, EventArgs e)
        {
            // save image viewer cursor
            _imageViewerPreviousCursor = _imageViewer.Cursor;
            // set new cursor in image viewer
            _imageViewer.Cursor = Cursors.Default;
        }

        /// <summary>
        /// The mouse pointer is moved over the control.
        /// </summary>
        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            Point convertedPoint = ConvertPointFromChildrenControlSpaceToParent(CommentControl, (Control)sender, e.Location);
            DoMouseMove(convertedPoint, CommentControl.Location, e.Button);
        }

        /// <summary>
        /// The mouse pointer is over the control and a mouse button is pressed.
        /// </summary>
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Point convertedPoint = ConvertPointFromChildrenControlSpaceToParent(CommentControl, (Control)sender, e.Location);
            DoMouseDown(convertedPoint, CommentControl.Location, e.Button);
        }

        /// <summary>
        /// The mouse pointer is over the control and a mouse button is released.
        /// </summary>
        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isCommentControlContentHidden)
            {
                // show comment control content
                UpdateCommentControlContentVisibility(true);
                _isCommentControlContentHidden = false;
            }
        }

        /// <summary>
        /// The mouse pointer leaves the control.
        /// </summary>
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            // restore image viewer cursor
            _imageViewer.Cursor = _imageViewerPreviousCursor;
            _imageViewerPreviousCursor = null;
        }

        /// <summary>
        /// Converts the specified point on child control space to the point on parent control space.
        /// </summary>
        /// <param name="parentControl">The parent control.</param>
        /// <param name="childControl">The children control.</param>
        /// <param name="point">The point.</param>
        /// <returns>
        /// The point on parent control space.
        /// </returns>
        private Point ConvertPointFromChildrenControlSpaceToParent(Control parentControl, Control childControl, Point point)
        {
            Point screenPoint = childControl.PointToScreen(point);
            return parentControl.PointToClient(screenPoint);
        }

        #endregion

        #endregion

    }
}
#endif