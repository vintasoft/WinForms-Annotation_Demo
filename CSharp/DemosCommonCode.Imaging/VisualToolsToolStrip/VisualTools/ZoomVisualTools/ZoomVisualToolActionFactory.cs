using System.Drawing;

using Vintasoft.Imaging.UI.VisualTools;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Creates visual tool action, which allows to enable/disable visual tool <see cref="MagnifierTool"/> in image viewer, and adds action to the toolstrip.
    /// </summary>
    public class ZoomVisualToolActionFactory
    {

        #region Methods

        #region PUBLIC

        /// <summary>
        /// Creates visual tool action, which allows to enable/disable visual tool <see cref="MagnifierTool"/> in image viewer, and adds action to the toolstrip.
        /// </summary>
        /// <param name="toolStrip">The toolstrip, where actions must be added.</param>
        public static void CreateActions(VisualToolsToolStrip toolStrip)
        {
            // create action, which allows to magnify of image region in image viewer
            MagnifierToolAction magnifierToolAction = new MagnifierToolAction(
                new MagnifierTool(),
                "Magnifier Tool",
                "Magnifier",
                GetIcon("MagnifierTool.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(magnifierToolAction);

            // create action, which allows to zoom an image region in image viewer
            VisualToolAction zoomSelectionToolAction = new VisualToolAction(
                new ZoomSelectionTool(),
                "Zoom Selection Tool",
                "Zoom selection",
                GetIcon("ZoomSelection.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(zoomSelectionToolAction);

            // create action, which allows to zoom an image in image viewer
            VisualToolAction zoomToolAction = new VisualToolAction(
                new ZoomTool(),
                "Zoom Tool",
                "Zoom",
                GetIcon("ZoomTool.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(zoomToolAction);
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
                string.Format("DemosCommonCode.Imaging.VisualToolsToolStrip.VisualTools.ZoomVisualTools.Resources.{0}", iconName);

            return DemosResourcesManager.GetResourceAsBitmap(iconPath);
        }

        #endregion

        #endregion

    }
}
