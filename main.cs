/*****************************************************************************\
|                                  main.cs                                    |
\*****************************************************************************/

/*
 * אוצר החייל
 * 363
 * 599800
 * 70500
 * השם בהערות
 * 054-766-7437
*/
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
using RmvDose.Properties;
using System.Security.Cryptography.X509Certificates;
//-----------------------------------------------------------------------------
namespace RmvDose
{
    public partial class main : Form
    {
        private ArrayList m_alLines;
        private TRmvcData m_rmvData;
		private TSourceData[] m_Sources;
        private Point m_ptMouse;
        private Chart m_chartEditSer = null;
        private Series m_serEdit = null;
        public ArrayList Lines {get{return(m_alLines);}set{m_alLines=value;}}
		public TSourceData[] Sources {get{return(m_Sources);}set{m_Sources=value;}}
//-----------------------------------------------------------------------------
        public main()
        {
            InitializeComponent();
            Lines = null;
            chartRate.Series.Clear();
            chartDose.Series.Clear();
            m_ptMouse = new Point(0,0);
        }
//-----------------------------------------------------------------------------
        private void btnOpen_Click(object sender, EventArgs e)
        {
            dlgOpenCsv.FileName = "";
            if (dlgOpenCsv.ShowDialog() == DialogResult.OK) {
                ReadRmvcCsvToGrid (dlgOpenCsv.FileName, gridCSV);
                txtbxFile.Text = dlgOpenCsv.FileName;
				Parse ();
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
			Parse ();
/*
			TRmvcRecord rec;
            string strSource="";
            Sources = null;//new TSourceData[1];
            if (Lines.Count > 0) {
                rec = new TRmvcRecord();
                for (int n=0 ; n < Lines.Count ; n++) {
                    string[] astr = (string[]) Lines[n];
                    if (rec.ParseFromRmvc (astr, ref strSource))
                        AddRrecordToSource (rec, strSource);
                }
                if (Sources != null)
                    if (Sources.Length > 0)
                        PlotData (Sources);
*/
		}
//-----------------------------------------------------------------------------
		public void Parse () {
            TRmvcRecord rec;
            string strSource="";
            Sources = null;//new TSourceData[1];
            if (Lines.Count > 0) {
                rec = new TRmvcRecord();
                for (int n=0 ; n < Lines.Count ; n++) {
                    string[] astr = (string[]) Lines[n];
                    if (rec.ParseFromRmvc (astr, ref strSource))
                        AddRrecordToSource (rec, strSource);
                }
                if (Sources != null)
                    if (Sources.Length > 0)
                        PlotData (Sources);
		}
            //clboxDose.Items.Clear();
            //CalcRate ();
            //GetDeviceDose();
            //CalculatedAccumDose();
		}
//-----------------------------------------------------------------------------
		private void AddRrecordToSource (TRmvcRecord rec, string strSrc) {
			TSourceData src = null;
			if (Sources == null) {
				src = new TSourceData (strSrc);
				Sources = new TSourceData[1];
				Sources[0] = src;
			}
			else {
				src = TMisc.FindSourceByName (Sources, strSrc);
				if (src == null) {
					src = new TSourceData (strSrc);
					TSourceData[] a = new TSourceData[1];
					a[0] = src;
					Sources = Sources.Concat(a).ToArray ();
				}
			}
			src.AddRecord (new TRmvcRecord (rec));
		}
//-----------------------------------------------------------------------------
        private void PlotData (TSourceData[] aSources) {
            chartDose.Series.Clear();
            chartRate.Series.Clear();
            if (aSources != null) {
                for (int n=0 ; n < aSources.Length ; n++) {
                    PlotRates (aSources[n]);
                    PlotDose (aSources[n]);//.Source, aSources[n].GetDose());
                }
            }
        }
//-----------------------------------------------------------------------------
        private void PlotRates (TSourceData sd) {
            PlotRmvcValue (chartRate, sd, ERmvcValue.E_Rate, clboxRates);

        }
//-----------------------------------------------------------------------------
        private void PlotDose (TSourceData sd) {
            PlotRmvcValue (chartDose, sd, ERmvcValue.E_Dose, clboxDose);
            PlotRmvcValue (chartDose, sd, ERmvcValue.E_CalcDose, clboxDose);
        }
//-----------------------------------------------------------------------------
        private void PlotRmvcValue (Chart chart, TSourceData sd, ERmvcValue value_type, CheckedListBox clbox=null) {
        //private void PlotRmvcValue (Chart chart, TSourceData sd, ERmvcValue value_type, Panel panel=null) {
            string strTitle = GetSeriesTitle (sd.Source, value_type);

            Series ser = AddSeriesToChart (chart, strTitle);
            if (ser != null) {
                //AddSeriesCheckbox (panel, ser);
                AddSeriesToCheckedListBox (clbox, ser);
                ser.Points.Clear();
				//ser.BorderDashStyle = ChartDashStyle.Dot;
                for (int n=0 ; n < sd.Data.Length ; n++) {
                    TRmvcRecord rec = (TRmvcRecord) sd.Data[n];
                    //ser.Points.AddXY (rec.SampleTime, rec.Rate);
                    ser.Points.AddXY (rec.SampleTime, rec.GetValue (value_type));
                }
            }
        }
//---------------------------------------------------------------------------
        public static int FindItem (CheckedListBox clbox, string str) {
            int n, nFound=-1;

            for (n=0 ; (n < clbox.Items.Count) && (nFound < 0) ; n++) {
                string s = clbox.Items[n].ToString ();
                if (s == str)
                    nFound = n;
            }
            return (nFound);
        }
//---------------------------------------------------------------------------
        private void AddSeriesCheckbox (Panel panel, Series ser) {
            CheckBox cbox, cboxFound=null;
            for (int n=0 ; (n < panel.Controls.Count) && (cboxFound == null) ; n++) {
                cbox = (CheckBox) panel.Controls[n];
                if (cbox.Text == ser.LegendText)
                    cboxFound = cbox;
            }
            if (cboxFound == null) {
                int nTop = panel.Controls.Count * 25;
                cbox = new CheckBox();
                cbox.Text = ser.LegendText;
                cbox.Parent = panel;
                cbox.Checked = true;
                cbox.Top = nTop;
                cbox.CheckedChanged += new EventHandler(this.OnCheckboxClick);
            }
        }
//---------------------------------------------------------------------------
        private void AddSeriesToCheckedListBox (CheckedListBox clbox, Series ser) {
            if (clbox != null) {
                int idx = FindItem (clbox, ser.LegendText);
                if (idx >= 0)
                    clbox.Items[idx] = ser.LegendText;
                else
                    clbox.Items.Add (ser.LegendText, true);
            }
        }
//---------------------------------------------------------------------------
        private Series AddSeriesToChart (Chart chart, string strTitle) {
            Series ser = TMisc.FindSeriesByName (chart, strTitle);
            if (ser == null) {
                ser = TMisc.StartFastLineSeries(strTitle);
                chart.Series.Add(ser);
            }
            return (ser);
        }
//---------------------------------------------------------------------------
        public string GetSeriesTitle (string strSource, ERmvcValue value_type) {
            string strTitle = strSource + " ";
            if (value_type == ERmvcValue.E_Rate)
                strTitle += "Rate";
            else if (value_type == ERmvcValue.E_Dose)
                strTitle += "Dose";
            else
                strTitle += "Calculated Dose";
            return (strTitle);
        }
//---------------------------------------------------------------------------
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
			serTarget.BorderDashStyle = serDemo.BorderDashStyle;
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
		private bool EditSeries (Series ser) {
            bool fEdit = false;
            dlgEditSeries dlg = new dlgEditSeries();
            Series serEdit = TMisc.InitSeries (ser);
            if ((fEdit = dlg.Execute(serEdit)) == true)
                AssignSerParams (ser, serEdit);
            return (fEdit);
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
            if (ser == null)
                ser = TMisc.StartFastLineSeries ("Normalized Dose");
            if (ser != null) {            
                ser.Color = Color.DarkGray;
                Series serIC3, serPC;
                serIC3 = TMisc.FindSeriesByName (chartDose, GetSeriesTitle ("Meter", ERmvcValue.E_Dose));
                serPC = TMisc.FindSeriesByName (chartDose, GetSeriesTitle ("Meter", ERmvcValue.E_CalcDose));
                for (int n=0 ; n < serPC.Points.Count ; n++)
                    ser.Points.AddXY (serPC.Points[n].XValue, serPC.Points[n].YValues[0] + serIC3.Points[0].YValues[0]);
                chartDose.Series.Add (ser);
                AddSeriesToCheckedListBox (clboxDose, ser);
            }
		}
//-----------------------------------------------------------------------------
		private void clboxRates_ItemCheck(object sender, ItemCheckEventArgs e) {
            ShowSeriesByCheck ((CheckedListBox)sender, chartRate);
        }
//-----------------------------------------------------------------------------
		private void ShowSeriesByCheck (CheckedListBox clbox, Chart chart) {
            for (int n=0 ; n < clbox.Items.Count ; n++) {
                string str = (string) clbox.Items[n];
                bool fChecked = clbox.GetItemChecked(n);
                Series ser = TMisc.FindSeriesByName (chart, str);
                if (ser != null)
                    ser.Enabled = !fChecked;//clbox.GetItemChecked(n);
            }
        }
//-----------------------------------------------------------------------------
		private void clboxDose_ItemCheck(object sender, ItemCheckEventArgs e) {
            ShowSeriesByCheck ((CheckedListBox)sender, chartDose);
		}
//-----------------------------------------------------------------------------
		private void OnCheckboxClick(object sender, EventArgs e) {
            CheckBox cbox = (CheckBox)sender;
            Panel panel = (Panel) cbox.Parent;
		}
//-----------------------------------------------------------------------------
		private void clboxDose_ItemCheck_1(object sender, ItemCheckEventArgs e) {
            ShowCheckedSeries ((CheckedListBox) sender, chartDose, e);
        }
//-----------------------------------------------------------------------------
        private void ShowCheckedSeries (CheckedListBox clbox, Chart chart, ItemCheckEventArgs e) {
            Series ser = TMisc.FindSeriesByName (chart, (string) clbox.Items[e.Index]);
            ser.Enabled = e.NewValue == CheckState.Checked;
		}
//-----------------------------------------------------------------------------
		private void clboxRates_ItemCheck_1(object sender, ItemCheckEventArgs e) {
            ShowCheckedSeries ((CheckedListBox) sender, chartRate, e);
		}
//-----------------------------------------------------------------------------
		private void clboxRates_DoubleClick(object sender, EventArgs e) {
            MouseEventArgs me = (MouseEventArgs)e;
            int idx = ((CheckedListBox)sender).IndexFromPoint(me.X, me.Y);
            CheckedListBox clbox = (CheckedListBox)sender;
            Series ser = TMisc.FindSeriesByName (chartRate, (string) clbox.Items[idx]);
            EditSeries (ser);
		}
//-----------------------------------------------------------------------------
		private void clboxDose_DoubleClick(object sender, EventArgs e) {
            MouseEventArgs me = (MouseEventArgs)e;
            int idx = ((CheckedListBox)sender).IndexFromPoint(me.X, me.Y);
            CheckedListBox clbox = (CheckedListBox)sender;
            Series ser = TMisc.FindSeriesByName (chartDose, (string) clbox.Items[idx]);
            EditSeries (ser);

		}
//-----------------------------------------------------------------------------
		private void clboxRates_MouseMove(object sender, MouseEventArgs e) {
            m_ptMouse = (Point)e.Location;
		}
//-----------------------------------------------------------------------------
		private void clboxRates_MouseUp(object sender, MouseEventArgs e) {
            PrepareSeries (e, chartRate, clboxRates);
        }
        private void PrepareSeries (MouseEventArgs e, Chart chart, CheckedListBox clbox) {
            if (clbox.Items.Count > 0) {
                int idx = clboxRates.SelectedIndex;
                if (idx < 0)
                    idx = clbox.IndexFromPoint(e.X, e.Y);
                if (idx < 0)
                    idx = 0;
                if (idx >= 0) {
                    string s = clbox.Items[idx].ToString();
                    m_serEdit = TMisc.FindSeriesByName (chart, s);
                }
            }
        }
//-----------------------------------------------------------------------------
		private void miEditSer_Click(object sender, EventArgs e) {
            if (m_serEdit != null) {
                EditSeries (m_serEdit);
                m_serEdit = null;
            }
		}
//-----------------------------------------------------------------------------
		private void clboxDose_MouseUp(object sender, MouseEventArgs e) {
            PrepareSeries (e, chartDose, clboxDose);
		}
//-----------------------------------------------------------------------------
		private void btnExport_Click(object sender, EventArgs e) {
            if (dlgSaveCsv.ShowDialog() == DialogResult.OK) {
                StreamWriter writer = null;
                try {
                    writer = new StreamWriter(dlgSaveCsv.FileName);
                    string str;
                    for (int n=0 ; n < chartDose.Series[0].Points.Count ; n++) {
                        str = "";
                        for (int y=0 ; y < chartDose.Series.Count ; y++) {
                            str += chartDose.Series[y].Points[n].YValues[0].ToString() + ",";
                        }
                        str.TrimEnd(',');
                        writer.WriteLine(str);
                    }
                }
                catch (Exception ex) {
                }
                finally {
                    if (writer != null)
                        writer.Close();
                    writer = null;
                }
            }
		}
//-----------------------------------------------------------------------------
		private void button1_Click(object sender, EventArgs e) {
			if (chartRate.Series.Count > 0) {
				if (chartRate.Series[0].Points.Count > 0) {
					double dAvg = 0;
					int n;

					for (n=0 ; n < chartRate.Series[0].Points.Count ; n++)
						dAvg += chartRate.Series[0].Points[n].YValues[0];
					dAvg /= (double) chartRate.Series[0].Points.Count;
					int nStart = FindStart (dAvg);
					int nEnd = FindEnd (dAvg);
					if ((nStart > 0) && (nEnd > 0)) {
						dAvg = 0;
						for (n=nStart ; n < nEnd ; n++)
							dAvg += chartRate.Series[0].Points[n].YValues[0];
						dAvg /= (double) (nEnd - nStart);
			            Series serAvg = AddSeriesToChart (chartRate, "Average");
						serAvg.Color = Color.Red;
						serAvg.BorderWidth = 2;
						for (n=nStart ; n < nEnd ; n++) {
							double x = chartRate.Series[0].Points[n].XValue;
							serAvg.Points.AddXY (x, dAvg);
						}
						AddSeriesToCheckedListBox (clboxRates, serAvg);
					}
				}
			}
		}
//-----------------------------------------------------------------------------
		private int FindStart (double dAvg) {
			int n, nStart = -1;
			double y;

			for (n=0 ; (n < chartRate.Series[0].Points.Count) && (nStart < 0) ; n++) {
				y = chartRate.Series[0].Points[n].YValues[0];
				//if (Math.Abs (chartRate.Series[0].Points[n].YValues[0]) > dAvg)
				if (chartRate.Series[0].Points[n].YValues[0] > dAvg)
					nStart = n;
			}
			return (nStart);
		}
//-----------------------------------------------------------------------------
		private int FindEnd (double dAvg) {
			int n, nEnd = -1;

			for (n=chartRate.Series[0].Points.Count-1 ; (n >= 0) && (nEnd < 0) ; n--)
				if (chartRate.Series[0].Points[n].YValues[0] > dAvg)
					nEnd = n;
			return (nEnd);
		}
//-----------------------------------------------------------------------------
		public static double PercentDiff (double d1, double d2) {
			double dDiff = 1e7;
			if (d2 != 0) {
				dDiff = 100 * (d1 - d2) / d2;
			}
			return (dDiff);
		}
//-----------------------------------------------------------------------------
		private void btnAnalyze_Click(object sender, EventArgs e) {
		   if (chartRate.Series.Count > 0) {
			   if (chartRate.Series[0].Points.Count > 0) {
				   double dAvg = 0, dMax, dMin;
				   int n;

				   for (n=0 ; n < chartRate.Series[0].Points.Count ; n++)
					   dAvg += chartRate.Series[0].Points[n].YValues[0];
				   dAvg /= (double) chartRate.Series[0].Points.Count;
				   int nStart = FindStart (dAvg);
				   int nEnd = FindEnd (dAvg);
				   if ((nStart > 0) && (nEnd > 0)) {
					   dAvg = 0;
					   for (n=nStart ; n < nEnd ; n++)
						   dAvg += chartRate.Series[0].Points[n].YValues[0];
					   dAvg /= (double) (nEnd - nStart);
					   dMax = dMin = dAvg;
					   for (n=nStart ; n < nEnd ; n++) {
							double y = chartRate.Series[0].Points[n].YValues[0];
							if (y > dMax)
								dMax = y;
							if (y < dAvg)
								dMin = y;
						}
					   Series serAvg = AddSeriesToChart (chartRate, "Average");
					   serAvg.Color = Color.Green;
					   serAvg.BorderDashStyle = ChartDashStyle.Dash;
					   //serAvg.Color = Color.Red;
					   //serAvg.BorderWidth = 2;
					   for (n=nStart ; n < nEnd ; n++) {
						   double x = chartRate.Series[0].Points[n].XValue;
						   serAvg.Points.AddXY (x, dAvg);
					   }
					   AddSeriesToCheckedListBox (clboxRates, serAvg);
					   txtbxAvg.Text = dAvg.ToString ("0.00");
					   txtbxMax.Text = dMax.ToString ("0.00");
					   txtbxMin.Text = dMin.ToString ("0.00");
					   txtbxPctMax.Text = String.Format ("{0:0.00}%", PercentDiff (dMax, dAvg));
					   txtbxPctMin.Text = String.Format ("{0:0.00}%", PercentDiff (dAvg, dMin));
				   }
			   }
		   }
		}

		private void popupClbox_Opening(object sender, CancelEventArgs e) {

		}
		//-----------------------------------------------------------------------------
	}
}
