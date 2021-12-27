using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Vintasoft.Imaging;


namespace DemosCommonCode
{
    /// <summary>
    /// Provides access to the resources of this demo.
    /// </summary>
    internal class DemosResourcesManager
    {

        #region Methods

        #region INTERNAL

        /// <summary>
        /// Returns the resource as image.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>
        /// The resource image.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if resource of <b>filename</b> is not found.
        /// </exception>
        internal static VintasoftImage GetResourceAsImage(string filename)
        {
            // get resource stream
            Stream stream = GetResourceAsStreamSafe(filename);

            // load image
            return new VintasoftImage(stream, true);
        }

        /// <summary>
        /// Returns the resource as bitmap.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>
        /// The resource bitmap.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if resource of <b>filename</b> is not found.
        /// </exception>
        internal static Bitmap GetResourceAsBitmap(string filename)
        {
            // get resource stream
            using (Stream stream = GetResourceAsStreamSafe(filename))
            {
                // load bitmap
                using (Bitmap temp = (Bitmap)Bitmap.FromStream(stream))
                    return new Bitmap(temp);
            }
        }

        /// <summary>
        /// Returns the resource as stream.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>
        /// The resource stream.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if resource of <b>filename</b> is not found.
        /// </exception>
        internal static Stream GetResourceAsStreamSafe(string filename)
        {
            // get resource stream
            Stream stream = GetResourceAsStream(filename);

            // if resource is not found
            if (stream == null)
                throw new FileNotFoundException(string.Format("Resource '{0}' was not found.", filename));

            return stream;
        }

        /// <summary>
        /// Returns the resource as stream.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>
        /// The resource stream or null.
        /// </returns>
        internal static Stream GetResourceAsStream(string filename)
        {
            // get assembly
            Assembly assembly = typeof(DemosResourcesManager).Module.Assembly;

            // get resource names of assembly
            string[] resourceNames = assembly.GetManifestResourceNames();

            // get resource name of specified filename
            string resourceName = GetResourceName(resourceNames, filename);

            // if resource is not found
            if (string.IsNullOrEmpty(resourceName))
            {
                // get file name
                filename = Path.GetFileName(filename);
                // get filename extension
                string extension = Path.GetExtension(filename);
                // get extension of filename
                string filenameWithoutExtension = Path.GetFileNameWithoutExtension(filename);

                // if filename has extension
                if (Path.HasExtension(filenameWithoutExtension))
                {
                    // create new filename
                    filename = Path.GetExtension(filenameWithoutExtension).Substring(1);
                }
                else
                {
                    filename = filenameWithoutExtension;
                }

                // create new resource name
                resourceName = string.Format("{0}{1}", filename, extension);
            }

            // load resource stream
            Stream resourceStream = assembly.GetManifestResourceStream(resourceName);

            return resourceStream;
        }

        /// <summary>
        /// Returns the resource as bytes array.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>
        /// The bytes array.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if resource of <b>filename</b> is not found.
        /// </exception>
        internal static byte[] GetResourceAsBytes(string filename)
        {
            // get resource stream
            using (Stream stream = GetResourceAsStreamSafe(filename))
            {
                // create bytes array
                byte[] result = new byte[(int)stream.Length];
                // read bytes
                stream.Read(result, 0, result.Length);
                // return result
                return result;
            }

        }

        /// <summary>
        /// Returns the external resource as a byte array.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>
        /// The external resource as a byte array.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <b>filename</b> is null or empty.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        /// Thrown if external resource with <b>filename</b> is not found.
        /// </exception>
        internal static byte[] GetExternalResourceAsBytes(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException();

            string applicationPath = Path.GetFullPath(Path.GetDirectoryName(Application.ExecutablePath));

            string filePath = Path.Combine(applicationPath, filename);

            return File.ReadAllBytes(filePath);
        }

        /// <summary>
        /// Finds the resource names that contains specified part of name.
        /// </summary>
        /// <param name="namePart">The name part.</param>
        internal static string[] FindResourceNames(string namePart)
        {
            // get assembly
            Assembly assembly = typeof(DemosResourcesManager).Module.Assembly;

            // get resource names of assembly
            string[] resourceNames = assembly.GetManifestResourceNames();

            List<string> result = new List<string>();
            foreach (string resourceName in resourceNames)
                if (resourceName.Contains(namePart))
                    result.Add(resourceName);

            result.Sort();

            return result.ToArray();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Returns the name of the resource.
        /// </summary>
        /// <param name="resourceNames">The resource names.</param>
        /// <param name="filename">The filename.</param>
        /// <returns>
        /// The resource name.
        /// </returns>
        private static string GetResourceName(string[] resourceNames, string filename)
        {
            foreach (string resourceName in resourceNames)
            {
                if (resourceName.EndsWith(filename, StringComparison.InvariantCultureIgnoreCase))
                    return resourceName;
            }

            return string.Empty;
        }

        #endregion

        #endregion

    }
}
