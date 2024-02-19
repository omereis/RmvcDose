using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RmvDose
{
	public partial class dlgAbout : Form
	{
		public dlgAbout()
		{
			InitializeComponent();
		}
		public bool Execute() {
			// https://stackoverflow.com/questions/19384193/get-company-name-and-copyright-information-of-assembly
			var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
			txtbxProduct.Text = versionInfo.ProductName;
			txtbxVersion.Text = versionInfo.FileVersion;// Assembly.GetExecutingAssembly().GetName().Name;
			Type t = typeof(string);
			txtbxTitle.Text = versionInfo.FileDescription;//  Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
			txtbxCompany.Text = versionInfo.CompanyName;
			txtbxCopyrights.Text = versionInfo.LegalCopyright;
			return ShowDialog() == DialogResult.OK;
		}
	}
}
