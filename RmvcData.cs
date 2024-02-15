/*****************************************************************************\
|                                RmvcData.cs                                  |
\*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmvDose
{
	public class TRmvcData {
		private ArrayList m_alRecords;
		private ArrayList m_alDose;
		private ArrayList m_alCalcDose;
		int m_nTimeDiff;
//-----------------------------------------------------------------------------
		public ArrayList Records {get{return(m_alRecords);}set{m_alRecords=value;}}
		public ArrayList Dose {get{return(m_alDose);}set{m_alDose=value;}}
		public ArrayList CalcDose {get{return(m_alCalcDose);}set{m_alCalcDose=value;}}
		public int TimeDiff {get{return(m_nTimeDiff);}set{m_nTimeDiff=value;}}
//-----------------------------------------------------------------------------
		public TRmvcData () {
			Records  = null;
			Dose     = null;
			CalcDose = null;
			TimeDiff = 0;
		}
//-----------------------------------------------------------------------------
		public int Parse (ArrayList alRecords) {
			TRmvcRecord rec = new TRmvcRecord();
			Records = new ArrayList();
			for (int n=0 ; n < alRecords.Count ; n++) {
				string[] astr = (string[]) alRecords[n];
				if (rec.ParseFromRmvc (astr))
					Records.Add (new TRmvcRecord(rec));
			}
				if (Records.Count > 0) {
					rec = (TRmvcRecord) Records[0];
					TRmvcRecord rec1 = (TRmvcRecord) Records[1];
					TimeSpan ts = (TimeSpan) (rec1.SampleTime - rec.SampleTime);
					TimeDiff = ts.Seconds;
				}
			return (Records.Count);
		}		
//-----------------------------------------------------------------------------
		public void CalculateDose() {
			if ((Records.Count > 0) && (TimeDiff > 0)) {
				if (CalcDose == null)
					CalcDose = new ArrayList();
				else
					CalcDose.Clear();
				double dDose = ((TRmvcRecord)Records[0]).Rate;
				double dTime = ((double) TimeDiff) / 3600.0;
				CalcDose.Add (dDose);
				for (int n=1 ; n < Records.Count ; n++)	{
					double d = ((TRmvcRecord)Records[n]).Rate;
					dDose += d * dTime;
					CalcDose.Add (dDose);
				}
			}
		}
	}
}
