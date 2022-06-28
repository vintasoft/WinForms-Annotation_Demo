using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.ColorManagement;
using Vintasoft.Imaging.ColorManagement.Icc;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Helps to initialize the color management settings.
    /// </summary>
    public static class ColorManagementHelper
    {

        #region Constants

        /// <summary>
        /// Default input CMYK ICC profile.
        /// </summary>
        const string DEFAULT_INPUT_CMYK_PROFILE = "DefaultCMYK.icc";

        #endregion



        #region Methods

        /// <summary>
        /// Enables the color management in image viewer.
        /// </summary>
        public static void EnableColorManagement(ImageViewerBase imageViewer)
        {
            // get image viewer decoding settings
            DecodingSettings settings = imageViewer.ImageDecodingSettings;

            // if image viewer does not have decodings settings
            if (settings == null)
                // create new decoding settings
                settings = new DecodingSettings();

            // init color management
            settings.ColorManagement = InitColorManagement(settings.ColorManagement);

            // set decoding settings for image viewer
            imageViewer.ImageDecodingSettings = settings;
        }

        /// <summary>
        /// Disables the color management in image viewer.
        /// </summary>
        public static void DisableColorManagement(ImageViewerBase imageViewer)
        {
            if (imageViewer.ImageDecodingSettings != null)
            {
                if (imageViewer.ImageDecodingSettings.ColorManagement != null)
                {
                    imageViewer.ImageDecodingSettings.ColorManagement = null;
                }
            }
        }

        /// <summary>
        /// Initializes the color management settings.
        /// </summary>
        /// <param name="colorManagementSettings">Source color management settings.</param>
        /// <returns>
        /// New color management settings.
        /// </returns>
        public static ColorManagementDecodeSettings InitColorManagement(ColorManagementDecodeSettings colorManagementSettings)
        {
            // if color management settings does not exist
            if (colorManagementSettings == null)
                // create new color management settings
                colorManagementSettings = new ColorManagementDecodeSettings();

            // load the default input CMYK ICC profile
            LoadDefaultInputCmykProfile(colorManagementSettings);

            colorManagementSettings.UseEmbeddedInputProfile = true;
            colorManagementSettings.UseBlackPointCompensation = true;

            return colorManagementSettings;
        }


        /// <summary>
        /// Loads the default input CMYK ICC profile.
        /// </summary>
        private static void LoadDefaultInputCmykProfile(ColorManagementDecodeSettings colorManagementSettings)
        {
            try
            {
                // search directories
                string[] directories = new string[] {
                    "",
                    @"..\..\..\..\Bin\DotNet4\AnyCPU\",
                };

                // for each search directory
                foreach (string dir in directories)
                {
                    // create path to a CMYK profile file in search directory
                    string profileDirectory = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), dir));
                    string profileFilename = Path.Combine(profileDirectory, DEFAULT_INPUT_CMYK_PROFILE);
                    // if CMYK profile file is found
                    if (File.Exists(profileFilename))
                    {
                        // set input CMYK profile in color management settings
                        colorManagementSettings.InputCmykProfile = new IccProfile(profileFilename);
                        return;
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

    }
}