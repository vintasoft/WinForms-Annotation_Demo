using System;
using System.Drawing;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.Comments;
using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Annotation.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Utils;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Contains algorithms, which allow to create annotation with comments.
    /// </summary>
    public class AnnotationCommentBuilder
    {

        #region Fields

        /// <summary>
        /// The annotation visual tool.
        /// </summary>
        AnnotationVisualTool _annotationVisualTool;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnotationCommentBuilder"/> class.
        /// </summary>
        /// <param name="commentVisualTool">The comment visual tool.</param>
        /// <param name="annotationVisualTool">The annotation visual tool.</param>
        public AnnotationCommentBuilder(
            CommentVisualTool commentVisualTool,
            AnnotationVisualTool annotationVisualTool)
        {
            _commentVisualTool = commentVisualTool;
            _annotationVisualTool = annotationVisualTool;
        }

        #endregion



        #region Properties

        CommentVisualTool _commentVisualTool;
        /// <summary>
        /// The comment visual tool.
        /// </summary>
        public CommentVisualTool CommentVisualTool
        {
            get
            {
                return _commentVisualTool;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Adds the annotation with comment.
        /// </summary>
        public void AddNewComment()
        {
            // get comment annotation image
            VintasoftImage image = DemosResourcesManager.GetResourceAsImage(
                "DemosCommonCode.Annotation.Comments.AnnotationCommentBuilder.CommentIcon.png");

            // create comment annotation data
            EmbeddedImageAnnotationData annotationData = new EmbeddedImageAnnotationData(image);
            Resolution resolution = _annotationVisualTool.ImageViewer.Image.Resolution;
            annotationData.Size = new SizeF(
                (float)UnitOfMeasureConverter.ConvertToDeviceIndependentPixels(image.Width, UnitOfMeasure.Pixels, resolution.Horizontal),
                (float)UnitOfMeasureConverter.ConvertToDeviceIndependentPixels(image.Height, UnitOfMeasure.Pixels, resolution.Vertical));
            annotationData.Border = false;

            // create comment
            annotationData.Comment = new AnnotationComment(Color.Yellow, Environment.UserName);
            annotationData.Comment.Type = "Comment";

            // build annotation
            _annotationVisualTool.AnnotationBuildingFinished += AnnotationVisualTool_AnnotationBuildingFinished;
            RectangleAnnotationView view = (RectangleAnnotationView)_annotationVisualTool.AddAndBuildAnnotation(annotationData);
            view.Builder = new RectangularObjectMoveBuilder(view, annotationData.Size);
        }

        /// <summary>
        /// Adds the comment to the specified annotation view.
        /// </summary>
        /// <param name="view">The annotation view.</param>
        /// <returns>
        /// The comment.
        /// </returns>
        public AnnotationComment AddCommentToAnnotation(AnnotationView view)
        {
            if (view == null)
                return null;

            return AddCommentToAnnotation(view.Data);
        }

        /// <summary>
        /// Adds the comment to the specified annotation data.
        /// </summary>
        /// <param name="data">The annotation data.</param>
        /// <returns>
        /// The comment.
        /// </returns>
        public AnnotationComment AddCommentToAnnotation(AnnotationData data)
        {
            if (data == null)
                return null;

            // save reference to the previous comment
            AnnotationComment comment = data.Comment;

            // if annotation comment does not exist
            if (comment == null)
            {
                // create comment
                comment = new AnnotationComment(Color.Yellow, Environment.UserName);
                comment.Type = AnnotationCommentTypeFactory.GetCommentType(data);

                // add comment to the annotation
                data.Comment = comment;
            }

            // set comment location
            SetAnnotationCommentLocation(comment);

            // open comment
            comment.IsOpen = true;

            // if comment is not selected
            if (_commentVisualTool != null &&
               (_commentVisualTool.SelectedComment == null ||
                _commentVisualTool.SelectedComment.Comment != comment))
                _commentVisualTool.SelectedComment = _commentVisualTool.FindCommentControl(comment);

            return comment;
        }


        /// <summary>
        /// Annotation building is finished.
        /// </summary>
        private void AnnotationVisualTool_AnnotationBuildingFinished(object sender, AnnotationViewEventArgs e)
        {
            if (e.AnnotationView.Data.Comment != null)
                SetAnnotationCommentLocation(e.AnnotationView.Data.Comment);

            _annotationVisualTool.AnnotationBuildingFinished -= AnnotationVisualTool_AnnotationBuildingFinished;
        }

        /// <summary>
        /// Sets the annotation comment location.
        /// </summary>
        /// <param name="comment">The comment.</param>
        private void SetAnnotationCommentLocation(AnnotationComment comment)
        {
            VintasoftImage focusedImage = _annotationVisualTool.ImageViewer.Image;

            if (focusedImage != null)
            {
                float x = (float)UnitOfMeasureConverter.ConvertToDeviceIndependentPixels(focusedImage.Width, UnitOfMeasure.Pixels, focusedImage.Resolution.Horizontal);
                comment.BoundingBox = new RectangleF(
                    x, comment.Annotation.Location.Y,
                    AnnotationComment.DefaultCommentSize.Width, AnnotationComment.DefaultCommentSize.Height);
            }
        }

        #endregion

    }
}
