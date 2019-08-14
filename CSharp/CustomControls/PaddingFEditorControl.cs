using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging;


namespace DemosCommonCode.CustomControls
{
    /// <summary>
    /// A control that allows to change the padding.
    /// </summary>
    [DefaultEvent("PaddingValueChanged")]
    public partial class PaddingFEditorControl : UserControl
    {

        #region Fields

        /// <summary>
        /// Determines that the the padding value is changing.
        /// </summary>
        bool _paddingValueUpdating = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PaddingFEditorControl"/> class.
        /// </summary>
        public PaddingFEditorControl()
        {
            InitializeComponent();
            UpdatePaddingPanel(_paddingValue);
        }

        #endregion



        #region Properties

        PaddingF _paddingValue = PaddingF.Empty;
        /// <summary>
        /// Gets or sets the padding value.
        /// </summary>
        /// <value>
        /// Default value is <b>Vintasoft.Imaging.PaddingF.Empty</b>.
        /// </value>
        [Description("The padding value.")]
        public PaddingF PaddingValue
        {
            get
            {
                return _paddingValue;
            }
            set
            {
                if (!_paddingValue.Equals(value))
                {
                    _paddingValue = value;
                    UpdatePaddingPanel(_paddingValue);
                }
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Updates the padding panel.
        /// </summary>
        /// <param name="padding">The padding.</param>
        private void UpdatePaddingPanel(PaddingF padding)
        {
            _paddingValueUpdating = true;

            leftNumericUpDown.Value = Convert.ToDecimal(padding.Left);
            topNumericUpDown.Value = Convert.ToDecimal(padding.Top);
            rightNumericUpDown.Value = Convert.ToDecimal(padding.Right);
            bottomNumericUpDown.Value = Convert.ToDecimal(padding.Bottom);
            allNumericUpDown.Value = Convert.ToDecimal(padding.All);

            _paddingValueUpdating = false;
        }

        /// <summary>
        /// The single padding value is changed.
        /// </summary>
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_paddingValueUpdating)
                return;

            float left = Convert.ToSingle(leftNumericUpDown.Value);
            float top = Convert.ToSingle(topNumericUpDown.Value);
            float right = Convert.ToSingle(rightNumericUpDown.Value);
            float bottom = Convert.ToSingle(bottomNumericUpDown.Value);

            PaddingValue = new PaddingF(left, top, right, bottom);
            OnPaddingValueChanged();
        }

        /// <summary>
        /// All padding values are changed.
        /// </summary>
        private void allNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_paddingValueUpdating)
                return;

            PaddingValue = new PaddingF(Convert.ToSingle(allNumericUpDown.Value));
            OnPaddingValueChanged();
        }

        /// <summary>
        /// Raises the <see cref="PaddingValueChanged"/> event.
        /// </summary>
        private void OnPaddingValueChanged()
        {
            if (PaddingValueChanged != null)
                PaddingValueChanged(this, EventArgs.Empty);
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when value of property is changed.
        /// </summary>
        public event EventHandler PaddingValueChanged;

        #endregion

    }
}
