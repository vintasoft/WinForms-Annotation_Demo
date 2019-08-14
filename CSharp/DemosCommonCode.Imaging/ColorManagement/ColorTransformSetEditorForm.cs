using System;
using System.Windows.Forms;

using Vintasoft.Imaging.ColorManagement;

namespace DemosCommonCode.Imaging.ColorManagement
{
    /// <summary>
    /// A form that allows to view and edit the color transformation set.
    /// </summary>
    public partial class ColorTransformSetEditorForm : Form
    {

        #region Constructors

        private ColorTransformSetEditorForm()
        {
            InitializeComponent();
        }

        public ColorTransformSetEditorForm(ColorTransformSet colorTransformSet)
            : this()
        {
            _colorTransformSet = new ColorTransformSet(colorTransformSet);
            RefreshColorTransformsList();

            // add standard transforms
            availableColorTransformsListBox.Items.Add(ColorTransforms.CmykToPcsXyzD50);
            availableColorTransformsListBox.Items.Add(ColorTransforms.SRgbToPcsXyzD50);
            availableColorTransformsListBox.Items.Add(ColorTransforms.SRgbToPcsXyzD50Fast);
            availableColorTransformsListBox.Items.Add(ColorTransforms.GrayToPcsXyzD50);
            availableColorTransformsListBox.Items.Add(ColorTransforms.PcsLabToPcsXyzD50);
            availableColorTransformsListBox.Items.Add(ColorTransforms.PcsXyzToPcsLabD50);
            availableColorTransformsListBox.Items.Add(ColorTransforms.PcsXyzToBgrD50);
            availableColorTransformsListBox.Items.Add(ColorTransforms.PcsXyzToBgrD50Fast);
            availableColorTransformsListBox.Items.Add(ColorTransforms.PcsXyzToGray);
        }

        #endregion



        #region Properties

        ColorTransformSet _colorTransformSet;
        /// <summary>
        /// Gets the color transform set.
        /// </summary>
        public ColorTransformSet ColorTransformSet
        {
            get
            {
                return _colorTransformSet;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Deletes the selected color transform from the transform set.
        /// </summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (colorTransformsListBox.SelectedItem != null)
            {
                ColorTransform selectedColorTransform = (ColorTransform)colorTransformsListBox.SelectedItem;
                _colorTransformSet.Remove(selectedColorTransform);
                RefreshColorTransformsList();
            }
        }

        /// <summary>
        /// Copies the selected color transform to the transform set.
        /// </summary>
        private void copyToTransformSetButton_Click(object sender, EventArgs e)
        {
            if (availableColorTransformsListBox.SelectedItem != null)
            {
                ColorTransform selectedColorTransform = (ColorTransform)availableColorTransformsListBox.SelectedItem;
                _colorTransformSet.Add(selectedColorTransform);
                RefreshColorTransformsList();
            }
        }

        /// <summary>
        /// Refreshes the list of color transforms in transform set.
        /// </summary>
        private void RefreshColorTransformsList()
        {
            colorTransformsListBox.Items.Clear();
            colorTransformsListBox.Items.AddRange(_colorTransformSet.ToArray());
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}
