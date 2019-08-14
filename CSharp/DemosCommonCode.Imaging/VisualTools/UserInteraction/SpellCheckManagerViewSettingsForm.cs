using System;
using System.Windows.Forms;

using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit spell check manager view settings.
    /// </summary>
    public partial class SpellCheckManagerViewSettingsForm : Form
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellCheckManagerViewSettingsForm"/> class.
        /// </summary>
        public SpellCheckManagerViewSettingsForm()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Gets or sets the interaction area settings.
        /// </summary>
        public InteractionAreaAppearanceManager InteractionAreaSettings
        {
            get
            {
                return spellCheckManagerViewSettingsControl1.InteractionAreaSettings;
            }
            set
            {
                spellCheckManagerViewSettingsControl1.InteractionAreaSettings = value;
            }
        }



        /// <summary>
        /// "OK" button is clicked.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            spellCheckManagerViewSettingsControl1.ApplySpellCheckManagerSetting();

            DialogResult = DialogResult.OK;
        }

    }
}
