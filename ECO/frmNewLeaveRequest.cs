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
    public partial class frmNewLeaveRequest : Form
    {
        public List<int> leaveEmpID;
        public List<string> leaveGender;
        public int dayswithpay;
        public int dayswithoutpay;
        int mLeaveDaysSelected;
        int PLeaveDaysSelected;
        private frmLeaveRequest m_Parent;
        public frmNewLeaveRequest(frmLeaveRequest frm1)
        {
            InitializeComponent();
            m_Parent = frm1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboLeaveType.Text == "" || cboNames.Text == "" || txtDaysRequested.Text == "" || txtDaysWithPay.Text == "" || txtLwithPay.Text == "" || txtPurpose.Text == "" || txtWithoutPay.Text == "")
            {
                MessageBox.Show("Please enter Values", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                DataTable dtPending = new DataTable();
                dtPending.Clear();
                MySqlDataAdapter daPend = new MySqlDataAdapter("SELECT * FROM leaves WHERE empID=" + txtID.Text + " AND RequestStatus='Pending'", msqlcon.con);
                daPend.Fill(dtPending);
                if (dtPending.Rows.Count > 0)
                {
                    MessageBox.Show("Employee already has a pending request for leave, Please Settle Leave first", "Pending Leave Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DataTable checkOverlap = new DataTable();
                    MySqlDataAdapter daOverlap = new MySqlDataAdapter("SELECT LeaveFrom, LeaveTo FROM leaves WHERE empID=" + txtID.Text, msqlcon.con);
                    daOverlap.Fill(checkOverlap);

                    if (checkOverlap.Rows.Count > 0)
                    {
                        int indicate;
                        indicate = 0;
                        for (int x = 0; x <= checkOverlap.Rows.Count - 1; x++)
                        {
                            DateTime dbFrom = Convert.ToDateTime(checkOverlap.Rows[x][0]);
                            dbFrom.ToShortDateString();
                            DateTime dbTo = Convert.ToDateTime(checkOverlap.Rows[x][1]);
                            dbTo.ToShortDateString();
                            DateTime dtFrom = dtpFrom.Value.Date;
                            dtFrom.ToShortDateString();
                            DateTime dtTo = dtpTo.Value.Date;
                            dtTo.ToShortDateString();
                            //MessageBox.Show(dbFrom.ToString() + ", " + dbTo.ToString() + ", " + dtFrom.ToString() + ", " + dtTo.ToString());
                            bool overlap = (dtFrom <= dbTo && dbFrom <= dtTo);
                            if (overlap == true)
                            {
                                indicate = 1;
                                break;
                            }
                        }
                        if (indicate == 1)
                        {
                            MessageBox.Show("Dates are overlapping", "Please try another date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            SaveMe();
                        }

                    }
                    else
                    {
                        SaveMe();
                    }

                }
            }
        }

        public void SaveMe()
        {
            if (MessageBox.Show("Submit Request for Leave?", "Leave Request", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                CheckOpen.cons();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO leaves(empID, LeaveFrom, LeaveTo, totalDays, DaysWithPay, Purpose, uID, RequestStatus, LeaveType, requestdate) VALUES(@eID, @LFrom, @LTo, @totDays, @DPay, @Purp, @userID, 'Pending', @LType, @reqdate)", msqlcon.con);
                cmd.Parameters.AddWithValue("@eID", txtID.Text);
                cmd.Parameters.AddWithValue("@LFrom", dtpFrom.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@LTo", dtpTo.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@totDays", txtDaysRequested.Text);
                cmd.Parameters.AddWithValue("@DPay", txtDaysWithPay.Text);
                cmd.Parameters.AddWithValue("@Purp", txtPurpose.Text);
                cmd.Parameters.AddWithValue("@userID", StoreData.loggedID);
                cmd.Parameters.AddWithValue("@LType", cboLeaveType.Text);
                cmd.Parameters.AddWithValue("@reqdate", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                m_Parent.loadleaverequest();
                this.Close();
            }
        }
        public void LoadEmployees()
        {
            CheckOpen.cons();
            DataTable dtEmps = new DataTable();
            MySqlDataAdapter daEmps = new MySqlDataAdapter("SELECT empID, LastName, FirstName, MiddleInitial, Gender FROM emp WHERE empStat='Employed' AND contractType='Regular'", msqlcon.con);
            daEmps.Fill(dtEmps);
            cboNames.Items.Clear();
            cboLeaveType.Items.Clear();
            leaveEmpID = new List<int>();
            leaveGender = new List<string>();
            leaveEmpID.Clear();
            leaveGender.Clear();
            if (dtEmps.Rows.Count > 0)
            {
                for (int x=0; x <= dtEmps.Rows.Count - 1; x++)
                {
                    leaveEmpID.Add((int)dtEmps.Rows[x][0]);
                    leaveGender.Add(dtEmps.Rows[x][4].ToString());
                    cboNames.Items.Add(dtEmps.Rows[x][1].ToString() + ", " + dtEmps.Rows[x][2].ToString() + " " + dtEmps.Rows[x][3].ToString() + ".");
                }
                
            }

        }

        private void frmNewLeaveRequest_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void cboNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNames.SelectedIndex > -1 || cboNames.Text != "")
            {
                txtID.Text = leaveEmpID[cboNames.SelectedIndex].ToString();
                txtGender.Text = leaveGender[cboNames.SelectedIndex];
                cboLeaveType.Items.Clear();
                cboLeaveType.Items.Add("Sick Leave/Vacation Leave");
                if (txtGender.Text == "FEMALE")
                {
                    cboLeaveType.Items.Add("Maternity Leave");
                }
                else
                {
                    cboLeaveType.Items.Add("Paternity Leave");
                }
            }

            
        }

        private void cboLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLeaveType.SelectedIndex > -1)
            {
                if (cboLeaveType.Text == "Sick Leave/Vacation Leave")
                {
                    dtpFrom.Enabled = true;
                    dtpTo.Enabled = true;
                    dtpFrom.Value = DateTime.Now;
                }
                else if (cboLeaveType.Text == "Maternity Leave")
                {
                    dtpFrom.Enabled = true;
                    dtpTo.Enabled = false;
                    dtpFrom.Value = DateTime.Now;
                }
                else if (cboLeaveType.Text == "Paternity Leave")
                {
                    dtpFrom.Enabled = true;
                    dtpTo.Enabled = false;
                    dtpFrom.Value = DateTime.Now;
                }
                    txtDaysRequested.Text = getdays(dtpFrom.Value, dtpTo.Value).ToString();
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                cboLwithPay.Enabled = false;
                txtDaysRequested.Text = "";
                txtDaysWithPay.Text = "";
                txtLwithPay.Text = "";
                txtWithoutPay.Text = "";
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            computevalues();
            if (cboLeaveType.Text == "Sick Leave/Vacation Leave")
            {
                dtpTo.Value = dtpFrom.Value.AddDays(2);
            }
        }

        public void computevalues()
        {
            cboLwithPay.Items.Clear();
            txtDaysRequested.Text = "";
            txtDaysWithPay.Text = "";
            txtLwithPay.Text = "";
            txtPurpose.Text = "";
            txtWithoutPay.Text = "";
            cboLwithPay.Items.Clear();
            
            txtDaysRequested.Text = getdays(dtpFrom.Value, dtpTo.Value).ToString();
            if (cboLeaveType.Text == "Maternity Leave")
            {
                
                //bool overlap = dtpFrom.Value < 
                
                cboLwithPay.Items.Clear();
                CheckOpen.cons();
                DataTable dtGetMar = new DataTable();
                dtGetMar.Clear();
                MySqlDataAdapter daMar = new MySqlDataAdapter("SELECT totaldays FROM leavedays WHERE leavedayID=2", msqlcon.con);
                daMar.Fill(dtGetMar);
                int marleavedays = (int)dtGetMar.Rows[0][0];
                mLeaveDaysSelected = marleavedays;
                dtpTo.Value = dtpFrom.Value.AddDays(marleavedays - 1);
                cboLwithPay.Items.Clear();
                for (int x = 1; x <= marleavedays; x++)
                {
                    cboLwithPay.Items.Add(x);
                }
                txtLwithPay.Text = marleavedays.ToString();
                cboLwithPay.Text = marleavedays.ToString();
            }
            else if (cboLeaveType.Text == "Paternity Leave")
            {
                cboLwithPay.Items.Clear();
                CheckOpen.cons();
                DataTable dtGetPar = new DataTable();
                dtGetPar.Clear();
                MySqlDataAdapter daPar = new MySqlDataAdapter("SELECT totaldays FROM leavedays WHERE leavedayID=3", msqlcon.con);
                daPar.Fill(dtGetPar);
                int parleavedays = (int)dtGetPar.Rows[0][0];
                PLeaveDaysSelected = parleavedays;
                dtpTo.Value = dtpFrom.Value.AddDays(parleavedays - 1);
                cboLwithPay.Items.Clear();
                for (int x = 1; x <= parleavedays; x++)
                {
                    cboLwithPay.Items.Add(x);
                }
                txtLwithPay.Text = parleavedays.ToString();
                cboLwithPay.Text = parleavedays.ToString();
            }
            else if (cboLeaveType.Text == "Sick Leave/Vacation Leave")
            {
                CheckOpen.cons();
                cboLwithPay.Enabled = true;
                cboLwithPay.Items.Clear();
                DataTable dtGetSV = new DataTable();
                MySqlDataAdapter daSV = new MySqlDataAdapter("SELECT totaldays FROM leavedays WHERE leavedayID=1", msqlcon.con);
                daSV.Fill(dtGetSV);
                int LDays = (int)dtGetSV.Rows[0][0];
                dtGetSV.Clear();
                dtGetSV.Rows.Clear();
                int LPerMonth = (LDays / 12);
                int CurLMonth = (LPerMonth * (Convert.ToInt16(DateTime.Now.Month.ToString("00"))));
                DataTable dtUDays = new DataTable();
                MySqlDataAdapter daGetUsedDays = new MySqlDataAdapter("SELECT usedamt FROM usedleave WHERE empID=" + leaveEmpID[cboNames.SelectedIndex] + " and year=" + DateTime.Now.Year + " and leavedayID=1", msqlcon.con);
                daGetUsedDays.Fill(dtUDays);
                int AvaLeaveDays;
                if (dtUDays.Rows.Count > 0)
                {
                    //MessageBox.Show(dtUDays.Rows[0][0].ToString());
                    AvaLeaveDays = (CurLMonth - ((int)dtUDays.Rows[0][0]));
                }
                else
                {
                    AvaLeaveDays = CurLMonth;
                }
                cboLwithPay.Items.Clear();
                for (int x = 0; x <= AvaLeaveDays; x++)
                {
                    if (x <= Convert.ToInt32(txtDaysRequested.Text))
                    {
                        cboLwithPay.Items.Add(x);
                    }
                }
                txtLwithPay.Text = AvaLeaveDays.ToString();
                
            }
            txtDaysRequested.Text = getdays(dtpFrom.Value, dtpTo.Value).ToString();
            try
            {
                if (cboLeaveType.Text == "Maternity Leave")
                {
                    cboLwithPay.SelectedIndex = mLeaveDaysSelected - 1;
                    cboLwithPay.Enabled = false;
                }
                else if (cboLeaveType.Text == "Paternity Leave")
                {
                    cboLwithPay.SelectedIndex = PLeaveDaysSelected - 1;
                    cboLwithPay.Enabled = false;
                }
                else
                {
                    cboLwithPay.SelectedIndex = 0;
                }
                compdays(Convert.ToInt32(txtDaysRequested.Text), Convert.ToInt32(txtLwithPay.Text), Convert.ToInt32(cboLwithPay.Text));
                txtDaysWithPay.Text = cboLwithPay.Text;
                txtWithoutPay.Text = (Convert.ToInt32(txtDaysRequested.Text) - Convert.ToInt32(cboLwithPay.Text)).ToString();
            }
            catch
            {

            }
            
        }

        public int getdays(DateTime dFrom, DateTime dTo)
        {
            int computedays = Convert.ToInt32((dTo - dFrom).TotalDays) + 1;
            return computedays;
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            computevalues();
        }

        public void compdays(int reqdays, int avadays, int usedavadays)
        {
            dayswithpay = reqdays - dayswithpay;
            dayswithoutpay =  avadays - usedavadays;
        }

        private void cboLwithPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            txtDaysWithPay.Text = cboLwithPay.Text;
            txtWithoutPay.Text = (Convert.ToInt32(txtDaysRequested.Text) - Convert.ToInt32(cboLwithPay.Text)).ToString();
        }
    }
}
