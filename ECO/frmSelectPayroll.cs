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
using System.Runtime.InteropServices;


namespace ECO
{
    public partial class frmSelectPayroll : Form
    {
        int maxdays;
        string formsel;
        public List<int> empID;
        public string DailyR;
        public int workdays;
        public double taxx;
        public double taxableamt;
        public string aLT;
        public string aHR;
        public string aWH;
        public string aSSS;
        public string aPH;
        public string aPG;
        public string aDR;
        public string aMR;
        public string aOT;
        public string aOB;
        public string aHP;
        public string aTX;
        public string aNT;
        public string aNS;
        public string aWD;
        public string aPT;
        public string aLP;
        public string aGS;
        public string aTB;
        //public string aNS;
        //public string aPT;
        public double pretax;
        private frmNewPayroll m_Parent;
        public DateTime startingdate;
        public DateTime endingdate;

        public frmSelectPayroll(frmNewPayroll frm1)
        {
            InitializeComponent();
            m_Parent = frm1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSelectPayroll_Load(object sender, EventArgs e)
        {
            lvwEmp.Items.Clear();
            loadyear();
        }

        public void loadPayroll(DateTime dateFrom)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT empID, LastName, FirstName, MiddleInitial FROM emp WHERE empStat='Employed'", msqlcon.con);
            da.Fill(dt);
            lvwEmp.Items.Clear();
            empID = new List<int>();
            empID.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {
                   
                    DataTable dtCP = new DataTable();
                    MySqlDataAdapter daCP = new MySqlDataAdapter("SELECT * FROM tblPayroll WHERE empID=" + Convert.ToInt32(dt.Rows[x][0]) + " AND dateFrom='" + dateFrom.ToString("yyyy-MM-dd") + "'", msqlcon.con);
                    daCP.Fill(dtCP);
                    if (dtCP.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        empID.Add((int)dt.Rows[x][0]);
                        ListViewItem lst = new ListViewItem();
                        lst.Text = "";
                        lst.SubItems.Add(dt.Rows[x][1].ToString() + ", " + dt.Rows[x][2].ToString() + " " + dt.Rows[x][3].ToString() + ".");
                        lvwEmp.Items.Add(lst);
                    }
                         
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (lvwEmp.Items.Count > 0)
            {
                for (int x = 0; x <= lvwEmp.Items.Count - 1; x++)
                {
                    lvwEmp.Items[x].Checked = true;
                }
            }
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            if (lvwEmp.Items.Count > 0)
            {
                for (int x = 0; x <= lvwEmp.Items.Count - 1; x++)
                {
                    lvwEmp.Items[x].Checked = false;
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (lvwEmp.CheckedItems.Count > 0)
            {
                int startd;
                int endd;
                if (cboDays.SelectedIndex == 0)
                {
                    startd = 1;
                    endd = 15;
                }
                else
                {
                    startd = 16;
                    endd = maxdays;
                }
                DateTime startdate = Convert.ToDateTime((cboYear.Text).ToString() + "-" + (cboMonth.SelectedIndex + 1) + "-" + startd);
                DateTime enddate = Convert.ToDateTime((cboYear.Text).ToString() + "-" + (cboMonth.SelectedIndex + 1) + "-" + endd);
                startingdate = startdate;
                endingdate = enddate;

                for (int x = 0; x <= lvwEmp.CheckedItems.Count - 1; x++)
                {
                    DataTable dtCP = new DataTable();
                    MySqlDataAdapter daCP = new MySqlDataAdapter("SELECT E.LastName, E.FirstName, E.MiddleInitial  FROM tblPayroll AS P LEFT JOIN emp AS E ON P.empID=E.empID WHERE P.dateFrom='" + startdate.ToString("yyyy-MM-dd") + "' AND P.empID=" + empID[lvwEmp.CheckedItems[x].Index], msqlcon.con);
                    daCP.Fill(dtCP);
                    if (dtCP.Rows.Count > 0)
                    {
                        MessageBox.Show("Already Payrolled", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        //DEDUCTIONS
                        if (cboDays.SelectedIndex == 0)
                        {
                            aSSS = "0";
                            aPH = "0";
                            aPG = "0";
                        }
                        else
                        {
                            aSSS = Deduction.SSS(empID[lvwEmp.CheckedItems[x].Index]).ToString();
                            aPH = Deduction.PhilHealth(empID[lvwEmp.CheckedItems[x].Index]).ToString();
                            aPG = Deduction.PagIBIG(empID[lvwEmp.CheckedItems[x].Index]).ToString();
                        }
                        aLT = Deduction.LateDeduction(empID[lvwEmp.CheckedItems[x].Index], startdate, enddate).ToString();
                        //SALARY COMPUTER
                        aMR = Salary.MonthlyBasicSalary(empID[lvwEmp.CheckedItems[x].Index]).ToString();
                        aDR = Salary.DailyRate(Convert.ToDouble(aMR)).ToString();
                        aHR = Salary.HourlyRate(Convert.ToDouble(aDR)).ToString();
                        //BONUSES
                        aOT = Bonus.Overtime(empID[lvwEmp.CheckedItems[x].Index], startdate, enddate).ToString();
                        aOB = Bonus.OfficialBusiness(empID[lvwEmp.CheckedItems[x].Index], startdate, enddate).ToString();
                        aHP = Bonus.Holiday(empID[lvwEmp.CheckedItems[x].Index], startdate, enddate).ToString();
                        aWD = Salary.WorkDays(empID[lvwEmp.CheckedItems[x].Index], startdate, enddate).ToString();
                        aWH = Salary.WorkHours().ToString();
                        aLP = Bonus.LeaveWithPay(empID[lvwEmp.CheckedItems[x].Index], startdate, enddate).ToString();
                        aGS = Salary.Compute(2, aMR, aDR, aHR, aOT, aOB, aHP, aLP, aGS, aSSS, aPH, aPG, aWD, aWH, aPT, aTX, aTB, aNT, aNS, aLT).ToString();
                        aPT = Salary.Compute(6, aMR, aDR, aHR, aOT, aOB, aHP, aLP, aGS, aSSS, aPH, aPG, aWD, aWH, aPT, aTX, aTB, aNT, aNS, aLT).ToString();
                        if (cboDays.SelectedIndex == 0)
                        {
                            aTB = "0";
                            aTX = "0";
                        }
                        else
                        {
                            aTB = Tax.TaxableAmount(Convert.ToDouble(aPT), startdate.Month, startdate.Year, empID[lvwEmp.CheckedItems[x].Index]).ToString();
                            aTX = Tax.TaxAmount(Convert.ToDouble(aTB)).ToString();
                        }

                        aNS = Salary.Compute(5, aMR, aDR, aHR, aOT, aOB, aHP, aLP, aGS, aSSS, aPH, aPG, aWD, aWH, aPT, aTX, aTB, aNT, aNS, aLT).ToString();

                        CheckOpen.cons();
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO tblPayroll(empID, monthlybasic, dailyrate, grosssalary, SSS, PhilHealth, Pagibig, WorkingDays, Absents, Lates, lateDeduction, OvertimeHrs, OvertimeAmt, HolidayPays, LeaveWithPay, OfficialBusiness, TaxableAmt, NetPay, DateFrom, DateTo, pretaxsal, taxamt, uID, prolldate) VALUES(@eID, @mbasic, @drate, @gsalary, @SS, @PHealth, @Pibig, @WDays, @Absent, @Late, @LDed, @OTHrs, @OTAmt, @HPays, @LeavePay, @OffBusiness,@Taxable, @NPay, @DFrom, @DTo, @ptsal, @taxa, @userID, @prdate)", msqlcon.con);

                        cmd.Parameters.AddWithValue("@eID", empID[lvwEmp.CheckedItems[x].Index]);
                        cmd.Parameters.AddWithValue("@mbasic", aMR);
                        cmd.Parameters.AddWithValue("@drate", aDR);
                        cmd.Parameters.AddWithValue("@gsalary", aGS);
                        cmd.Parameters.AddWithValue("@SS", aSSS);
                        cmd.Parameters.AddWithValue("@PHealth", aPH);
                        cmd.Parameters.AddWithValue("@Pibig", aPG);
                        cmd.Parameters.AddWithValue("@WDays", aWD);
                        cmd.Parameters.AddWithValue("@Absent", countabsents(empID[lvwEmp.CheckedItems[x].Index], startdate, enddate));
                        cmd.Parameters.AddWithValue("@Late", latecount(empID[lvwEmp.CheckedItems[x].Index], startdate, enddate));
                        cmd.Parameters.AddWithValue("@LDed", aLT);
                        cmd.Parameters.AddWithValue("@OTHrs", othrscount(empID[lvwEmp.CheckedItems[x].Index], startdate, enddate));
                        cmd.Parameters.AddWithValue("@OTAmt", aOT);
                        cmd.Parameters.AddWithValue("@HPays", aHP);
                        cmd.Parameters.AddWithValue("@LeavePay", aLP);
                        cmd.Parameters.AddWithValue("@OffBusiness", aOB);
                        cmd.Parameters.AddWithValue("@Taxable", aTB);
                        cmd.Parameters.AddWithValue("@NPay", aNS);
                        cmd.Parameters.AddWithValue("@DFrom", startdate);
                        cmd.Parameters.AddWithValue("@DTo", enddate);
                        cmd.Parameters.AddWithValue("@ptsal", aPT);
                        cmd.Parameters.AddWithValue("@taxa", aTX);
                        cmd.Parameters.AddWithValue("@userID", StoreData.loggedID);
                        cmd.Parameters.AddWithValue("@prdate", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                    }
                }
                m_Parent.payrollload(startingdate, endingdate);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a Name to Payroll", "Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        public double taxable([Optional] string bSSS,[Optional] string bPH,[Optional] string bPG,[Optional] string bDR,[Optional] string bMR,[Optional] string bOT, [Optional] string bOB, [Optional] string bHP,[Optional] string bTX, [Optional] string bNT, [Optional] string bNS, [Optional] string bWD, [Optional] string bPT, [Optional] string bLP, [Optional] string bGS)
        {
            string myformula;
            string replaceformula;
            double total = 0;
            double taxableamount = 0;
            double compareamount = 0;
            double namount = 0;
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE FormulaID=6", msqlcon.con);
            da.Fill(dt);
            myformula = dt.Rows[0][0].ToString();
            //MessageBox.Show(myformula);
            replaceformula = myformula.Replace("SSS", bSSS).Replace("PH", bPH).Replace("PG", bPG).Replace("DR", bDR).Replace("MR", bMR).Replace("OT", bOT).Replace("OB", bOB).Replace("HP",bHP).Replace("TX",bTX).Replace("NT",bNT).Replace("NS",bNS).Replace("WD",bWD).Replace("PT",bPT).Replace("LP",bLP).Replace("GS", bGS);
            //MessageBox.Show(replaceformula);
            total = GetFormula.Ans(replaceformula);
            //MessageBox.Show(GetFormula.Ans(replaceformula).ToString());
            pretax = total;
            DataTable dtNon = new DataTable();
            MySqlDataAdapter daNon = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE formulaID=4", msqlcon.con);
            daNon.Fill(dtNon);
            string newtotal = total.ToString();
            string replaceneg = newtotal.Replace("-", "");
            double gottotal = Convert.ToDouble(replaceneg);
            //MessageBox.Show(replaceneg);
            if (dtNon.Rows.Count > 0)
            {
                namount = Convert.ToInt32(dtNon.Rows[0][0].ToString());
                compareamount = gottotal - (namount / 12);
                if (compareamount >= 0)
                {
                    taxableamount = compareamount;
                }
                else
                {
                    taxableamount = 0;
                }
            }
            else
            {
                taxableamount = total;
            }
            taxableamt = taxableamount;
            return taxableamount;
        }

        public double netsalary(double pretax, double taxamt)
        {
            double mysala = pretax - taxamt;
            return mysala;
        }

        public double gettaxamount(double tax)
        {
            taxx = (tax * .2);
            return taxx;
        }
    

        public void loadyear()
        {
            cboYear.Items.Clear();
            for (int x = 2015; x <= DateTime.Now.Year; x++)
            {
                cboYear.Items.Add(x);
            }
        }

        public void loaddays(int year, int month)
        {
            cboDays.Items.Clear();
            maxdays = DateTime.DaysInMonth(year, month);
            cboDays.Items.Add("1 to 15");
            cboDays.Items.Add("16 to " + maxdays);
        }

        //public void netsalary()
        //{

        //}

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwEmp.Items.Clear();
            try
            {
                loaddays(Convert.ToInt32(cboYear.Text), cboMonth.SelectedIndex + 1);
            }
            catch
            {
                cboDays.Items.Clear();
            }

        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwEmp.Items.Clear();
            try
            {
                loaddays(Convert.ToInt32(cboYear.Text), cboMonth.SelectedIndex + 1);
            }
            catch
            {
                cboDays.Items.Clear();
            }
        }

        public double monthlysalary(int eID)
        {
            CheckOpen.cons();
            double salarym;
            double sal;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT P.BasicPay FROM emp AS E LEFT JOIN empposition AS P ON E.positionID=P.positionID WHERE e.empID=" + eID, msqlcon.con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                salarym = (double)dt.Rows[0][0];
            }
            else
            {
                salarym = 0;
            }
            sal = salarym;
            return sal;
        }

        public double Formula(int empID, int formtype)
        {
            CheckOpen.cons();

            double fmula;
            string myFormula;
            if (formtype == 1) //dailyrate
            {
                formsel = "1";
            }
            else if (formtype == 2) //gross salary
            {
                formsel = "2";
            }
            else if (formtype == 3) //netsalary
            {
                formsel = "5";
            }
            else if (formtype == 4) //pretaxsalary
            {
                formsel = "6";
            }

            DataTable dtDeduction = new DataTable();
            MySqlDataAdapter daDedct = new MySqlDataAdapter("SELECT P.BasicPay, P.SSS, P.PagIbig, P.PhilHealth  FROM empposition AS P LEFT JOIN emp AS E ON P.positionID =E.positionID WHERE E.empID=" + empID, msqlcon.con);
            daDedct.Fill(dtDeduction);
            string basic = dtDeduction.Rows[0][0].ToString();
            string sss = dtDeduction.Rows[0][1].ToString();
            string pagi = dtDeduction.Rows[0][2].ToString();
            string ph = dtDeduction.Rows[0][0].ToString();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Formula FROM tblformula WHERE FormulaID=" + formsel, msqlcon.con);
            da.Fill(dt);
            myFormula = dt.Rows[0][0].ToString();
            string res;
            res = myFormula.Replace("MR", basic).Replace("SSS", sss).Replace("PG", pagi).Replace("PH", ph);

            fmula = 0;


            return fmula;
        }

        public double drate(int eID)
        {
            double daily;
            CheckOpen.cons();
            DataTable dtMonth = new DataTable();
            MySqlDataAdapter daMonth = new MySqlDataAdapter("SELECT P.BasicPay FROM empposition AS P LEFT JOIN emp AS E ON P.positionID =E.positionID WHERE E.empID=" + eID, msqlcon.con);
            daMonth.Fill(dtMonth);
            string mbasic = dtMonth.Rows[0][0].ToString();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Formula FROM tblformula WHERE FormulaID=1", msqlcon.con);
            da.Fill(dt);
            string fmula = dt.Rows[0][0].ToString();
            string newfmula = fmula.Replace("MR", mbasic);
            daily = GetFormula.Ans(newfmula);
            DailyR = daily.ToString();
            return daily;
        }

        public double msal(int eID, DateTime Starter, DateTime Ender)
        {
            //int wdays;
            int countdays = 0;
            double monthl;
            CheckOpen.cons();
            DataTable dtWD = new DataTable();
            dtWD.Clear();
            MySqlDataAdapter daWD = new MySqlDataAdapter("SELECT computedtime FROM timesheet WHERE  tDate BETWEEN '" + Starter.ToString("yyyy-MM-dd") + "' AND '" + Ender.ToString("yyyy-MM-dd") + "' and empID=" + eID, msqlcon.con);
            daWD.Fill(dtWD);
            //MessageBox.Show("SELECT tdate, computedtime FROM timesheet WHERE  tDate BETWEEN '" + Starter.ToString("yyyy-MM-dd") + "' AND '" + Ender.ToString("yyyy-MM-dd") + "' and empID=" + eID);
            if (dtWD.Rows.Count > 0)
            {
                for (int x = 0; x <= dtWD.Rows.Count - 1; x++)
                {
                    int gethrs;
                    string ctime;
                    try
                    {
                        ctime = dtWD.Rows[x][0].ToString();
                    }
                    catch
                    {
                        ctime = "";
                    }

                    if (ctime == "")
                    {
                        gethrs = 0;
                    }
                    else
                    {
                        gethrs = Convert.ToInt32(dtWD.Rows[x][0].ToString());
                        //MessageBox.Show(gethrs.ToString());
                    }
                    if (gethrs >= 1)
                    {
                        countdays++;
                    }
                }
            }
            else
            {
                countdays = 0;
            }
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Formula FROM tblformula WHERE FormulaID=2", msqlcon.con);
            da.Fill(dt);
            string fmula = dt.Rows[0][0].ToString();
            workdays = countdays;
            string newfmula = fmula.Replace("DR", DailyR).Replace("WD", countdays.ToString());
            monthl = GetFormula.Ans(newfmula);
            return monthl;

        }

        public double deductions(string types, int eID)
        {

            CheckOpen.cons();
            double ded;
            double c = Convert.ToDouble(aGS);
            if (c > 1)
            {
                DataTable dt = new DataTable();
                
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT " + types + " FROM emp AS E LEFT JOIN empposition AS P ON E.positionID=P.positionID WHERE E.empID=" + eID, msqlcon.con);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ded = Convert.ToDouble(dt.Rows[0][0].ToString());
                }
                else
                {
                    ded = 0;
                }
            }
            else
            {
                ded = 0;
            }
           
            return ded;
        }

        public int countabsents(int eID, DateTime Starter, DateTime Ender)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT count(*) FROM timesheet WHERE  tDate BETWEEN '" + Starter.ToString("yyyy-MM-dd") + "' AND '" + Ender.ToString("yyyy-MM-dd") + "' and empID=" + eID + " AND Remark='Absent'", msqlcon.con);
            da.Fill(dt);
            int counter = 0;
            if (dt.Rows.Count > 0)
            {
                counter = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            return counter;

        }

        public int latecount(int eID, DateTime Starter, DateTime Ender)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT TimeIn1 FROM timesheet WHERE tDate BETWEEN '" + Starter.ToString("yyyy-MM-dd") + "' AND '" + Ender.ToString("yyyy-MM-dd") + "' and empID=" + eID  + " AND NOT (DayName='Saturday' OR DayName='Sunday')", msqlcon.con);
            da.Fill(dt);
            int counter = 0;
            if (dt.Rows.Count > 0)
            {
                for (int x = 0; x < dt.Rows.Count - 1; x++)
                {
                    if (dt.Rows[x][0].ToString() != "")
                    {
                        DateTime timref = Convert.ToDateTime("9:15 AM");
                        DateTime timget = Convert.ToDateTime(dt.Rows[x][0].ToString());
                        if (timget >= timref)
                        {
                            counter++;
                        }
                    }
                }
            }
            return counter;
        }
    
        public int othrscount(int eID, DateTime Starter, DateTime Ender)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT count(*) FROM timesheet WHERE tDate BETWEEN '" + Starter.ToString("yyyy-MM-dd") + "' AND '" + Ender.ToString("yyyy-MM-dd") + "' and empID=" + eID + " AND Remark Like '%Overtime%'", msqlcon.con);
            da.Fill(dt);
            int counter = 0;
            if (dt.Rows.Count > 0)
            {
                counter = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            return counter;
        }

        private void cboDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwEmp.Items.Clear();
            int startd;
            if (cboDays.SelectedIndex == 0)
            {
                startd = 1;
                
            }
            else
            {
                startd = 16;
                
            }
            DateTime startdate = Convert.ToDateTime((cboYear.Text).ToString() + "-" + (cboMonth.SelectedIndex + 1) + "-" + startd);
            loadPayroll(startdate);
        }
    }
}