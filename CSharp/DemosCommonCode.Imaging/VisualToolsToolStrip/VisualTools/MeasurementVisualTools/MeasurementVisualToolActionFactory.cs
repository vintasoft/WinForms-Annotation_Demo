using System.Drawing;

#if !REMOVE_ANNOTATION_PLUGIN
using Vintasoft.Imaging.Annotation.Measurements;
#endif

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Creates visual tool action, which allows to enable/disable visual tool <see cref="ImageMeasureTool"/> in image viewer, and adds action to the toolstrip.
    /// </summary>
    public class MeasurementVisualToolActionFactory
    {

        #region Methods

        #region PUBLIC

        /// <summary>
        /// Creates visual tool action, which allows to enable/disable visual tool <see cref="ImageMeasureTool"/> in image viewer, and adds action to the toolstrip.
        /// </summary>
        /// <param name="toolStrip">The toolstrip, where actions must be added.</param>
        public static void CreateActions(VisualToolsToolStrip toolStrip)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            // create action, which allows to measure objects on image in image viewer
            ImageMeasureToolAction imageMeasureToolAction = new ImageMeasureToolAction(
                 new ImageMeasureTool(),
                 "Image Measure Tool",
                 "Image Measure Tool",
                 GetIcon("ImageMeasureTool.png"));
            // add the action to the toolstrip
            toolStrip.AddAction(imageMeasureToolAction);
#endif
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
                string.Format("DemosCommonCode.Imaging.VisualToolsToolStrip.VisualTools.MeasurementVisualTools.Resources.{0}", iconName);

            return DemosResourcesManager.GetResourceAsBitmap(iconPath);
        }

        #endregion

        #endregion

    }
}