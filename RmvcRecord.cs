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
	public enum ERmvcUnits {E_Rem, E_Sievert, E_Error}
	public enum ERmvcValue {E_Rate, E_Dose, E_CalcDose}
	public class TRmvcRecord {
		private DateTime? m_dtSample;
		private double m_dRate;
		private double m_dDose;
		private double m_dCalcDose;
		private ERmvcUnits m_units;
//-----------------------------------------------------------------------------
		public DateTime? SampleTime {get{return(m_dtSample);}set{m_dtSample=value;}}
		public double Rate {get{return(m_dRate);}set{m_dRate=value;}}
		public double Dose {get{return(m_dDose);}set{m_dDose=value;}}
		public double CalcDose {get{return(m_dCalcDose);}set{m_dCalcDose=value;}}
		public ERmvcUnits Units {get{return(m_units);}set{m_units=value;}}
//-----------------------------------------------------------------------------
		public TRmvcRecord () {
			Clear ();
		}
		public TRmvcRecord (TRmvcRecord other) {
			SampleTime = other.SampleTime;
			Rate       = other.Rate;
			Dose       = other.Dose;
			CalcDose   = other.CalcDose;
			Units      = other.Units;
		}
//-----------------------------------------------------------------------------
		public void Clear () {
			SampleTime = null;
			Rate       = 0;
			Dose       = 0;
			CalcDose   = 0;
			Units      = ERmvcUnits.E_Sievert;
		}
//-----------------------------------------------------------------------------
		public static ERmvcUnits ParseUnits(string strSrc) {
			ERmvcUnits units = ERmvcUnits.E_Error;
			string strUnits = strSrc.ToLower().Trim();
			if ((strUnits == "mr") || (strUnits == "mr/h"))
				units = ERmvcUnits.E_Rem;
			else if ((strUnits == "usv") || (strUnits == "usv/h"))
				units = ERmvcUnits.E_Sievert;
			return (units);
		}
//-----------------------------------------------------------------------------
		public bool ParseFromRmvc (string str, ref string strSource) {
			string[] astr = str.Split(',');
			return (ParseFromRmvc (astr, ref strSource));
		}
//-----------------------------------------------------------------------------
		public bool ParseFromRmvc (string[] astr, ref string strSource) {
			bool fParse;
			try {
				SampleTime = DateTime.ParseExact(astr[0], "HH:mm:ss", CultureInfo.InvariantCulture);
				strSource = astr[1];//.ToLower();
				string[] astrValue = astr[2].Split(' ');
				Rate = TMisc.ToDoubleDef(astrValue[0]);
				Units = ParseUnits(astrValue[1]);
				astrValue = astr[3].Split(' ');
				Dose = TMisc.ToDoubleDef(astrValue[0]);
				fParse = true;
			}
			catch (Exception e) {
				fParse = false;
			}
			return (fParse);
		}
//-----------------------------------------------------------------------------
		public double GetValue (ERmvcValue value_type) {
			double dValue;

			if (value_type == ERmvcValue.E_Rate)
				dValue = Rate;
			else if (value_type == ERmvcValue.E_Dose)
				dValue = Dose;
			else
				dValue = CalcDose;
			return (dValue);
		}
//-----------------------------------------------------------------------------
	}
}
