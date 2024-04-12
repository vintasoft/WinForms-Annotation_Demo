#if REMOVE_OFFICE_PLUGIN
#error Remove OfficeDocumentParagraphPropertiesVisualEditorToolStrip from the project.
#endif

using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Utils;

namespace DemosCommonCode.Office
{
    /// <summary>
    /// A toolstrip that allows to edit paragraph properties of Office document using <see cref="OfficeDocumentVisualEditor"/>.
    /// </summary>
    public partial class OfficeDocumentParagraphPropertiesVisualEditorToolStrip : ToolStrip
    {

        #region Constants

        /// <summary>
        /// The paragraph indentation delta.
        /// </summary>
        static readonly float ParagraphIndentationDelta = (float)UnitOfMeasureConverter.ConvertToPoints(1, UnitOfMeasure.Centimeters);

        /// <summary>
        /// The paragraph first line indentation delta.
        /// </summary>
        static readonly float ParagraphFirstLineIndentationDelta = (float)UnitOfMeasureConverter.ConvertToPoints(0.75, UnitOfMeasure.Centimeters);

        #endregion



        #region Fields

        /// <summary>
        /// A value indicating whether UI is updating.
        /// </summary>
        bool _isUiUpdating = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfficeDocumentParagraphPropertiesVisualEditorToolStrip"/> class.
        /// </summary>
        public OfficeDocumentParagraphPropertiesVisualEditorToolStrip()
            : base()
        {
            InitializeComponent();

            paragraphJLeftButton.Click += ParagraphJLeftButton_Click;
            paragraphJCenterButton.Click += ParagraphJCenterButton_Click;
            paragraphJRightButton.Click += ParagraphJRightButton_Click;
            paragraphJBothButton.Click += ParagraphJBothButton_Click;
            incParagraphLeftIndentationButton.Click += IncParagraphLeftIndentationButton_Click;
            decParagraphLeftIndentationButton.Click += DecParagraphLeftIndentationButton_Click;
            incParagraphFirstLineIndentationButton.Click += IncParagraphFirstLineIndentationButton_Click;
            decParagraphFirstLineIndentationButton.Click += DecParagraphFirstLineIndentationButton_Click;
            paragraphPropertiesButton.Click += ParagraphPropertiesButton_Click;
            paragraphNumberingButton.Click += ParagraphNumberingButton_Click;

            OnEditingDisabled();
        }

        #endregion



        #region Properties

        OfficeDocumentVisualEditor _visualEditor;
        /// <summary>
        /// Gets or sets the visual editor for Office document.
        /// </summary>
        private OfficeDocumentVisualEditor VisualEditor
        {
            get
            {
                return _visualEditor;
            }
            set
            {
                if (_visualEditor != value)
                {
                    if (_visualEditor != null)
                    {
                        _visualEditor.EditingEnabled -= _visualEditor_EditEnabled;
                        _visualEditor.EditingDisabled -= _visualEditor_EditDisabled;
                        _visualEditor.DocumentChanged -= _visualEditor_DocumentChanged;
                    }

                    _visualEditor = value;

                    if (_visualEditor != null)
                    {
                        _visualEditor.EditingEnabled += _visualEditor_EditEnabled;
                        _visualEditor.EditingDisabled += _visualEditor_EditDisabled;
                        _visualEditor.DocumentChanged += _visualEditor_DocumentChanged;
                    }
                }
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Gets or sets the visual tool that uses the Office document visual editor.
        /// </summary>
        public void AddVisualTool(UserInteractionVisualTool visualTool)
        {
            visualTool.ActiveInteractionControllerChanged += VisualTool_ActiveInteractionControllerChanged;
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of ParagraphNumberingButton object.
        /// </summary>
        private void ParagraphNumberingButton_Click(object sender, EventArgs e)
        {
            try
            {
                // if focused paragraph has numeration
                if (paragraphNumberingButton.Checked)
                {
                    // remove numeration
                    OpenXmlParagraphProperties paragraphProperties = new OpenXmlParagraphProperties();
                    paragraphProperties.RemoveNumeration();
                    VisualEditor.SetParagraphProperties(paragraphProperties);
                }
                else
                {
                    // if visual editor has focused paragraph
                    if (VisualEditor.GetParagraphProperties() != null)
                    {
                        // set numeration properties
                        using (SetOpenXmlParagraphNumerationForm form = new SetOpenXmlParagraphNumerationForm(VisualEditor))
                        {
                            form.ShowDialog();
                        }
                        // set focus to parent form
                        Parent.FindForm().Owner.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of ParagraphPropertiesButton object.
        /// </summary>
        private void ParagraphPropertiesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // if visual editor has focused paragraph
                OpenXmlParagraphProperties paragraphProperties = VisualEditor.GetParagraphProperties();
                if (paragraphProperties != null)
                {
                    // show paragraph properties form
                    OpenXmlParagraphPropertiesForm paragraphPropertiesForm = new OpenXmlParagraphPropertiesForm();
                    paragraphPropertiesForm.ParagraphProperties = paragraphProperties;
                    if (paragraphPropertiesForm.ShowDialog() == DialogResult.OK)
                    {
                        // set paragraph properties
                        paragraphProperties = paragraphPropertiesForm.GetChangedParagraphProperties();
                        if (paragraphProperties != null)
                            VisualEditor.SetParagraphProperties(paragraphProperties);
                    }
                    // set focus to parent form
                    Parent.FindForm().Owner.Focus();
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of DecParagraphFirstLineIndentationButton object.
        /// </summary>
        private void DecParagraphFirstLineIndentationButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.CreateChangeParagraphFirstLineIndentation(-ParagraphFirstLineIndentationDelta).Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of IncParagraphFirstLineIndentationButton object.
        /// </summary>
        private void IncParagraphFirstLineIndentationButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.CreateChangeParagraphFirstLineIndentation(ParagraphFirstLineIndentationDelta).Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of DecParagraphLeftIndentationButton object.
        /// </summary>
        private void DecParagraphLeftIndentationButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.CreateChangeParagraphLeftIndentation(-ParagraphIndentationDelta).Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of IncParagraphLeftIndentationButton object.
        /// </summary>
        private void IncParagraphLeftIndentationButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.CreateChangeParagraphLeftIndentation(ParagraphIndentationDelta).Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of ParagraphJBothButton object.
        /// </summary>
        private void ParagraphJBothButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.CreateSetParagraphJustification(OpenXmlParagraphJustification.Both).Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of ParagraphJRightButton object.
        /// </summary>
        private void ParagraphJRightButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.CreateSetParagraphJustification(OpenXmlParagraphJustification.Right).Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of ParagraphJCenterButton object.
        /// </summary>
        private void ParagraphJCenterButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.CreateSetParagraphJustification(OpenXmlParagraphJustification.Center).Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of ParagraphJLeftButton object.
        /// </summary>
        private void ParagraphJLeftButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.CreateSetParagraphJustification(OpenXmlParagraphJustification.Left).Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        #endregion


        /// <summary>
        /// Handles the ActiveInteractionControllerChanged event of VisualTool object.
        /// </summary>
        private void VisualTool_ActiveInteractionControllerChanged(object sender, Vintasoft.Imaging.PropertyChangedEventArgs<IInteractionController> e)
        {
            OfficeDocumentVisualEditor visualEditor = null;
            if (e.NewValue != null)
                visualEditor = CompositeInteractionController.FindInteractionController<OfficeDocumentVisualEditor>(e.NewValue);
            VisualEditor = visualEditor;
        }

        /// <summary>
        /// Handles the EditEnabled event of _visualEditor object.
        /// </summary>
        private void _visualEditor_EditEnabled(object sender, EventArgs e)
        {
            OnEditingEnabled();
        }

        /// <summary>
        /// Handles the EditDisabled event of _visualEditor object.
        /// </summary>
        private void _visualEditor_EditDisabled(object sender, EventArgs e)
        {
            OnEditingDisabled();
        }

        /// <summary>
        /// Handles the DocumentChanged event of _visualEditor object.
        /// </summary>
        private void _visualEditor_DocumentChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Handles the FocusedTextSymbolChanged event of TextTool object.
        /// </summary>
        private void TextTool_FocusedTextSymbolChanged(object sender, Vintasoft.Imaging.PropertyChangedEventArgs<Vintasoft.Imaging.Text.TextRegionSymbol> e)
        {
            UpdateUI();
        }


        /// <summary>
        /// Updates the UI.
        /// </summary>
        private void UpdateUI()
        {
            _isUiUpdating = true;

            TextRegionSymbol symbol = VisualEditor.FocusedTextSymbol;


            OpenXmlParagraphProperties paragraphProperties = null;
            if (symbol != null)
                paragraphProperties = VisualEditor.GetParagraphProperties(symbol);
            UpdateParagraphPropertiesUI(paragraphProperties);

            _isUiUpdating = false;
        }


        /// <summary>
        /// Updates the UI for specified paragraph properties.
        /// </summary>
        /// <param name="paragraphProperties">The paragraph properties.</param>
        private void UpdateParagraphPropertiesUI(OpenXmlParagraphProperties paragraphProperties)
        {
            paragraphProperties = paragraphProperties ?? new OpenXmlParagraphProperties();
            if (paragraphProperties.Justification.HasValue)
            {
                paragraphJBothButton.Checked = paragraphProperties.Justification.Value == OpenXmlParagraphJustification.Both;
                paragraphJLeftButton.Checked = paragraphProperties.Justification.Value == OpenXmlParagraphJustification.Left;
                paragraphJRightButton.Checked = paragraphProperties.Justification.Value == OpenXmlParagraphJustification.Right;
                paragraphJCenterButton.Checked = paragraphProperties.Justification.Value == OpenXmlParagraphJustification.Center;
            }
            else
            {
                paragraphJBothButton.Checked = false;
                paragraphJLeftButton.Checked = false;
                paragraphJRightButton.Checked = false;
                paragraphJCenterButton.Checked = false;
            }
            paragraphNumberingButton.Checked = paragraphProperties.Numeration != null;
        }


        /// <summary>
        /// Called when editing is enabled.
        /// </summary>
        private void OnEditingEnabled()
        {
            VisualEditor.TextTool.FocusedTextSymbolChanged += TextTool_FocusedTextSymbolChanged;
            UpdateUI();
            Enabled = true;
        }

        /// <summary>
        /// Called when editing is disabled.
        /// </summary>
        private void OnEditingDisabled()
        {
            if (VisualEditor != null)
            {
                VisualEditor.TextTool.FocusedTextSymbolChanged -= TextTool_FocusedTextSymbolChanged;
            }
            Enabled = false;
        }

        #endregion

        #endregion

    }
}
