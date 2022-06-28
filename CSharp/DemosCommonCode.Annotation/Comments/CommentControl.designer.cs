#if !REMOVE_ANNOTATION_PLUGIN
namespace DemosCommonCode.Annotation
{
    partial class CommentControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentControl));
            this.userNameLabel = new System.Windows.Forms.Label();
            this.modifyDateLabel = new System.Windows.Forms.Label();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.repliesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mainFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.statesToolStrip = new System.Windows.Forms.ToolStrip();
            this.topPanel = new System.Windows.Forms.Panel();
            this.commentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseRepliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.reviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewAcceptedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewCompletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewRejectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewCancelledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStateHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameLabel = new System.Windows.Forms.Label();
            this.rightHeaderflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.expandButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.lockIconLabel = new System.Windows.Forms.Label();
            this.mainFlowLayoutPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.commentContextMenuStrip.SuspendLayout();
            this.rightHeaderflowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.userNameLabel.Location = new System.Drawing.Point(0, 6);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(63, 13);
            this.userNameLabel.TabIndex = 3;
            this.userNameLabel.Text = "userName";
            // 
            // modifyDateLabel
            // 
            this.modifyDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modifyDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.modifyDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modifyDateLabel.Location = new System.Drawing.Point(162, 20);
            this.modifyDateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.modifyDateLabel.Name = "modifyDateLabel";
            this.modifyDateLabel.Size = new System.Drawing.Size(141, 24);
            this.modifyDateLabel.TabIndex = 4;
            this.modifyDateLabel.Text = "modifyDate";
            this.modifyDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textTextBox
            // 
            this.textTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textTextBox.ForeColor = System.Drawing.Color.Black;
            this.textTextBox.Location = new System.Drawing.Point(4, 29);
            this.textTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 3, 0);
            this.textTextBox.Multiline = true;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(296, 20);
            this.textTextBox.TabIndex = 1;
            this.textTextBox.TextChanged += new System.EventHandler(this.textTextBox_TextChanged);
            // 
            // repliesFlowLayoutPanel
            // 
            this.repliesFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repliesFlowLayoutPanel.AutoScroll = true;
            this.repliesFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.repliesFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.repliesFlowLayoutPanel.Location = new System.Drawing.Point(10, 51);
            this.repliesFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(10, 2, 3, 3);
            this.repliesFlowLayoutPanel.Name = "repliesFlowLayoutPanel";
            this.repliesFlowLayoutPanel.Size = new System.Drawing.Size(290, 68);
            this.repliesFlowLayoutPanel.TabIndex = 2;
            this.repliesFlowLayoutPanel.WrapContents = false;
            // 
            // mainFlowLayoutPanel
            // 
            this.mainFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainFlowLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainFlowLayoutPanel.Controls.Add(this.statesToolStrip);
            this.mainFlowLayoutPanel.Controls.Add(this.textTextBox);
            this.mainFlowLayoutPanel.Controls.Add(this.repliesFlowLayoutPanel);
            this.mainFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainFlowLayoutPanel.Location = new System.Drawing.Point(0, 45);
            this.mainFlowLayoutPanel.Name = "mainFlowLayoutPanel";
            this.mainFlowLayoutPanel.Size = new System.Drawing.Size(303, 128);
            this.mainFlowLayoutPanel.TabIndex = 6;
            this.mainFlowLayoutPanel.WrapContents = false;
            // 
            // statesToolStrip
            // 
            this.statesToolStrip.AutoSize = false;
            this.statesToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.statesToolStrip.Location = new System.Drawing.Point(4, 0);
            this.statesToolStrip.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statesToolStrip.Name = "statesToolStrip";
            this.statesToolStrip.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.statesToolStrip.Size = new System.Drawing.Size(295, 25);
            this.statesToolStrip.TabIndex = 4;
            // 
            // topPanel
            // 
            this.topPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.ContextMenuStrip = this.commentContextMenuStrip;
            this.topPanel.Controls.Add(this.nameLabel);
            this.topPanel.Controls.Add(this.userNameLabel);
            this.topPanel.Controls.Add(this.rightHeaderflowLayoutPanel);
            this.topPanel.Controls.Add(this.modifyDateLabel);
            this.topPanel.Location = new System.Drawing.Point(-1, -1);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(306, 46);
            this.topPanel.TabIndex = 7;
            // 
            // commentContextMenuStrip
            // 
            this.commentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replyToolStripMenuItem,
            this.toolStripSeparator1,
            this.expandAllToolStripMenuItem,
            this.collapseRepliesToolStripMenuItem,
            this.resetLocationToolStripMenuItem,
            this.collapseAllButThisToolStripMenuItem,
            this.toolStripSeparator4,
            this.reviewToolStripMenuItem,
            this.stateHistoryToolStripMenuItem,
            this.showStateHistoryToolStripMenuItem,
            this.toolStripSeparator3,
            this.removeToolStripMenuItem,
            this.toolStripSeparator2,
            this.propertiesToolStripMenuItem});
            this.commentContextMenuStrip.Name = "contextMenuStrip1";
            this.commentContextMenuStrip.Size = new System.Drawing.Size(227, 248);
            // 
            // replyToolStripMenuItem
            // 
            this.replyToolStripMenuItem.Name = "replyToolStripMenuItem";
            this.replyToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.replyToolStripMenuItem.Text = "Reply";
            this.replyToolStripMenuItem.Click += new System.EventHandler(this.replyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.expandAllToolStripMenuItem.Text = "Expand All";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.expandAllToolStripMenuItem_Click);
            // 
            // collapseRepliesToolStripMenuItem
            // 
            this.collapseRepliesToolStripMenuItem.Name = "collapseRepliesToolStripMenuItem";
            this.collapseRepliesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.collapseRepliesToolStripMenuItem.Text = "Collapse Replies";
            this.collapseRepliesToolStripMenuItem.Click += new System.EventHandler(this.collapseRepliesToolStripMenuItem_Click);
            // 
            // resetLocationToolStripMenuItem
            // 
            this.resetLocationToolStripMenuItem.Name = "resetLocationToolStripMenuItem";
            this.resetLocationToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.resetLocationToolStripMenuItem.Text = "Reset Location";
            this.resetLocationToolStripMenuItem.Click += new System.EventHandler(this.resetLocationToolStripMenuItem_Click);
            // 
            // collapseAllButThisToolStripMenuItem
            // 
            this.collapseAllButThisToolStripMenuItem.Name = "collapseAllButThisToolStripMenuItem";
            this.collapseAllButThisToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.collapseAllButThisToolStripMenuItem.Text = "Collapse All But This";
            this.collapseAllButThisToolStripMenuItem.Click += new System.EventHandler(this.collapseAllButThisToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(223, 6);
            // 
            // reviewToolStripMenuItem
            // 
            this.reviewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reviewAcceptedToolStripMenuItem,
            this.reviewCompletedToolStripMenuItem,
            this.reviewRejectedToolStripMenuItem,
            this.reviewCancelledToolStripMenuItem,
            this.reviewNoneToolStripMenuItem});
            this.reviewToolStripMenuItem.Name = "reviewToolStripMenuItem";
            this.reviewToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.reviewToolStripMenuItem.Text = "Set Status";
            // 
            // reviewAcceptedToolStripMenuItem
            // 
            this.reviewAcceptedToolStripMenuItem.Name = "reviewAcceptedToolStripMenuItem";
            this.reviewAcceptedToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.reviewAcceptedToolStripMenuItem.Text = "Accepted";
            this.reviewAcceptedToolStripMenuItem.Click += new System.EventHandler(this.setStateToolStripMenuItem_Click);
            // 
            // reviewCompletedToolStripMenuItem
            // 
            this.reviewCompletedToolStripMenuItem.Name = "reviewCompletedToolStripMenuItem";
            this.reviewCompletedToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.reviewCompletedToolStripMenuItem.Text = "Completed";
            this.reviewCompletedToolStripMenuItem.Click += new System.EventHandler(this.setStateToolStripMenuItem_Click);
            // 
            // reviewRejectedToolStripMenuItem
            // 
            this.reviewRejectedToolStripMenuItem.Name = "reviewRejectedToolStripMenuItem";
            this.reviewRejectedToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.reviewRejectedToolStripMenuItem.Text = "Rejected";
            this.reviewRejectedToolStripMenuItem.Click += new System.EventHandler(this.setStateToolStripMenuItem_Click);
            // 
            // reviewCancelledToolStripMenuItem
            // 
            this.reviewCancelledToolStripMenuItem.Name = "reviewCancelledToolStripMenuItem";
            this.reviewCancelledToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.reviewCancelledToolStripMenuItem.Text = "Cancelled";
            this.reviewCancelledToolStripMenuItem.Click += new System.EventHandler(this.setStateToolStripMenuItem_Click);
            // 
            // reviewNoneToolStripMenuItem
            // 
            this.reviewNoneToolStripMenuItem.Name = "reviewNoneToolStripMenuItem";
            this.reviewNoneToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.reviewNoneToolStripMenuItem.Text = "None";
            this.reviewNoneToolStripMenuItem.Click += new System.EventHandler(this.setStateToolStripMenuItem_Click);
            // 
            // stateHistoryToolStripMenuItem
            // 
            this.stateHistoryToolStripMenuItem.Name = "stateHistoryToolStripMenuItem";
            this.stateHistoryToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.stateHistoryToolStripMenuItem.Text = "State History...";
            this.stateHistoryToolStripMenuItem.Click += new System.EventHandler(this.stateHistoryToolStripMenuItem_Click);
            // 
            // showStateHistoryToolStripMenuItem
            // 
            this.showStateHistoryToolStripMenuItem.CheckOnClick = true;
            this.showStateHistoryToolStripMenuItem.Name = "showStateHistoryToolStripMenuItem";
            this.showStateHistoryToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.showStateHistoryToolStripMenuItem.Text = "Show State History In Replies";
            this.showStateHistoryToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showStateHistoryToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.propertiesToolStripMenuItem.Text = "Properties...";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.Location = new System.Drawing.Point(0, 25);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(37, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "name";
            // 
            // rightHeaderflowLayoutPanel
            // 
            this.rightHeaderflowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rightHeaderflowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.rightHeaderflowLayoutPanel.Controls.Add(this.expandButton);
            this.rightHeaderflowLayoutPanel.Controls.Add(this.closeButton);
            this.rightHeaderflowLayoutPanel.Controls.Add(this.settingsButton);
            this.rightHeaderflowLayoutPanel.Controls.Add(this.lockIconLabel);
            this.rightHeaderflowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.rightHeaderflowLayoutPanel.Location = new System.Drawing.Point(209, 0);
            this.rightHeaderflowLayoutPanel.Name = "rightHeaderflowLayoutPanel";
            this.rightHeaderflowLayoutPanel.Size = new System.Drawing.Size(93, 25);
            this.rightHeaderflowLayoutPanel.TabIndex = 6;
            this.rightHeaderflowLayoutPanel.WrapContents = false;
            // 
            // expandButton
            // 
            this.expandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expandButton.Location = new System.Drawing.Point(70, 1);
            this.expandButton.Margin = new System.Windows.Forms.Padding(1);
            this.expandButton.Name = "expandButton";
            this.expandButton.Size = new System.Drawing.Size(22, 22);
            this.expandButton.TabIndex = 6;
            this.expandButton.UseVisualStyleBackColor = true;
            this.expandButton.Click += new System.EventHandler(this.expandButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(46, 1);
            this.closeButton.Margin = new System.Windows.Forms.Padding(1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(22, 22);
            this.closeButton.TabIndex = 2;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.Location = new System.Drawing.Point(22, 1);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(1);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(22, 22);
            this.settingsButton.TabIndex = 5;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // lockIconLabel
            // 
            this.lockIconLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lockIconLabel.Image = ((System.Drawing.Image)(resources.GetObject("lockIconLabel.Image")));
            this.lockIconLabel.Location = new System.Drawing.Point(4, 4);
            this.lockIconLabel.Margin = new System.Windows.Forms.Padding(3, 4, 1, 3);
            this.lockIconLabel.Name = "lockIconLabel";
            this.lockIconLabel.Size = new System.Drawing.Size(16, 16);
            this.lockIconLabel.TabIndex = 8;
            // 
            // CommentControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.mainFlowLayoutPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(5, 5);
            this.Name = "CommentControl";
            this.Size = new System.Drawing.Size(304, 172);
            this.mainFlowLayoutPanel.ResumeLayout(false);
            this.mainFlowLayoutPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.commentContextMenuStrip.ResumeLayout(false);
            this.rightHeaderflowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label modifyDateLabel;
        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.FlowLayoutPanel repliesFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel mainFlowLayoutPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.FlowLayoutPanel rightHeaderflowLayoutPanel;
        private System.Windows.Forms.Button expandButton;
        private System.Windows.Forms.ContextMenuStrip commentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replyToolStripMenuItem;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem collapseRepliesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseAllButThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem reviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewAcceptedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewCompletedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewRejectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewCancelledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStateHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStrip statesToolStrip;
        private System.Windows.Forms.Label lockIconLabel;
    }
}
#endif