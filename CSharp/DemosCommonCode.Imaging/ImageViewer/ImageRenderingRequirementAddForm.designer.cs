namespace DemosCommonCode.Imaging
{
    partial class ImageRenderingRequirementAddForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.codecComboBox = new System.Windows.Forms.ComboBox();
            this.imageSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(84, 66);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(165, 66);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // codecComboBox
            // 
            this.codecComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codecComboBox.FormattingEnabled = true;
            this.codecComboBox.Location = new System.Drawing.Point(140, 12);
            this.codecComboBox.Name = "codecComboBox";
            this.codecComboBox.Size = new System.Drawing.Size(121, 23);
            this.codecComboBox.TabIndex = 2;
            this.codecComboBox.SelectedIndexChanged += new System.EventHandler(this.codecComboBox_SelectedIndexChanged);
            // 
            // megapixelsComboBox
            // 
            this.imageSizeComboBox.FormattingEnabled = true;
            this.imageSizeComboBox.Items.AddRange(new object[] {
            "0.5",
            "1",
            "5",
            "10",
            "25",
            "50",
            "100"});
            this.imageSizeComboBox.Location = new System.Drawing.Point(140, 39);
            this.imageSizeComboBox.Name = "megapixelsComboBox";
            this.imageSizeComboBox.Size = new System.Drawing.Size(121, 23);
            this.imageSizeComboBox.TabIndex = 3;
            this.imageSizeComboBox.TextChanged += new System.EventHandler(this.imageSizeComboBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Codec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enable Rendering from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Megapixels";
            // 
            // ImageRenderingRequirementAddForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(346, 97);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageSizeComboBox);
            this.Controls.Add(this.codecComboBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageRenderingRequirementAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Rendering Requirement Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox codecComboBox;
        private System.Windows.Forms.ComboBox imageSizeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}