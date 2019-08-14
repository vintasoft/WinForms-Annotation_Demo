using System.Windows.Forms;
using Vintasoft.Imaging.Codecs;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Codecs.Encoders;

namespace DemosCommonCode.Imaging.Codecs
{
    /// <summary>
    /// Class that contains filters for Open/Save dialogs.
    /// </summary>
    public class CodecsFileFilters
    {

        #region Constants

        const string Filters_ImagesFiles = "BMP Files|*.bmp|JPEG Files|*.jpg;*.jpeg|PNG Files|*.png|TIFF Files|*.tif;*.tiff|GIF Files|*.gif|PCX Files|*.pcx";
        const string Filters_AllImageFiles = "All Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.gif;*.pcx;";

        const string Filters_Extended = "*.wmf;*.emf;*.ico;*.cur;*.jls;";
        const string Filters_ExtendedFiles = "EMF Files|*.emf|WMF Files|*.wmf|Icon Files|*.ico|Cursor Files|*.cur|JPEG-LS Files|*.jls";

        const string Filters_TiffFiles = "TIFF Files|*.tif;*.tiff";
        const string Filters_JpegFiles = "JPEG Files|*.jpg;*.jpeg";

        const string Filters_Pdf = "*.pdf";
        const string Filters_PdfFiles = "PDF Files|" + Filters_Pdf;

        const string Filters_Gif = "*.gif";
        const string Filters_GifFiles = "GIF Files|" + Filters_Gif;

        const string Filters_Png = "*.png";
        const string Filters_PngFiles = "PNG Files|" + Filters_Png;

        const string Filters_Jbig2 = "*.jb2;*.jbig2";
        const string Filters_Jbig2Files = "JBIG2 Files|" + Filters_Jbig2;

        const string Filters_Jpeg2000 = "*.jp2;*.j2k;*.j2c;*.jpc";
        const string Filters_Jpeg2000Files = "JPEG 2000 Files|" + Filters_Jpeg2000;

        const string Filters_Raw = "*.cr2;*.crw;*.nef;*.nrw;*.dng";
        const string Filters_RawFiles = "RAW Image Files|" + Filters_Raw;

        const string Filters_Dicom = "*.dcm;*.dic;*.acr";
        const string Filters_DicomFiles = "DICOM files|" + Filters_Dicom;

        #endregion



        #region Properties

        #region Decoder

        static string _decoderFilters = null;
        public static string DecoderFilters
        {
            get
            {
                if (_decoderFilters == null)
                    SetDecoderFilters();
                return _decoderFilters;
            }
        }

        static int _decoderFiltersDefaultFilterIndex = -1;
        public static int DecoderFiltersDefaultFilterIndex
        {
            get
            {
                if (_decoderFiltersDefaultFilterIndex == -1)
                    SetDecoderFilters();
                return _decoderFiltersDefaultFilterIndex;
            }
        }

        #endregion


        #region Encoder

        static string _encoderFilters = null;
        public static string EncoderFilters
        {
            get
            {
                if (_encoderFilters == null)
                    SetEncoderFilters();
                return _encoderFilters;
            }
        }

        static int _encoderFiltersDefaultFilterIndex = -1;
        public static int EncoderFiltersDefaultFilterIndex
        {
            get
            {
                if (_encoderFiltersDefaultFilterIndex == -1)
                    SetEncoderFilters();
                return _encoderFiltersDefaultFilterIndex;
            }
        }

        static string _multiPageEncoderFilters = null;       
        public static string MultipageEncoderFilters
        {
            get
            {
                if (_multiPageEncoderFilters == null)
                    SetMultiPageEncoderFilters();
                return _multiPageEncoderFilters;
            }
        }


        static int _multiPageEncoderFiltersDefaultFilterIndex = -1;
        public static int MultipageEncoderFiltersDefaultFilterIndex
        {
            get
            {
                if (_multiPageEncoderFiltersDefaultFilterIndex == -1)
                    SetMultiPageEncoderFilters();
                return _multiPageEncoderFiltersDefaultFilterIndex;
            }
        }


        static string _encoderFiltersWithAnnotations = null;
        public static string EncoderFiltersWithAnnotations
        {
            get
            {
                if (_encoderFiltersWithAnnotations == null)
                    SetEncoderFiltersWithAnnotations();
                return _encoderFiltersWithAnnotations;
            }
        }

        static int _encoderFiltersWithAnnotationsDefaultFilterIndex = -1;
        public static int EncoderFiltersWithAnnotationsDefaultFilterIndex
        {
            get
            {
                if (_encoderFiltersWithAnnotationsDefaultFilterIndex == -1)
                    SetEncoderFiltersWithAnnotations();
                return _encoderFiltersWithAnnotationsDefaultFilterIndex;
            }
        }

        static string _multiPageEncoderFiltersWithAnnotations = null;
        public static string MultipageEncoderFiltersWithAnnotations
        {
            get
            {
                if (_multiPageEncoderFiltersWithAnnotations == null)
                    SetMultiPageEncoderFiltersWithAnnotations();
                return _multiPageEncoderFiltersWithAnnotations;
            }
        }

        static int _multiPageEncoderFiltersWithAnnotationsDefaultFilterIndex = -1;
        public static int MultipageEncoderFiltersWithAnnotationsDefaultFilterIndex
        {
            get
            {
                if (_multiPageEncoderFiltersWithAnnotationsDefaultFilterIndex == -1)
                    SetMultiPageEncoderFiltersWithAnnotations();
                return _multiPageEncoderFiltersWithAnnotationsDefaultFilterIndex;
            }
        }

        #endregion
        
        #endregion



        #region Methods

        #region Decoder

        static void SetDecoderFilters()
        {
            string filter1 = string.Format("{0}|{1}", Filters_ImagesFiles, Filters_ExtendedFiles);
            string filter2 = Filters_AllImageFiles + Filters_Extended;
            _decoderFiltersDefaultFilterIndex = 12;

            if (AvailableDecoders.IsDecoderAvailable("Jbig2"))
            {
                filter1 += "|" + Filters_Jbig2Files;
                filter2 += Filters_Jbig2 + ";";
                _decoderFiltersDefaultFilterIndex++;
            }

            if (AvailableDecoders.IsDecoderAvailable("Pdf"))
            {
                filter1 += "|" + Filters_PdfFiles;
                filter2 += Filters_Pdf + ";";
                _decoderFiltersDefaultFilterIndex++;
            }

            if (AvailableDecoders.IsDecoderAvailable("Jpeg2000"))
            {
                filter1 += "|" + Filters_Jpeg2000Files;
                filter2 += Filters_Jpeg2000 + ";";
                _decoderFiltersDefaultFilterIndex++;
            }

            if (AvailableDecoders.IsDecoderAvailable("Raw"))
            {
                filter1 += "|" + Filters_RawFiles;
                filter2 += Filters_Raw + ";";
                _decoderFiltersDefaultFilterIndex++;
            }

            if (AvailableDecoders.IsDecoderAvailable("Dicom"))
            {
                filter1 += "|" + Filters_DicomFiles;
                filter2 += Filters_Dicom + ";";
                _decoderFiltersDefaultFilterIndex++;
            }

            _decoderFilters = string.Format("{0}|{1}", filter1, filter2);
        }


        public static void SetFilters(OpenFileDialog dialog)
        {
            try
            {
                dialog.Filter = DecoderFilters;
                dialog.FilterIndex = DecoderFiltersDefaultFilterIndex;
            }
            catch
            {
            }
        }

        public static void SetFilters(SaveFileDialog dialog, bool multipageOnly)
        {
            try
            {
                if (multipageOnly)
                {
                    dialog.Filter = MultipageEncoderFilters;
                    dialog.FilterIndex = MultipageEncoderFiltersDefaultFilterIndex;
                    dialog.DefaultExt = ".tif";
                }
                else
                {
                    dialog.Filter = EncoderFilters;
                    dialog.FilterIndex = EncoderFiltersDefaultFilterIndex;
                    dialog.DefaultExt = ".png";
                }
                dialog.OverwritePrompt = false;
            }
            catch
            {
            }
        }

        public static void SetFiltersWithAnnotations(SaveFileDialog dialog, bool multipageOnly)
        {
            if (multipageOnly)
            {
                dialog.Filter = MultipageEncoderFiltersWithAnnotations;
                dialog.FilterIndex = MultipageEncoderFiltersWithAnnotationsDefaultFilterIndex;
            }
            else
            {
                dialog.Filter = EncoderFiltersWithAnnotations;
                dialog.FilterIndex = EncoderFiltersWithAnnotationsDefaultFilterIndex;
            }
            dialog.OverwritePrompt = false;
            dialog.DefaultExt = ".tif";
        }

        #endregion


        #region Encoder

        static void SetEncoderFilters()
        {
            string filter1 = Filters_ImagesFiles;
            _encoderFiltersDefaultFilterIndex = 3;

            if (AvailableEncoders.IsEncoderAvailable("Jbig2"))
                filter1 += "|" + Filters_Jbig2Files;

            if (AvailableEncoders.IsEncoderAvailable("Pdf"))
                filter1 += "|" + Filters_PdfFiles;

            if (AvailableEncoders.IsEncoderAvailable("Jpeg2000"))
                filter1 += "|" + Filters_Jpeg2000Files;

            _encoderFilters = filter1;
        }

        static void SetMultiPageEncoderFilters()
        {
            string filter1 = "TIFF Files|*.tif;*.tiff";
            _multiPageEncoderFiltersDefaultFilterIndex = 0;

            if (AvailableEncoders.IsEncoderAvailable("Jbig2"))
                filter1 += "|" + Filters_Jbig2Files;

            if (AvailableEncoders.IsEncoderAvailable("Pdf"))
                filter1 += "|" + Filters_PdfFiles;

            filter1 += "|" + Filters_GifFiles;

            _multiPageEncoderFilters = filter1;
        }


        static void SetEncoderFiltersWithAnnotations()
        {
            string filter1 = Filters_TiffFiles;
            _encoderFiltersWithAnnotationsDefaultFilterIndex = 0;

            if (AvailableEncoders.IsEncoderAvailable("Pdf"))
                filter1 += "|" + Filters_PdfFiles;

            filter1 += "|" + Filters_JpegFiles;

            filter1 += "|" + Filters_PngFiles;

            _encoderFiltersWithAnnotations = filter1;
        }

        static void SetMultiPageEncoderFiltersWithAnnotations()
        {
            string filter1 = Filters_TiffFiles;
            _multiPageEncoderFiltersWithAnnotationsDefaultFilterIndex = 0;

            if (AvailableEncoders.IsEncoderAvailable("Pdf"))
                filter1 += "|" + Filters_PdfFiles;

            _multiPageEncoderFiltersWithAnnotations = filter1;
        }

        #endregion

        #endregion

    }
}
