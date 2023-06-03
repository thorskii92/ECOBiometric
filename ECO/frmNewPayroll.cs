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
    public partial class frmNewPayroll : Form
    {
        private frmSelectPayroll _SelPayroll;
        private frmPayrollLoader _PayLoad;
        public List<int> prollID;
        public List<int> pempID;
        public frmNewPayroll()
            
        {
            InitializeComponent();
            _SelPayroll = new frmSelectPayroll(this);
            _PayLoad = new frmPayrollLoader(this);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNewPayroll_Click(object sender, EventArgs e)
        {
           
            _SelPayroll.StartPosition = FormStartPosition.CenterScreen;
            _SelPayroll.ShowDialog();
        }

        private void frmNewPayroll_Load(object sender, EventArgs e)
        {

        }

        public void payrollload(DateTime dFrom, DateTime dTo)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            StoreData.PayrollQuery = "SELECT P.prID, E.empID ,E.LastName, E.FirstName, E.MiddleInitial, P.grosssalary ,(P.SSS + P.PhilHealth + P.Pagibig + P.taxamt) AS deduct, P.NetPay FROM tblPayroll AS P LEFT JOIN emp AS E ON P.empID=E.empID WHERE dateFrom='" + dFrom.ToString("yyyy-MM-dd") + "' AND dateTo='" + dTo.ToString("yyyy-MM-dd") + "'";

            MySqlDataAdapter da = new MySqlDataAdapter(StoreData.PayrollQuery, msqlcon.con);
            da.Fill(dt);
            lvwPayrollList.Items.Clear();
            
            prollID = new List<int>();
            pempID = new List<int>();
            pempID.Clear();
            prollID.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {
                    prollID.Add((int)dt.Rows[x][0]);
                    pempID.Add((int)dt.Rows[x][1]);
                    ListViewItem lst = new ListViewItem();
                    lst.Text = dt.Rows[x][2].ToString() + ", " + dt.Rows[x][3].ToString() + " " + dt.Rows[x][4].ToString() + ".";
                    lst.SubItems.Add(Convert.ToDouble(dt.Rows[x][5].ToString()).ToString("#,##0.#0"));
                    lst.SubItems.Add(Convert.ToDouble(dt.Rows[x][6].ToString()).ToString("#,##0.#0"));
                    lst.SubItems.Add(Convert.ToDouble(dt.Rows[x][7].ToString()).ToString("#,##0.#0"));
                    lvwPayrollList.Items.Add(lst);
                }
            }
        }

        

        private void btnViewPayroll_Click(object sender, EventArgs e)
        {
            if (lvwPayrollList.SelectedItems.Count > 0)
            {
                CheckOpen.cons();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT P.*, E.LastName, E.FirstName, E.MiddleInitial, U.FullName, POS.PositionName  FROM tblPayroll AS P LEFT JOIN emp AS E ON P.empID=E.empID LEFT JOIN user AS U ON P.uID=U.UserID LEFT JOIN empposition AS POS ON E.positionID=POS.positionID WHERE P.prID=" + prollID[lvwPayrollList.FocusedItem.Index], msqlcon.con);
                da.Fill(dt);
                StoreData.SelectedPayrollID = prollID[lvwPayrollList.FocusedItem.Index];
                frmPayrollBreakdown fBrk = new frmPayrollBreakdown();
                fBrk.lblAbsent.Text = dt.Rows[0][9].ToString() + " days";
                fBrk.lblDaily.Text = "Php " + Convert.ToDouble(dt.Rows[0][3]).ToString("#0.#0");
                fBrk.lblDate.Text  = Convert.ToDateTime(dt.Rows[0][24]).ToString("MM-dd-yyyy");
                fBrk.lblGross.Text = "Php " + Convert.ToDouble(dt.Rows[0][4]).ToString("#0.#0");
                fBrk.lblHoliday.Text = "Php " + Convert.ToDouble(dt.Rows[0][14]).ToString("#0.#0");
                fBrk.lblID.Text = dt.Rows[0][1].ToString();
                fBrk.lblLate.Text = dt.Rows[0][10].ToString() + " hrs";
                fBrk.lblLateDeduct.Text = "Php " + Convert.ToDouble(dt.Rows[0][11]).ToString("#0.#0");
                fBrk.lblLeaveWithPay.Text = "Php " + Convert.ToDouble(dt.Rows[0][15]).ToString("#0.#0");
                fBrk.lblMonthly.Text = "Php " + Convert.ToDouble(dt.Rows[0][2]).ToString("#0.#0"); ;
                fBrk.lblName.Text = dt.Rows[0][25].ToString() + ", " + dt.Rows[0][26].ToString() + " " +  dt.Rows[0][27].ToString() + ".";
                fBrk.lblNetSalary.Text = "Php " + Convert.ToDouble(dt.Rows[0][18]).ToString("#0.#0");
                fBrk.lblOB.Text = "Php " + Convert.ToDouble(dt.Rows[0][16]).ToString("#0.#0");
                fBrk.lblOTAmt.Text = "Php " + Convert.ToDouble(dt.Rows[0][13]).ToString("#0.#0");
                fBrk.lblOThrs.Text = dt.Rows[0][12].ToString() + " hrs";
                fBrk.lblPagibig.Text = "Php " + Convert.ToDouble(dt.Rows[0][7]).ToString("#0.#0");
                fBrk.lblPayrollDates.Text = Convert.ToDateTime(dt.Rows[0][19]).ToString("MM-dd-yyyy") + " to " + Convert.ToDateTime(dt.Rows[0][20]).ToString("MM-dd-yyyy");
                fBrk.lblPhilHealth.Text = "Php " + Convert.ToDouble(dt.Rows[0][6]).ToString("#0.#0");
                fBrk.lblPosition.Text = dt.Rows[0][29].ToString();
                fBrk.lblPrepared.Text = dt.Rows[0][28].ToString();
                fBrk.lblSalNoTax.Text = "Php " + Convert.ToDouble(dt.Rows[0][21]).ToString("#0.#0");
                fBrk.lblSSS.Text = "Php " + Convert.ToDouble(dt.Rows[0][5]).ToString("#0.#0");
                fBrk.lblTaxable.Text = "Php " + Convert.ToDouble(dt.Rows[0][17]).ToString("#0.#0");
                fBrk.lblWithhold.Text = "Php " + Convert.ToDouble(dt.Rows[0][22]).ToString("#0.#0");
                fBrk.lblWorkDays.Text = dt.Rows[0][8].ToString() + " days";
                fBrk.StartPosition = FormStartPosition.CenterScreen;
                fBrk.ShowDialog();
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwPayrollList.Items.Count > 0)
            {

                StoreData.MultiPayrollQuery = "SELECT P.*, E.LastName, E.FirstName, E.MiddleInitial, U.FullName, POS.PositionName  FROM tblPayroll AS P LEFT JOIN emp AS E ON P.empID=E.empID LEFT JOIN user AS U ON P.uID=U.UserID LEFT JOIN empposition AS POS ON E.positionID=POS.positionID WHERE ";
                for (int x=0; x <= lvwPayrollList.Items.Count - 1; x++)
                {
                    StoreData.MultiPayrollQuery = StoreData.MultiPayrollQuery + " P.prID=" + prollID[lvwPayrollList.Items[x].Index];
                    if (x < lvwPayrollList.Items.Count - 1)
                    {
                        StoreData.MultiPayrollQuery = StoreData.MultiPayrollQuery + " OR ";
                    }
                }
                //MessageBox.Show(StoreData.MultiPayrollQuery);
                frmPrintPayroll pprint = new frmPrintPayroll();
                CheckOpen.cons();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(StoreData.MultiPayrollQuery, msqlcon.con);
                pprint.dset.Clear();
                da.Fill(pprint.dset.payroll);
                //pprint.reportViewer1.RefreshReport();
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

        private void button2_Click(object sender, EventArgs e)
        {
            frmThirteenthMonth tmonth = new frmThirteenthMonth();
            tmonth.StartPosition = FormStartPosition.CenterScreen;
            tmonth.lvwTM.Items.Clear();
            tmonth.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _PayLoad.StartPosition = FormStartPosition.CenterScreen;
            _PayLoad.ShowDialog();
        }
    }
}
