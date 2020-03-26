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
        public const bool SplitStatesByUserName = true;

        /// <summary>
        /// Determines the state name for accepted comment.
        /// </summary>
        public const string CommentStateReviewAccepted = "Review.Accepted";

        /// <summary>
        /// Determines the state name for rejected comment.
        /// </summary>
        public const string CommentStateReviewRejected = "Review.Rejected";

        /// <summary>
        /// Determines the state name for cancelled comment.
        /// </summary>
        public const string CommentStateReviewCancelled = "Review.Cancelled";

        /// <summary>
        /// Determines the state name for completed comment.
        /// </summary>
        public const string CommentStateReviewCompleted = "Review.Completed";

        /// <summary>
        /// Determines the none state name for comment.
        /// </summary>
        public const string CommentStateReviewNone = "Review.None";

        #endregion

    }
}