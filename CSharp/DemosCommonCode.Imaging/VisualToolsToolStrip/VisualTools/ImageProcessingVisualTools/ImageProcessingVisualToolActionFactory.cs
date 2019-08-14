using System.Drawing;

using Vintasoft.Imaging.UI.VisualTools;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Creates visual tool actions, which allow to enable/disable visual tools (<see cref="CropSelectionTool"/>, <see cref="DragDropSelectionTool"/>,
    /// <see cref="OverlayImageTool"/> and <see cref="PanTool"/>) in image viewer, and adds actions to the toolstrip.
    /// </summary>
    public class ImageProcessingVisualToolActionFactory
    {

        #region Methods

        #region PUBLIC

        /// <summary>
        /// Creates visual tool actions, which allow to enable/disable visual tools (<see cref="CropSelectionTool"/>, <see cref="DragDropSelectionTool"/>,
        /// <see cref="OverlayImageTool"/> and <see cref="PanTool"/>) in image viewer, and adds actions to the toolstrip.
        /// </summary>
        /// <param name="toolStrip">The toolstrip, where actions must be added.</param>
        public static void CreateActions(VisualToolsToolStrip toolStrip)
        {
            // create action, which allows to crop an image in image viewer
            VisualToolAction cropSelectionToolAction = new VisualToolAction(
                new CropSelectionTool(),
                "Crop Selection Tool",
                "Crop selection",
                GetIcon("CropSelectionTool.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(cropSelectionToolAction);

            // create action, which allows to drag-and-drop an image region in image viewer
            VisualToolAction dragDropSelectionToolAction = new VisualToolAction(
                new DragDropSelectionTool(),
                "Drag-n-drop Selection Tool",
                "Drag-n-drop selection",
                GetIcon("DragDropTool.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(dragDropSelectionToolAction);

            // create action, which allows to overlay an image on a top of image in image viewer
            OverlayImageToolAction overlayImageToolAction = new OverlayImageToolAction(
                new OverlayImageTool(),
                "Overlay Image Tool",
                "Overlay Image",
                GetIcon("OverlayTool.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(overlayImageToolAction);

            // create action, which allows to pan an image in image viewer
            VisualToolAction panToolAction = new VisualToolAction(
                new PanTool(),
                "Pan Tool",
                "Pan",
                GetIcon("PanTool.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(panToolAction);
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
                string.Format("DemosCommonCode.Imaging.VisualToolsToolStrip.VisualTools.ImageProcessingVisualTools.Resources.{0}", iconName);

            return DemosResourcesManager.GetResourceAsBitmap(iconPath);
        }

        #endregion

        #endregion

    }
}
