using System.Collections.Generic;
using System.Runtime.Serialization;
using Vintasoft.Imaging.Fonts;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Provides access to the fonts, which are located in the specified directory, and system fonts.
    /// </summary>
    public class CustomFontProgramsController : FileFontProgramsControllerWithFallbackFont
    {

        #region Fields

        /// <summary>
        /// "Full font name" to "font file name" table.
        /// </summary>
        static Dictionary<string, string> _systemFonts = null;


        #endregion



        #region Constructors

        /// <summary>
        /// Initializes the <see cref="CustomFontProgramsController"/> class.
        /// </summary>
        static CustomFontProgramsController()
        {
            RegisterSerializingType<CustomFontProgramsController>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFontProgramsController"/> class.
        /// </summary>
        public CustomFontProgramsController()
            : base(true, "fonts")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFontProgramsController"/> class.
        /// </summary>
        /// <param name="info">The SerializationInfo to populate with data.</param>
        /// <param name="context">The destination for this serialization.</param>
        public CustomFontProgramsController(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns an array of strings that contains names of the system TrueType fonts.
        /// </summary>
        public static string[] GetSystemInstalledFontNames()
        {
            Dictionary<string, string> systemFonts = GetSystemFonts();
            string[] names = new string[systemFonts.Count];
            systemFonts.Keys.CopyTo(names, 0);
            return names;
        }

        /// <summary>
        /// Returns a filename of the TrueType font by font name.
        /// </summary>
        /// <param name="trueTypeFontName">A name of the TrueType font.</param>
        /// <returns>Filename of the TrueType font.</returns>
        public static string GetSystemInstalledFontFileName(string trueTypeFontName)
        {
            Dictionary<string, string> systemFonts = GetSystemFonts();
            return systemFonts[trueTypeFontName];
        }


        /// <summary>
        /// Sets <see cref="CustomFontProgramsController"/> as default font programs controller.
        /// </summary>
        public static void SetDefaultFontProgramsController()
        {
            Default = new CustomFontProgramsController();
        }


#if NETCORE
        /// <summary>
        /// Returns the dictionary, which contains information ("full font name" => "font file path") about all fonts installed in system.
        /// </summary>
        /// <returns>
        /// The dictionary, which contains information ("full font name" => "font file path") about all fonts installed in system.
        /// </returns>
        /// <seealso cref="TryGetSystemFontDirectory"/>
        public override Dictionary<string, string> GetSystemInstalledFonts()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            // gets information about installed fonts from the "LocalMachine" system registry key
            GetSystemInstalledFontsFromRegistry(Microsoft.Win32.Registry.LocalMachine, result);

            // gets information about installed fonts from the "CurrentUser" system registry key
            GetSystemInstalledFontsFromRegistry(Microsoft.Win32.Registry.CurrentUser, result);

            return result;
        }

        /// <summary>
        /// Returns information about installed fonts from the system registry key.
        /// </summary>
        /// <param name="registryKey">The registry key, where information about fonts must be searched.</param>
        /// <param name="fonts">The dictionary, where information about found fonts must be added.</param>
        private void GetSystemInstalledFontsFromRegistry(Microsoft.Win32.RegistryKey registryKey, Dictionary<string, string> fonts)
        {
            try
            {
                string systemFontsDirectory = "";
                try
                {
                    systemFontsDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts);
                }
                catch
                {
                }

                Microsoft.Win32.RegistryKey fontsRegistry = registryKey.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Fonts");
                foreach (string fullFontName in fontsRegistry.GetValueNames())
                {
                    string fontFilename = (string)fontsRegistry.GetValue(fullFontName);

                    string fontExt = System.IO.Path.GetExtension(fontFilename).ToUpperInvariant();
                    if (fontExt != ".TTF" && fontExt != ".TTC")
                        continue;

                    if (string.IsNullOrEmpty(System.IO.Path.GetDirectoryName(fontFilename)))
                    {
                        fontFilename = System.IO.Path.Combine(systemFontsDirectory, fontFilename);
                    }

                    string fontName = fullFontName.Replace("(TrueType)", "").Trim();
                    fontName = fontName.Replace("(OpenType)", "").Trim();

                    fonts[fontName] = fontFilename;
                }
            }
            catch
            {
            }
        }
#endif

        /// <summary>
        /// Returns the dictionary, which contains information ("full font name" => "font file path") about all fonts installed in system.
        /// </summary>
        /// <returns>
        /// The dictionary, which contains information ("full font name" => "font file path") about all fonts installed in system.
        /// </returns>
        private static Dictionary<string, string> GetSystemFonts()
        {
            if (_systemFonts == null)
            {
                // get installed fonts
                if (Default is FileFontProgramsController)
                    _systemFonts = ((FileFontProgramsController)Default).GetSystemInstalledFonts();
                else
                    _systemFonts = new Dictionary<string, string>();
            }
            return _systemFonts;
        }

        #endregion

    }
}