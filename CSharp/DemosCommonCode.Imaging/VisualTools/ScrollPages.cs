using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.Utils;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// The visual tool that allows to scroll the pages in the image viewer.
    /// </summary>
    public class ScrollPages : VisualTool
    {

        #region Enums

        /// <summary>
        /// Specifies available scroll actions.
        /// </summary>
        private enum ScrollAction
        {
            /// <summary>
            /// No action.
            /// </summary>
            None,

            /// <summary>
            /// Move To Next Page action.
            /// </summary>
            MoveToNextPage,

            /// <summary>
            /// Move To Previous Page action.
            /// </summary>
            MoveToPreviousPage
        }

        #endregion



        #region Fields

        /// <summary>
        /// The current scroll action.
        /// </summary>
        ScrollAction _scrollAction = ScrollAction.None;

        /// <summary>
        /// A value indicating whether the page changing is in progress.
        /// </summary>
        bool _isPageChanging;

        /// <summary>
        /// X coordinate of autoscroll position of previous focused image.
        /// </summary>
        float _previousFocusedImageAutoScrollPositionX;

        /// <summary>
        /// Width of previous focused image.
        /// </summary>
        int _previousFocusedImageWidth;

        /// <summary>
        /// A value indication whether the scroll was changed by user.
        /// </summary>
        bool _isScrollChangedByUser = true;

        /// <summary>
        /// A value indication whether the scroll was changed by visual tool.
        /// </summary>
        bool _isScrollChangedByTool = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="ScrollPages"/> object.
        /// </summary>
        public ScrollPages()
            : base()
        {
            base.Cursor = Cursors.Arrow;
            base.ActionCursor = base.Cursor;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the name of the visual tool.
        /// </summary>
        public override string Name
        {
            get { return "Scroll pages"; }
        }

        int _scrollStep = 50;
        /// <summary>
        /// Gets or sets the scroll step size, in pixels, of this tool.
        /// </summary>
        [Description("The scroll step size in pixels.")]
        [DefaultValue(50)]
        public int ScrollStep
        {
            get
            {
                return _scrollStep;
            }
            set
            {
                if (value > 100)
                    value = 100;
                if (value < 0)
                    value = 0;
                _scrollStep = value;
            }
        }

        bool _usePreviousImageAnchorWhenScrolling = false;
        /// <summary>
        /// Gets or sets a value which determines whether save scroll position by image.
        /// </summary>
        /// <value>
        /// <b>True</b> - image viewer must use the anchor of previous image when image viewer is scrolled;
        /// <b>false</b> - image viewer must NOT use the anchor of previous image when image viewer is scrolled.
        /// </value>
        [Description("Indicates that image viewer must use the anchor of previous image when image viewer is scrolled.")]
        [DefaultValue(false)]
        public bool UsePreviousImageAnchorWhenScrolling
        {
            get
            {
                return _usePreviousImageAnchorWhenScrolling;
            }
            set
            {
                _usePreviousImageAnchorWhenScrolling = value;
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Raises the MouseWheel event.
        /// </summary>
        /// <param name="e">A <see cref="VisualToolMouseEventArgs"/> that contains the event data.</param>
        protected override void OnMouseWheel(VisualToolMouseEventArgs e)
        {
            if (!Enabled)
                return;

            if (_isPageChanging)
                return;

            Scroll(e);

            e.Handled = true;
        }

        /// <summary> 
        /// Raises the Activated event.
        /// </summary>
        protected override void OnActivated(EventArgs e)
        {
            ImageViewer.Scroll += new ScrollEventHandler(ImageViewer_Scroll);
            ImageViewer.FocusedIndexChanged += new EventHandler<Vintasoft.Imaging.UI.FocusedIndexChangedEventArgs>(ImageViewer_FocusedIndexChanged);

            Point imageViewerCenter = new Point(ImageViewer.ClientSize.Width / 2, ImageViewer.ClientSize.Height / 2);
            if (ImageViewer.GetImageIndexByLocation(imageViewerCenter) == ImageViewer.FocusedIndex)
            {
                _isScrollChangedByUser = false;
            }
            else
            {
                _isScrollChangedByUser = true;
            }

            base.OnActivated(e);
        }

        /// <summary> 
        /// Raises the Deactivated event.
        /// </summary>
        protected override void OnDeactivated(EventArgs e)
        {
            ImageViewer.Scroll -= ImageViewer_Scroll;
            ImageViewer.FocusedIndexChanged -= ImageViewer_FocusedIndexChanged;

            base.OnDeactivated(e);
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Scrolls the current page.
        /// </summary>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        private void Scroll(MouseEventArgs e)
        {
            if (!Enabled)
                return;

            if (_isPageChanging)
                return;

            int delta = e.Delta;


            if (delta <= 0)
            {
                Scroll(_scrollStep);
            }
            else
            {
                Scroll(-_scrollStep);
            }

            _isScrollChangedByTool = true;
        }

        /// <summary>
        /// Image viewer scroll is changed.
        /// </summary>
        private void ImageViewer_Scroll(object sender, ScrollEventArgs e)
        {
            if (!_isScrollChangedByTool)
                _isScrollChangedByUser = true;

            _isScrollChangedByTool = false;
        }

        /// <summary>
        /// Returns center point of image viewer in coordinate space of specified image.
        /// </summary>
        /// <param name="image">An image.</param>
        /// <returns>Center point of image viewer in coordinate space of specified image.</returns>
        private PointF GetCenterPoint(VintasoftImage image)
        {
            // get old visible point
            PointF centerPoint = new PointF(ImageViewer.ClientSize.Width / 2.0f, ImageViewer.ClientSize.Height / 2.0f);
            // get transform from image space to viewer space
            AffineMatrix pointTransfrom = ImageViewer.GetTransformFromControlToImage(image);
            // transform the point
            return PointFAffineTransform.TransformPoint(pointTransfrom, centerPoint);
        }

        /// <summary>
        /// Returns a value, which determines that the image edge is visible.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="imageEdge">The image edge.</param>
        /// <returns>
        /// <b>true</b> - if image edge is visible.
        /// <b>false</b> - if image edge is not visible.
        /// </returns>
        private bool GetIsImageEdgeVisible(VintasoftImage image, Vintasoft.Imaging.UI.AnchorType imageEdge)
        {
            // get image viewer state for the image
            Vintasoft.Imaging.UI.ImageViewerState focusedImageViewerState = ImageViewer.GetViewerState(image);

            // get the visible image rectangle in image viewer
            RectangleF imageVisibleRect;
            if (ImageViewer.IsMultipageDisplayMode && !UsePreviousImageAnchorWhenScrolling)
            {
                imageVisibleRect = ImageViewer.ClientRectangle;
            }
            else
            {
                imageVisibleRect = focusedImageViewerState.ImageVisibleRect;
            }

            // get the image rectangle in image viewer
            RectangleF imageRect;
            if (ImageViewer.IsMultipageDisplayMode && !UsePreviousImageAnchorWhenScrolling)
            {
                imageRect = focusedImageViewerState.ImageBoundingBox;
            }
            else
            {
                imageRect = new RectangleF(0, 0, ImageViewer.Image.Width, ImageViewer.Image.Height);
            }
            if (imageRect == RectangleF.Empty)
                return false;

            // get the image "anchor" line
            RectangleF imageLine = RectangleF.Empty;
            if (imageEdge == Vintasoft.Imaging.UI.AnchorType.Bottom)
            {
                // get bottom line of image
                imageLine = new RectangleF(imageRect.X, imageRect.Y + imageRect.Height - 1, imageRect.Width, 1);
            }
            else if (imageEdge == Vintasoft.Imaging.UI.AnchorType.Top)
            {
                // get top line of image
                imageLine = new RectangleF(imageRect.X, imageRect.Y, imageRect.Width, 1);
            }
            else if (imageEdge == Vintasoft.Imaging.UI.AnchorType.Left)
            {
                // get left line of image
                imageLine = new RectangleF(0, 0, 1, ImageViewer.Image.Height);
            }
            else if (imageEdge == Vintasoft.Imaging.UI.AnchorType.Right)
            {
                // get right line of image
                imageLine = new RectangleF(ImageViewer.Image.Width - 1, 0, 1, ImageViewer.Image.Height);
            }

            // return a value that indicates whether the visible rectangle intersects with image line
            return imageVisibleRect.IntersectsWith(imageLine);
        }

        /// <summary>
        /// Scrolls the image viewer.
        /// </summary>
        /// <param name="scrollStepSize">A scroll step size in pixels.</param>
        private void Scroll(int scrollStepSize)
        {
            VintasoftImage image = ImageViewer.Image;
            if (image == null)
                return;

            // determine the scroll direction
            bool scrollForward = true;
            _scrollAction = ScrollAction.MoveToNextPage;
            Vintasoft.Imaging.UI.AnchorType imageEdge = Vintasoft.Imaging.UI.AnchorType.Bottom;
            // if scroll step size is negative 
            if (scrollStepSize < 0)
            {
                // change the scroll direction
                scrollForward = false;
                _scrollAction = ScrollAction.MoveToPreviousPage;
                imageEdge = Vintasoft.Imaging.UI.AnchorType.Top;
            }

            // get new scroll step size according to the focused image resolution
            float newScrollStepSize = scrollStepSize * (float)image.Resolution.Vertical / 96.0f;

            // if edge (top/bottom) of focused image is visible
            if (GetIsImageEdgeVisible(image, imageEdge))
            {
                // if focused image is first image in image viewer
                // and viewer must be scrolled backward
                if (ImageViewer.FocusedIndex == 0 && !scrollForward)
                    return;

                // if focused image is last in image viewer
                // and viewer must be scrolled forward
                if (ImageViewer.FocusedIndex >= ImageViewer.Images.Count - 1 && scrollForward)
                    return;

                _isPageChanging = true;

                int newFocusedIndex = ImageViewer.FocusedIndex;
                if (scrollForward)
                    newFocusedIndex++;
                else
                    newFocusedIndex--;

                // if image viewer is in multipage mode
                if (ImageViewer.IsMultipageDisplayMode)
                {
                    // get the center point of previous focused image
                    PointF previousFocusedImageCenterPoint = GetCenterPoint(ImageViewer.Image);
                    // anchor of previous focused image
                    Vintasoft.Imaging.UI.AnchorType previousFocusedImageAnchor = Vintasoft.Imaging.UI.AnchorType.None;
                    // X coordinate of center point of previous focused image bounding box
                    float previousFocusedImageBoundingBoxCenterX = 0;
                    // width of previous focused image bounding box
                    float previousFocusedImageBoundingBoxWidth = 0;

                    // get the scroll point of previous focused image
                    PointF previousImageScrollPoint = GetPreviousFocusedImageScrollPoint(
                        scrollForward,
                        previousFocusedImageCenterPoint,
                        ref previousFocusedImageAnchor,
                        ref previousFocusedImageBoundingBoxCenterX,
                        ref previousFocusedImageBoundingBoxWidth);

                    // change focused image
                    ChangeFocusedImage(newFocusedIndex);

                    // get the scroll point of new focused image
                    PointF newFocusedImageScrollPoint = GetNewFocusedImageScrollPoint(
                        scrollForward,
                        newScrollStepSize,
                        previousImageScrollPoint,
                        ref previousFocusedImageAnchor,
                        previousFocusedImageBoundingBoxCenterX,
                        previousFocusedImageBoundingBoxWidth);

                    // scroll to the scroll point on new focused image
                    ImageViewer.ScrollToPoint(newFocusedImageScrollPoint, previousFocusedImageAnchor);

                    _scrollAction = ScrollAction.None;
                    _isPageChanging = false;
                }
                // if image viewer is in single page mode
                else
                {
                    ImageViewer.ImageLoading += new EventHandler<ImageLoadingEventArgs>(ImageViewer_ImageLoading);
                    // save information about previous focused image
                    _previousFocusedImageAutoScrollPositionX = ImageViewer.ViewerState.AutoScrollPosition.X;
                    _previousFocusedImageWidth = ImageViewer.Image.Width;
                    // change focused index
                    ChangeFocusedImage(newFocusedIndex);
                }
            }
            // if edge (top/bottom) of image is not visible
            else
            {
                // get the center point of previous focused image
                PointF previousFocusedImageCenterPoint = GetCenterPoint(ImageViewer.Image);

                // get the scroll point of new focused image
                PointF newFocusedImageScrollPoint = new PointF(
                    previousFocusedImageCenterPoint.X,
                    previousFocusedImageCenterPoint.Y + newScrollStepSize);

                // scroll to the scroll point on new focused image
                ImageViewer.ScrollToPoint(newFocusedImageScrollPoint,
                        Vintasoft.Imaging.UI.AnchorType.Bottom |
                        Vintasoft.Imaging.UI.AnchorType.Left |
                        Vintasoft.Imaging.UI.AnchorType.Right |
                        Vintasoft.Imaging.UI.AnchorType.Top);

                _scrollAction = ScrollAction.None;
                SetFocusToVisibleImage();
            }
        }

        /// <summary>
        /// Changes the focused image.
        /// </summary>
        /// <param name="newFocusedIndex">New index of the focused image.</param>
        private void ChangeFocusedImage(int newFocusedIndex)
        {
            ImageViewer.DisableAutoScrollToFocusedImage();
            ImageViewer.SetFocusedIndexSync(newFocusedIndex);
            ImageViewer.EnableAutoScrollToFocusedImage();
        }

        /// <summary>
        /// Returns the scroll point of previous focused image.
        /// </summary>
        /// <param name="scrollForward">A value, which determines that the image viewer must be scrolled forward.</param>
        /// <param name="previousFocusedImageCenterPoint">The center point of previous focused image.</param>
        /// <param name="previousFocusedImageAnchor">The anchor of previous focused image.</param>
        /// <param name="previousFocusedImageBoundingBoxCenterX">X coordinate of center point of previous focused image bounding box.</param>
        /// <param name="previousFocusedImageBoundingBoxWidth">The width of previous focused image bounding box.</param>
        /// <returns>The scroll point of previous focused image.</returns>
        private PointF GetPreviousFocusedImageScrollPoint(
            bool scrollForward,
            PointF previousFocusedImageCenterPoint,
            ref Vintasoft.Imaging.UI.AnchorType previousFocusedImageAnchor,
            ref float previousFocusedImageBoundingBoxCenterX,
            ref float previousFocusedImageBoundingBoxWidth)
        {
            int newFocusedIndex = ImageViewer.FocusedIndex;
            if (scrollForward)
                newFocusedIndex++;
            else
                newFocusedIndex--;

            VintasoftImage previousFocusedImage = ImageViewer.Image;
            VintasoftImage newFocusedImage = ImageViewer.Images[newFocusedIndex];

            PointF previousImageScrollPoint = previousFocusedImageCenterPoint;

            // if image viewer must use the anchor of previous focused image when image viewer is scrolled
            if (UsePreviousImageAnchorWhenScrolling)
            {
                // if left edge of previous focused image is visible
                if (GetIsImageEdgeVisible(previousFocusedImage, Vintasoft.Imaging.UI.AnchorType.Left))
                {
                    // save information about anchor of previous focused image
                    previousFocusedImageAnchor = Vintasoft.Imaging.UI.AnchorType.Left;
                    // save information scroll point of new focused image 
                    previousImageScrollPoint.X = 0;
                }
                // if right edge of previous focused image is visible
                else if (GetIsImageEdgeVisible(previousFocusedImage, Vintasoft.Imaging.UI.AnchorType.Right))
                {
                    // save information about anchor of previous focused image
                    previousFocusedImageAnchor = Vintasoft.Imaging.UI.AnchorType.Right;
                    // save information scroll point of new focused image 
                    previousImageScrollPoint.X = newFocusedImage.Width;
                }
                // if left/right edges of previous focused image are not visible
                else
                {
                    // save information scroll point of new focused image 
                    previousImageScrollPoint.X = previousFocusedImageCenterPoint.X *
                        newFocusedImage.Width / previousFocusedImage.Width;
                }
            }
            // if image viewer must NOT use the anchor of previous focused image when image viewer is scrolled
            else 
            {
                // if display mode is single continuous row
                // and left and right edges of previous focused image is visible
                if (ImageViewer.DisplayMode == Vintasoft.Imaging.UI.ImageViewerDisplayMode.SingleContinuousRow &&
                    GetIsImageEdgeVisible(previousFocusedImage, Vintasoft.Imaging.UI.AnchorType.Left) &&
                    GetIsImageEdgeVisible(previousFocusedImage, Vintasoft.Imaging.UI.AnchorType.Right))
                {
                    // if scroll moves forward
                    if (scrollForward)
                    {
                        previousImageScrollPoint.X = 0;
                        previousFocusedImageAnchor = Vintasoft.Imaging.UI.AnchorType.Left;
                    }
                    // if scroll moves backward
                    else
                    {
                        previousImageScrollPoint.X = newFocusedImage.Width;
                        previousFocusedImageAnchor = Vintasoft.Imaging.UI.AnchorType.Right;
                    }
                }
                else
                {
                    // get X coordinate of the viewer center
                    float viewerCenterPointX = ImageViewer.ClientSize.Width / 2.0f;

                    // get image viewer state for focused image
                    Vintasoft.Imaging.UI.ImageViewerState focusedImageViewerState = ImageViewer.GetViewerState(previousFocusedImage);
                    // get width of focused image bounding box
                    previousFocusedImageBoundingBoxWidth = focusedImageViewerState.ImageBoundingBox.Width;
                    // get X coordinate of central point for next image
                    previousFocusedImageBoundingBoxCenterX = viewerCenterPointX - focusedImageViewerState.ImageBoundingBox.X;
                }
            }
             
            return previousImageScrollPoint;
        }

        /// <summary>
        /// Returns the scroll point of new focused image.
        /// </summary>
        /// <param name="scrollForward">A value, which determines the direction of scrolling.</param>
        /// <param name="scrollStepSize">A scroll step size.</param>
        /// <param name="previousImageScrollPoint">The scroll point of previous focused image.</param>
        /// <param name="scrollAnchor">An anchor to scroll.</param>
        /// <param name="previousFocusedImageBoundingBoxCenterX">X coordinate of center point of previous focused image bounding box.</param>
        /// <param name="previousFocusedImageBoundingBoxWidth">The width of previous focused image bounding box.</param>
        /// <returns>The scroll point of new focused image.</returns>
        private PointF GetNewFocusedImageScrollPoint(
            bool scrollForward,
            float scrollStepSize,
            PointF previousImageScrollPoint,
            ref Vintasoft.Imaging.UI.AnchorType scrollAnchor,
            float previousFocusedImageBoundingBoxCenterX,
            float previousFocusedImageBoundingBoxWidth)
        {
            PointF newFocusedImageScrollPoint = previousImageScrollPoint;

            // if image viewer must NOT use the anchor of previous image when image viewer is scrolled
            if (!UsePreviousImageAnchorWhenScrolling)
            {
                // get image viewer state for the focused image
                Vintasoft.Imaging.UI.ImageViewerState focusedImageViewerState = ImageViewer.GetViewerState(ImageViewer.Image);

                // get X coordinate of bounding box for focused image
                float focusedImageBoundingBoxXCoord = focusedImageViewerState.ImageBoundingBox.X;
                previousFocusedImageBoundingBoxCenterX = previousFocusedImageBoundingBoxCenterX *
                    focusedImageViewerState.ImageBoundingBox.Width / previousFocusedImageBoundingBoxWidth;

                // calculate the scroll point of new focused image
                focusedImageBoundingBoxXCoord += previousFocusedImageBoundingBoxCenterX;
                AffineMatrix transformToNewImageSpace = ImageViewer.GetTransformFromControlToImage();
                newFocusedImageScrollPoint = PointFAffineTransform.TransformPoint(transformToNewImageSpace, new PointF(focusedImageBoundingBoxXCoord, 0));
            }

            // if row count is greater than 1
            // or layout direction is horizontal
            if (ImageViewer.MultipageDisplayRowCount > 1 ||
                ImageViewer.MultipageDisplayLayoutDirection == Vintasoft.Imaging.UI.ImagesLayoutDirection.Horizontal)
            {
                // if scroll moves forward
                if (scrollForward)
                {
                    newFocusedImageScrollPoint.Y = 0;
                    scrollAnchor |= Vintasoft.Imaging.UI.AnchorType.Top;
                }
                // if scroll moves backward
                else
                {
                    newFocusedImageScrollPoint.Y = ImageViewer.Image.Height;
                    scrollAnchor |= Vintasoft.Imaging.UI.AnchorType.Bottom;
                }
            }
            else
            {
                // get index of previous focused image
                int previousFocusedImageIndex = ImageViewer.FocusedIndex;
                // if scroll moves forward
                if (scrollForward)
                    previousFocusedImageIndex--;
                // if scroll moves backward
                else
                    previousFocusedImageIndex++;

                // get transform from previous focused image to new focused image
                AffineMatrix transformFromPreviousImageToFocusedImage = 
                    ImageViewer.GetTransformFromFocusedImageToImage(ImageViewer.Images[previousFocusedImageIndex]);
                transformFromPreviousImageToFocusedImage.Invert();

                // get Y coordinate of previous scroll point in focused image space
                newFocusedImageScrollPoint.Y = PointFAffineTransform.TransformPoint(
                    transformFromPreviousImageToFocusedImage, new PointF(0, previousImageScrollPoint.Y)).Y;
                // calculate scroll point for new focused image
                newFocusedImageScrollPoint.Y += scrollStepSize;
                // get scroll anchor
                scrollAnchor = Vintasoft.Imaging.UI.AnchorType.Bottom |
                        Vintasoft.Imaging.UI.AnchorType.Left |
                        Vintasoft.Imaging.UI.AnchorType.Right |
                        Vintasoft.Imaging.UI.AnchorType.Top;
            }

            return newFocusedImageScrollPoint;
        }

        /// <summary>
        /// Image is loading in image viewer.
        /// </summary>
        private void ImageViewer_ImageLoading(object sender, ImageLoadingEventArgs e)
        {
            // if scrolling is in progress
            if (_scrollAction != ScrollAction.None)
            {
                ImageViewer.ImageLoading -= new EventHandler<ImageLoadingEventArgs>(ImageViewer_ImageLoading);

                float autoScrollPositionX;
                float autoScrollPositionY;

                // autoScrollPositionX
                float proportion = (float)ImageViewer.Image.Width / _previousFocusedImageWidth;
                autoScrollPositionX = _previousFocusedImageAutoScrollPositionX * proportion;

                // autoScrollPositionY
                switch (_scrollAction)
                {
                    case ScrollAction.MoveToNextPage:
                        autoScrollPositionY = 0;
                        break;
                    case ScrollAction.MoveToPreviousPage:
                        autoScrollPositionY = ImageViewer.Image.Height;
                        break;
                    default:
                        throw new Exception();
                }

                // set scroll of new focused image
                ImageViewer.ViewerState.AutoScrollPosition = new PointF(autoScrollPositionX, autoScrollPositionY);

                _scrollAction = ScrollAction.None;
            }

            _isPageChanging = false;
        }

        /// <summary>
        /// Sets focus to the visible image.
        /// </summary>
        /// <remarks>
        /// Focus will be changed if focused image is not visible.
        /// </remarks>
        private void SetFocusToVisibleImage()
        {
            // if scroll is changed by user
            if (_isScrollChangedByUser)
            {
                // if focused image is not visible
                if (ImageViewer.ViewerState.ImageVisibleRect == RectangleF.Empty)
                {
                    // get visible images
                    VintasoftImage[] visibleImages = ImageViewer.GetVisibleImages();

                    // get central point of image viewer
                    PointF centerPoint = new PointF(ImageViewer.ClientSize.Width / 2.0f, ImageViewer.ClientSize.Height / 2.0f);

                    float minDistance = ImageViewer.ClientSize.Width * ImageViewer.ClientSize.Width +
                        ImageViewer.ClientSize.Height * ImageViewer.ClientSize.Height;
                    VintasoftImage minDistanceImage = null;

                    // for each visible image
                    foreach (VintasoftImage image in visibleImages)
                    {
                        // calculate distance between central point and image rectangle
                        float distanceBetweenImageAndPoint = GetDistanceBetweenPointAndImageRect(centerPoint, image);

                        if (distanceBetweenImageAndPoint < minDistance)
                        {
                            minDistance = distanceBetweenImageAndPoint;
                            minDistanceImage = image;
                        }
                    }

                    // if there is visible image
                    if (minDistanceImage != null)
                    {
                        _isPageChanging = true;
                        // get index of visible image
                        int indexOfVisibleImage = ImageViewer.Images.IndexOf(minDistanceImage);

                        // set focus to visible image
                        ChangeFocusedImage(indexOfVisibleImage);

                        _isPageChanging = false;
                    }
                }
                else
                {
                    _isScrollChangedByUser = false;
                }
            }
        }

        /// <summary>
        /// Returns distance between point and image rectangle.
        /// </summary>
        /// <param name="point">A point in image viewer space.</param>
        /// <param name="image">An image.</param>
        /// <returns>Distance between point and image rectangle.</returns>
        private float GetDistanceBetweenPointAndImageRect(PointF point, VintasoftImage image)
        {
            AffineMatrix transformMatrix = ImageViewer.GetTransformFromImageToControl(image);
            // get image rectangle
            RectangleF imageRect = new RectangleF(0, 0, image.Width, image.Height);
            PointFTransform pointTransform = PointFAffineTransform.FromMatrix(transformMatrix);
            imageRect = PointFAffineTransform.TransformBoundingBox(pointTransform, imageRect);

            PointF imagePoint = PointF.Empty;
            // get X coordinate of point on image
            if (point.X < imageRect.X)
                imagePoint.X = imageRect.X;
            else if (point.X > imageRect.X + imageRect.Width)
                imagePoint.X = imageRect.X + imageRect.Width;
            else
                imagePoint.X = point.X;

            // get Y coordinate of point on image
            if (point.Y < imageRect.Y)
                imagePoint.Y = imageRect.Y;
            else if (point.Y > imageRect.Y + imageRect.Height)
                imagePoint.Y = imageRect.Y + imageRect.Height;
            else
                imagePoint.Y = point.Y;

            // calculate distance
            float dx = (point.X - imagePoint.X);
            float dy = (point.Y - imagePoint.Y);
            float distanceBetweenImageAndPoint = dx * dx + dy * dy;

            return distanceBetweenImageAndPoint;
        }

        /// <summary>
        /// Focused index is changed in image viewer.
        /// </summary>
        private void ImageViewer_FocusedIndexChanged(object sender, Vintasoft.Imaging.UI.FocusedIndexChangedEventArgs e)
        {
            // if visual tool is enabled
            if (Enabled)
                // specify that scroll is changed not by user
                _isScrollChangedByUser = false;
        }

        #endregion

        #endregion

    }
}
