/*****************************************************************************\
|                               RmvcRecord.cs                                 |
\*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------------------------------------------------------------------
using RotemRadiation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
//-----------------------------------------------------------------------------
namespace RmvDose
{
	public class TRmvcRecord {
		private DateTime? m_dtSample;
		private double m_dRate;
		private double m_dDose;
//-----------------------------------------------------------------------------
		public DateTime? SampleTime {get{return(m_dtSample);}set{m_dtSample=value;}}
		public double Rate {get{return(m_dRate);}set{m_dRate=value;}}
		public double Dose {get{return(m_dDose);}set{m_dDose=value;}}
//-----------------------------------------------------------------------------
		public TRmvcRecord () {
			Clear ();
		}
		public TRmvcRecord (TRmvcRecord other) {
			SampleTime = other.SampleTime;
			Rate       = other.Rate;
			Dose       = other.Dose;
		}
//-----------------------------------------------------------------------------
		public void Clear () {
			SampleTime = null;
			Rate = 0;
			Dose = 0;
		}
//-----------------------------------------------------------------------------
		public bool ParseFromRmvc (string[] astr) {
			bool fParse;
			try {
				SampleTime = DateTime.ParseExact(astr[0], "HH:mm:ss", CultureInfo.InvariantCulture);
				string[] astrValue = astr[2].Split(' ');
				Rate = TMisc.ToDoubleDef(astrValue[0]);
				astrValue = astr[3].Split(' ');
				Dose = TMisc.ToDoubleDef(astrValue[0]);
				fParse = true;
			}
			catch (Exception e) {
				fParse = false;
			}
			return (fParse);
		}
	}
}
