
namespace DemosCommonCode.Office
{
    partial class OpenXmlDocumentChartDataForm
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
            this.chartDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonOk = new System.Windows.Forms.Button();
            this.chartComboBox = new System.Windows.Forms.ComboBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.removeRowButton = new System.Windows.Forms.Button();
            this.insertRowButton = new System.Windows.Forms.Button();
            this.insertColumnButton = new System.Windows.Forms.Button();
            this.removeColumnButton = new System.Windows.Forms.Button();
            this.clearRowButton = new System.Windows.Forms.Button();
            this.clearColumnButton = new System.Windows.Forms.Button();
            this.seriesColorLabel = new System.Windows.Forms.Label();
            this.addRowButton = new System.Windows.Forms.Button();
            this.addColumnButton = new System.Windows.Forms.Button();
            this.markerColorLabel = new System.Windows.Forms.Label();
            this.dataPointColorLabel = new System.Windows.Forms.Label();
            this.seriesMarkerStyleLabel = new System.Windows.Forms.Label();
            this.seriesMarkerStyleComboBox = new System.Windows.Forms.ComboBox();
            this.dataPointColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.markerColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.seriesColorPanelControl = new DemosCommonCode.CustomControls.ColorPanelControl();
            this.seriesMarkerSizeLabel = new System.Windows.Forms.Label();
            this.seriesMarkerSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.chartDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesMarkerSizeNumericUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartDataGridView
            // 
            this.chartDataGridView.AllowUserToAddRows = false;
            this.chartDataGridView.AllowUserToDeleteRows = false;
            this.chartDataGridView.AllowUserToResizeRows = false;
            this.chartDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.chartDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chartDataGridView.ColumnHeadersVisible = false;
            this.chartDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDataGridView.Location = new System.Drawing.Point(3, 42);
            this.chartDataGridView.MultiSelect = false;
            this.chartDataGridView.Name = "chartDataGridView";
            this.chartDataGridView.RowHeadersVisible = false;
            this.chartDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.chartDataGridView.ShowCellToolTips = false;
            this.chartDataGridView.Size = new System.Drawing.Size(290, 248);
            this.chartDataGridView.TabIndex = 0;
            this.chartDataGridView.SelectionChanged += new System.EventHandler(this.chartDataGridView_SelectionChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(659, 326);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // chartComboBox
            // 
            this.chartComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chartComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chartComboBox.FormattingEnabled = true;
            this.chartComboBox.Location = new System.Drawing.Point(3, 16);
            this.chartComboBox.Name = "chartComboBox";
            this.chartComboBox.Size = new System.Drawing.Size(206, 21);
            this.chartComboBox.TabIndex = 6;
            this.chartComboBox.SelectedIndexChanged += new System.EventHandler(this.chartComboBox_SelectedIndexChanged);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(3, 16);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(290, 20);
            this.titleTextBox.TabIndex = 7;
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Chart Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Title";
            // 
            // removeRowButton
            // 
            this.removeRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.removeRowButton.Location = new System.Drawing.Point(109, 32);
            this.removeRowButton.Name = "removeRowButton";
            this.removeRowButton.Size = new System.Drawing.Size(100, 23);
            this.removeRowButton.TabIndex = 10;
            this.removeRowButton.Text = "Remove Row";
            this.removeRowButton.UseVisualStyleBackColor = true;
            this.removeRowButton.Click += new System.EventHandler(this.removeRowButton_Click);
            // 
            // insertRowButton
            // 
            this.insertRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.insertRowButton.Location = new System.Drawing.Point(109, 3);
            this.insertRowButton.Name = "insertRowButton";
            this.insertRowButton.Size = new System.Drawing.Size(100, 23);
            this.insertRowButton.TabIndex = 11;
            this.insertRowButton.Text = "Insert Row";
            this.insertRowButton.UseVisualStyleBackColor = true;
            this.insertRowButton.Click += new System.EventHandler(this.insertRowButton_Click);
            // 
            // insertColumnButton
            // 
            this.insertColumnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.insertColumnButton.Location = new System.Drawing.Point(109, 61);
            this.insertColumnButton.Name = "insertColumnButton";
            this.insertColumnButton.Size = new System.Drawing.Size(100, 23);
            this.insertColumnButton.TabIndex = 13;
            this.insertColumnButton.Text = "Insert Column";
            this.insertColumnButton.UseVisualStyleBackColor = true;
            this.insertColumnButton.Click += new System.EventHandler(this.insertColumnButton_Click);
            // 
            // removeColumnButton
            // 
            this.removeColumnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.removeColumnButton.Location = new System.Drawing.Point(109, 90);
            this.removeColumnButton.Name = "removeColumnButton";
            this.removeColumnButton.Size = new System.Drawing.Size(100, 23);
            this.removeColumnButton.TabIndex = 12;
            this.removeColumnButton.Text = "Remove Column";
            this.removeColumnButton.UseVisualStyleBackColor = true;
            this.removeColumnButton.Click += new System.EventHandler(this.removeColumnButton_Click);
            // 
            // clearRowButton
            // 
            this.clearRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clearRowButton.Location = new System.Drawing.Point(3, 32);
            this.clearRowButton.Name = "clearRowButton";
            this.clearRowButton.Size = new System.Drawing.Size(100, 23);
            this.clearRowButton.TabIndex = 16;
            this.clearRowButton.Text = "Clear Row";
            this.clearRowButton.UseVisualStyleBackColor = true;
            this.clearRowButton.Click += new System.EventHandler(this.clearRowButton_Click);
            // 
            // clearColumnButton
            // 
            this.clearColumnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clearColumnButton.Location = new System.Drawing.Point(3, 90);
            this.clearColumnButton.Name = "clearColumnButton";
            this.clearColumnButton.Size = new System.Drawing.Size(100, 23);
            this.clearColumnButton.TabIndex = 17;
            this.clearColumnButton.Text = "Clear Column";
            this.clearColumnButton.UseVisualStyleBackColor = true;
            this.clearColumnButton.Click += new System.EventHandler(this.clearColumnButton_Click);
            // 
            // seriesColorLabel
            // 
            this.seriesColorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.seriesColorLabel.AutoSize = true;
            this.seriesColorLabel.Location = new System.Drawing.Point(3, 0);
            this.seriesColorLabel.Name = "seriesColorLabel";
            this.seriesColorLabel.Size = new System.Drawing.Size(100, 13);
            this.seriesColorLabel.TabIndex = 19;
            this.seriesColorLabel.Text = "Series Color";
            // 
            // addRowButton
            // 
            this.addRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addRowButton.Location = new System.Drawing.Point(3, 3);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(100, 23);
            this.addRowButton.TabIndex = 20;
            this.addRowButton.Text = "Add Row";
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.addRowButton_Click);
            // 
            // addColumnButton
            // 
            this.addColumnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addColumnButton.Location = new System.Drawing.Point(3, 61);
            this.addColumnButton.Name = "addColumnButton";
            this.addColumnButton.Size = new System.Drawing.Size(100, 23);
            this.addColumnButton.TabIndex = 21;
            this.addColumnButton.Text = "Add Column";
            this.addColumnButton.UseVisualStyleBackColor = true;
            this.addColumnButton.Click += new System.EventHandler(this.addColumnButton_Click);
            // 
            // markerColorLabel
            // 
            this.markerColorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.markerColorLabel.AutoSize = true;
            this.markerColorLabel.Location = new System.Drawing.Point(109, 0);
            this.markerColorLabel.Name = "markerColorLabel";
            this.markerColorLabel.Size = new System.Drawing.Size(100, 13);
            this.markerColorLabel.TabIndex = 23;
            this.markerColorLabel.Text = "Series Marker Color";
            // 
            // dataPointColorLabel
            // 
            this.dataPointColorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPointColorLabel.AutoSize = true;
            this.dataPointColorLabel.Location = new System.Drawing.Point(3, 82);
            this.dataPointColorLabel.Name = "dataPointColorLabel";
            this.dataPointColorLabel.Size = new System.Drawing.Size(100, 13);
            this.dataPointColorLabel.TabIndex = 25;
            this.dataPointColorLabel.Text = "Data Point Color";
            // 
            // seriesMarkerStyleLabel
            // 
            this.seriesMarkerStyleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.seriesMarkerStyleLabel.AutoSize = true;
            this.seriesMarkerStyleLabel.Location = new System.Drawing.Point(3, 41);
            this.seriesMarkerStyleLabel.Name = "seriesMarkerStyleLabel";
            this.seriesMarkerStyleLabel.Size = new System.Drawing.Size(100, 13);
            this.seriesMarkerStyleLabel.TabIndex = 26;
            this.seriesMarkerStyleLabel.Text = "Series Marker Type";
            // 
            // seriesMarkerStyleComboBox
            // 
            this.seriesMarkerStyleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seriesMarkerStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seriesMarkerStyleComboBox.FormattingEnabled = true;
            this.seriesMarkerStyleComboBox.Location = new System.Drawing.Point(3, 57);
            this.seriesMarkerStyleComboBox.Name = "seriesMarkerStyleComboBox";
            this.seriesMarkerStyleComboBox.Size = new System.Drawing.Size(100, 21);
            this.seriesMarkerStyleComboBox.TabIndex = 27;
            this.seriesMarkerStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.seriesMarkerStyleComboBox_SelectedIndexChanged);
            // 
            // dataPointColorPanelControl
            // 
            this.dataPointColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPointColorPanelControl.CanEditAlphaChannel = false;
            this.dataPointColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.dataPointColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.dataPointColorPanelControl.Location = new System.Drawing.Point(3, 98);
            this.dataPointColorPanelControl.Name = "dataPointColorPanelControl";
            this.dataPointColorPanelControl.ShowColorDialogOnClick = true;
            this.dataPointColorPanelControl.ShowColorDialogOnDoubleClick = false;
            this.dataPointColorPanelControl.Size = new System.Drawing.Size(100, 22);
            this.dataPointColorPanelControl.TabIndex = 24;
            this.dataPointColorPanelControl.ColorChanged += new System.EventHandler(this.dataPointColorPanelControl_ColorChanged);
            // 
            // markerColorPanelControl
            // 
            this.markerColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.markerColorPanelControl.CanEditAlphaChannel = false;
            this.markerColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.markerColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.markerColorPanelControl.Location = new System.Drawing.Point(109, 16);
            this.markerColorPanelControl.Name = "markerColorPanelControl";
            this.markerColorPanelControl.ShowColorDialogOnClick = true;
            this.markerColorPanelControl.ShowColorDialogOnDoubleClick = false;
            this.markerColorPanelControl.Size = new System.Drawing.Size(100, 22);
            this.markerColorPanelControl.TabIndex = 22;
            this.markerColorPanelControl.ColorChanged += new System.EventHandler(this.markerColorPanelControl_ColorChanged);
            // 
            // seriesColorPanelControl
            // 
            this.seriesColorPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seriesColorPanelControl.CanEditAlphaChannel = false;
            this.seriesColorPanelControl.Color = System.Drawing.Color.Transparent;
            this.seriesColorPanelControl.DefaultColor = System.Drawing.Color.Empty;
            this.seriesColorPanelControl.Location = new System.Drawing.Point(3, 16);
            this.seriesColorPanelControl.Name = "seriesColorPanelControl";
            this.seriesColorPanelControl.ShowColorDialogOnClick = true;
            this.seriesColorPanelControl.ShowColorDialogOnDoubleClick = false;
            this.seriesColorPanelControl.Size = new System.Drawing.Size(100, 22);
            this.seriesColorPanelControl.TabIndex = 18;
            this.seriesColorPanelControl.ColorChanged += new System.EventHandler(this.seriesColorPanelControl_ColorChanged);
            // 
            // seriesMarkerSizeLabel
            // 
            this.seriesMarkerSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.seriesMarkerSizeLabel.AutoSize = true;
            this.seriesMarkerSizeLabel.Location = new System.Drawing.Point(109, 41);
            this.seriesMarkerSizeLabel.Name = "seriesMarkerSizeLabel";
            this.seriesMarkerSizeLabel.Size = new System.Drawing.Size(100, 13);
            this.seriesMarkerSizeLabel.TabIndex = 28;
            this.seriesMarkerSizeLabel.Text = "Series Marker Size";
            // 
            // seriesMarkerSizeNumericUpDown
            // 
            this.seriesMarkerSizeNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seriesMarkerSizeNumericUpDown.Location = new System.Drawing.Point(109, 57);
            this.seriesMarkerSizeNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.seriesMarkerSizeNumericUpDown.Name = "seriesMarkerSizeNumericUpDown";
            this.seriesMarkerSizeNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.seriesMarkerSizeNumericUpDown.TabIndex = 29;
            this.seriesMarkerSizeNumericUpDown.ValueChanged += new System.EventHandler(this.seriesMarkerSizeNumericUpDown_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.addRowButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.insertRowButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.clearRowButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.removeRowButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.addColumnButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.insertColumnButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.clearColumnButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.removeColumnButton, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(212, 116);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.seriesMarkerStyleLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.seriesMarkerSizeLabel, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.markerColorPanelControl, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.markerColorLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataPointColorPanelControl, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.dataPointColorLabel, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.seriesColorPanelControl, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.seriesColorLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.seriesMarkerSizeNumericUpDown, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.seriesMarkerStyleComboBox, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(508, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(212, 124);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.chartComboBox, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(212, 293);
            this.tableLayoutPanel3.TabIndex = 32;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(744, 0);
            this.tableLayoutPanel4.TabIndex = 33;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.titleTextBox, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.chartDataGridView, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(212, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(296, 293);
            this.tableLayoutPanel5.TabIndex = 34;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(720, 293);
            this.tableLayoutPanel6.TabIndex = 35;
            // 
            // OpenXmlDocumentChartDataForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 361);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.buttonOk);
            this.MinimizeBox = false;
            this.Name = "OpenXmlDocumentChartDataForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Document Charts";
            ((System.ComponentModel.ISupportInitialize)(this.chartDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesMarkerSizeNumericUpDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView chartDataGridView;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ComboBox chartComboBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeRowButton;
        private System.Windows.Forms.Button insertRowButton;
        private System.Windows.Forms.Button insertColumnButton;
        private System.Windows.Forms.Button removeColumnButton;
        private System.Windows.Forms.Button clearRowButton;
        private System.Windows.Forms.Button clearColumnButton;
        private CustomControls.ColorPanelControl seriesColorPanelControl;
        private System.Windows.Forms.Label seriesColorLabel;
        private System.Windows.Forms.Button addRowButton;
        private System.Windows.Forms.Button addColumnButton;
        private System.Windows.Forms.Label markerColorLabel;
        private CustomControls.ColorPanelControl markerColorPanelControl;
        private System.Windows.Forms.Label dataPointColorLabel;
        private CustomControls.ColorPanelControl dataPointColorPanelControl;
        private System.Windows.Forms.Label seriesMarkerStyleLabel;
        private System.Windows.Forms.ComboBox seriesMarkerStyleComboBox;
        private System.Windows.Forms.Label seriesMarkerSizeLabel;
        private System.Windows.Forms.NumericUpDown seriesMarkerSizeNumericUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
    }
}