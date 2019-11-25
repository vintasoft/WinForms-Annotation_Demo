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
using Vintasoft.Imaging.Utils;

namespace DemosCommonCode.Annotation
{
    public class AnnotationsLogger : AnnotationsEventsHandler
    {

        #region Fields

        TextBox _outputTextBox;

        #endregion



        #region Constructor

        public AnnotationsLogger(AnnotationViewer annotationViewer, TextBox outputTextBox)
            : base(annotationViewer, true, true)
        {
            _outputTextBox = outputTextBox;

            annotationViewer.AnnotationTransformingStarted += new EventHandler<AnnotationViewEventArgs>(annotationViewer_AnnotationTransformingStarted);
            annotationViewer.AnnotationTransformingFinished += new EventHandler<AnnotationViewEventArgs>(annotationViewer_AnnotationTransformingFinished);
            annotationViewer.FocusedAnnotationViewChanged += new EventHandler<AnnotationViewChangedEventArgs>(annotationViewer_FocusedAnnotationViewChanged);
            annotationViewer.AnnotationDrawException += new EventHandler<AnnotationViewDrawExceptionEventArgs>(annotationViewer_AnnotationDrawException);
        }

        #endregion



        #region Methods

        private void annotationViewer_FocusedAnnotationViewChanged(
            object sender,
            AnnotationViewChangedEventArgs e)
        {
            if (IsEnabled)
                AddLogMessage(string.Format("FocusedAnnotationViewChanged: {0} -> {1}", GetAnnotationInfo(e.OldValue), GetAnnotationInfo(e.NewValue)));
        }

        private void annotationViewer_AnnotationTransformingStarted(
            object sender,
            AnnotationViewEventArgs e)
        {
            if (IsEnabled)
                AddLogMessage(string.Format("{0}: TransformingStarted: {1}", GetAnnotationInfo(e.AnnotationView), GetInteractionControllerInfo(e.AnnotationView.InteractionController)));
        }

        private void annotationViewer_AnnotationTransformingFinished(
            object sender,
            AnnotationViewEventArgs e)
        {
            if (IsEnabled)
                AddLogMessage(string.Format("{0}: TransformingFinished: {1}", GetAnnotationInfo(e.AnnotationView), GetInteractionControllerInfo(e.AnnotationView.InteractionController)));
        }

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

        private void annotationViewer_AnnotationDrawException(
            object sender,
            AnnotationViewDrawExceptionEventArgs e)
        {
            if (IsEnabled)
                AddLogMessage(string.Format("{0}: DrawException: {1}: {2}", GetAnnotationInfo(e.Annotation), e.Exception.GetType().Name, e.Exception.Message));
        }

        protected override void OnAnnotationDataControllerChanged(
            AnnotationViewer viewer,
            PropertyChangedEventArgs<AnnotationDataController> e)
        {
            AddLogMessage("AnnotationViewer.AnnotationDataControllerChanged");
        }

        protected override void OnAnnotationViewCollectionChanged(
            AnnotationViewer viewer,
            PropertyChangedEventArgs<AnnotationViewCollection> e)
        {
            AddLogMessage("AnnotationViewer.AnnotationViewCollectionChanged");
        }

        protected override void OnDataCollectionChanged(
            AnnotationDataCollection annotationDataCollection,
            CollectionChangeEventArgs<AnnotationData> e)
        {
            if (e.NewValue != null && e.OldValue!=null)
                AddLogMessage(string.Format("DataCollection.{0}: {1}->{2}", e.Action, GetAnnotationInfo(e.OldValue), GetAnnotationInfo(e.NewValue)));
            else if (e.NewValue != null)
                AddLogMessage(string.Format("DataCollection.{0}: {1}", e.Action, GetAnnotationInfo(e.NewValue)));
            else if (e.OldValue != null)
                AddLogMessage(string.Format("DataCollection.{0}: {1}", e.Action, GetAnnotationInfo(e.OldValue)));
            else
                AddLogMessage(string.Format("DataCollection.{0}", e.Action));
        }

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

        protected override void OnClick(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "Click", e);
        }

        protected override void OnDoubleClick(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "DoubleClick", e);
        }

        protected override void OnMouseDown(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "MouseDown", e);
        }

        protected override void OnMouseEnter(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "MouseEnter", e);
        }

        protected override void OnMouseMove(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "MouseMove", e);
        }

        protected override void OnMouseUp(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "MouseUp", e);
        }

        protected override void OnMouseWheel(AnnotationView annotationView, MouseEventArgs e)
        {
            AddMouseEventLogMessage(annotationView, "MouseWheel", e);
        }


        private void AddMouseEventLogMessage(
            AnnotationView annotationView,
            string eventName,
            MouseEventArgs e)
        {
            // location in Viewer space
            PointF locationInViewerSpace = e.Location;

            // DIP(annotation space) -> ImageViewer space transformation
            PointFTransform toViewerTransform = annotationView.GetPointTransform(Viewer);
            PointFTransform inverseTransform = toViewerTransform.GetInverseTransform();

            // location in Annotation (DIP) space
            PointF locationInAnnotationSpace = inverseTransform.TransformPoint(locationInViewerSpace);

            // location in Annotation content space
            PointF locationInAnnotationContentSpace;
            // Annotation content space -> DIP(annotation space)
            using (Matrix fromDipToContentSpace = VintasoftDrawingConverter.Convert(annotationView.GetTransformFromContentToImageSpace()))
            {
                // DIP space -> Annotation content space
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

        private string GetAnnotationInfo(AnnotationView annotation)
        {
            if (annotation == null)
                return "(none)";
            string type = annotation.GetType().FullName;
            type = type.Replace("Vintasoft.Imaging.Annotation.UI.", "");
            int index = -1;
            if (Viewer.AnnotationViewCollection != null)
                index = Viewer.AnnotationViewCollection.IndexOf(annotation);
            return string.Format("[{0}]{1}", index, type);
        }

        private string GetAnnotationInfo(AnnotationData annotation)
        {
            if (annotation == null)
                return "(none)";
            string type = annotation.GetType().FullName;
            type = type.Replace("Vintasoft.Imaging.Annotation.", "");
            int index = -1;
            if (Viewer.AnnotationDataCollection != null)
                index = Viewer.AnnotationDataCollection.IndexOf(annotation);
            return string.Format("[{0}]{1}", index, type);
        }

        private void AddLogMessage(string text)
        {
            _outputTextBox.AppendText(string.Format("{0}{1}", text, Environment.NewLine));
        }

        #endregion

    }
}
