/*****************************************************************************\
|                                  main.cs                                    |
\*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms.DataVisualization.Charting;
//-----------------------------------------------------------------------------
using RotemRadiation;
using System.Runtime.ConstrainedExecution;
//-----------------------------------------------------------------------------
namespace RmvDose
{
    public partial class main : Form
    {
        private ArrayList m_alLines;
        private TRmvcData m_rmvData;
        public ArrayList Lines {get{return(m_alLines);}set{m_alLines=value;}}
//-----------------------------------------------------------------------------
        public main()
        {
            InitializeComponent();
            Lines = null;
            chartRate.Series.Clear();
            chartDose.Series.Clear();
        }
//-----------------------------------------------------------------------------
        private void btnOpen_Click(object sender, EventArgs e)
        {
            dlgOpenCsv.FileName = "";
            if (dlgOpenCsv.ShowDialog() == DialogResult.OK) {
                ReadRmvcCsvToGrid (dlgOpenCsv.FileName, gridCSV);
                txtbxFile.Text = dlgOpenCsv.FileName;
            }
        }
//-----------------------------------------------------------------------------
        public static ArrayList ReadFile (string strFileName) {
            ArrayList al = null;

            try {
                al = new ArrayList();
                foreach (string line in File.ReadLines(strFileName)) {
                    al.Add(line);
                }
            }
            catch (Exception ex) {
                al = null;
                Console.WriteLine(ex.Message);
            }
            return (al);
        }

//-----------------------------------------------------------------------------
        private void ReadRmvcCsvToGrid (string strFileName, DataGridView grid) {
            ArrayList alLines = ReadFile (strFileName);
            if (alLines.Count > 0) {
                ArrayList alGrid = ParseRmvcLines (alLines);
                alGrid.Reverse ();
                if (alGrid  != null)
                    DownloadToGrid (grid, alGrid);
                Lines = alGrid;
            }
        }
//-----------------------------------------------------------------------------
        private void DownloadToGrid (DataGridView grid, ArrayList alGrid) {
            string[] astr = (string[]) alGrid[0];
            grid.ColumnCount = astr.Length;
            grid.RowCount = alGrid.Count - 1;
            for (int n=0 ; n < astr.Length ; n++)
                grid.Columns[n].HeaderText = astr[n];
            for (int n=1 ; n < alGrid.Count ; n++) {
                astr = (string[]) alGrid[n];
                for (int c=0 ; c < astr.Length ; c++) {
                    grid.Rows[n-1].Cells[c].Value = astr[c];
                }
            }
        }
//-----------------------------------------------------------------------------
        private ArrayList ParseRmvcLines (ArrayList alLines) {
            ArrayList al = new ArrayList();
            int nHeader = FindRmvcHeader (alLines);
            if (nHeader > 0) {
                string str = (string) alLines[nHeader];
                al.Add (str.Split(','));
                for (int n=nHeader+1 ; n < alLines.Count ; n++) {
                    string s = (string) alLines[n];
                    if (s.Trim().Length > 0)
                        al.Add (s.Split(','));
                }
            }
            return (al);
        }
//-----------------------------------------------------------------------------
        private int FindRmvcHeader (ArrayList alLines) {
            int nHeader=-1;

            for (int n=0 ; (n < alLines.Count) && (nHeader < 0) ; n++) {
                string strLine = (string) alLines[n];
                int idx = strLine.IndexOf ("time", StringComparison.CurrentCultureIgnoreCase);
                if (idx >= 0) {
                    string[] astrHeader = strLine.Split(',');
                    if (astrHeader.Length >= 4)
                        nHeader = n;
                }
            }
            return (nHeader);
        }
//-----------------------------------------------------------------------------
		private void btnParse_Click(object sender, EventArgs e)
		{
            if (Lines.Count > 0) {
                m_rmvData = new TRmvcData();
                int nRecords = m_rmvData.Parse(Lines);
                txtbxRecords.Text = nRecords.ToString();
                chartDose.Series.Clear();
				chartRate.Series.Clear();
			}
            //clboxDose.Items.Clear();
            CalcRate ();
            GetDeviceDose();
            CalculatedAccumDose();
		}
//-----------------------------------------------------------------------------
		private void btnRate_Click(object sender, EventArgs e)
		{
            CalcRate ();
        }
//-----------------------------------------------------------------------------
		private void CalcRate ()
		{
            Series ser = TMisc.FindSeriesByName (chartRate, "Rate");
            if (ser == null) {
                ser = TMisc.StartFastLineSeries("Rate");
                chartRate.Series.Add(ser);
            }
            ser.Points.Clear();
            //chartRate.Series.Clear();
            for (int n=0 ; n < m_rmvData.Records.Count ; n++) {
                TRmvcRecord rec = (TRmvcRecord) m_rmvData.Records[n];
                ser.Points.AddXY (rec.SampleTime, rec.Rate);
            }
            //chartRate.Series.Add(ser);
		}
//-----------------------------------------------------------------------------
		private void btnDose_Click(object sender, EventArgs e)
		{
            GetDeviceDose();
        }
//-----------------------------------------------------------------------------
		private void GetDeviceDose() {
            Series ser = TMisc.FindSeriesByName (chartRate, "Dose");
            if (ser == null)
                ser = TMisc.StartFastLineSeries("Dose");
            for (int n=0 ; n < m_rmvData.Records.Count ; n++) {
                TRmvcRecord rec = (TRmvcRecord) m_rmvData.Records[n];
                ser.Points.AddXY (rec.SampleTime, rec.Dose);
            }
			chartDose.Series.Add(ser);
            //clboxDose.Items.Add(ser);
		}
//-----------------------------------------------------------------------------
		private void AssignSerParams (Series serTarget, Series serDemo) {
            serTarget.Color = serDemo.Color;
            serTarget.BorderWidth = serDemo.BorderWidth;
}
//-----------------------------------------------------------------------------
		private void btnCalcDose_Click(object sender, EventArgs e)
		{
            CalculatedAccumDose();
        }
        private void CalculatedAccumDose() {
            m_rmvData.CalculateDose();
            Series serNorm=null, ser = TMisc.FindSeriesByName (chartDose, "Calculated Dose");
            if (ser == null) { 
                ser = TMisc.StartFastLineSeries("Calculated Dose");
                chartDose.Series.Add (ser);
                //.Items.Add (ser);
            }
            TRmvcRecord rec = (TRmvcRecord) m_rmvData.Records[0];
            if (rec.Rate > 0) {
                serNorm = TMisc.FindSeriesByName (chartDose, "Normalized Dose");
                if (serNorm == null) { 
                    serNorm = TMisc.StartFastLineSeries("Normalized Dose");
                    chartDose.Series.Add (serNorm);
                    //clboxDose.Items.Add (serNorm);
                }
            }
            for (int n=0 ; n < m_rmvData.Records.Count ; n++) {
                ser.Points.AddXY (((TRmvcRecord)m_rmvData.Records[n]).SampleTime, (double) m_rmvData.CalcDose[n]);
                if (serNorm != null)
                    serNorm.Points.AddXY (((TRmvcRecord)m_rmvData.Records[n]).SampleTime, (double) m_rmvData.CalcDose[n] - rec.Rate);
             }
		}

//-----------------------------------------------------------------------------
		private void btnRateSer_Click(object sender, EventArgs e)
		{
            Series ser = TMisc.FindSeriesByName (chartRate, "Rate");
            EditSeries (ser);
		}
//-----------------------------------------------------------------------------
		private void btnDoseSer_Click(object sender, EventArgs e)
		{
            Series ser = TMisc.FindSeriesByName (chartDose, "Dose");
            EditSeries (ser);
		}
//-----------------------------------------------------------------------------
		private void btnCalcDoseSer_Click(object sender, EventArgs e)
		{
            Series ser = TMisc.FindSeriesByName (chartDose, "Calculated Dose");
            EditSeries (ser);
		}
//-----------------------------------------------------------------------------
		private void EditSeries (Series ser) {
            dlgEditSeries dlg = new dlgEditSeries();
            Series serEdit = TMisc.InitSeries (ser);
            if (dlg.Execute(serEdit))
                AssignSerParams (ser, serEdit);
        }
//-----------------------------------------------------------------------------
        private void CopyToClipboard (Chart chart) {
            using (MemoryStream ms = new MemoryStream()) {
                chart.SaveImage(ms, ChartImageFormat.Bmp);
                Bitmap bm = new Bitmap(ms);
                Clipboard.SetImage(bm);
            }
        }
//-----------------------------------------------------------------------------
		private void btnCopyRate_Click_1(object sender, EventArgs e)
		{
            CopyToClipboard (chartRate);
		}
//-----------------------------------------------------------------------------
		private void btnCopyDose_Click(object sender, EventArgs e)
		{
            CopyToClipboard (chartDose);
		}
//-----------------------------------------------------------------------------
		private void btnSaveDose_Click(object sender, EventArgs e)
		{
            chartDose.SaveImage("file.txt", ChartImageFormat.Jpeg);
		}
//-----------------------------------------------------------------------------
		private void btnSaveRate_Click(object sender, EventArgs e)
		{
            if (dlgSavePic.ShowDialog() == DialogResult.OK) {
				ChartImageFormat format = GetFormatFromExt (dlgSavePic.FileName);
                chartRate.SaveImage(dlgSavePic.FileName, format);
			}
		}
//-----------------------------------------------------------------------------
		public static ChartImageFormat GetFormatFromExt(string strName) {
            ChartImageFormat format = ChartImageFormat.Bmp;
            string strExt = Path.GetExtension(strName).ToLower().Substring(1, 3);
            if (strExt == "jpg")
                format = ChartImageFormat.Jpeg;
            else if (strExt == "png")
                format = ChartImageFormat.Png;
			else if (strExt == "gif")
				format = ChartImageFormat.Gif;
			return (format);

		}
//-----------------------------------------------------------------------------
		private void btnAbout_Click(object sender, EventArgs e)
		{
			dlgAbout dlg = new dlgAbout();
            dlg.Execute();
		}
//-----------------------------------------------------------------------------
		private void OnIdle (object sender, EventArgs e) {
            bool fParse = false;
            if (Lines != null)
                fParse = Lines.Count > 0;
			btnParse.Enabled = fParse;
			btnRateEdit.Enabled = chartRate.Series.Count > 0;
			btnDoseSer.Enabled = chartDose.Series.Count > 0;
			btnCalcDoseSer.Enabled = chartDose.Series.Count > 0;
		}
//-----------------------------------------------------------------------------
		private void main_Load(object sender, EventArgs e)
		{
            Application.Idle += OnIdle;
		}
//-----------------------------------------------------------------------------
		private void main_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Idle -= OnIdle;
		}
//-----------------------------------------------------------------------------
		private void btnNormSer_Click(object sender, EventArgs e)
		{
            Series ser = TMisc.FindSeriesByName (chartDose, "Normalized Dose");
            EditSeries (ser);
		}
//-----------------------------------------------------------------------------
	}
}
