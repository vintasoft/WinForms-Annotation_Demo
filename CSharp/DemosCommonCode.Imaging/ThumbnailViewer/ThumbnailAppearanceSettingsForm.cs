using System;
using System.Windows.Forms;

using Vintasoft.Imaging.UI;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to edit the appearance settings of thumbnail.
    /// </summary>
    public partial class ThumbnailAppearanceSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// The appearance of thumbnail.
        /// </summary>
        ThumbnailAppearance _thumbnailAppearance;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ThumbnailAppearanceSettingsForm"/> class.
        /// </summary>
        /// <param name="thumbnailAppearance">The appearance of thumbnail.</param>
        public ThumbnailAppearanceSettingsForm(ThumbnailAppearance thumbnailAppearance)
            : this()
        {
            _thumbnailAppearance = thumbnailAppearance;

            ShowSettings();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThumbnailAppearanceSettingsForm"/> class.
        /// </summary>
        /// <param name="thumbnailAppearance">The appearance of thumbnail.</param>
        /// <param name="title">The title of the form.</param>
        public ThumbnailAppearanceSettingsForm(ThumbnailAppearance thumbnailAppearance, string title)
            : this()
        {
            Text = title;
            _thumbnailAppearance = thumbnailAppearance;

            ShowSettings();
        }


        /// <summary>
        /// Prevents a default instance of
        /// the <see cref="ThumbnailAppearanceSettingsForm"/> class from being created.
        /// </summary>
        private ThumbnailAppearanceSettingsForm()
        {
            InitializeComponent();

            borderStyleComboBox.Items.Add(ButtonBorderStyle.None);
            borderStyleComboBox.Items.Add(ButtonBorderStyle.Dotted);
            borderStyleComboBox.Items.Add(ButtonBorderStyle.Dashed);
            borderStyleComboBox.Items.Add(ButtonBorderStyle.Solid);
            borderStyleComboBox.Items.Add(ButtonBorderStyle.Inset);
            borderStyleComboBox.Items.Add(ButtonBorderStyle.Outset);
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // if settings is updated
            if (SetSettings())
                DialogResult = DialogResult.OK;
        }


        /// <summary>
        /// Shows the settings of appearance.
        /// </summary>
        private void ShowSettings()
        {
            backColorPanelControl.Color = _thumbnailAppearance.BackColor;
            borderColorPanelControl.Color = _thumbnailAppearance.BorderColor;
            borderWidthNumericUpDown.Value = _thumbnailAppearance.BorderWidth;
            borderStyleComboBox.SelectedItem = _thumbnailAppearance.BorderStyle;
        }

        /// <summary>
        /// Sets the settings of appearance.
        /// </summary>
        private bool SetSettings()
        {
            _thumbnailAppearance.BackColor = backColorPanelControl.Color;
            _thumbnailAppearance.BorderColor = borderColorPanelControl.Color;
            _thumbnailAppearance.BorderWidth = (int)borderWidthNumericUpDown.Value;
            _thumbnailAppearance.BorderStyle = (ButtonBorderStyle)borderStyleComboBox.SelectedItem;

            return true;
        }

        #endregion

    }
}
