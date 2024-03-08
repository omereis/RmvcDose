/*****************************************************************************\
|                                RmvcData.cs                                  |
\*****************************************************************************/
using RmvDose.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RmvDose
{
	public class TRmvcData {
		private ArrayList m_alRecords;
		private ArrayList m_alErrors;
		private ArrayList m_alDose;
		private ArrayList m_alCalcDose;
		int m_nTimeDiff;
		private TSourceData[] m_Sources;
//-----------------------------------------------------------------------------
		public ArrayList Records {get{return(m_alRecords);}set{m_alRecords=value;}}
		public ArrayList Errors {get{return(m_alErrors);}set{m_alErrors=value;}}
		public ArrayList Dose {get{return(m_alDose);}set{m_alDose=value;}}
		public ArrayList CalcDose {get{return(m_alCalcDose);}set{m_alCalcDose=value;}}
		public int TimeDiff {get{return(m_nTimeDiff);}set{m_nTimeDiff=value;}}
		public TSourceData[] Sources {get{return(m_Sources);}set{m_Sources=value;}}
//-----------------------------------------------------------------------------
		public TRmvcData () {
			Records  = null;
			Dose     = null;
			CalcDose = null;
			TimeDiff = 0;
			Errors = new ArrayList();
			Sources = null;
		}
//-----------------------------------------------------------------------------
		public int Parse (ArrayList alRecords) {
			TRmvcRecord rec = new TRmvcRecord();
			string strSrc="";
			Records = new ArrayList();
			Errors.Clear();
			for (int n=0 ; n < alRecords.Count ; n++) {
				string[] astr = (string[]) alRecords[n];
				if (rec.ParseFromRmvc (astr, ref strSrc))
					AddRrecordToSource (rec, strSrc);
					//Records.Add (new TRmvcRecord(rec));
				else
					Errors.Add(alRecords[n]);
			}
/*
				if (Records.Count > 0) {
					rec = (TRmvcRecord) Records[0];
					TRmvcRecord rec1 = (TRmvcRecord) Records[1];
					TimeSpan ts = (TimeSpan) (rec1.SampleTime - rec.SampleTime);
					TimeDiff = ts.Seconds;
				}
*/
			int nCount = (Sources == null ? 0 : Sources.Length);
			//return (Records.Count);
			return (nCount);
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
				src = FindSourceByName (strSrc);
				if (src == null) {
					src = new TSourceData (strSrc);
					TSourceData[] a = new TSourceData[1];
					a[0] = src;
					Sources = Sources.Concat(a).ToArray ();
				}
			}
			src.AddRecord (rec);
		}
//-----------------------------------------------------------------------------
		private TSourceData FindSourceByName (string strSrc) {
			TSourceData src=null;
			
			if (Sources == null) {
				for (int n=0 ; (n < Sources.Length) && (src == null) ; n++) {
					if (Sources[n].Source == strSrc)
						src = Sources[n];
				}
			}
			return (src);
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
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
	}
}
