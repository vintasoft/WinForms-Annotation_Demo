#if REMOVE_PDF_PLUGIN
#error Remove CreateSignatureAppearanceEventArgs from project.
#endif

using System;

using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;

namespace DemosCommonCode.Pdf.Security
{
    /// <summary>
    /// Provides data for an event when property with generic type is changing.
    /// </summary>
    public class CreateSignatureAppearanceEventArgs : EventArgs
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSignatureAppearanceEventArgs"/> class.
        /// </summary>
        /// <param name="signatureField">The signature field.</param>
        public CreateSignatureAppearanceEventArgs(PdfInteractiveFormSignatureField signatureField)
        {
            _signatureField = signatureField;
        }

        #endregion



        #region Properties

        PdfInteractiveFormSignatureField _signatureField;
        /// <summary>
        /// Gets the PDF signature field.
        /// </summary>
        public PdfInteractiveFormSignatureField SignatureField
        {
            get
            {
                return _signatureField;
            }
        }

        bool _cancel = false;
        /// <summary>
        /// Gets or sets a value indicating whether the changing of signature field appearance must be canceled.
        /// </summary>
        /// <value>
        /// <b>true</b> - changing of signature field appearance must be canceled;
        /// <b>false</b> - changing of signature field appearance must not be canceled.<br />
        /// Default value is <b>false</b>.
        /// </value>
        public bool Cancel
        {
            get
            {
                return _cancel;
            }
            set
            {
                _cancel = value;
            }
        }

        #endregion

    }
}
