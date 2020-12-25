using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Annotation.UI.VisualTools.UserInteraction;


namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Class that determines how to display the annotation that displays a mark
    /// and how user can interact with annotation.
    /// </summary>
    public class MarkAnnotationView : AnnotationView, IRectangularInteractiveObject
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkAnnotationView"/> class.
        /// </summary>
        /// <param name="annotationData">Object that stores the annotation data.</param>
        public MarkAnnotationView(MarkAnnotationData annotationData)
            : base(annotationData)
        {
            SizeF initialSize = Size;
            if (initialSize.IsEmpty)
            {
                initialSize = new Size(64, 64);
                Size = initialSize;
            }
            Builder = new MarkAnnotationBuilder(this);

            RectangularAnnotationTransformer transformer = new RectangularAnnotationTransformer(this);
            transformer.HideInteractionPointsWhenMoving = true;
            foreach (InteractionPoint point in transformer.ResizePoints)
                point.FillColor = Color.FromArgb(100, Color.Red);
            Transformer = transformer;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets a mark type.
        /// </summary>
        [Description("The mark type.")]
        [DefaultValue(MarkAnnotationType.Tick)]
        public MarkAnnotationType MarkType
        {
            get
            { 
                return MarkAnnoData.MarkType;
            }
            set 
            { 
                MarkAnnoData.MarkType = value;
            }
        }

        /// <summary>
        /// Gets an annotation data.
        /// </summary>
        MarkAnnotationData MarkAnnoData
        {
            get 
            { 
                return (MarkAnnotationData)Data;
            }
        }

        /// <summary>
        /// Gets or sets the rotation angle of interactive object.
        /// </summary>
        double IRectangularInteractiveObject.RotationAngle
        {
            get 
            { 
                return Rotation; 
            }
            set 
            { 
                Rotation = (float)value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Indicates whether the specified point is contained within the annotation.
        /// </summary>
        /// <param name="point">Point in image space.</param>
        /// <returns><b>true</b> if the specified point is contained within the annotation;
        /// otherwise, <b>false</b>.</returns>
        public override bool IsPointOnFigure(PointF point)
        {
            using (Matrix m = VintasoftDrawingConverter.Convert(GetTransformFromContentToImageSpace()))
            using (GraphicsPath path = ((MarkAnnotationRenderer)Renderer).GetAsGraphicsPath())
            {
                path.Transform(m);
                using (Pen pen = ObjectConverter.CreateDrawingPen(Outline))
                {
                    return path.IsVisible(point) || path.IsOutlineVisible(point, pen);
                }
            }
        }

        /// <summary>
        /// Creates a new object that is a copy of the current 
        /// <see cref="MarkAnnotationView"/> instance.
        /// </summary>
        /// <returns>A new object that is a copy of this <see cref="MarkAnnotationView"/>
        /// instance.</returns>
        public override object Clone()
        {
            return new MarkAnnotationView((MarkAnnotationData)this.Data.Clone());
        }

        /// <summary>
        /// Returns an annotation selection as <see cref="GraphicsPath"/> in annotation content space.
        /// </summary>
        public override GraphicsPath GetSelectionAsGraphicsPath()
        {
            GraphicsPath path = new GraphicsPath();
            SizeF size = Size;
            path.AddRectangle(new RectangleF(-size.Width / 2, -size.Height / 2, size.Width, size.Height));
            using (Matrix transform = VintasoftDrawingConverter.Convert(GetTransformFromContentToImageSpace()))
                path.Transform(transform);
            return path;
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Sets the properties of interaction controller according to the properties of annotation.
        /// </summary>
        /// <param name="controller">The interaction controller.</param>
        protected override void SetInteractionControllerProperties(IInteractionController controller)
        {
            base.SetInteractionControllerProperties(controller);

            RectangularObjectTransformer rectangularTransformer = controller as RectangularObjectTransformer;
            if (rectangularTransformer != null)
            {
                rectangularTransformer.CanMove = Data.CanMove;
                rectangularTransformer.CanResize = Data.CanResize;
                rectangularTransformer.CanRotate = Data.CanRotate;
                return;
            }
        }

        /// <summary>
        /// Raises the <see cref="AnnotationView.StateChanged" /> event.
        /// Invoked when the property of annotation is changed.
        /// </summary>
        /// <param name="e">An <see cref="ObjectPropertyChangedEventArgs" />
        /// that contains the event data.</param>
        protected override void OnDataPropertyChanged(ObjectPropertyChangedEventArgs e)
        {
            base.OnDataPropertyChanged(e);

            if (e.PropertyName == "Size")
            {
                if (Builder is MarkAnnotationBuilder)
                    ((MarkAnnotationBuilder)Builder).InitialSize = (SizeF)e.NewValue;
            }
        }

        #endregion


        #region IRectangularInteractiveObject

        /// <summary>
        /// Returns a rectangle of interactive object.
        /// </summary>
        /// <param name="x0">Left-top X coordinate of rectangle.</param>
        /// <param name="y0">Left-top Y coordinate of rectangle.</param>
        /// <param name="x1">Right-bottom X coordinate of rectangle.</param>
        /// <param name="y1">Right-bottom Y coordinate of rectangle.</param>
        void IRectangularInteractiveObject.GetRectangle(
            out double x0,
            out double y0,
            out double x1,
            out double y1)
        {
            PointF location = Location;
            SizeF size = Size;
            x0 = location.X - size.Width / 2;
            y0 = location.Y - size.Height / 2;
            x1 = location.X + size.Width / 2;
            y1 = location.Y + size.Height / 2;
            if (Data.HorizontalMirrored)
            {
                double tmp = x0;
                x0 = x1;
                x1 = tmp;
            }
            if (Data.VerticalMirrored)
            {
                double tmp = y0;
                y0 = y1;
                y1 = tmp;
            }
        }

        /// <summary>
        /// Sets a rectangle of interactive object.
        /// </summary>
        /// <param name="x0">Left-top X coordinate of rectangle.</param>
        /// <param name="y0">Left-top Y coordinate of rectangle.</param>
        /// <param name="x1">Right-bottom X coordinate of rectangle.</param>
        /// <param name="y1">Right-bottom Y coordinate of rectangle.</param>
        void IRectangularInteractiveObject.SetRectangle(double x0, double y0, double x1, double y1)
        {
            Size = new SizeF((float)Math.Abs(x0 - x1), (float)Math.Abs(y0 - y1));
            Location = new PointF((float)(x0 + x1) / 2, (float)(y0 + y1) / 2);

            HorizontalMirrored = x0 > x1;
            VerticalMirrored = y0 > y1;

            if (Data.IsInitializing)
                OnStateChanged();
        }

        #endregion

        #endregion

    }
}
