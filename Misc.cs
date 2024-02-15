/*****************************************************************************\
|                                  misc.cs                                    |
\*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace RotemRadiation
{
	public class TMisc
	{
		private string m_strErr;
		public string ErrorMessage {get{return(m_strErr);}}
//-----------------------------------------------------------------------------
		public static double ToDoubleDef (string str, double def=0) {
			double dValue;
			try {
				dValue = double.Parse (str, System.Globalization.CultureInfo.InvariantCulture);
			}
			catch (Exception ex) {
				dValue = def;
			}
			return (dValue);
		}
//-----------------------------------------------------------------------------
        public static Series StartFastLineSeries(string strName="") {
            Series ser = new Series();
            ser.ChartType = SeriesChartType.FastLine;
            ser.XValueType = ChartValueType.DateTime;
            ser.YValueType = ChartValueType.Double;
			ser.LegendText = strName;
            return (ser);
        }
//-----------------------------------------------------------------------------
        public static Series FindSeriesByName (Chart chart, string strName) {
            int nFound = -1;
            Series ser = null;

            for (int n=0 ; (n < chart.Series.Count) && (nFound < 0) ; n++) { 
                if (String.Compare (chart.Series[n].LegendText, strName, StringComparison.OrdinalIgnoreCase) == 0)
                    nFound = n;
            }
            if (nFound >= 0)
                ser = chart.Series[nFound];
            return (ser);
        }
//-----------------------------------------------------------------------------
		public static Series InitSeries (Series ser) {
			Series serNew = new Series();
			serNew = TMisc.StartFastLineSeries(ser.Name);
			serNew.Color = ser.Color;
			serNew.BorderWidth = ser.BorderWidth;
			serNew.BorderColor = ser.BorderColor;
			Random rnd = new Random();
			for (int n=0 ; n < 100 ;  n++) 
				serNew.Points.AddY (rnd.NextDouble ());
			return (serNew);
		}
	}
}
