using System.ComponentModel;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Allows to register the ability to edit properries of <see cref="VintasoftImage"/> in property grid.
    /// </summary>
    class ImagingTypeEditorRegistrator
    {

        /// <summary>
        /// Registers the ability to edit properries of <see cref="VintasoftImage"/> in property grid.
        /// </summary>
        public static void Register()
        {
            TypeDescriptor.AddAttributes(typeof(VintasoftImage), new EditorAttribute(typeof(VintasoftImageWinFormsEditor), typeof(System.Drawing.Design.UITypeEditor)));
        }

    }

}
