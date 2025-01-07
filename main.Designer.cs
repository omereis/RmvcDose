namespace RmvDose
{
    partial class main
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
			this.btnOpen = new System.Windows.Forms.Button();
			this.dlgOpenCsv = new System.Windows.Forms.OpenFileDialog();
			this.txtbxFile = new System.Windows.Forms.TextBox();
			this.gridCSV = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnRate = new System.Windows.Forms.Button();
			this.btnDose = new System.Windows.Forms.Button();
			this.btnParse = new System.Windows.Forms.Button();
			this.txtbxRecords = new System.Windows.Forms.TextBox();
			this.chartRate = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabRate = new System.Windows.Forms.TabPage();
			this.clboxRates = new System.Windows.Forms.CheckedListBox();
			this.popupClbox = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.miEditSer = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSaveRate = new System.Windows.Forms.Button();
			this.btnRateEdit = new System.Windows.Forms.Button();
			this.btnCopyRate = new System.Windows.Forms.Button();
			this.tabDose = new System.Windows.Forms.TabPage();
			this.btnExport = new System.Windows.Forms.Button();
			this.clboxDose = new System.Windows.Forms.CheckedListBox();
			this.btnNormSer = new System.Windows.Forms.Button();
			this.btnCalcDoseSer = new System.Windows.Forms.Button();
			this.btnSaveDose = new System.Windows.Forms.Button();
			this.btnCopyDose = new System.Windows.Forms.Button();
			this.btnDoseSer = new System.Windows.Forms.Button();
			this.chartDose = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.btnCalcDose = new System.Windows.Forms.Button();
			this.dlgSavePic = new System.Windows.Forms.SaveFileDialog();
			this.btnAbout = new System.Windows.Forms.Button();
			this.dlgSaveCsv = new System.Windows.Forms.SaveFileDialog();
			this.btnAnalyze = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.txtbxPctMin = new System.Windows.Forms.TextBox();
			this.txtbxPctMax = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtbxMin = new System.Windows.Forms.TextBox();
			this.txtbxMax = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtbxAvg = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.gridCSV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartRate)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabRate.SuspendLayout();
			this.popupClbox.SuspendLayout();
			this.tabDose.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartDose)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(12, 41);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(75, 23);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "&Open...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// dlgOpenCsv
			// 
			this.dlgOpenCsv.DefaultExt = "*.csv";
			this.dlgOpenCsv.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
			// 
			// txtbxFile
			// 
			this.txtbxFile.Location = new System.Drawing.Point(93, 44);
			this.txtbxFile.Name = "txtbxFile";
			this.txtbxFile.Size = new System.Drawing.Size(323, 20);
			this.txtbxFile.TabIndex = 2;
			// 
			// gridCSV
			// 
			this.gridCSV.AllowUserToAddRows = false;
			this.gridCSV.AllowUserToDeleteRows = false;
			this.gridCSV.AllowUserToOrderColumns = true;
			this.gridCSV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.gridCSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridCSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
			this.gridCSV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.gridCSV.Location = new System.Drawing.Point(12, 77);
			this.gridCSV.Name = "gridCSV";
			this.gridCSV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.gridCSV.RowHeadersVisible = false;
			this.gridCSV.Size = new System.Drawing.Size(335, 351);
			this.gridCSV.TabIndex = 3;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Date Time";
			this.Column1.Name = "Column1";
			this.Column1.Width = 70;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Device";
			this.Column2.Name = "Column2";
			this.Column2.Width = 50;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Rate";
			this.Column3.Name = "Column3";
			this.Column3.Width = 70;
			// 
			// Column4
			// 
			this.Column4.HeaderText = "Dose";
			this.Column4.Name = "Column4";
			this.Column4.Width = 70;
			// 
			// Column5
			// 
			this.Column5.HeaderText = "Status";
			this.Column5.Name = "Column5";
			this.Column5.Width = 50;
			// 
			// btnRate
			// 
			this.btnRate.Location = new System.Drawing.Point(357, 356);
			this.btnRate.Name = "btnRate";
			this.btnRate.Size = new System.Drawing.Size(75, 23);
			this.btnRate.TabIndex = 4;
			this.btnRate.Text = "Rate";
			this.btnRate.UseVisualStyleBackColor = true;
			this.btnRate.Visible = false;
			this.btnRate.Click += new System.EventHandler(this.btnRate_Click);
			// 
			// btnDose
			// 
			this.btnDose.Location = new System.Drawing.Point(353, 385);
			this.btnDose.Name = "btnDose";
			this.btnDose.Size = new System.Drawing.Size(75, 23);
			this.btnDose.TabIndex = 5;
			this.btnDose.Text = "Dose";
			this.btnDose.UseVisualStyleBackColor = true;
			this.btnDose.Visible = false;
			this.btnDose.Click += new System.EventHandler(this.btnDose_Click);
			// 
			// btnParse
			// 
			this.btnParse.Location = new System.Drawing.Point(353, 77);
			this.btnParse.Name = "btnParse";
			this.btnParse.Size = new System.Drawing.Size(75, 23);
			this.btnParse.TabIndex = 6;
			this.btnParse.Text = "Parse";
			this.btnParse.UseVisualStyleBackColor = true;
			this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
			// 
			// txtbxRecords
			// 
			this.txtbxRecords.Location = new System.Drawing.Point(357, 109);
			this.txtbxRecords.Name = "txtbxRecords";
			this.txtbxRecords.Size = new System.Drawing.Size(59, 20);
			this.txtbxRecords.TabIndex = 7;
			// 
			// chartRate
			// 
			this.chartRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.Name = "ChartArea1";
			this.chartRate.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chartRate.Legends.Add(legend1);
			this.chartRate.Location = new System.Drawing.Point(46, 70);
			this.chartRate.Name = "chartRate";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chartRate.Series.Add(series1);
			this.chartRate.Size = new System.Drawing.Size(549, 393);
			this.chartRate.TabIndex = 8;
			this.chartRate.Text = "chart1";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabRate);
			this.tabControl1.Controls.Add(this.tabDose);
			this.tabControl1.Location = new System.Drawing.Point(521, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(606, 494);
			this.tabControl1.TabIndex = 9;
			// 
			// tabRate
			// 
			this.tabRate.Controls.Add(this.clboxRates);
			this.tabRate.Controls.Add(this.btnSaveRate);
			this.tabRate.Controls.Add(this.btnRateEdit);
			this.tabRate.Controls.Add(this.btnCopyRate);
			this.tabRate.Controls.Add(this.chartRate);
			this.tabRate.Location = new System.Drawing.Point(4, 22);
			this.tabRate.Name = "tabRate";
			this.tabRate.Padding = new System.Windows.Forms.Padding(3);
			this.tabRate.Size = new System.Drawing.Size(598, 468);
			this.tabRate.TabIndex = 0;
			this.tabRate.Text = "Rate";
			this.tabRate.UseVisualStyleBackColor = true;
			// 
			// clboxRates
			// 
			this.clboxRates.ContextMenuStrip = this.popupClbox;
			this.clboxRates.FormattingEnabled = true;
			this.clboxRates.Location = new System.Drawing.Point(399, 3);
			this.clboxRates.Name = "clboxRates";
			this.clboxRates.Size = new System.Drawing.Size(120, 64);
			this.clboxRates.TabIndex = 14;
			this.clboxRates.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clboxRates_ItemCheck_1);
			this.clboxRates.MouseMove += new System.Windows.Forms.MouseEventHandler(this.clboxRates_MouseMove);
			this.clboxRates.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clboxRates_MouseUp);
			// 
			// popupClbox
			// 
			this.popupClbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditSer});
			this.popupClbox.Name = "popupClbox";
			this.popupClbox.Size = new System.Drawing.Size(137, 26);
			this.popupClbox.Opening += new System.ComponentModel.CancelEventHandler(this.popupClbox_Opening);
			// 
			// miEditSer
			// 
			this.miEditSer.Name = "miEditSer";
			this.miEditSer.Size = new System.Drawing.Size(136, 22);
			this.miEditSer.Text = "Edit Series...";
			this.miEditSer.Click += new System.EventHandler(this.miEditSer_Click);
			// 
			// btnSaveRate
			// 
			this.btnSaveRate.Location = new System.Drawing.Point(153, 7);
			this.btnSaveRate.Name = "btnSaveRate";
			this.btnSaveRate.Size = new System.Drawing.Size(75, 23);
			this.btnSaveRate.TabIndex = 13;
			this.btnSaveRate.Text = "Save...";
			this.btnSaveRate.UseVisualStyleBackColor = true;
			this.btnSaveRate.Click += new System.EventHandler(this.btnSaveRate_Click);
			// 
			// btnRateEdit
			// 
			this.btnRateEdit.Location = new System.Drawing.Point(234, 7);
			this.btnRateEdit.Name = "btnRateEdit";
			this.btnRateEdit.Size = new System.Drawing.Size(87, 23);
			this.btnRateEdit.TabIndex = 12;
			this.btnRateEdit.Text = "Rate Series...";
			this.btnRateEdit.UseVisualStyleBackColor = true;
			this.btnRateEdit.Visible = false;
			this.btnRateEdit.Click += new System.EventHandler(this.btnRateSer_Click);
			// 
			// btnCopyRate
			// 
			this.btnCopyRate.Location = new System.Drawing.Point(46, 7);
			this.btnCopyRate.Name = "btnCopyRate";
			this.btnCopyRate.Size = new System.Drawing.Size(75, 23);
			this.btnCopyRate.TabIndex = 12;
			this.btnCopyRate.Text = "Copy";
			this.btnCopyRate.UseVisualStyleBackColor = true;
			this.btnCopyRate.Click += new System.EventHandler(this.btnCopyRate_Click_1);
			// 
			// tabDose
			// 
			this.tabDose.Controls.Add(this.btnExport);
			this.tabDose.Controls.Add(this.clboxDose);
			this.tabDose.Controls.Add(this.btnNormSer);
			this.tabDose.Controls.Add(this.btnCalcDoseSer);
			this.tabDose.Controls.Add(this.btnSaveDose);
			this.tabDose.Controls.Add(this.btnCopyDose);
			this.tabDose.Controls.Add(this.btnDoseSer);
			this.tabDose.Controls.Add(this.chartDose);
			this.tabDose.Location = new System.Drawing.Point(4, 22);
			this.tabDose.Name = "tabDose";
			this.tabDose.Padding = new System.Windows.Forms.Padding(3);
			this.tabDose.Size = new System.Drawing.Size(581, 468);
			this.tabDose.TabIndex = 1;
			this.tabDose.Text = "Dose";
			this.tabDose.UseVisualStyleBackColor = true;
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(249, 6);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 23);
			this.btnExport.TabIndex = 16;
			this.btnExport.Text = "Export...";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// clboxDose
			// 
			this.clboxDose.ContextMenuStrip = this.popupClbox;
			this.clboxDose.FormattingEnabled = true;
			this.clboxDose.Location = new System.Drawing.Point(373, 2);
			this.clboxDose.Name = "clboxDose";
			this.clboxDose.Size = new System.Drawing.Size(149, 64);
			this.clboxDose.TabIndex = 15;
			this.clboxDose.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clboxDose_ItemCheck_1);
			this.clboxDose.DoubleClick += new System.EventHandler(this.clboxDose_DoubleClick);
			this.clboxDose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clboxDose_MouseUp);
			// 
			// btnNormSer
			// 
			this.btnNormSer.Location = new System.Drawing.Point(168, 6);
			this.btnNormSer.Name = "btnNormSer";
			this.btnNormSer.Size = new System.Drawing.Size(75, 23);
			this.btnNormSer.TabIndex = 14;
			this.btnNormSer.Text = "Normalized...";
			this.btnNormSer.UseVisualStyleBackColor = true;
			this.btnNormSer.Click += new System.EventHandler(this.btnNormSer_Click);
			// 
			// btnCalcDoseSer
			// 
			this.btnCalcDoseSer.Location = new System.Drawing.Point(3, 51);
			this.btnCalcDoseSer.Name = "btnCalcDoseSer";
			this.btnCalcDoseSer.Size = new System.Drawing.Size(124, 23);
			this.btnCalcDoseSer.TabIndex = 13;
			this.btnCalcDoseSer.Text = "Calculated Series...";
			this.btnCalcDoseSer.UseVisualStyleBackColor = true;
			this.btnCalcDoseSer.Visible = false;
			this.btnCalcDoseSer.Click += new System.EventHandler(this.btnCalcDoseSer_Click);
			// 
			// btnSaveDose
			// 
			this.btnSaveDose.Location = new System.Drawing.Point(87, 6);
			this.btnSaveDose.Name = "btnSaveDose";
			this.btnSaveDose.Size = new System.Drawing.Size(75, 23);
			this.btnSaveDose.TabIndex = 11;
			this.btnSaveDose.Text = "Save...";
			this.btnSaveDose.UseVisualStyleBackColor = true;
			this.btnSaveDose.Click += new System.EventHandler(this.btnSaveDose_Click);
			// 
			// btnCopyDose
			// 
			this.btnCopyDose.Location = new System.Drawing.Point(6, 4);
			this.btnCopyDose.Name = "btnCopyDose";
			this.btnCopyDose.Size = new System.Drawing.Size(75, 23);
			this.btnCopyDose.TabIndex = 10;
			this.btnCopyDose.Text = "Copy";
			this.btnCopyDose.UseVisualStyleBackColor = true;
			this.btnCopyDose.Click += new System.EventHandler(this.btnCopyDose_Click);
			// 
			// btnDoseSer
			// 
			this.btnDoseSer.Location = new System.Drawing.Point(148, 51);
			this.btnDoseSer.Name = "btnDoseSer";
			this.btnDoseSer.Size = new System.Drawing.Size(86, 23);
			this.btnDoseSer.TabIndex = 10;
			this.btnDoseSer.Text = "Dose Series...";
			this.btnDoseSer.UseVisualStyleBackColor = true;
			this.btnDoseSer.Visible = false;
			this.btnDoseSer.Click += new System.EventHandler(this.btnDoseSer_Click);
			// 
			// chartDose
			// 
			this.chartDose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea2.Name = "ChartArea1";
			this.chartDose.ChartAreas.Add(chartArea2);
			legend2.Name = "Legend1";
			this.chartDose.Legends.Add(legend2);
			this.chartDose.Location = new System.Drawing.Point(6, 70);
			this.chartDose.Name = "chartDose";
			series2.ChartArea = "ChartArea1";
			series2.Legend = "Legend1";
			series2.Name = "Series1";
			this.chartDose.Series.Add(series2);
			this.chartDose.Size = new System.Drawing.Size(516, 324);
			this.chartDose.TabIndex = 9;
			this.chartDose.Text = "chart1";
			// 
			// btnCalcDose
			// 
			this.btnCalcDose.Location = new System.Drawing.Point(353, 414);
			this.btnCalcDose.Name = "btnCalcDose";
			this.btnCalcDose.Size = new System.Drawing.Size(75, 23);
			this.btnCalcDose.TabIndex = 11;
			this.btnCalcDose.Text = "Calculate";
			this.btnCalcDose.UseVisualStyleBackColor = true;
			this.btnCalcDose.Visible = false;
			this.btnCalcDose.Click += new System.EventHandler(this.btnCalcDose_Click);
			// 
			// dlgSavePic
			// 
			this.dlgSavePic.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|GIF files (*.gif)|*.gif|Bitmap f" +
    "iles (*.bmp)|*.bmp";
			// 
			// btnAbout
			// 
			this.btnAbout.Location = new System.Drawing.Point(12, 12);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(75, 23);
			this.btnAbout.TabIndex = 12;
			this.btnAbout.Text = "About...";
			this.btnAbout.UseVisualStyleBackColor = true;
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// dlgSaveCsv
			// 
			this.dlgSaveCsv.DefaultExt = "*.csv";
			this.dlgSaveCsv.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
			// 
			// btnAnalyze
			// 
			this.btnAnalyze.Location = new System.Drawing.Point(361, 158);
			this.btnAnalyze.Name = "btnAnalyze";
			this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
			this.btnAnalyze.TabIndex = 13;
			this.btnAnalyze.Text = "Analyze";
			this.btnAnalyze.UseVisualStyleBackColor = true;
			this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.txtbxPctMin);
			this.panel1.Controls.Add(this.txtbxPctMax);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtbxMin);
			this.panel1.Controls.Add(this.txtbxMax);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtbxAvg);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(353, 187);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(162, 96);
			this.panel1.TabIndex = 14;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(104, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Error (%)";
			// 
			// txtbxPctMin
			// 
			this.txtbxPctMin.Location = new System.Drawing.Point(104, 64);
			this.txtbxPctMin.Name = "txtbxPctMin";
			this.txtbxPctMin.Size = new System.Drawing.Size(49, 20);
			this.txtbxPctMin.TabIndex = 7;
			this.txtbxPctMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtbxPctMax
			// 
			this.txtbxPctMax.Location = new System.Drawing.Point(104, 38);
			this.txtbxPctMax.Name = "txtbxPctMax";
			this.txtbxPctMax.Size = new System.Drawing.Size(49, 20);
			this.txtbxPctMax.TabIndex = 6;
			this.txtbxPctMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Minimum";
			// 
			// txtbxMin
			// 
			this.txtbxMin.Location = new System.Drawing.Point(58, 64);
			this.txtbxMin.Name = "txtbxMin";
			this.txtbxMin.Size = new System.Drawing.Size(40, 20);
			this.txtbxMin.TabIndex = 4;
			this.txtbxMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtbxMax
			// 
			this.txtbxMax.Location = new System.Drawing.Point(58, 38);
			this.txtbxMax.Name = "txtbxMax";
			this.txtbxMax.Size = new System.Drawing.Size(40, 20);
			this.txtbxMax.TabIndex = 3;
			this.txtbxMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Maximum";
			// 
			// txtbxAvg
			// 
			this.txtbxAvg.Location = new System.Drawing.Point(58, 14);
			this.txtbxAvg.Name = "txtbxAvg";
			this.txtbxAvg.Size = new System.Drawing.Size(40, 20);
			this.txtbxAvg.TabIndex = 1;
			this.txtbxAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Average";
			// 
			// main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1139, 518);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnAnalyze);
			this.Controls.Add(this.btnAbout);
			this.Controls.Add(this.btnCalcDose);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.txtbxRecords);
			this.Controls.Add(this.btnParse);
			this.Controls.Add(this.btnDose);
			this.Controls.Add(this.btnRate);
			this.Controls.Add(this.gridCSV);
			this.Controls.Add(this.txtbxFile);
			this.Controls.Add(this.btnOpen);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "main";
			this.Text = "RMVC Dose Calculator";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_FormClosed);
			this.Load += new System.EventHandler(this.main_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridCSV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartRate)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabRate.ResumeLayout(false);
			this.popupClbox.ResumeLayout(false);
			this.tabDose.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartDose)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog dlgOpenCsv;
        private System.Windows.Forms.TextBox txtbxFile;
		private System.Windows.Forms.DataGridView gridCSV;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.Button btnRate;
		private System.Windows.Forms.Button btnDose;
		private System.Windows.Forms.Button btnParse;
		private System.Windows.Forms.TextBox txtbxRecords;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartRate;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabRate;
		private System.Windows.Forms.TabPage tabDose;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartDose;
		private System.Windows.Forms.Button btnDoseSer;
		private System.Windows.Forms.Button btnCalcDose;
		private System.Windows.Forms.Button btnRateEdit;
		private System.Windows.Forms.Button btnCalcDoseSer;
		private System.Windows.Forms.Button btnSaveDose;
		private System.Windows.Forms.Button btnCopyDose;
		private System.Windows.Forms.Button btnSaveRate;
		private System.Windows.Forms.Button btnCopyRate;
		private System.Windows.Forms.SaveFileDialog dlgSavePic;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.Button btnNormSer;
		private System.Windows.Forms.CheckedListBox clboxRates;
		private System.Windows.Forms.CheckedListBox clboxDose;
		private System.Windows.Forms.ContextMenuStrip popupClbox;
		private System.Windows.Forms.ToolStripMenuItem miEditSer;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.SaveFileDialog dlgSaveCsv;
		private System.Windows.Forms.Button btnAnalyze;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtbxMax;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtbxAvg;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtbxMin;
		private System.Windows.Forms.TextBox txtbxPctMin;
		private System.Windows.Forms.TextBox txtbxPctMax;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}

