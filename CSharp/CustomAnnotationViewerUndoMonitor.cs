using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Annotation.UI.Undo;
using Vintasoft.Imaging.Annotation.UI.VisualTools;
using Vintasoft.Imaging.Undo;


namespace AnnotationDemo
{
    /// <summary>
    /// The undo monitor that monitors the <see cref="AnnotationViewer"/> object and
    /// adds undo action to an undo manager if <see cref="AnnotationViewCollection"/> is changed.
    /// </summary>
    public class CustomAnnotationViewerUndoMonitor : AnnotationViewerUndoMonitor
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAnnotationViewerUndoMonitor"/> class.
        /// </summary>
        /// <param name="undoManager">The undo manager.</param>
        /// <param name="annotationViewer">The annotation viewer.</param>
        /// <remarks>
        /// The monitor will save undo history for all images in viewer
        /// if the undo manager is <see cref="CompositeUndoManager"/>.<br />
        /// The monitor will save undo history only for focused image in viewer
        /// if the undo manager is NOT <see cref="CompositeUndoManager"/>.
        /// </remarks>
        public CustomAnnotationViewerUndoMonitor(UndoManager undoManager, AnnotationViewer annotationViewer)
            : base(undoManager, annotationViewer)
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Creates the undo monitor for annotation visual tool.
        /// </summary>
        /// <param name="undoManager">The undo manager.</param>
        /// <param name="annotationVisualTool">The annotation visual tool.</param>
        /// <returns>
        /// The undo monitor for annotation visual tool.
        /// </returns>
        protected override AnnotationVisualToolUndoMonitor CreateAnnotationVisualToolUndoMonitor(
            UndoManager undoManager,
            AnnotationVisualTool annotationVisualTool)
        {
            return new CustomAnnotationVisualToolUndoMonitor(undoManager, annotationVisualTool);
        }

        #endregion

    }
}
