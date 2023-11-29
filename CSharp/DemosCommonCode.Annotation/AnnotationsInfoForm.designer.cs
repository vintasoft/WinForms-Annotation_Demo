namespace DemosCommonCode.Annotation
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
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.creationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
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
            this.annoInfoListView.FullRowSelect = true;
            this.annoInfoListView.HideSelection = false;
            this.annoInfoListView.Location = new System.Drawing.Point(0, 0);
            this.annoInfoListView.Name = "annoInfoListView";
            this.annoInfoListView.Size = new System.Drawing.Size(605, 307);
            this.annoInfoListView.TabIndex = 0;
            this.annoInfoListView.UseCompatibleStateImageBehavior = false;
            this.annoInfoListView.View = System.Windows.Forms.View.Details;
            this.annoInfoListView.SelectedIndexChanged += new System.EventHandler(this.annoInfoListView_SelectedIndexChanged);
            // 
            // type
            // 
            this.type.Text = "Annotation";
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
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(436, 313);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(517, 313);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // AnnotationsInfoForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOk;
            this.ClientSize = new System.Drawing.Size(605, 346);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
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
		private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ColumnHeader creationDate;
        private System.Windows.Forms.Button buttonCancel;
    }
}