#if !REMOVE_PDF_PLUGIN

using System;
using System.Collections.Generic;
using System.IO;
using Vintasoft.Imaging.Pdf;

namespace DemosCommonCode.Pdf
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
        /// Initializes a new instance of the <see cref="CustomFontProgramsController"/> class.
        /// </summary>
        public CustomFontProgramsController()
            : base(true, @"fonts\")
        {
        }

        #endregion



        #region Properties

        static CustomFontProgramsController _default;
        /// <summary>
        /// Gets or sets the default custom font programs controller.
        /// </summary>
        public static CustomFontProgramsController Default
        {
            get
            {
                if (_default == null)
                    _default = new CustomFontProgramsController();
                return _default;
            }
            set
            {
                _default = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns an array of strings that contains names of the system TrueType fonts.
        /// </summary>
        public static string[] GetSystemInstalledFontNames()
        {
            Dictionary<string, string> systemFonts = GetSystemFonts();
            string[] names = new string[_systemFonts.Count];
            _systemFonts.Keys.CopyTo(names, 0);
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
        /// Enables usage of default custom font programs controller for all opened PDF documents.
        /// </summary>
        public static void EnableUsageOfDefaultFontProgramsController()
        {
            // subscribe to the PdfDocumentController.DocumentOpened event
            PdfDocumentController.DocumentOpened += PdfDocumentController_DocumentOpened;
        }

        /// <summary>
        /// Disables usage of default custom font programs controller for all opened PDF documents.
        /// </summary>
        public static void DisableUsageOfDefaultFontProgramsController()
        {
            // unsubscribe from the PdfDocumentController.DocumentOpened event
            PdfDocumentController.DocumentOpened -= PdfDocumentController_DocumentOpened;
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
#endif


        /// <summary>
        /// PDF document is opened.
        /// </summary>
        private static void PdfDocumentController_DocumentOpened(object sender, Vintasoft.Imaging.Pdf.PdfDocumentEventArgs e)
        {
            // set the default custom font programs controller as a document font programs controller
            e.Document.FontProgramsController = Default;
        }

#if NETCORE
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
                    systemFontsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
                }
                catch
                {
                }

                Microsoft.Win32.RegistryKey fontsRegistry = registryKey.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Fonts");
                foreach (string fontName in fontsRegistry.GetValueNames())
                {
                    string fontFilename = (string)fontsRegistry.GetValue(fontName);

                    string fontExt = Path.GetExtension(fontFilename).ToUpperInvariant();
                    if (fontExt != ".TTF" && fontExt != ".TTC")
                        continue;

                    if (string.IsNullOrEmpty(Path.GetDirectoryName(fontFilename)))
                    {
                        fontFilename = Path.Combine(systemFontsDirectory, fontFilename);
                    }

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
                _systemFonts = Default.GetSystemInstalledFonts();
            }
            return _systemFonts;
        }

        #endregion

    }
}

#endif