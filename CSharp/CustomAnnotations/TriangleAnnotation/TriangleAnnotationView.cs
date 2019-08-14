using System.Drawing;

using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Annotation.UI.VisualTools.UserInteraction;

namespace AnnotationDemo
{
    /// <summary>
    /// Class that determines how to display the annotation that displays a triangle
    /// and how user can interact with annotation.
    /// </summary>
    public class TriangleAnnotationView : PolygonAnnotationView
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleAnnotationView"/> class.
        /// </summary>
        /// <param name="annotationData">Object that stores the annotation data.</param>
        public TriangleAnnotationView(TriangleAnnotationData annotationData)
            : base(annotationData)
        {
            FillBrush = null;

            // create a point-based builder
            Builder = new PointBasedAnnotationPointBuilder(this, 3, 3);

            // create a transformer for rectangular mode
            PointBasedAnnotationRectangularTransformer rectangleTransformer = new PointBasedAnnotationRectangularTransformer(this);
            // show bounding box area
            rectangleTransformer.BoundingBoxArea.IsVisible = true;
            RectangularTransformer = rectangleTransformer;

            // create a transformer for point mode
            PointBasedAnnotationPointTransformer pointsTransformer = new PointBasedAnnotationPointTransformer(this);
            // change interaction points color
            pointsTransformer.InteractionPointBackColor = Color.FromArgb(100, Color.Red);
            pointsTransformer.SelectedInteractionPointBackColor = Color.FromArgb(150, Color.Red);
            // change interaction points type
            pointsTransformer.PolygonPointTemplate = new TriangleAnnotationInteractionPoint();
            PointTransformer = pointsTransformer;

            GripMode = GripMode.RectangularAndPoints;                
        }

        #endregion



        #region Methods

        /// <summary>
        /// Creates a new object that is a copy of the current 
        /// <see cref="TriangleAnnotationView"/> instance.
        /// </summary>
        /// <returns>A new object that is a copy of this <see cref="TriangleAnnotationView"/>
        /// instance.</returns>
        public override object Clone()
        {
            return new TriangleAnnotationView((TriangleAnnotationData)this.Data.Clone());
        }

        #endregion

    }
}
