using System.Windows.Forms;

using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Codecs.Encoders;

namespace DemosCommonCode.Imaging.Codecs
{
    /// <summary>
    /// Contains filters for Open/Save dialogs.
    /// </summary>
    public class CodecsFileFilters
    {

        #region Constants

        /// <summary>
        /// The file filter for image files.
        /// </summary>
        const string IMAGE_FILES_DIALOG_FILTER = "BMP Files|*.bmp|JPEG Files|*.jpg;*.jpeg|PNG Files|*.png|TIFF Files|*.tif;*.tiff|GIF Files|*.gif|PCX Files|*.pcx";

        /// <summary>
        /// The file filter for all image files.
        /// </summary>
        const string ALL_IMAGE_FILES_DIALOG_FILTER = "All Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.gif;*.pcx;";

        /// <summary>
        /// The other image files extensions.
        /// </summary>
        const string OTHER_IMAGE_FILES_EXTENSIONS = "*.wmf;*.emf;*.ico;*.cur;*.jls;";

        /// <summary>
        /// The file filter for other image files.
        /// </summary>
        const string OTHER_IMAGE_FILES_DIALOG_FILTER = "EMF Files|*.emf|WMF Files|*.wmf|Icon Files|*.ico|Cursor Files|*.cur|JPEG-LS Files|*.jls";

        /// <summary>
        /// The file filter for TIFF files.
        /// </summary>
        const string TIFF_FILE_DIALOG_FILTER = "TIFF Files|*.tif;*.tiff";

        /// <summary>
        /// The file filter for JPEG files.
        /// </summary>
        const string JPEG_FILE_DIALOG_FILTER = "JPEG Files|*.jpg;*.jpeg";

        /// <summary>
        /// The PDF file extensions.
        /// </summary>
        const string PDF_FILE_EXTENSIONS = "*.pdf";
        /// <summary>
        /// The file filter for PDF files.
        /// </summary>
        const string PDF_FILE_DIALOG_FILTER = "PDF Files|" + PDF_FILE_EXTENSIONS;

        /// <summary>
        /// The GIF files extension.
        /// </summary>
        const string GIF_FILE_EXTENSIONS = "*.gif";
        /// <summary>
        /// The file filter for GIF files.
        /// </summary>
        const string GIF_FILE_DIALOG_FILTER = "GIF Files|" + GIF_FILE_EXTENSIONS;

        /// <summary>
        /// The PNG file extensions.
        /// </summary>
        const string PNG_FILE_EXTENSIONS = "*.png";
        /// <summary>
        /// The file filter for PNG files.
        /// </summary>
        const string PNG_FILE_DIALOG_FILTER = "PNG Files|" + PNG_FILE_EXTENSIONS;

        /// <summary>
        /// The JBIG2 file extensions.
        /// </summary>
        const string JBIG2_FILE_EXTENSIONS = "*.jb2;*.jbig2";
        /// <summary>
        /// The file filter for JBIG2 files.
        /// </summary>
        const string JBIG2_FILE_DIALOG_FILTER = "JBIG2 Files|" + JBIG2_FILE_EXTENSIONS;

        /// <summary>
        /// The JPEG2000 file extensions.
        /// </summary>
        const string JPEG2000_FILE_EXTENSIONS = "*.jp2;*.j2k;*.j2c;*.jpc";
        /// <summary>
        /// The file filter for JPEG2000 files.
        /// </summary>
        const string JPEG2000_FILE_DIALOG_FILTER = "JPEG 2000 Files|" + JPEG2000_FILE_EXTENSIONS;

        /// <summary>
        /// The RAW file extensions.
        /// </summary>
        const string RAW_FILE_EXTENSIONS = "*.cr2;*.crw;*.nef;*.nrw;*.dng";
        /// <summary>
        /// The file filter for RAW files.
        /// </summary>
        const string RAW_FILE_DIALOG_FILTER = "RAW Image Files|" + RAW_FILE_EXTENSIONS;

        /// <summary>
        /// The DICOM file extensions.
        /// </summary>
        const string DICOM_FILE_EXTENSIONS = "*.dcm;*.dic;*.acr";
        /// <summary>
        /// The file filter for DICOM files.
        /// </summary>
        const string DICOM_FILE_DIALOG_FILTER = "DICOM files|" + DICOM_FILE_EXTENSIONS;

        /// <summary>
        /// The DOCX file extensions.
        /// </summary>
        const string DOCX_FILE_EXTENSIONS = "*.docx";
        /// <summary>
        /// The file filter for DOCX files.
        /// </summary>
        const string DOCX_FILE_DIALOG_FILTER = "DOCX files|" + DOCX_FILE_EXTENSIONS;

        /// <summary>
        /// The XLSX file extensions.
        /// </summary>
        const string XLSX_FILE_EXTENSIONS = "*.xlsx";
        /// <summary>
        /// The file filter for XLSX files.
        /// </summary>
        const string XLSX_FILE_DIALOG_FILTER = "XLSX files|" + XLSX_FILE_EXTENSIONS;

        /// <summary>
        /// The SVG file extensions.
        /// </summary>
        const string SVG_FILE_EXTENSIONS = "*.svg";

        /// <summary>
        /// The file filter for SVG files.
        /// </summary>
        const string SVG_FILE_DIALOG_FILTER = "SVG Files|" + SVG_FILE_EXTENSIONS;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CodecsFileFilters"/> class.
        /// </summary>
        public CodecsFileFilters()
        {
        } 

        #endregion



        #region Properties

        #region Decoders

        static string _imageDecoderFilter = null;
        /// <summary>
        /// Gets the file filter for image file decoders.
        /// </summary>
        public static string ImageDecoderFilter
        {
            get
            {
                if (_imageDecoderFilter == null)
                    InitImageDecoderFilter();
                return _imageDecoderFilter;
            }
        }

        static int _imageDecoderFilterDefaultIndex = -1;
        /// <summary>
        /// Gets the default index in file filter for image file decoders.
        /// </summary>
        public static int ImageDecoderFilterDefaultIndex
        {
            get
            {
                if (_imageDecoderFilterDefaultIndex == -1)
                    InitImageDecoderFilter();
                return _imageDecoderFilterDefaultIndex;
            }
        }

        #endregion


        #region Encoders

        static string _imageEncoderFilter = null;
        /// <summary>
        /// Gets the file filter for image file encoders.
        /// </summary>
        public static string ImageEncoderFilter
        {
            get
            {
                if (_imageEncoderFilter == null)
                    InitImageEncoderFilter();
                return _imageEncoderFilter;
            }
        }

        static int _imageEncoderFilterDefaultIndex = -1;
        /// <summary>
        /// Gets the default index in file filter for image file encoders.
        /// </summary>
        public static int ImageEncoderFilterDefaultIndex
        {
            get
            {
                if (_imageEncoderFilterDefaultIndex == -1)
                    InitImageEncoderFilter();
                return _imageEncoderFilterDefaultIndex;
            }
        }

        static string _multipageImageEncoderFilter = null;
        /// <summary>
        /// Gets the file filter for multipage image file encoders.
        /// </summary>
        public static string MultipageImageEncoderFilter
        {
            get
            {
                if (_multipageImageEncoderFilter == null)
                    InitMultipageImageEncoderFilter();
                return _multipageImageEncoderFilter;
            }
        }


        static int _multipageImageEncoderFilterDefaultIndex = -1;
        /// <summary>
        /// Gets the default index in file filter for multipage image file encoders.
        /// </summary>
        public static int MultipageImageEncoderFilterDefaultIndex
        {
            get
            {
                if (_multipageImageEncoderFilterDefaultIndex == -1)
                    InitMultipageImageEncoderFilter();
                return _multipageImageEncoderFilterDefaultIndex;
            }
        }


        static string _imageEncoderWithAnnotationsFilter = null;
        /// <summary>
        /// Gets the file filter for image file encoders with annotation support.
        /// </summary>
        public static string ImageEncoderWithAnnotationsFilter
        {
            get
            {
                if (_imageEncoderWithAnnotationsFilter == null)
                    InitImageEncoderWithAnnotationsFilter();
                return _imageEncoderWithAnnotationsFilter;
            }
        }

        static int _imageEncoderWithAnnotationsFilterDefaultIndex = -1;
        /// <summary>
        /// Gets the default index in file filter for image file encoders with annotation support.
        /// </summary>
        public static int ImageEncoderWithAnnotationsFilterDefaultIndex
        {
            get
            {
                if (_imageEncoderWithAnnotationsFilterDefaultIndex == -1)
                    InitImageEncoderWithAnnotationsFilter();
                return _imageEncoderWithAnnotationsFilterDefaultIndex;
            }
        }

        static string _multipageImageEncoderWithAnnotationsFilter = null;
        /// <summary>
        /// Gets the file filter for multipage image file encoders with annotation support.
        /// </summary>
        public static string MultipageEncoderFiltersWithAnnotations
        {
            get
            {
                if (_multipageImageEncoderWithAnnotationsFilter == null)
                    InitMultipageImageEncoderWithAnnotationsFilter();
                return _multipageImageEncoderWithAnnotationsFilter;
            }
        }

        static int _multipageImageEncoderWithAnnotationsFilterDefaultIndex = -1;
        /// <summary>
        /// Gets the default index in file filter for multipage image file encoders with annotation support.
        /// </summary>
        public static int MultipageEncoderWithAnnotationsFilterDefaultIndex
        {
            get
            {
                if (_multipageImageEncoderWithAnnotationsFilterDefaultIndex == -1)
                    InitMultipageImageEncoderWithAnnotationsFilter();
                return _multipageImageEncoderWithAnnotationsFilterDefaultIndex;
            }
        }

        #endregion

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Sets the filter for open file dialog.
        /// </summary>
        /// <param name="dialog">The open file dialog.</param>
        public static void SetOpenFileDialogFilter(OpenFileDialog dialog)
        {
            try
            {
                dialog.Filter = ImageDecoderFilter;
                dialog.FilterIndex = ImageDecoderFilterDefaultIndex;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Sets the filter for save file dialog.
        /// </summary>
        /// <param name="dialog">The save file dialog.</param>
        /// <param name="multipageOnly">A value indicating whether the image encoder must support multiple pages.</param>
        /// <param name="annotationsSupport">A value indicating whether the image encoder must support annotations.</param>
        public static void SetSaveFileDialogFilter(SaveFileDialog dialog, bool multipageOnly, bool annotationsSupport)
        {
            if (annotationsSupport)
            {
                if (multipageOnly)
                {
                    dialog.Filter = MultipageEncoderFiltersWithAnnotations;
                    dialog.FilterIndex = MultipageEncoderWithAnnotationsFilterDefaultIndex;
                }
                else
                {
                    dialog.Filter = ImageEncoderWithAnnotationsFilter;
                    dialog.FilterIndex = ImageEncoderWithAnnotationsFilterDefaultIndex;
                }
                dialog.OverwritePrompt = false;
                dialog.DefaultExt = ".tif";
            }
            else
            {
                try
                {
                    if (multipageOnly)
                    {
                        dialog.Filter = MultipageImageEncoderFilter;
                        dialog.FilterIndex = MultipageImageEncoderFilterDefaultIndex;
                        dialog.DefaultExt = ".tif";
                    }
                    else
                    {
                        dialog.Filter = ImageEncoderFilter;
                        dialog.FilterIndex = ImageEncoderFilterDefaultIndex;
                        dialog.DefaultExt = ".png";
                    }
                    dialog.OverwritePrompt = false;
                }
                catch
                {
                }
            }
        }

        #endregion


        #region PRIVATE

        #region Decoders

        /// <summary>
        /// Inits the image decoder filter.
        /// </summary>
        static void InitImageDecoderFilter()
        {
            string filter1 = string.Format("{0}|{1}", IMAGE_FILES_DIALOG_FILTER, OTHER_IMAGE_FILES_DIALOG_FILTER);
            string filter2 = ALL_IMAGE_FILES_DIALOG_FILTER + OTHER_IMAGE_FILES_EXTENSIONS;
            _imageDecoderFilterDefaultIndex = 12;

            // if JBIG2 decoder is available
            if (AvailableDecoders.IsDecoderAvailable("Jbig2"))
            {
                filter1 += "|" + JBIG2_FILE_DIALOG_FILTER;
                filter2 += JBIG2_FILE_EXTENSIONS + ";";
                _imageDecoderFilterDefaultIndex++;
            }

            // if PDF decoder is available
            if (AvailableDecoders.IsDecoderAvailable("Pdf"))
            {
                filter1 += "|" + PDF_FILE_DIALOG_FILTER;
                filter2 += PDF_FILE_EXTENSIONS + ";";
                _imageDecoderFilterDefaultIndex++;
            }

            // if DOCX decoder is available
            if (AvailableDecoders.IsDecoderAvailable("Docx"))
            {
                filter1 += "|" + DOCX_FILE_DIALOG_FILTER;
                filter2 += DOCX_FILE_EXTENSIONS + ";";
                _imageDecoderFilterDefaultIndex++;
            }

            // if XLSX decoder is available
            if (AvailableDecoders.IsDecoderAvailable("Xlsx"))
            {
                filter1 += "|" + XLSX_FILE_DIALOG_FILTER;
                filter2 += XLSX_FILE_EXTENSIONS + ";";
                _imageDecoderFilterDefaultIndex++;
            }

            // if JPEG2000 decoder is available
            if (AvailableDecoders.IsDecoderAvailable("Jpeg2000"))
            {
                filter1 += "|" + JPEG2000_FILE_DIALOG_FILTER;
                filter2 += JPEG2000_FILE_EXTENSIONS + ";";
                _imageDecoderFilterDefaultIndex++;
            }

            // if RAW decoder is available
            if (AvailableDecoders.IsDecoderAvailable("Raw"))
            {
                filter1 += "|" + RAW_FILE_DIALOG_FILTER;
                filter2 += RAW_FILE_EXTENSIONS + ";";
                _imageDecoderFilterDefaultIndex++;
            }

            // if DICOM decoder is available
            if (AvailableDecoders.IsDecoderAvailable("Dicom"))
            {
                filter1 += "|" + DICOM_FILE_DIALOG_FILTER;
                filter2 += DICOM_FILE_EXTENSIONS + ";";
                _imageDecoderFilterDefaultIndex++;
            }

            _imageDecoderFilter = string.Format("{0}|{1}", filter1, filter2);
        }

        #endregion


        #region Encoders

        /// <summary>
        /// Inits the image encoder filter.
        /// </summary>
        static void InitImageEncoderFilter()
        {
            string filter1 = IMAGE_FILES_DIALOG_FILTER;
            _imageEncoderFilterDefaultIndex = 3;

            filter1 += "|" + SVG_FILE_DIALOG_FILTER;

            // if JBIG2 encoder is available
            if (AvailableEncoders.IsEncoderAvailable("Jbig2"))
                filter1 += "|" + JBIG2_FILE_DIALOG_FILTER;

            // if PDF encoder is available
            if (AvailableEncoders.IsEncoderAvailable("Pdf"))
                filter1 += "|" + PDF_FILE_DIALOG_FILTER;

            // if JPEG encoder is available
            if (AvailableEncoders.IsEncoderAvailable("Jpeg2000"))
                filter1 += "|" + JPEG2000_FILE_DIALOG_FILTER;

            _imageEncoderFilter = filter1;
        }

        /// <summary>
        /// Inits the multipage image encoder filter.
        /// </summary>
        static void InitMultipageImageEncoderFilter()
        {
            string filter1 = "TIFF Files|*.tif;*.tiff";
            _multipageImageEncoderFilterDefaultIndex = 0;

            // if JBIG2 encoder is available
            if (AvailableEncoders.IsEncoderAvailable("Jbig2"))
                filter1 += "|" + JBIG2_FILE_DIALOG_FILTER;

            // if PDF encoder is available
            if (AvailableEncoders.IsEncoderAvailable("Pdf"))
                filter1 += "|" + PDF_FILE_DIALOG_FILTER;

            filter1 += "|" + GIF_FILE_DIALOG_FILTER;

            _multipageImageEncoderFilter = filter1;
        }

        /// <summary>
        /// Inits the image encoder with annotations filter.
        /// </summary>
        static void InitImageEncoderWithAnnotationsFilter()
        {
            string filter1 = TIFF_FILE_DIALOG_FILTER;
            _imageEncoderWithAnnotationsFilterDefaultIndex = 0;

            // if PDF encoder is available
            if (AvailableEncoders.IsEncoderAvailable("Pdf"))
                filter1 += "|" + PDF_FILE_DIALOG_FILTER;

            filter1 += "|" + JPEG_FILE_DIALOG_FILTER;

            filter1 += "|" + PNG_FILE_DIALOG_FILTER;

            _imageEncoderWithAnnotationsFilter = filter1;
        }

        /// <summary>
        /// Inits the multipage image encoder with annotations filter.
        /// </summary>
        static void InitMultipageImageEncoderWithAnnotationsFilter()
        {
            string filter1 = TIFF_FILE_DIALOG_FILTER;
            _multipageImageEncoderWithAnnotationsFilterDefaultIndex = 0;

            // if PDF encoder is available
            if (AvailableEncoders.IsEncoderAvailable("Pdf"))
                filter1 += "|" + PDF_FILE_DIALOG_FILTER;

            _multipageImageEncoderWithAnnotationsFilter = filter1;
        }

        #endregion

        #endregion

        #endregion

    }
}
