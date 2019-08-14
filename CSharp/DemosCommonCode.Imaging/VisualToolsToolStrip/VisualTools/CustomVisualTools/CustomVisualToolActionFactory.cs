using System.Drawing;

using Vintasoft.Imaging.UI.VisualTools;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Creates visual tool actions, which allow to enable/disable visual tools (<see cref="ScrollPages"/> and
    /// the composite visual tool with <see cref="RectangularSelectionTool"/> and <see cref="ScrollPages"/>) in image viewer, and adds actions to the toolstrip.
    /// </summary>
    public class CustomVisualToolActionFactory
    {

        #region Methods

        #region PUBLIC

        /// <summary>
        /// Creates visual tool actions, which allow to enable/disable visual tools (<see cref="ScrollPages"/> and
        /// the composite visual tool with <see cref="RectangularSelectionTool"/> and <see cref="ScrollPages"/>) in image viewer, and adds actions to the toolstrip.
        /// </summary>
        /// <param name="toolStrip">The toolstrip, where actions must be added.</param>
        public static void CreateActions(VisualToolsToolStrip toolStrip)
        {
            // create action, which allows to scroll pages in image viewer
            VisualToolAction scrollPagesVisualToolAction = new VisualToolAction(
                new ScrollPages(),
                "Scroll Pages",
                "Scroll Pages",
                GetIcon("ScrollPagesTool.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(scrollPagesVisualToolAction);

            // create visual tool, which allows to select rectangular area in image viewer and scroll pages in image viewer
            CompositeVisualTool selectionAndScrollPages = new CompositeVisualTool(
                new RectangularSelectionTool(), new ScrollPages());
            // create action, which allows to select rectangular area in image viewer and scroll pages in image viewer
            VisualToolAction rectangularSelectionAndScrollPagesVisualToolAction = new VisualToolAction(
                selectionAndScrollPages,
                selectionAndScrollPages.Name,
                selectionAndScrollPages.Name,
                GetIcon("SelectionScrollingTool.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(rectangularSelectionAndScrollPagesVisualToolAction);
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
                string.Format("DemosCommonCode.Imaging.VisualToolsToolStrip.VisualTools.CustomVisualTools.Resources.{0}", iconName);

            return DemosResourcesManager.GetResourceAsBitmap(iconPath);
        }

        #endregion

        #endregion

    }
}
