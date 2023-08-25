using System;
using System.Drawing.Printing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Print;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Represents a print manager of an image viewer.
    /// </summary>
    public class ImageViewerPrintManager
    {

        #region Fields

        /// <summary>
        /// A value indicating whether printing is started.
        /// </summary>
        bool _isPrintingStarted = false;

        /// <summary>
        /// Array of images to print.
        /// </summary>
        int[] _imagesToPrint;

        /// <summary>
        /// Index of the printing page.
        /// </summary>
        int _printPageIndex = 0;

        /// <summary>
        /// A value indicating whether current image must be disposed after print.
        /// </summary>
        bool _disposeCurrentImageAfterUse;

        /// <summary>
        /// The image viewer.
        /// </summary>
        ImageViewerBase _imageViewer;        

        /// <summary>
        /// The <see cref="PrintDialog"/>.
        /// </summary>
        PrintDialog _printDialog;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageViewerPrintManager"/> class.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        /// <param name="printDocument">The ImagePrintDocument.</param>
        /// <param name="printDialog">The PrintDialog.</param>
        public ImageViewerPrintManager(
            ImageViewerBase imageViewer,
            ImagePrintDocument printDocument,
            PrintDialog printDialog)
        {
            _imageViewer = imageViewer;

            _printDialog = printDialog;

            _printDocument = printDocument;
            _printDocument.BeginPrint += new PrintEventHandler(printDocument_BeginPrint);
            _printDocument.PrintImage += new EventHandler<PrintImageEventArgs>(printDocument_PrintImage);
            _printDocument.EndPrint += new PrintEventHandler(printDocument_EndPrint);
            _printDocument.ImagePrinted += new EventHandler<PrintImageEventArgs>(printDocument_EndPrintImage);
            _printDocument.PrintingException += new EventHandler<ExceptionEventArgs>(printDocument_PrintingException);

            // no margins
            _printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
        }

        #endregion



        #region Properties

        ImagePrintDocument _printDocument;
        /// <summary>
        /// Gets the <see cref="ImagePrintDocument"/>.
        /// </summary>
        public ImagePrintDocument PrintDocument
        {
            get
            {
                return _printDocument;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Starts printing the images.
        /// </summary>
        public void Print()
        {
            try
            {
                _printDialog.PrinterSettings.FromPage = 1;
                _printDialog.PrinterSettings.ToPage = _imageViewer.Images.Count;

                Print(true, false);
            }
            catch(Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Starts printing the images.
        /// </summary>
        /// <param name="showPrintDialog">Defines if print dialog should be shown.</param>
        /// <param name="reverse">Defines if pages should be printed in reverse order.</param>
        public void Print(bool showPrintDialog, bool reverse)
        {
            if (_isPrintingStarted)
                return;

            _isPrintingStarted = true;

            try
            {
                if (_imageViewer.Images.Count == 0)
                    return;
                if (_imagesToPrint != null)
                {
                    DemosTools.ShowWarningMessage("Another print process is still working.");
                    return;
                }

                if (showPrintDialog)
                {
                    // show print dialog
                    DialogResult dialogResult = _printDialog.ShowDialog();

                    // PrintDialog control has bug and sometimes does not show print dialog and returns
                    // Cancel as a result of execution of the ShowDialog method. This problem can be solved
                    // if you will set the UseEXDialog property to True.
                    if (dialogResult == DialogResult.Cancel)
                    {
                        _printDialog.UseEXDialog = true;
                        dialogResult = _printDialog.ShowDialog();
                    }

                    // start print if dialog results is OK
                    if (dialogResult != DialogResult.OK)
                        return;
                }

                switch (_printDialog.PrinterSettings.PrintRange)
                {
                    case PrintRange.AllPages:
                        _imagesToPrint = new int[_imageViewer.Images.Count];
                        for (int i = 0; i < _imagesToPrint.Length; i++)
                            _imagesToPrint[i] = i;
                        break;

                    case PrintRange.SomePages:
                        _imagesToPrint = new int[_printDialog.PrinterSettings.ToPage - _printDialog.PrinterSettings.FromPage + 1];
                        for (int i = 0; i < _imagesToPrint.Length; i++)
                            _imagesToPrint[i] = _printDialog.PrinterSettings.FromPage + i - 1;
                        break;

                    case PrintRange.Selection:
                        ThumbnailViewer thumbnailViewer = _imageViewer as ThumbnailViewer;
                        if (thumbnailViewer != null && thumbnailViewer.SelectedIndices.Count > 0)
                            _imagesToPrint = thumbnailViewer.SelectedIndices.ToArray();
                        else
                            _imagesToPrint = new int[1] { _imageViewer.FocusedIndex };
                        break;

                    case PrintRange.CurrentPage:
                        _imagesToPrint = new int[1] { _imageViewer.FocusedIndex };
                        break;
                }

                if (reverse && _imagesToPrint.Length > 1)
                    Array.Reverse(_imagesToPrint);

                _printDocument.Print();
            }
            finally
            {
                _isPrintingStarted = false;
            }
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Returns the image that should be printed.
        /// </summary>
        /// <param name="imageIndex">Index of the image in image collection of the viewer.</param>
        /// <param name="disposeAfterUse">Determines whether to dispose returned image after use.</param>
        /// <returns>Image that should be printed.</returns>
        protected virtual VintasoftImage GetImage(int imageIndex, out bool disposeAfterUse)
        {
            disposeAfterUse = false;
            return _imageViewer.Images[imageIndex];
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the BeginPrint event of the printDocument control.
        /// </summary>
        private void printDocument_BeginPrint(object sender, PrintEventArgs e)
        {            
            if (_imagesToPrint.Length == 0)
                e.Cancel = true;

            _printPageIndex = 0;
        }

        /// <summary>
        /// Handles the PrintImage event of the printDocument control.
        /// </summary>
        private void printDocument_PrintImage(object sender, PrintImageEventArgs e)
        {
            // if there are images to print
            if (_imagesToPrint.Length > 0)
            {
                bool hasMoreImages = true;

                // get the printed image
                int imageIndex = _imagesToPrint[_printPageIndex];
                if (imageIndex >= _imageViewer.Images.Count)
                {
                    e.HasMoreImages = false;
                    return;
                }
                try
                {
                    e.Image = GetImage(imageIndex, out _disposeCurrentImageAfterUse);
                }
                catch (DecoderException)
                {
                    hasMoreImages = false;
                }
                // increment the count of printed pages
                _printPageIndex++;

                // check if there is more images to print
                if (hasMoreImages && (_printPageIndex >= _imagesToPrint.Length))
                {
                    hasMoreImages = false;
                }
                e.HasMoreImages = hasMoreImages;
            }
        }

        /// <summary>
        /// Handles the EndPrintImage event of the printDocument control.
        /// </summary>
        private void printDocument_EndPrintImage(object sender, PrintImageEventArgs e)
        {
            if (_disposeCurrentImageAfterUse)
                e.Image.Dispose();
        }

        /// <summary>
        /// Handles the EndPrint event of the printDocument control.
        /// </summary>
        private void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            // clear array of pages to print
            _imagesToPrint = null;
            _printPageIndex = 0;
        }

        /// <summary>
        /// Handles the PrintingException event of the printDocument control.
        /// </summary>
        private void printDocument_PrintingException(object sender, ExceptionEventArgs e)
        {
            DemosTools.ShowErrorMessage(e.Exception);
        }

        #endregion

        #endregion

    }
}