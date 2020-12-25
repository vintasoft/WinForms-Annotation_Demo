using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Annotation.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Class that handles all events of annotation and annotation collection.
    /// </summary>
    public class AnnotationsLogger : AnnotationsEventsHandler
    {

        #region Fields

        /// <summary>
        /// The log text box.
        /// </summary>
        TextBox _logTextBox;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnotationsLogger"/> class.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        /// <param name="textBox">The text box.</param>
        public AnnotationsLogger(AnnotationViewer annotationViewer, TextBox textBox)
            : base(annotationViewer, true, true)
        {
            _logTextBox = textBox;

            // subscribe to the annotation viewer events
            annotationViewer.AnnotationTransformingStarted += new EventHandler<AnnotationViewEventArgs>(AnnotationViewer_AnnotationTransformingStarted);
            annotationViewer.AnnotationTransformingFinished += new EventHandler<AnnotationViewEventArgs>(AnnotationViewer_AnnotationTransformingFinished);
            annotationViewer.FocusedAnnotationViewChanged += new EventHandler<AnnotationViewChangedEventArgs>(AnnotationViewer_FocusedAnnotationViewChanged);
            annotationViewer.AnnotationDrawException += new EventHandler<AnnotationViewDrawExceptionEventArgs>(AnnotationViewer_AnnotationDrawException);
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// The annotation data controller is changed.
        /// </summary>
        /// <param name="viewer">The annotation viewer.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs{AnnotationViewCollection}"/> instance containing the event data.</param>
        protected override void OnAnnotationDataControllerChanged(
            AnnotationViewer viewer,
            PropertyChangedEventArgs<AnnotationDataController> e)
        {
            // add a log message that annotation data controller is changed
            AddLogMessage("AnnotationViewer.AnnotationDataControllerChanged");
        }

        /// <summary>
        /// The annotation view collection is changed.
        /// </summary>
        /// <param name="viewer">The annotation viewer.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs{AnnotationViewCollection}"/> instance containing the event data.</param>
        protected override void OnAnnotationViewCollectionChanged(
            AnnotationViewer viewer,
            PropertyChangedEventArgs<AnnotationViewCollection> e)
        {
            AddLogMessage("AnnotationViewer.AnnotationViewCollectionChanged");
        }

        /// <summary>
        /// The annotation data collection is changed.
        /// </summary>
        /// <param name="annotationDataCollection">The annotation data collection.</param>
        /// <param name="e">The <see cref="CollectionChangeEventArgs{AnnotationData}"/> instance containing the event data.</param>
        protected override void OnDataCollectionChanged(
            AnnotationDataCollection annotationDataCollection,
            CollectionChangeEventArgs<AnnotationData> e)
        {
            if (e.NewValue != null && e.OldValue != null)
                AddLogMessage(string.Format("DataCollection.{0}: {1}->{2}", e.Action, GetAnnotationInfo(e.OldValue), GetAnnotationInfo(e.NewValue)));
            else if (e.NewValue != null)
                AddLogMessage(string.Format("DataCollection.{0}: {1}", e.Action, GetAnnotationInfo(e.NewValue)));
            else if (e.OldValue != null)
                AddLogMessage(string.Format("DataCollection.{0}: {1}", e.Action, GetAnnotationInfo(e.OldValue)));
            else
                AddLogMessage(string.Format("DataCollection.{0}", e.Action));
        }

        /// <summary>
        /// The annotation data property is changed.
        /// </summary>
        /// <param name="annotationDataCollection">The annotation data collection.</param>
        /// <param name="annotationData">The annotation data.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnAnnotationDataPropertyChanged(
            AnnotationDataCollection annotationDataCollection,
            AnnotationData annotationData,
            ObjectPropertyChangedEventArgs e)
        {
            if (e.OldValue == null && e.NewValue == null)
                AddLogMessage(string.Format("{0}.{1}",
                    GetAnnotationInfo(annotationData),
                    e.PropertyName));
            else
                AddLogMessage(string.Format("{0}.{1}: {2} -> {3}",
                    GetAnnotationInfo(annotationData),
                    e.PropertyName,
                    e.OldValue,
                    e.NewValue));
        }

        /// <summary>
        /// The mouse is clicked on annotation view.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnClick(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "Click", e);
        }

        /// <summary>
        /// The mouse is double clicked on annotation view.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnDoubleClick(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "DoubleClick", e);
        }

        /// <summary>
        /// The mouse is down on annotation view.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "MouseDown", e);
        }

        /// <summary>
        /// The mouse enters the annotation view.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseEnter(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "MouseEnter", e);
        }

        /// <summary>
        /// The mouse is moved on annotation view.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseMove(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "MouseMove", e);
        }

        /// <summary>
        /// The mouse is up on annotation view.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseUp(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "MouseUp", e);
        }

        /// <summary>
        /// The mouse wheel is moved on annotation view
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseWheel(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "MouseWheel", e);
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the AnnotationViewer.FocusedAnnotationViewChanged event.
        /// </summary>
        private void AnnotationViewer_FocusedAnnotationViewChanged(
            object sender,
            AnnotationViewChangedEventArgs e)
        {
            if (IsEnabled)
                // add a log message about changed focused annotation view
                AddLogMessage(string.Format("FocusedAnnotationViewChanged: {0} -> {1}", GetAnnotationInfo(e.OldValue), GetAnnotationInfo(e.NewValue)));
        }

        /// <summary>
        /// Handles the AnnotationViewer.AnnotationTransformingStarted event.
        /// </summary>
        private void AnnotationViewer_AnnotationTransformingStarted(
            object sender,
            AnnotationViewEventArgs e)
        {
            if (IsEnabled)
                // add a log message about beginning of the annotation view transformation
                AddLogMessage(string.Format("{0}: TransformingStarted: {1}", GetAnnotationInfo(e.AnnotationView), GetInteractionControllerInfo(e.AnnotationView.InteractionController)));
        }

        /// <summary>
        /// Handles the AnnotationViewer.AnnotationTransformingFinished event.
        /// </summary>
        private void AnnotationViewer_AnnotationTransformingFinished(
            object sender,
            AnnotationViewEventArgs e)
        {
            if (IsEnabled)
                // adds a log message about finishing of the annotation view transformation
                AddLogMessage(string.Format("{0}: TransformingFinished: {1}", GetAnnotationInfo(e.AnnotationView), GetInteractionControllerInfo(e.AnnotationView.InteractionController)));
        }

        /// <summary>
        /// Handles the AnnotationViewer.AnnotationDrawException event.
        /// </summary>
        private void AnnotationViewer_AnnotationDrawException(
            object sender,
            AnnotationViewDrawExceptionEventArgs e)
        {
            if (IsEnabled)
                // add a log message about draw exception of the annotation view
                AddLogMessage(string.Format("{0}: DrawException: {1}: {2}", GetAnnotationInfo(e.Annotation), e.Exception.GetType().Name, e.Exception.Message));
        }

        /// <summary>
        /// Returns an information about interaction controller.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <returns>
        /// The information about interaction controller.
        /// </returns>
        private string GetInteractionControllerInfo(IInteractionController controller)
        {
            CompositeInteractionController compositeController = controller as CompositeInteractionController;
            if (compositeController != null)
            {
                StringBuilder sb = new StringBuilder(string.Format("CompositeInteractionController ({0}", GetInteractionControllerInfo(compositeController.Items[0])));
                for (int i = 1; i < compositeController.Items.Count; i++)
                    sb.Append(string.Format(", {0}", GetInteractionControllerInfo(compositeController.Items[i])));
                sb.Append(")");
                return sb.ToString();
            }
            object controllerObject = (object)controller;
            return controllerObject.GetType().Name;
        }

        /// <summary>
        /// Adds a log message about mouse event.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="eventName">The event name.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void AddMouseEventLogMessage(
            AnnotationView annotationView,
            string eventName,
            MouseEventArgs e)
        {
            // location in viewer space
            PointF locationInViewerSpace = e.Location;

            // transformation from annotation space (DIP) to the viewer space
            PointFTransform toViewerTransform = annotationView.GetPointTransform(AnnotationViewer);
            PointFTransform inverseTransform = toViewerTransform.GetInverseTransform();

            // location in annotation space (DIP)
            PointF locationInAnnotationSpace = inverseTransform.TransformPoint(locationInViewerSpace);

            // location in annotation content space
            PointF locationInAnnotationContentSpace;
            // matrix from annotation content space to the annotation space (DIP)
            using (Matrix fromDipToContentSpace = VintasoftDrawingConverter.Convert(annotationView.GetTransformFromContentToImageSpace()))
            {
                // DIP space -> annotation content space
                fromDipToContentSpace.Invert();
                PointF[] points = new PointF[] { locationInAnnotationSpace };
                fromDipToContentSpace.TransformPoints(points);
                locationInAnnotationContentSpace = points[0];
            }

            AddLogMessage(string.Format("{0}.{1}: ViewerSpace={2}; ContentSpace={3}",
                GetAnnotationInfo(annotationView),
                eventName,
                locationInViewerSpace,
                locationInAnnotationContentSpace));
        }

        /// <summary>
        /// Returns a string with information about annotation view.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <returns>
        /// A string with information about annotation view.
        /// </returns>
        private string GetAnnotationInfo(AnnotationView annotationView)
        {
            if (annotationView == null)
                return "(none)";
            string type = annotationView.GetType().FullName;
            type = type.Replace("Vintasoft.Imaging.Annotation.UI.", "");
            int index = -1;
            if (AnnotationViewer.AnnotationViewCollection != null)
                index = AnnotationViewer.AnnotationViewCollection.IndexOf(annotationView);
            return string.Format("[{0}]{1}", index, type);
        }

        /// <summary>
        /// Returns a string with information about annotation data.
        /// </summary>
        /// <param name="annotationData">The annotation data.</param>
        /// <returns>
        /// A string with information about annotation data.
        /// </returns>
        private string GetAnnotationInfo(AnnotationData annotationData)
        {
            if (annotationData == null)
                return "(none)";
            string type = annotationData.GetType().FullName;
            type = type.Replace("Vintasoft.Imaging.Annotation.", "");
            int index = -1;
            if (AnnotationViewer.AnnotationDataCollection != null)
                index = AnnotationViewer.AnnotationDataCollection.IndexOf(annotationData);
            return string.Format("[{0}]{1}", index, type);
        }

        /// <summary>
        /// Adds the specified text to log text box.
        /// </summary>
        /// <param name="text">The text.</param>
        private void AddLogMessage(string text)
        {
            _logTextBox.AppendText(string.Format("{0}{1}", text, Environment.NewLine));
        }

        #endregion

        #endregion

    }
}
