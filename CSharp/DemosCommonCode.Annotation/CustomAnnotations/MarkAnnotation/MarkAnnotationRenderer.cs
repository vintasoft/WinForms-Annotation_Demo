using System.Drawing;
using System.Drawing.Drawing2D;

using Vintasoft.Imaging;

using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.Rendering;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Determines how to render the mark annotation.
    /// </summary>
    public class MarkAnnotationRenderer : AnnotationGraphicsRenderer
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkAnnotationRenderer"/> class.
        /// </summary>
        /// <param name="annotationData">Object that stores the annotation data.</param>
        public MarkAnnotationRenderer(MarkAnnotationData annotationData)
            : base(annotationData)
        {
        }

        #endregion



        #region Properties

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

        #endregion



        #region Methods

        /// <summary>
        /// Returns a drawing box of annotation, in the image space.
        /// </summary>
        /// <param name="drawingSurface">The object that provides information about drawing surface.</param>
        /// <returns>Drawing box of annotation, in the image space.</returns>
        public override RectangleF GetDrawingBox(DrawingSurface drawingSurface)
        {
            using (Matrix m = VintasoftDrawingConverter.Convert(GetTransformFromContentToImageSpace()))
            {
                using (GraphicsPath path = GetAsGraphicsPath())
                {
                    using (Pen pen = ObjectConverter.CreateDrawingPen(Data.Outline))
                    {
                        return path.GetBounds(m, pen);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a mark annotation as <see cref="GraphicsPath"/> in content space.
        /// </summary>
        public virtual GraphicsPath GetAsGraphicsPath()
        {
            GraphicsPath path = new GraphicsPath();

            PointF[] referencePoints = MarkAnnoData.GetReferencePointsInContentSpace();

            switch (MarkAnnoData.MarkType)
            {
                case MarkAnnotationType.Tick:
                    path.AddCurve(referencePoints);
                    break;
                default:
                    path.AddPolygon(referencePoints);
                    break;
            }

            return path;
        }


        /// <summary>
        /// Renders the annotation on the <see cref="System.Drawing.Graphics"/>
        /// in the coordinate space of annotation.
        /// </summary>
        /// <param name="g">The <see cref="System.Drawing.Graphics"/> to draw on.</param>
        /// <param name="drawingSurface">The object that provides information about drawing surface.</param>
        protected override void RenderInContentSpace(Graphics g, DrawingSurface drawingSurface)
        {
            using (GraphicsPath path = GetAsGraphicsPath())
            {
                if (Data.FillBrush != null)
                {
                    using (Brush brush = ObjectConverter.CreateDrawingBrush(Data.FillBrush))
                        g.FillPath(brush, path);
                }
                if (Data.Border)
                {
                    using (Pen pen = ObjectConverter.CreateDrawingPen(Data.Outline))
                        g.DrawPath(pen, path);
                }
            }
        }

        #endregion

    }
}
