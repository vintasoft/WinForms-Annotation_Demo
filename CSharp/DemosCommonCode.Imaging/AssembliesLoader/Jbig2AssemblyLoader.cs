namespace DemosCommonCode
{
    /// <summary>
    /// Loads the Vintasoft.Imaging.Jbig2Codec asssembly.
    /// </summary>
    public class Jbig2AssemblyLoader
    {

        /// <summary>
        /// Loads the Vintasoft.Imaging.Jbig2Codec asssembly.
        /// </summary>
        public static void Load()
        {
#if REMOVE_JBIG2_PLUGIN
            Vintasoft.Imaging.Codecs.AvailableCodecs.RemoveCodecByName("Jbig2");
#else
            using (Vintasoft.Imaging.Codecs.Decoders.Jbig2Decoder decoder = 
                new Vintasoft.Imaging.Codecs.Decoders.Jbig2Decoder())
            {
            }
#endif
        }

    }
}
