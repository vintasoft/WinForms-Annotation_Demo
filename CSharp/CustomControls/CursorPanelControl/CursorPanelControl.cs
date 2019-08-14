using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.UI.VisualTools;


namespace DemosCommonCode.CustomControls
{
    /// <summary>
    /// A panel that allows to show the selected cursor and change the selected cursor.
    /// </summary>
    [DefaultProperty("SelectedCursor")]
    public partial class CursorPanelControl : ComboBox
    {

        #region Fields

        /// <summary>
        /// Available cursors.
        /// </summary>
        List<Cursor> _cursors = new List<Cursor>();

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CursorPanelControl"/> class.
        /// </summary>
        public CursorPanelControl()
        {
            BeginUpdate();

            Items.Clear();

            AddCursor("CloseHandCursor (VintaSoft)", ToolCursors.CloseHandCursor);
            AddCursor("OpenHandCursor (VintaSoft)", ToolCursors.OpenHandCursor);
            AddCursor("CropSelectionCursor (VintaSoft)", ToolCursors.CropSelectionCursor);
            AddCursor("MagnifierCursor (VintaSoft)", ToolCursors.MagnifierCursor);
            AddCursor("RotateCursor (VintaSoft)", ToolCursors.RotateCursor);
            AddCursor("ZoomCursor (VintaSoft)", ToolCursors.ZoomCursor);

            AddCursor("Default", Cursors.Default);
            AddCursor("AppStarting", Cursors.AppStarting);
            AddCursor("Arrow", Cursors.Arrow);
            AddCursor("Cross", Cursors.Cross);
            AddCursor("Hand", Cursors.Hand);
            AddCursor("Help", Cursors.Help);
            AddCursor("HSplit", Cursors.HSplit);
            AddCursor("IBeam", Cursors.IBeam);
            AddCursor("No", Cursors.No);
            AddCursor("NoMove2D", Cursors.NoMove2D);
            AddCursor("NoMoveHoriz", Cursors.NoMoveHoriz);
            AddCursor("NoMoveVert", Cursors.NoMoveVert);
            AddCursor("PanEast", Cursors.PanEast);
            AddCursor("PanNE", Cursors.PanNE);
            AddCursor("PanNorth", Cursors.PanNorth);
            AddCursor("PanNW", Cursors.PanNW);
            AddCursor("PanSE", Cursors.PanSE);
            AddCursor("PanSouth", Cursors.PanSouth);
            AddCursor("PanSW", Cursors.PanSW);
            AddCursor("PanWest", Cursors.PanWest);
            AddCursor("SizeAll", Cursors.SizeAll);
            AddCursor("SizeNESW", Cursors.SizeNESW);
            AddCursor("SizeNS", Cursors.SizeNS);
            AddCursor("SizeNWSE", Cursors.SizeNWSE);
            AddCursor("SizeWE", Cursors.SizeWE);
            AddCursor("UpArrow", Cursors.UpArrow);
            AddCursor("VSplit", Cursors.VSplit);
            AddCursor("WaitCursor", Cursors.WaitCursor);

            SelectedCursor = null;
            DropDownStyle = ComboBoxStyle.DropDownList;

            EndUpdate();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the currently selected cursor.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Browsable(false)]
        public Cursor SelectedCursor
        {
            get
            {
                if (SelectedIndex == -1)
                    return null;

                return _cursors[SelectedIndex];
            }
            set
            {
                SelectedIndex = _cursors.IndexOf(value);
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Adds a cursor to the control.
        /// </summary>
        /// <param name="name">The cursor name.</param>
        /// <param name="cursor">The cursor.</param>
        private void AddCursor(string name, Cursor cursor)
        {
            _cursors.Add(cursor);
            Items.Add(name);
        }

        #endregion

    }
}
