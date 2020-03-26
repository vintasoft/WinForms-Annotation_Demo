namespace DemosCommonCode.Annotation
{
    partial class AnnotationCommentsControl
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
            this.commentsControl1 = new DemosCommonCode.Annotation.CommentsControl();
            this.addNewCommentButton = new System.Windows.Forms.Button();
            this.removeCommentFromAnnotationButton = new System.Windows.Forms.Button();
            this.closeAllCommentsButton = new System.Windows.Forms.Button();
            this.addCommentToAnnotationButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // commentsControl1
            // 
            this.commentsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsControl1.CommentController = null;
            this.commentsControl1.CommentTool = null;
            this.commentsControl1.ImageViewer = null;
            this.commentsControl1.Location = new System.Drawing.Point(3, 119);
            this.commentsControl1.Name = "commentsControl1";
            this.commentsControl1.Size = new System.Drawing.Size(225, 195);
            this.commentsControl1.TabIndex = 0;
            // 
            // addNewCommentButton
            // 
            this.addNewCommentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewCommentButton.Location = new System.Drawing.Point(3, 3);
            this.addNewCommentButton.Name = "addNewCommentButton";
            this.addNewCommentButton.Size = new System.Drawing.Size(225, 23);
            this.addNewCommentButton.TabIndex = 5;
            this.addNewCommentButton.Text = "Add New Comment";
            this.addNewCommentButton.UseVisualStyleBackColor = true;
            this.addNewCommentButton.Click += new System.EventHandler(this.addNewCommentButton_Click);
            // 
            // removeCommentFromAnnotationButton
            // 
            this.removeCommentFromAnnotationButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeCommentFromAnnotationButton.Location = new System.Drawing.Point(3, 61);
            this.removeCommentFromAnnotationButton.Name = "removeCommentFromAnnotationButton";
            this.removeCommentFromAnnotationButton.Size = new System.Drawing.Size(225, 23);
            this.removeCommentFromAnnotationButton.TabIndex = 8;
            this.removeCommentFromAnnotationButton.Text = "Remove Comment From Annotation";
            this.removeCommentFromAnnotationButton.UseVisualStyleBackColor = true;
            this.removeCommentFromAnnotationButton.Click += new System.EventHandler(this.removeCommentFromAnnotationButton_Click);
            // 
            // closeAllCommentsButton
            // 
            this.closeAllCommentsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeAllCommentsButton.Location = new System.Drawing.Point(3, 90);
            this.closeAllCommentsButton.Name = "closeAllCommentsButton";
            this.closeAllCommentsButton.Size = new System.Drawing.Size(225, 23);
            this.closeAllCommentsButton.TabIndex = 7;
            this.closeAllCommentsButton.Text = "Close All Comments";
            this.closeAllCommentsButton.UseVisualStyleBackColor = true;
            this.closeAllCommentsButton.Click += new System.EventHandler(this.closeAllCommentsButton_Click);
            // 
            // addCommentToAnnotationButton
            // 
            this.addCommentToAnnotationButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addCommentToAnnotationButton.Location = new System.Drawing.Point(3, 32);
            this.addCommentToAnnotationButton.Name = "addCommentToAnnotationButton";
            this.addCommentToAnnotationButton.Size = new System.Drawing.Size(225, 23);
            this.addCommentToAnnotationButton.TabIndex = 6;
            this.addCommentToAnnotationButton.Text = "Add Comment To Annotation";
            this.addCommentToAnnotationButton.UseVisualStyleBackColor = true;
            this.addCommentToAnnotationButton.Click += new System.EventHandler(this.addCommentToAnnotationButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.addNewCommentButton);
            this.mainPanel.Controls.Add(this.commentsControl1);
            this.mainPanel.Controls.Add(this.removeCommentFromAnnotationButton);
            this.mainPanel.Controls.Add(this.addCommentToAnnotationButton);
            this.mainPanel.Controls.Add(this.closeAllCommentsButton);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(231, 317);
            this.mainPanel.TabIndex = 9;
            // 
            // AnnotationCommentsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(190, 180);
            this.Name = "AnnotationCommentsControl";
            this.Size = new System.Drawing.Size(231, 317);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Annotation.CommentsControl commentsControl1;
        private System.Windows.Forms.Button addNewCommentButton;
        private System.Windows.Forms.Button removeCommentFromAnnotationButton;
        private System.Windows.Forms.Button closeAllCommentsButton;
        private System.Windows.Forms.Button addCommentToAnnotationButton;
        private System.Windows.Forms.Panel mainPanel;
    }
}