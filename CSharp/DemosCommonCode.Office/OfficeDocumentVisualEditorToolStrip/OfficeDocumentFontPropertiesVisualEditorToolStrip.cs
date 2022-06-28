#if REMOVE_OFFICE_PLUGIN
#error Remove OfficeDocumentFontPropertiesVisualEditorToolStrip from the project.
#endif

using System;
using System.Globalization;
using System.Windows.Forms;

using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

namespace DemosCommonCode.Office
{
    /// <summary>
    /// A toolstrip that allows to edit font properties of Office document using <see cref="OfficeDocumentVisualEditor"/>.
    /// </summary>
    public partial class OfficeDocumentFontPropertiesVisualEditorToolStrip : ToolStrip
    {

        #region Fields

        /// <summary>
        /// A value indicating whether UI is updating.
        /// </summary>
        bool _isUiUpdating = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfficeDocumentFontPropertiesVisualEditorToolStrip"/> class.
        /// </summary>
        public OfficeDocumentFontPropertiesVisualEditorToolStrip()
            :base()
        {
            InitializeComponent();

            fontNameComboBox.SelectedIndexChanged += FontNameComboBox_SelectedIndexChanged;
            fontSizeComboBox.TextChanged += FontSizeComboBox_TextChanged;

            OnEditingDisabled();
        }

        #endregion



        #region Properties

        OfficeDocumentVisualEditor _visualEditor;
        /// <summary>
        /// Gets or sets the Office document visual editor.
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
        /// Handles the SelectedIndexChanged event of FontNameComboBox object.
        /// </summary>
        private void FontNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isUiUpdating)
            {
                // create text properties
                OpenXmlTextProperties textProperties = new OpenXmlTextProperties();
                textProperties.FontName = fontNameComboBox.Text;

                // set text properties for text
                VisualEditor.Actions.CreateSetTextProperties(textProperties).Execute();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of FontSizeComboBox object.
        /// </summary>
        private void FontSizeComboBox_TextChanged(object sender, EventArgs e)
        {
            if (!_isUiUpdating)
            {
                try
                {
                    float value;
                    if (float.TryParse(fontSizeComboBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                    {
                        // create text properties
                        OpenXmlTextProperties textProperties = new OpenXmlTextProperties();
                        textProperties.FontSize = value;

                        // set text properties for text
                        VisualEditor.Actions.CreateSetTextProperties(textProperties).Execute();
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
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
        /// Handles the EditingEnabled event of VisualEditor object.
        /// </summary>
        private void _visualEditor_EditingEnabled(object sender, EventArgs e)
        {
            OnEditingEnabled();
        }

        /// <summary>
        /// Handles the EditingDisabled event of VisualEditor object.
        /// </summary>
        private void _visualEditor_EditingDisabled(object sender, EventArgs e)
        {
            OnEditingDisabled();
        }

        /// <summary>
        /// Handles the DocumentChanged event of VisualEditor object.
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
            if (properties.FontName != null)
            {
                SetFontName(properties.FontName);
            }
            else
            {
                fontNameComboBox.Text = "";
            }
            fontSizeComboBox.Text = properties.FontSize.HasValue ? properties.FontSize.ToString() : "";
        }

        /// <summary>
        /// Sets the name of the font.
        /// </summary>
        /// <param name="fontName">Name of the font.</param>
        private void SetFontName(string fontName)
        {
            for (int i = 0; i < fontNameComboBox.Items.Count; i++)
            {
                // if fontNameComboBox contains fontName
                if ((string)fontNameComboBox.Items[i] == fontName)
                {
                    // select font name in fontNameComboBox
                    fontNameComboBox.SelectedIndex = i;
                    return;
                }
            }

            // add font name to current fonts list
            string[] names = new string[fontNameComboBox.Items.Count + 1];
            names[0] = fontName;
            for (int i = 0; i < fontNameComboBox.Items.Count; i++)
            {
                names[i + 1] = (string)fontNameComboBox.Items[i];
            }

            // sort font names
            Array.Sort(names);

            // update fontNameComboBox
            fontNameComboBox.Items.Clear();
            fontNameComboBox.Items.AddRange(names);
            fontNameComboBox.Text = fontName;
        }

        /// <summary>
        /// Called when editing is enabled.
        /// </summary>
        private void OnEditingEnabled()
        {
            fontNameComboBox.Items.Clear();
            fontNameComboBox.Items.AddRange(VisualEditor.GetFontNames());

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
