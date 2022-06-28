namespace DemosCommonCode.Annotation
{
    partial class CommentPropertiesForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.commonTabPage = new System.Windows.Forms.TabPage();
            this.isOpenCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.creationDateTimeTextBox = new System.Windows.Forms.TextBox();
            this.modifyDateTimeTextBox = new System.Windows.Forms.TextBox();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.colorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.isLockedCheckBox = new System.Windows.Forms.CheckBox();
            this.stateHistoryTabPage = new System.Windows.Forms.TabPage();
            this.commentStateHistoryControl1 = new DemosCommonCode.Annotation.CommentStateHistoryControl();
            this.advancedTabPage = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.okButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.commonTabPage.SuspendLayout();
            this.stateHistoryTabPage.SuspendLayout();
            this.advancedTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.commonTabPage);
            this.tabControl1.Controls.Add(this.stateHistoryTabPage);
            this.tabControl1.Controls.Add(this.advancedTabPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(485, 309);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // commonTabPage
            // 
            this.commonTabPage.Controls.Add(this.isOpenCheckBox);
            this.commonTabPage.Controls.Add(this.textBox);
            this.commonTabPage.Controls.Add(this.label7);
            this.commonTabPage.Controls.Add(this.creationDateTimeTextBox);
            this.commonTabPage.Controls.Add(this.modifyDateTimeTextBox);
            this.commonTabPage.Controls.Add(this.subjectTextBox);
            this.commonTabPage.Controls.Add(this.userNameTextBox);
            this.commonTabPage.Controls.Add(this.colorPanelControl);
            this.commonTabPage.Controls.Add(this.typeComboBox);
            this.commonTabPage.Controls.Add(this.label6);
            this.commonTabPage.Controls.Add(this.label5);
            this.commonTabPage.Controls.Add(this.label4);
            this.commonTabPage.Controls.Add(this.label3);
            this.commonTabPage.Controls.Add(this.label2);
            this.commonTabPage.Controls.Add(this.label1);
            this.commonTabPage.Controls.Add(this.isLockedCheckBox);
            this.commonTabPage.Location = new System.Drawing.Point(4, 22);
            this.commonTabPage.Name = "commonTabPage";
            this.commonTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.commonTabPage.Size = new System.Drawing.Size(477, 283);
            this.commonTabPage.TabIndex = 0;
            this.commonTabPage.Text = "Common";
            this.commonTabPage.UseVisualStyleBackColor = true;
            // 
            // isOpenCheckBox
            // 
            this.isOpenCheckBox.AutoSize = true;
            this.isOpenCheckBox.Location = new System.Drawing.Point(90, 6);
            this.isOpenCheckBox.Name = "isOpenCheckBox";
            this.isOpenCheckBox.Size = new System.Drawing.Size(52, 17);
            this.isOpenCheckBox.TabIndex = 19;
            this.isOpenCheckBox.Text = "Open";
            this.isOpenCheckBox.UseVisualStyleBackColor = true;
            this.isOpenCheckBox.CheckedChanged += new System.EventHandler(this.openCheckBox_CheckedChanged);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Location = new System.Drawing.Point(89, 185);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(379, 92);
            this.textBox.TabIndex = 18;
            this.textBox.Text = "<Text>";
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Text:";
            // 
            // creationDateTimeTextBox
            // 
            this.creationDateTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creationDateTimeTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.creationDateTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.creationDateTimeTextBox.HideSelection = false;
            this.creationDateTimeTextBox.Location = new System.Drawing.Point(89, 56);
            this.creationDateTimeTextBox.Name = "creationDateTimeTextBox";
            this.creationDateTimeTextBox.ReadOnly = true;
            this.creationDateTimeTextBox.Size = new System.Drawing.Size(379, 13);
            this.creationDateTimeTextBox.TabIndex = 16;
            this.creationDateTimeTextBox.Text = "<CreationDate>";
            // 
            // modifyDateTimeTextBox
            // 
            this.modifyDateTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modifyDateTimeTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.modifyDateTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modifyDateTimeTextBox.HideSelection = false;
            this.modifyDateTimeTextBox.Location = new System.Drawing.Point(89, 30);
            this.modifyDateTimeTextBox.Name = "modifyDateTimeTextBox";
            this.modifyDateTimeTextBox.ReadOnly = true;
            this.modifyDateTimeTextBox.Size = new System.Drawing.Size(379, 13);
            this.modifyDateTimeTextBox.TabIndex = 15;
            this.modifyDateTimeTextBox.Text = "<ModifyDate>";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.subjectTextBox.HideSelection = false;
            this.subjectTextBox.Location = new System.Drawing.Point(89, 159);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(379, 20);
            this.subjectTextBox.TabIndex = 12;
            this.subjectTextBox.Text = "<Subject>";
            this.subjectTextBox.TextChanged += new System.EventHandler(this.subjectTextBox_TextChanged);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userNameTextBox.HideSelection = false;
            this.userNameTextBox.Location = new System.Drawing.Point(89, 133);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(379, 20);
            this.userNameTextBox.TabIndex = 11;
            this.userNameTextBox.Text = "<UserName>";
            this.userNameTextBox.TextChanged += new System.EventHandler(this.userNameTextBox_TextChanged);
            // 
            // colorPanelControl
            // 
            this.colorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorPanelControl.CanEditAlphaChannel = false;
            this.colorPanelControl.Color = System.Drawing.Color.Transparent;
            this.colorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.colorPanelControl.Location = new System.Drawing.Point(89, 105);
            this.colorPanelControl.Name = "colorPanelControl";
            this.colorPanelControl.Size = new System.Drawing.Size(379, 22);
            this.colorPanelControl.TabIndex = 10;
            this.colorPanelControl.ColorChanged += new System.EventHandler(this.colorPanelControl_ColorChanged);
            // 
            // typeComboBox
            // 
            this.typeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(89, 78);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(379, 21);
            this.typeComboBox.TabIndex = 9;
            this.typeComboBox.TextChanged += new System.EventHandler(this.typeComboBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Subject:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "UserName:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Color:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Creation Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Modify Date:";
            // 
            // isLockedCheckBox
            // 
            this.isLockedCheckBox.AutoSize = true;
            this.isLockedCheckBox.Location = new System.Drawing.Point(11, 6);
            this.isLockedCheckBox.Name = "isLockedCheckBox";
            this.isLockedCheckBox.Size = new System.Drawing.Size(62, 17);
            this.isLockedCheckBox.TabIndex = 0;
            this.isLockedCheckBox.Text = "Locked";
            this.isLockedCheckBox.UseVisualStyleBackColor = true;
            this.isLockedCheckBox.CheckedChanged += new System.EventHandler(this.isReadOnlyCheckBox_CheckedChanged);
            // 
            // stateHistoryTabPage
            // 
            this.stateHistoryTabPage.Controls.Add(this.commentStateHistoryControl1);
            this.stateHistoryTabPage.Location = new System.Drawing.Point(4, 22);
            this.stateHistoryTabPage.Name = "stateHistoryTabPage";
            this.stateHistoryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.stateHistoryTabPage.Size = new System.Drawing.Size(477, 283);
            this.stateHistoryTabPage.TabIndex = 1;
            this.stateHistoryTabPage.Text = "State History";
            this.stateHistoryTabPage.UseVisualStyleBackColor = true;
            // 
            // commentStateHistoryControl1
            // 
#if !REMOVE_ANNOTATION_PLUGIN
            this.commentStateHistoryControl1.Comment = null;
#endif
            this.commentStateHistoryControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentStateHistoryControl1.Location = new System.Drawing.Point(3, 3);
            this.commentStateHistoryControl1.Name = "commentStateHistoryControl1";
            this.commentStateHistoryControl1.Size = new System.Drawing.Size(471, 277);
            this.commentStateHistoryControl1.TabIndex = 0;
            // 
            // advancedTabPage
            // 
            this.advancedTabPage.Controls.Add(this.propertyGrid1);
            this.advancedTabPage.Location = new System.Drawing.Point(4, 22);
            this.advancedTabPage.Name = "advancedTabPage";
            this.advancedTabPage.Size = new System.Drawing.Size(477, 283);
            this.advancedTabPage.TabIndex = 2;
            this.advancedTabPage.Text = "Advanced";
            this.advancedTabPage.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(477, 283);
            this.propertyGrid1.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(397, 316);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // CommentPropertiesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(484, 350);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 350);
            this.Name = "CommentPropertiesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comment Properties";
            this.tabControl1.ResumeLayout(false);
            this.commonTabPage.ResumeLayout(false);
            this.commonTabPage.PerformLayout();
            this.stateHistoryTabPage.ResumeLayout(false);
            this.advancedTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage commonTabPage;
        private System.Windows.Forms.TabPage stateHistoryTabPage;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabPage advancedTabPage;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private CommentStateHistoryControl commentStateHistoryControl1;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private CustomControls.ColorPanelControl colorPanelControl;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox isLockedCheckBox;
        private System.Windows.Forms.TextBox creationDateTimeTextBox;
        private System.Windows.Forms.TextBox modifyDateTimeTextBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox isOpenCheckBox;
    }
}