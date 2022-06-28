namespace DemosCommonCode.Imaging
{
    partial class SpellCheckManagerViewSettingsForm
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
            Vintasoft.Imaging.UI.VisualTools.UserInteraction.InteractionAreaAppearanceManager interactionAreaAppearanceManager7 = new Vintasoft.Imaging.UI.VisualTools.UserInteraction.InteractionAreaAppearanceManager();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.spellCheckManagerViewSettingsControl1 = new DemosCommonCode.Imaging.SpellCheckManagerViewSettingsControl();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(143, 118);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(224, 118);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // spellCheckManagerViewSettingsControl1
            // 
            this.spellCheckManagerViewSettingsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            interactionAreaAppearanceManager7.MoveAreaCursor = System.Windows.Forms.Cursors.SizeAll;
            interactionAreaAppearanceManager7.NortheastSouthwestResizePointCursor = System.Windows.Forms.Cursors.SizeNESW;
            interactionAreaAppearanceManager7.NorthSouthResizePointCursor = System.Windows.Forms.Cursors.SizeNS;
            interactionAreaAppearanceManager7.NorthwestSoutheastResizePointCursor = System.Windows.Forms.Cursors.SizeNWSE;
            interactionAreaAppearanceManager7.PolygonPointBorderPenWidth = 1F;
            interactionAreaAppearanceManager7.PolygonPointCursor = System.Windows.Forms.Cursors.Cross;
            interactionAreaAppearanceManager7.PolygonPointInteractionRadius = 4F;
            interactionAreaAppearanceManager7.PolygonPointRadius = 4F;
            interactionAreaAppearanceManager7.ResizePointsBorderPenWidth = 1F;
            interactionAreaAppearanceManager7.ResizePointsInteractionRadius = 4F;
            interactionAreaAppearanceManager7.ResizePointsRadius = 4F;
            interactionAreaAppearanceManager7.RotationAssistantBorderPenWidth = 1F;
            interactionAreaAppearanceManager7.RotationAssistantDiscreteAngle = 45F;
            interactionAreaAppearanceManager7.RotationAssistantRadius = 75F;
            interactionAreaAppearanceManager7.RotationPointBorderPenWidth = 1F;
            interactionAreaAppearanceManager7.RotationPointDistance = 20F;
            interactionAreaAppearanceManager7.RotationPointInteractionRadius = 4F;
            interactionAreaAppearanceManager7.RotationPointRadius = 4F;
            interactionAreaAppearanceManager7.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            interactionAreaAppearanceManager7.TextBoxCursor = System.Windows.Forms.Cursors.IBeam;
            interactionAreaAppearanceManager7.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            interactionAreaAppearanceManager7.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            interactionAreaAppearanceManager7.VisualTool = null;
            interactionAreaAppearanceManager7.WestEastResizePointCursor = System.Windows.Forms.Cursors.SizeWE;
            this.spellCheckManagerViewSettingsControl1.InteractionAreaSettings = interactionAreaAppearanceManager7;
            this.spellCheckManagerViewSettingsControl1.Location = new System.Drawing.Point(12, 12);
            this.spellCheckManagerViewSettingsControl1.MinimumSize = new System.Drawing.Size(212, 100);
            this.spellCheckManagerViewSettingsControl1.Name = "spellCheckManagerViewSettingsControl1";
            this.spellCheckManagerViewSettingsControl1.Size = new System.Drawing.Size(287, 100);
            this.spellCheckManagerViewSettingsControl1.TabIndex = 0;
            // 
            // SpellCheckManagerViewSettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(306, 149);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.spellCheckManagerViewSettingsControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SpellCheckManagerViewSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Spell check view settings";
            this.ResumeLayout(false);

        }

        #endregion

        private global::DemosCommonCode.Imaging.SpellCheckManagerViewSettingsControl spellCheckManagerViewSettingsControl1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
    }
}