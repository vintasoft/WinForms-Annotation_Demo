#if !REMOVE_PDF_PLUGIN
using System;
using System.IO;

using Vintasoft.Imaging.Pdf;

using DemosCommonCode.Pdf.Security;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// Allows to enable PDF document authentication in PDF demos.
    /// </summary>
    public static class PdfAuthenticateTools
    {

        #region Constructors

        /// <summary>
        /// Initializes the <see cref="PdfAuthenticateTools"/> class.
        /// </summary>
        static PdfAuthenticateTools()
        {
        }

        #endregion



        #region Properties

        static bool _enableAuthenticateRequest = false;
        /// <summary>
        /// Gets or sets a value indicating whether authenticate request is enabled.
        /// </summary>
        public static bool EnableAuthenticateRequest
        {
            get
            {
                return _enableAuthenticateRequest;
            }
            set
            {
                if (_enableAuthenticateRequest != value)
                {
                    _enableAuthenticateRequest = value;
                    if (value)
                        PdfDocumentController.AuthenticateRequest += new EventHandler<PdfDocumentEventArgs>(PdfDocumentController_AuthenticateRequest);
                    else
                        PdfDocumentController.AuthenticateRequest -= PdfDocumentController_AuthenticateRequest;
                }
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Shows a dialog for authenticating the PDF document
        /// when the authentication request occurs.
        /// </summary>
        private static void PdfDocumentController_AuthenticateRequest(
            object sender,
            PdfDocumentEventArgs e)
        {
            ShowAuthenticateRequestWindow(e);
        }

        /// <summary>
        /// Shows a dialog for authenticating the PDF document
        /// when the authentication request occurs.
        /// </summary>
        private static void ShowAuthenticateRequestWindow(PdfDocumentEventArgs e)
        {
            PdfDocument document = e.Document;
            string filename = null;
            if (document.SourceStream != null && document.SourceStream is FileStream)
                filename = ((FileStream)document.SourceStream).Name;
            DocumentPasswordForm.Authenticate(document, filename);
        }

        #endregion

    }
}
#endif