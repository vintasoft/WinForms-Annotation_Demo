using System;
using System.Windows.Forms;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    ///  A form that allows to edit the server settings.
    /// </summary>
    public partial class ServerSettingsDialog : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerSettingsDialog"/> class.
        /// </summary>
        public ServerSettingsDialog()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets a server URL.
        /// </summary>
        public string ServerUrl
        {
            get
            {
                return urlTextBox.Text;
            }
            set
            {
                urlTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets a user name.
        /// </summary>
        public string ServerUserName
        {
            get
            {
                return userNameTextBox.Text;
            }
            set
            {
                userNameTextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets a user name.
        /// </summary>
        public string ServerPassword
        {
            get
            {
                return passwordTextBox.Text;
            }
            set
            {
                passwordTextBox.Text = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
