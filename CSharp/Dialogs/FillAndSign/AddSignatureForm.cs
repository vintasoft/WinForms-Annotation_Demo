using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.UI;

using DemosCommonCode;
using DemosCommonCode.Imaging;


namespace AnnotationDemo
{
    /// <summary>
    /// A form that allows to create the annotation template, which represents signature, initials or title.
    /// </summary>
    public partial class AddSignatureForm : Form
    {

        #region Fields

        /// <summary>
        /// The build manager for annotation templates.
        /// </summary>
        AnnotationTemplateBuildManager _buildManager = null;

        /// <summary>
        /// The template category.
        /// </summary>
        string _category;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AddSignatureForm"/> class.
        /// </summary>
        /// <param name="templateManager">The annotation template manager.</param>
        /// <param name="category">The template category.</param>
        public AddSignatureForm(AnnotationTemplateManager templateManager, string category)
        {
            InitializeComponent();

            _category = category;

            Text = string.Format("Create {0} Template", category);

            // set the filter for open file dialog
            DemosCommonCode.Imaging.Codecs.CodecsFileFilters.SetOpenFileDialogFilter(openFileDialog1);

            // create the build manager for annotation templates
            _buildManager = new AnnotationTemplateBuildManager(annotationViewer1, templateManager);

            // init name comboBox
            foreach (AnnotationData annotationData in templateManager.ToArray())
            {
                if (!string.IsNullOrEmpty(annotationData.Name))
                    nameComboBox.Items.Add(annotationData.Name);
            }

            nameComboBox.Text = Environment.UserName;

            annotationViewer1.AnnotationDataCollection.Changed += AnnotationDataCollection_Changed;
            annotationViewer1.FocusedAnnotationViewChanged += AnnotationViewer1_FocusedAnnotationViewChanged;

            UpdateUI();
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Raises the <see cref="E:Closed" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            if (_buildManager != null)
            {
                _buildManager.Dispose();
                _buildManager = null;
            }

            base.OnClosed(e);
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of FreehandToolStripButton object.
        /// </summary>
        private void freehandToolStripButton_Click(object sender, EventArgs e)
        {
            _buildManager.BuildSignature();
        }

        /// <summary>
        /// Handles the Click event of TextToolStripButton object.
        /// </summary>
        private void textToolStripButton_Click(object sender, EventArgs e)
        {
            _buildManager.AddText("Test");
        }

        /// <summary>
        /// Handles the Click event of StampToolStripButton object.
        /// </summary>
        private void stampToolStripButton_Click(object sender, EventArgs e)
        {
            _buildManager.AddStamp("APPROVED", System.Drawing.Color.Green);
        }

        /// <summary>
        /// Handles the Click event of ImageToolStripButton object.
        /// </summary>
        private void imageToolStripButton_Click(object sender, EventArgs e)
        {
            _buildManager.CancelAnnotationBuilding();

            // if image file is selected
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _buildManager.AddImage(openFileDialog1.FileName);
                }
                catch (Exception exc)
                {
                    DemosTools.ShowErrorMessage(exc);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of FontToolStripButton object.
        /// </summary>
        private void fontToolStripButton_Click(object sender, EventArgs e)
        {
            TextAnnotationData textAnnotation = (TextAnnotationData)annotationViewer1.FocusedAnnotationData;
            AnnotationSolidBrush solidBrush = (AnnotationSolidBrush)textAnnotation.FontBrush;

            using (AnnotationFontPropertiesForm form = new AnnotationFontPropertiesForm(textAnnotation.Font, solidBrush.Color))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.Owner = this;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    textAnnotation.Font = form.AnnotationFont;
                    textAnnotation.FontBrush = new AnnotationSolidBrush(form.AnnotationFontColor);
                    textAnnotation.Outline.Color = form.AnnotationFontColor;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of ClearToolStripButton object.
        /// </summary>
        private void clearToolStripButton_Click(object sender, EventArgs e)
        {
            _buildManager.Clear();
        }

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            AnnotationData data = _buildManager.AddTemplateAnnotationToTemplateManager();
            if (data != null)
            {
                data.Intent = _category;
                data.Name = nameComboBox.Text;
            }
        }


        #region Annotation Viewer

        /// <summary>
        /// Handles the Changed event of AnnotationDataCollection object.
        /// </summary>
        private void AnnotationDataCollection_Changed(object sender, CollectionChangeEventArgs<AnnotationData> e)
        {
            if (e.Action == CollectionChangeActionType.InsertItem ||
                e.Action == CollectionChangeActionType.ClearAndAddItems ||
                e.Action == CollectionChangeActionType.SetItem)
            {
                AnnotationView view = annotationViewer1.AnnotationViewCollection.FindView(e.NewValue);

                view.ContextMenuStrip = contextMenuStrip1;
            }

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of PropertiesToolStripMenuItem object.
        /// </summary>
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PropertyGridForm form = new PropertyGridForm(annotationViewer1.FocusedAnnotationData, "Annotation Properties", false))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.Owner = this;

                form.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the FocusedAnnotationViewChanged event of AnnotationViewer1 object.
        /// </summary>
        private void AnnotationViewer1_FocusedAnnotationViewChanged(object sender, AnnotationViewChangedEventArgs e)
        {
            UpdateUI();
        }

        #endregion

        #endregion


        #region UI State

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            bool hasAnnotations =
                annotationViewer1.AnnotationDataCollection != null &&
                annotationViewer1.AnnotationDataCollection.Count != 0;
            bool isTextAnnotationSelected = annotationViewer1.FocusedAnnotationData is TextAnnotationData;

            buttonOk.Enabled = hasAnnotations;
            fontToolStripButton.Enabled = isTextAnnotationSelected;
        }

        #endregion

        #endregion

        #endregion

    }
}
