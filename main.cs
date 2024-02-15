using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RmvDose
{
    public partial class main : Form
    {
//-----------------------------------------------------------------------------
        public main()
        {
            InitializeComponent();
        }
//-----------------------------------------------------------------------------
        private void btnOpen_Click(object sender, EventArgs e)
        {
            dlgOpenCsv.FileName = "";
            if (dlgOpenCsv.ShowDialog() == DialogResult.OK) {
                CsvToGrid (dlgOpenCsv.FileName, gridCSV);
                txtbxFile.Text = dlgOpenCsv.FileName;
            }
        }
//-----------------------------------------------------------------------------
        private void CsvToGrid (string strFileName, DataGridView grid) {
            
        }
//-----------------------------------------------------------------------------
    }
}
