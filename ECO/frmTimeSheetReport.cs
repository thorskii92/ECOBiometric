using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace ECO
{
    public partial class frmTimeSheetReport : Form
    {
        public frmTimeSheetReport()
        {
            InitializeComponent();
        }

        private void frmTimeSheetReport_Load(object sender, EventArgs e)
        {
            //MySqlDataAdapter da = new MySqlDataAdapter("", msqlcon.con);
            //da.Fill(this.dset.timesheet);
            this.reportViewer1.RefreshReport();
        }
    }
}
