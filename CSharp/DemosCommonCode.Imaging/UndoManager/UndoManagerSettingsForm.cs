using System;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Data;
using Vintasoft.Imaging.Undo;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit settings of undo manager.
    /// </summary>
    public partial class UndoManagerSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// The undo manager.
        /// </summary>
        UndoManager _undoManager = null;

        #endregion



        #region Consturctors

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoManagerSettingsForm"/> class.
        /// </summary>
        /// <param name="undoManager">The undo manager.</param>
        /// <param name="dataStorage">The data storage, where data are stored.</param>
        public UndoManagerSettingsForm(
            UndoManager undoManager,
            IDataStorage dataStorage)
        {
            InitializeComponent();

            _undoManager = undoManager;
            _dataStorage = dataStorage;

            undoLevelNumericUpDown.Value = _undoManager.UndoLevel;

            storageGroupBox.Enabled = false;

            Type type = this.GetType();
            string storagePath = Path.GetDirectoryName(type.Assembly.Location);

            storagePath = Path.Combine(storagePath, "Undo");
            if (!Directory.Exists(storagePath))
                Directory.CreateDirectory(storagePath);


            if (dataStorage is CompressedImageStorageInMemory)
            {
                compressedVintasoftImageInMemoryRadioButton.Checked = true;
            }
            else if (dataStorage is CompressedImageStorageOnDisk)
            {
                storageGroupBox.Enabled = true;
                compressedVintasoftImageOnDiskRadioButton.Checked = true;
                CompressedImageStorageOnDisk dataStorageOnDisk = (CompressedImageStorageOnDisk)dataStorage;
                storagePath = dataStorageOnDisk.StoragePath;
            }
            else
            {
                vintasoftImageInMemoryRadioButton.Checked = true;
            }

            storagePathTextBox.Text = storagePath;
        }

        #endregion



        #region Properties

        IDataStorage _dataStorage = null;
        /// <summary>
        /// Gets the data storage.
        /// </summary>
        public IDataStorage DataStorage
        {
            get
            {
                return _dataStorage;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // update undo manager level
            _undoManager.UndoLevel = (int)undoLevelNumericUpDown.Value;

            // if compressed data storage in memory must be used
            if (compressedVintasoftImageInMemoryRadioButton.Checked)
            {
                if (!(_dataStorage is CompressedImageStorageInMemory))
                    _dataStorage = new CompressedImageStorageInMemory();
            }
            // if compressed data storage on disk must be used
            else if (compressedVintasoftImageOnDiskRadioButton.Checked)
            {
                CompressedImageStorageOnDisk prevDataStorage =
                    _dataStorage as CompressedImageStorageOnDisk;

                // if data storage is changed
                if (prevDataStorage == null ||
                    !prevDataStorage.StoragePath.Equals(storagePathTextBox.Text, StringComparison.InvariantCultureIgnoreCase))
                {
                    _dataStorage = new CompressedImageStorageOnDisk(storagePathTextBox.Text);
                }
            }
            else
            {
                _dataStorage = null;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of compressedVintasoftImageOnDiskRadioButton object.
        /// </summary>
        private void compressedVintasoftImageOnDiskRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // if compressed image on disk must be used
            if (compressedVintasoftImageOnDiskRadioButton.Checked)
                storageGroupBox.Enabled = true;
            else
                storageGroupBox.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of storageFolderButton object.
        /// </summary>
        private void storageFolderButton_Click(object sender, EventArgs e)
        {
            // update selected folder
            folderBrowserDialog1.SelectedPath = storagePathTextBox.Text;
            // if storage folder must be changed
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                storagePathTextBox.Text = folderBrowserDialog1.SelectedPath;
        }

        #endregion

    }
}
