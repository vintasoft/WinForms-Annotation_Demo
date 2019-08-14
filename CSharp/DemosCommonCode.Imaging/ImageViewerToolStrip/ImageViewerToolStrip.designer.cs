using System.Windows.Forms;

namespace DemosCommonCode.Imaging
{
    partial class ImageViewerToolStrip
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewerToolStrip));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.scanCaptureSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.printButton = new System.Windows.Forms.ToolStripButton();
            this.printSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mainLabel = new System.Windows.Forms.ToolStripLabel();
            this.firstPageButton = new System.Windows.Forms.ToolStripButton();
            this.previousPageButton = new System.Windows.Forms.ToolStripButton();
            this.selectedPageIndexTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.slashLabel = new System.Windows.Forms.ToolStripLabel();
            this.pageCountLabel = new System.Windows.Forms.ToolStripLabel();
            this.nextPageButton = new System.Windows.Forms.ToolStripButton();
            this.lastPageButton = new System.Windows.Forms.ToolStripButton();
            this.navigationSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.navigationLabel = new System.Windows.Forms.ToolStripLabel();
            this.instrumentsLabel = new System.Windows.Forms.ToolStripLabel();
            this.zoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.zoomValueTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.zoomInButton = new System.Windows.Forms.ToolStripButton();
            this.zoomModesButton = new System.Windows.Forms.ToolStripSplitButton();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestFitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToHeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelToPixelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomModesSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.scale25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanButton = new System.Windows.Forms.ToolStripButton();
            this.openSaveSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.captureFromCameraButton = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(23, 22);
            this.openButton.Text = "Open...";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.Text = "Save...";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // scanCaptureSeparator
            // 
            this.scanCaptureSeparator.Name = "scanCaptureSeparator";
            this.scanCaptureSeparator.Size = new System.Drawing.Size(6, 25);
            this.scanCaptureSeparator.Visible = false;
            // 
            // printButton
            // 
            this.printButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
            this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(23, 20);
            this.printButton.Text = "Print...";
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // printSeparator
            // 
            this.printSeparator.Name = "printSeparator";
            this.printSeparator.Size = new System.Drawing.Size(30, 25);
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = false;
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(20, 22);
            // 
            // firstPageButton
            // 
            this.firstPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.firstPageButton.Enabled = false;
            this.firstPageButton.Image = ((System.Drawing.Image)(resources.GetObject("firstPageButton.Image")));
            this.firstPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.firstPageButton.Name = "firstPageButton";
            this.firstPageButton.Size = new System.Drawing.Size(23, 20);
            this.firstPageButton.Text = "First page";
            this.firstPageButton.Click += new System.EventHandler(this.firstPageButton_Click);
            // 
            // previousPageButton
            // 
            this.previousPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previousPageButton.Enabled = false;
            this.previousPageButton.Image = ((System.Drawing.Image)(resources.GetObject("previousPageButton.Image")));
            this.previousPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(23, 20);
            this.previousPageButton.Text = "Previous page";
            this.previousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // selectedPageIndexTextBox
            // 
            this.selectedPageIndexTextBox.Enabled = false;
            this.selectedPageIndexTextBox.MaxLength = 8;
            this.selectedPageIndexTextBox.Name = "selectedPageIndexTextBox";
            this.selectedPageIndexTextBox.Size = new System.Drawing.Size(40, 23);
            this.selectedPageIndexTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.selectedPageIndexTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPages_KeyPress);
            this.selectedPageIndexTextBox.LostFocus += new System.EventHandler(this.selectedPageIndexTextBox_LostFocus);
            // 
            // slashLabel
            // 
            this.slashLabel.Name = "slashLabel";
            this.slashLabel.Size = new System.Drawing.Size(12, 15);
            this.slashLabel.Text = "/";
            // 
            // pageCountLabel
            // 
            this.pageCountLabel.Name = "pageCountLabel";
            this.pageCountLabel.Size = new System.Drawing.Size(13, 15);
            this.pageCountLabel.Text = "0";
            // 
            // nextPageButton
            // 
            this.nextPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextPageButton.Enabled = false;
            this.nextPageButton.Image = ((System.Drawing.Image)(resources.GetObject("nextPageButton.Image")));
            this.nextPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(23, 20);
            this.nextPageButton.Text = "Next page";
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // lastPageButton
            // 
            this.lastPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lastPageButton.Enabled = false;
            this.lastPageButton.Image = ((System.Drawing.Image)(resources.GetObject("lastPageButton.Image")));
            this.lastPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lastPageButton.Name = "lastPageButton";
            this.lastPageButton.Size = new System.Drawing.Size(23, 20);
            this.lastPageButton.Text = "Last page";
            this.lastPageButton.Click += new System.EventHandler(this.lastPageButton_Click);
            // 
            // navigationSeparator
            // 
            this.navigationSeparator.Name = "navigationSeparator";
            this.navigationSeparator.Size = new System.Drawing.Size(30, 25);
            // 
            // navigationLabel
            // 
            this.navigationLabel.AutoSize = false;
            this.navigationLabel.Name = "navigationLabel";
            this.navigationLabel.Size = new System.Drawing.Size(20, 22);
            // 
            // instrumentsLabel
            // 
            this.instrumentsLabel.AutoSize = false;
            this.instrumentsLabel.Name = "instrumentsLabel";
            this.instrumentsLabel.Size = new System.Drawing.Size(20, 22);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutButton.Enabled = false;
            this.zoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutButton.Image")));
            this.zoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(23, 20);
            this.zoomOutButton.Text = "Zoom out";
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomValueTextBox
            // 
            this.zoomValueTextBox.Enabled = false;
            this.zoomValueTextBox.Name = "zoomValueTextBox";
            this.zoomValueTextBox.Size = new System.Drawing.Size(40, 23);
            this.zoomValueTextBox.Text = "100%";
            this.zoomValueTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.zoomValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zoomTextBox_KeyPress);
            this.zoomValueTextBox.LostFocus += new System.EventHandler(this.zoomValueTextBox_LostFocus);
            // 
            // zoomInButton
            // 
            this.zoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInButton.Enabled = false;
            this.zoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInButton.Image")));
            this.zoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(23, 20);
            this.zoomInButton.Text = "Zoom in";
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomModesButton
            // 
            this.zoomModesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.zoomModesButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.bestFitToolStripMenuItem,
            this.fitToWidthToolStripMenuItem,
            this.fitToHeightToolStripMenuItem,
            this.pixelToPixelToolStripMenuItem,
            this.scaleToolStripMenuItem,
            this.zoomModesSeparator,
            this.scale25ToolStripMenuItem,
            this.scale50ToolStripMenuItem,
            this.scale100ToolStripMenuItem,
            this.scale200ToolStripMenuItem,
            this.scale400ToolStripMenuItem});
            this.zoomModesButton.Enabled = false;
            this.zoomModesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomModesButton.Name = "zoomModesButton";
            this.zoomModesButton.Size = new System.Drawing.Size(16, 4);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // bestFitToolStripMenuItem
            // 
            this.bestFitToolStripMenuItem.Name = "bestFitToolStripMenuItem";
            this.bestFitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.bestFitToolStripMenuItem.Text = "Best fit";
            this.bestFitToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // fitToWidthToolStripMenuItem
            // 
            this.fitToWidthToolStripMenuItem.Name = "fitToWidthToolStripMenuItem";
            this.fitToWidthToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.fitToWidthToolStripMenuItem.Text = "Fit to width";
            this.fitToWidthToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // fitToHeightToolStripMenuItem
            // 
            this.fitToHeightToolStripMenuItem.Name = "fitToHeightToolStripMenuItem";
            this.fitToHeightToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.fitToHeightToolStripMenuItem.Text = "Fit to height";
            this.fitToHeightToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // pixelToPixelToolStripMenuItem
            // 
            this.pixelToPixelToolStripMenuItem.Name = "pixelToPixelToolStripMenuItem";
            this.pixelToPixelToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.pixelToPixelToolStripMenuItem.Text = "Pixel to pixel";
            this.pixelToPixelToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scaleToolStripMenuItem.Text = "Scale";
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // zoomModesSeparator
            // 
            this.zoomModesSeparator.Name = "zoomModesSeparator";
            this.zoomModesSeparator.Size = new System.Drawing.Size(136, 6);
            // 
            // scale25ToolStripMenuItem
            // 
            this.scale25ToolStripMenuItem.Name = "scale25ToolStripMenuItem";
            this.scale25ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scale25ToolStripMenuItem.Text = "25%";
            this.scale25ToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // scale50ToolStripMenuItem
            // 
            this.scale50ToolStripMenuItem.Name = "scale50ToolStripMenuItem";
            this.scale50ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scale50ToolStripMenuItem.Text = "50%";
            this.scale50ToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // scale100ToolStripMenuItem
            // 
            this.scale100ToolStripMenuItem.Name = "scale100ToolStripMenuItem";
            this.scale100ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scale100ToolStripMenuItem.Text = "100%";
            this.scale100ToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // scale200ToolStripMenuItem
            // 
            this.scale200ToolStripMenuItem.Name = "scale200ToolStripMenuItem";
            this.scale200ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scale200ToolStripMenuItem.Text = "200%";
            this.scale200ToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // scale400ToolStripMenuItem
            // 
            this.scale400ToolStripMenuItem.Name = "scale400ToolStripMenuItem";
            this.scale400ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.scale400ToolStripMenuItem.Text = "400%";
            this.scale400ToolStripMenuItem.Click += new System.EventHandler(this.ImageScale_Click);
            // 
            // scanButton
            // 
            this.scanButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.scanButton.Image = ((System.Drawing.Image)(resources.GetObject("scanButton.Image")));
            this.scanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(23, 20);
            this.scanButton.ToolTipText = "Scan...";
            this.scanButton.Visible = false;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // openSaveSeparator
            // 
            this.openSaveSeparator.Name = "openSaveSeparator";
            this.openSaveSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // captureFromCameraButton
            // 
            this.captureFromCameraButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.captureFromCameraButton.Image = ((System.Drawing.Image)(resources.GetObject("captureFromCameraButton.Image")));
            this.captureFromCameraButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.captureFromCameraButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.captureFromCameraButton.Name = "captureFromCameraButton";
            this.captureFromCameraButton.Size = new System.Drawing.Size(23, 22);
            this.captureFromCameraButton.ToolTipText = "Capture from camera ...";
            this.captureFromCameraButton.Visible = false;
            this.captureFromCameraButton.Click += new System.EventHandler(this.captureFromCameraButton_Click);
            // 
            // ImageViewerToolStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openButton,
            this.saveButton,
            this.openSaveSeparator,
            this.scanButton,
            this.captureFromCameraButton,
            this.scanCaptureSeparator,
            this.printButton,
            this.printSeparator,
            this.firstPageButton,
            this.previousPageButton,
            this.selectedPageIndexTextBox,
            this.slashLabel,
            this.pageCountLabel,
            this.nextPageButton,
            this.lastPageButton,
            this.navigationSeparator,
            this.zoomOutButton,
            this.zoomValueTextBox,
            this.zoomModesButton,
            this.zoomInButton});
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;

        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripSeparator scanCaptureSeparator;
        private System.Windows.Forms.ToolStripButton scanButton;
        private System.Windows.Forms.ToolStripSeparator openSaveSeparator;
        private System.Windows.Forms.ToolStripButton printButton;
        private System.Windows.Forms.ToolStripSeparator printSeparator;
        private System.Windows.Forms.ToolStripLabel mainLabel;

        private System.Windows.Forms.ToolStripButton firstPageButton;
        private System.Windows.Forms.ToolStripButton previousPageButton;
        private System.Windows.Forms.ToolStripTextBox selectedPageIndexTextBox;
        private System.Windows.Forms.ToolStripLabel slashLabel;
        private System.Windows.Forms.ToolStripLabel pageCountLabel;
        private System.Windows.Forms.ToolStripButton nextPageButton;
        private System.Windows.Forms.ToolStripButton lastPageButton;
        private System.Windows.Forms.ToolStripSeparator navigationSeparator;
        private System.Windows.Forms.ToolStripLabel navigationLabel;
        private System.Windows.Forms.ToolStripLabel instrumentsLabel;

        private System.Windows.Forms.ToolStripButton zoomInButton;
        private System.Windows.Forms.ToolStripButton zoomOutButton;
        private System.Windows.Forms.ToolStripTextBox zoomValueTextBox;
        private System.Windows.Forms.ToolStripSplitButton zoomModesButton;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestFitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToHeightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelToPixelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator zoomModesSeparator;
        private System.Windows.Forms.ToolStripMenuItem scale25ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale50ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale400ToolStripMenuItem;
        private ToolStripButton captureFromCameraButton;
    }
}
