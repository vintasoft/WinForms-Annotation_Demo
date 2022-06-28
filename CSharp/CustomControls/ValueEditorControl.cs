using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace DemosCommonCode.CustomControls
{
    /// <summary>
    /// A control that allows to edit value in image processing configuration form.
    /// </summary>
    public partial class ValueEditorControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueEditorControl"/> class.
        /// </summary>
        public ValueEditorControl()
        {
            InitializeComponent();

            UpdateGroupBoxText();
        }

        #endregion



        #region Properties

        string _valueName = "Value Name";
        /// <summary>
        /// Gets or sets name of the value.
        /// </summary>
        [Description("Name of the value.")]
        public string ValueName 
        {
            get
            {
                return _valueName;
            }
            set
            {
                _valueName = value;
                UpdateGroupBoxText();
            }
        }

        string _valueUnitOfMeasure = "";
        /// <summary>
        /// Gets or sets the unit of measure of the value.
        /// </summary>
        [Description("Unit of measure of the value.")]
        public string ValueUnitOfMeasure 
        {
            get
            {
                return _valueUnitOfMeasure;
            }
            set
            {
                _valueUnitOfMeasure = value;
                UpdateGroupBoxText();
            }
        }

        float _value = 0f;
        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        [Description("Current value.")]
        [DefaultValue(0f)]
        public float Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                valueNumericUpDown.Value = (decimal)value;
            }
        }

        float _minValue = 0f;
        /// <summary>
        /// Gets or sets minimum value.
        /// </summary>
        [Description("Minimum value.")]
        [DefaultValue(0f)]
        public float MinValue 
        {
            get
            {
                return _minValue;
            }
            set
            {
                _minValue = value;
                minValueLabel.Text = value.ToString(CultureInfo.InvariantCulture);
                valueNumericUpDown.Minimum = (decimal)value;
                UpdateTrackBarParameters();
            }
        }

        float _maxValue = 100f;
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        [Description("Maximum value.")]
        [DefaultValue(100f)]
        public float MaxValue 
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
                maxValueLabel.Text = value.ToString(CultureInfo.InvariantCulture);
                valueNumericUpDown.Maximum = (decimal)value;
                UpdateTrackBarParameters();
            }
        }

        float _defaultValue = 0f;
        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        [Description("Default value.")]
        [DefaultValue(0f)]
        public float DefaultValue 
        {
            get
            {
                return _defaultValue;
            }
            set
            {
                _defaultValue = value;
            }
        }

        float _step = 1f;
        /// <summary>
        /// Gets or sets the value step.
        /// </summary>
        [Description("The value step.")]
        [DefaultValue(1f)]
        public float Step 
        {
            get
            {
                return _step;
            }
            set
            {
                _step = value;
                valueNumericUpDown.Increment = (decimal)value;
                UpdateTrackBarParameters();
            }
        }

        /// <summary>
        /// Gets or sets the number of decimal places.
        /// </summary>
        [Description("The number of decimal places.")]
        [DefaultValue(0)]
        public int DecimalPlaces
        {
            get
            {
                return valueNumericUpDown.DecimalPlaces;
            }
            set
            {
                valueNumericUpDown.DecimalPlaces = value;
            }
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Scroll event of ValueTrackBar object.
        /// </summary>
        private void valueTrackBar_Scroll(object sender, EventArgs e)
        {
            // calculate current value
            float value = MinValue + valueTrackBar.Value * Step;
            // update current value
            valueNumericUpDown.Value = (decimal)Math.Min(value, MaxValue);
        }

        /// <summary>
        /// Handles the ValueChanged event of ValueNumericUpDown object.
        /// </summary>
        private void valueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // update current value
            Value = (float)valueNumericUpDown.Value;
            // update track bar
            UpdateTrackBarParameters();
            // raise value changed event
            OnValueChanged();
        }

        /// <summary>
        /// Handles the Click event of ResetButton object.
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {
            // set default value
            valueNumericUpDown.Value = (decimal)_defaultValue;
        }

        #endregion


        /// <summary>
        /// Raises the <see cref="ValueChanged"/> event.
        /// </summary>
        private void OnValueChanged()
        {
            if (ValueChanged != null)
                ValueChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Updates parameters of the track bar.
        /// </summary>
        private void UpdateTrackBarParameters()
        {
            // set the number of steps in the track bar
            int stepCount = (int)Math.Round((MaxValue - MinValue) / Step);
            valueTrackBar.Minimum = 0;
            valueTrackBar.Maximum = stepCount;

            // set the large change to 1/10 of range
            valueTrackBar.LargeChange = (int)Math.Max(Math.Round(0.1 * stepCount), 1);

            // set the frequency of displayed ticks
            valueTrackBar.TickFrequency = (int)Math.Max((0.05 * stepCount), 1);

            // set current value of the track bar
            float trackBarValue = ((float)valueNumericUpDown.Value - MinValue) / Step;
            valueTrackBar.Value = (int)Math.Round(trackBarValue);
        }

        /// <summary>
        /// Updates text of the group box.
        /// </summary>
        private void UpdateGroupBoxText()
        {
            if (string.IsNullOrEmpty(ValueUnitOfMeasure))
            {
                valueGroupBox.Text = ValueName;
            }
            else
            {
                valueGroupBox.Text = String.Format("{0} ({1})", ValueName, ValueUnitOfMeasure);
            }
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when the value is changed.
        /// </summary>
        public event EventHandler ValueChanged;

        #endregion

    }
}
