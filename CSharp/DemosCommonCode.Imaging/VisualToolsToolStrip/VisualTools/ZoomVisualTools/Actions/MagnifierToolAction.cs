using System.Drawing;

using Vintasoft.Imaging.UI.VisualTools;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Stores information about a <see cref="MagnifierTool"/> action.
    /// </summary>
    public class MagnifierToolAction : VisualToolAction
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MagnifierToolAction"/> class.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        /// <param name="text">The action text.</param>
        /// <param name="toolTip">The action tool tip.</param>
        /// <param name="icon">The action icon.</param>
        /// <param name="subActions">The sub-actions of the action.</param>
        public MagnifierToolAction(
            MagnifierTool visualTool,
            string text,
            string toolTip,
            Image icon,
            params VisualToolAction[] subActions)
            : base(visualTool, text, toolTip, icon, subActions)
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Shows the visual tool settings.
        /// </summary>
        public override void ShowVisualToolSettings()
        {
            using (MagnifierToolSettingsForm dlg = new MagnifierToolSettingsForm())
            {
                dlg.Magnifier = (MagnifierTool)VisualTool;
                dlg.ShowDialog();
            }
        }

        #endregion

    }
}
