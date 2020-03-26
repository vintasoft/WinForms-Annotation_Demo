using System;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to enter password of document.
    /// </summary>
    public partial class DocumentPasswordForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentPasswordForm"/> class.
        /// </summary>
        private DocumentPasswordForm()
        {
            InitializeComponent();

            passwordTextBox.Focus();
        }

        #endregion



        #region Properties

        string _filename;
        /// <summary>
        /// Gets or sets the filename of document.
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
        /// Gets the password of document.
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

        #region PUBLIC

        /// <summary>
        /// Authenticates the specified document.
        /// </summary>
        /// <param name="document">The decoder.</param>
        public static bool Authenticate(DecoderBase decoder)
        {
            // if authentication is required
            if (decoder.IsAuthenticationRequired)
            {
                // get the document filename
                string filename = null;
                if (decoder.SourceStream != null && decoder.SourceStream is FileStream)
                    filename = ((FileStream)decoder.SourceStream).Name;

                while (true)
                {
                    // create the document password dialog
                    using (DocumentPasswordForm enterPasswordDialog = new DocumentPasswordForm())
                    {
                        enterPasswordDialog.Filename = filename;

                        // show the document password dialog
                        DialogResult showDialogResult = enterPasswordDialog.ShowDialog();

                        // if "OK" button is clicked
                        if (showDialogResult == DialogResult.OK)
                        {
                            DocumentAuthenticationRequest authenticationRequest = new DocumentAuthenticationRequest(
                                enterPasswordDialog.authenticateTypeComboBox.Text,
                                enterPasswordDialog.Password);

                            // uuthenticate the decoder
                            DocumentAuthorizationResult result = decoder.Authenticate(authenticationRequest);
                            // if user is NOT authorized
                            if (!result.IsAuthorized)
                            {
                                MessageBox.Show(
                                    string.Format("The {0} password is incorrect.", enterPasswordDialog.authenticateTypeComboBox.Text),
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            // if user is authorized
                            else
                            {
                                if (enterPasswordDialog.authenticateTypeComboBox.Text != result.UserName)
                                    MessageBox.Show(
                                        string.Format("Authorized as: {0}", result.UserName),
                                        "Authorization Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                        // if "Cancel" button is clicked
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Enables the authentication for specified image viewer.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        public static void EnableAuthentication(ImageViewerBase imageViewer)
        {
            // enable the authentication for image collection of image viewer
            EnableAuthentication(imageViewer.Images);
        }

        /// <summary>
        /// Enables the authentication for specified image collection.
        /// </summary>
        /// <param name="imageViewer">The image collection.</param>
        public static void EnableAuthentication(ImageCollection imageCollection)
        {
            // subscribe to the ImageCollection.AuthenticationRequest event
            imageCollection.AuthenticationRequest += ImageViewer_AuthenticationRequest;
        }

        /// <summary>
        /// Disables the authentication for specified image viewer.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        public static void DisableAuthentication(ImageViewerBase imageViewer)
        {
            // disable the authentication for image collection of image viewer
            DisableAuthentication(imageViewer.Images);
        }

        /// <summary>
        /// Disables the authentication for specified image viewer.
        /// </summary>
        /// <param name="imageViewer">The image collection.</param>
        public static void DisableAuthentication(ImageCollection imageCollection)
        {
            // unsubscribe from the ImageCollection.AuthenticationRequest event
            imageCollection.AuthenticationRequest -= ImageViewer_AuthenticationRequest;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// "OK" button is clicked.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// "Cancel" button is clicked.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// The document, which is adding to the image collection, requires authentication.
        /// </summary>
        private static void ImageViewer_AuthenticationRequest(object sender, Vintasoft.Imaging.DocumentAuthenticationRequestEventArgs e)
        {
            if (!Authenticate(e.Decoder))
                e.IsCanceled = true;
        }

        #endregion

        #endregion

    }
}
