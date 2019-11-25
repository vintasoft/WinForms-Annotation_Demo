using System;
using System.Drawing;
using System.Globalization;

using Vintasoft.Imaging.UI.VisualTools;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Stores information about a <see cref="CustomSelectionTool"/> action.
    /// </summary>
    public class CustomSelectionAction : VisualToolAction
    {

        #region Fields

        /// <summary>
        /// The activated region type action.
        /// </summary>
        CustomSelectionRegionTypeAction _activatedRegionTypeAction;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSelectionAction"/> class.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        /// <param name="text">The action text.</param>
        /// <param name="toolTip">The action tool tip.</param>
        /// <param name="icon">The action icon.</param>
        /// <param name="subActions">The sub-actions of the action.</param>
        public CustomSelectionAction(
            CustomSelectionTool visualTool,
            string text,
            string toolTip,
            Image icon,
            params VisualToolAction[] subActions)
            : base(visualTool, text, toolTip, icon, subActions)
        {
            _activatedRegionTypeAction = null;
            if (subActions != null)
            {
                foreach (VisualToolAction subaction in subActions)
                {
                    if (subaction is CustomSelectionRegionTypeAction)
                        subaction.Activated += new EventHandler(Action_Activated);
                }
            }
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

            CustomSelectionTool visualTool = (CustomSelectionTool)VisualTool;

            visualTool.SelectionChanged +=
                new EventHandler<CustomSelectionChangedEventArgs>(customSelectionTool_SelectionChanged);
        }

        /// <summary>
        /// Deactivates this action.
        /// </summary>
        public override void Deactivate()
        {
            CustomSelectionTool visualTool = (CustomSelectionTool)VisualTool;

            visualTool.SelectionChanged -= customSelectionTool_SelectionChanged;

            base.Deactivate();
        }

        /// <summary>
        /// Selects the specified region.
        /// </summary>
        /// <param name="regionTypeAction">The region type action.</param>
        /// <returns>
        /// <b>True</b> - the specified region is selected; otherwise <b>false</b>.
        /// </returns>
        public bool SelectRegion(CustomSelectionRegionTypeAction regionTypeAction)
        {
            if (regionTypeAction == null || _activatedRegionTypeAction == regionTypeAction)
                return false;

            if (_activatedRegionTypeAction != null)
                _activatedRegionTypeAction.Deactivate();

            _activatedRegionTypeAction = regionTypeAction;

            CustomSelectionTool visualTool = (CustomSelectionTool)VisualTool;

            visualTool.Selection = regionTypeAction.Region;

            SetIcon(regionTypeAction.Icon);

            return true;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Selects the selection region.
        /// </summary>
        private void Action_Activated(object sender, EventArgs e)
        {
            CustomSelectionRegionTypeAction regionTypeAction = (CustomSelectionRegionTypeAction)sender;

            if (SelectRegion(regionTypeAction))
            {
                if (!IsActivated)
                    Activate();
            }
        }

        /// <summary>
        /// Updates visual tool status.
        /// </summary>
        private void customSelectionTool_SelectionChanged(object sender, CustomSelectionChangedEventArgs e)
        {
            Rectangle bbox = Rectangle.Round(e.Selection.GetBoundingBox());
            string status = string.Format(
                        CultureInfo.InvariantCulture,
                        "Bounding box: X={0}, Y={1}, Width={2}, Height={3}",
                        bbox.X,
                        bbox.Y,
                        bbox.Width,
                        bbox.Height);

            SetStatus(status);
        }

        #endregion

        #endregion

    }
}
