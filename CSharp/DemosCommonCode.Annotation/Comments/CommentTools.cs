namespace DemosCommonCode
{
    /// <summary>
    /// Contains collection of constants and helper-algorithms with comments for demo applications.
    /// </summary>
    public static class CommentTools
    {

        #region Constants

        /// <summary>
        /// Determines that comment states must be splitted by user name.
        /// </summary>
        public const bool SPLIT_STATES_BY_USER_NAME = true;

        /// <summary>
        /// Determines the state name for accepted comment.
        /// </summary>
        public const string COMMENT_STATE_REVIEW_ACCEPTED = "Review.Accepted";

        /// <summary>
        /// Determines the state name for rejected comment.
        /// </summary>
        public const string COMMENT_STATE_REVIEW_REJECTED = "Review.Rejected";

        /// <summary>
        /// Determines the state name for cancelled comment.
        /// </summary>
        public const string COMMENT_STATE_REVIEW_CANCELLED = "Review.Cancelled";

        /// <summary>
        /// Determines the state name for completed comment.
        /// </summary>
        public const string COMMENT_STATE_REVIEW_COMPLETED = "Review.Completed";

        /// <summary>
        /// Determines the none state name for comment.
        /// </summary>
        public const string COMMENT_STATE_REVIEW_NONE = "Review.None";

        #endregion

    }
}