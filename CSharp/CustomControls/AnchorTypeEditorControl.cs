using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging;

namespace DemosCommonCode.CustomControls
{
    /// <summary>
    /// A control that allows to change value of <see cref="AnchorType"/> type.
    /// </summary>
    public partial class AnchorTypeEditorControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnchorTypeEditorControl"/> class.
        /// </summary>
        public AnchorTypeEditorControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the type of the selected <see cref="AnchorType"/> property.
        /// </summary>
        /// <value>
        /// The type of the selected AnchorType property.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public AnchorType SelectedAnchorType
        {
            get
            {
                if (topLeftRadioButton.Checked)
                    return AnchorType.TopLeft;

                if (topRadioButton.Checked)
                    return AnchorType.Top;

                if (topRightRadioButton.Checked)
                    return AnchorType.TopRight;

                if (leftRadioButton.Checked)
                    return AnchorType.Left;

                if (centerRadioButton.Checked)
                    return AnchorType.Center;

                if (rightRadioButton.Checked)
                    return AnchorType.Right;

                if (bottomLeftRadioButton.Checked)
                    return AnchorType.BottomLeft;

                if (bottomRadioButton.Checked)
                    return AnchorType.Bottom;

                if (bottomRightRadioButton.Checked)
                    return AnchorType.BottomRight;

                return AnchorType.None;
            }
            set
            {
                switch (value)
                {
                    case AnchorType.TopLeft:
                        topLeftRadioButton.Checked = true;
                        break;

                    case AnchorType.Top:
                        topRadioButton.Checked = true;
                        break;

                    case AnchorType.TopRight:
                        topRightRadioButton.Checked = true;
                        break;

                    case AnchorType.Left:
                        leftRadioButton.Checked = true;
                        break;

                    case AnchorType.None:
                    case AnchorType.Center:
                        centerRadioButton.Checked = true;
                        break;

                    case AnchorType.Right:
                        rightRadioButton.Checked = true;
                        break;

                    case AnchorType.BottomLeft:
                        bottomLeftRadioButton.Checked = true;
                        break;

                    case AnchorType.Bottom:
                        bottomRadioButton.Checked = true;
                        break;

                    case AnchorType.BottomRight:
                        bottomRightRadioButton.Checked = true;
                        break;

                    default:
                        centerRadioButton.Checked = true;
                        break;
                }
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the CheckedChanged event of radioButton object.
        /// </summary>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedAnchorTypeChanged != null)
                // raise selected anchor changed event
                SelectedAnchorTypeChanged(sender, e);
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when <see cref="SelectedAnchorType"/> is changed.
        /// </summary>
        public event EventHandler SelectedAnchorTypeChanged;

        #endregion

    }
}
