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
        /// Determines that the padding value is changing.
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

        #region UI

        /// <summary>
        /// Handles the ValueChanged event of numericUpDown object.
        /// </summary>
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // if padding value is updating
            if (_paddingValueUpdating)
                return;

            // get left padding
            float left = Convert.ToSingle(leftNumericUpDown.Value);
            // get top padding
            float top = Convert.ToSingle(topNumericUpDown.Value);
            // get right padding
            float right = Convert.ToSingle(rightNumericUpDown.Value);
            // get bottom padding
            float bottom = Convert.ToSingle(bottomNumericUpDown.Value);

            // update padding value
            PaddingValue = new PaddingF(left, top, right, bottom);
            OnPaddingValueChanged();
        }

        /// <summary>
        /// Handles the ValueChanged event of allNumericUpDown object.
        /// </summary>
        private void allNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // if padding value is updating
            if (_paddingValueUpdating)
                return;

            // update padding value
            PaddingValue = new PaddingF(Convert.ToSingle(allNumericUpDown.Value));
            OnPaddingValueChanged();
        }

        #endregion


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
