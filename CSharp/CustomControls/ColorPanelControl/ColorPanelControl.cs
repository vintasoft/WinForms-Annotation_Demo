using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace DemosCommonCode.CustomControls
{
    /// <summary>
    /// A panel that allows to show the selected color and change the selected color.
    /// </summary>
    [DefaultEvent("ColorChanged")]
    [DefaultProperty("Color")]
    public partial class ColorPanelControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPanelControl"/> class.
        /// </summary>
        public ColorPanelControl()
        {
            InitializeComponent();

            CanSetColor = true;
            toolTip1.SetToolTip(colorButton, "Click the button if the current color must be changed.");
            toolTip1.SetToolTip(defaultColorButton, "Click the button if the current color must be set to the default color.");
        }

        #endregion



        #region Properties

        Color _color = Color.Transparent;
        /// <summary>
        /// Gets or sets the current color.
        /// </summary>
        /// <value>
        /// Default value is <b>Color.Transparent</b>.
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

                    UpdateColorPanel();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the current color can be changed.
        /// </summary>
        /// <value>
        /// <b>True</b> if the button, which allows to change the current color, is visible;
        /// otherwise, <b>false</b>.
        /// </value>
        [Description("Indicates whether the current color can be changed.")]
        [DefaultValue(true)]
        public bool CanSetColor
        {
            get
            {
                return colorButton.Visible;
            }
            set
            {
                colorButton.Visible = value;

                Cursor cursor = Cursors.Default;
                string toolTip = string.Empty;
                if (value)
                {
                    toolTip = "Double click on the panel if the current color must be changed.";
                    cursor = Cursors.Hand;
                }

                toolTip1.SetToolTip(colorPanel, toolTip);
                colorPanel.Cursor = cursor;
                toolTip1.SetToolTip(colorNameLabel, toolTip);
                colorNameLabel.Cursor = cursor;
            }
        }

        /// <summary>
        /// Gets or sets the width of button, which allows to change the current color.
        /// </summary>
        [Description("The width of button, which allows to change the current color.")]
        [DefaultValue(25)]
        public int ColorButtonWidth
        {
            get
            {
                return colorButton.Width;
            }
            set
            {
                colorButton.Width = Math.Max(1, value);
            }
        }

        /// <summary>
        /// Gets or sets the margin of button, which allows to change the current color.
        /// </summary>
        /// <value>
        /// Default value is <b>3</b>.
        /// </value>
        [Description("The margin of button, which allows to change the current color.")]
        [DefaultValue(3)]
        public int ColorButtonMargin
        {
            get
            {
                if (_colorRightToLeft)
                    return colorButton.Margin.Right;
                else
                    return colorButton.Margin.Left;
            }
            set
            {
                Padding padding;
                if (_colorRightToLeft)
                    padding = new Padding(0, 0, Math.Max(0, value), 0);
                else
                    padding = new Padding(Math.Max(0, value), 0, 0, 0);

                colorButton.Margin = padding;
            }
        }

        /// <summary>
        /// Gets or sets the text of button, which allows to change the current color.
        /// </summary>
        /// <value>
        /// Default value is <b>...</b>.
        /// </value>
        [Description("The text of button, which allows to change the current color.")]
        [DefaultValue("...")]
        public string ColorButtonText
        {
            get
            {
                return colorButton.Text;
            }
            set
            {
                if (value != null)
                    colorButton.Text = value;
            }
        }

        bool _showColorName = false;
        /// <summary>
        /// Gets or sets a value indicating whether the color must can be shown.
        /// </summary>
        /// <value>
        /// <b>true</b> - the color name must be shown; otherwise, <b>false</b>.
        /// </value>
        [Description("Indicates whether the color name must be shown.")]
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
                    UpdateColorPanel();
                }
            }
        }

        Color _defaultColor = Color.Empty;
        /// <summary>
        /// Gets or sets the default color.
        /// </summary>
        /// <value>
        /// Default value is <b>Color.Empty</b>.
        /// </value>
        [Description("The default color.")]
        public Color DefaultColor
        {
            get
            {
                return _defaultColor;
            }
            set
            {
                _defaultColor = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the default color can be changed.
        /// </summary>
        /// <value>
        /// <b>True</b> - the default color can be changed; otherwise, <b>false</b>.
        /// </value>
        [Description("Indicates whether the default color can be changed.")]
        [DefaultValue(false)]
        public bool CanSetDefaultColor
        {
            get
            {
                return defaultColorButton.Visible;
            }
            set
            {
                defaultColorButton.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of button, which allows to change the default color.
        /// </summary>
        [Description("The width of button, which allows to change the default color.")]
        [DefaultValue(25)]
        public int DefaultColorButtonWidth
        {
            get
            {
                return defaultColorButton.Width;
            }
            set
            {
                defaultColorButton.Width = Math.Max(1, value);
            }
        }

        /// <summary>
        /// Gets or sets the margin of button, which allows to change the default color.
        /// </summary>
        /// <value>
        /// Default value is <b>3</b>.
        /// </value>
        [Description("The margin of button, which allows to change the default color.")]
        [DefaultValue(3)]
        public int DefaultColorButtonMargin
        {
            get
            {
                if (_colorRightToLeft)
                    return defaultColorButton.Margin.Right;
                else
                    return defaultColorButton.Margin.Left;
            }
            set
            {
                Padding padding;
                if (_colorRightToLeft)
                    padding = new Padding(0, 0, Math.Max(0, value), 0);
                else
                    padding = new Padding(Math.Max(0, value), 0, 0, 0);

                defaultColorButton.Margin = padding;
            }
        }

        /// <summary>
        /// Gets or sets the text of button, which allows to change the default color.
        /// </summary>
        /// <value>
        /// Default value is <b>X</b>.
        /// </value>
        [Description("The text of button, which allows to change the default color.")]
        [DefaultValue("X")]
        public string DefaultColorButtonText
        {
            get
            {
                return defaultColorButton.Text;
            }
            set
            {
                if (value != null)
                    defaultColorButton.Text = value;
            }
        }

        bool _colorRightToLeft = false;
        /// <summary>
        /// Gets or sets a value indicating whether the color panel and buttons
        /// must be positioned from the right to the left.
        /// </summary>
        /// <value>
        /// Default value is <b>false</b>.
        /// </value>
        [Description("Indicates that the color panel and buttons must be positioned from the right to the left.")]
        [DefaultValue(false)]
        public bool ColorRightToLeft
        {
            get
            {
                return _colorRightToLeft;
            }
            set
            {
                if (_colorRightToLeft != value)
                {
                    int colorButtonMargin = ColorButtonMargin;
                    int defaultColorButtonMargin = DefaultColorButtonMargin;

                    _colorRightToLeft = value;

                    if (_colorRightToLeft)
                    {
                        tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.AutoSize;
                        tableLayoutPanel1.SetColumn(colorButton, 0);

                        tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.AutoSize;
                        tableLayoutPanel1.SetColumn(defaultColorButton, 1);

                        tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.Percent;
                        tableLayoutPanel1.ColumnStyles[2].Width = 100;
                        tableLayoutPanel1.SetColumn(backgroundPanel, 2);
                    }
                    else
                    {
                        tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent;
                        tableLayoutPanel1.ColumnStyles[0].Width = 100;
                        tableLayoutPanel1.SetColumn(backgroundPanel, 0);

                        tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.AutoSize;
                        tableLayoutPanel1.SetColumn(colorButton, 1);

                        tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.AutoSize;
                        tableLayoutPanel1.SetColumn(defaultColorButton, 2);
                    }

                    ColorButtonMargin = colorButtonMargin;
                    DefaultColorButtonMargin = defaultColorButtonMargin;
                }
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of ColorButton object.
        /// </summary>
        private void colorButton_Click(object sender, EventArgs e)
        {
            // show color dialog
            ShowColorDialog();
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of ColorPanel object.
        /// </summary>
        private void colorPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // if color can be changed
            if (CanSetColor && e.Button == MouseButtons.Left)
                // show color dialog
                ShowColorDialog();
        }

        /// <summary>
        /// Handles the Click event of DefaultColorButton object.
        /// </summary>
        private void defaultColorButton_Click(object sender, EventArgs e)
        {
            // if current color is not default color
            if (Color != _defaultColor)
            {
                // update color
                Color = _defaultColor;

                if (ColorChanged != null)
                    // raise color changed event
                    ColorChanged(this, EventArgs.Empty);
            }
        }

        #endregion


        /// <summary>
        /// Updates the color panel.
        /// </summary>
        private void UpdateColorPanel()
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
                    // if current color has transparency
                    if (foreColor.A != 255)
                        // remove transparency
                        foreColor = Color.FromArgb(255, foreColor);
                }

                string colorName;
                // if selected color is default color
                if (CanSetDefaultColor &&
                    color == DefaultColor)
                {
                    colorName = "Default";
                }
                // if color name is known
                else if (color.IsNamedColor)
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

        /// <summary>
        /// Shows the color dialog.
        /// </summary>
        private void ShowColorDialog()
        {
            colorDialog.Color = Color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (Color != colorDialog.Color)
                {
                    Color = colorDialog.Color;

                    if (ColorChanged != null)
                        ColorChanged(this, EventArgs.Empty);
                }
            }
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when color is changed.
        /// </summary>
        public event EventHandler ColorChanged;

        #endregion

    }
}
