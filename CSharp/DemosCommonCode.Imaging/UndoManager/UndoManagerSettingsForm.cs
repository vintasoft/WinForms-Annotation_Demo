using System;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging.Undo;
using Vintasoft.Imaging.Utils;
using Vintasoft.Data;


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
            string storagePath = string.Empty;

            Type type = this.GetType();
            storagePath = Path.GetDirectoryName(type.Assembly.Location);

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
                compressedVintasoftImageOnDiscRadioButton.Checked = true;
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
        /// "OK" button is clicked.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            _undoManager.UndoLevel = (int)undoLevelNumericUpDown.Value;

            if (compressedVintasoftImageInMemoryRadioButton.Checked)
            {
                if (!(_dataStorage is CompressedImageStorageInMemory))
                    _dataStorage = new CompressedImageStorageInMemory();
            }
            else if (compressedVintasoftImageOnDiscRadioButton.Checked)
            {
                CompressedImageStorageOnDisk prevDataStorage =
                    _dataStorage as CompressedImageStorageOnDisk;

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
        /// History storage type is changed.
        /// </summary>
        private void compressedVintasoftImageOnDiscRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (compressedVintasoftImageOnDiscRadioButton.Checked)
                storageGroupBox.Enabled = true;
            else
                storageGroupBox.Enabled = false;
        }

        /// <summary>
        /// The button, which allows to select the folder for storage, is clicked.
        /// </summary>
        private void storageFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = storagePathTextBox.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                storagePathTextBox.Text = folderBrowserDialog1.SelectedPath;
        }

        #endregion

    }
}
