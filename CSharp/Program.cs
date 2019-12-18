using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AnnotationDemo
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Vintasoft.VintasoftImagingLicense.Register();
            DemosCommonCode.DemosTools.EnableLicenseExceptionDisplaying();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }
}