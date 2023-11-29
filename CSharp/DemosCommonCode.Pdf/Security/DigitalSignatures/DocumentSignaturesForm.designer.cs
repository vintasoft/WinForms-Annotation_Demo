namespace DemosCommonCode.Pdf.Security
{
    partial class DocumentSignaturesForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.vefifyAllButton = new System.Windows.Forms.Button();
            this.signaturesTreeView = new System.Windows.Forms.TreeView();
            this.saveDocumentRevisionButton = new System.Windows.Forms.Button();
            this.useSigningCertificateChainToBuildChainCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(541, 26);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // vefifyAllButton
            // 
            this.vefifyAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vefifyAllButton.AutoSize = true;
            this.vefifyAllButton.Location = new System.Drawing.Point(3, 26);
            this.vefifyAllButton.Name = "vefifyAllButton";
            this.vefifyAllButton.Size = new System.Drawing.Size(146, 23);
            this.vefifyAllButton.TabIndex = 5;
            this.vefifyAllButton.Text = "Verify All Signatures";
            this.vefifyAllButton.UseVisualStyleBackColor = true;
            this.vefifyAllButton.Click += new System.EventHandler(this.verifyAllButton_Click);
            // 
            // signaturesTreeView
            // 
            this.signaturesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signaturesTreeView.HideSelection = false;
            this.signaturesTreeView.Location = new System.Drawing.Point(12, 12);
            this.signaturesTreeView.Name = "signaturesTreeView";
            this.signaturesTreeView.Size = new System.Drawing.Size(600, 371);
            this.signaturesTreeView.TabIndex = 6;
            this.signaturesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.signaturesTreeView_AfterSelect);
            this.signaturesTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.signaturesTreeView_NodeMouseClick);
            // 
            // saveDocumentRevisionButton
            // 
            this.saveDocumentRevisionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveDocumentRevisionButton.AutoSize = true;
            this.saveDocumentRevisionButton.Location = new System.Drawing.Point(155, 26);
            this.saveDocumentRevisionButton.Name = "saveDocumentRevisionButton";
            this.saveDocumentRevisionButton.Size = new System.Drawing.Size(183, 23);
            this.saveDocumentRevisionButton.TabIndex = 7;
            this.saveDocumentRevisionButton.Text = "Save Document Resivion As...";
            this.saveDocumentRevisionButton.UseVisualStyleBackColor = true;
            this.saveDocumentRevisionButton.Click += new System.EventHandler(this.saveDocumentRevisionButton_Click);
            // 
            // useSigningCertificateChainToBuildChainCheckBox
            // 
            this.useSigningCertificateChainToBuildChainCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.useSigningCertificateChainToBuildChainCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.useSigningCertificateChainToBuildChainCheckBox, 3);
            this.useSigningCertificateChainToBuildChainCheckBox.Location = new System.Drawing.Point(3, 3);
            this.useSigningCertificateChainToBuildChainCheckBox.Name = "useSigningCertificateChainToBuildChainCheckBox";
            this.useSigningCertificateChainToBuildChainCheckBox.Size = new System.Drawing.Size(463, 17);
            this.useSigningCertificateChainToBuildChainCheckBox.TabIndex = 8;
            this.useSigningCertificateChainToBuildChainCheckBox.Text = "Use certificate chain from signature to build and verify certificate chain (no re" +
    "vocation check)";
            this.useSigningCertificateChainToBuildChainCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.vefifyAllButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.useSigningCertificateChainToBuildChainCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveDocumentRevisionButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.okButton, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 390);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 52);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // DocumentSignaturesForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.signaturesTreeView);
            this.Name = "DocumentSignaturesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Document Signatures";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button vefifyAllButton;
        private System.Windows.Forms.TreeView signaturesTreeView;
        private System.Windows.Forms.Button saveDocumentRevisionButton;
        private System.Windows.Forms.CheckBox useSigningCertificateChainToBuildChainCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}