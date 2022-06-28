namespace DemosCommonCode.Annotation
{
    partial class CommentStateHistoryForm
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
            this.commentStateHistoryControl1 = new DemosCommonCode.Annotation.CommentStateHistoryControl();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // commentStateHistoryControl1
            // 
            this.commentStateHistoryControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
#if !REMOVE_ANNOTATION_PLUGIN
            this.commentStateHistoryControl1.Comment = null;
#endif
            this.commentStateHistoryControl1.Location = new System.Drawing.Point(12, 12);
            this.commentStateHistoryControl1.Name = "commentStateHistoryControl1";
            this.commentStateHistoryControl1.Size = new System.Drawing.Size(343, 367);
            this.commentStateHistoryControl1.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(280, 385);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // CommentStateHistoryForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(367, 420);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.commentStateHistoryControl1);
            this.MinimumSize = new System.Drawing.Size(300, 252);
            this.Name = "CommentStateHistoryForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comment State History";
            this.ResumeLayout(false);

        }

        #endregion

        private CommentStateHistoryControl commentStateHistoryControl1;
        private System.Windows.Forms.Button okButton;
    }
}