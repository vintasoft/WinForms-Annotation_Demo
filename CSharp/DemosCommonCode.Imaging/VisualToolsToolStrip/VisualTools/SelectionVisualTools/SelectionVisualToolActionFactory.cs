using System.Drawing;

using Vintasoft.Imaging.UI.VisualTools;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Creates visual tool actions, which allow to enable/disable visual tools (<see cref="RectangularSelectionTool"/> and <see cref="CustomSelectionTool"/>)
    /// in image viewer, and adds actions to the toolstrip.
    /// </summary>
    public class SelectionVisualToolActionFactory
    {

        #region Methods

        #region PUBLIC

        /// <summary>
        /// Creates visual tool actions, which allow to enable/disable visual tools (<see cref="RectangularSelectionTool"/> and <see cref="CustomSelectionTool"/>)
        /// in image viewer, and adds actions to the toolstrip.
        /// </summary>
        /// <param name="toolStrip">The toolstrip, where actions must be added.</param>
        public static void CreateActions(VisualToolsToolStrip toolStrip)
        {
            // create action, which allows to select rectangle on image in image viewer
            RectangularSelectionAction rectangularSelectionAction =
                new RectangularSelectionAction(
                new RectangularSelectionToolWithCopyPaste(),
                "Rectangular Selection",
                "Rectangular Selection",
                GetIcon("RectangularSelectionTool.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(rectangularSelectionAction);


            // create the custom selection tool
            CustomSelectionTool elipticalSelection = new CustomSelectionTool();
            // set the elliptical selection as the current selection in the custom selection tool
            elipticalSelection.Selection = new EllipticalSelectionRegion();

            // create action, which allows to select the elliptical image region in an image viewer
            CustomSelectionAction ellipticalSelectionAction = new CustomSelectionAction(
                elipticalSelection,
                "Elliptical Selection",
                "Elliptical Selection",
                GetIcon("CustomSelectionToolEllipse.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(ellipticalSelectionAction);


            // the default selection region type
            CustomSelectionRegionTypeAction defaultSelectedRegion = null;
            // create action, which allows to select the custom image region in an image viewer
            CustomSelectionAction customSelectionAction =
                new CustomSelectionAction(
                    new CustomSelectionTool(),
                    "Custom Selection",
                    "Custom Selection",
                    null,
                    CreateSelectionRegionTypeActions(out defaultSelectedRegion));
            // set the default selection region type
            customSelectionAction.SelectRegion(defaultSelectedRegion);
            // add the action to the toolstrip
            toolStrip.AddAction(customSelectionAction);
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Returns the visual tool icon of specified name.
        /// </summary>
        /// <param name="iconName">The visual tool icon name.</param>
        /// <returns>
        /// The visual tool icon.
        /// </returns>
        private static Image GetIcon(string iconName)
        {
            string iconPath =
                string.Format("DemosCommonCode.Imaging.VisualToolsToolStrip.VisualTools.SelectionVisualTools.Resources.{0}", iconName);

            return DemosResourcesManager.GetResourceAsBitmap(iconPath);
        }

        /// <summary>
        /// Returns the selection region type actions.
        /// </summary>
        /// <param name="defaultSelectedRegion">The default selected region.</param>
        /// <returns>
        /// The selection region type actions.
        /// </returns>
        private static VisualToolAction[] CreateSelectionRegionTypeActions(
            out CustomSelectionRegionTypeAction defaultSelectedRegion)
        {
            // create action, which allows to select the rectangular image region in an image viewer.
            CustomSelectionRegionTypeAction rectangleSelectionRegion =
                new CustomSelectionRegionTypeAction(
                        new RectangularSelectionRegion(),
                        "Rectangle",
                        "Rectangle",
                        GetIcon("CustomSelectionToolRectangle.png"));

            // create action, which allows to select the elliptical image region in an image viewer.
            CustomSelectionRegionTypeAction ellipticalSelectionRegion =
                new CustomSelectionRegionTypeAction(
                        new EllipticalSelectionRegion(),
                        "Ellipse",
                        "Ellipse",
                        GetIcon("CustomSelectionToolEllipse.png"));

            // create action, which allows to select the polygonal image region in an image viewer.
            CustomSelectionRegionTypeAction polygonSelectionRegion =
                new CustomSelectionRegionTypeAction(
                        new PolygonalSelectionRegion(),
                        "Polygon",
                        "Polygon",
                        GetIcon("CustomSelectionToolPolygon.png"));

            // create action, which allows to select the freehand polygon image region in an image viewer.
            CustomSelectionRegionTypeAction lassoSelectionRegion =
                new CustomSelectionRegionTypeAction(
                        new LassoSelectionRegion(),
                        "Lasso",
                        "Lasso",
                        GetIcon("CustomSelectionToolLasso.png"));

            // create action, which allows to select the curve image region in an image viewer.
            CustomSelectionRegionTypeAction curvesSelectionRegion =
                new CustomSelectionRegionTypeAction(
                        new CurvilinearSelectionRegion(),
                        "Curves",
                        "Curves",
                        GetIcon("CustomSelectionToolCurves.png"));

            // set the default selection region
            defaultSelectedRegion = lassoSelectionRegion;

            // returns the actions
            return new VisualToolAction[] {
                    rectangleSelectionRegion,
                    ellipticalSelectionRegion,
                    polygonSelectionRegion,
                    lassoSelectionRegion,
                    curvesSelectionRegion};
        }

        #endregion

        #endregion

    }
}
