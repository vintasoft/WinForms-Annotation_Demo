using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace DemosCommonCode.Pdf.Security
{
    /// <summary>
    /// A form that allows to select the X509 Certificate from list.
    /// </summary>
    public partial class SelectCertificateForm : Form
    {

        #region Fields

        /// <summary>
        /// The list of X509 certificates.
        /// </summary>
        List<X509Certificate2> _certificates = new List<X509Certificate2>();

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectCertificateForm"/> class.
        /// </summary>
        public SelectCertificateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectCertificateForm"/> class.
        /// </summary>
        /// <param name="certificates">The certificates.</param>
        public SelectCertificateForm(X509Certificate2Collection certificates)
            : this()
        {
            foreach (X509Certificate2 cert in certificates)
                AddCertificate(cert);
            UpdateUI();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the selected certificate.
        /// </summary>
        public X509Certificate2 SelectedCertificate
        {
            get
            {
                if (certificatesListBox.SelectedIndex >= 0)
                    return _certificates[certificatesListBox.SelectedIndex];
                return null;
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

        /// <summary>
        /// Handles the Click event of the "Details..." button.
        /// </summary>
        private void certDitailsButton_Click(object sender, EventArgs e)
        {
            X509Certificate2UI.DisplayCertificate(_certificates[certificatesListBox.SelectedIndex], this.Handle);
        }

        /// <summary>
        /// Handles the Click event of the "Add From File..." button.
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PKCS12 (PFX) Files|*.pfx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CertificatePasswordForm passwordForm = new CertificatePasswordForm();
                    if (passwordForm.ShowDialog() == DialogResult.OK)
                    {
                        X509Certificate2 cert = new X509Certificate2(openFileDialog.FileName, passwordForm.Password);
                        certificatesListBox.SelectedIndex = AddCertificate(cert);
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
            DialogResult = DialogResult.None;
        }

        /// <summary>
        /// Updates the User Interface.
        /// </summary>
        private void UpdateUI()
        {
            buttonOk.Enabled = certificatesListBox.SelectedItem != null;
            certDitailsButton.Enabled = buttonOk.Enabled;
        }

        /// <summary>
        /// Adds the certificate to the list box.
        /// </summary>
        /// <param name="cert">The X509 certificate.</param>
        /// <returns></returns>
        private int AddCertificate(X509Certificate2 cert)
        {
            _certificates.Add(cert);
            return certificatesListBox.Items.Add(ConvertCertificateToString(cert));
        }

        /// <summary>
        /// Converts the certificate to a string.
        /// </summary>
        /// <param name="certificate">The certificate.</param>
        private string ConvertCertificateToString(X509Certificate2 certificate)
        {
            string result;
            string email = certificate.GetNameInfo(X509NameType.EmailName, false);
            if (email != "")
                result = string.Format("{0} <{1}>", certificate.GetNameInfo(X509NameType.SimpleName, false), email);
            else
                result = certificate.GetNameInfo(X509NameType.SimpleName, false);
            if (certificate.HasPrivateKey)
                result += " (Has Private Key)";
            return result;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the certificatesListBox control.
        /// </summary>
        private void certificatesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the certificatesListBox control.
        /// </summary>
        private void certificatesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedCertificate != null)
                DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
