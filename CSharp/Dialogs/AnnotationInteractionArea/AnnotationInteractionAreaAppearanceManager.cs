using Vintasoft.Imaging.Annotation.UI.VisualTools;
using Vintasoft.Imaging.Annotation.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;


namespace AnnotationDemo
{
    /// <summary>
    /// Manages and stores the settings for annotation interaction areas of visual tool.
    /// </summary>
    public class AnnotationInteractionAreaAppearanceManager : InteractionAreaAppearanceManager
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnotationInteractionAreaAppearanceManager"/> class.
        /// </summary>
        public AnnotationInteractionAreaAppearanceManager()
            : base()
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Sets the properties of specified interaction controller.
        /// </summary>
        /// <param name="controller">The controller of interaction areas.</param>
        protected override void SetTransformerProperties(IInteractionController controller)
        {
            base.SetTransformerProperties(controller);

            if (controller is PointBasedAnnotationRectangularTransformer)
            {
                SetResizePointSettings(((PointBasedAnnotationRectangularTransformer)controller).ResizePoints);
            }
            else if (controller is PointBasedAnnotationPointTransformer)
            {
                PointBasedAnnotationPointTransformer pointTransformer =
                  (PointBasedAnnotationPointTransformer)controller;
                if (pointTransformer != null)
                {
                    if (!(pointTransformer.PolygonPointTemplate is TriangleAnnotationInteractionPoint))
                    {
                        InteractionPolygonPoint point = (InteractionPolygonPoint)pointTransformer.PolygonPointTemplate.Clone();
                        SetPolygonPointSettings(point);
                        pointTransformer.PolygonPointTemplate = point;
                        pointTransformer.InteractionPointBackColor = PolygonPointBackgroundColor;
                        pointTransformer.SelectedInteractionPointBackColor = SelectedPolygonPointBackgroundColor;
                    }
                }
            }
        }

        #endregion

    }
}
