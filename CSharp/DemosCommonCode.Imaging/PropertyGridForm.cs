using System;
using System.Windows.Forms;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that shows the property grid with properties of specified object.
    /// </summary>
    public partial class PropertyGridForm : Form
    {

        #region Constructors

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
            propertyGrid1.SelectedObject = obj;
            propertyGrid1.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid_PropertyValueChanged);
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the <see cref="PropertyGrid"/>.
        /// </summary>
        public PropertyGrid PropertyGrid
        {
            get
            {
                return propertyGrid1;
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

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            // property value is changed
            _propertyValueChanged = true;
        }

        #endregion

    }
}
