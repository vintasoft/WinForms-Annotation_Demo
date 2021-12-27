
namespace DemosCommonCode.Office
{
    partial class SetOpenXmlParagraphNumerationForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.numerationDefinitionsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.externalNumerationsComboBox = new System.Windows.Forms.ComboBox();
            this.importButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(257, 156);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(176, 156);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // numerationDefinitionsListBox
            // 
            this.numerationDefinitionsListBox.FormattingEnabled = true;
            this.numerationDefinitionsListBox.Location = new System.Drawing.Point(12, 29);
            this.numerationDefinitionsListBox.Name = "numerationDefinitionsListBox";
            this.numerationDefinitionsListBox.Size = new System.Drawing.Size(138, 95);
            this.numerationDefinitionsListBox.TabIndex = 4;
            this.numerationDefinitionsListBox.SelectedIndexChanged += new System.EventHandler(this.numerationDefinitionsListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Numeration Definitions";
            // 
            // externalNumerationsComboBox
            // 
            this.externalNumerationsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.externalNumerationsComboBox.FormattingEnabled = true;
            this.externalNumerationsComboBox.Location = new System.Drawing.Point(163, 29);
            this.externalNumerationsComboBox.Name = "externalNumerationsComboBox";
            this.externalNumerationsComboBox.Size = new System.Drawing.Size(176, 21);
            this.externalNumerationsComboBox.TabIndex = 6;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(163, 56);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(176, 23);
            this.importButton.TabIndex = 7;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "External Numeration Definitions";
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(12, 130);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(138, 23);
            this.restartButton.TabIndex = 9;
            this.restartButton.Text = "Create Copy (Restart)";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // SetOpenXmlParagraphNumerationForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(344, 191);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.externalNumerationsComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numerationDefinitionsListBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetOpenXmlParagraphNumerationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Paragraph Numeration";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ListBox numerationDefinitionsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox externalNumerationsComboBox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button restartButton;
    }
}