using System;
using System.Windows.Forms;

#if !REMOVE_ANNOTATION_PLUGIN
using Vintasoft.Imaging.Annotation.Comments;
#endif

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Represents a form that allows to display comment properties.
    /// </summary>
    public partial class CommentPropertiesForm : Form
    {

        #region Fields

#if !REMOVE_ANNOTATION_PLUGIN
        /// <summary>
        /// The comment.
        /// </summary>
        Comment _comment;

        /// <summary>
        /// A value indicating whether the <see cref="Comment.Type"/> can be changed.
        /// </summary>
        bool _canEditType = false;
#endif

        #endregion



        #region Constructors

#if !REMOVE_ANNOTATION_PLUGIN
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentPropertiesForm"/> class.
        /// </summary>
        /// <param name="comment">The comment.</param>
        public CommentPropertiesForm(Comment comment)
        {
            InitializeComponent();

            _comment = comment;

            propertyGrid1.SelectedObject = comment;
            commentStateHistoryControl1.Comment = comment;

            UpdateCommonTabItem();
        }
#endif

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the SelectedIndexChanged event of TabControl1 object.
        /// </summary>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            // if selected 'Common' tab page
            if (tabControl1.SelectedTab == commonTabPage)
                // update 'Common' tab page items
                UpdateCommonTabItem();
            // if selected 'Advanced' tab page
            else if (tabControl1.SelectedTab == advancedTabPage)
                // update 'Advanced' tab page items
                propertyGrid1.Refresh();
#endif
        }

        /// <summary>
        /// Handles the CheckedChanged event of IsReadOnlyCheckBox object.
        /// </summary>
        private void isReadOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            // if comment must be locked
            if (isLockedCheckBox.Checked)
                _comment.IsReadOnly = true;
            else
                _comment.IsReadOnly = false;

            UpdateUI();
            UpdateModifyDateTime();
#endif
        }

        /// <summary>
        /// Handles the CheckedChanged event of OpenCheckBox object.
        /// </summary>
        private void openCheckBox_CheckedChanged(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            // if comment must be opened
            if (isOpenCheckBox.Checked)
                _comment.IsOpen = true;
            else
                _comment.IsOpen = false;
#endif
        }

        /// <summary>
        /// Handles the ColorChanged event of ColorPanelControl object.
        /// </summary>
        private void colorPanelControl_ColorChanged(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            // update comment color
            _comment.Color = colorPanelControl.Color;
            // update comment modify date time
            UpdateModifyDateTime();
#endif
        }

        /// <summary>
        /// Handles the TextChanged event of TypeComboBox object.
        /// </summary>
        private void typeComboBox_TextChanged(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            if (_comment == null)
                return;

            // if comment type is changed
            if (!string.Equals(_comment.Type, typeComboBox.Text))
            {
                // update comment type
                _comment.Type = typeComboBox.Text;
                UpdateModifyDateTime();
            }
#endif
        }

        /// <summary>
        /// Handles the TextChanged event of UserNameTextBox object.
        /// </summary>
        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            if (_comment == null)
                return;

            // update comment user name
            _comment.UserName = userNameTextBox.Text;
            UpdateModifyDateTime();
#endif
        }

        /// <summary>
        /// Handles the TextChanged event of SubjectTextBox object.
        /// </summary>
        private void subjectTextBox_TextChanged(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            if (_comment == null)
                return;

            // update comment subject
            _comment.Subject = subjectTextBox.Text;
            UpdateModifyDateTime();
#endif
        }

        /// <summary>
        /// Handles the TextChanged event of TextBox object.
        /// </summary>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
#if !REMOVE_ANNOTATION_PLUGIN
            if (_comment == null)
                return;

            // update comment text
            _comment.Text = textBox.Text;
            UpdateModifyDateTime();
#endif
        }

        #endregion


#if !REMOVE_ANNOTATION_PLUGIN
        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            typeComboBox.Enabled = _canEditType && !_comment.IsReadOnly;
            colorPanelControl.Enabled = !_comment.IsReadOnly;
            userNameTextBox.Enabled = !_comment.IsReadOnly;
            subjectTextBox.Enabled = !_comment.IsReadOnly;
            textBox.Enabled = !_comment.IsReadOnly;
        }

        /// <summary>
        /// Updates the common tab item.
        /// </summary>
        private void UpdateCommonTabItem()
        {
            UpdateModifyDateTime();

            if (_comment.CreationDate != DateTime.MinValue)
                creationDateTimeTextBox.Text = _comment.CreationDate.ToString();
            else
                creationDateTimeTextBox.Text = string.Empty;

            // update type combo box

            typeComboBox.BeginUpdate();
            typeComboBox.Items.Clear();
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            string[] availableTypes = _comment.GetAvailableTypes();
            if (availableTypes != null)
            {
                if (availableTypes.Length == 0)
                {
                    typeComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                    typeComboBox.Text = _comment.Type;
                }
                else
                {
                    typeComboBox.Items.AddRange(availableTypes);

                    if (_comment.Type != null && Array.IndexOf(availableTypes, _comment.Type) == -1)
                        typeComboBox.Items.Add(_comment.Type);

                    _canEditType = true;
                }
            }
            else
            {
                if (_comment.Type != null)
                    typeComboBox.Items.Add(_comment.Type);
            }
            typeComboBox.SelectedItem = _comment.Type;
            typeComboBox.EndUpdate();

            isOpenCheckBox.Checked = _comment.IsOpen;
            colorPanelControl.Color = _comment.Color;
            userNameTextBox.Text = _comment.UserName;
            subjectTextBox.Text = _comment.Subject;
            textBox.Text = _comment.Text;

            isLockedCheckBox.Checked = _comment.IsReadOnly;
        }

        /// <summary>
        /// Updates the comment modify date time.
        /// </summary>
        private void UpdateModifyDateTime()
        {
            if (_comment.ModifyDate != DateTime.MinValue)
                modifyDateTimeTextBox.Text = _comment.ModifyDate.ToString();
            else
                modifyDateTimeTextBox.Text = string.Empty;
        }
#endif

        #endregion

    }
}
