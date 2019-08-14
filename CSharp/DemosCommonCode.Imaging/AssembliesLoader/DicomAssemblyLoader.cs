namespace DemosCommonCode
{
    /// <summary>
    /// Loads the Vintasoft.Imaging.Dicom assembly.
    /// </summary>
    public class DicomAssemblyLoader
    {

        /// <summary>
        /// Loads the Vintasoft.Imaging.Dicom assembly.
        /// </summary>
        public static void Load()
        {
#if !REMOVE_DICOM_PLUGIN
            using (Vintasoft.Imaging.Codecs.Decoders.DicomDecoder decoder =
                new Vintasoft.Imaging.Codecs.Decoders.DicomDecoder())
            {
            }
#endif
        }

    }
}
