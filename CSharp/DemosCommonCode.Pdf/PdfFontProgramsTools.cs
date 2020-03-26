#if !REMOVE_PDF_PLUGIN
using System;
using System.Text;
using System.Windows.Forms;
using DemosCommonCode.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Utils;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// Allows to use custom PDF font program controller for PDF documents, which are opened in PDF demos.
    /// </summary>
    public static class PdfFontProgramsTools
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfFontProgramsTools"/> class.
        /// </summary>
        static PdfFontProgramsTools()
        {
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Shows a dialog for refreshing the PostScript font names of programs controller
        /// and refreshes the PostScript font names of programs controller.
        /// </summary>
        /// <param name="dialogOwner">The dialog owner.</param>
        public static DialogResult RefreshPostScriptFontNamesOfProgramsController(Form dialogOwner)
        {
            StringBuilder messageString = new StringBuilder();
            messageString.AppendLine("This operation will parse all fonts available on system and refresh");
            messageString.AppendLine("the font map by replacing current names with actual PostScript names.");
            messageString.AppendLine("It can be time consuming.");
            messageString.AppendLine("Do you want to refresh names of all available fonts?");

            if (MessageBox.Show(messageString.ToString(), "Refresh PostScript font names?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (ActionProgressForm actionProgressForm = new ActionProgressForm(RefreshPostScriptFontNames, 2, "Refreshing PostScript font names..."))
                    return actionProgressForm.RunAndShowDialog(dialogOwner);
            }
            else
            {
                return DialogResult.None;
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Refreshes the PostScript font names of programs controller.
        /// </summary>
        /// <param name="progressController">Progress controller.</param>
        private static void RefreshPostScriptFontNames(IActionProgressController progressController)
        {
            CustomFontProgramsController.Default.RefreshPostScriptFontNames(progressController);
        }

        #endregion

        #endregion

    }
}
#endif