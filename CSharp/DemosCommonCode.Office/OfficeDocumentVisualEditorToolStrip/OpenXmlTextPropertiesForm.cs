#if REMOVE_OFFICE_PLUGIN
#error Remove OpenXmlTextPropertiesForm from the project.
#endif

using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Office.OpenXml.Editor;

namespace DemosCommonCode.Office
{
    /// <summary>
    /// A form that allows to view and edit the text properties.
    /// </summary>
    public partial class OpenXmlTextPropertiesForm : Form
    {

        #region Fields

        /// <summary>
        /// The initial text properties.
        /// </summary>
        OpenXmlTextProperties _intalTextProperties;

        /// <summary>
        /// The font names.
        /// </summary>
        string[] _fontNames;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenXmlTextPropertiesForm"/> class.
        /// </summary>
        public OpenXmlTextPropertiesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenXmlTextPropertiesForm"/> class.
        /// </summary>
        /// <param name="fontNames">The font names.</param>
        public OpenXmlTextPropertiesForm(string[] fontNames)
            : this()
        {
            fontListBox.Items.AddRange(fontNames);
            _fontNames = fontNames;

            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.None);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.Single);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.Double);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.Dotted);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.DottedHeavy);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.Dash);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.DashDotHeavy);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.DashDotDotHeavy);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.DashedHeavy);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.DashLong);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.DashLongHeavy);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.DotDash);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.DotDotDash);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.Wave);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.WavyDouble);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.WavyHeavy);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.Words);
            underlineComboBox.Items.Add(OpenXmlTextUnderlineType.Thick);

            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.None);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.Black);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.Blue);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.Cyan);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.DarkBlue);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.DarkCyan);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.DarkGray);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.DarkGreen);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.DarkMagenta);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.DarkRed);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.DarkYellow);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.Green);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.LightGray);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.Magenta);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.Red);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.White);
            textHighlightComboBox.Items.Add(OpenXmlTextHighlightType.Yellow);
        }

        #endregion



        #region Properties

        OpenXmlTextProperties _textProperties;
        /// <summary>
        /// Gets or sets the text properties.
        /// </summary>
        public OpenXmlTextProperties TextProperties
        {
            get
            {
                return _textProperties;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _textProperties = value;
                _intalTextProperties = value.Clone();

                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Returns the text properties, which contain changed properties.
        /// </summary>
        /// <returns>The text properties, which contain changed properties.</returns>
        public OpenXmlTextProperties GetChangedTextProperties()
        {
            OpenXmlTextProperties result = OpenXmlTextProperties.GetChanges(_intalTextProperties, _textProperties);
            if (result.IsEmpty)
                return null;
            return result;
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of ButtonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (UpdateTextProperties())
                DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of ButtonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the CheckedChanged event of SubscriptCheckBox object.
        /// </summary>
        private void subscriptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (subscriptCheckBox.Checked)
                superscriptCheckBox.Checked = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of SuperscriptCheckBox object.
        /// </summary>
        private void superscriptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (superscriptCheckBox.Checked)
                subscriptCheckBox.Checked = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of StrikeoutCheckBox object.
        /// </summary>
        private void strikeoutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (strikeoutCheckBox.Checked)
                doubleStrikeoutcheckBox.Checked = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of DoubleStrikeoutcheckBox object.
        /// </summary>
        private void doubleStrikeoutcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (doubleStrikeoutcheckBox.Checked)
                strikeoutCheckBox.Checked = false;
        }

        #endregion


        /// <summary>
        /// Updates the User Interface from <see cref="TextProperties"/>.
        /// </summary>
        private void UpdateUI()
        {
            if (_textProperties.FontName != null)
                if (Array.IndexOf(_fontNames, _textProperties.FontName) < 0)
                    fontListBox.Items.Insert(0, _textProperties.FontName);
            fontListBox.SelectedItem = _textProperties.FontName;

            fontSizeComboBox.Text = DemosTools.ToString(_textProperties.FontSize);

            if (_textProperties.IsBold.Value && _textProperties.IsItalic.Value)
                fontStyleListBox.SelectedIndex = 3;
            else if (_textProperties.IsItalic.Value)
                fontStyleListBox.SelectedIndex = 2;
            else if (_textProperties.IsBold.Value)
                fontStyleListBox.SelectedIndex = 1;
            else
                fontStyleListBox.SelectedIndex = 0;

            if (_textProperties.VerticalAlignment == OpenXmlTextVerticalPositionType.Subscript)
                subscriptCheckBox.Checked = true;
            else if (_textProperties.VerticalAlignment == OpenXmlTextVerticalPositionType.Superscript)
                superscriptCheckBox.Checked = true;

            if (_textProperties.IsStrike.Value)
                strikeoutCheckBox.Checked = true;
            else if (_textProperties.IsDoubleStrike.Value)
                doubleStrikeoutcheckBox.Checked = true;

            fontColorPanel.Color = _textProperties.Color.Value;

            underlineComboBox.SelectedItem = _textProperties.Underline;

            underlineColorPanel.Color = _textProperties.UnderlineColor.Value;

            textHighlightComboBox.SelectedItem = _textProperties.Highlight;

            horizontalScaleComboBox.Text = DemosTools.ToString(_textProperties.CharacterHorizontalScaling);

            characterSpacingComboBox.Text = DemosTools.ToString(_textProperties.CharacterSpacing);
        }

        /// <summary>
        /// Updates the <see cref="TextProperties"/> from UI.
        /// </summary>
        private bool UpdateTextProperties()
        {
            try
            {
                _textProperties.FontName = (string)fontListBox.SelectedItem;

                float fontSize;
                if (!DemosTools.ParseFloat(fontSizeComboBox.Text, "FontSize", out fontSize))
                    return false;
                _textProperties.FontSize = fontSize;

                switch (fontStyleListBox.SelectedIndex)
                {
                    case 3:
                        _textProperties.IsBold = true;
                        _textProperties.IsItalic = true;
                        break;
                    case 2:
                        _textProperties.IsBold = false;
                        _textProperties.IsItalic = true;
                        break;
                    case 1:
                        _textProperties.IsBold = true;
                        _textProperties.IsItalic = false;
                        break;
                    case 0:
                        _textProperties.IsBold = false;
                        _textProperties.IsItalic = false;
                        break;
                }

                if (subscriptCheckBox.Checked)
                    _textProperties.VerticalAlignment = OpenXmlTextVerticalPositionType.Subscript;
                else if (superscriptCheckBox.Checked)
                    _textProperties.VerticalAlignment = OpenXmlTextVerticalPositionType.Superscript;
                else
                    _textProperties.VerticalAlignment = OpenXmlTextVerticalPositionType.Baseline;

                _textProperties.IsStrike = strikeoutCheckBox.Checked;

                _textProperties.IsDoubleStrike = doubleStrikeoutcheckBox.Checked;

                _textProperties.Color = fontColorPanel.Color;

                _textProperties.Underline = (OpenXmlTextUnderlineType)underlineComboBox.SelectedItem;

                _textProperties.UnderlineColor = underlineColorPanel.Color;

                _textProperties.Highlight = (OpenXmlTextHighlightType)textHighlightComboBox.SelectedItem;

                float characterHorizontalScaling;
                if (!DemosTools.ParseFloat(horizontalScaleComboBox.Text, "Character Horizontal Scaling", out characterHorizontalScaling))
                    return false;
                _textProperties.CharacterHorizontalScaling = characterHorizontalScaling;

                float characterSpacing;
                if (!DemosTools.ParseFloat(characterSpacingComboBox.Text, "Character Spacing", out characterSpacing))
                    return false;
                _textProperties.CharacterSpacing = characterSpacing;

                return true;
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
                return false;
            }
        }

        #endregion

        #endregion

    }
}
