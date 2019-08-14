using System;
using System.Globalization;
using System.Windows.Forms;

using Vintasoft.Imaging.ImageRendering;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to add an image rendering requirement.
    /// </summary>
    public partial class ImageRenderingRequirementAddForm : Form
    {

        #region Constructor

        public ImageRenderingRequirementAddForm()
        {
            InitializeComponent();

            string[] codes = new string[] { "Bmp", "Jpeg", "Jpeg2000", "Tiff", "Png", "Pdf" };

            codecComboBox.Items.AddRange(codes);

            codecComboBox.SelectedIndex = 2;
        }

        #endregion



        #region Properties

        public string Codec
        {
            get
            {
                return codecComboBox.SelectedItem.ToString();
            }
        }

        float _value;
        public float Value
        {
            get
            {
                return _value;
            }
        }

        #endregion



        #region Methods

        private void megapixelsComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _value = float.Parse(megapixelsComboBox.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        private void codecComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (codecComboBox.SelectedItem.ToString() == "Jpeg2000")
                megapixelsComboBox.Text = "0.5";
            else
                megapixelsComboBox.Text = "50";
        }

        #endregion

    }
}
