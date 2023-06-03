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
    public partial class frmPayrollBreakdown : Form
    {
        public frmPayrollBreakdown()
        {
            InitializeComponent();
        }

        private void frmPayrollBreakdown_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPrintPayroll pprint = new frmPrintPayroll();
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT P.*, E.LastName, E.FirstName, E.MiddleInitial, U.FullName, POS.PositionName  FROM tblPayroll AS P LEFT JOIN emp AS E ON P.empID=E.empID LEFT JOIN user AS U ON P.uID=U.UserID LEFT JOIN empposition AS POS ON E.positionID=POS.positionID WHERE P.prID=" + StoreData.SelectedPayrollID, msqlcon.con);
            da.Fill(pprint.dset.payroll);
            pprint.reportViewer1.RefreshReport();
            pprint.WindowState = FormWindowState.Maximized;
            pprint.reportViewer1.ZoomPercent = 100;
            pprint.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            pprint.reportViewer1.Width = 75;
            pprint.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            pprint.reportViewer1.RefreshReport();
            pprint.WindowState = FormWindowState.Maximized;
            pprint.ShowDialog();

        }
    }
}
