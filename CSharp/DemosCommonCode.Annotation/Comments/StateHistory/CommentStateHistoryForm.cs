using System.Windows.Forms;

#if !REMOVE_ANNOTATION_PLUGIN
using Vintasoft.Imaging.Annotation.Comments;
#endif

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Represents a form that allows to display a comment state history.
    /// </summary>
    public partial class CommentStateHistoryForm : Form
    {

#if !REMOVE_ANNOTATION_PLUGIN
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentStateHistoryForm"/> class.
        /// </summary>
        /// <param name="comment">The comment.</param>
        public CommentStateHistoryForm(Comment comment)
        {
            InitializeComponent();

            commentStateHistoryControl1.Comment = comment;
        }
#endif

    }
}
