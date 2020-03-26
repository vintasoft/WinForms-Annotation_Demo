#if !REMOVE_ANNOTATION_PLUGIN
using Vintasoft.Imaging.Annotation.Comments;
using Vintasoft.Imaging.Annotation.UI.Comments;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Represents a factory that allows to create comment controls.
    /// </summary>
    public class CommentControlFactory : ICommentControlFactory
    {

        /// <summary>
        /// Creates the comment control that displays specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>Comment control that displays specified comment.</returns>
        public ICommentControl Create(Comment comment)
        {
            return new CommentControl(comment);
        }

    }
}
#endif