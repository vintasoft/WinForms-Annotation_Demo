#if REMOVE_OFFICE_PLUGIN
#error Remove SetOpenXmlParagraphNumerationForm from the project.
#endif

using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Docx;
using Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction;

namespace DemosCommonCode.Office
{
    /// <summary>
    /// A form that allows to set numbering of focused paragraph(s).
    /// </summary>
    public partial class SetOpenXmlParagraphNumerationForm : Form
    {

        #region Fields

        /// <summary>
        /// The visual editor for Office document.
        /// </summary>
        OfficeDocumentVisualEditor _documentVisualEditor;

        /// <summary>
        /// The DOCX document editor.
        /// </summary>
        DocxDocumentEditor _documentEditor;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SetOpenXmlParagraphNumerationForm"/> class.
        /// </summary>
        public SetOpenXmlParagraphNumerationForm()
        {
            InitializeComponent();

            externalNumerationsComboBox.Items.Add("SimpleList");
            externalNumerationsComboBox.Items.Add("NumberedList");
            externalNumerationsComboBox.Items.Add("CheckList");
            externalNumerationsComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetOpenXmlParagraphNumerationForm"/> class.
        /// </summary>
        /// <param name="documentVisualEditor">The Office document visual editor.</param>
        public SetOpenXmlParagraphNumerationForm(OfficeDocumentVisualEditor documentVisualEditor)
            : this()
        {
            _documentVisualEditor = documentVisualEditor;
            _documentEditor = documentVisualEditor.CreateDocumentEditor();
            UpdateUI();
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Closing" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event data.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (_documentEditor != null)
            {
                _documentEditor.Dispose();
                _documentEditor = null;
            }
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of importButton object.
        /// </summary>
        private void importButton_Click(object sender, EventArgs e)
        {
            using (Stream numberingTemplateStream = DemosResourcesManager.GetResourceAsStream(externalNumerationsComboBox.Text + ".docx"))
            {
                using (DocxDocumentEditor numberingTemplateDocumentEditor = new DocxDocumentEditor(numberingTemplateStream))
                {
                    DocxDocumentNumbering importedNumbering = _documentEditor.Numbering.Import(
                        numberingTemplateDocumentEditor,
                        numberingTemplateDocumentEditor.Numbering.Items[0]);

                    numerationDefinitionsListBox.Items.Add(importedNumbering);
                    numerationDefinitionsListBox.SelectedItem = importedNumbering;
                }
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
        /// Handles the SelectedIndexChanged event of numerationDefinitionsListBox object.
        /// </summary>
        private void numerationDefinitionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = numerationDefinitionsListBox.SelectedItem != null;
            restartButton.Enabled = numerationDefinitionsListBox.SelectedItem != null;
        }

        /// <summary>
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (numerationDefinitionsListBox.SelectedItem != null)
            {
                OpenXmlDocumentNumbering numbering = (OpenXmlDocumentNumbering)numerationDefinitionsListBox.SelectedItem;
                if (_documentVisualEditor.SetParagraphNumeration(_documentEditor, numbering, 0))
                {
                    _documentEditor.Dispose();
                    _documentEditor = null;
                    _documentVisualEditor.OnDocumentChanged();
                }
            }
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of restartButton object.
        /// </summary>
        private void restartButton_Click(object sender, EventArgs e)
        {
            if (numerationDefinitionsListBox.SelectedItem != null)
            {
                DocxDocumentNumbering numbering = (DocxDocumentNumbering)numerationDefinitionsListBox.SelectedItem;
                numbering = _documentEditor.Numbering.CreateCopy(numbering);

                numerationDefinitionsListBox.Items.Add(numbering);
                numerationDefinitionsListBox.SelectedItem = numbering;
            }
        }

        #endregion


        /// <summary>
        /// Updates the User Interface.
        /// </summary>
        private void UpdateUI()
        {
            numerationDefinitionsListBox.Items.Clear();
            if (_documentEditor.Numbering.Items != null)
            {
                foreach (DocxDocumentNumbering numbering in _documentEditor.Numbering.Items)
                {
                    numerationDefinitionsListBox.Items.Add(numbering);
                }
                OpenXmlParagraphProperties paragraphProperties = _documentVisualEditor.GetParagraphProperties();
                if (paragraphProperties.Numeration != null)
                {
                    numerationDefinitionsListBox.SelectedItem = paragraphProperties.Numeration;
                }
            }
        }

        #endregion

        #endregion

    }
}
