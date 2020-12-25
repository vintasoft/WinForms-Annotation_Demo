using System;
using System.Drawing;
using System.Globalization;

using Vintasoft.Imaging.UI.VisualTools;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Stores information about a <see cref="RectangularSelectionTool"/> action.
    /// </summary>
    public class RectangularSelectionAction : VisualToolAction
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangularSelectionAction"/> class.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        /// <param name="text">The action text.</param>
        /// <param name="toolTip">The action tool tip.</param>
        /// <param name="icon">The action icon.</param>
        /// <param name="subActions">The sub-actions of the action.</param>
        public RectangularSelectionAction(
            RectangularSelectionTool visualTool,
            string text,
            string toolTip,
            Image icon,
            params VisualToolAction[] subActions)
            : base(visualTool, text, toolTip, icon, subActions)
        {
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Activates this action.
        /// </summary>
        public override void Activate()
        {
            base.Activate();

            RectangularSelectionTool rectangularSelectionTool = (RectangularSelectionTool)VisualTool;

            rectangularSelectionTool.SelectionChanged +=
                new EventHandler<SelectionChangedEventArgs>(RectangularSelectionTool_SelectionChanged);
        }

        /// <summary>
        /// Deactivates this action.
        /// </summary>
        public override void Deactivate()
        {
            RectangularSelectionTool rectangularSelectionTool = (RectangularSelectionTool)VisualTool;

            rectangularSelectionTool.SelectionChanged -= RectangularSelectionTool_SelectionChanged;

            base.Deactivate();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// The visual tool selection is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void RectangularSelectionTool_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetStatus(ConvertRectangleToString(e.Rectangle));
        }

        /// <summary>
        /// Converts the specified rectangle to a string.
        /// </summary>
        /// <param name="rect">The rectangle.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents the specified <see cref="Rectangle"/>.
        /// </returns>
        private string ConvertRectangleToString(Rectangle rect)
        {
            return string.Format(
                        CultureInfo.InvariantCulture,
                        "X={0}, Y={1}, Width={2}, Height={3}",
                        rect.X,
                        rect.Y,
                        rect.Width,
                        rect.Height);
        }

        #endregion

        #endregion

    }
}
