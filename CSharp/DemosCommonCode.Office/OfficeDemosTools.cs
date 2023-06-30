using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using DemosCommonCode.Imaging;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
#if !REMOVE_OFFICE_PLUGIN
using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Docx;
#endif
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Office
{
    /// <summary>
    /// Contains collection of helper-algorithms for demo applications, which use VintaSoft Office .NET Plugin.
    /// </summary>
    public static class OfficeDemosTools
    {

        #region Fields

        /// <summary>
        /// The chart images.
        /// </summary>
        static ImageCollection _chartImages;

        /// <summary>
        /// The dialog that allows to open Office document.
        /// </summary>
        static OpenFileDialog _openDocumentDialog = new OpenFileDialog();

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes the <see cref="OfficeDemosTools"/> class.
        /// </summary>
        static OfficeDemosTools()
        {
            _openDocumentDialog.Filter = "All Supported Documents (*.docx;*.doc;*.txt)|*.docx;*.doc;*.txt";
        }

        #endregion



        #region Methods

        /// <summary>
        /// Selects the Chart resource.
        /// </summary>
        public static Stream SelectChartResource()
        {
            string[] chartResourceNames = DemosResourcesManager.FindResourceNames("Chart_");

            // if collection of chart images is not created
            if (_chartImages == null)
            {
                // create collection of chart images
                _chartImages = new ImageCollection();
                _chartImages.LayoutSettingsRequest += ChartImages_LayoutSettingsRequest;
                foreach (string chartResourceName in chartResourceNames)
                    _chartImages.Add(DemosResourcesManager.GetResourceAsStream(chartResourceName), true);
            }
            if (_chartImages.Count == 0)
                throw new Exception("Chart resources was not found.");

            // create "Select image" form
            SelectImageForm selectImageForm = new SelectImageForm(_chartImages);
            selectImageForm.Size = new Size(900, 550);
            selectImageForm.ImagePreviewViewer.ThumbnailSize = new Size(200, 200);
            selectImageForm.ImagePreviewViewer.ThumbnailFlowStyle = ThumbnailFlowStyle.WrappedRows;
            selectImageForm.ImagePreviewViewer.SelectedThumbnailAppearance.BorderColor = Color.Black;
            selectImageForm.ImagePreviewViewer.FocusedThumbnailAppearance = selectImageForm.ImagePreviewViewer.SelectedThumbnailAppearance;
            selectImageForm.Text = "Select a chart";
            selectImageForm.TopMost = true;

            if (selectImageForm.ShowDialog() != DialogResult.OK)
                return null;

            string selectedChartResourceName = chartResourceNames[selectImageForm.SelectedImageIndex];

            return DemosResourcesManager.GetResourceAsStream(selectedChartResourceName);
        }

        /// <summary> 
        /// Handles the LayoutSettingsRequest event of the ChartImages.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DocumentLayoutSettingsRequestEventArgs"/> instance containing the event data.</param>
        private static void ChartImages_LayoutSettingsRequest(object sender, DocumentLayoutSettingsRequestEventArgs e)
        {
            // specify that only first page must be layouted
            e.LayoutSettings.PageCount = 1;

            // specify that relative size of graphics object must be used
            e.LayoutSettings.UseGraphicObjectReleativeSize = true;

            // set the page size to 70x70mm
            e.LayoutSettings.PageLayoutSettings = new PageLayoutSettings(ImageSize.FromMillimeters(70, 70, new Resolution(96)));
        }

        /// <summary>
        /// Selects the Office document.
        /// </summary>
        public static Stream SelectOfficeDocument()
        {
#if !REMOVE_OFFICE_PLUGIN
            // if image is selected
            if (_openDocumentDialog.ShowDialog() == DialogResult.OK)
            {
                string documentFilename = _openDocumentDialog.FileName;
                if (File.Exists(documentFilename))
                {
                    // if selected file is TXT file
                    if (Path.GetExtension(documentFilename).ToLowerInvariant() == ".txt")
                    {
                        // convert TXT file to a DOCX document
                        return ConvertTxtFileToDocxDocument(documentFilename);
                    }

                    // open document
                    return File.OpenRead(documentFilename);
                }

                // use empty document
                return DemosResourcesManager.GetResourceAsStream("EmptyDocument.docx");
            }
#endif
            return null;
        }

        /// <summary>
        /// Converts the text file to a DOCX document.
        /// </summary>
        /// <param name="txtFilename">The text filename.</param>
        /// <returns>Stream that contains converted DOCX document.</returns>
        public static Stream ConvertTxtFileToDocxDocument(string txtFilename)
        {
#if !REMOVE_OFFICE_PLUGIN
            // get "EmptyDocument.docx" resource
            using (Stream documentStream = DemosResourcesManager.GetResourceAsStream("EmptyDocument.docx"))
            {
                if (documentStream == null)
                    throw new Exception("TXT to DOCX conversion error: Resource 'EmptyDocument.docx' is not found in demo application.");

                MemoryStream tempStream = new MemoryStream();
                // create DOCX editor for "EmptyDocument.docx"
                using (DocxDocumentEditor editor = new DocxDocumentEditor(documentStream))
                {
                    // set document text to a TXT file
                    editor.Body.Text = File.ReadAllText(txtFilename);

                    // save document
                    editor.Save(tempStream);
                }

                return tempStream;
            }
#else
            return null;
#endif
        }

        #endregion

    }
}
