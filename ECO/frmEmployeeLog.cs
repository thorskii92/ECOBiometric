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
    public partial class frmEmployeeLog : Form
    {
        List<int> arrAttID;
        int workHours;

        DateTime dateFromTS;
        DateTime dateToTS;
        public frmEmployeeLog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmployeeLog_Load(object sender, EventArgs e)
        {
            loadYear();
        }

        public void loadYear()
        {
            cboYear.Items.Clear();
            for (int x = 2017; x <= DateTime.Now.Year; x++)
            {
                cboYear.Items.Add(x);
            }
        }

        public void loadFrom(int year, int m)
        {
            try
            {
                int x = DateTime.DaysInMonth(year, m);
                cboDays.Items.Clear();
                cboDays.Items.Add("1 to 15");
                cboDays.Items.Add("16 to " + x);
            }
            catch
            {

            }
            
        }

        public void loadTo(int year, int m, int seld)
        {
            try
            {
                //cboDayTo.Items.Clear();
                int x = DateTime.DaysInMonth(year, m);
                for (int y = seld; y <= x; y++)
                {
                    //cboDayTo.Items.Add(y);
                }
            }
            catch
            {

            }
            
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadFrom(Convert.ToInt32(cboYear.Text), (cboMonth.SelectedIndex + 1));
            lvwTimeSheet.Items.Clear();
        }

        private void cboDayFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadTo(Convert.ToInt32(cboYear.Text), (cboMonth.SelectedIndex + 1), Convert.ToInt32(cboDayFrom.Text));
            lvwTimeSheet.Items.Clear();
        }

        private void btnLOad_Click(object sender, EventArgs e)
        {
            lvwTimeSheet.Items.Clear();
            arrAttID = new List<int>();
            arrAttID.Clear();
            //CheckOpen.cons();
            //DataTable dt = new DataTable();
            //MySqlDataAdapter da = new MySqlDataAdapter("SELECT dateIn, Day, TimeIn1, TimeOut1, TimeIn2, TimeOut2 FROM attendance WHERE empID=" + txtID.Text + " AND dateIn BETWEEN '" + cboYear.Text + "-" + (cboMonth.SelectedIndex + 1).ToString() + "-" + cboDayFrom.Text + "' AND '" + cboYear.Text + "-" + (cboMonth.SelectedIndex + 1).ToString() + "-" + cboDayTo.Text + "'", msqlcon.con);
            //da.Fill(dt);
            //lvwTimeSheet.Items.Clear();
            //if (dt.Rows.Count > 0)
            //{
            //    for (int x=0; x <= dt.Rows.Count - 1; x++)
            //    {
            //        ListViewItem lst = new ListViewItem();
            //        lst.Text = Convert.ToDateTime(dt.Rows[x][0]).ToString("dd");
            //        lst.SubItems.Add(dt.Rows[x][2].ToString());
            //        lst.SubItems.Add(dt.Rows[x][3].ToString());
            //        lst.SubItems.Add(dt.Rows[x][4].ToString());
            //        lst.SubItems.Add(dt.Rows[x][5].ToString());
            //        lvwTimeSheet.Items.Add(lst);
            //    }
            //}
            DateTime deytFrom;
            DateTime deyTo;

            if (cboDays.SelectedIndex == 0)
            {
                deytFrom = Convert.ToDateTime(cboYear.Text + "-" + (cboMonth.SelectedIndex + 1).ToString("0#") + "-" + "01");
                deyTo = Convert.ToDateTime(cboYear.Text + "-" + (cboMonth.SelectedIndex + 1).ToString("0#") + "-" + "15");
            }
            else
            {
                deytFrom = Convert.ToDateTime(cboYear.Text + "-" + (cboMonth.SelectedIndex + 1).ToString("0#") + "-" + "16");
                deyTo = Convert.ToDateTime(cboYear.Text + "-" + (cboMonth.SelectedIndex + 1).ToString("0#") + "-" + DateTime.DaysInMonth(Convert.ToInt32(cboYear.Text), cboMonth.SelectedIndex + 1));
            }

            dateFromTS = deytFrom;
            dateToTS = deyTo;
            DataTable dtLe = new DataTable();
            MySqlDataAdapter daLe = new MySqlDataAdapter("SELECT DaysWithPay FROM leaves WHERE LeaveFrom <= '" + deyTo.ToString("yyyy-MM-dd") + "' AND LeaveTo>='" + deytFrom.ToString("yyyy-MM-dd") + "' AND empID=" + txtID.Text, msqlcon.con);
            daLe.Fill(dtLe);
            int countLeaveDays=0;
            if (dtLe.Rows.Count > 0)
            {
                countLeaveDays = Convert.ToInt32(dtLe.Rows[0][0].ToString());
            }
            
            for (int x= Convert.ToInt32(deytFrom.Day); x <= Convert.ToInt32(deyTo.Day); x++)
            {
                
                ListViewItem lst = new ListViewItem();
                lst.Text = cboMonth.Text + " " + x + ", " + cboYear.Text;
                DateTime deyt = Convert.ToDateTime(cboYear.Text + "-" + (cboMonth.SelectedIndex + 1).ToString("0#") + "-" + x.ToString("0#"));
                lst.SubItems.Add(deyt.DayOfWeek.ToString());
                
                string dOfWeek = deyt.DayOfWeek.ToString();
                if (dOfWeek == "Saturday" || dOfWeek == "Sunday")
                {
                    lst.SubItems.Add("-");
                    lst.SubItems.Add("-");
                    lst.SubItems.Add("-");
                    lst.SubItems.Add("-");
                    lst.SubItems.Add("Rest Day");
                    arrAttID.Add(0);
                }
                else
                {
                    DataTable dtHol = new DataTable();
                    MySqlDataAdapter daHol = new MySqlDataAdapter("SELECT * FROM holidays WHERE holidaydate='" + deyt.ToString("yyyy-MM-dd") + "'", msqlcon.con);
                    daHol.Fill(dtHol);
                    if (dtHol.Rows.Count > 0)
                    {
                        lst.SubItems.Add("-");
                        lst.SubItems.Add("-");
                        lst.SubItems.Add("-");
                        lst.SubItems.Add("-");
                        lst.SubItems.Add("Holiday");
                        arrAttID.Add(0);
                    }
                    else
                    {
                        DataTable dtL = new DataTable();
                        MySqlDataAdapter daL = new MySqlDataAdapter("SELECT * FROM leaves WHERE LeaveFrom <= '" + deyt.ToString("yyyy-MM-dd") + "' AND LeaveTo>='" + deyt.ToString("yyyy-MM-dd") + "' AND empID=" + txtID.Text, msqlcon.con);
                        daL.Fill(dtL);
                        if (dtL.Rows.Count > 0)
                        {
                            lst.SubItems.Add("-");
                            lst.SubItems.Add("-");
                            lst.SubItems.Add("-");
                            lst.SubItems.Add("-");
                            if (countLeaveDays == 0)
                            {
                                lst.SubItems.Add("Leave");
                            }
                            else
                            {
                                countLeaveDays--;
                                lst.SubItems.Add("Leave with Pay");
                            }
                            
                            //int lwithpaycount = Convert.ToInt32(dtL.Rows[0][5].ToString());

                            
                            arrAttID.Add(0);
                        }
                        else
                        {
                            DataTable dtOB = new DataTable();
                            MySqlDataAdapter daOB = new MySqlDataAdapter("SELECT * FROM officialbusiness WHERE DateFrom <= '" + deyt.ToString("yyyy-MM-dd") + "' AND DateTo >= '" + deyt.ToString("yyyy-MM-dd") + "' and empID=" + txtID.Text, msqlcon.con);
                            daOB.Fill(dtOB);
                            if (dtOB.Rows.Count > 0)
                            {
                                lst.SubItems.Add("-");
                                lst.SubItems.Add("-");
                                lst.SubItems.Add("-");
                                lst.SubItems.Add("-");
                                lst.SubItems.Add("Official Business");
                                arrAttID.Add(0);
                            }
                            else
                            {
                                DataTable dtAtt = new DataTable();
                                MySqlDataAdapter daAtt = new MySqlDataAdapter("SELECT dateIn, Day, TimeIn1, TimeOut1, TimeIn2, TimeOut2, attendanceID FROM attendance WHERE empID=" + txtID.Text + " AND dateIn='" + deyt.ToString("yyyy-MM-dd") + "'", msqlcon.con);
                                daAtt.Fill(dtAtt);
                                if (dtAtt.Rows.Count > 0)
                                {
                                    lst.SubItems.Add(dtAtt.Rows[0][2].ToString());
                                    lst.SubItems.Add(dtAtt.Rows[0][3].ToString());
                                    lst.SubItems.Add(dtAtt.Rows[0][4].ToString());
                                    lst.SubItems.Add(dtAtt.Rows[0][5].ToString());
                                    lst.SubItems.Add("");
                                    arrAttID.Add((int)dtAtt.Rows[0][6]);
                                }
                                else
                                {
                                    lst.SubItems.Add("-");
                                    lst.SubItems.Add("-");
                                    lst.SubItems.Add("-");
                                    lst.SubItems.Add("-");
                                    lst.SubItems.Add("Absent");
                                    arrAttID.Add(0);
                                }
                            }
                        }
                    }
                }
                
                lvwTimeSheet.Items.Add(lst);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int dayo;
            if (cboDays.SelectedIndex == 0)
            {
                dayo = 15;
            }
            else
            {
                dayo = DateTime.DaysInMonth(Convert.ToInt32(cboYear.Text), cboMonth.SelectedIndex + 1);
            }
            if ((Convert.ToDateTime(cboMonth.Text + " " + dayo + ", " + cboYear.Text) > DateTime.Now.Date))
            {
                MessageBox.Show("Cannot Save until Cutoff", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CheckOpen.cons();
                if (MessageBox.Show("Continue to Save and Print?", "Save and Print", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    for (int x = 0; x <= lvwTimeSheet.Items.Count - 1; x++)
                    {
                        string rmk = lvwTimeSheet.Items[x].SubItems[6].Text;
                        string coltime1;
                        string coltime2;
                        string coltime3;
                        string coltime4;
                        string savetime1;
                        string savetime2;
                        string savetime3;
                        string savetime4;
                        //MessageBox.Show(lvwTimeSheet.Items[x].SubItems[1].Text);
                        string checktime1 = lvwTimeSheet.Items[x].SubItems[2].Text;
                        string checktime2 = lvwTimeSheet.Items[x].SubItems[3].Text;
                        string checktime3 = lvwTimeSheet.Items[x].SubItems[4].Text;
                        string checktime4 = lvwTimeSheet.Items[x].SubItems[5].Text;

                        int indicateComp = 0;
                        string querComp = "";
                        int tapCount = 0;
                        int compTime = 0;
                        string querTime = "";

                        if (checktime1 == "-")
                        {
                            coltime1 = "";
                            savetime1 = "";
                        }
                        else
                        {
                            coltime1 = ", TimeIn1";
                            savetime1 = ", '" + Convert.ToDateTime(checktime1).ToString("HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) + "'";
                            indicateComp = 1;
                            tapCount++;
                        }

                        if (checktime2 == "-")
                        {
                            coltime2 = "";
                            savetime2 = "";
                        }
                        else
                        {
                            coltime2 = ", TimeOut1";
                            savetime2 = ", '" + Convert.ToDateTime(checktime2).ToString("HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) + "'";
                            indicateComp = 1;
                            tapCount++;
                        }

                        if (checktime3 == "-")
                        {
                            coltime3 = "";
                            savetime3 = "";
                        }
                        else
                        {
                            coltime3 = ", TimeIn2";
                            savetime3 = ", '" + Convert.ToDateTime(checktime3).ToString("HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) + "'";
                            indicateComp = 1;
                            tapCount++;
                        }

                        if (checktime4 == "-")
                        {
                            coltime4 = "";
                            savetime4 = "";
                        }
                        else
                        {
                            coltime4 = ", TimeOut2";
                            savetime4 = ", '" + Convert.ToDateTime(checktime4).ToString("HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) + "'";
                            indicateComp = 1;
                            tapCount++;
                        }

                        DataTable dtWH = new DataTable();
                        MySqlDataAdapter daWH = new MySqlDataAdapter("SELECT Formula FROM tblformula WHERE FormulaID=3", msqlcon.con);
                        daWH.Fill(dtWH);
                        workHours = Convert.ToInt32(dtWH.Rows[0][0].ToString());


                        if (indicateComp == 1)
                        {
                            querComp = ", ComputedTime";
                            if (tapCount == 1)
                            {
                                //TimeSpan compTimeS = (Convert.ToDateTime(checktime2) - Convert.ToDateTime(checktime1));
                                compTime = 0;
                                querTime = ", " + compTime;
                                rmk = "Absent";
                            }
                            else if (tapCount == 2)
                            {
                                TimeSpan compTimeS = (Convert.ToDateTime(checktime2) - Convert.ToDateTime(checktime1));
                                compTime = Convert.ToInt32(compTimeS.TotalHours);
                                if (compTime > workHours)
                                {
                                    compTime--;
                                }

                                querTime = ", " + compTime;
                            }
                            else if (tapCount == 3)
                            {
                                TimeSpan compTimeS = (Convert.ToDateTime(checktime2).Subtract(Convert.ToDateTime(checktime1)));
                                compTime = Convert.ToInt32(compTimeS.TotalHours);
                                querTime = ", " + compTime;
                            }
                            else if (tapCount == 4)
                            {
                                TimeSpan compTimeS = ((Convert.ToDateTime(checktime2).Subtract(Convert.ToDateTime(checktime1))) + (Convert.ToDateTime(checktime4).Subtract(Convert.ToDateTime(checktime3))));
                                compTime = Convert.ToInt32(compTimeS.TotalHours);
                                querTime = ", " + compTime;
                            }
                            if (compTime >= 10)
                            {
                                rmk = "Overtime for " + (compTime - workHours) + " hr(s)";
                            }

                        }

                        //MessageBox.Show(Convert.ToDateTime(checktime1).ToString("HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
                        //MessageBox.Show("INSERT INTO timesheet(empID, tDate " + coltime1 + "" + coltime2 + "" + coltime3 + "" + coltime4 + ", Remark, DayTime, attendanceID) VALUES(" + txtID.Text + ", '" + Convert.ToDateTime(lvwTimeSheet.Items[x].Text).ToString("yyyy-MM-dd") + "'" + savetime1 + "" + savetime2 + "" + savetime3 + "" + savetime4 + ", '" + lvwTimeSheet.Items[x].SubItems[6].Text + "', '" + lvwTimeSheet.Items[x].SubItems[1].Text + "', " + arrAttID[x] + ")");
                        DataTable dtGetSaved = new DataTable();
                        MySqlDataAdapter daGetSaved = new MySqlDataAdapter("SELECT * FROM timesheet WHERE tDate='" + Convert.ToDateTime(lvwTimeSheet.Items[x].Text).ToString("yyyy-MM-dd") + "' AND empID=" + txtID.Text, msqlcon.con);
                        daGetSaved.Fill(dtGetSaved);
                        if (dtGetSaved.Rows.Count < 1)
                        {

                            MySqlCommand cmd = new MySqlCommand("INSERT INTO timesheet(empID, tDate " + coltime1 + "" + coltime2 + "" + coltime3 + "" + coltime4 + ", Remark, DayName, attendanceID" + querComp + ") VALUES(" + txtID.Text + ",'" + Convert.ToDateTime(lvwTimeSheet.Items[x].Text).ToString("yyyy-MM-dd") + "'" + savetime1 + "" + savetime2 + "" + savetime3 + "" + savetime4 + ", '" + rmk + "', '" + lvwTimeSheet.Items[x].SubItems[1].Text + "', " + arrAttID[x] + "" + querTime + ")", msqlcon.con);
                            cmd.ExecuteNonQuery();


                        }

                    }
                    DataTable getDTTS = new DataTable();
                    MySqlDataAdapter getDATS = new MySqlDataAdapter("SELECT T.tsID, T.empID, T.tDate, Time_Format(T.TimeIn1,'%h %i %p') AS TimeIn1, Time_Format(T.TimeOut1,'%h %i %p') AS TimeOut1, Time_Format(T.TimeIn2,'%h %i %p') AS TimeIn2, Time_Format(T.TimeOut2,'%h %i %p') AS TimeOut2, T.Remark, T.DayName, T.attendanceID, T.computedTime, E.LastName, E.FirstName, E.MiddleInitial FROM timesheet AS T LEFT JOIN emp AS E ON T.empID=E.empID WHERE tDate BETWEEN '" + dateFromTS.ToString("yyyy-MM-dd") + "' AND '" + dateToTS.ToString("yyyy-MM-dd") + "' and T.empID=" + txtID.Text, msqlcon.con);
                    getDATS.Fill(getDTTS);
                    frmTimeSheetReport tsReport = new frmTimeSheetReport();
                    tsReport.WindowState = FormWindowState.Maximized;
                    tsReport.dset.timesheet.Rows.Clear();
                    getDATS.Fill(tsReport.dset.timesheet);
                    tsReport.reportViewer1.ZoomPercent = 100;
                    tsReport.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                    tsReport.reportViewer1.Width = 75;
                    tsReport.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    tsReport.reportViewer1.RefreshReport();
                    tsReport.WindowState = FormWindowState.Maximized;
                    tsReport.ShowDialog();
                }
            }

            
        }
    }
}
