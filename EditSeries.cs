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
		}
//-----------------------------------------------------------------------------
		private void Upload (Series ser) {
			ser.BorderWidth = m_ser.BorderWidth;
			ser.Color = m_ser.Color;
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
	}
}
