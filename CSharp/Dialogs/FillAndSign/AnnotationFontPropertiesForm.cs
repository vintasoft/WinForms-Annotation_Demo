using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.Annotation;

namespace AnnotationDemo
{
    /// <summary>
    /// A form that allows to change the font properties of text annotation.
    /// </summary>
    public partial class AnnotationFontPropertiesForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnotationFontPropertiesForm"/> class.
        /// </summary>
        /// <param name="font">The annotation font.</param>
        /// <param name="fontColor">The annotation font color.</param>
        public AnnotationFontPropertiesForm(AnnotationFont font, Color fontColor)
        {
            InitializeComponent();

            _annotationFont = font;
            _annotationFontColor = fontColor;

            fontFamilyNameComboBox.BeginUpdate();
            foreach (FontFamily fontFamily in FontFamily.Families)
                fontFamilyNameComboBox.Items.Add(fontFamily.Name);
            fontFamilyNameComboBox.SelectedItem = font.FamilyName;
            fontFamilyNameComboBox.EndUpdate();

            fontSizeNumericUpDown.Value = (decimal)font.Size;
            fontColorPanelControl.Color = fontColor;
            isBoldCheckBox.Checked = font.Bold;
            isItalicCheckBox.Checked = font.Italic;
            isStrikeoutCheckBox.Checked = font.Strikeout;
            isUnderlineCheckBox.Checked = font.Underline;
        }

        #endregion



        #region Properties

        AnnotationFont _annotationFont;
        /// <summary>
        /// Gets the annotation font.
        /// </summary>
        public AnnotationFont AnnotationFont
        {
            get
            {
                return _annotationFont;
            }
        }

        Color _annotationFontColor;
        /// <summary>
        /// Gets the annotation font color.
        /// </summary>
        public Color AnnotationFontColor
        {
            get
            {
                return _annotationFontColor;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            _annotationFont = new AnnotationFont(
                (string)fontFamilyNameComboBox.SelectedItem,
                (float)fontSizeNumericUpDown.Value,
                isBoldCheckBox.Checked,
                isItalicCheckBox.Checked,
                isStrikeoutCheckBox.Checked,
                isUnderlineCheckBox.Checked,
                _annotationFont.Unit);

            _annotationFontColor = fontColorPanelControl.Color;
        }

        #endregion

    }
}
