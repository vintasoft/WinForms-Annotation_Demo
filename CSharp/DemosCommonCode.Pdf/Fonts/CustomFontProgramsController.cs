using System;
using System.Collections.Generic;
#if !REMOVE_PDF_PLUGIN

using Vintasoft.Imaging.Pdf;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// Provides access to fonts located in the specified directory
    /// and system fonts.
    /// </summary>
    public class CustomFontProgramsController : FileFontProgramsControllerWithFallbackFont
    {

#region Constructor

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CustomFontProgramsController"/> class.
        /// </summary>
        public CustomFontProgramsController()
            : base(true, @"fonts\")
        {
            DefaultFallbackFontName = "Arial";
        }

#endregion

    }
}

#endif
