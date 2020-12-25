namespace DemosCommonCode.Imaging
{
    partial class UndoManagerSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.undoLevelLabel = new System.Windows.Forms.Label();
            this.undoLevelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.compressedVintasoftImageOnDiskRadioButton = new System.Windows.Forms.RadioButton();
            this.storageGroupBox = new System.Windows.Forms.GroupBox();
            this.storagePathTextBox = new System.Windows.Forms.TextBox();
            this.storageFolderButton = new System.Windows.Forms.Button();
            this.compressedVintasoftImageInMemoryRadioButton = new System.Windows.Forms.RadioButton();
            this.vintasoftImageInMemoryRadioButton = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.undoLevelNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.storageGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // undoLevelLabel
            // 
            this.undoLevelLabel.AutoSize = true;
            this.undoLevelLabel.Location = new System.Drawing.Point(10, 14);
            this.undoLevelLabel.Name = "undoLevelLabel";
            this.undoLevelLabel.Size = new System.Drawing.Size(61, 13);
            this.undoLevelLabel.TabIndex = 1;
            this.undoLevelLabel.Text = "Undo level:";
            // 
            // undoLevelNumericUpDown
            // 
            this.undoLevelNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.undoLevelNumericUpDown.Location = new System.Drawing.Point(78, 11);
            this.undoLevelNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.undoLevelNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.undoLevelNumericUpDown.Name = "undoLevelNumericUpDown";
            this.undoLevelNumericUpDown.Size = new System.Drawing.Size(162, 20);
            this.undoLevelNumericUpDown.TabIndex = 2;
            this.undoLevelNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(84, 176);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(165, 176);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.compressedVintasoftImageOnDiskRadioButton);
            this.groupBox1.Controls.Add(this.storageGroupBox);
            this.groupBox1.Controls.Add(this.compressedVintasoftImageInMemoryRadioButton);
            this.groupBox1.Controls.Add(this.vintasoftImageInMemoryRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 119);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History storage";
            // 
            // compressedVintasoftImageOnDiscRadioButton
            // 
            this.compressedVintasoftImageOnDiskRadioButton.AutoSize = true;
            this.compressedVintasoftImageOnDiskRadioButton.Location = new System.Drawing.Point(6, 65);
            this.compressedVintasoftImageOnDiskRadioButton.Name = "compressedVintasoftImageOnDiscRadioButton";
            this.compressedVintasoftImageOnDiskRadioButton.Size = new System.Drawing.Size(193, 17);
            this.compressedVintasoftImageOnDiskRadioButton.TabIndex = 2;
            this.compressedVintasoftImageOnDiskRadioButton.TabStop = true;
            this.compressedVintasoftImageOnDiskRadioButton.Text = "Compressed VintasoftImage on disk";
            this.compressedVintasoftImageOnDiskRadioButton.UseVisualStyleBackColor = true;
            this.compressedVintasoftImageOnDiskRadioButton.CheckedChanged += new System.EventHandler(this.compressedVintasoftImageOnDiskRadioButton_CheckedChanged);
            // 
            // storageGroupBox
            // 
            this.storageGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.storageGroupBox.Controls.Add(this.storagePathTextBox);
            this.storageGroupBox.Controls.Add(this.storageFolderButton);
            this.storageGroupBox.Enabled = false;
            this.storageGroupBox.Location = new System.Drawing.Point(6, 73);
            this.storageGroupBox.Name = "storageGroupBox";
            this.storageGroupBox.Size = new System.Drawing.Size(215, 40);
            this.storageGroupBox.TabIndex = 3;
            this.storageGroupBox.TabStop = false;
            // 
            // storagePathTextBox
            // 
            this.storagePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.storagePathTextBox.Location = new System.Drawing.Point(6, 15);
            this.storagePathTextBox.Name = "storagePathTextBox";
            this.storagePathTextBox.ReadOnly = true;
            this.storagePathTextBox.Size = new System.Drawing.Size(172, 20);
            this.storagePathTextBox.TabIndex = 1;
            // 
            // storageFolderButton
            // 
            this.storageFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.storageFolderButton.Location = new System.Drawing.Point(184, 13);
            this.storageFolderButton.Name = "storageFolderButton";
            this.storageFolderButton.Size = new System.Drawing.Size(25, 23);
            this.storageFolderButton.TabIndex = 0;
            this.storageFolderButton.Text = "...";
            this.storageFolderButton.UseVisualStyleBackColor = true;
            this.storageFolderButton.Click += new System.EventHandler(this.storageFolderButton_Click);
            // 
            // compressedVintasoftImageInMemoryRadioButton
            // 
            this.compressedVintasoftImageInMemoryRadioButton.AutoSize = true;
            this.compressedVintasoftImageInMemoryRadioButton.Location = new System.Drawing.Point(6, 42);
            this.compressedVintasoftImageInMemoryRadioButton.Name = "compressedVintasoftImageInMemoryRadioButton";
            this.compressedVintasoftImageInMemoryRadioButton.Size = new System.Drawing.Size(206, 17);
            this.compressedVintasoftImageInMemoryRadioButton.TabIndex = 1;
            this.compressedVintasoftImageInMemoryRadioButton.TabStop = true;
            this.compressedVintasoftImageInMemoryRadioButton.Text = "Compressed VintasoftImage in memory";
            this.compressedVintasoftImageInMemoryRadioButton.UseVisualStyleBackColor = true;
            // 
            // vintasoftImageInMemoryRadioButton
            // 
            this.vintasoftImageInMemoryRadioButton.AutoSize = true;
            this.vintasoftImageInMemoryRadioButton.Location = new System.Drawing.Point(6, 19);
            this.vintasoftImageInMemoryRadioButton.Name = "vintasoftImageInMemoryRadioButton";
            this.vintasoftImageInMemoryRadioButton.Size = new System.Drawing.Size(145, 17);
            this.vintasoftImageInMemoryRadioButton.TabIndex = 0;
            this.vintasoftImageInMemoryRadioButton.TabStop = true;
            this.vintasoftImageInMemoryRadioButton.Text = "VintasoftImage in memory";
            this.vintasoftImageInMemoryRadioButton.UseVisualStyleBackColor = true;
            // 
            // UndoManagerSettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(252, 211);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.undoLevelNumericUpDown);
            this.Controls.Add(this.undoLevelLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "UndoManagerSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Undo Manager Settings";
            ((System.ComponentModel.ISupportInitialize)(this.undoLevelNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.storageGroupBox.ResumeLayout(false);
            this.storageGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label undoLevelLabel;
        private System.Windows.Forms.NumericUpDown undoLevelNumericUpDown;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton compressedVintasoftImageOnDiskRadioButton;
        private System.Windows.Forms.RadioButton compressedVintasoftImageInMemoryRadioButton;
        private System.Windows.Forms.RadioButton vintasoftImageInMemoryRadioButton;
        private System.Windows.Forms.GroupBox storageGroupBox;
        private System.Windows.Forms.TextBox storagePathTextBox;
        private System.Windows.Forms.Button storageFolderButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
