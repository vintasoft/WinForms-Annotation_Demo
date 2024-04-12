using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DemosCommonCode.CustomControls
{
    /// <summary>
    /// A panel that allows to show the selected color.
    /// </summary>
    [DefaultProperty("Color")]
    public partial class ColorSampleControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSampleControl"/> class.
        /// </summary>
        public ColorSampleControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        Color _color = Color.Transparent;
        /// <summary>
        /// Gets or sets the current color.
        /// </summary>
        /// <value>
        /// Default value is <b><see cref="Color.Transparent"/></b>.
        /// </value>
        [Description("The current color.")]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    UpdateColorSample();
                }
            }
        }

        bool _showColorName = false;
        /// <summary>
        /// Gets or sets a value indicating whether the color name must be shown.
        /// </summary>
        /// <value>
        /// <b>true</b> - the color name must be shown; otherwise, <b>false</b>.
        /// </value>
        [Description("A value indicating whether the color name must be shown.")]
        [DefaultValue(false)]
        public bool ShowColorName
        {
            get
            {
                return _showColorName;
            }
            set
            {
                if (_showColorName != value)
                {
                    _showColorName = value;
                    UpdateColorSample();
                }
            }
        }

        string _toolTip = "";
        /// <summary>
        /// Gets or sets the tooltip text.
        /// </summary>
        [Description("The tooltip text.")]
        [DefaultValue("")]
        public string ToolTip
        {
            get
            {
                return _toolTip;
            }
            set
            {
                if (_toolTip != value)
                {
                    _toolTip = value;

                    if (_toolTip == null)
                        _toolTip = "";

                    toolTip1.SetToolTip(colorPanel, _toolTip);
                    toolTip1.SetToolTip(colorNameLabel, _toolTip);
                }
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the CursorChanged event of ColorSampleControl object.
        /// </summary>
        private void ColorSampleControl_CursorChanged(object sender, EventArgs e)
        {
            colorPanel.Cursor = Cursor;
            colorNameLabel.Cursor = Cursor;
        }

        /// <summary>
        /// Handles the MouseClick event of colorNameLabel object.
        /// </summary>
        private void colorNameLabel_MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick(e);
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of colorNameLabel object.
        /// </summary>
        private void colorNameLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        /// <summary>
        /// Handles the MouseClick event of colorPanel object.
        /// </summary>
        private void colorPanel_MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick(e);
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of colorPanel object.
        /// </summary>
        private void colorPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        #endregion


        /// <summary>
        /// Updates the color sample.
        /// </summary>
        private void UpdateColorSample()
        {
            Color color = Color;
            colorPanel.BackColor = color;

            // if color name must be shown
            if (ShowColorName)
            {
                Color foreColor;
                // if color is empty
                if (color.IsEmpty)
                {
                    foreColor = Color.Black;
                }
                // if color is white
                else if (Math.Abs(color.R - 128) < 30 &&
                         Math.Abs(color.G - 128) < 30 &&
                         Math.Abs(color.B - 128) < 30)
                {
                    foreColor = Color.White;
                }
                else
                {
                    // get inverted color
                    foreColor = Color.FromArgb(0xFFFFFF ^ color.ToArgb());
                    // if color has transparency
                    if (foreColor.A != 255)
                        // remove transparency
                        foreColor = Color.FromArgb(255, foreColor);
                }

                string colorName;
                // if color has known name
                if (color.IsNamedColor)
                {
                    colorName = color.Name;
                }
                else
                {
                    // get HEX color value
                    colorName = String.Format("#{0}{1}{2}",
                            color.R.ToString("X2"),
                            color.G.ToString("X2"),
                            color.B.ToString("X2"));
                }

                colorNameLabel.ForeColor = foreColor;
                colorNameLabel.Text = colorName;
            }
            else if (!string.IsNullOrEmpty(colorNameLabel.Text))
                colorNameLabel.Text = string.Empty;
        }

        #endregion

    }
}
