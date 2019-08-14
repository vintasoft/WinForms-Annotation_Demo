using System;
using System.IO;
using System.Windows.Forms;

#if !REMOVE_PDF_PLUGIN
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Security;
#endif

namespace DemosCommonCode.Pdf.Security
{
    /// <summary>
    /// A form that allows to enter password of PDF document.
    /// </summary>
    public partial class DocumentPasswordForm : Form
    {

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="DocumentPasswordWindow"/> class
        /// from being created.
        /// </summary>
        public DocumentPasswordForm()
            : this(2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentPasswordWindow"/> class.
        /// </summary>
        /// <param name="authenticateType">Type of the authentication.</param>
        private DocumentPasswordForm(int authenticateType)
        {
            InitializeComponent();
            passwordTextBox.Focus();
            authenticateTypeComboBox.SelectedIndex = authenticateType;
        }

        #endregion



        #region Properties


        string _filename;
        /// <summary>
        /// Gets or sets the filename of PDF document.
        /// </summary>
        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                if (_filename != null)
                    Text = string.Format("Password - {0}", Path.GetFileName(_filename));
                else
                    Text = "Password";
            }
        }

        /// <summary>
        /// Gets the password of PDF document.
        /// </summary>
        public string Password
        {
            get
            {
                return passwordTextBox.Text;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// "OK" button is pressed.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// "Cancel" button is pressed.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

#if !REMOVE_PDF_PLUGIN
        /// <summary>
        /// Authenticates the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="filename">The filename.</param>
        public static bool Authenticate(PdfDocument document, string filename)
        {
            if (document.IsEncrypted &&
                document.AuthorizationResult == AuthorizationResult.IncorrectPassword)
            {
                int authenticateType = 0;
                while (true)
                {
                    using (DocumentPasswordForm enterPasswordDialog = new DocumentPasswordForm(authenticateType))
                    {
                        enterPasswordDialog.Filename = filename;
                        if (enterPasswordDialog.ShowDialog() == DialogResult.OK)
                        {
                            AuthorizationResult result = AuthorizationResult.IncorrectPassword;
                            switch (enterPasswordDialog.authenticateTypeComboBox.SelectedIndex)
                            {
                                case 0:
                                    result = document.AuthenticateAsUser(enterPasswordDialog.Password);
                                    break;
                                case 1:
                                    result = document.AuthenticateAsOwner(enterPasswordDialog.Password);
                                    break;
                                case 2:
                                    result = document.Authenticate(enterPasswordDialog.Password);
                                    break;
                            }

                            authenticateType = enterPasswordDialog.authenticateTypeComboBox.SelectedIndex;
                            if (result == AuthorizationResult.IncorrectPassword)
                            {
                                MessageBox.Show(
                                    string.Format("The {0} password is incorrect.", enterPasswordDialog.authenticateTypeComboBox.SelectedItem),
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (authenticateType == 2)
                                    MessageBox.Show(
                                        string.Format("Authorization result: {0}", document.AuthorizationResult),
                                        "Authorization Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
#endif

        #endregion

    }
}
