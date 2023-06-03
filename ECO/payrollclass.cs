using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ECO
{


    class payrollclass
    {
    }
    public class Deduction
    {
        public static double SSS(int empID)
        {
            double Deduct;
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT P.SSS FROM empposition AS P LEFT JOIN emp AS E ON P.positionID=E.positionID WHERE E.empID=" + empID, msqlcon.con);
            da.Fill(dt);
            Deduct = Convert.ToDouble(dt.Rows[0][0].ToString());
            return Deduct;
        }

        public static double PhilHealth(int empID)
        {
            double Deduct;
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT P.PhilHealth FROM empposition AS P LEFT JOIN emp AS E ON P.positionID = E.positionID WHERE E.empID = " + empID, msqlcon.con);
            da.Fill(dt);
            Deduct = Convert.ToDouble(dt.Rows[0][0].ToString());
            return Deduct;
        }

        public static double PagIBIG(int empID)
        {
            double Deduct;
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT P.Pagibig FROM empposition AS P LEFT JOIN emp AS E ON P.positionID=E.positionID WHERE E.empID=" + empID, msqlcon.con);
            da.Fill(dt);
            Deduct = Convert.ToDouble(dt.Rows[0][0].ToString());
            return Deduct;
        }



        public static double LateDeduction(int empID, DateTime StartDate, DateTime EndDate)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT TimeIn1 FROM timesheet WHERE tDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "' and empID=" + empID + " AND NOT (DayName='Saturday' OR DayName='Sunday')", msqlcon.con);
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
            DataTable dtWH = new DataTable();
            MySqlDataAdapter daWH = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE FormulaID=3", msqlcon.con);
            daWH.Fill(dtWH);
            double dayrate = Salary.DailyRate(Salary.MonthlyBasicSalary(empID));
            int workH = Convert.ToInt32(dtWH.Rows[0][0].ToString());
            double hrate = dayrate / workH;
            double totalDedLate = hrate * counter;
            return totalDedLate;
        }
    }

    public class Bonus
    {
        public static double Overtime(int empID, DateTime StartDate, DateTime EndDate)
        {
            CheckOpen.cons();
            DataTable dtWH = new DataTable();
            MySqlDataAdapter daWH = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE FormulaID=3", msqlcon.con);
            daWH.Fill(dtWH);
            int workH = Convert.ToInt32(dtWH.Rows[0][0].ToString());
            int comphours = 0;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT computedtime FROM timesheet WHERE tDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "' and empID=" + empID + " AND Remark Like '%Overtime%'", msqlcon.con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {
                    int totaltime = Convert.ToInt32(dt.Rows[x][0].ToString());
                    comphours = totaltime - workH;
                }
            }
            double dayrate = Salary.DailyRate(Salary.MonthlyBasicSalary(empID));
            double hrate = dayrate / workH;
            double otrate = hrate * comphours;
            return otrate;
        }

        public static double LeaveWithPay(int empID, DateTime StartDate, DateTime EndDate)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT count(*) FROM timesheet WHERE tDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "' and empID=" + empID + " AND Remark='Leave with Pay'", msqlcon.con);
            da.Fill(dt);
            int counter = 0;
            if (dt.Rows.Count > 0)
            {
                counter = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            double dayrate = Salary.DailyRate(Salary.MonthlyBasicSalary(empID));
            double totalrate = dayrate * counter;
            return totalrate;
        }

        public static double LeaveWithoutPay(int empID, DateTime StartDate, DateTime EndDate)
        {
            double Bons = 0;
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT COUNT(*) FROM timesheet WHERE empID = " + empID + " AND Remark LIKE '%Leave%' AND tDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "'", msqlcon.con);
            da.Fill(dt);
            Bons = (double)dt.Rows[0][0];
            return Bons;
        }

        public static double OfficialBusiness(int empID, DateTime StartDate, DateTime EndDate)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT count(*) FROM timesheet WHERE tDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "' and empID=" + empID + " AND Remark='Official Business'", msqlcon.con);
            da.Fill(dt);
            int counter = 0;
            if (dt.Rows.Count > 0)
            {
                counter = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            double dayrate = Salary.DailyRate(Salary.MonthlyBasicSalary(empID));
            double totalrate = dayrate * counter;
            return totalrate;
        }

        public static double Holiday(int empID, DateTime StartDate, DateTime EndDate)
        {
            
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT count(*) FROM timesheet WHERE tDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "' and empID=" + empID + " AND Remark='Holiday'", msqlcon.con);
            da.Fill(dt);
            int counter = 0;
            if (dt.Rows.Count > 0)
            {
                counter = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            double dayrate = Salary.DailyRate(Salary.MonthlyBasicSalary(empID));
            double totalrate = dayrate * counter;
            return totalrate;
        }

        public static double ThirteenMonth(int empID, int CurYear)
        {
            double Bons = 0;
            return Bons;
        }

        public static double MidYear(int empID, int CurYear)
        {
            double Bons = 0;
            return Bons;
        }
    }

    public class Salary
    {

        public static double ThirteenthMonth(int empID, int year)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT E.DateHired, P.BasicPay FROM emp AS E LEFT JOIN empposition AS P ON e.positionID=p.positionID WHERE e.empID=" + empID, msqlcon.con);
            da.Fill(dt);
            DateTime dHired = Convert.ToDateTime(dt.Rows[0][0]);
            int totalmonths = (((year - dHired.Year) * 12) + (12 - dHired.Month));
            double BasicSalary = Convert.ToDouble(dt.Rows[0][1]);
            double computedSalary = 0;
            if (totalmonths < 12)
            {
                computedSalary = ((BasicSalary * totalmonths) / 12);
            }
            else
            {
                computedSalary = BasicSalary;
            }
            return computedSalary;
        }

        public static int countMonths(int empID, int year)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT E.DateHired, P.BasicPay FROM emp AS E LEFT JOIN empposition AS P ON e.positionID=p.positionID WHERE e.empID=" + empID, msqlcon.con);
            da.Fill(dt);
            DateTime dHired = Convert.ToDateTime(dt.Rows[0][0]);
            int totalmonths = (((year - dHired.Year) * 12) + (12 - dHired.Month));
            return totalmonths;
        }

        public static int WorkDays(int empID, DateTime StartDate, DateTime EndDate)
        {
            int countdays = 0;
            CheckOpen.cons();
            DataTable dtWD = new DataTable();
            dtWD.Clear();
            MySqlDataAdapter daWD = new MySqlDataAdapter("SELECT computedtime FROM timesheet WHERE  tDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "' and empID=" + empID, msqlcon.con);
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
            return countdays;
        }

        public static double DailyRate(double MSal)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE FormulaID=1", msqlcon.con);
            da.Fill(dt);
            string Formula = dt.Rows[0][0].ToString();
            double Daily = GetFormula.Ans(Formula.Replace("MR", MSal.ToString()));
            return Daily;
        }

        public static int WorkHours()
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE FormulaID=3", msqlcon.con);
            da.Fill(dt);
            int wHrs = Convert.ToInt32(dt.Rows[0][0]);
            return wHrs;
        }

        public static double MonthlyBasicSalary(int empID)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT P.BasicPay FROM emp AS E LEFT JOIN empposition AS P ON E.positionID=P.positionID WHERE e.empID=" + empID, msqlcon.con);
            da.Fill(dt);
            double Msal = 0;
            Msal = (double)dt.Rows[0][0];
            return Msal;   
        }

        public static double HourlyRate(double Daily)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE FormulaID=3", msqlcon.con);
            da.Fill(dt);
            double WorkHours = Convert.ToDouble(dt.Rows[0][0]);
            double myRate = (Daily / WorkHours);
            return myRate;

        }

        public static double Compute(int ForID , string MR, string DR, string HR, string OT, string OB, string HP, string LP, string GS, string SS, string PH, string PG, string WD, string WH, string PT, string TX, string TB, string NT, string NS, string LT)

        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE FormulaID=" + ForID, msqlcon.con);
            da.Fill(dt);
            string Formula = dt.Rows[0][0].ToString();
            //MessageBox.Show(Formula);
            string ReplaceFormula = Formula.Replace("MR", MR).Replace("DR", DR).Replace("HR", HR).Replace("OT", OT).Replace("OB", OB).Replace("HP", HP).Replace("LP", LP).Replace("GS", GS).Replace("SS", SS).Replace("PH", PH).Replace("PG", PG).Replace("WD", WD).Replace("WH", WH).Replace("PT", PT).Replace("TX", TX).Replace("TB", TB).Replace("NT", NT).Replace("NS", NS).Replace("LT", LT);
            //MessageBox.Show(ReplaceFormula);
            double Comp = GetFormula.Ans(ReplaceFormula);
            return Comp;
        }
    }

    public class Tax
    {
        public static double TaxableAmount(double Amount, int Month, int Year, int empID)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE FormulaID=4", msqlcon.con);
            da.Fill(dt);
            double NTax =Convert.ToDouble(dt.Rows[0][0]);
            double MonthlyNTax = (NTax / 12);

            DataTable dtP = new DataTable();
            MySqlDataAdapter daP = new MySqlDataAdapter("SELECT NetPay FROM tblPayroll WHERE MONTH(DateFrom)='" + Month + "' AND YEAR(dateFrom)='" + Year + "' AND DAY(DateFrom)='1' AND empID=" + empID, msqlcon.con);
            daP.Fill(dtP);
            double prevSal;
            if (dtP.Rows.Count > 0)
            {
                prevSal = Convert.ToDouble(dtP.Rows[0][0]);
            }
            else
            {
                prevSal = 0;
            }
            
            double Taxa = (Amount + prevSal) - MonthlyNTax;
            if (Taxa < 0) 
            {
                Taxa = 0;
            }
            return Taxa;
        }
        public static double TaxAmount(double Amount)
        {
            double TaxAm = (Amount * 0.20);
            return TaxAm;
        }
    }

    


}
