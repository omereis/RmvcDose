/*****************************************************************************\
|                               EditSeries.cs                                 |
\*****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

//-----------------------------------------------------------------------------
using RotemRadiation;
//-----------------------------------------------------------------------------
namespace RmvDose
{
	public partial class dlgEditSeries : Form
	{
//-----------------------------------------------------------------------------
		Series m_ser;
		ChartDashStyle m_style = ChartDashStyle.NotSet;
		public dlgEditSeries()
		{
			InitializeComponent();
			m_ser = null;
		}
//-----------------------------------------------------------------------------
		public bool Execute (Series ser) {
			m_ser = TMisc.InitSeries (ser);
			chartDemo.Series.Clear();
			chartDemo.Series.Add (m_ser);

			bool fEdit = true;
			Download (m_ser);
			if (ShowDialog() == DialogResult.OK)
				Upload (ser);
			else
				fEdit = false;
			return (fEdit);
		}
//-----------------------------------------------------------------------------
		private void Download (Series ser) {
			udWidth.Value = ser.BorderWidth;
			panelColor.BackColor = ser.Color;
			DownloadStyle (ser.BorderDashStyle);
		}
//-----------------------------------------------------------------------------
		private void Upload (Series ser) {
			ser.BorderWidth = m_ser.BorderWidth;
			ser.Color = m_ser.Color;
			ser.BorderDashStyle = DashStyleFromName (comboStyle.SelectedItem.ToString());
		}
//-----------------------------------------------------------------------------
		private void btnColor_Click(object sender, EventArgs e)
		{
			dlgEditColor.Color = btnColor.BackColor;
			if (dlgEditColor.ShowDialog() == DialogResult.OK ) {
				btnColor.BackColor = dlgEditColor.Color;
				m_ser.Color = dlgEditColor.Color;
			}
		}
//-----------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
//-----------------------------------------------------------------------------
		private void panelColor_Click(object sender, EventArgs e)
		{
			dlgEditColor.Color = panelColor.BackColor;
			if (dlgEditColor.ShowDialog() == DialogResult.OK ) {
				panelColor.BackColor = dlgEditColor.Color;
				m_ser.Color = dlgEditColor.Color;
				chartDemo.Invalidate();
			}
		}
//-----------------------------------------------------------------------------
		private void udWidth_ValueChanged(object sender, EventArgs e)
		{
			int nWidth = (int) udWidth.Value;
			if (m_ser != null)
				m_ser.BorderWidth = nWidth;
		}
//-----------------------------------------------------------------------------
		public static string GetStyleName (ChartDashStyle style) {
			string strName="";
			if (style == ChartDashStyle.Solid)
				strName = "Solid";
			else if (style == ChartDashStyle.Dash)
				strName = "Dash";
			else if (style == ChartDashStyle.DashDot)
				strName = "DashDot";
			else if (style == ChartDashStyle.DashDotDot)
				strName = "DashDotDot";
			else if (style == ChartDashStyle.Dot)
				strName = "Dot";
			return (strName);
		}
//-----------------------------------------------------------------------------
		private void DownloadStyle (ChartDashStyle style) {
			string strName = GetStyleName (style);
            if (strName.Length > 0)
				comboStyle.SelectedItem = strName;
        }
//-----------------------------------------------------------------------------
		private void comboStyle_DropDownClosed(object sender, EventArgs e) {
			ChartDashStyle style = DashStyleFromName (comboStyle.SelectedItem.ToString());
			if (m_ser != null)
				if (style != m_style) {
					m_ser.BorderDashStyle = style;
					m_style = style;
				}
		}
//-----------------------------------------------------------------------------
		private void comboStyle_DropDown(object sender, EventArgs e) {
			m_style = DashStyleFromName (comboStyle.SelectedItem.ToString());
		}
//-----------------------------------------------------------------------------
		public static ChartDashStyle DashStyleFromName (string strName) {
			ChartDashStyle style = ChartDashStyle.NotSet;
			strName = strName.ToLower ();
			if (strName == "solid")
				style = ChartDashStyle.Solid;
			else if (strName == "dash")
				style = ChartDashStyle.Dash;
			else if (strName == "dashdot")
				style = ChartDashStyle.DashDot;
			else if (strName == "dashdotdot")
				style = ChartDashStyle.DashDotDot;
			else if (strName == "dot")
				style = ChartDashStyle.Dot;
			return (style);
		}
	}
}
