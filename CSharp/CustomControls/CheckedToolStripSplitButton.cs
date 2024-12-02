using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DemosCommonCode.CustomControls
{
    /// <summary>
    /// Represents a <see cref="ToolStripSplitButton"/> with <see cref="Checked"/> property.
    /// </summary>
    public class CheckedToolStripSplitButton : ToolStripSplitButton
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedToolStripSplitButton"/> class.
        /// </summary>
        public CheckedToolStripSplitButton()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedToolStripSplitButton"/> class.
        /// </summary>
        /// <param name="text">The text to display on the <see cref="CheckedToolStripSplitButton"/>.</param>
        public CheckedToolStripSplitButton(string text)
            : base(text)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedToolStripSplitButton"/> class.
        /// </summary>
        /// <param name="image">The <see cref="Image"/> to be displayed on the <see cref="CheckedToolStripSplitButton"/>.</param>
        public CheckedToolStripSplitButton(Image image)
            : base(image)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedToolStripSplitButton"/> class.
        /// </summary>
        /// <param name="text">The text to display on the <see cref="CheckedToolStripSplitButton"/>.</param>
        /// <param name="image">The <see cref="Image"/> to be displayed on the <see cref="CheckedToolStripSplitButton"/>.</param>
        public CheckedToolStripSplitButton(string text, Image image)
            : base(text, image)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedToolStripSplitButton"/> class.
        /// </summary>
        /// <param name="text">The text to display on the <see cref="CheckedToolStripSplitButton"/>.</param>
        /// <param name="image">The <see cref="Image"/> to be displayed on the <see cref="CheckedToolStripSplitButton"/>.</param>
        /// <param name="dropDownItems">A <see cref="ToolStripItem"/> array of controls.</param>
        public CheckedToolStripSplitButton(string text, Image image, params ToolStripItem[] dropDownItems)
            : base(text, image, dropDownItems)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedToolStripSplitButton"/> class.
        /// </summary>
        /// <param name="text">The text to display on the <see cref="CheckedToolStripSplitButton"/>.</param>
        /// <param name="image">The <see cref="Image"/> to be displayed on the <see cref="CheckedToolStripSplitButton"/>.</param>
        /// <param name="onClick">Raises the <see cref="EventHandler"/> event when the user clicks the
        /// <see cref="CheckedToolStripSplitButton"/>.</param>
        public CheckedToolStripSplitButton(string text, Image image, EventHandler onClick)
            : base(text, image, onClick)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedToolStripSplitButton"/> class.
        /// </summary>
        /// <param name="text">The text to display on the <see cref="CheckedToolStripSplitButton"/>.</param>
        /// <param name="image"> The <see cref="Image"/> to be displayed on the <see cref="CheckedToolStripSplitButton"/>.</param>
        /// <param name="onClick">Raises the <see cref="EventHandler"/> event when the user clicks the
        /// <see cref="CheckedToolStripSplitButton"/>.</param>
        /// <param name="name">The name of the <see cref="CheckedToolStripSplitButton"/>.</param>
        public CheckedToolStripSplitButton(string text, Image image, EventHandler onClick, string name)
            : base(text, image, onClick, name)
        {
        }

        #endregion



        #region Properties

        bool _checked = false;
        /// <summary>
        /// Gets or sets a value, indicating whether 
        /// the <see cref="CheckedToolStripSplitButton"/> is pressed or not pressed.
        /// </summary>
        [Browsable(true)]
        [Description("Indicates whether the CheckedToolStripSplitButton is pressed in or not pressed in.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                if (value != _checked)
                {
                    _checked = value;
                    Invalidate();
                }
            }
        }

        bool _checkOnClick = false;
        /// <summary>
        /// Gets or sets a value indicating whether
        /// the button must be checked on click.
        /// </summary>
        /// <value>
        /// <b>true</b> if button must be checked on click; otherwise, <b>false</b>.
        /// </value>
        [Browsable(true)]
        [Description("Indicates whether the button must be checked on click.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool CheckOnClick
        {
            get
            {
                return _checkOnClick;
            }
            set
            {
                _checkOnClick = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.ToolStripItem.Click"/> event.
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            if (CheckOnClick)
                Checked ^= true;

            base.OnClick(e);
        }

        /// <summary>
        /// Raises the <see cref="PaintEventArgs"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // if checked is true
            if (Checked)
            {
                // get graphics
                Graphics g = e.Graphics;

                // draw a rectangle
                g.DrawRectangle(new Pen(SystemColors.Highlight), new Rectangle(0, 0,
                    SplitterBounds.X,
                    Size.Height + Margin.All));
            }

            base.OnPaint(e);
        }

        #endregion

    }
}
