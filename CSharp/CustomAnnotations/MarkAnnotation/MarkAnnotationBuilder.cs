using System.Drawing;

using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

namespace AnnotationDemo
{
    /// <summary>
    /// Interaction controller that builds a mark annotation.
    /// </summary>
    public class MarkAnnotationBuilder : InteractionControllerBase<IRectangularInteractiveObject>
    {

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkAnnotationBuilder"/> class.
        /// </summary>
        /// <param name="view">The mark annotation.</param>
        /// <param name="initialSize">The initial size of annotation.</param>
        public MarkAnnotationBuilder(MarkAnnotationView view)
            : base(view)
        {
            // create an interaction area that can be moved, hovered and clicked
            ImageViewerArea buildArea = new ImageViewerArea(
                InteractionAreaType.Hover | InteractionAreaType.Movable | InteractionAreaType.Clickable);
            // mark that any mouse button can interact with interaction area
            buildArea.AnyActionMouseButton = true;
            // add the interacton area to a list of interaction areas of the interaction controller
            InteractionAreaList.Add(buildArea);

            // set initial size of annotation
            _initialSize = view.Size;
        }

        #endregion



        #region Properties
        
        SizeF _initialSize;
        /// <summary>
        /// Gets or sets an annotation initial size.
        /// </summary>
        public SizeF InitialSize
        {
            get
            {
                return _initialSize;
            }
            set
            {
                _initialSize = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Performs an interaction between user and interaction area.
        /// </summary>
        /// <param name="args">An interaction event args.</param>
        protected override void PerformInteraction(InteractionEventArgs args)
        {
            // set rectangle of annotation
            InteractiveObject.SetRectangle(
                        args.Location.X - _initialSize.Width / 2, args.Location.Y - _initialSize.Height / 2,
                        args.Location.X + _initialSize.Width / 2, args.Location.Y + _initialSize.Height / 2);

            // mark that the user interacted with annotation
            args.InteractionOccured(true);

            // if any mouse button is clicked
            if (args.Action == InteractionAreaAction.Click)
                // finish building of annotation
                args.InteractionFinished = true;
        }

        #endregion

    }
}
