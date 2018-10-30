namespace AnnotationDemo
{
	partial class AnnotationsInfoForm
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
            this.annoInfoListView = new System.Windows.Forms.ListView();
            this.type = new System.Windows.Forms.ColumnHeader();
            this.locationColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.creationDate = new System.Windows.Forms.ColumnHeader();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // annoInfoListView
            // 
            this.annoInfoListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.annoInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.type,
            this.locationColumnHeader,
            this.creationDate});
            this.annoInfoListView.Location = new System.Drawing.Point(0, 0);
            this.annoInfoListView.Name = "annoInfoListView";
            this.annoInfoListView.Size = new System.Drawing.Size(605, 307);
            this.annoInfoListView.TabIndex = 0;
            this.annoInfoListView.UseCompatibleStateImageBehavior = false;
            this.annoInfoListView.View = System.Windows.Forms.View.Details;
            // 
            // type
            // 
            this.type.Text = "Annotation type";
            this.type.Width = 273;
            // 
            // locationColumnHeader
            // 
            this.locationColumnHeader.Text = "Location";
            this.locationColumnHeader.Width = 166;
            // 
            // creationDate
            // 
            this.creationDate.Text = "Creation time";
            this.creationDate.Width = 142;
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(265, 311);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // AnnotationsInfoForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(605, 346);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.annoInfoListView);
            this.Name = "AnnotationsInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Information about annotations";
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView annoInfoListView;
		private System.Windows.Forms.ColumnHeader type;
		private System.Windows.Forms.ColumnHeader locationColumnHeader;
		private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ColumnHeader creationDate;
	}
}