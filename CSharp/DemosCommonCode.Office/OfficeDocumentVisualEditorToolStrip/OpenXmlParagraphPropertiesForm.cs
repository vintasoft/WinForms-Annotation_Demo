#if REMOVE_OFFICE_PLUGIN
#error Remove OpenXmlParagraphPropertiesForm from the project.
#endif

using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Office.OpenXml.Editor;

namespace DemosCommonCode.Office
{
    /// <summary>
    /// A form that allows to view and edit the paragraph properties.
    /// </summary>
    public partial class OpenXmlParagraphPropertiesForm : Form
    {

        #region Fields

        /// <summary>
        /// The initial paragraph properties.
        /// </summary>
        OpenXmlParagraphProperties _intalParagraphProperties;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenXmlParagraphPropertiesForm"/> class.
        /// </summary>
        public OpenXmlParagraphPropertiesForm()
        {
            InitializeComponent();

            textJustificationComboBox.Items.Add(OpenXmlParagraphJustification.Left);
            textJustificationComboBox.Items.Add(OpenXmlParagraphJustification.Center);
            textJustificationComboBox.Items.Add(OpenXmlParagraphJustification.Right);
            textJustificationComboBox.Items.Add(OpenXmlParagraphJustification.Both);
        }

        #endregion



        #region Properties

        OpenXmlParagraphProperties _paragraphProperties;
        /// <summary>
        /// Gets or sets the paragraph properties.
        /// </summary>
        public OpenXmlParagraphProperties ParagraphProperties
        {
            get
            {
                return _paragraphProperties;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _paragraphProperties = value;
                _intalParagraphProperties = value.Clone();
                
                UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Returns the paragraph properties, which contain changed properties.
        /// </summary>
        /// <returns>The paragraph properties, which contain changed properties.</returns>
        public OpenXmlParagraphProperties GetChangedParagraphProperties()
        {
            OpenXmlParagraphProperties result = OpenXmlParagraphProperties.GetChanges(_intalParagraphProperties, _paragraphProperties);
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
            if (UpdateParagraphProperties())
                DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of ButtonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion


        /// <summary>
        /// Updates the UI from <see cref="ParagraphProperties"/>.
        /// </summary>
        private void UpdateUI()
        {
            textJustificationComboBox.SelectedItem = _paragraphProperties.Justification;

            fillColorPanel.Color = _paragraphProperties.FillColor.Value;

            firstLineIndentationComboBox.Text = DemosTools.ToString(_paragraphProperties.FirstLineIndentation);

            leftIndentationComboBox.Text = DemosTools.ToString(_paragraphProperties.LeftIndentation);

            rightIndentationComboBox.Text = DemosTools.ToString(_paragraphProperties.RightIndentation);

            lineHeightComboBox.Text = DemosTools.ToString(_paragraphProperties.LineHeightFactor);

            spacingBeforeComboBox.Text = DemosTools.ToString(_paragraphProperties.SpacingBeforeParagraph);

            spacingAfterComboBox.Text = DemosTools.ToString(_paragraphProperties.SpacingAfterParagraph);

            keepLinesCheckBox.Checked = _paragraphProperties.KeepLines.Value;

            keepNextCheckBox.Checked = _paragraphProperties.KeepNext.Value;

            pageBreakBeforeCheckBox.Checked = _paragraphProperties.PageBreakBefore.Value;

            widowControlCheckBox.Checked = _paragraphProperties.WidowControl.Value;
        }

        /// <summary>
        /// Updates the <see cref="ParagraphProperties"/> from UI.
        /// </summary>
        private bool UpdateParagraphProperties()
        {
            _paragraphProperties.Justification = (OpenXmlParagraphJustification)textJustificationComboBox.SelectedItem;

            _paragraphProperties.FillColor = fillColorPanel.Color;

            float value;

            if (!DemosTools.ParseFloat(firstLineIndentationComboBox.Text, "First Line Indentation", out value))
                return false;
            _paragraphProperties.FirstLineIndentation = value;

            if (!DemosTools.ParseFloat(leftIndentationComboBox.Text, "Left Indentation", out value))
                return false;
            _paragraphProperties.LeftIndentation = value;

            if (!DemosTools.ParseFloat(rightIndentationComboBox.Text, "Right Indentation", out value))
                return false;
            _paragraphProperties.RightIndentation = value;

            if (!DemosTools.ParseFloat(lineHeightComboBox.Text, "Line Height Factor", out value))
                return false;
            _paragraphProperties.LineHeightFactor = value;

            if (!DemosTools.ParseFloat(spacingBeforeComboBox.Text, "Spacing Before Paragraph", out value))
                return false;
            _paragraphProperties.SpacingBeforeParagraph = value;

            if (!DemosTools.ParseFloat(spacingAfterComboBox.Text, "Spacing After Paragraph", out value))
                return false;
            _paragraphProperties.SpacingAfterParagraph = value;

            _paragraphProperties.KeepLines = keepLinesCheckBox.Checked;

            _paragraphProperties.KeepNext = keepNextCheckBox.Checked;

            _paragraphProperties.PageBreakBefore = pageBreakBeforeCheckBox.Checked;

            _paragraphProperties.WidowControl = widowControlCheckBox.Checked;

            return true;
        }

        #endregion

        #endregion

    }
}
