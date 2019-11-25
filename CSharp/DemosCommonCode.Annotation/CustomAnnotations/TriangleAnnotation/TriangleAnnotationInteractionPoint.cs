using System.Drawing;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Represents rounded interaction point for vertices of triangle annotation.
    /// </summary>
    internal class TriangleAnnotationInteractionPoint : InteractionPolygonPoint
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleAnnotationInteractionPoint"/> class.
        /// </summary>
        internal TriangleAnnotationInteractionPoint()
            : base("Resize")
        {
            BorderColor = Color.Black;
            FillColor = Color.FromArgb(100, Color.Red);
            Radius = 6;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Draws the interaction area on specified graphics.
        /// </summary>
        /// <param name="viewer">The image viewer.</param>
        /// <param name="g">The graphics to draw the interaction area.</param>
        public override void Draw(ImageViewer viewer, Graphics g)
        {
            RectangleF rect = GetDrawingRect();

            if (FillBrush != null)
                g.FillEllipse(FillBrush, rect);
            if (BorderPen != null)
                g.DrawEllipse(BorderPen, rect);
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public override InteractionArea Clone()
        {
            TriangleAnnotationInteractionPoint area = new TriangleAnnotationInteractionPoint();
            CopyTo(area);
            return area;
        }

        #endregion

    }
}
