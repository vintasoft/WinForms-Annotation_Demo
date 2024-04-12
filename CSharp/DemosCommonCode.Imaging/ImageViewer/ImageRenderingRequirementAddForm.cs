using System;
using System.Globalization;
using System.Windows.Forms;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to add an image rendering requirement.
    /// </summary>
    public partial class ImageRenderingRequirementAddForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageRenderingRequirementAddForm"/> class.
        /// </summary>
        public ImageRenderingRequirementAddForm()
        {
            InitializeComponent();

            string[] codes = new string[] { "Bmp", "Jpeg", "Jpeg2000", "Tiff", "Png", "Pdf", "Docx", "Xlsx", "Wmf" };

            codecComboBox.Items.AddRange(codes);

            codecComboBox.SelectedIndex = 2;
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the selected codec name.
        /// </summary>
        public string Codec
        {
            get
            {
                return codecComboBox.SelectedItem.ToString();
            }
        }

        float _imageSize;
        /// <summary>
        /// Gets the image size in megapixels when image rendering must be enabled.
        /// </summary>
        public float ImageSize
        {
            get
            {
                return _imageSize;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the TextChanged event of imageSizeComboBox object.
        /// </summary>
        private void imageSizeComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // update value
                _imageSize = float.Parse(imageSizeComboBox.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of codecComboBox object.
        /// </summary>
        private void codecComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if JPEG2000 codec is selected
            if (codecComboBox.SelectedItem.ToString() == "Jpeg2000")
                imageSizeComboBox.Text = "0.5";
            // if PDF codec or DOCX codec is selected
            else if (codecComboBox.SelectedItem.ToString() == "Pdf" ||
                     codecComboBox.SelectedItem.ToString() == "Docx" ||
                     codecComboBox.SelectedItem.ToString() == "Xlsx" ||
                     codecComboBox.SelectedItem.ToString() == "Wmf")
                imageSizeComboBox.Text = "0";
            else
                imageSizeComboBox.Text = "50";
        }

        #endregion

    }
}
