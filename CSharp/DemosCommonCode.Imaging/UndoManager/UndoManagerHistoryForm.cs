using System;
using System.Windows.Forms;

using Vintasoft.Imaging.Undo;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that shows an action list of undo manager.
    /// </summary>
    public partial class UndoManagerHistoryForm : Form
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoManagerHistoryForm"/> class.
        /// </summary>
        /// <param name="ownerForm">The owner form.</param>
        /// <param name="undoManager">The undo manager.</param>
        public UndoManagerHistoryForm(Form ownerForm, UndoManager undoManager)
        {
            InitializeComponent();

            this.Owner = ownerForm;
            this.UndoManager = undoManager;
        }

        #endregion



        #region Properties

        UndoManager _undoManager;
        /// <summary>
        /// Gets or sets the undo manager.
        /// </summary>
        public UndoManager UndoManager
        {
            get
            {
                return _undoManager;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                if (_undoManager == value)
                    return;

                // unsubscribe from events of previous history manager
                UnsubscribeFromUndoManagerEvents(_undoManager);

                // set a reference to new history manager
                _undoManager = value;
                // subscribe to events of new history manager
                SubscribeToUndoManagerEvents(_undoManager);

                // update the listbox with descriptions of history action
                UpdateHistoryListBox();

                // select current action in the ist box of action descriptions
                undoManagerHistoryListBox.SelectedIndex = _undoManager.CurrentActionIndex;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the navigation in history is enabled.
        /// </summary>
        /// <value>
        /// <b>true</b> if navigate in history is enabled; otherwise, <b>false</b>.
        /// </value>
        public bool CanNavigateOnHistory
        {
            get
            {
                return undoManagerHistoryListBox.Enabled;
            }
            set
            {
                undoManagerHistoryListBox.Enabled = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Form is closed.
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (_undoManager != null)
                UnsubscribeFromUndoManagerEvents(_undoManager);
        }


        /// <summary>
        /// Subscribes to the events of history manager.
        /// </summary>
        private void SubscribeToUndoManagerEvents(UndoManager undoManager)
        {
            undoManager.Changed += new EventHandler<UndoManagerChangedEventArgs>(undoManager_Changed);
            undoManager.Navigated += new EventHandler<UndoManagerNavigatedEventArgs>(undoManager_Navigated);
        }

        /// <summary>
        /// Unsubscribes from the events of history manager.
        /// </summary>
        private void UnsubscribeFromUndoManagerEvents(UndoManager undoManager)
        {
            if (undoManager == null)
                return;

            undoManager.Changed -= new EventHandler<UndoManagerChangedEventArgs>(undoManager_Changed);
            undoManager.Navigated -= new EventHandler<UndoManagerNavigatedEventArgs>(undoManager_Navigated);
        }

        /// <summary>
        /// Updates the listbox with descriptions of history action.
        /// </summary>
        private void UpdateHistoryListBox()
        {
            undoManagerHistoryListBox.BeginUpdate();
            undoManagerHistoryListBox.Items.Clear();

            foreach (UndoAction action in _undoManager.GetActions())
                undoManagerHistoryListBox.Items.Add(GetUndoActionDescription(action));

            undoManagerHistoryListBox.SelectedIndex = _undoManager.CurrentActionIndex;
            undoManagerHistoryListBox.EndUpdate();
        }

        /// <summary>
        /// Returns a description of undo action.
        /// </summary>
        /// <returns>
        /// a description of undo action.
        /// </returns>
        private string GetUndoActionDescription(UndoAction action)
        {
            return action.ToString();
        }

        /// <summary>
        /// History is changed.
        /// </summary>
        private void undoManager_Changed(object sender, UndoManagerChangedEventArgs e)
        {
            if (undoManagerHistoryListBox.InvokeRequired)
                Invoke(new UpdateHistoryListBoxDelegate(UpdateHistoryListBox));
            else
                UpdateHistoryListBox();
        }

        /// <summary>
        /// Current action in history is changed.
        /// </summary>
        private void undoManager_Navigated(object sender, UndoManagerNavigatedEventArgs e)
        {
            if (undoManagerHistoryListBox.InvokeRequired)
                Invoke(new UpdateHistoryListBoxDelegate(SetSelectedIndexUndoManagerHistoryListBox));
            else
                SetSelectedIndexUndoManagerHistoryListBox();
        }

        /// <summary>
        /// Selects the current undo action in list box.
        /// </summary>
        private void SetSelectedIndexUndoManagerHistoryListBox()
        {
            if (undoManagerHistoryListBox.SelectedIndex == _undoManager.CurrentActionIndex)
                return;

            undoManagerHistoryListBox.SelectedIndex = _undoManager.CurrentActionIndex;
        }

        /// <summary>
        /// Index of current action is changed.
        /// </summary>
        private void undoManagerHistoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newHistoryIndex = undoManagerHistoryListBox.SelectedIndex;
            if (newHistoryIndex == _undoManager.CurrentActionIndex)
                return;

            if (newHistoryIndex > _undoManager.CurrentActionIndex)
                _undoManager.Redo(newHistoryIndex - _undoManager.CurrentActionIndex);
            else
                _undoManager.Undo(_undoManager.CurrentActionIndex - newHistoryIndex);
        }

        #endregion



        #region Delegates

        delegate void UpdateHistoryListBoxDelegate();

        #endregion

    }
}
