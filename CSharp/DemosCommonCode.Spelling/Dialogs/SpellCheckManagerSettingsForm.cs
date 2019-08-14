using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Vintasoft.Imaging.Spelling;


namespace DemosCommonCode.Spelling
{
    /// <summary>
    /// A form that allows to view and edit settings of <see cref="SpellCheckManager"/>.
    /// </summary>
    public partial class SpellCheckManagerSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// The spell check manager.
        /// </summary>
        SpellCheckManager _spellCheckManager;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellCheckManagerSettingsForm"/> class.
        /// </summary>
        /// <param name="spellCheckManager">The spell check manager.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <i>spellCheckManager</i> is <b>null</b>.
        /// </exception>
        public SpellCheckManagerSettingsForm(SpellCheckManager spellCheckManager)
        {
            InitializeComponent();

            // if spell check manager is not specified
            if (spellCheckManager == null)
                throw new ArgumentNullException();

            // save the spell check manager
            _spellCheckManager = spellCheckManager;


            // initialize UI

            enabledCheckBox.Checked = _spellCheckManager.IsEnabled;

            enginesCheckedListBox.BeginUpdate();
            foreach (ISpellCheckEngine engine in _spellCheckManager.Engines)
            {
                string engineName = engine.Name;

                // if engine name is not specified
                if (string.IsNullOrEmpty(engineName))
                    // create "standard" engine name
                    engineName = string.Format("Engine {0}", _spellCheckManager.Engines.IndexOf(engine));

                enginesCheckedListBox.Items.Add(engineName, engine.IsEnabled);
            }

            if (_spellCheckManager.Engines.Count > 0)
                enginesCheckedListBox.SelectedIndex = 0;
            enginesCheckedListBox.EndUpdate();

            // update UI
            UpdateUI();
        }

        #endregion



        #region Methods

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            // indicate whether the selected item must be moved up
            bool canMoveUp = false;
            // indicate whether the selected item must be moved down
            bool canMoveDown = false;

            // if item is selected
            if (enginesCheckedListBox.SelectedIndex != -1)
            {
                // if selected item is not first item
                if (enginesCheckedListBox.SelectedIndex > 0)
                    canMoveUp = true;

                // if selected item is not last item
                if (enginesCheckedListBox.SelectedIndex < enginesCheckedListBox.Items.Count - 1)
                    canMoveDown = true;
            }

            // update buttons
            moveUpButton.Enabled = canMoveUp;
            moveDownButton.Enabled = canMoveDown;
        }

        /// <summary>
        /// Enables/disables the spell check manager.
        /// </summary>
        private void enabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _spellCheckManager.IsEnabled = enabledCheckBox.Checked;
        }

        /// <summary>
        /// Moves up the selected engine.
        /// </summary>
        private void moveUpButton_Click(object sender, EventArgs e)
        {
            MoveEngine(enginesCheckedListBox.SelectedIndex, true);
        }

        /// <summary>
        /// Moves down the selected engine.
        /// </summary>
        private void moveDownButton_Click(object sender, EventArgs e)
        {
            MoveEngine(enginesCheckedListBox.SelectedIndex, false);
        }

        /// <summary>
        /// Moves up or down the engine.
        /// </summary>
        /// <param name="engineIndex">Index of the engine.</param>
        /// <param name="moveUp">
        /// <b>true</b> - the specified engine must be moved up;
        /// <b>false</b> - the specified engine must be moved down.
        /// </param>
        private void MoveEngine(int engineIndex, bool moveUp)
        {
            // get the engine
            ISpellCheckEngine engine = _spellCheckManager.Engines[engineIndex];

            // create engine list for reordering
            List<ISpellCheckEngine> engines = new List<ISpellCheckEngine>(
                _spellCheckManager.Engines);
            // get the engine name
            string engineName = enginesCheckedListBox.GetItemText(
                enginesCheckedListBox.Items[engineIndex]);

            // remove engine
            engines.RemoveAt(engineIndex);
            // new index of removed engne
            int newEngineIndex;

            // if engine must be moved up
            if (moveUp)
                newEngineIndex = engineIndex - 1;
            // if engine must be moved down
            else
                newEngineIndex = engineIndex + 1;

            // insert the engine
            engines.Insert(newEngineIndex, engine);
            // update engines in spell check manager
            _spellCheckManager.Engines = engines;

            // begin update of the list box with engines
            enginesCheckedListBox.BeginUpdate();

            // remove old item
            enginesCheckedListBox.Items.RemoveAt(engineIndex);
            // insert new item
            enginesCheckedListBox.Items.Insert(
                newEngineIndex, engineName);
            // update check state of item
            enginesCheckedListBox.SetItemChecked(
                newEngineIndex, engine.IsEnabled);
            // set the selected item
            enginesCheckedListBox.SelectedIndex = newEngineIndex;

            // end update of the list box with engines
            enginesCheckedListBox.EndUpdate();
        }

        /// <summary>
        /// Enable/disable the selected engine.
        /// </summary>
        private void enginesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            bool isEnabled = false;
            if (e.NewValue == CheckState.Checked)
                isEnabled = true;

            ISpellCheckEngine engine = _spellCheckManager.Engines[e.Index];

            if (isEnabled)
                _spellCheckManager.EnableEngine(engine);
            else
                _spellCheckManager.DisableEngine(engine);
        }

        /// <summary>
        /// Updates the UI.
        /// </summary>
        private void enginesCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        #endregion

    }
}
