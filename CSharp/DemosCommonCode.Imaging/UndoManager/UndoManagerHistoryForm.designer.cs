namespace DemosCommonCode.Imaging
{
    partial class UndoManagerHistoryForm
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
            this.undoManagerHistoryListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // undoManagerHistoryListBox
            // 
            this.undoManagerHistoryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.undoManagerHistoryListBox.FormattingEnabled = true;
            this.undoManagerHistoryListBox.HorizontalScrollbar = true;
            this.undoManagerHistoryListBox.Location = new System.Drawing.Point(12, 9);
            this.undoManagerHistoryListBox.Name = "undoManagerHistoryListBox";
            this.undoManagerHistoryListBox.Size = new System.Drawing.Size(250, 316);
            this.undoManagerHistoryListBox.TabIndex = 0;
            this.undoManagerHistoryListBox.SelectedIndexChanged += new System.EventHandler(this.undoManagerHistoryListBox_SelectedIndexChanged);
            // 
            // UndoManagerHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 334);
            this.Controls.Add(this.undoManagerHistoryListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(290, 370);
            this.Name = "UndoManagerHistoryForm";
            this.Text = "Undo Manager History";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox undoManagerHistoryListBox;
    }
}