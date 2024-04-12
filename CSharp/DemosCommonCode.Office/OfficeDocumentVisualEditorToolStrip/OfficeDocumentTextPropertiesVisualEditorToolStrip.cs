#if REMOVE_OFFICE_PLUGIN
#error Remove OfficeDocumentTextPropertiesVisualEditorToolStrip from the project.
#endif

using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

namespace DemosCommonCode.Office
{
    /// <summary>
    /// A toolstrip that allows to edit text properties of Office document using <see cref="OfficeDocumentVisualEditor"/>.
    /// </summary>
    public partial class OfficeDocumentTextPropertiesVisualEditorToolStrip : ToolStrip
    {

        #region Fields

        /// <summary>
        /// A value indicating whether UI is updating.
        /// </summary>
        bool _isUiUpdating = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfficeDocumentTextPropertiesVisualEditorToolStrip"/> class.
        /// </summary>
        public OfficeDocumentTextPropertiesVisualEditorToolStrip()
            : base()
        {
            InitializeComponent();

            changeBoldButton.Click += ChangeBoldButton_Click;
            changeItalicButton.Click += ChangeItalicButton_Click;
            changeUnderlineButton.Click += ChangeUnderlineButton_Click;
            decreaseTextSizeButton.Click += DecreaseTextSizeButton_Click;
            increaseTextSizeButton.Click += IncraseTextSizeButton_Click;
            changeStrikeoutButton.Click += ChangeStrikeoutStripButton_Click;
            changeSubscriptButton.Click += ChangeSubscriptButton_Click;
            changeSuperscriptButton.Click += ChangeSuperscriptButton_Click;
            textPropertiesButton.Click += TextPropertiesButton_Click;

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
                        _visualEditor.EditingEnabled -= _visualEditor_EditingEnabled;
                        _visualEditor.EditingDisabled -= _visualEditor_EditingDisabled;
                        _visualEditor.DocumentChanged -= _visualEditor_DocumentChanged;
                    }

                    _visualEditor = value;

                    if (_visualEditor != null)
                    {
                        _visualEditor.EditingEnabled += _visualEditor_EditingEnabled;
                        _visualEditor.EditingDisabled += _visualEditor_EditingDisabled;
                        _visualEditor.DocumentChanged += _visualEditor_DocumentChanged;
                    }
                }
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Adds visual tool that uses the Office document visual editor.
        /// </summary>
        public void AddVisualTool(UserInteractionVisualTool visualTool)
        {
            visualTool.ActiveInteractionControllerChanged += VisualTool_ActiveInteractionControllerChanged;
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of TextPropertiesButton object.
        /// </summary>
        private void TextPropertiesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // if visual editor has focused text 
                OpenXmlTextProperties textProperties = VisualEditor.GetTextProperties();
                if (textProperties != null)
                {
                    // show text properties form
                    OpenXmlTextPropertiesForm textPropertiesForm = new OpenXmlTextPropertiesForm(VisualEditor.GetFontNames());
                    textPropertiesForm.TextProperties = textProperties;
                    if (textPropertiesForm.ShowDialog() == DialogResult.OK)
                    {
                        // set text properties
                        textProperties = textPropertiesForm.GetChangedTextProperties();
                        if (textProperties != null)
                            VisualEditor.SetTextProperties(textProperties);
                    }
                    // set focus to the parent form
                    Parent.FindForm().Owner.Focus();
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of ChangeSuperscriptButton object.
        /// </summary>
        private void ChangeSuperscriptButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.ChangeFocusedTextSuperscript.Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of ChangeSubscriptButton object.
        /// </summary>
        private void ChangeSubscriptButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.ChangeFocusedTextSubscript.Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of ChangeStrikeoutStripButton object.
        /// </summary>
        private void ChangeStrikeoutStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.ChangeFocusedTextStrikeout.Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of IncraseTextSizeButton object.
        /// </summary>
        private void IncraseTextSizeButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.CreateChangeTextSize(1).Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of DecreaseTextSizeButton object.
        /// </summary>
        private void DecreaseTextSizeButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.CreateChangeTextSize(-1).Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of ChangeUnderlineButton object.
        /// </summary>
        private void ChangeUnderlineButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.CreateChangeTextUnderlineUIAction(OpenXmlTextUnderlineType.Single).Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of ChangeItalicButton object.
        /// </summary>
        private void ChangeItalicButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.ChangeFocusedTextItalic.Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of ChangeBoldButton object.
        /// </summary>
        private void ChangeBoldButton_Click(object sender, EventArgs e)
        {
            try
            {
                VisualEditor.Actions.ChangeFocusedTextBold.Execute();
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
        /// Handles the EditingDisabled event of _visualEditor object.
        /// </summary>
        private void _visualEditor_EditingDisabled(object sender, EventArgs e)
        {
            OnEditingDisabled();
        }

        /// <summary>
        /// Handles the EditingEnabled event of _visualEditor object.
        /// </summary>
        private void _visualEditor_EditingEnabled(object sender, EventArgs e)
        {
            OnEditingEnabled();
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

            OpenXmlTextProperties textProperties = null;
            if (symbol != null)
                textProperties = VisualEditor.GetTextProperties(symbol);
            UpdateTextPropertiesUI(textProperties);

            _isUiUpdating = false;
        }

        /// <summary>
        /// Updates the UI for specified text properties.
        /// </summary>
        /// <param name="textProperties">The text properties.</param>
        private void UpdateTextPropertiesUI(OpenXmlTextProperties textProperties)
        {
            OpenXmlTextProperties properties = textProperties ?? new OpenXmlTextProperties();
            changeBoldButton.Checked = properties.IsBold ?? false;
            changeItalicButton.Checked = properties.IsItalic ?? false;
            changeUnderlineButton.Checked = properties.IsUnderline ?? false;
            changeStrikeoutButton.Checked = properties.IsStrike ?? false;
            if (properties.VerticalAlignment.HasValue)
            {
                changeSubscriptButton.Checked = properties.VerticalAlignment.Value == OpenXmlTextVerticalPositionType.Subscript;
                changeSuperscriptButton.Checked = properties.VerticalAlignment.Value == OpenXmlTextVerticalPositionType.Superscript;
            }
            else
            {
                changeSubscriptButton.Checked = false;
                changeSuperscriptButton.Checked = false;
            }
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
