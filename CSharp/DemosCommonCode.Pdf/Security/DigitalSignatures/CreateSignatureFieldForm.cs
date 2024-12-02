#if REMOVE_PDF_PLUGIN
#error Remove CreateSignatureFieldForm from project.
#endif

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree.DigitalSignatures;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;

using DemosCommonCode.Imaging;

namespace DemosCommonCode.Pdf.Security
{
    /// <summary>
    /// A form that allows to create new signature field or use existing signature field AND
    /// perform signing of PDF document using the signature field.
    /// </summary>
    public partial class CreateSignatureFieldForm : Form
    {

        #region Fields

        /// <summary>
        /// Timestamp Server URL.
        /// </summary>
        static string TimestampServerUrl = "http://timestamp.comodoca.com/";

        /// <summary>
        /// User name of Timestamp Server.
        /// </summary>
        static string TimestampServerUserName = null;

        /// <summary>
        /// Password of Timestamp Server.
        /// </summary>
        static string TimestampServerPassword = null;

        /// <summary>
        /// The PDF document.
        /// </summary>
        PdfDocument _document;

        /// <summary>
        /// Annotation rectangle of new signature field.
        /// </summary>
        RectangleF _annotationRect;

        /// <summary>
        /// The X509 certificate with private key.
        /// </summary>
        X509Certificate2 _certificate;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSignatureForm"/> class.
        /// </summary>
        public CreateSignatureFieldForm()
        {
            InitializeComponent();

            timestampHashAlgorithmComboBox.SelectedIndex = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSignatureForm"/> class.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="annotationRect">The annotation rectangle of new signature field.</param>
        public CreateSignatureFieldForm(
            PdfDocument document,
            RectangleF annotationRect)
            : this()
        {
            _annotationRect = annotationRect;
            _document = document;

            signatureNameTextBox.Text = GetNewSignatureName();

            signatureTypeComboBox.Items.Add("PKCS#1 (adbe.x509.rsa_sha1)");
            signatureTypeComboBox.Items.Add("PKCS#7 (adbe.pkcs7.detached)");
            signatureTypeComboBox.Items.Add("PKCS#7 (ETSI.CAdES.detached)");
            signatureTypeComboBox.SelectedIndex = 1;

            UpdateUI();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSignatureForm"/> class.
        /// </summary>
        /// <param name="signatureField">The signature field.</param>
        public CreateSignatureFieldForm(PdfInteractiveFormSignatureField signatureField)
            : this(signatureField.Document,
                   signatureField.Annotation.Rectangle)
        {
            _signatureField = signatureField;
            signatureNameTextBox.Text = _signatureField.PartialName;

            if (string.IsNullOrEmpty(signatureNameTextBox.Text))
                signatureNameTextBox.Text = GetNewSignatureName();
        }

        #endregion



        #region Properties

        PdfInteractiveFormSignatureField _signatureField;
        /// <summary>
        /// Gets the new signature field.
        /// </summary>
        public PdfInteractiveFormSignatureField SignatureField
        {
            get
            {
                return _signatureField;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this form can change signature appearance.
        /// </summary>
        /// <value>
        /// <b>True</b> if this form can change signature appearance; otherwise, <b>false</b>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanChangeSignatureAppearance
        {
            get
            {
                return signatureAppearanceButton.Visible;
            }
            set
            {
                signatureAppearanceButton.Visible = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of the "Cancel" button.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the Click event of the "OK" button.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // if certificate is NOT specified
            if (_certificate == null)
            {
                // if empty signature field must NOT be created
                if (MessageBox.Show("Certificate is not selected, create empty signature field?", "Create empty signature", MessageBoxButtons.YesNo) == DialogResult.No)
                    // exit
                    return;
            }

            // if signature field is NOT specified
            if (_signatureField == null)
            {
                // if signature field is NOT created
                if (!CreateSignatureField())
                    // exit
                    return;
            }

            // init the signature field
            if (InitSignatureField())
            {
                // if annotation appearance of signature field is NOT set
                if (CanChangeSignatureAppearance && _signatureField.Annotation.Appearances == null)
                {
                    CreateSignatureAppearanceEventArgs args = new CreateSignatureAppearanceEventArgs(_signatureField);
                    OnCreateSignatureAppearance(args);
                    if (args.Cancel)
                        return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Creates the signature field.
        /// </summary>
        /// <returns>
        /// <b>true</b> - signature field is created successfully;
        /// <b>false</b> - signature field is not created;
        /// </returns>
        private bool CreateSignatureField()
        {
            // if signature name is NOT valid
            if (!CheckSignatureName(signatureNameTextBox.Text))
            {
                DemosTools.ShowWarningMessage(string.Format("Document has annotation with name '{0}'.", signatureNameTextBox.Text));
                return false;
            }

            // create new signature field
            _signatureField = new PdfInteractiveFormSignatureField(_document, signatureNameTextBox.Text, _annotationRect);

            return true;
        }

        /// <summary>
        /// Inits the signature field.
        /// </summary>
        private bool InitSignatureField()
        {
            // set the signature field name
            _signatureField.PartialName = signatureNameTextBox.Text;

            // if certificate is selected 
            if (_certificate != null)
            {
                // get signature info from the signature field
                PdfSignatureInformation signatureInfo = _signatureField.SignatureInfo;
                // if signate info is NOT found
                if (signatureInfo == null)
                {
                    try
                    {
                        // create the signature info
                        signatureInfo = CreateSignatureInformation();
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                    }
                    if (signatureInfo == null)
                        return false;

                    // set the signature information of signature field
                    _signatureField.SignatureInfo = signatureInfo;
                }


                // update the signature information
                if (signatureInfo != null)
                {
                    if (contactInfoTextBox.Text != "")
                        signatureInfo.ContactInfo = contactInfoTextBox.Text;
                    if (locationTextBox.Text != "")
                        signatureInfo.Location = locationTextBox.Text;
                    if (reasonTextBox.Text != "")
                        signatureInfo.Reason = reasonTextBox.Text;
                    if (signerNameTextBox.Text != "")
                        signatureInfo.SignerName = signerNameTextBox.Text;
                    signatureInfo.SigningTime = DateTime.Now;

                    // add application name
                    signatureInfo.BuildProperties = new PdfSignatureBuildProperties(_document);
                    signatureInfo.BuildProperties.Application = new PdfSignatureBuildData(_document);
                    signatureInfo.BuildProperties.Application.Name = "VintaSoft Imaging .NET SDK - https://www.vintasoft.com";
                }
            }

            return true;
        }

        /// <summary>
        /// Creates the signature information.
        /// </summary>
        private PdfSignatureInformation CreateSignatureInformation()
        {
            bool addCertificateChain = certificateChainCheckBox.Checked;

            PdfPkcsSignature signature;
            if (signatureTypeComboBox.SelectedIndex == 0)
            {
                // create new PKCS#1 signature
                signature = PdfPkcsSignature.CreatePkcs1Signature(_certificate, addCertificateChain);
            }
            else
            {
                // create new PKCS#7 signature
                try
                {
                    PdfPkcsSignatureCreationParams creationParams = new PdfPkcsSignatureCreationParams(_certificate, addCertificateChain);

                    // set ParentWindowHandle
                    creationParams.ParentWindowHandle = Application.OpenForms[0].Handle;

                    // if timestamp must be embedded into signature
                    if (addTimestampCheckBox.Checked)
                    {
                        TimestampAuthorityWebClient timestampRequest = new TimestampAuthorityWebClient(TimestampServerUrl, TimestampServerUserName, TimestampServerPassword);
                        timestampRequest.HashAlgorithmName = timestampHashAlgorithmComboBox.Text;
                        creationParams.TimestampAuthorityClient = timestampRequest;
                    }

                    if (signatureTypeComboBox.SelectedIndex == 1)
                        creationParams.SignatureFormat = PdfPkcsSignatureFormat.CMS;
                    else if (signatureTypeComboBox.SelectedIndex == 2)
                        creationParams.SignatureFormat = PdfPkcsSignatureFormat.CAdES;
                    else
                        throw new NotImplementedException();

                    signature = PdfPkcsSignature.CreatePkcs7Signature(_document.Format, creationParams);
                }
                catch (System.Security.Cryptography.CryptographicException ex)
                {
                    DemosTools.ShowErrorMessage("Certificate error", ex);
                    return null;
                }
            }

            // create signature information
            return new PdfSignatureInformation(_document, signature);
        }

        /// <summary>
        /// Handles the Click event of the selectCertificateButton control.
        /// </summary>
        private void selectCertificateButton_Click(object sender, EventArgs e)
        {
            SelectCertificate();
        }

        /// <summary>
        /// Handles the Click event of the "Signature Appearance..." button.
        /// </summary>
        private void signatureAppearanceButton_Click(object sender, EventArgs e)
        {
            // if signature field is NOT specified
            if (_signatureField == null)
            {
                // if signature field is NOT created
                if (!CreateSignatureField())
                    // exit
                    return;
            }

            // init the signature field
            if (InitSignatureField())
            {
                if (CanChangeSignatureAppearance)
                    OnCreateSignatureAppearance(new CreateSignatureAppearanceEventArgs(_signatureField));
            }
        }

        /// <summary>
        /// Updates the User Interface.
        /// </summary>
        private void UpdateUI()
        {
            bool isCertificateSelected = _certificate != null;
            signerNameTextBox.Enabled = isCertificateSelected;
            locationTextBox.Enabled = isCertificateSelected;
            contactInfoTextBox.Enabled = isCertificateSelected;
            reasonTextBox.Enabled = isCertificateSelected;
            signatureTypeComboBox.Enabled = isCertificateSelected;
            certificateChainCheckBox.Enabled = isCertificateSelected;

            bool canEmbedTimestamp =
                signatureTypeComboBox.SelectedIndex == 1 ||
                signatureTypeComboBox.SelectedIndex == 2;
            if (!canEmbedTimestamp)
                addTimestampCheckBox.Checked = false;
            addTimestampCheckBox.Enabled = isCertificateSelected && canEmbedTimestamp;
            timestampServerSettingsButton.Enabled = isCertificateSelected && canEmbedTimestamp;
        }

        /// <summary>
        /// Gets the new name of the signature.
        /// </summary>
        private string GetNewSignatureName()
        {
            int i = 1;
            string name;
            do
            {
                name = string.Format("Signature{0}", i++);
            }
            while (!CheckSignatureName(name));
            return name;
        }

        /// <summary>
        /// Checks the name of the signature.
        /// </summary>
        /// <param name="name">The new signature name.</param>
        /// <returns><b>true</b> if name is valid; otherwise <b>false</b></returns>
        private bool CheckSignatureName(string name)
        {
            if (_document.InteractiveForm != null)
                return _document.InteractiveForm.FindField(name) == null;
            return true;
        }

        /// <summary>
        /// Selects the certificate for a signature field.
        /// </summary>
        private void SelectCertificate()
        {
            // open certificate store for personal certificates
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            // show form that allows to select certificate
            SelectCertificateForm dialog = new SelectCertificateForm(store.Certificates);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!dialog.SelectedCertificate.HasPrivateKey)
                {
                    DemosTools.ShowErrorMessage("Certificate does not have Private Key.");
                }
                else
                {
                    _certificate = dialog.SelectedCertificate;
                    certificateTextBox.Text = ConvertCertificateToString(_certificate);
                    signerNameTextBox.Text = _certificate.GetNameInfo(X509NameType.SimpleName, false);
                    locationTextBox.Text = CultureInfo.CurrentCulture.EnglishName;
                    if (CanChangeSignatureAppearance && _signatureField != null)
                        _signatureField.Annotation.Appearances = null;
                }
            }

            DialogResult = DialogResult.None;
            UpdateUI();
        }

        /// <summary>
        /// Converts the certificate to a string.
        /// </summary>
        /// <param name="certificate">The certificate.</param>
        private string ConvertCertificateToString(X509Certificate2 certificate)
        {
            string email = certificate.GetNameInfo(X509NameType.EmailName, false);
            if (email != "")
                return string.Format("{0} <{1}>", certificate.GetNameInfo(X509NameType.SimpleName, false), email);
            else
                return certificate.GetNameInfo(X509NameType.SimpleName, false);
        }

        /// <summary>
        /// Handles the MouseClick event of the certificateTextBox control.
        /// </summary>
        private void certificateTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (_certificate == null)
                SelectCertificate();
        }

        /// <summary>
        /// Clears the signature information.
        /// </summary>
        private void signatureTypeComboBox_SelectedItemChanged(object sender, EventArgs e)
        {
            if (_signatureField != null)
                _signatureField.SignatureInfo = null;
            UpdateUI();
        }

        /// <summary>
        /// Set settinggs of timestamp server.
        /// </summary>
        private void timestampServerSettingsButton_Click(object sender, EventArgs e)
        {
            using (ServerSettingsDialog serverSettings = new ServerSettingsDialog())
            {
                serverSettings.Text = "Timestamp Server Settings";
                serverSettings.ServerUrl = TimestampServerUrl;
                serverSettings.ServerUserName = TimestampServerUserName;
                serverSettings.ServerPassword = TimestampServerPassword;
                if (serverSettings.ShowDialog() == DialogResult.OK)
                {
                    TimestampServerUrl = serverSettings.ServerUrl;
                    TimestampServerUserName = serverSettings.ServerUserName;
                    TimestampServerPassword = serverSettings.ServerPassword;
                }
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of addTimestampCheckBox object.
        /// </summary>
        private void addTimestampCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            timestampProperitesGroupBox.Enabled = addTimestampCheckBox.Checked;
        }

        /// <summary>
        /// Raises the <see cref="E:CreateSignatureAppearance" /> event.
        /// </summary>
        /// <param name="args">The <see cref="CreateSignatureAppearanceEventArgs"/> instance containing the event data.</param>
        private void OnCreateSignatureAppearance(CreateSignatureAppearanceEventArgs args)
        {
            if (CreateSignatureAppearance != null)
                CreateSignatureAppearance(this, args);
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when the signature appearance must be created.
        /// </summary>
        public event EventHandler<CreateSignatureAppearanceEventArgs> CreateSignatureAppearance;

        #endregion

    }
}
