using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using DemosCommonCode;

using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.UI;

namespace AnnotationDemo
{
    /// <summary>
    /// A form that allows to create, view and select the signature-annotation.
    /// </summary>
    public partial class FillSignatureForm : Form
    {

        #region Fields

        /// <summary>
        /// The annotation template manager that stores the signature-annotations.
        /// </summary>
        AnnotationTemplateManager _templateManager;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FillSignatureForm"/> class.
        /// </summary>
        public FillSignatureForm()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FillSignatureForm"/> class.
        /// </summary>
        /// <param name="annotations">The annotation templates.</param>
        public FillSignatureForm(IEnumerable<AnnotationData> annotations)
        {
            InitializeComponent();

            _templateManager = new AnnotationTemplateManager(annotatedThumbnailViewer1);
            if (annotations != null)
                _templateManager.AddRange(annotations);
            _templateManager.ShowDescriptions = true;
            if (_templateManager.ShowDescriptions)
            {
                int height = annotatedThumbnailViewer1.ThumbnailCaption.Font.Height;
                _templateManager.ThumbnailPaddingSize = new System.Drawing.Size(0, (height + 1) * 2);
            }

            annotatedThumbnailViewer1.Images.ImageCollectionChanged += Images_ImageCollectionChanged;
            annotatedThumbnailViewer1.FocusedIndexChanged += AnnotationViewer1_FocusedIndexChanged;
            UpdateUI();
        }

        #endregion



        #region Properties

        AnnotationView _selectedSignatureAnnotation = null;
        /// <summary>
        /// Gets the copy of selected signature-annotation.
        /// </summary>
        public AnnotationView SelectedSignatureAnnotation
        {
            get
            {
                return _selectedSignatureAnnotation;
            }
        }

        /// <summary>
        /// Gets or sets the index of selected signature-annotation.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedSignatureAnnotationIndex
        {
            get
            {
                return _templateManager.SelectedTemplateIndex;
            }
            set
            {
                _templateManager.SelectedTemplateIndex = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Returns the signature-annotations.
        /// </summary>
        /// <returns>
        /// An array that contains copies of signature-annotations.
        /// </returns>
        public AnnotationData[] GetSignatureAnnotations()
        {
            return _templateManager.ToArray();
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the ButtonClick event of addToolStripSplitButton object.
        /// </summary>
        private void addToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            addToolStripSplitButton.ShowDropDown();
        }

        /// <summary>
        /// Handles the Click event of addSignatureToolStripMenuItem object.
        /// </summary>
        private void addSignatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddSignatureForm form = new AddSignatureForm(_templateManager, "Signature"))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.Owner = this;

                form.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of addInitialsToolStripMenuItem object.
        /// </summary>
        private void addInitialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddSignatureForm form = new AddSignatureForm(_templateManager, "Initials"))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.Owner = this;

                form.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of addTitleToolStripMenuItem object.
        /// </summary>
        private void addTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddSignatureForm form = new AddSignatureForm(_templateManager, "Title"))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.Owner = this;

                form.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of addFromFileToolStripMenuItem object.
        /// </summary>
        private void addFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _templateManager.Add(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Handles the ButtonClick event of removeToolStripSplitButton object.
        /// </summary>
        private void removeToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            _templateManager.RemoveSelected();
        }

        /// <summary>
        /// Handles the Click event of removeAllToolStripMenuItem object.
        /// </summary>
        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _templateManager.Clear();
        }

        /// <summary>
        /// Handles the Click event of saveToolStripButton object.
        /// </summary>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _templateManager.Save(saveFileDialog1.FileName);
                }
                catch(Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Handles the ImageCollectionChanged event of Images object.
        /// </summary>
        private void Images_ImageCollectionChanged(object sender, Vintasoft.Imaging.ImageCollectionChangeEventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Handles the FocusedIndexChanged event of AnnotationViewer1 object.
        /// </summary>
        private void AnnotationViewer1_FocusedIndexChanged(object sender, Vintasoft.Imaging.UI.FocusedIndexChangedEventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (_templateManager.SelectedTemplateIndex != -1)
                _selectedSignatureAnnotation = _templateManager.GetTemplateViewCopy(_templateManager.SelectedTemplateIndex);
        }

        #endregion


        #region UI State

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            saveToolStripButton.Enabled = _templateManager.Count != 0;
            removeToolStripSplitButton.Enabled = _templateManager.SelectedTemplateIndex != -1;
        }

        #endregion

        #endregion

        #endregion

    }
}
