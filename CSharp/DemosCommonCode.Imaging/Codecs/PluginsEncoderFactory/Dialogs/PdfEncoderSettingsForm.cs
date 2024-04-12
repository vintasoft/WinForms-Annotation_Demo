using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Encoders;

using Vintasoft.Imaging.Pdf;

namespace DemosCommonCode.Imaging.Codecs.Dialogs
{
    /// <summary>
    /// A form that allows to view and edit the PDF encoder settings.
    /// </summary>
    public partial class PdfEncoderSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// Tooltip that shows error message if Vintasoft.Imaging.Annotation.Pdf.dll is not found.
        /// </summary>
        ToolTip _annotationPdfIsNotFoundToolTip;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfEncoderSettingsForm"/> class.
        /// </summary>
        public PdfEncoderSettingsForm()
        {
            InitializeComponent();

            updateModeComboBox.Items.Add(PdfDocumentUpdateMode.Auto);
            updateModeComboBox.Items.Add(PdfDocumentUpdateMode.Incremental);
            updateModeComboBox.Items.Add(PdfDocumentUpdateMode.Pack);
            updateModeComboBox.Items.Add(PdfDocumentUpdateMode.CleanupAndPack);
            updateModeComboBox.Items.Add(PdfDocumentUpdateMode.SubsetFontsAndPack);
            updateModeComboBox.SelectedIndex = 0;

            CanEditAnnotationSettings = false;

#if !REMOVE_PDF_PLUGIN
            PdfDocumentConformance[] conformances = new PdfDocumentConformance[] {
                 PdfDocumentConformance.PdfA_1a,
                 PdfDocumentConformance.PdfA_1b,
                 PdfDocumentConformance.PdfA_2a,
                 PdfDocumentConformance.PdfA_2b,
                 PdfDocumentConformance.PdfA_2u,
                 PdfDocumentConformance.PdfA_3a,
                 PdfDocumentConformance.PdfA_3b,
                 PdfDocumentConformance.PdfA_3u,
                 PdfDocumentConformance.PdfA_4,
                 PdfDocumentConformance.PdfA_4e,
                 PdfDocumentConformance.PdfA_4f,
            };
            foreach (PdfDocumentConformance conformance in conformances)
                conformanceComboBox.Items.Add(ConvertToString(conformance));

            conformanceComboBox.SelectedIndex = 1;

            // if PDF encoder cannot generate annotation appearance in PDF document
            if (!PdfEncoder.CanGeneratePdfAnnotationAppearance)
            {
                // disable the ability to generate annotation appearance in PDF document
                annotationsPdfAppearanceCheckBox.Enabled = false;

                // create the tooltip that shows error message if Vintasoft.Imaging.Annotation.Pdf.dll is not found
                _annotationPdfIsNotFoundToolTip = new ToolTip();

                // add handler to the mouse move event
                // (necessary because the annotationsPdfAppearanceCheckBox control is disabled)
                annotationsTabPage.MouseMove += new MouseEventHandler(annotationsTabPage_MouseMove);
            }
#endif
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether PDF document can be compressed with MRC compression only.
        /// </summary>
        /// <value>
        /// <b>true</b> - PDF document can be compressed only with MRC compression;
        /// <b>false</b> - PDF document can be compressed with or without MRC compression.
        /// </value>
        public bool IsMrcCompressionOnly
        {
            get
            {
                return pdfImageCompressionControl1.IsMrcCompressionOnly;
            }
            set
            {
                pdfImageCompressionControl1.IsMrcCompressionOnly = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether PDF document can be compressed with MRC compression.
        /// </summary>
        /// <value>
        /// <b>True</b> - PDF document can be compressed with or without MRC compression;
        /// <b>false</b> - PDF document can be compressed with image compression only.
        /// </value>
        public bool AllowMrcCompression
        {
            get
            {
                return pdfImageCompressionControl1.AllowMrcCompression;
            }
            set
            {
                pdfImageCompressionControl1.AllowMrcCompression = value;
            }
        }

        PdfEncoderSettings _encoderSettings;
        /// <summary>
        /// Gets or sets the PDF encoder settings.
        /// </summary>
        public PdfEncoderSettings EncoderSettings
        {
            get
            {
                return _encoderSettings;
            }
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException();
                if (_encoderSettings != value)
                {
                    _encoderSettings = value;
#if !REMOVE_PDF_PLUGIN
                    pdfImageCompressionControl1.Compression = ConvertToPdfCompression(_encoderSettings.Compression);
                    pdfImageCompressionControl1.CompressionSettings = new PdfCompressionSettings();
                    PdfCompressionSettings settings = pdfImageCompressionControl1.CompressionSettings;
                    settings.Jbig2Settings = _encoderSettings.Jbig2Settings;
                    settings.Jbig2UseGlobals = _encoderSettings.Jbig2UseGlobals;
                    settings.Jpeg2000Settings = _encoderSettings.Jpeg2000Settings;
                    settings.JpegSettings = _encoderSettings.JpegSettings;
                    settings.BinarizationCommand = _encoderSettings.BinarizationCommand;
#endif
                    if (CanEditImageTilesSettings)
                    {
                        tileWidthCheckBox.Checked = _encoderSettings.ImageTileWidth > 0;
                        tileHeightCheckBox.Checked = _encoderSettings.ImageTileHeight > 0;
                        if (tileHeightCheckBox.Checked)
                            tileHeightNumericUpDown.Value = _encoderSettings.ImageTileHeight;
                        if (tileWidthCheckBox.Checked)
                            tileWidthNumericUpDown.Value = _encoderSettings.ImageTileWidth;
                    }
                    UpdateUI();
                }
            }
        }

#if !REMOVE_PDF_PLUGIN && !REMOVE_DOCCLEANUP_PLUGIN
        /// <summary>
        /// Gets or sets the PDF MRC compression settings.
        /// </summary>
        public PdfMrcCompressionSettings MrcCompressionSettings
        {
            get
            {
                return pdfImageCompressionControl1.MrcCompressionSettings;
            }
            set
            {
                pdfImageCompressionControl1.MrcCompressionSettings = value;
            }
        }
#endif

        /// <summary>
        /// Gets or sets a value indicating whether the images can be added to an existing PDF document.
        /// </summary>
        public bool AppendExistingDocument
        {
            get
            {
                return appendCheckBox.Checked;
            }
            set
            {
                appendCheckBox.Checked = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="AppendExistingDocument"/> is enabled.
        /// </summary>
        public bool AppendExistingDocumentEnabled
        {
            get
            {
                return appendCheckBox.Enabled;
            }
            set
            {
                appendCheckBox.Enabled = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the annotation settings can be edited.
        /// </summary>
        public bool CanEditAnnotationSettings
        {
            get
            {
                return tabControl1.TabPages.Contains(annotationsTabPage);
            }
            set
            {
                if (CanEditAnnotationSettings != value)
                {
                    if (value)
                        tabControl1.TabPages.Add(annotationsTabPage);
                    else
                        tabControl1.TabPages.Remove(annotationsTabPage);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the image tiles settings can be edited.
        /// </summary>
        public bool CanEditImageTilesSettings
        {
            get
            {
                return imageTilesGroupBox.Enabled;
            }
            set
            {
                if (CanEditImageTilesSettings != value)
                {
                    imageTilesGroupBox.Enabled = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether PDF annotation appearance should be generated.
        /// </summary>
        public bool GeneratePdfAnnotationsAppearence
        {
            get
            {
                return annotationsPdfAppearanceCheckBox.Checked;
            }
            set
            {
                annotationsPdfAppearanceCheckBox.Checked = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

#if !REMOVE_PDF_PLUGIN
        /// <summary>
        /// Converts the PdfDocumentConformance to a string.
        /// </summary>
        public static string ConvertToString(PdfDocumentConformance documentConformance)
        {
            switch (documentConformance)
            {
                case PdfDocumentConformance.PdfA_1a:
                    return "PDF/A-1a";
                case PdfDocumentConformance.PdfA_1b:
                    return "PDF/A-1b";
                case PdfDocumentConformance.PdfA_2a:
                    return "PDF/A-2a";
                case PdfDocumentConformance.PdfA_2b:
                    return "PDF/A-2b";
                case PdfDocumentConformance.PdfA_2u:
                    return "PDF/A-2u";
                case PdfDocumentConformance.PdfA_3a:
                    return "PDF/A-3a";
                case PdfDocumentConformance.PdfA_3b:
                    return "PDF/A-3b";
                case PdfDocumentConformance.PdfA_3u:
                    return "PDF/A-3u";
                case PdfDocumentConformance.PdfA_4:
                    return "PDF/A-4";
                case PdfDocumentConformance.PdfA_4e:
                    return "PDF/A-4e";
                case PdfDocumentConformance.PdfA_4f:
                    return "PDF/A-4f";
            }
            return null;
        }

        /// <summary>
        /// Converts a string to a PdfDocumentConformance.
        /// </summary>
        public static PdfDocumentConformance ConvertFromString(string documentConformance)
        {
            switch (documentConformance)
            {
                case "PDF/A-1a":
                    return PdfDocumentConformance.PdfA_1a;

                case "PDF/A-1b":
                    return PdfDocumentConformance.PdfA_1b;

                case "PDF/A-2a":
                    return PdfDocumentConformance.PdfA_2a;

                case "PDF/A-2b":
                    return PdfDocumentConformance.PdfA_2b;

                case "PDF/A-2u":
                    return PdfDocumentConformance.PdfA_2u;

                case "PDF/A-3a":
                    return PdfDocumentConformance.PdfA_3a;

                case "PDF/A-3b":
                    return PdfDocumentConformance.PdfA_3b;

                case "PDF/A-3u":
                    return PdfDocumentConformance.PdfA_3u;

                case "PDF/A-4":
                    return PdfDocumentConformance.PdfA_4;

                case "PDF/A-4e":
                    return PdfDocumentConformance.PdfA_4e;

                case "PDF/A-4f":
                    return PdfDocumentConformance.PdfA_4f;
            }

            return PdfDocumentConformance.Undefined;
        }
#endif

        #endregion


        #region PROTECTED

        /// <summary>
        /// Creates the encoder settings.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (EncoderSettings == null)
                EncoderSettings = new PdfEncoderSettings();
        }

        /// <summary>
        /// Removes the annotations tab page.
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (CanEditAnnotationSettings)
            {
                tabControl1.TabPages.Remove(annotationsTabPage);
                tabControl1.TabPages.Insert(1, annotationsTabPage);
            }
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the CheckedChanged event of appendCheckBox object.
        /// </summary>
        private void appendCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (appendCheckBox.Checked)
            {
                pdfaCheckBox.Enabled = false;
                pdfaCheckBox.Checked = false;
            }
            else
            {
                pdfaCheckBox.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of buttonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            SyncEncoderSettingsWithUI();

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the CheckedChanged event of pdfaCheckBox object.
        /// </summary>
        private void pdfaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if PDF must be compatible to PDF/A
            if (pdfaCheckBox.Checked)
                conformanceComboBox.Enabled = true;
            else
                conformanceComboBox.Enabled = false;
        }

        #endregion


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
#if !REMOVE_PDF_PLUGIN
            pdfaCheckBox.Checked = _encoderSettings.PdfACompatible;
            if (_encoderSettings.PdfACompatible)
                conformanceComboBox.SelectedItem = ConvertToString(_encoderSettings.Conformance);
#endif

            tileWidthNumericUpDown.Enabled = tileWidthCheckBox.Checked;
            tileHeightNumericUpDown.Enabled = tileHeightCheckBox.Checked;

            titleTextBox.Text = _encoderSettings.DocumentTitle;
            authorTextBox.Text = _encoderSettings.DocumentAuthor;
            creatorTextBox.Text = _encoderSettings.DocumentCreator;
            keywordsTextBox.Text = _encoderSettings.DocumentKeywords;
            producerTextBox.Text = _encoderSettings.DocumentProducer;
            subjectTextBox.Text = _encoderSettings.DocumentSubject;

            annotationsBinaryCheckBox.Checked = (EncoderSettings.AnnotationsFormat & AnnotationsFormat.VintasoftBinary) != 0;
            annotationXmpCheckBox.Checked = (EncoderSettings.AnnotationsFormat & AnnotationsFormat.VintasoftXmp) != 0;

            createThumbnailsCheckBox.Checked = EncoderSettings.CreateThumbnails;

            if (annotationsPdfAppearanceCheckBox.Enabled)
                annotationsPdfAppearanceCheckBox.Checked = _encoderSettings.GenerateAnnotationAppearance;

            tileWidthNumericUpDown.Enabled = tileWidthCheckBox.Checked;
            tileHeightNumericUpDown.Enabled = tileHeightCheckBox.Checked;

            updateModeComboBox.SelectedItem = _encoderSettings.UpdateMode;
        }

        /// <summary>
        /// Synchronizes the <see cref="EncoderSettings"/> property with UI.
        /// </summary>
        private void SyncEncoderSettingsWithUI()
        {
#if !REMOVE_PDF_PLUGIN
            if (pdfaCheckBox.Checked)
                EncoderSettings.Conformance = ConvertFromString(conformanceComboBox.SelectedItem.ToString());
            else
                EncoderSettings.Conformance = PdfDocumentConformance.Undefined;
#endif

            if (CanEditImageTilesSettings)
            {
                if (tileWidthCheckBox.Checked)
                    EncoderSettings.ImageTileWidth = (int)tileWidthNumericUpDown.Value;
                else
                    EncoderSettings.ImageTileWidth = 0;

                if (tileHeightCheckBox.Checked)
                    EncoderSettings.ImageTileHeight = (int)tileHeightNumericUpDown.Value;
                else
                    EncoderSettings.ImageTileHeight = 0;
            }

            EncoderSettings.DocumentTitle = titleTextBox.Text;
            EncoderSettings.DocumentAuthor = authorTextBox.Text;
            EncoderSettings.DocumentCreator = creatorTextBox.Text;
            EncoderSettings.DocumentKeywords = keywordsTextBox.Text;
            EncoderSettings.DocumentProducer = producerTextBox.Text;
            EncoderSettings.DocumentSubject = subjectTextBox.Text;
#if !REMOVE_PDF_PLUGIN
            EncoderSettings.Compression = ConvertToPdfImageCompression(pdfImageCompressionControl1.Compression);

            EncoderSettings.Jbig2Settings = pdfImageCompressionControl1.CompressionSettings.Jbig2Settings;
            EncoderSettings.Jbig2UseGlobals = pdfImageCompressionControl1.CompressionSettings.Jbig2UseGlobals;
            EncoderSettings.Jpeg2000Settings = pdfImageCompressionControl1.CompressionSettings.Jpeg2000Settings;
            EncoderSettings.JpegQuality = pdfImageCompressionControl1.CompressionSettings.JpegQuality;
            EncoderSettings.JpegSaveAsGrayscale = pdfImageCompressionControl1.CompressionSettings.JpegSaveAsGrayscale;
            EncoderSettings.ZipCompressionLevel = pdfImageCompressionControl1.CompressionSettings.ZipCompressionLevel;
#endif

            if (CanEditAnnotationSettings)
            {
                EncoderSettings.AnnotationsFormat = AnnotationsFormat.None;
                if (annotationsBinaryCheckBox.Checked)
                    EncoderSettings.AnnotationsFormat |= AnnotationsFormat.VintasoftBinary;
                if (annotationXmpCheckBox.Checked)
                    EncoderSettings.AnnotationsFormat |= AnnotationsFormat.VintasoftXmp;
            }

            EncoderSettings.CreateThumbnails = createThumbnailsCheckBox.Checked;

            if (CanEditAnnotationSettings)
            {
                EncoderSettings.GenerateAnnotationAppearance = annotationsPdfAppearanceCheckBox.Checked;
            }

            EncoderSettings.UpdateMode = (PdfDocumentUpdateMode)updateModeComboBox.SelectedItem;
        }

#if !REMOVE_PDF_PLUGIN
        /// <summary>
        /// Converts <see cref="PdfCompression"/> enum to <see cref="PdfImageCompression"/> enum.
        /// </summary>
        private PdfImageCompression ConvertToPdfImageCompression(PdfCompression compression)
        {
            switch (compression)
            {
                case PdfCompression.CcittFax:
                    return PdfImageCompression.CcittFax;

                case PdfCompression.Jbig2:
                    return PdfImageCompression.Jbig2;

                case PdfCompression.Jpeg:
                    return PdfImageCompression.Jpeg;

                case PdfCompression.Jpeg2000:
                    return PdfImageCompression.Jpeg2000;

                case PdfCompression.Lzw:
                    return PdfImageCompression.Lzw;

                case PdfCompression.None:
                    return PdfImageCompression.None;

                case PdfCompression.Zip:
                    return PdfImageCompression.Zip;

                case PdfCompression.Zip | PdfCompression.Jpeg:
                    return PdfImageCompression.Zip | PdfImageCompression.Jpeg;
            }
            return PdfImageCompression.Auto;
        }

        /// <summary>
        /// Converts <see cref="PdfImageCompression"/> enum to <see cref="PdfCompression"/> enum.
        /// </summary>
        private PdfCompression ConvertToPdfCompression(PdfImageCompression compression)
        {
            switch (compression)
            {
                case PdfImageCompression.CcittFax:
                    return PdfCompression.CcittFax;

                case PdfImageCompression.Jbig2:
                    return PdfCompression.Jbig2;

                case PdfImageCompression.Jpeg:
                    return PdfCompression.Jpeg;

                case PdfImageCompression.Jpeg2000:
                    return PdfCompression.Jpeg2000;

                case PdfImageCompression.Lzw:
                    return PdfCompression.Lzw;

                case PdfImageCompression.None:
                    return PdfCompression.None;

                case PdfImageCompression.Zip:
                    return PdfCompression.Zip;

                case PdfImageCompression.Jpeg | PdfImageCompression.Zip:
                    return PdfCompression.Jpeg | PdfCompression.Zip;
            }
            return PdfCompression.Auto;
        }
#endif

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI_Handler(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Handler of the mouse move event.
        /// </summary>
        private void annotationsTabPage_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = annotationsTabPage.GetChildAtPoint(e.Location);
            if (control == annotationsPdfAppearanceCheckBox)
            {
                _annotationPdfIsNotFoundToolTip.Show("Vintasoft.Imaging.Annotation.Pdf.dll assembly is not found.", annotationsTabPage, e.X, e.Y);
            }
            else
            {
                _annotationPdfIsNotFoundToolTip.Hide(annotationsTabPage);
            }
        }

        #endregion

        #endregion

    }
}
