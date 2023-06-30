#if !REMOVE_ANNOTATION_PLUGIN
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Annotation.Comments;
using Vintasoft.Imaging.Annotation.UI.Comments;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Represents a control that allows to display a comment in image viewer.
    /// </summary>
    /// <seealso cref="CommentTools"/>
    public partial class CommentControl : UserControl, ICommentControl
    {

        #region Constants

        /// <summary>
        /// The maximum count of nested replies.
        /// </summary>
        /// <remarks>
        /// This limitation is added because WinForms thrown Win32Exception if 48 or more controls are nested.
        /// </remarks>
        const int MAX_REPLY_NESTING_COUNT = 10;

        /// <summary>
        /// The resource file name format.
        /// </summary>
        const string RESOURCE_FILE_NAME_FORMAT = "DemosCommonCode.Annotation.Comments.Resources.{0}.png";

        /// <summary>
        /// The reply margin in pixels.
        /// </summary>
        const int REPLY_MARGIN = 2;

        /// <summary>
        /// The states panel height in pixels.
        /// </summary>
        const int STATES_PANEL_HEIGHT = 25;

        /// <summary>
        /// The WM_LBUTTONDOWN message code.
        /// </summary>
        const int WM_LBUTTONDOWN = 0x0201;

        /// <summary>
        /// The WM_RBUTTONDOWN message code.
        /// </summary>
        const int WM_RBUTTONDOWN = 0x0204;

        /// <summary>
        /// The WM_PARENTNOTIFY message code.
        /// </summary>
        const int WM_PARENTNOTIFY = 0x0210;

        #endregion



        #region Fields

        /// <summary>
        /// The expanded button image.
        /// </summary>
        static Image _expandedImage;

        /// <summary>
        /// The collapsed button image.
        /// </summary>
        static Image _collapsedImage;

        /// <summary>
        /// Dictionary: "Comment state" => "Icon image".
        /// </summary>
        static Dictionary<string, Image> _commentStateImages;


        /// <summary>
        /// Dictionary: "State name" => "Menu item".
        /// </summary>
        Dictionary<string, ToolStripMenuItem> _commentStateNameToMenuItem;

        /// <summary>
        /// Dictionary: "State comment" => "Label".
        /// </summary>
        Dictionary<Comment, ToolStripLabel> _commentStateToControl = new Dictionary<Comment, ToolStripLabel>();

        /// <summary>
        /// A value indicating whether UI is updating.
        /// </summary>
        bool _isUiUpdating = false;

        /// <summary>
        /// A value indicating whether control size is updating.
        /// </summary>
        bool _isSizeUpdating = false;

        /// <summary>
        /// A value indicating whether error occurs during updating of control size.
        /// </summary>
        bool _hasSizeUpdatingError = false;

        /// <summary>
        /// The control transformer.
        /// </summary>
        CommentControlTransformer _transformer = null;

        /// <summary>
        /// The current states of this comment.
        /// </summary>
        Comment[] _currentStates = null;

        /// <summary>
        /// The current text in the comment's text box.
        /// </summary>
        string _textBoxText = null;

        /// <summary>
        /// The current font of the text box.
        /// </summary>
        Font _textBoxFont = null;

        /// <summary>
        /// The current width of the text box.
        /// </summary>
        int _textBoxWidth = 0;

        /// <summary>
        /// The current height of the text box text.
        /// </summary>
        int _textBoxTextHeight = 0;

        #endregion



        #region Contructors

        /// <summary>
        /// Initializes the <see cref="CommentControl"/> class.
        /// </summary>
        static CommentControl()
        {
            _expandedImage = DemosResourcesManager.GetResourceAsBitmap(string.Format(RESOURCE_FILE_NAME_FORMAT, "CommentExpand"));
            _collapsedImage = DemosResourcesManager.GetResourceAsBitmap(string.Format(RESOURCE_FILE_NAME_FORMAT, "CommentCollapse"));

            string[] states = new string[] {
                "ReviewAccepted", "ReviewRejected", "ReviewCancelled", "ReviewCompleted", "ReviewNone"
            };
            _commentStateImages = new Dictionary<string, Image>();
            foreach (string state in states)
                _commentStateImages.Add(state, DemosResourcesManager.GetResourceAsBitmap(string.Format(RESOURCE_FILE_NAME_FORMAT, "CommentState_" + state)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentControl"/> class.
        /// </summary>
        public CommentControl()
        {
            InitializeComponent();

            Disposed += CommentControl_Disposed;

            _commentStateNameToMenuItem = new Dictionary<string, ToolStripMenuItem>();
            _commentStateNameToMenuItem.Add(CommentTools.COMMENT_STATE_REVIEW_ACCEPTED, reviewAcceptedToolStripMenuItem);
            _commentStateNameToMenuItem.Add(CommentTools.COMMENT_STATE_REVIEW_REJECTED, reviewRejectedToolStripMenuItem);
            _commentStateNameToMenuItem.Add(CommentTools.COMMENT_STATE_REVIEW_CANCELLED, reviewCancelledToolStripMenuItem);
            _commentStateNameToMenuItem.Add(CommentTools.COMMENT_STATE_REVIEW_COMPLETED, reviewCompletedToolStripMenuItem);
            _commentStateNameToMenuItem.Add(CommentTools.COMMENT_STATE_REVIEW_NONE, reviewNoneToolStripMenuItem);
            foreach (string stateName in _commentStateNameToMenuItem.Keys)
                _commentStateNameToMenuItem[stateName].Tag = stateName;

            showStateHistoryToolStripMenuItem.Checked = ShowStateHistory;
            AutoHeight = false;
            CanExpand = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentControl"/> class.
        /// </summary>
        /// <param name="comment">The comment.</param>
        public CommentControl(Comment comment)
            : this()
        {
            if (comment == null)
                throw new ArgumentNullException();
            Comment = comment;
            SetSize(true);
        }

        #endregion



        #region Properties

        bool _autoHeight = false;
        /// <summary>
        /// Gets or sets a value indicating whether control has automatic height.
        /// </summary>
        /// <value>
        /// Default value is <b>false</b>.
        /// </value>
        public bool AutoHeight
        {
            get
            {
                return _autoHeight;
            }
            set
            {
                if (_autoHeight != value)
                {
                    _autoHeight = value;
                    repliesFlowLayoutPanel.AutoScroll = !value;
                    if (value)
                    {
                        SetSize(true);
                    }
                }
            }
        }

        bool _canClose = true;
        /// <summary>
        /// Gets or sets a value indicating whether this control can be closed.
        /// </summary>
        /// <value>
        /// Default value is <b>true</b>.
        /// </value>
        public bool CanClose
        {
            get
            {
                return _canClose;
            }
            set
            {
                _canClose = value;
                if (value)
                {
                    rightHeaderflowLayoutPanel.Controls.Add(closeButton);
                    rightHeaderflowLayoutPanel.Controls.SetChildIndex(closeButton, 0);
                }
                else
                {
                    rightHeaderflowLayoutPanel.Controls.Remove(closeButton);
                }
            }
        }

        bool _canExpand = true;
        /// <summary>
        /// Gets or sets a value indicating whether this control can be expanded.
        /// </summary>
        /// <value>
        /// Default value is <b>true</b>.
        /// </value>
        public bool CanExpand
        {
            get
            {
                return _canExpand;
            }
            set
            {
                _canExpand = value;
                if (value)
                {
                    rightHeaderflowLayoutPanel.Controls.Add(expandButton);
                    rightHeaderflowLayoutPanel.Controls.SetChildIndex(expandButton, 0);
                }
                else
                {
                    rightHeaderflowLayoutPanel.Controls.Remove(expandButton);
                }
            }
        }

        bool _showStateHistory = false;
        /// <summary>
        /// Gets or sets a value indicating whether control must show states in replies.
        /// </summary>
        /// <value>
        /// Default value is <b>false</b>.
        /// </value>
        public bool ShowStateHistory
        {
            get
            {
                return _showStateHistory;
            }
            set
            {
                if (_showStateHistory != value)
                {
                    _showStateHistory = value;
                    showStateHistoryToolStripMenuItem.Checked = value;
                    UpdateReplies();
                    foreach (CommentControl reply in repliesFlowLayoutPanel.Controls)
                        reply.ShowStateHistory = value;
                    SetSize(false);
                }
            }
        }


        Comment _comment;
        /// <summary>
        /// Gets or sets the comment that is displayed in control.
        /// </summary>
        public Comment Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                if (_comment != null)
                {
                    _comment.PropertyChanged -= Comment_PropertyChanged;
                    if (_comment.Replies != null)
                        _comment.Replies.Changed -= CommentReplies_Changed;
                    _comment.StatesChanged -= Comment_StatesChanged;
                    ClearRepliesPanel();
                }

                _comment = value;

                if (_comment != null)
                {
                    _comment.PropertyChanged += Comment_PropertyChanged;
                    if (_comment.Replies != null)
                        _comment.Replies.Changed += CommentReplies_Changed;
                    _comment.StatesChanged += Comment_StatesChanged;
                }
                UpdateUI();
                UpdateReplies();
            }
        }


        /// <summary>
        /// Gets the size of the top panel.
        /// </summary>
        public Size TopPanelSize
        {
            get
            {
                return topPanel.Size;
            }
        }

        bool _isCommentSelected = false;
        /// <summary>
        /// Gets or sets a value indicating whether the comment is selected.
        /// </summary>
        /// <value>
        /// <b>true</b> if the comment is selected; otherwise, <b>false</b>.
        /// </value>
        public bool IsCommentSelected
        {
            get
            {
                return _isCommentSelected;
            }
            set
            {
                if (_isCommentSelected != value)
                {
                    _isCommentSelected = value;

                    OnIsCommentSelectedChanged(this, new PropertyChangedEventArgs<bool>(!value, value));

                    if (value)
                    {
                        Control currentControl = this.Parent;
                        while (currentControl != null)
                        {
                            if (currentControl is CommentControl)
                            {
                                ((CommentControl)currentControl).IsCommentSelected = true;
                                break;
                            }

                            currentControl = currentControl.Parent;
                        }
                    }
                    else
                    {
                        foreach (Control control in repliesFlowLayoutPanel.Controls)
                        {
                            if (control is CommentControl)
                                ((CommentControl)control).IsCommentSelected = false;
                        }
                    }
                }
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Selects the comment.
        /// </summary>
        public void SelectComment()
        {
            IsCommentSelected = true;
        }

        /// <summary>
        /// Sets the focus to specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        public void SetFocus(Comment comment)
        {
            CommentControl control = (CommentControl)FindCommentControl(comment);
            if (control != null)
                control.textTextBox.Focus();
        }

        /// <summary>
        /// Searches the comment control that displays specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>
        /// Comment control that diplays specified comment.
        /// </returns>
        public ICommentControl FindCommentControl(Comment comment)
        {
            if (Comment == comment)
                return this;
            foreach (ICommentControl control in repliesFlowLayoutPanel.Controls)
            {
                ICommentControl result = control.FindCommentControl(comment);
                if (result != null)
                    return result;
            }
            return null;
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Raises the <see cref="E:IsCommentSelectedChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs{T}"/> instance containing the event data.</param>
        protected virtual void OnIsCommentSelectedChanged(object sender, PropertyChangedEventArgs<bool> e)
        {
            if (IsCommentSelectedChanged != null)
                IsCommentSelectedChanged(sender, e);
        }

        /// <summary>
        /// Raises the <see cref="E:SizeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (Comment != null)
                SetSize(true);
        }

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m"> The Windows<see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PARENTNOTIFY)
            {
                switch ((int)m.WParam)
                {
                    case WM_LBUTTONDOWN:
                    case WM_RBUTTONDOWN:
                        if (Comment.IsOpen)
                            SelectComment();
                        break;
                }
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Raises the <see cref="E:ParentChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            // remove old transformer
            if (_transformer != null)
            {
                _transformer.Dispose();
                _transformer = null;
            }

            // if this control is located on image viewer
            if (GetParentControl<ImageViewer>(Parent) != null &&
                GetParentControl<CommentControl>(Parent) == null)
                _transformer = new CommentControlTransformer(this);
        }

        #endregion


        #region INTERNAL

        /// <summary>
        /// Sets size of control.
        /// </summary>
        internal void SetSize()
        {
            SetSize(true);
        }

        /// <summary>
        /// Updates the User Interface.
        /// </summary>
        internal void UpdateUI()
        {
            _isUiUpdating = true;
            if (Comment != null && Comment.Source!=null)
            {
                if (Comment.IsOpen)
                    expandButton.Image = _collapsedImage;
                else
                    expandButton.Image = _expandedImage;

                UpdateHeaderUI();

                if (Comment.ModifyDate != DateTime.MinValue)
                    modifyDateLabel.Text = Comment.ModifyDate.ToString();
                else
                    modifyDateLabel.Text = "";

                UpdateStatesUI();

                UpdateValueUI();

                if (Comment.Color.ToArgb() == Color.Black.ToArgb())
                    BackColor = Color.Gray;
                else
                    BackColor = GetLightenColor(Comment.Color);

                if (Comment.IsReadOnly)
                {
                    replyToolStripMenuItem.Enabled = false;
                    removeToolStripMenuItem.Enabled = false;
                }
                else
                {
                    replyToolStripMenuItem.Enabled = true;
                    removeToolStripMenuItem.Enabled = true;
                }

                if (GetCommentNestingCount(Comment) >= MAX_REPLY_NESTING_COUNT)
                    replyToolStripMenuItem.Enabled = false;
            }
            _isUiUpdating = false;
        }


        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the SizeChanged event of ReplyControl object.
        /// </summary>
        private void ReplyControl_SizeChanged(object sender, EventArgs e)
        {
            // if size must be updated
            if (!_isSizeUpdating)
                // update control size
                SetSize(true);
        }

        /// <summary>
        /// Handles the TextChanged event of TextTextBox object.
        /// </summary>
        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            // if size must be updated
            if (SetTextBoxHeight())
                // update size
                SetSize(false);

            // if user is not updating
            if (!_isUiUpdating)
            {
                // get current text
                string text = textTextBox.Text;
                if (text != null)
                    // remove invalid new line sumbols
                    text = text.Replace("\r\n", "\n");

                // update text
                Comment.Text = text;
            }
        }

        /// <summary>
        /// Handles the Disposed event of CommentControl object.
        /// </summary>
        private void CommentControl_Disposed(object sender, EventArgs e)
        {
            // remove comment
            Comment = null;
        }


        #region Buttons

        /// <summary>
        /// Handles the Click event of CloseButton object.
        /// </summary>
        private void closeButton_Click(object sender, EventArgs e)
        {
            // hide current control
            Visible = false;
            // close comment
            Comment.IsOpen = false;
            // deselect the current comment
            IsCommentSelected = false;
        }

        /// <summary>
        /// Handles the Click event of ExpandButton object.
        /// </summary>
        private void expandButton_Click(object sender, EventArgs e)
        {
            // if the current comment is open
            if (Comment.IsOpen)
            {
                // close the current comment
                Comment.IsOpen = false;
                // deselect the current comment
                IsCommentSelected = false;
            }
            else
            {
                // open the current comment
                Comment.IsOpen = true;
                // select the current comment
                IsCommentSelected = true;
            }
        }

        /// <summary>
        /// Handles the Click event of SettingsButton object.
        /// </summary>
        private void settingsButton_Click(object sender, EventArgs e)
        {
            // show context menu
            commentContextMenuStrip.Show(settingsButton, new Point(0, 0));
        }

        /// <summary>
        /// Handles the Click event of StateHistoryToolStripMenuItem object.
        /// </summary>
        private void stateHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create the comment state history
            using (CommentStateHistoryForm dlg = new CommentStateHistoryForm(Comment))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Owner = this.ParentForm;

                // show dialog
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of PropertiesToolStripMenuItem object.
        /// </summary>
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create the comment properties form
            using (CommentPropertiesForm dlg = new CommentPropertiesForm(Comment))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Owner = this.ParentForm;

                // show dialog
                dlg.ShowDialog();
                // update user interface
                UpdateUI();
            }
        }

        /// <summary>
        /// Handles the Click event of RemoveToolStripMenuItem object.
        /// </summary>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // remove current comment
            Comment.Remove();
        }

        /// <summary>
        /// Handles the Click event of ReplyToolStripMenuItem object.
        /// </summary>
        private void replyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add reply to the current comment
            Comment reply = Comment.AddReply(Color.Yellow, GetCurrentUserName());
            // move focus to the reply
            SetFocus(reply);
        }

        /// <summary>
        /// Handles the Click event of ExpandAllToolStripMenuItem object.
        /// </summary>
        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // expand all replies
            Comment.Expand();
        }

        /// <summary>
        /// Handles the Click event of CollapseRepliesToolStripMenuItem object.
        /// </summary>
        private void collapseRepliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // for each comment in the current comment replies
            foreach (Comment reply in Comment.Replies)
                // collapse the reply
                reply.Collapse();
        }

        /// <summary>
        /// Handles the Click event of ResetLocationToolStripMenuItem object.
        /// </summary>
        private void resetLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset comment location
            Comment.ResetBoundingBox();
        }

        /// <summary>
        /// Handles the Click event of CollapseAllButThisToolStripMenuItem object.
        /// </summary>
        private void collapseAllButThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get parent comment collection
            CommentCollection parentCollection = Comment.ParentCollection;
            while (parentCollection != null)
            {
                // for each comment in parent collection
                foreach (Comment rootComment in parentCollection)
                {
                    // if comment must be closed
                    if (rootComment.FindCommentBySource(Comment.Source) == null)
                        // close comment
                        rootComment.IsOpen = false;
                }

                // if comment does not contain a parent
                if (parentCollection.Parent == null)
                    break;

                // get the parent comment collection
                parentCollection = parentCollection.Parent.ParentCollection;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of ShowStateHistoryToolStripMenuItem object.
        /// </summary>
        private void showStateHistoryToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // if states must be shown in replies
            if (showStateHistoryToolStripMenuItem.Checked)
                // show the states in replies
                ShowStateHistory = true;
            else
                // hide the states in replies
                ShowStateHistory = false;
        }

        /// <summary>
        /// Handles the Click event of SetStateToolStripMenuItem object.
        /// </summary>
        private void setStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get current tool strip menu item
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            // get state nema
            string stateName = (string)menuItem.Tag;

            string[] parsedName = stateName.Split('.');
            // get state model
            string stateModel = parsedName[0];
            // get state
            string state = parsedName[1];

            // set comment state
            Comment stateComment = Comment.SetState(Color.Yellow, GetCurrentUserName(), stateModel, state, CommentTools.SPLIT_STATES_BY_USER_NAME);
            // close comment state
            stateComment.IsOpen = false;
            // update comment state text
            stateComment.Text = string.Format("{0} sets by {1}", state, stateComment.UserName);
        }

        #endregion

        #endregion


        /// <summary>
        /// Handles the Comment.PropertyChanged event.
        /// </summary>
        private void Comment_PropertyChanged(object sender, Vintasoft.Imaging.ObjectPropertyChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<ObjectPropertyChangedEventArgs>(Comment_PropertyChanged), sender, e);
            }
            else
            {
                if (e.PropertyName == "IsOpen")
                {
                    SetSize(true);
                    UpdateHeaderUI();
                    UpdateValueUI();
                    if (CanExpand)
                    {
                        if ((bool)e.NewValue)
                            expandButton.Image = _collapsedImage;
                        else
                            expandButton.Image = _expandedImage;
                    }

                    IsCommentSelected = (bool)e.NewValue;
                }
                else if (e.PropertyName == "BoundingBox")
                {
                }
                else
                {
                    if (e.PropertyName == "IsReadOnly")
                        SetSize(false);
                    UpdateUI();
                }
            }
        }

        /// <summary>
        /// Updates the comment value.
        /// </summary>
        private void UpdateValueUI()
        {
            string text = Comment.Text;

            if (text != null)
            {
                text = text.Replace("\r\n", "\n");
                text = text.Replace("\n\r", "\n");
                text = text.Replace("\n", "\r\n");
            }

            textTextBox.Text = text;
            textTextBox.ReadOnly = Comment.IsReadOnly;
        }

        /// <summary>
        /// Sets size of control.
        /// </summary>
        /// <param name="setRepliesSize">Indicates that replies size must be set.</param>
        private void SetSize(bool setRepliesSize)
        {
            _isSizeUpdating = true;

            SuspendLayout();
            // if comment is closed
            if (!Comment.IsOpen)
            {
                // for each reply
                foreach (Control replyControl in repliesFlowLayoutPanel.Controls)
                    // hide reply control
                    replyControl.Visible = false;
            }

            // set width of body
            statesToolStrip.Width = mainFlowLayoutPanel.ClientSize.Width - statesToolStrip.Left * 2;
            textTextBox.Width = mainFlowLayoutPanel.ClientSize.Width - textTextBox.Left * 2;
            repliesFlowLayoutPanel.Width = mainFlowLayoutPanel.ClientSize.Width - repliesFlowLayoutPanel.Left * 2;

            // set height of text box
            SetTextBoxHeight();

            ResumeLayout();

            // calculate height of all reply controls
            int repliesFlowLayoutPanelHeight = 0;
            foreach (CommentControl replyControl in repliesFlowLayoutPanel.Controls)
            {
                repliesFlowLayoutPanelHeight += replyControl.Height + replyControl.Margin.Vertical;
            }

            // set height of repliesFlowLayoutPanel
            if (AutoHeight)
            {
                if (CanExpand && !Comment.IsOpen)
                {
                    this.Height = topPanel.Height;
                }
                else
                {
                    repliesFlowLayoutPanel.Height = repliesFlowLayoutPanelHeight;
                    this.Height = topPanel.Height + textTextBox.Bottom + repliesFlowLayoutPanel.Height + 6;
                }
            }
            else
            {
                repliesFlowLayoutPanel.Height = Height - textTextBox.Bottom - topPanel.Height - 6;
            }

            SuspendLayout();

            // if replies size must be set
            if (!AutoHeight && setRepliesSize)
            {
                // for each reply
                foreach (CommentControl replyControl in repliesFlowLayoutPanel.Controls)
                    // set size of reply control
                    replyControl.SetSize(true);
            }

            // update reply controls size
            int verticalScrollBarWidth = 0;
            if (!AutoHeight && (repliesFlowLayoutPanel.Height < repliesFlowLayoutPanelHeight))
                verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
            foreach (CommentControl replyControl in repliesFlowLayoutPanel.Controls)
            {
                replyControl.Width = repliesFlowLayoutPanel.Width - replyControl.Left * 2 - verticalScrollBarWidth;
                if (setRepliesSize)
                {
                    if (_hasSizeUpdatingError)
                    {
                        ResumeLayout();
                        _isSizeUpdating = false;
                        return;
                    }

                    replyControl.SetSize(true);
                }
            }

            // if comment is open
            if (Comment.IsOpen)
            {
                // for each reply
                foreach (Control replyControl in repliesFlowLayoutPanel.Controls)
                {
                    try
                    {
                        // show reply control
                        replyControl.Visible = true;
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        // WinForms generates Win32Exception if 15 or more FlowLayoutPanel are nested

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _hasSizeUpdatingError = true;

                        ResumeLayout();
                        _isSizeUpdating = false;
                        return;
                    }
                }
            }

            ResumeLayout();
            _isSizeUpdating = false;
        }

        /// <summary>
        /// Sets the height of the text box.
        /// </summary>
        private bool SetTextBoxHeight()
        {
            int textHeight;
            string text = textTextBox.Text;
            if (Comment.IsReadOnly && string.IsNullOrEmpty(text))
                textHeight = 0;
            else
                textHeight = MeasureTextHeight(text, textTextBox);
            if (textTextBox.ClientSize.Height == textHeight)
                return false;
            textTextBox.ClientSize = new Size(textTextBox.ClientSize.Width, textHeight);
            return true;
        }

        /// <summary>
        /// Updates the replies panel.
        /// </summary>
        private void UpdateReplies()
        {
            ClearRepliesPanel();
            if (Comment != null && Comment.Replies != null)
            {
                foreach (Comment reply in Comment.Replies)
                {
                    if (ShowStateHistory || !reply.IsState)
                    {
                        AddReplyControl(reply);
                    }
                }
                UpdateReplyMargins();
            }
        }

        /// <summary>
        /// Clears the replies panel.
        /// </summary>
        private void ClearRepliesPanel()
        {
            Control[] replies = new Control[repliesFlowLayoutPanel.Controls.Count];
            repliesFlowLayoutPanel.Controls.CopyTo(replies, 0);
            repliesFlowLayoutPanel.Controls.Clear();
            foreach (Control control in replies)
            {
                if (control is CommentControl)
                {
                    ((CommentControl)control).Comment = null;
                    control.Dispose();
                }
            }
        }

        /// <summary>
        /// Updates the reply margins.
        /// </summary>
        private void UpdateReplyMargins()
        {
            ControlCollection repliesControls = repliesFlowLayoutPanel.Controls;
            if (repliesControls.Count > 0)
            {
                for (int i = 1; i < repliesControls.Count - 1; i++)
                {
                    repliesControls[i].Margin = new Padding(0, REPLY_MARGIN, 0, REPLY_MARGIN);
                }
                repliesControls[0].Margin = new Padding(0, 0, 0, REPLY_MARGIN);
                repliesControls[repliesControls.Count - 1].Margin = new Padding(0, REPLY_MARGIN, 0, 0);
            }
        }

        /// <summary>
        /// Updates the control header UI.
        /// </summary>
        private void UpdateHeaderUI()
        {
            lockIconLabel.Visible = Comment.IsReadOnly;

            // if comment does not represent state of the parent comment
            if (!Comment.IsState)
            {
                // if comment is open
                if (Comment.IsOpen)
                {
                    // update user name
                    userNameLabel.Text = Comment.UserName;
                }
                // if comment is closed
                else
                {
                    // get all replies without states
                    Comment[] replies = Comment.GetAllReplies(false);
                    if (replies.Length > 0)
                        // update user name
                        userNameLabel.Text = string.Format("{0} ({1} replies)", Comment.UserName, replies.Length);
                    else
                        // update user name
                        userNameLabel.Text = Comment.UserName;
                }
                if (!string.IsNullOrEmpty(Comment.Subject) && Comment.Subject != Comment.UserName)
                    nameLabel.Text = Comment.Subject;
                else
                    nameLabel.Text = Comment.Type;
            }
            // if comment represents state of the parent comment
            else
            {
                // show comment state
                if (string.IsNullOrEmpty(Comment.StateModel))
                    userNameLabel.Text = Comment.UserName;
                else
                    userNameLabel.Text = string.Format("{0} ({1})", Comment.UserName, Comment.StateModel);
                nameLabel.Text = Comment.ParentState;
            }
        }

        /// <summary>
        /// Updates the states UI.
        /// </summary>
        private void UpdateStatesUI()
        {
            Comment[] states;
            // if comment has parent state
            if (!string.IsNullOrEmpty(Comment.ParentState))
            {
                // comment status
                reviewToolStripMenuItem.Visible = false;
                stateHistoryToolStripMenuItem.Visible = false;
                states = null;
            }
            else
            {
                // comment
                reviewToolStripMenuItem.Visible = true;
                stateHistoryToolStripMenuItem.Visible = true;
                states = Comment.GetStates(CommentTools.SPLIT_STATES_BY_USER_NAME);
            }

            // update items of state menu item
            foreach (ToolStripMenuItem item in _commentStateNameToMenuItem.Values)
            {
                item.Enabled = !Comment.IsReadOnly;
                item.Checked = false;
            }
            if (states != null)
            {
                foreach (Comment state in states)
                {
                    if (!CommentTools.SPLIT_STATES_BY_USER_NAME || state.UserName == GetCurrentUserName())
                    {
                        ToolStripMenuItem item = null;
                        string stateName = string.Format("{0}.{1}", state.StateModel, state.ParentState);
                        if (_commentStateNameToMenuItem.TryGetValue(stateName, out item))
                            item.Checked = true;
                    }
                }
            }

            if (_currentStates != null)
            {
                foreach (Comment state in _currentStates)
                    UnsubscribeFromStateEvent(state);
            }
            _currentStates = states;

            bool heightChanged = false;

            // if comment does NOT have states
            if (states == null)
            {
                // hide statesToolStrip
                statesToolStrip.Items.Clear();
                _commentStateToControl.Clear();
                if (statesToolStrip.Height != 0)
                {
                    heightChanged = true;
                    statesToolStrip.Height = 0;
                }
            }
            // if comment has states
            else
            {
                // show statesToolStrip
                if (statesToolStrip.Height != STATES_PANEL_HEIGHT)
                {
                    statesToolStrip.Height = STATES_PANEL_HEIGHT;
                    heightChanged = true;
                }
                Comment[] oldStates = new Comment[_commentStateToControl.Count];
                _commentStateToControl.Keys.CopyTo(oldStates, 0);

                // update statesToolStrip items
                foreach (Comment oldState in oldStates)
                {
                    if (Array.IndexOf(states, oldState) < 0)
                    {
                        ToolStripLabel oldStateControl = _commentStateToControl[oldState];
                        statesToolStrip.Items.Remove(oldStateControl);
                        oldStateControl.Dispose();
                        _commentStateToControl.Remove(oldState);
                    }
                }
                foreach (Comment state in states)
                {
                    ShowState(state);
                    SubscribeToStateEvent(state);
                }
            }

            if (heightChanged)
                SetSize(false);
        }

        /// <summary>
        /// Subscribes to the state events.
        /// </summary>
        /// <param name="state">The state.</param>
        private void SubscribeToStateEvent(Comment state)
        {
            state.PropertyChanged += State_PropertyChanged;
        }

        /// <summary>
        /// Unsubscribe from the state events.
        /// </summary>
        /// <param name="state">The state.</param>
        private void UnsubscribeFromStateEvent(Comment state)
        {
            state.PropertyChanged -= State_PropertyChanged;
        }

        /// <summary>
        /// The state property is changed.
        /// </summary>
        private void State_PropertyChanged(object sender, ObjectPropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, "StateModel", StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(e.PropertyName, "ParentState", StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(e.PropertyName, "UserName", StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(e.PropertyName, "ModifyDate", StringComparison.InvariantCultureIgnoreCase))
            {
                bool isPropertyRemoved = false;

                if (e.NewValue == null ||
                    e.NewValue is string && string.IsNullOrEmpty((string)e.NewValue) ||
                    e.NewValue is DateTime && DateTime.MinValue == (DateTime)e.NewValue)
                    isPropertyRemoved = true;

                if (isPropertyRemoved)
                    UpdateStatesUI();
                else
                    ShowState(((Comment)sender));
            }
        }

        /// <summary>
        /// Shows the state in UI.
        /// </summary>
        /// <param name="state">The state.</param>
        private void ShowState(Comment state)
        {
            ToolStripLabel stateLabel = null;
            if (!_commentStateToControl.TryGetValue(state, out stateLabel))
            {
                stateLabel = new ToolStripLabel();
                stateLabel.ImageScaling = ToolStripItemImageScaling.None;

                _commentStateToControl.Add(state, stateLabel);
                statesToolStrip.Items.Add(stateLabel);
            }
            UpdateStateControl(stateLabel, state);

            if (string.IsNullOrEmpty(stateLabel.Text))
            {
                _commentStateToControl.Remove(state);
                statesToolStrip.Items.Remove(stateLabel);
            }
        }

        /// <summary>
        /// Updates the state control.
        /// </summary>
        /// <param name="stateLabel">The state label.</param>
        /// <param name="state">The state.</param>
        private void UpdateStateControl(ToolStripLabel stateLabel, Comment state)
        {
            string fullState = string.Format("{0}{1}", state.StateModel, state.ParentState);
            // if comment has image for comment state
            if (_commentStateImages.ContainsKey(fullState))
            {
                // display image and user name
                stateLabel.Image = _commentStateImages[fullState];
                stateLabel.Text = state.UserName;
            }
            // if comment does NOT have image for comment state
            else
            {
                // display state and user name
                stateLabel.Image = null;
                stateLabel.Text = string.Format("{0}: {1}", state.ParentState, state.UserName);
            }

            // set tooltip for state label
            stateLabel.ToolTipText = string.Format("{0}, {1}: {2} ({3})", state.UserName, state.StateModel, state.ParentState, state.ModifyDate.ToString());
        }


        #region Tools

        /// <summary> 
        /// Returns the specified parent control.
        /// </summary>
        /// <param name="control">The control.</param>
        private T GetParentControl<T>(Control control)
            where T : Control
        {
            if (control == null)
                return null;

            if (control is T)
                return (T)control;

            if (control.Parent == null)
                return null;

            return GetParentControl<T>(control.Parent);
        }


        /// <summary>
        /// Adds the reply control to the reply panel.
        /// </summary>
        /// <param name="reply">The reply.</param>
        private void AddReplyControl(Comment reply)
        {
            if (GetCommentNestingCount(reply) > MAX_REPLY_NESTING_COUNT)
                return;

            if (_hasSizeUpdatingError)
                return;

            CommentControl replyControl = new CommentControl(reply);
            replyControl.ShowStateHistory = ShowStateHistory;
            replyControl.AutoHeight = true;
            replyControl.CanClose = false;
            replyControl.CanExpand = true;
            replyControl.Width = repliesFlowLayoutPanel.ClientSize.Width;
            replyControl.SizeChanged += ReplyControl_SizeChanged;

            try
            {
                repliesFlowLayoutPanel.Controls.Add(replyControl);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                repliesFlowLayoutPanel.Controls.Remove(replyControl);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _hasSizeUpdatingError = true;
            }
        }

        /// <summary>
        /// Returns the name of the current user.
        /// </summary>
        /// <returns>The name of the current user.</returns>
        private string GetCurrentUserName()
        {
            return Environment.UserName;
        }


        /// <summary>
        /// Returns a color that is lighter than specified color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Color that is lighter than specified color.</returns>
        private static Color GetLightenColor(Color color)
        {
            return Color.FromArgb(
                Math.Min(255, color.R + 96),
                Math.Min(255, color.G + 96),
                Math.Min(255, color.B + 96));
        }


        /// <summary>
        /// Handles the Comment.StatesChanged event.
        /// </summary>
        private void Comment_StatesChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(Comment_StatesChanged), sender, e);
            }
            else
            {
                UpdateStatesUI();
            }
        }

        /// <summary>
        /// Handles the Comment.Replies.Changed event.
        /// </summary>
        private void CommentReplies_Changed(object sender, CollectionChangeEventArgs<Comment> e)
        {
            if (IsDisposed || Comment == null || Comment.Source == null)
                return;
            if (InvokeRequired)
            {
                Invoke(new CollectionChangeEventHandler<Comment>(CommentReplies_Changed), sender, e);
            }
            else
            {
                // if reply is removed
                if (e.Action == CollectionChangeActionType.RemoveItem)
                {
                    // remove reply control
                    ICommentControl control = FindCommentControl((Comment)e.OldValue);
                    if (control != null)
                    {
                        repliesFlowLayoutPanel.Controls.Remove((Control)control);
                        control.Comment = null;
                        ((CommentControl)control).SizeChanged -= ReplyControl_SizeChanged;
                        ((CommentControl)control).Dispose();
                        SetSize(false);

                        _hasSizeUpdatingError = false;
                    }
                }
                // if reply is added
                else if (e.Action == CollectionChangeActionType.InsertItem)
                {
                    Comment newComment = (Comment)e.NewValue;
                    // if new reply must be displayed
                    if (ShowStateHistory || string.IsNullOrEmpty(newComment.ParentState))
                    {
                        // add reply control
                        AddReplyControl(newComment);
                        UpdateReplyMargins();
                        SetSize(false);
                        if (!Comment.IsOpen)
                            Comment.IsOpen = true;
                    }
                }
            }
        }

        /// <summary>
        /// Measures text height in specified text box.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="textBox">The text box.</param>
        private int MeasureTextHeight(string text, TextBox textBox)
        {
            // if text box text, font and width are the same
            if (textBox.Text == _textBoxText &&
                textBox.Font == _textBoxFont &&
                textBox.ClientSize.Width == _textBoxWidth)
            {
                // return previous text height
                return _textBoxTextHeight;
            }

            // save current text box properties
            _textBoxText = text;
            _textBoxFont = textBox.Font;
            _textBoxWidth = textBox.ClientSize.Width;

            // find count of lines, which are necessary for displaying text in text box
            int lineCount = 1 + textBox.GetLineFromCharIndex(text.Length);

            // calculate text height
            _textBoxTextHeight = lineCount * textBox.Font.Height;

            return _textBoxTextHeight;
        }

        /// <summary>
        /// Returns the nesting count of specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>
        /// The nesting count.
        /// </returns>
        private int GetCommentNestingCount(Comment comment)
        {
            int count = 0;
            Comment currentComment = comment;

            while (currentComment != null)
            {
                count++;
                currentComment = currentComment.Parent;
            }

            return count;
        }

        #endregion

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when the property <see cref="P:Vintasoft.Imaging.Annotation.UI.Comments.ICommentControl.IsCommentSelected" /> is changed.
        /// </summary>
        public event PropertyChangedEventHandler<bool> IsCommentSelectedChanged;

        #endregion

    }
}
#endif
