using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging;
using DemosCommonCode.Annotation;

namespace AnnotationDemo
{
	partial class MainForm
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
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard1 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance1 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance2 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance3 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance4 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailAppearance thumbnailAppearance5 = new Vintasoft.Imaging.UI.ThumbnailAppearance();
            Vintasoft.Imaging.UI.ThumbnailCaption thumbnailCaption1 = new Vintasoft.Imaging.UI.ThumbnailCaption();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings1 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableUndoRedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoRedoSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHistoryForDisplayedImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.thumbnailViewerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.imageDisplayModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleContinuousRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleContinuousColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoContinuousRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoContinuousColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestFitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToHeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelToPixelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorZoomModes = new System.Windows.Forms.ToolStripSeparator();
            this.scale25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scale400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateCounterclockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationViewerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interactionPointsSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boundAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveAnnotationsBetweenImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.spellCheckSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spellCheckViewSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.showEventsLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.colorManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationsInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.interactionModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationInteractionModeNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationInteractionModeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationInteractionModeAuthorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformationModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangularAndPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.loadFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.addAnnotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textHighlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embeddedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referencedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stickyNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freeTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rubberStampToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linesWithInterpolationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freehandLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonWithInterpolationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freehandPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.angleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.triangleCustomAnnotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markCustomAnnotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildAnnotationsContinuouslyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.bringToBackToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bringToFrontToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.multiSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.groupSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.rotateImageWithAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.burnAnnotationsOnImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneImageWithAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.thumbnailViewer1 = new Vintasoft.Imaging.Annotation.UI.AnnotatedThumbnailViewer();
            this.annotationViewer1 = new Vintasoft.Imaging.Annotation.UI.AnnotationViewer();
            this.annotationMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutAnnotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAnnotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteAnnotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAnnotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bringToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationViewerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.saveImageWithAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.burnAnnotationsOnImage2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyImageToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thumbnailMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.thumbnailMenu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.thumbnailMenu_Burn = new System.Windows.Forms.ToolStripMenuItem();
            this.thumbnailMenu_CopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.thumbnailMenu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.annotationEventsLog = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.propertiesTabPage = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.annotationsPropertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel5 = new System.Windows.Forms.Panel();
            this.annotationComboBox = new System.Windows.Forms.ComboBox();
            this.commentsTabPage = new System.Windows.Forms.TabPage();
            this.commentsPanel = new System.Windows.Forms.Panel();
            this.commentsControl1 = new DemosCommonCode.Annotation.AnnotationCommentsControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.actionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelLoadingImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarImageLoading = new System.Windows.Forms.ToolStripProgressBar();
            this.imageInfoStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
            this.viewerToolStrip = new DemosCommonCode.Imaging.ImageViewerToolStrip();
            this.visualToolsToolStrip1 = new DemosCommonCode.Imaging.VisualToolsToolStrip();
            this.selectionModeToolStrip = new System.Windows.Forms.ToolStrip();
            this.interactionModeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.annotationInteractionModeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.annotationsToolStrip1 = new DemosCommonCode.Annotation.AnnotationsToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.zoomPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mainMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.annotationMenu.SuspendLayout();
            this.annotationViewerMenu.SuspendLayout();
            this.thumbnailMenu.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.propertiesTabPage.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.commentsTabPage.SuspendLayout();
            this.commentsPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            this.toolStripPanel1.SuspendLayout();
            this.selectionModeToolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.zoomPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.annotationsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(951, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.addToolStripMenuItem,
            this.saveCurrentFileToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveToToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator8,
            this.printToolStripMenuItem,
            this.toolStripSeparator7,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addToolStripMenuItem.Text = "&Add...";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // saveCurrentFileToolStripMenuItem
            // 
            this.saveCurrentFileToolStripMenuItem.Enabled = false;
            this.saveCurrentFileToolStripMenuItem.Name = "saveCurrentFileToolStripMenuItem";
            this.saveCurrentFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveCurrentFileToolStripMenuItem.Text = "Save";
            this.saveCurrentFileToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentImageToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveToToolStripMenuItem
            // 
            this.saveToToolStripMenuItem.Name = "saveToToolStripMenuItem";
            this.saveToToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToToolStripMenuItem.Text = "&Save To...";
            this.saveToToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(177, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableUndoRedoToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.undoRedoSettingsToolStripMenuItem,
            this.showHistoryForDisplayedImagesToolStripMenuItem,
            this.historyDialogToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // enableUndoRedoToolStripMenuItem
            // 
            this.enableUndoRedoToolStripMenuItem.Name = "enableUndoRedoToolStripMenuItem";
            this.enableUndoRedoToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.enableUndoRedoToolStripMenuItem.Text = "Enable Undo/Redo";
            this.enableUndoRedoToolStripMenuItem.Click += new System.EventHandler(this.enableUndoRedoToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // undoRedoSettingsToolStripMenuItem
            // 
            this.undoRedoSettingsToolStripMenuItem.Name = "undoRedoSettingsToolStripMenuItem";
            this.undoRedoSettingsToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.undoRedoSettingsToolStripMenuItem.Text = "Undo/Redo Settings...";
            this.undoRedoSettingsToolStripMenuItem.Click += new System.EventHandler(this.undoRedoSettingsToolStripMenuItem_Click);
            // 
            // showHistoryForDisplayedImagesToolStripMenuItem
            // 
            this.showHistoryForDisplayedImagesToolStripMenuItem.Checked = true;
            this.showHistoryForDisplayedImagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showHistoryForDisplayedImagesToolStripMenuItem.Name = "showHistoryForDisplayedImagesToolStripMenuItem";
            this.showHistoryForDisplayedImagesToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.showHistoryForDisplayedImagesToolStripMenuItem.Text = "Show History for Displayed Images";
            this.showHistoryForDisplayedImagesToolStripMenuItem.Click += new System.EventHandler(this.showHistoryForDisplayedImagesToolStripMenuItem_Click);
            // 
            // historyDialogToolStripMenuItem
            // 
            this.historyDialogToolStripMenuItem.Name = "historyDialogToolStripMenuItem";
            this.historyDialogToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.historyDialogToolStripMenuItem.Text = "History Dialog...";
            this.historyDialogToolStripMenuItem.Click += new System.EventHandler(this.annotationHistoryToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualToolsToolStripMenuItem,
            this.toolStripSeparator18,
            this.thumbnailViewerSettingsToolStripMenuItem,
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem,
            this.toolStripSeparator3,
            this.imageDisplayModeToolStripMenuItem,
            this.scaleModeToolStripMenuItem,
            this.rotateViewToolStripMenuItem,
            this.annotationViewerSettingsToolStripMenuItem,
            this.interactionPointsSettingsToolStripMenuItem,
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem,
            this.boundAnnotationsToolStripMenuItem,
            this.moveAnnotationsBetweenImagesToolStripMenuItem,
            this.toolStripSeparator17,
            this.spellCheckSettingsToolStripMenuItem,
            this.spellCheckViewSettingsToolStripMenuItem,
            this.toolStripSeparator9,
            this.showEventsLogToolStripMenuItem,
            this.toolStripSeparator2,
            this.colorManagementToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // visualToolsToolStripMenuItem
            // 
            this.visualToolsToolStripMenuItem.Name = "visualToolsToolStripMenuItem";
            this.visualToolsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.visualToolsToolStripMenuItem.Text = "Visual Tools";
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(364, 6);
            // 
            // thumbnailViewerSettingsToolStripMenuItem
            // 
            this.thumbnailViewerSettingsToolStripMenuItem.Name = "thumbnailViewerSettingsToolStripMenuItem";
            this.thumbnailViewerSettingsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.thumbnailViewerSettingsToolStripMenuItem.Text = "Thumbnail Viewer Settings...";
            this.thumbnailViewerSettingsToolStripMenuItem.Click += new System.EventHandler(this.thumbnailViewerSettingsToolStripMenuItem_Click);
            // 
            // showAnnotationTransformationOnThumbnailToolStripMenuItem
            // 
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem.CheckOnClick = true;
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem.Name = "showAnnotationTransformationOnThumbnailToolStripMenuItem";
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.showAnnotationTransformationOnThumbnailToolStripMenuItem.Text = "Show Annotation Transformation on Thumbnail";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(364, 6);
            // 
            // imageDisplayModeToolStripMenuItem
            // 
            this.imageDisplayModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singlePageToolStripMenuItem,
            this.twoColumnsToolStripMenuItem,
            this.singleContinuousRowToolStripMenuItem,
            this.singleContinuousColumnToolStripMenuItem,
            this.twoContinuousRowsToolStripMenuItem,
            this.twoContinuousColumnsToolStripMenuItem});
            this.imageDisplayModeToolStripMenuItem.Name = "imageDisplayModeToolStripMenuItem";
            this.imageDisplayModeToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.imageDisplayModeToolStripMenuItem.Text = "Image Display Mode";
            // 
            // singlePageToolStripMenuItem
            // 
            this.singlePageToolStripMenuItem.Name = "singlePageToolStripMenuItem";
            this.singlePageToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.singlePageToolStripMenuItem.Text = "Single Page";
            this.singlePageToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // twoColumnsToolStripMenuItem
            // 
            this.twoColumnsToolStripMenuItem.Name = "twoColumnsToolStripMenuItem";
            this.twoColumnsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.twoColumnsToolStripMenuItem.Text = "Two Columns";
            this.twoColumnsToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // singleContinuousRowToolStripMenuItem
            // 
            this.singleContinuousRowToolStripMenuItem.Name = "singleContinuousRowToolStripMenuItem";
            this.singleContinuousRowToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.singleContinuousRowToolStripMenuItem.Text = "Single Continuous Row";
            this.singleContinuousRowToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // singleContinuousColumnToolStripMenuItem
            // 
            this.singleContinuousColumnToolStripMenuItem.Name = "singleContinuousColumnToolStripMenuItem";
            this.singleContinuousColumnToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.singleContinuousColumnToolStripMenuItem.Text = "Single Continuous Column";
            this.singleContinuousColumnToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // twoContinuousRowsToolStripMenuItem
            // 
            this.twoContinuousRowsToolStripMenuItem.Name = "twoContinuousRowsToolStripMenuItem";
            this.twoContinuousRowsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.twoContinuousRowsToolStripMenuItem.Text = "Two Continuous Rows";
            this.twoContinuousRowsToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // twoContinuousColumnsToolStripMenuItem
            // 
            this.twoContinuousColumnsToolStripMenuItem.Name = "twoContinuousColumnsToolStripMenuItem";
            this.twoContinuousColumnsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.twoContinuousColumnsToolStripMenuItem.Text = "Two Continuous Columns";
            this.twoContinuousColumnsToolStripMenuItem.Click += new System.EventHandler(this.ImageDisplayMode_Click);
            // 
            // scaleModeToolStripMenuItem
            // 
            this.scaleModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.bestFitToolStripMenuItem,
            this.fitToWidthToolStripMenuItem,
            this.fitToHeightToolStripMenuItem,
            this.pixelToPixelToolStripMenuItem,
            this.scaleToolStripMenuItem,
            this.toolStripSeparatorZoomModes,
            this.scale25ToolStripMenuItem,
            this.scale50ToolStripMenuItem,
            this.scale100ToolStripMenuItem,
            this.scale200ToolStripMenuItem,
            this.scale400ToolStripMenuItem});
            this.scaleModeToolStripMenuItem.Name = "scaleModeToolStripMenuItem";
            this.scaleModeToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.scaleModeToolStripMenuItem.Text = "Image Scale Mode";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // bestFitToolStripMenuItem
            // 
            this.bestFitToolStripMenuItem.Checked = true;
            this.bestFitToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bestFitToolStripMenuItem.Name = "bestFitToolStripMenuItem";
            this.bestFitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.bestFitToolStripMenuItem.Text = "Best fit";
            this.bestFitToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // fitToWidthToolStripMenuItem
            // 
            this.fitToWidthToolStripMenuItem.Name = "fitToWidthToolStripMenuItem";
            this.fitToWidthToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.fitToWidthToolStripMenuItem.Text = "Fit to width";
            this.fitToWidthToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // fitToHeightToolStripMenuItem
            // 
            this.fitToHeightToolStripMenuItem.Name = "fitToHeightToolStripMenuItem";
            this.fitToHeightToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.fitToHeightToolStripMenuItem.Text = "Fit to height";
            this.fitToHeightToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // pixelToPixelToolStripMenuItem
            // 
            this.pixelToPixelToolStripMenuItem.Name = "pixelToPixelToolStripMenuItem";
            this.pixelToPixelToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.pixelToPixelToolStripMenuItem.Text = "Pixel to Pixel";
            this.pixelToPixelToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scaleToolStripMenuItem.Text = "Scale";
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // toolStripSeparatorZoomModes
            // 
            this.toolStripSeparatorZoomModes.Name = "toolStripSeparatorZoomModes";
            this.toolStripSeparatorZoomModes.Size = new System.Drawing.Size(138, 6);
            // 
            // scale25ToolStripMenuItem
            // 
            this.scale25ToolStripMenuItem.Name = "scale25ToolStripMenuItem";
            this.scale25ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale25ToolStripMenuItem.Text = "25%";
            this.scale25ToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // scale50ToolStripMenuItem
            // 
            this.scale50ToolStripMenuItem.Name = "scale50ToolStripMenuItem";
            this.scale50ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale50ToolStripMenuItem.Text = "50%";
            this.scale50ToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // scale100ToolStripMenuItem
            // 
            this.scale100ToolStripMenuItem.Name = "scale100ToolStripMenuItem";
            this.scale100ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale100ToolStripMenuItem.Text = "100%";
            this.scale100ToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // scale200ToolStripMenuItem
            // 
            this.scale200ToolStripMenuItem.Name = "scale200ToolStripMenuItem";
            this.scale200ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale200ToolStripMenuItem.Text = "200%";
            this.scale200ToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // scale400ToolStripMenuItem
            // 
            this.scale400ToolStripMenuItem.Name = "scale400ToolStripMenuItem";
            this.scale400ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.scale400ToolStripMenuItem.Text = "400%";
            this.scale400ToolStripMenuItem.Click += new System.EventHandler(this.imageSizeMode_Click);
            // 
            // rotateViewToolStripMenuItem
            // 
            this.rotateViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateClockwiseToolStripMenuItem,
            this.rotateCounterclockwiseToolStripMenuItem});
            this.rotateViewToolStripMenuItem.Name = "rotateViewToolStripMenuItem";
            this.rotateViewToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.rotateViewToolStripMenuItem.Text = "Rotate View";
            // 
            // rotateClockwiseToolStripMenuItem
            // 
            this.rotateClockwiseToolStripMenuItem.Name = "rotateClockwiseToolStripMenuItem";
            this.rotateClockwiseToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Ctrl+Plus";
            this.rotateClockwiseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Oemplus)));
            this.rotateClockwiseToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.rotateClockwiseToolStripMenuItem.Text = "Clockwise";
            this.rotateClockwiseToolStripMenuItem.Click += new System.EventHandler(this.rotateClockwiseToolStripMenuItem_Click);
            // 
            // rotateCounterclockwiseToolStripMenuItem
            // 
            this.rotateCounterclockwiseToolStripMenuItem.Name = "rotateCounterclockwiseToolStripMenuItem";
            this.rotateCounterclockwiseToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Ctrl+Minus";
            this.rotateCounterclockwiseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.OemMinus)));
            this.rotateCounterclockwiseToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.rotateCounterclockwiseToolStripMenuItem.Text = "Counterclockwise";
            this.rotateCounterclockwiseToolStripMenuItem.Click += new System.EventHandler(this.rotateCounterclockwiseToolStripMenuItem_Click);
            // 
            // annotationViewerSettingsToolStripMenuItem
            // 
            this.annotationViewerSettingsToolStripMenuItem.Name = "annotationViewerSettingsToolStripMenuItem";
            this.annotationViewerSettingsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.annotationViewerSettingsToolStripMenuItem.Text = "Annotation Viewer Settings...";
            this.annotationViewerSettingsToolStripMenuItem.Click += new System.EventHandler(this.annotationViewerSettingsToolStripMenuItem_Click);
            // 
            // interactionPointsSettingsToolStripMenuItem
            // 
            this.interactionPointsSettingsToolStripMenuItem.Name = "interactionPointsSettingsToolStripMenuItem";
            this.interactionPointsSettingsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.interactionPointsSettingsToolStripMenuItem.Text = "Interaction Points Settings...";
            this.interactionPointsSettingsToolStripMenuItem.Click += new System.EventHandler(this.interactionPointsAppearanceToolStripMenuItem_Click);
            // 
            // scrollViewerWhenAnnotationIsMovedToolStripMenuItem
            // 
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Checked = true;
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.CheckOnClick = true;
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Name = "scrollViewerWhenAnnotationIsMovedToolStripMenuItem";
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.scrollViewerWhenAnnotationIsMovedToolStripMenuItem.Text = "Scroll Viewer When Annotation is Moved";
            // 
            // boundAnnotationsToolStripMenuItem
            // 
            this.boundAnnotationsToolStripMenuItem.CheckOnClick = true;
            this.boundAnnotationsToolStripMenuItem.Name = "boundAnnotationsToolStripMenuItem";
            this.boundAnnotationsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.boundAnnotationsToolStripMenuItem.Text = "Move Annotations Within Image Bounds";
            this.boundAnnotationsToolStripMenuItem.Click += new System.EventHandler(this.boundAnnotationsToolStripMenuItem_Click);
            // 
            // moveAnnotationsBetweenImagesToolStripMenuItem
            // 
            this.moveAnnotationsBetweenImagesToolStripMenuItem.CheckOnClick = true;
            this.moveAnnotationsBetweenImagesToolStripMenuItem.Name = "moveAnnotationsBetweenImagesToolStripMenuItem";
            this.moveAnnotationsBetweenImagesToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.moveAnnotationsBetweenImagesToolStripMenuItem.Text = "Move Annotations Between Images (Multipage Display)";
            this.moveAnnotationsBetweenImagesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.moveAnnotationsBetweenImagesToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(364, 6);
            // 
            // spellCheckSettingsToolStripMenuItem
            // 
            this.spellCheckSettingsToolStripMenuItem.Name = "spellCheckSettingsToolStripMenuItem";
            this.spellCheckSettingsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.spellCheckSettingsToolStripMenuItem.Text = "Spell Check Settings...";
            this.spellCheckSettingsToolStripMenuItem.Click += new System.EventHandler(this.spellCheckSettingsToolStripMenuItem_Click);
            // 
            // spellCheckViewSettingsToolStripMenuItem
            // 
            this.spellCheckViewSettingsToolStripMenuItem.Name = "spellCheckViewSettingsToolStripMenuItem";
            this.spellCheckViewSettingsToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.spellCheckViewSettingsToolStripMenuItem.Text = "Spell Check View Settings...";
            this.spellCheckViewSettingsToolStripMenuItem.Click += new System.EventHandler(this.spellCheckViewSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(364, 6);
            // 
            // showEventsLogToolStripMenuItem
            // 
            this.showEventsLogToolStripMenuItem.Name = "showEventsLogToolStripMenuItem";
            this.showEventsLogToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.showEventsLogToolStripMenuItem.Text = "Show Events Log";
            this.showEventsLogToolStripMenuItem.Click += new System.EventHandler(this.showEventsLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(364, 6);
            // 
            // colorManagementToolStripMenuItem
            // 
            this.colorManagementToolStripMenuItem.Name = "colorManagementToolStripMenuItem";
            this.colorManagementToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.colorManagementToolStripMenuItem.Text = "Color Management...";
            this.colorManagementToolStripMenuItem.Click += new System.EventHandler(this.colorManagementToolStripMenuItem_Click);
            // 
            // annotationsToolStripMenuItem
            // 
            this.annotationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annotationsInfoToolStripMenuItem,
            this.toolStripSeparator1,
            this.interactionModeToolStripMenuItem,
            this.transformationModeToolStripMenuItem,
            this.toolStripSeparator15,
            this.loadFromFileToolStripMenuItem,
            this.saveToFileToolStripMenuItem,
            this.toolStripSeparator10,
            this.addAnnotationToolStripMenuItem,
            this.buildAnnotationsContinuouslyToolStripMenuItem,
            this.toolStripSeparator19,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.deleteAllToolStripMenuItem,
            this.toolStripSeparator11,
            this.bringToBackToolStripMenuItem1,
            this.bringToFrontToolStripMenuItem1,
            this.toolStripSeparator6,
            this.multiSelectToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.deselectAllToolStripMenuItem,
            this.toolStripSeparator13,
            this.groupSelectedToolStripMenuItem,
            this.groupAllToolStripMenuItem,
            this.toolStripSeparator12,
            this.rotateImageWithAnnotationsToolStripMenuItem,
            this.burnAnnotationsOnImageToolStripMenuItem,
            this.cloneImageWithAnnotationsToolStripMenuItem});
            this.annotationsToolStripMenuItem.Name = "annotationsToolStripMenuItem";
            this.annotationsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.annotationsToolStripMenuItem.Text = "Annotations";
            this.annotationsToolStripMenuItem.DropDownClosed += new System.EventHandler(this.annotationsToolStripMenuItem_DropDownClosed);
            this.annotationsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.annotationsToolStripMenuItem_DropDownOpening);
            // 
            // annotationsInfoToolStripMenuItem
            // 
            this.annotationsInfoToolStripMenuItem.Name = "annotationsInfoToolStripMenuItem";
            this.annotationsInfoToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.annotationsInfoToolStripMenuItem.Text = "Info...";
            this.annotationsInfoToolStripMenuItem.Click += new System.EventHandler(this.annotationsInfoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
            // 
            // interactionModeToolStripMenuItem
            // 
            this.interactionModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annotationInteractionModeNoneToolStripMenuItem,
            this.annotationInteractionModeViewToolStripMenuItem,
            this.annotationInteractionModeAuthorToolStripMenuItem});
            this.interactionModeToolStripMenuItem.Name = "interactionModeToolStripMenuItem";
            this.interactionModeToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.interactionModeToolStripMenuItem.Text = "Interaction Mode";
            // 
            // annotationInteractionModeNoneToolStripMenuItem
            // 
            this.annotationInteractionModeNoneToolStripMenuItem.Name = "annotationInteractionModeNoneToolStripMenuItem";
            this.annotationInteractionModeNoneToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.annotationInteractionModeNoneToolStripMenuItem.Text = "None";
            this.annotationInteractionModeNoneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // annotationInteractionModeViewToolStripMenuItem
            // 
            this.annotationInteractionModeViewToolStripMenuItem.Name = "annotationInteractionModeViewToolStripMenuItem";
            this.annotationInteractionModeViewToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.annotationInteractionModeViewToolStripMenuItem.Text = "View";
            this.annotationInteractionModeViewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem1_Click);
            // 
            // annotationInteractionModeAuthorToolStripMenuItem
            // 
            this.annotationInteractionModeAuthorToolStripMenuItem.Checked = true;
            this.annotationInteractionModeAuthorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.annotationInteractionModeAuthorToolStripMenuItem.Name = "annotationInteractionModeAuthorToolStripMenuItem";
            this.annotationInteractionModeAuthorToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.annotationInteractionModeAuthorToolStripMenuItem.Text = "Author";
            this.annotationInteractionModeAuthorToolStripMenuItem.Click += new System.EventHandler(this.authorToolStripMenuItem_Click);
            // 
            // transformationModeToolStripMenuItem
            // 
            this.transformationModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangularToolStripMenuItem,
            this.pointsToolStripMenuItem,
            this.rectangularAndPointsToolStripMenuItem});
            this.transformationModeToolStripMenuItem.Name = "transformationModeToolStripMenuItem";
            this.transformationModeToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.transformationModeToolStripMenuItem.Text = "Transformation Mode";
            // 
            // rectangularToolStripMenuItem
            // 
            this.rectangularToolStripMenuItem.Name = "rectangularToolStripMenuItem";
            this.rectangularToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.rectangularToolStripMenuItem.Text = "Rectangular";
            this.rectangularToolStripMenuItem.Click += new System.EventHandler(this.rectangularToolStripMenuItem_Click);
            // 
            // pointsToolStripMenuItem
            // 
            this.pointsToolStripMenuItem.Name = "pointsToolStripMenuItem";
            this.pointsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.pointsToolStripMenuItem.Text = "Points";
            this.pointsToolStripMenuItem.Click += new System.EventHandler(this.pointsToolStripMenuItem_Click);
            // 
            // rectangularAndPointsToolStripMenuItem
            // 
            this.rectangularAndPointsToolStripMenuItem.Name = "rectangularAndPointsToolStripMenuItem";
            this.rectangularAndPointsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.rectangularAndPointsToolStripMenuItem.Text = "Rectangular and Points";
            this.rectangularAndPointsToolStripMenuItem.Click += new System.EventHandler(this.rectangularAndPointsToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(244, 6);
            // 
            // loadFromFileToolStripMenuItem
            // 
            this.loadFromFileToolStripMenuItem.Name = "loadFromFileToolStripMenuItem";
            this.loadFromFileToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.loadFromFileToolStripMenuItem.Text = "Load from file...";
            this.loadFromFileToolStripMenuItem.Click += new System.EventHandler(this.loadAnnotationsFromFileToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.saveToFileToolStripMenuItem.Text = "Save to file...";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveAnnotationsToFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(244, 6);
            // 
            // addAnnotationToolStripMenuItem
            // 
            this.addAnnotationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.highlightToolStripMenuItem,
            this.textHighlightToolStripMenuItem,
            this.embeddedImageToolStripMenuItem,
            this.referencedImageToolStripMenuItem,
            this.textToolStripMenuItem,
            this.stickyNoteToolStripMenuItem,
            this.freeTextToolStripMenuItem,
            this.rubberStampToolStripMenuItem,
            this.linkToolStripMenuItem,
            this.toolStripSeparator16,
            this.lineToolStripMenuItem,
            this.linesToolStripMenuItem,
            this.linesWithInterpolationToolStripMenuItem,
            this.freehandLinesToolStripMenuItem,
            this.polygonToolStripMenuItem,
            this.polygonWithInterpolationToolStripMenuItem,
            this.freehandPolygonToolStripMenuItem,
            this.rulerToolStripMenuItem,
            this.rulersToolStripMenuItem,
            this.angleToolStripMenuItem,
            this.toolStripSeparator14,
            this.triangleCustomAnnotationToolStripMenuItem,
            this.markCustomAnnotationToolStripMenuItem});
            this.addAnnotationToolStripMenuItem.Name = "addAnnotationToolStripMenuItem";
            this.addAnnotationToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.addAnnotationToolStripMenuItem.Text = "Add";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // highlightToolStripMenuItem
            // 
            this.highlightToolStripMenuItem.Name = "highlightToolStripMenuItem";
            this.highlightToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.highlightToolStripMenuItem.Text = "Highlight";
            this.highlightToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // textHighlightToolStripMenuItem
            // 
            this.textHighlightToolStripMenuItem.Name = "textHighlightToolStripMenuItem";
            this.textHighlightToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.textHighlightToolStripMenuItem.Text = "Text highlight";
            this.textHighlightToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // embeddedImageToolStripMenuItem
            // 
            this.embeddedImageToolStripMenuItem.Name = "embeddedImageToolStripMenuItem";
            this.embeddedImageToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.embeddedImageToolStripMenuItem.Text = "Embedded image";
            this.embeddedImageToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // referencedImageToolStripMenuItem
            // 
            this.referencedImageToolStripMenuItem.Name = "referencedImageToolStripMenuItem";
            this.referencedImageToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.referencedImageToolStripMenuItem.Text = "Referenced image";
            this.referencedImageToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // stickyNoteToolStripMenuItem
            // 
            this.stickyNoteToolStripMenuItem.Name = "stickyNoteToolStripMenuItem";
            this.stickyNoteToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.stickyNoteToolStripMenuItem.Text = "Sticky note";
            this.stickyNoteToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // freeTextToolStripMenuItem
            // 
            this.freeTextToolStripMenuItem.Name = "freeTextToolStripMenuItem";
            this.freeTextToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.freeTextToolStripMenuItem.Text = "Free text";
            this.freeTextToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // rubberStampToolStripMenuItem
            // 
            this.rubberStampToolStripMenuItem.Name = "rubberStampToolStripMenuItem";
            this.rubberStampToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.rubberStampToolStripMenuItem.Text = "Rubber stamp";
            this.rubberStampToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // linkToolStripMenuItem
            // 
            this.linkToolStripMenuItem.Name = "linkToolStripMenuItem";
            this.linkToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.linkToolStripMenuItem.Text = "Link";
            this.linkToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(228, 6);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // linesToolStripMenuItem
            // 
            this.linesToolStripMenuItem.Name = "linesToolStripMenuItem";
            this.linesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.linesToolStripMenuItem.Text = "Lines";
            this.linesToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // linesWithInterpolationToolStripMenuItem
            // 
            this.linesWithInterpolationToolStripMenuItem.Name = "linesWithInterpolationToolStripMenuItem";
            this.linesWithInterpolationToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.linesWithInterpolationToolStripMenuItem.Text = "Lines with interpolation";
            this.linesWithInterpolationToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // freehandLinesToolStripMenuItem
            // 
            this.freehandLinesToolStripMenuItem.Name = "freehandLinesToolStripMenuItem";
            this.freehandLinesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.freehandLinesToolStripMenuItem.Text = "Freehand lines";
            this.freehandLinesToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // polygonToolStripMenuItem
            // 
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            this.polygonToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.polygonToolStripMenuItem.Text = "Polygon";
            this.polygonToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // polygonWithInterpolationToolStripMenuItem
            // 
            this.polygonWithInterpolationToolStripMenuItem.Name = "polygonWithInterpolationToolStripMenuItem";
            this.polygonWithInterpolationToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.polygonWithInterpolationToolStripMenuItem.Text = "Polygon with interpolation";
            this.polygonWithInterpolationToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // freehandPolygonToolStripMenuItem
            // 
            this.freehandPolygonToolStripMenuItem.Name = "freehandPolygonToolStripMenuItem";
            this.freehandPolygonToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.freehandPolygonToolStripMenuItem.Text = "Freehand polygon";
            this.freehandPolygonToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // rulerToolStripMenuItem
            // 
            this.rulerToolStripMenuItem.Name = "rulerToolStripMenuItem";
            this.rulerToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.rulerToolStripMenuItem.Text = "Ruler";
            this.rulerToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // rulersToolStripMenuItem
            // 
            this.rulersToolStripMenuItem.Name = "rulersToolStripMenuItem";
            this.rulersToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.rulersToolStripMenuItem.Text = "Rulers";
            this.rulersToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // angleToolStripMenuItem
            // 
            this.angleToolStripMenuItem.Name = "angleToolStripMenuItem";
            this.angleToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.angleToolStripMenuItem.Text = "Angle";
            this.angleToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(228, 6);
            // 
            // triangleCustomAnnotationToolStripMenuItem
            // 
            this.triangleCustomAnnotationToolStripMenuItem.Name = "triangleCustomAnnotationToolStripMenuItem";
            this.triangleCustomAnnotationToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.triangleCustomAnnotationToolStripMenuItem.Text = "Triangle - Custom Annotation";
            this.triangleCustomAnnotationToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // markCustomAnnotationToolStripMenuItem
            // 
            this.markCustomAnnotationToolStripMenuItem.Name = "markCustomAnnotationToolStripMenuItem";
            this.markCustomAnnotationToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.markCustomAnnotationToolStripMenuItem.Text = "Mark - Custom Annotation";
            this.markCustomAnnotationToolStripMenuItem.Click += new System.EventHandler(this.addAnnotationToolStripMenuItem_Click);
            // 
            // buildAnnotationsContinuouslyToolStripMenuItem
            // 
            this.buildAnnotationsContinuouslyToolStripMenuItem.CheckOnClick = true;
            this.buildAnnotationsContinuouslyToolStripMenuItem.Name = "buildAnnotationsContinuouslyToolStripMenuItem";
            this.buildAnnotationsContinuouslyToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.buildAnnotationsContinuouslyToolStripMenuItem.Text = "Build Annotations Continuously";
            this.buildAnnotationsContinuouslyToolStripMenuItem.CheckedChanged += new System.EventHandler(this.buildAnnotationsContinuouslyToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(244, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutAnnotationToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyAnnotationToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteAnnotationToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeyDisplayString = "Del";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteAnnotationToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.deleteAllToolStripMenuItem.Text = "Delete All";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.deleteAllAnnotationsToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(244, 6);
            // 
            // bringToBackToolStripMenuItem1
            // 
            this.bringToBackToolStripMenuItem1.Name = "bringToBackToolStripMenuItem1";
            this.bringToBackToolStripMenuItem1.Size = new System.Drawing.Size(247, 22);
            this.bringToBackToolStripMenuItem1.Text = "Bring to back";
            this.bringToBackToolStripMenuItem1.Click += new System.EventHandler(this.bringToBackToolStripMenuItem_Click);
            // 
            // bringToFrontToolStripMenuItem1
            // 
            this.bringToFrontToolStripMenuItem1.Name = "bringToFrontToolStripMenuItem1";
            this.bringToFrontToolStripMenuItem1.Size = new System.Drawing.Size(247, 22);
            this.bringToFrontToolStripMenuItem1.Text = "Bring to front";
            this.bringToFrontToolStripMenuItem1.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(244, 6);
            // 
            // multiSelectToolStripMenuItem
            // 
            this.multiSelectToolStripMenuItem.Checked = true;
            this.multiSelectToolStripMenuItem.CheckOnClick = true;
            this.multiSelectToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.multiSelectToolStripMenuItem.Name = "multiSelectToolStripMenuItem";
            this.multiSelectToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.multiSelectToolStripMenuItem.Text = "Multi Select";
            this.multiSelectToolStripMenuItem.Click += new System.EventHandler(this.multiSelectToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllAnnotationsToolStripMenuItem_Click);
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.deselectAllToolStripMenuItem.Text = "Deselect All";
            this.deselectAllToolStripMenuItem.Click += new System.EventHandler(this.deselectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(244, 6);
            // 
            // groupSelectedToolStripMenuItem
            // 
            this.groupSelectedToolStripMenuItem.Name = "groupSelectedToolStripMenuItem";
            this.groupSelectedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.groupSelectedToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.groupSelectedToolStripMenuItem.Text = "Group/Ungroup Selected";
            this.groupSelectedToolStripMenuItem.Click += new System.EventHandler(this.groupSelectedToolStripMenuItem_Click);
            // 
            // groupAllToolStripMenuItem
            // 
            this.groupAllToolStripMenuItem.Name = "groupAllToolStripMenuItem";
            this.groupAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.groupAllToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.groupAllToolStripMenuItem.Text = "Group All";
            this.groupAllToolStripMenuItem.Click += new System.EventHandler(this.groupAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(244, 6);
            // 
            // rotateImageWithAnnotationsToolStripMenuItem
            // 
            this.rotateImageWithAnnotationsToolStripMenuItem.Name = "rotateImageWithAnnotationsToolStripMenuItem";
            this.rotateImageWithAnnotationsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.rotateImageWithAnnotationsToolStripMenuItem.Text = "Rotate Image with Annotations...";
            this.rotateImageWithAnnotationsToolStripMenuItem.Click += new System.EventHandler(this.rotateImageWithAnnotationsToolStripMenuItem_Click);
            // 
            // burnAnnotationsOnImageToolStripMenuItem
            // 
            this.burnAnnotationsOnImageToolStripMenuItem.Name = "burnAnnotationsOnImageToolStripMenuItem";
            this.burnAnnotationsOnImageToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.burnAnnotationsOnImageToolStripMenuItem.Text = "Burn Annotations on Image";
            this.burnAnnotationsOnImageToolStripMenuItem.Click += new System.EventHandler(this.burnAnnotationsOnImageToolStripMenuItem_Click);
            // 
            // cloneImageWithAnnotationsToolStripMenuItem
            // 
            this.cloneImageWithAnnotationsToolStripMenuItem.Name = "cloneImageWithAnnotationsToolStripMenuItem";
            this.cloneImageWithAnnotationsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.cloneImageWithAnnotationsToolStripMenuItem.Text = "Clone Image with Annotations";
            this.cloneImageWithAnnotationsToolStripMenuItem.Click += new System.EventHandler(this.cloneImageWithAnnotationsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.thumbnailViewer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Size = new System.Drawing.Size(740, 429);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 1;
            // 
            // thumbnailViewer1
            // 
            this.thumbnailViewer1.AllowDrop = true;
            this.thumbnailViewer1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.thumbnailViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnailViewer1.Clipboard = winFormsSystemClipboard1;
            this.thumbnailViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            thumbnailAppearance1.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance1.BorderColor = System.Drawing.Color.Gray;
            thumbnailAppearance1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Dotted;
            thumbnailAppearance1.BorderWidth = 1;
            this.thumbnailViewer1.FocusedThumbnailAppearance = thumbnailAppearance1;
            this.thumbnailViewer1.GenerateOnlyVisibleThumbnails = true;
            thumbnailAppearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            thumbnailAppearance2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance2.BorderWidth = 2;
            this.thumbnailViewer1.HoveredThumbnailAppearance = thumbnailAppearance2;
            this.thumbnailViewer1.ImageRotationAngle = 0;
            this.thumbnailViewer1.Location = new System.Drawing.Point(0, 0);
            this.thumbnailViewer1.MasterViewer = this.annotationViewer1;
            this.thumbnailViewer1.Name = "thumbnailViewer1";
            thumbnailAppearance3.BackColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderColor = System.Drawing.Color.Black;
            thumbnailAppearance3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance3.BorderWidth = 0;
            this.thumbnailViewer1.NotReadyThumbnailAppearance = thumbnailAppearance3;
            thumbnailAppearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(238)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(222)))), ((int)(((byte)(253)))));
            thumbnailAppearance4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance4.BorderWidth = 1;
            this.thumbnailViewer1.SelectedThumbnailAppearance = thumbnailAppearance4;
            this.thumbnailViewer1.Size = new System.Drawing.Size(188, 429);
            this.thumbnailViewer1.TabIndex = 0;
            this.thumbnailViewer1.Text = "thumbnailViewer1";
            thumbnailAppearance5.BackColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderColor = System.Drawing.Color.Transparent;
            thumbnailAppearance5.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            thumbnailAppearance5.BorderWidth = 1;
            this.thumbnailViewer1.ThumbnailAppearance = thumbnailAppearance5;
            thumbnailCaption1.Padding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            thumbnailCaption1.TextColor = System.Drawing.Color.Black;
            this.thumbnailViewer1.ThumbnailCaption = thumbnailCaption1;
            this.thumbnailViewer1.ThumbnailContextMenuStrip = this.thumbnailMenu;
            this.thumbnailViewer1.ThumbnailFlowStyle = Vintasoft.Imaging.UI.ThumbnailFlowStyle.WrappedRows;
            this.thumbnailViewer1.ThumbnailImagePadding = new Vintasoft.Imaging.PaddingF(0F, 0F, 0F, 0F);
            this.thumbnailViewer1.ThumbnailMargin = new System.Windows.Forms.Padding(3);
            this.thumbnailViewer1.ThumbnailRenderingThreadCount = 4;
            this.thumbnailViewer1.ThumbnailSize = new System.Drawing.Size(100, 100);
            this.thumbnailViewer1.ThumbnailsLoadingProgress += new System.EventHandler<Vintasoft.Imaging.UI.ThumbnailsLoadingProgressEventArgs>(this.thumbnailViewer1_ThumbnailsLoadingProgress);
            // 
            // annotationViewer1
            // 
            this.annotationViewer1.AnnotationAuthorContextMenuStrip = this.annotationMenu;
            this.annotationViewer1.AnnotationBoundingRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.annotationViewer1.AnnotationViewContextMenuStrip = null;
            this.annotationViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.annotationViewer1.Clipboard = winFormsSystemClipboard1;
            this.annotationViewer1.ContextMenuStrip = this.annotationViewerMenu;
            this.annotationViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.annotationViewer1.DisplayMode = Vintasoft.Imaging.UI.ImageViewerDisplayMode.SingleContinuousColumn;
            this.annotationViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annotationViewer1.ImageRenderingSettings = renderingSettings1;
            this.annotationViewer1.ImageRotationAngle = 0;
            this.annotationViewer1.IsKeyboardNavigationEnabled = true;
            this.annotationViewer1.IsZoomingEnabled = true;
            this.annotationViewer1.Location = new System.Drawing.Point(0, 0);
            this.annotationViewer1.MultipageDisplayMode = Vintasoft.Imaging.UI.ImageViewerMultipageDisplayMode.AllImages;
            this.annotationViewer1.Name = "annotationViewer1";
            this.annotationViewer1.RendererCacheSize = 256F;
            this.annotationViewer1.ShortcutCopy = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.annotationViewer1.Size = new System.Drawing.Size(548, 429);
            this.annotationViewer1.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.annotationViewer1.TabIndex = 0;
            this.annotationViewer1.Text = "annotationViewer1";
            this.annotationViewer1.FocusedAnnotationViewChanged += new System.EventHandler<Vintasoft.Imaging.Annotation.UI.AnnotationViewChangedEventArgs>(this.annotationViewer1_FocusedAnnotationViewChanged);
            this.annotationViewer1.AnnotationTransformingStarted += new System.EventHandler<Vintasoft.Imaging.Annotation.UI.VisualTools.AnnotationViewEventArgs>(this.annotationViewer1_AnnotationTransformingStarted);
            this.annotationViewer1.AnnotationTransformingFinished += new System.EventHandler<Vintasoft.Imaging.Annotation.UI.VisualTools.AnnotationViewEventArgs>(this.annotationViewer1_AnnotationTransformingFinished);
            this.annotationViewer1.ImageLoading += new System.EventHandler<Vintasoft.Imaging.ImageLoadingEventArgs>(this.annotationViewer1_ImageLoading);
            this.annotationViewer1.ImageLoadingProgress += new System.EventHandler<Vintasoft.Imaging.ProgressEventArgs>(this.annotationViewer1_ImageLoadingProgress);
            this.annotationViewer1.ImageLoaded += new System.EventHandler<Vintasoft.Imaging.ImageLoadedEventArgs>(this.annotationViewer1_ImageLoaded);
            this.annotationViewer1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.annotationViewer1_KeyDown);
            // 
            // annotationMenu
            // 
            this.annotationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutAnnotationToolStripMenuItem,
            this.copyAnnotationToolStripMenuItem,
            this.pasteAnnotationToolStripMenuItem,
            this.deleteAnnotationToolStripMenuItem,
            this.toolStripSeparator4,
            this.bringToBackToolStripMenuItem,
            this.bringToFrontToolStripMenuItem});
            this.annotationMenu.Name = "contextMenuStrip1";
            this.annotationMenu.Size = new System.Drawing.Size(169, 142);
            this.annotationMenu.Opening += new System.ComponentModel.CancelEventHandler(this.annotationMenu_Opening);
            // 
            // cutAnnotationToolStripMenuItem
            // 
            this.cutAnnotationToolStripMenuItem.Name = "cutAnnotationToolStripMenuItem";
            this.cutAnnotationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.cutAnnotationToolStripMenuItem.Text = "Cut annotation";
            this.cutAnnotationToolStripMenuItem.Click += new System.EventHandler(this.cutAnnotationToolStripMenuItem_Click);
            // 
            // copyAnnotationToolStripMenuItem
            // 
            this.copyAnnotationToolStripMenuItem.Name = "copyAnnotationToolStripMenuItem";
            this.copyAnnotationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.copyAnnotationToolStripMenuItem.Text = "Copy annotation";
            this.copyAnnotationToolStripMenuItem.Click += new System.EventHandler(this.copyAnnotationToolStripMenuItem_Click);
            // 
            // pasteAnnotationToolStripMenuItem
            // 
            this.pasteAnnotationToolStripMenuItem.Name = "pasteAnnotationToolStripMenuItem";
            this.pasteAnnotationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.pasteAnnotationToolStripMenuItem.Text = "Paste annotation";
            this.pasteAnnotationToolStripMenuItem.Click += new System.EventHandler(this.pasteAnnotationInMousePositionToolStripMenuItem_Click);
            // 
            // deleteAnnotationToolStripMenuItem
            // 
            this.deleteAnnotationToolStripMenuItem.Name = "deleteAnnotationToolStripMenuItem";
            this.deleteAnnotationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.deleteAnnotationToolStripMenuItem.Text = "Delete annotation";
            this.deleteAnnotationToolStripMenuItem.Click += new System.EventHandler(this.deleteAnnotationToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
            // 
            // bringToBackToolStripMenuItem
            // 
            this.bringToBackToolStripMenuItem.Name = "bringToBackToolStripMenuItem";
            this.bringToBackToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.bringToBackToolStripMenuItem.Text = "Bring to back";
            this.bringToBackToolStripMenuItem.Click += new System.EventHandler(this.bringToBackToolStripMenuItem_Click);
            // 
            // bringToFrontToolStripMenuItem
            // 
            this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
            this.bringToFrontToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.bringToFrontToolStripMenuItem.Text = "Bring to front";
            this.bringToFrontToolStripMenuItem.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem_Click);
            // 
            // annotationViewerMenu
            // 
            this.annotationViewerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem2,
            this.toolStripSeparator20,
            this.saveImageWithAnnotationsToolStripMenuItem,
            this.burnAnnotationsOnImage2ToolStripMenuItem,
            this.copyImageToClipboardToolStripMenuItem,
            this.deleteImageToolStripMenuItem});
            this.annotationViewerMenu.Name = "contextMenuStrip1";
            this.annotationViewerMenu.Size = new System.Drawing.Size(236, 142);
            this.annotationViewerMenu.Opening += new System.ComponentModel.CancelEventHandler(this.annotationViewerMenu_Opening);
            // 
            // pasteToolStripMenuItem2
            // 
            this.pasteToolStripMenuItem2.Name = "pasteToolStripMenuItem2";
            this.pasteToolStripMenuItem2.Size = new System.Drawing.Size(235, 22);
            this.pasteToolStripMenuItem2.Text = "Paste annotation";
            this.pasteToolStripMenuItem2.Click += new System.EventHandler(this.pasteAnnotationInMousePositionToolStripMenuItem_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(232, 6);
            // 
            // saveImageWithAnnotationsToolStripMenuItem
            // 
            this.saveImageWithAnnotationsToolStripMenuItem.Name = "saveImageWithAnnotationsToolStripMenuItem";
            this.saveImageWithAnnotationsToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.saveImageWithAnnotationsToolStripMenuItem.Text = "Save image with annotations...";
            this.saveImageWithAnnotationsToolStripMenuItem.Click += new System.EventHandler(this.saveImageWithAnnotationsToolStripMenuItem_Click);
            // 
            // burnAnnotationsOnImage2ToolStripMenuItem
            // 
            this.burnAnnotationsOnImage2ToolStripMenuItem.Name = "burnAnnotationsOnImage2ToolStripMenuItem";
            this.burnAnnotationsOnImage2ToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.burnAnnotationsOnImage2ToolStripMenuItem.Text = "Burn annotations on image";
            this.burnAnnotationsOnImage2ToolStripMenuItem.Click += new System.EventHandler(this.burnAnnotationsOnImageToolStripMenuItem_Click);
            // 
            // copyImageToClipboardToolStripMenuItem
            // 
            this.copyImageToClipboardToolStripMenuItem.Name = "copyImageToClipboardToolStripMenuItem";
            this.copyImageToClipboardToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.copyImageToClipboardToolStripMenuItem.Text = "Copy image to clipboard";
            this.copyImageToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyImageToClipboardToolStripMenuItem_Click);
            // 
            // deleteImageToolStripMenuItem
            // 
            this.deleteImageToolStripMenuItem.Name = "deleteImageToolStripMenuItem";
            this.deleteImageToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.deleteImageToolStripMenuItem.Text = "Delete image";
            this.deleteImageToolStripMenuItem.Click += new System.EventHandler(this.deleteImageToolStripMenuItem_Click);
            // 
            // thumbnailMenu
            // 
            this.thumbnailMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thumbnailMenu_Save,
            this.thumbnailMenu_Burn,
            this.thumbnailMenu_CopyToClipboard,
            this.thumbnailMenu_Delete});
            this.thumbnailMenu.Name = "thumbnailMenu";
            this.thumbnailMenu.Size = new System.Drawing.Size(236, 92);
            // 
            // thumbnailMenu_Save
            // 
            this.thumbnailMenu_Save.Name = "thumbnailMenu_Save";
            this.thumbnailMenu_Save.Size = new System.Drawing.Size(235, 22);
            this.thumbnailMenu_Save.Text = "Save image with annotations...";
            this.thumbnailMenu_Save.Click += new System.EventHandler(this.saveImageWithAnnotationsToolStripMenuItem_Click);
            // 
            // thumbnailMenu_Burn
            // 
            this.thumbnailMenu_Burn.Name = "thumbnailMenu_Burn";
            this.thumbnailMenu_Burn.Size = new System.Drawing.Size(235, 22);
            this.thumbnailMenu_Burn.Text = "Burn annotations on image";
            this.thumbnailMenu_Burn.Click += new System.EventHandler(this.burnAnnotationsOnImageToolStripMenuItem_Click);
            // 
            // thumbnailMenu_CopyToClipboard
            // 
            this.thumbnailMenu_CopyToClipboard.Name = "thumbnailMenu_CopyToClipboard";
            this.thumbnailMenu_CopyToClipboard.Size = new System.Drawing.Size(235, 22);
            this.thumbnailMenu_CopyToClipboard.Text = "Copy image to clipboard";
            this.thumbnailMenu_CopyToClipboard.Click += new System.EventHandler(this.copyImageToClipboardToolStripMenuItem_Click);
            // 
            // thumbnailMenu_Delete
            // 
            this.thumbnailMenu_Delete.Name = "thumbnailMenu_Delete";
            this.thumbnailMenu_Delete.Size = new System.Drawing.Size(235, 22);
            this.thumbnailMenu_Delete.Text = "Delete image(s)";
            this.thumbnailMenu_Delete.Click += new System.EventHandler(this.deleteImageToolStripMenuItem_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.annotationViewer1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.annotationEventsLog);
            this.splitContainer4.Panel2Collapsed = true;
            this.splitContainer4.Size = new System.Drawing.Size(548, 429);
            this.splitContainer4.SplitterDistance = 325;
            this.splitContainer4.TabIndex = 1;
            // 
            // annotationEventsLog
            // 
            this.annotationEventsLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annotationEventsLog.Location = new System.Drawing.Point(0, 0);
            this.annotationEventsLog.Multiline = true;
            this.annotationEventsLog.Name = "annotationEventsLog";
            this.annotationEventsLog.ReadOnly = true;
            this.annotationEventsLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.annotationEventsLog.Size = new System.Drawing.Size(150, 46);
            this.annotationEventsLog.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.splitContainer2.Size = new System.Drawing.Size(951, 429);
            this.splitContainer2.SplitterDistance = 740;
            this.splitContainer2.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel7);
            this.splitContainer3.Panel2Collapsed = true;
            this.splitContainer3.Size = new System.Drawing.Size(206, 429);
            this.splitContainer3.SplitterDistance = 340;
            this.splitContainer3.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tabControl1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(206, 429);
            this.panel7.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.propertiesTabPage);
            this.tabControl1.Controls.Add(this.commentsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(206, 429);
            this.tabControl1.TabIndex = 2;
            // 
            // propertiesTabPage
            // 
            this.propertiesTabPage.Controls.Add(this.panel6);
            this.propertiesTabPage.Controls.Add(this.panel5);
            this.propertiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.propertiesTabPage.Name = "propertiesTabPage";
            this.propertiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.propertiesTabPage.Size = new System.Drawing.Size(198, 403);
            this.propertiesTabPage.TabIndex = 0;
            this.propertiesTabPage.Text = "Properties";
            this.propertiesTabPage.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.annotationsPropertyGrid1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(192, 373);
            this.panel6.TabIndex = 3;
            // 
            // annotationsPropertyGrid1
            // 
            this.annotationsPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annotationsPropertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.annotationsPropertyGrid1.Name = "annotationsPropertyGrid1";
            this.annotationsPropertyGrid1.Size = new System.Drawing.Size(192, 373);
            this.annotationsPropertyGrid1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.annotationComboBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(192, 24);
            this.panel5.TabIndex = 2;
            // 
            // annotationComboBox
            // 
            this.annotationComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annotationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.annotationComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.annotationComboBox.FormattingEnabled = true;
            this.annotationComboBox.Location = new System.Drawing.Point(0, 0);
            this.annotationComboBox.Name = "annotationComboBox";
            this.annotationComboBox.Size = new System.Drawing.Size(192, 23);
            this.annotationComboBox.TabIndex = 0;
            this.annotationComboBox.DropDown += new System.EventHandler(this.annotationComboBox_DropDown);
            this.annotationComboBox.SelectedIndexChanged += new System.EventHandler(this.annotationComboBox_SelectedIndexChanged);
            // 
            // commentsTabPage
            // 
            this.commentsTabPage.Controls.Add(this.commentsPanel);
            this.commentsTabPage.Location = new System.Drawing.Point(4, 22);
            this.commentsTabPage.Name = "commentsTabPage";
            this.commentsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.commentsTabPage.Size = new System.Drawing.Size(198, 403);
            this.commentsTabPage.TabIndex = 1;
            this.commentsTabPage.Text = "Comments";
            this.commentsTabPage.UseVisualStyleBackColor = true;
            // 
            // commentsPanel
            // 
            this.commentsPanel.Controls.Add(this.commentsControl1);
            this.commentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentsPanel.Location = new System.Drawing.Point(3, 3);
            this.commentsPanel.Name = "commentsPanel";
            this.commentsPanel.Size = new System.Drawing.Size(192, 397);
            this.commentsPanel.TabIndex = 5;
            // 
            // commentsControl1
            // 
            this.commentsControl1.AnnotationTool = null;
            this.commentsControl1.CommentTool = null;
            this.commentsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentsControl1.ImageViewer = null;
            this.commentsControl1.Location = new System.Drawing.Point(0, 0);
            this.commentsControl1.MinimumSize = new System.Drawing.Size(190, 180);
            this.commentsControl1.Name = "commentsControl1";
            this.commentsControl1.Size = new System.Drawing.Size(192, 397);
            this.commentsControl1.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionLabel,
            this.progressBar1,
            this.toolStripStatusLabelLoadingImage,
            this.progressBarImageLoading,
            this.imageInfoStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(951, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // actionLabel
            // 
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(118, 17);
            this.actionLabel.Text = "toolStripStatusLabel1";
            this.actionLabel.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            this.progressBar1.Visible = false;
            // 
            // toolStripStatusLabelLoadingImage
            // 
            this.toolStripStatusLabelLoadingImage.Name = "toolStripStatusLabelLoadingImage";
            this.toolStripStatusLabelLoadingImage.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabelLoadingImage.Text = "Loading image:";
            this.toolStripStatusLabelLoadingImage.Visible = false;
            // 
            // progressBarImageLoading
            // 
            this.progressBarImageLoading.Name = "progressBarImageLoading";
            this.progressBarImageLoading.Size = new System.Drawing.Size(100, 16);
            this.progressBarImageLoading.Visible = false;
            // 
            // imageInfoStatusLabel
            // 
            this.imageInfoStatusLabel.Name = "imageInfoStatusLabel";
            this.imageInfoStatusLabel.Size = new System.Drawing.Size(936, 17);
            this.imageInfoStatusLabel.Spring = true;
            this.imageInfoStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.AutoSize = false;
            this.zoomTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoomTrackBar.Location = new System.Drawing.Point(0, 50);
            this.zoomTrackBar.Maximum = 1000;
            this.zoomTrackBar.Minimum = 1;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(951, 39);
            this.zoomTrackBar.TabIndex = 5;
            this.zoomTrackBar.TickFrequency = 50;
            this.zoomTrackBar.Value = 100;
            // 
            // printDialog1
            // 
            this.printDialog1.AllowCurrentPage = true;
            this.printDialog1.AllowSelection = true;
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.ShowNetwork = false;
            // 
            // toolStripPanel1
            // 
            this.toolStripPanel1.Controls.Add(this.viewerToolStrip);
            this.toolStripPanel1.Controls.Add(this.visualToolsToolStrip1);
            this.toolStripPanel1.Controls.Add(this.selectionModeToolStrip);
            this.toolStripPanel1.Controls.Add(this.annotationsToolStrip1);
            this.toolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripPanel1.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanel1.Name = "toolStripPanel1";
            this.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolStripPanel1.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripPanel1.Size = new System.Drawing.Size(951, 50);
            // 
            // viewerToolStrip
            // 
            this.viewerToolStrip.AssociatedZoomTrackBar = this.zoomTrackBar;
            this.viewerToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.viewerToolStrip.ImageViewer = this.annotationViewer1;
            this.viewerToolStrip.IsScanEnabled = true;
            this.viewerToolStrip.Location = new System.Drawing.Point(3, 0);
            this.viewerToolStrip.Name = "viewerToolStrip";
            this.viewerToolStrip.PageCount = 0;
            this.viewerToolStrip.PrintButtonEnabled = true;
            this.viewerToolStrip.SaveButtonEnabled = true;
            this.viewerToolStrip.Size = new System.Drawing.Size(362, 25);
            this.viewerToolStrip.TabIndex = 2;
            this.viewerToolStrip.UseImageViewerImages = true;
            this.viewerToolStrip.OpenFile += new System.EventHandler(this.viewerToolStrip_OpenFile);
            this.viewerToolStrip.SaveFile += new System.EventHandler(this.viewerToolStrip_SaveFile);
            this.viewerToolStrip.Print += new System.EventHandler(this.viewerToolStrip_Print);
            // 
            // visualToolsToolStrip1
            // 
            this.visualToolsToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.visualToolsToolStrip1.Enabled = false;
            this.visualToolsToolStrip1.ImageViewer = null;
            this.visualToolsToolStrip1.Location = new System.Drawing.Point(520, 0);
            this.visualToolsToolStrip1.MandatoryVisualTool = null;
            this.visualToolsToolStrip1.Name = "visualToolsToolStrip1";
            this.visualToolsToolStrip1.Size = new System.Drawing.Size(35, 25);
            this.visualToolsToolStrip1.TabIndex = 4;
            this.visualToolsToolStrip1.VisualToolsMenuItem = this.visualToolsToolStripMenuItem;
            // 
            // selectionModeToolStrip
            // 
            this.selectionModeToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.selectionModeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.interactionModeToolStripLabel,
            this.annotationInteractionModeToolStripComboBox});
            this.selectionModeToolStrip.Location = new System.Drawing.Point(586, 0);
            this.selectionModeToolStrip.Name = "selectionModeToolStrip";
            this.selectionModeToolStrip.Size = new System.Drawing.Size(233, 25);
            this.selectionModeToolStrip.TabIndex = 3;
            // 
            // interactionModeToolStripLabel
            // 
            this.interactionModeToolStripLabel.Name = "interactionModeToolStripLabel";
            this.interactionModeToolStripLabel.Size = new System.Drawing.Size(98, 22);
            this.interactionModeToolStripLabel.Text = "Interaction Mode";
            // 
            // annotationInteractionModeToolStripComboBox
            // 
            this.annotationInteractionModeToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.annotationInteractionModeToolStripComboBox.Name = "annotationInteractionModeToolStripComboBox";
            this.annotationInteractionModeToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.annotationInteractionModeToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.annotationInteractionModeToolStripComboBox_SelectedIndexChanged);
            // 
            // annotationsToolStrip1
            // 
            this.annotationsToolStrip1.AnnotationViewer = null;
            this.annotationsToolStrip1.CommentBuilder = null;
            this.annotationsToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.annotationsToolStrip1.Location = new System.Drawing.Point(3, 25);
            this.annotationsToolStrip1.Name = "annotationsToolStrip1";
            this.annotationsToolStrip1.NeedBuildAnnotationsContinuously = false;
            this.annotationsToolStrip1.Size = new System.Drawing.Size(794, 25);
            this.annotationsToolStrip1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 564);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.zoomPanel);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(951, 540);
            this.panel3.TabIndex = 1;
            // 
            // zoomPanel
            // 
            this.zoomPanel.Controls.Add(this.splitContainer2);
            this.zoomPanel.Controls.Add(this.statusStrip1);
            this.zoomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoomPanel.Location = new System.Drawing.Point(0, 89);
            this.zoomPanel.Name = "zoomPanel";
            this.zoomPanel.Size = new System.Drawing.Size(951, 451);
            this.zoomPanel.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.zoomTrackBar);
            this.panel4.Controls.Add(this.toolStripPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(951, 89);
            this.panel4.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mainMenu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(951, 24);
            this.panel2.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 564);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(615, 420);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VintaSoft Annotation Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.annotationMenu.ResumeLayout(false);
            this.annotationViewerMenu.ResumeLayout(false);
            this.thumbnailMenu.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.propertiesTabPage.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.commentsTabPage.ResumeLayout(false);
            this.commentsPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            this.toolStripPanel1.ResumeLayout(false);
            this.toolStripPanel1.PerformLayout();
            this.selectionModeToolStrip.ResumeLayout(false);
            this.selectionModeToolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.zoomPanel.ResumeLayout(false);
            this.zoomPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private Vintasoft.Imaging.Annotation.UI.AnnotatedThumbnailViewer thumbnailViewer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel actionLabel;
		private System.Windows.Forms.ToolStripProgressBar progressBar1;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripPanel toolStripPanel1;

        private System.Windows.Forms.ToolStripMenuItem scaleModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestFitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fitToWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToHeightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorZoomModes;
        private System.Windows.Forms.ToolStripMenuItem scale25ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale50ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scale400ToolStripMenuItem;

		private System.Windows.Forms.ContextMenuStrip annotationMenu;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem bringToBackToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private Vintasoft.Imaging.Annotation.UI.AnnotationViewer annotationViewer1;
		private System.Windows.Forms.ToolStripStatusLabel imageInfoStatusLabel;
		private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TrackBar zoomTrackBar;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showEventsLogToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip thumbnailMenu;
        private System.Windows.Forms.ToolStripMenuItem thumbnailMenu_Save;
        private System.Windows.Forms.ToolStripMenuItem thumbnailMenu_Burn;
        private System.Windows.Forms.ToolStripMenuItem thumbnailMenu_CopyToClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem annotationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annotationsInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem thumbnailMenu_Delete;
        private System.Windows.Forms.ToolStripMenuItem burnAnnotationsOnImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar progressBarImageLoading;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLoadingImage;
        private AnnotationsToolStrip annotationsToolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel zoomPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private DemosCommonCode.Imaging.ImageViewerToolStrip viewerToolStrip;
        private System.Windows.Forms.ToolStrip selectionModeToolStrip;
        private System.Windows.Forms.ToolStripLabel interactionModeToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox annotationInteractionModeToolStripComboBox;
        private System.Windows.Forms.PropertyGrid annotationsPropertyGrid1;
        private System.Windows.Forms.ComboBox annotationComboBox;
        private System.Windows.Forms.ToolStripMenuItem annotationViewerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem thumbnailViewerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelToPixelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAnnotationTransformationOnThumbnailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateImageWithAnnotationsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TextBox annotationEventsLog;
        private System.Windows.Forms.ToolStripMenuItem cloneImageWithAnnotationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boundAnnotationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAnnotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bringToBackToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem highlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textHighlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embeddedImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referencedImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stickyNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freeTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rubberStampToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linesWithInterpolationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freehandLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonWithInterpolationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freehandPolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem angleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleCustomAnnotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem markCustomAnnotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem interactionModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem annotationInteractionModeNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annotationInteractionModeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annotationInteractionModeAuthorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableUndoRedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformationModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangularAndPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interactionPointsSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoRedoSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyDialogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem colorManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scrollViewerWhenAnnotationIsMovedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageDisplayModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singlePageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleContinuousRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleContinuousColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoContinuousRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoContinuousColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveAnnotationsBetweenImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHistoryForDisplayedImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildAnnotationsContinuouslyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem spellCheckSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spellCheckViewSettingsToolStripMenuItem;
        private DemosCommonCode.Imaging.VisualToolsToolStrip visualToolsToolStrip1;
        private System.Windows.Forms.ToolStripMenuItem visualToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage propertiesTabPage;
        private System.Windows.Forms.TabPage commentsTabPage;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel commentsPanel;
        private AnnotationCommentsControl commentsControl1;
        private System.Windows.Forms.ToolStripMenuItem rotateViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateClockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateCounterclockwiseToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip annotationViewerMenu;
        private System.Windows.Forms.ToolStripMenuItem saveImageWithAnnotationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem burnAnnotationsOnImage2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyImageToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutAnnotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAnnotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteAnnotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAnnotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
    }
}
