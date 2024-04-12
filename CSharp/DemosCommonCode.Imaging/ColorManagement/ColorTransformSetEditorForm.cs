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

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorTransformSetEditorForm"/> class.
        /// </summary>
        private ColorTransformSetEditorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorTransformSetEditorForm"/> class.
        /// </summary>
        /// <param name="colorTransformSet">The set of color transforms.</param>
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
        /// Handles the Click event of deleteButton object.
        /// </summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (colorTransformsListBox.SelectedItem != null)
            {
                // get color transform that must be removed
                ColorTransform selectedColorTransform = (ColorTransform)colorTransformsListBox.SelectedItem;
                // remove color transform
                _colorTransformSet.Remove(selectedColorTransform);
                // update color transform list
                RefreshColorTransformsList();
            }
        }

        /// <summary>
        /// Handles the Click event of copyToTransformSetButton object.
        /// </summary>
        private void copyToTransformSetButton_Click(object sender, EventArgs e)
        {
            if (availableColorTransformsListBox.SelectedItem != null)
            {
                ColorTransform selectedColorTransform = (ColorTransform)availableColorTransformsListBox.SelectedItem;
                // add color transform
                _colorTransformSet.Add(selectedColorTransform);
                // update color transform list
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

        #endregion

    }
}
