namespace DemosCommonCode.Imaging
{
    partial class ImageRenderingRequirementsForm
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
            this.codecComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codec";
            // 
            // codecComboBox
            // 
            this.codecComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codecComboBox.FormattingEnabled = true;
            this.codecComboBox.Location = new System.Drawing.Point(139, 17);
            this.codecComboBox.Name = "codecComboBox";
            this.codecComboBox.Size = new System.Drawing.Size(121, 23);
            this.codecComboBox.TabIndex = 1;
            this.codecComboBox.SelectedIndexChanged += new System.EventHandler(this.codecComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enable Rendering from";
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
            this.imageSizeComboBox.Location = new System.Drawing.Point(139, 46);
            this.imageSizeComboBox.Name = "megapixelsComboBox";
            this.imageSizeComboBox.Size = new System.Drawing.Size(121, 23);
            this.imageSizeComboBox.TabIndex = 3;
            this.imageSizeComboBox.TextChanged += new System.EventHandler(this.imageSizeComboBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Megapixels";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(129, 77);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(210, 77);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(332, 16);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(60, 23);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(266, 16);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(60, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add...";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // ImageRenderingRequirementsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(404, 112);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imageSizeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codecComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageRenderingRequirementsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Rendering Requirements";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox codecComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox imageSizeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
    }
}