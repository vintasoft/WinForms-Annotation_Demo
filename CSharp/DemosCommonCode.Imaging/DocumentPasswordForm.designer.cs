namespace DemosCommonCode.Imaging
{
    partial class DocumentPasswordForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.authenticateTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Document is protected. Please enter a password.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTextBox.Location = new System.Drawing.Point(99, 64);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(192, 23);
            this.passwordTextBox.TabIndex = 2;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(135, 98);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 26);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(216, 98);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 26);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Authenticate as:";
            // 
            // authenticateTypeComboBox
            // 
            this.authenticateTypeComboBox.FormattingEnabled = true;
            this.authenticateTypeComboBox.Items.AddRange(new object[] {
            "User",
            "Owner"});
            this.authenticateTypeComboBox.Location = new System.Drawing.Point(99, 35);
            this.authenticateTypeComboBox.Name = "authenticateTypeComboBox";
            this.authenticateTypeComboBox.Size = new System.Drawing.Size(192, 23);
            this.authenticateTypeComboBox.TabIndex = 6;
            // 
            // DocumentPasswordForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(303, 136);
            this.Controls.Add(this.authenticateTypeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocumentPasswordForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Authentication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox authenticateTypeComboBox;
    }
}