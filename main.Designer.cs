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
			this.btnSaveRate = new System.Windows.Forms.Button();
			this.btnRateEdit = new System.Windows.Forms.Button();
			this.btnCopyRate = new System.Windows.Forms.Button();
			this.tabDose = new System.Windows.Forms.TabPage();
			this.btnCalcDoseSer = new System.Windows.Forms.Button();
			this.btnSaveDose = new System.Windows.Forms.Button();
			this.btnCopyDose = new System.Windows.Forms.Button();
			this.btnDoseSer = new System.Windows.Forms.Button();
			this.chartDose = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.btnCalcDose = new System.Windows.Forms.Button();
			this.dlgSavePic = new System.Windows.Forms.SaveFileDialog();
			this.btnAbout = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridCSV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartRate)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabRate.SuspendLayout();
			this.tabDose.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartDose)).BeginInit();
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
			this.chartRate.Location = new System.Drawing.Point(6, 36);
			this.chartRate.Name = "chartRate";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chartRate.Series.Add(series1);
			this.chartRate.Size = new System.Drawing.Size(489, 358);
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
			this.tabControl1.Location = new System.Drawing.Point(438, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(509, 425);
			this.tabControl1.TabIndex = 9;
			// 
			// tabRate
			// 
			this.tabRate.Controls.Add(this.btnSaveRate);
			this.tabRate.Controls.Add(this.btnRateEdit);
			this.tabRate.Controls.Add(this.btnCopyRate);
			this.tabRate.Controls.Add(this.chartRate);
			this.tabRate.Location = new System.Drawing.Point(4, 22);
			this.tabRate.Name = "tabRate";
			this.tabRate.Padding = new System.Windows.Forms.Padding(3);
			this.tabRate.Size = new System.Drawing.Size(501, 399);
			this.tabRate.TabIndex = 0;
			this.tabRate.Text = "Rate";
			this.tabRate.UseVisualStyleBackColor = true;
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
			this.tabDose.Controls.Add(this.btnCalcDoseSer);
			this.tabDose.Controls.Add(this.btnSaveDose);
			this.tabDose.Controls.Add(this.btnCopyDose);
			this.tabDose.Controls.Add(this.btnDoseSer);
			this.tabDose.Controls.Add(this.chartDose);
			this.tabDose.Location = new System.Drawing.Point(4, 22);
			this.tabDose.Name = "tabDose";
			this.tabDose.Padding = new System.Windows.Forms.Padding(3);
			this.tabDose.Size = new System.Drawing.Size(501, 399);
			this.tabDose.TabIndex = 1;
			this.tabDose.Text = "Dose";
			this.tabDose.UseVisualStyleBackColor = true;
			// 
			// btnCalcDoseSer
			// 
			this.btnCalcDoseSer.Location = new System.Drawing.Point(319, 4);
			this.btnCalcDoseSer.Name = "btnCalcDoseSer";
			this.btnCalcDoseSer.Size = new System.Drawing.Size(124, 23);
			this.btnCalcDoseSer.TabIndex = 13;
			this.btnCalcDoseSer.Text = "Calculated Series...";
			this.btnCalcDoseSer.UseVisualStyleBackColor = true;
			this.btnCalcDoseSer.Click += new System.EventHandler(this.btnCalcDoseSer_Click);
			// 
			// btnSaveDose
			// 
			this.btnSaveDose.Location = new System.Drawing.Point(146, 4);
			this.btnSaveDose.Name = "btnSaveDose";
			this.btnSaveDose.Size = new System.Drawing.Size(75, 23);
			this.btnSaveDose.TabIndex = 11;
			this.btnSaveDose.Text = "Save...";
			this.btnSaveDose.UseVisualStyleBackColor = true;
			this.btnSaveDose.Click += new System.EventHandler(this.btnSaveDose_Click);
			// 
			// btnCopyDose
			// 
			this.btnCopyDose.Location = new System.Drawing.Point(39, 4);
			this.btnCopyDose.Name = "btnCopyDose";
			this.btnCopyDose.Size = new System.Drawing.Size(75, 23);
			this.btnCopyDose.TabIndex = 10;
			this.btnCopyDose.Text = "Copy";
			this.btnCopyDose.UseVisualStyleBackColor = true;
			this.btnCopyDose.Click += new System.EventHandler(this.btnCopyDose_Click);
			// 
			// btnDoseSer
			// 
			this.btnDoseSer.Location = new System.Drawing.Point(227, 4);
			this.btnDoseSer.Name = "btnDoseSer";
			this.btnDoseSer.Size = new System.Drawing.Size(86, 23);
			this.btnDoseSer.TabIndex = 10;
			this.btnDoseSer.Text = "Dose Series...";
			this.btnDoseSer.UseVisualStyleBackColor = true;
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
			this.chartDose.Location = new System.Drawing.Point(6, 30);
			this.chartDose.Name = "chartDose";
			series2.ChartArea = "ChartArea1";
			series2.Legend = "Legend1";
			series2.Name = "Series1";
			this.chartDose.Series.Add(series2);
			this.chartDose.Size = new System.Drawing.Size(489, 363);
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
			// main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(955, 449);
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
			this.tabDose.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartDose)).EndInit();
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
	}
}

