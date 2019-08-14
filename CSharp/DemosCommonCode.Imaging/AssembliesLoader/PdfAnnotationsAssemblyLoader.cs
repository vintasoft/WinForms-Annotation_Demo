namespace DemosCommonCode
{
    /// <summary>
    /// Loads the Vintasoft.Imaging.Annotation.Pdf assembly.
    /// </summary>
    public class PdfAnnotationsAssemblyLoader
    {

        /// <summary>
        /// Loads the Vintasoft.Imaging.Annotation.Pdf assembly.
        /// </summary>
        public static void Load()
        {
#if !REMOVE_ANNOTATION_PLUGIN && !REMOVE_PDF_PLUGIN
            using (Vintasoft.Imaging.Annotation.Pdf.Print.AnnotatedPdfPrintDocument decoder =
                new Vintasoft.Imaging.Annotation.Pdf.Print.AnnotatedPdfPrintDocument())
            {
            }
#endif
        }

    }
}
