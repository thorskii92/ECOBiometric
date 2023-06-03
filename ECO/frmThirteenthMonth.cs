using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace ECO
{
    public partial class frmThirteenthMonth : Form
    {
        public frmThirteenthMonth()
        {
            InitializeComponent();
        }

        private void frmThirteenthMonth_Load(object sender, EventArgs e)
        {
            cboYear.Items.Clear();
            for (int x = 2015; x <= DateTime.Now.Year; x++)
            {
                cboYear.Items.Add(x);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cboYear.Text == "")
            {
                MessageBox.Show("Please select year", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CheckOpen.cons();
                lvwTM.Items.Clear();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT E.empID, E.LastName, E.FirstName, E.LastName, E.DateHired, P.BasicPay FROM emp AS E LEFT JOIN empposition AS P ON E.positionID=P.positionID WHERE E.empstat='Employed' and Year(Datehired)<=" + cboYear.Text, msqlcon.con);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int x = 0; x <= dt.Rows.Count - 1; x++)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.Text = dt.Rows[x][0].ToString();
                        lst.SubItems.Add(dt.Rows[x][1].ToString() + ", " + dt.Rows[x][2].ToString() + " " + dt.Rows[x][3].ToString() + ".");
                        lst.SubItems.Add(Convert.ToDateTime(dt.Rows[x][4]).ToString("MM-dd-yyyy"));
                        lst.SubItems.Add(Convert.ToDouble(dt.Rows[x][5]).ToString("#,##0.#0"));
                        lst.SubItems.Add(Salary.countMonths(Convert.ToInt32(dt.Rows[x][0]), Convert.ToInt32(cboYear.Text)).ToString());
                        lst.SubItems.Add(cboYear.Text);
                        lst.SubItems.Add(Salary.ThirteenthMonth(Convert.ToInt32(dt.Rows[x][0]), Convert.ToInt32(cboYear.Text)).ToString("#,##0.#0"));
                        lvwTM.Items.Add(lst);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int countme = 0;
            int countSaved = 0;
            CheckOpen.cons();
            if (lvwTM.Items.Count > 0)
            {
                for (int x = 0; x <= lvwTM.Items.Count - 1; x++)
                {
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM thirteenthmonth WHERE empID=" + lvwTM.Items[x].Text + " AND year=" + cboYear.Text, msqlcon.con);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        countme++;
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO thirteenthmonth(empID, year, SAmount, monthsworked, basicsalary, uID, DateCreated) VALUES(@eID, @yr, @amt, @msworked, @bsalary, @userID, @dCreate)", msqlcon.con);
                        cmd.Parameters.AddWithValue("@eID", lvwTM.Items[x].Text);
                        cmd.Parameters.AddWithValue("@yr", cboYear.Text);
                        //MessageBox.Show(lvwTM.Items[x].SubItems[6].Text);
                        cmd.Parameters.AddWithValue("@amt", Convert.ToDouble(lvwTM.Items[x].SubItems[6].Text));
                        cmd.Parameters.AddWithValue("@msworked", lvwTM.Items[x].SubItems[4].Text);
                        cmd.Parameters.AddWithValue("@bsalary", Convert.ToDouble(lvwTM.Items[x].SubItems[3].Text));
                        cmd.Parameters.AddWithValue("@userID", StoreData.loggedID);
                        cmd.Parameters.AddWithValue("@dCreate", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                        countSaved++;
                    }
                }
                if (countme > 0)
                {
                    MessageBox.Show(countme + " payslips cannot be save because it's already issued by Thirteenth Month Payslip", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (countSaved > 0)
                {
                    MessageBox.Show(countSaved + " payslips has been Saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                print(Convert.ToInt32(cboYear.Text));


            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwTM.Items.Clear();
        }

        private void print(int year)
        {
            frmThirteenMonthPrint tprint = new frmThirteenMonthPrint();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT T.*, E.LastName, E.FirstName, E.MiddleInitial, E.DateHired, U.FullName, P.PositionName  FROM thirteenthmonth AS T LEFT JOIN emp AS E ON T.empID=E.empID LEFT JOIN user AS U ON T.uID=U.userID LEFT JOIN empposition AS P ON E.positionID=P.positionID WHERE T.year=" + year, msqlcon.con);
            da.Fill(dt);
            tprint.payrolldataset.tmonth.Clear();
            da.Fill(tprint.payrolldataset.tmonth);
            //pprint.reportViewer1.RefreshReport();
            tprint.WindowState = FormWindowState.Maximized;
            tprint.reportViewer1.ZoomPercent = 100;
            tprint.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            tprint.reportViewer1.Width = 75;
            tprint.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            tprint.reportViewer1.RefreshReport();
            tprint.WindowState = FormWindowState.Maximized;
            tprint.ShowDialog();
        }
    }
}
