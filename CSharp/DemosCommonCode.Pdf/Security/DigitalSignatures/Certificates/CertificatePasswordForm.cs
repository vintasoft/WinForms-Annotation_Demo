using System;
using System.IO;
using System.Windows.Forms;

namespace DemosCommonCode.Pdf.Security
{
    /// <summary>
    /// A form that allows to input password for opening the certificate with private key.
    /// </summary>
    public partial class CertificatePasswordForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificatePasswordForm"/> class.
        /// </summary>
        public CertificatePasswordForm()
            : base()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties
        
        string _filename;
        /// <summary>
        /// Gets or sets the certificate filename.
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
        /// Gets the password.
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
        /// Handles the Click event of the "OK" button.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of the "Cancel" button.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}
