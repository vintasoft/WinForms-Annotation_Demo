using System;
using System.Windows.Forms;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that shows the property grid with properties of specified object.
    /// </summary>
    public partial class PropertyGridForm : Form
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyGridForm"/> class.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="formTitle">The form title.</param>
        public PropertyGridForm(object obj, string formTitle)
            : this(obj, formTitle, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyGridForm"/> class.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="formTitle">The form title.</param>
        /// <param name="canCancel">Determines that form has "Cancel" button.</param>
        public PropertyGridForm(object obj, string formTitle, bool canCancel)
        {
            InitializeComponent();
            Text = formTitle;
            buttonCancel.Enabled = canCancel;
            _propertyGrid.SelectedObject = obj;
            _propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid_PropertyValueChanged);
        }

        #endregion



        #region Properties

        public PropertyGrid PropertyGrid
        {
            get
            {
                return _propertyGrid;
            }
        }

        bool _propertyValueChanged = false;
        /// <summary>
        /// Gets a value indicating whether a property value was changed.
        /// </summary>
        /// <value>
        /// <b>true</b> if a property value was changed; otherwise, <b>false</b>.
        /// </value>
        public bool PropertyValueChanged
        {
            get
            {
                return _propertyValueChanged;
            }
        }

        #endregion



        #region Methods

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of the _propertyGrid control.
        /// </summary>
        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _propertyValueChanged = true;
        }

        #endregion

    }
}
