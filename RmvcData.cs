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
		int m_nTimeDiff;
//-----------------------------------------------------------------------------
		public ArrayList Records {get{return(m_alRecords);}set{m_alRecords=value;}}
		private ArrayList Dose {get{return(m_alDose);}set{m_alDose=value;}}
		public int TimeDiff {get{return(m_nTimeDiff);}set{m_nTimeDiff=value;}}
//-----------------------------------------------------------------------------
		public TRmvcData () {
			Records  = null;
			Dose     = null;
			TimeDiff = 0;
		}
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
	}
}
