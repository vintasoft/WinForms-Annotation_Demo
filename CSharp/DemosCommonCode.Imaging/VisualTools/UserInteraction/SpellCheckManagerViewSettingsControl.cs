using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Spelling.UI;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A control that allows to view and edit the view settings of spell check manager.
    /// </summary>
    public partial class SpellCheckManagerViewSettingsControl : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellCheckManagerViewSettingsControl"/> class.
        /// </summary>
        public SpellCheckManagerViewSettingsControl()
        {
            InitializeComponent();

            spellCheckMnagerUnderlineColorColorPanelControl.CanSetColor = true;
            foreach (UnderlineType underlineType in Enum.GetValues(typeof(UnderlineType)))
                spellCheckManagerUnderlineTypeComboBox.Items.Add(underlineType);

            mainPanel.Enabled = false;
        }

        #endregion



        #region Properties

        InteractionAreaAppearanceManager _interactionAreaSettings = null;
        /// <summary>
        /// Gets or sets the interaction area settings.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public InteractionAreaAppearanceManager InteractionAreaSettings
        {
            get
            {
                return _interactionAreaSettings;
            }
            set
            {
                _interactionAreaSettings = value;

                UpdateUI();
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            InteractionAreaAppearanceManager settings = _interactionAreaSettings;

            mainPanel.Enabled = settings != null;

            if (settings == null)
                return;

            // spell check manager
            spellCheckMnagerUnderlineColorColorPanelControl.Color = settings.SpellCheckManagerUnderlineColor;
            spellCheckManagerUnderlineThicknessNumericUpDown.Value = (decimal)settings.SpellCheckManagerUnderlineThickness;
            spellCheckManagerUnderlineTypeComboBox.SelectedItem = settings.SpellCheckManagerUnderlineType;
            spellCheckManagerSuggestMenuEnabledCheckBox.Checked = settings.SpellCheckManagerSuggestMenuEnabled;
        }

        /// <summary>
        /// Applies the setting to the spell check manager.
        /// </summary>
        public void ApplySpellCheckManagerSetting()
        {
            if (_interactionAreaSettings != null)
            {
                // spell check manager
                _interactionAreaSettings.SpellCheckManagerUnderlineColor = spellCheckMnagerUnderlineColorColorPanelControl.Color;
                _interactionAreaSettings.SpellCheckManagerUnderlineThickness = (float)spellCheckManagerUnderlineThicknessNumericUpDown.Value;
                _interactionAreaSettings.SpellCheckManagerUnderlineType = (UnderlineType)spellCheckManagerUnderlineTypeComboBox.SelectedItem;
                _interactionAreaSettings.SpellCheckManagerSuggestMenuEnabled = spellCheckManagerSuggestMenuEnabledCheckBox.Checked;
            }
        }

        #endregion

    }
}
