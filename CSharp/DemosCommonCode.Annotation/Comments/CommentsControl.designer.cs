#if !REMOVE_ANNOTATION_PLUGIN
namespace DemosCommonCode.Annotation
{
    partial class CommentsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commentsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.visibleOnViewerCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // commentsLayoutPanel
            // 
            this.commentsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsLayoutPanel.AutoScroll = true;
            this.commentsLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commentsLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.commentsLayoutPanel.Location = new System.Drawing.Point(3, 23);
            this.commentsLayoutPanel.Name = "commentsLayoutPanel";
            this.commentsLayoutPanel.Size = new System.Drawing.Size(211, 295);
            this.commentsLayoutPanel.TabIndex = 0;
            this.commentsLayoutPanel.WrapContents = false;
            // 
            // visibleOnViewerCheckBox
            // 
            this.visibleOnViewerCheckBox.AutoSize = true;
            this.visibleOnViewerCheckBox.Enabled = false;
            this.visibleOnViewerCheckBox.Location = new System.Drawing.Point(3, 3);
            this.visibleOnViewerCheckBox.Name = "visibleOnViewerCheckBox";
            this.visibleOnViewerCheckBox.Size = new System.Drawing.Size(184, 17);
            this.visibleOnViewerCheckBox.TabIndex = 1;
            this.visibleOnViewerCheckBox.Text = "Display on image viewer";
            this.visibleOnViewerCheckBox.UseVisualStyleBackColor = true;
            this.visibleOnViewerCheckBox.CheckedChanged += new System.EventHandler(this.visibleOnViewerCheckBox_CheckedChanged);
            // 
            // CommentsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.visibleOnViewerCheckBox);
            this.Controls.Add(this.commentsLayoutPanel);
            this.Name = "CommentsControl";
            this.Size = new System.Drawing.Size(217, 321);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel commentsLayoutPanel;
        private System.Windows.Forms.CheckBox visibleOnViewerCheckBox;
    }
}
#endif