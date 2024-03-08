/*****************************************************************************\
|                               SourceData.cs                                 |
\*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//-----------------------------------------------------------------------------
namespace RmvDose
{
	public class TSourceData
	{
		private string m_strSource;
		private TRmvcRecord[] m_data;
//-----------------------------------------------------------------------------
		public string Source { get { return (m_strSource); } set { m_strSource = value; } }
		public TRmvcRecord[] Data {get{return(m_data);} set{m_data=value;}}
//-----------------------------------------------------------------------------
		public TSourceData (string strSrc="") {
			Source = strSrc;
			Data = null;
		}
//-----------------------------------------------------------------------------
		public void AddRecord (TRmvcRecord rec) {
			TRmvcRecord[] a = new TRmvcRecord[1];

			a[0] = rec;
			if (m_data == null) {
				m_data = a;
			}
			else {
				if (m_data.Length > 0) {
					TRmvcRecord recLast = m_data[m_data.Length - 1];
					TimeSpan ts = (TimeSpan) (rec.SampleTime - recLast.SampleTime);
					double dt = ts.TotalSeconds;
					if (dt > 0)
						rec.CalcDose = recLast.CalcDose + rec.Rate * dt / 3600.0;
					else
						rec.CalcDose = recLast.CalcDose;
				}
				TRmvcRecord[] aNew = m_data.Concat(a).ToArray();
				m_data = aNew;
			}
		}
//-----------------------------------------------------------------------------
		public double[] GetRates () {
			double[] aRates = null;
			
			if (Data != null) {
				aRates = new double[Data.Length];
				for (int n=0 ; n < Data.Length ; n++)
					aRates[n] = Data[n].Rate;
			}
			return (aRates);
		}
//-----------------------------------------------------------------------------
		public double[] GetDoses () {
			double[] aDoses = null;
			
			if (Data != null) {
				aDoses = new double[Data.Length];
				for (int n=0 ; n < Data.Length ; n++)
					aDoses[n] = Data[n].Dose;
			}
			return (aDoses);
		}
//-----------------------------------------------------------------------------
		public double[] GetRates (TRmvcRecord[] aRecords) {
			double[] aRates = new double[aRecords.Length];

			for (int n=0 ; n < aRecords.Length ; n++)
				aRates[n] = aRecords[n].Rate;
			return (aRates);
		}
//-----------------------------------------------------------------------------
		public double[] GetDose (TRmvcRecord[] aRecords) {
			double[] aDose = new double[aRecords.Length];

			for (int n=0 ; n < aRecords.Length ; n++)
				aDose[n] = aRecords[n].Dose;
			return (aDose);
		}
//-----------------------------------------------------------------------------
	}
}
