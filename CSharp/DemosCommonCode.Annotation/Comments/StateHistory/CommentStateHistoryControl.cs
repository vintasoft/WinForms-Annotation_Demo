using System.Collections.Generic;
using System.Windows.Forms;

#if !REMOVE_ANNOTATION_PLUGIN
using Vintasoft.Imaging.Annotation.Comments;
#endif

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Represents the control that allows to display a comment state history.
    /// </summary>
    public partial class CommentStateHistoryControl : TreeView
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentStateHistoryControl"/> class.
        /// </summary>
        public CommentStateHistoryControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

#if !REMOVE_ANNOTATION_PLUGIN
        Comment _comment = null;
        /// <summary>
        /// Gets or sets the comment that is displayed in control.
        /// </summary>
        public Comment Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                if (_comment != value)
                {
                    _comment = value;

                    UpdateTreeView();
                }
            }
        }
#endif

        #endregion



        #region Methods

#if !REMOVE_ANNOTATION_PLUGIN
        /// <summary>
        /// Updates the control.
        /// </summary>
        private void UpdateTreeView()
        {
            // get state model groups of comment
            Dictionary<string, List<Comment>> stateModelToComment = GetCommentStateModelGroups(_comment);

            BeginUpdate();

            // clear tree view
            Nodes.Clear();

            // add state model groups to tree view
            foreach (string stateModel in stateModelToComment.Keys)
            {
                // create state model group node
                TreeNode stateModelTreeNode = new TreeNode(
                    string.Format("{0} history", stateModel));

                // add children to state model group node
                foreach (Comment comment in stateModelToComment[stateModel])
                {
                    stateModelTreeNode.Nodes.Add(string.Format(
                        "{0}: {1}, {2}", comment.UserName, comment.ParentState, comment.ModifyDate));
                }

                // add state model group node to the tree view
                Nodes.Add(stateModelTreeNode);
                stateModelTreeNode.Expand();
            }

            EndUpdate();
        }

        /// <summary>
        /// Returns the state model groups of the specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>
        /// The state model groups.
        /// </returns>
        private Dictionary<string, List<Comment>> GetCommentStateModelGroups(Comment comment)
        {
            Dictionary<string, List<Comment>> result = new Dictionary<string, List<Comment>>();

            if (comment != null && comment.Replies != null)
            {
                foreach (Comment reply in comment.Replies)
                    AddCommentStateModel(reply, result);
            }

            return result;
        }

        /// <summary>
        /// Adds the comment state model.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="stateModelToComment">The state model groups dictionary.</param>
        private void AddCommentStateModel(
            Comment comment,
            Dictionary<string, List<Comment>> stateModelToComment)
        {
            if (!string.IsNullOrEmpty(comment.StateModel))
            {
                List<Comment> comments = null;

                if (!stateModelToComment.TryGetValue(comment.StateModel, out comments))
                {
                    comments = new List<Comment>();

                    stateModelToComment.Add(comment.StateModel, comments);
                }

                comments.Add(comment);

                foreach (Comment reply in comment.Replies)
                    AddCommentStateModel(reply, stateModelToComment);
            }
        }
#endif

        #endregion

    }
}
