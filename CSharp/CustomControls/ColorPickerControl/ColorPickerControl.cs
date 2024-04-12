using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DemosCommonCode.CustomControls
{
    /// <summary>
    /// A panel that allows to show the selected color and change the selected color.
    /// </summary>
    [DefaultProperty("Color")]
    [DefaultEvent("ColorChanged")]
    public partial class ColorPickerControl : UserControl
    {

        #region Fields

        /// <summary>
        /// A value indicating whether the user interface of this panel is updating.
        /// </summary>
        bool _isUiUpdating = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPickerControl"/> class.
        /// </summary>
        public ColorPickerControl()
        {
            InitializeComponent();

            Color = Color.White;
            CanEditAlphaChannel = true;

            colorSampleControl.ToolTip = "Click on the panel if current color must be changed.";
        }

        #endregion



        #region Properties

        Color _color;
        /// <summary>
        /// Gets or sets the current color.
        /// </summary>
        /// <value>
        /// Default value is <b><see cref="Color.White"/></b>.
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
                SetColor(value);

                channelAlphaValueEditorControl.DefaultValue = value.A;
                channelRedValueEditorControl.DefaultValue = value.R;
                channelGreenValueEditorControl.DefaultValue = value.G;
                channelBlueValueEditorControl.DefaultValue = value.B;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the alpha channel, of color, can be edited.
        /// </summary>
        /// <value>
        /// <b>true</b> if the alpha channel, of color, can be edited; otherwise, <b>false</b>.
        /// </value>
        [Description("A value indicating whether the alpha channel, of color, can be edited.")]
        [DefaultValue(true)]
        public bool CanEditAlphaChannel
        {
            get
            {
                return channelAlphaValueEditorControl.Enabled;
            }
            set
            {
                channelAlphaValueEditorControl.Enabled = value;

                if (value)
                {
                    hexValueLabel.Text = "Hex (ARGB):";
                    hexValueTextBox.MaxLength = 8;
                }
                else
                {
                    hexValueLabel.Text = "Hex (RGB):";
                    hexValueTextBox.MaxLength = 6;
                }

                UpdateTextBoxValue(Color);
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the MouseClick event of colorSampleControl object.
        /// </summary>
        private void colorSampleControl_MouseClick(object sender, MouseEventArgs e)
        {
            // set color
            colorDialog.Color = Color;
            // if color must be changed
            if (colorDialog.ShowDialog() == DialogResult.OK)
                // change color
                SetColor(colorDialog.Color);
        }

        /// <summary>
        /// Handles the Leave event of hexValueTextBox object.
        /// </summary>
        private void hexValueTextBox_Leave(object sender, EventArgs e)
        {
            // restore color value
            UpdateTextBoxValue(Color);
        }

        /// <summary>
        /// Handles the TextChanged event of hexValueTextBox object.
        /// </summary>
        private void hexValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hexValueTextBox.Text) &&
                hexValueTextBox.Text.Length == hexValueTextBox.MaxLength)
            {
                int value;
                // if value is stored in hexadecimal format
                if (int.TryParse(hexValueTextBox.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out value))
                    // change color
                    SetColor(Color.FromArgb(value));
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of channelValueEditorControl object.
        /// </summary>
        private void channelValueEditorControl_ValueChanged(object sender, EventArgs e)
        {
            // if the user interface is updating
            if (_isUiUpdating)
                return;

            // get alpha channel
            int a = (int)channelAlphaValueEditorControl.Value;
            // get red channel
            int r = Color.R;
            // get green channel
            int g = Color.G;
            // get blue channel
            int b = Color.B;

            // if RGB channels are locked
            if (lockRgbCheckBox.Checked)
            {
                int dx = 0;
                // if red channel is changed
                if (r != channelRedValueEditorControl.Value)
                    dx = (int)channelRedValueEditorControl.Value - r;
                // if green channel is changed
                else if (g != channelGreenValueEditorControl.Value)
                    dx = (int)channelGreenValueEditorControl.Value - g;
                // if blue channel is changed
                else if (b != channelBlueValueEditorControl.Value)
                    dx = (int)channelBlueValueEditorControl.Value - b;

                // calculate red channel
                r = Math.Min(255, Math.Max(0, r + dx));
                // calculate green channel
                g = Math.Min(255, Math.Max(0, g + dx));
                // calculate blue channel
                b = Math.Min(255, Math.Max(0, b + dx));
            }
            else
            {
                // get red channel
                r = (int)channelRedValueEditorControl.Value;
                // get green channel
                g = (int)channelGreenValueEditorControl.Value;
                // get blue channel
                b = (int)channelBlueValueEditorControl.Value;
            }

            // change color
            SetColor(Color.FromArgb(a, r, g, b));
        }

        #endregion


        #region UI state

        /// <summary>
        /// Updates the user interface of this panel.
        /// </summary>
        private void UpdateUI()
        {
            _isUiUpdating = true;

            channelAlphaValueEditorControl.Value = Color.A;
            channelRedValueEditorControl.Value = Color.R;
            channelGreenValueEditorControl.Value = Color.G;
            channelBlueValueEditorControl.Value = Color.B;

            colorSampleControl.Color = Color;
            UpdateTextBoxValue(Color);

            _isUiUpdating = false;
        }

        #endregion


        /// <summary>
        /// Updates the text box with color value in hexadecimal format.
        /// </summary>
        /// <param name="color">The color.</param>
        private void UpdateTextBoxValue(Color color)
        {
            // get color value in hexadecimal format
            string text = string.Format("{0:X8}", color.ToArgb());

            // if alpha channel must be removed
            if (!CanEditAlphaChannel)
                // remove alpha channel
                text = text.Substring(2);

            // update text box
            hexValueTextBox.Text = text;
        }

        /// <summary>
        /// Sets the current color.
        /// </summary>
        /// <param name="color">The color.</param>
        private void SetColor(Color color)
        {
            // if color is changed
            if (Color != color)
            {
                // change color
                _color = color;

                // if alpha channel must be removed
                if (_color.A != 255 && !CanEditAlphaChannel)
                    _color = Color.FromArgb(255, _color);

                // update the UI
                UpdateUI();


                if (ColorChanged != null)
                    ColorChanged(this, EventArgs.Empty);
            }
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when <see cref="Color"/> is changed.
        /// </summary>
        public event EventHandler ColorChanged;

        #endregion

    }
}
