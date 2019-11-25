using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using Vintasoft.Imaging.ImageRendering;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit the image rendering requirements.
    /// </summary>
    public partial class ImageRenderingRequirementsForm : Form
    {

        #region Fields

        Dictionary<string, float> _requirements = new Dictionary<string, float>();

        string[] _codes = new string[] { "Bmp", "Jpeg", "Jpeg2000", "Tiff", "Png", "Pdf", "Docx" };

        #endregion



        #region Constructors

        public ImageRenderingRequirementsForm()
        {
            InitializeComponent();
        }

        public ImageRenderingRequirementsForm(ImageRenderingRequirements renderingRequirements)
            : this()
        {
            _renderingRequirements = renderingRequirements;

            ShowSettings();
        }

        #endregion



        #region Properties

        ImageRenderingRequirements _renderingRequirements;
        public ImageRenderingRequirements RenderingRequirements
        {
            get
            {
                return _renderingRequirements;
            }
        }

        #endregion



        #region Methods

        private void ShowSettings()
        {

            for (int i = 0; i < _codes.Length; i++)
            {
                ImageSizeRenderingRequirement requirement;
                requirement = _renderingRequirements.GetRequirement(_codes[i]) as ImageSizeRenderingRequirement;
                if (requirement != null)
                {
                    codecComboBox.Items.Add(_codes[i]);
                    _requirements.Add(_codes[i], requirement.ImageSize);
                }
            }

            if (codecComboBox.Items.Count > 0)
                codecComboBox.SelectedIndex = 0;
            UpdateUI();
        }

        private bool SetSettings()
        {
            for (int i = 0; i < _codes.Length; i++)
            {
                string codec = _codes[i];
                if (_requirements.ContainsKey(codec))
                {
                    if (codec == "Tiff")
                        _renderingRequirements.SetRequirement(codec, new TiffRenderingRequirement(_requirements[codec]));
                    else if (codec == "Jpeg")
                        _renderingRequirements.SetRequirement(codec, new JpegRenderingRequirement(_requirements[codec]));
                    else
                        _renderingRequirements.SetRequirement(codec, new ImageSizeRenderingRequirement(_requirements[codec]));
                }
                else
                {
                    _renderingRequirements.SetRequirement(codec, null);
                }
            }
            return true;
        }

        private void UpdateUI()
        {
            bool isEmptyRenderingRequirments = _requirements.Count == 0;

            codecComboBox.Enabled = !isEmptyRenderingRequirments;
            megapixelsComboBox.Enabled = !isEmptyRenderingRequirments;
            removeButton.Enabled = !isEmptyRenderingRequirments;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (SetSettings())
                DialogResult = DialogResult.OK;
        }

        private void megapixelsComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _requirements[(string)codecComboBox.SelectedItem] = float.Parse(megapixelsComboBox.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        private void codecComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            megapixelsComboBox.Text = _requirements[(string)codecComboBox.SelectedItem].ToString(CultureInfo.InvariantCulture);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            string codec = codecComboBox.SelectedItem.ToString();
            if (_requirements.ContainsKey(codec))
            {
                _requirements.Remove(codec);
                codecComboBox.Items.Remove(codec);
                codecComboBox.SelectedIndex = codecComboBox.Items.Count - 1;
                UpdateUI();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ImageRenderingRequirementAddForm dialog = new ImageRenderingRequirementAddForm();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string codec = dialog.Codec;
                float value = dialog.Value;
                if (_requirements.ContainsKey(codec))
                    _requirements[codec] = value;
                else
                {
                    _requirements.Add(codec, value);
                    codecComboBox.Items.Add(codec);
                }
                UpdateUI();
                if (codecComboBox.SelectedItem != null && codecComboBox.SelectedItem.ToString() == codec)
                    codecComboBox_SelectedIndexChanged(this, EventArgs.Empty);
                else
                    codecComboBox.SelectedItem = codec;
            }
        }

        #endregion

    }
}
