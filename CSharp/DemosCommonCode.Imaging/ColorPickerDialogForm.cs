using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to show and change the color.
    /// </summary>
    [DefaultProperty("Color")]
    public partial class ColorPickerDialogForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPickerDialogForm"/> class.
        /// </summary>
        public ColorPickerDialogForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

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
                return colorPickerControl1.Color;
            }
            set
            {
                colorPickerControl1.Color = value;
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
                return colorPickerControl1.CanEditAlphaChannel;
            }
            set
            {
                colorPickerControl1.CanEditAlphaChannel = value;
            }
        } 

        #endregion

    }
}
