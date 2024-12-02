using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit spell check manager view settings.
    /// </summary>
    public partial class SpellCheckManagerViewSettingsForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellCheckManagerViewSettingsForm"/> class.
        /// </summary>
        public SpellCheckManagerViewSettingsForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the interaction area settings.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // update spell check manager settings
            spellCheckManagerViewSettingsControl1.ApplySpellCheckManagerSetting();

            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
