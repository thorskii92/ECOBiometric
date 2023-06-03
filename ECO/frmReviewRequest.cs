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
    public partial class frmReviewRequest : Form
    {
        private frmRequests m_Parent;
        private int lID;
        public frmReviewRequest(frmRequests frm1)
        {
            InitializeComponent();
            m_Parent = frm1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void loadRequest(int i)
        {
            CheckOpen.cons();
            DataTable dtL = new DataTable();
            dtL.Clear();
            MySqlDataAdapter daL = new MySqlDataAdapter("SELECT L.LeaveID, E.empID, E.LastName, E.FirstName, E.MiddleInitial, L.LeaveFrom, L.LeaveTo, L.totalDays, L.dayswithpay, L.Purpose, L.RequestStatus, L.LeaveType, L.RequestDate, E.gender  FROM leaves AS L LEFT JOIN emp AS E ON L.empID=E.empID WHERE L.leaveID=" + i, msqlcon.con);
            daL.Fill(dtL);
            if (dtL.Rows.Count > 0)
            {
                lID = i;
                txtID.Text = dtL.Rows[0][1].ToString();
                txtName.Text = dtL.Rows[0][2].ToString() + ", " + dtL.Rows[0][3].ToString() + " " + dtL.Rows[0][4].ToString() + ".";
                txtDateFrom.Text = Convert.ToDateTime(dtL.Rows[0][5]).ToString("MMMM dd, yyyy");
                txtDateTo.Text = Convert.ToDateTime(dtL.Rows[0][6]).ToString("MMMM dd, yyyy");
                txtDaysRequested.Text = dtL.Rows[0][7].ToString();
                txtDaysPay.Text = dtL.Rows[0][8].ToString();
                txtWithoutPay.Text = ((int)dtL.Rows[0][7] - (int)dtL.Rows[0][8]).ToString() ;
                txtPurpose.Text = dtL.Rows[0][9].ToString();
                lblStatus.Text = dtL.Rows[0][10].ToString();
                txtLeaveType.Text = dtL.Rows[0][11].ToString();
                txtReqDate.Text = Convert.ToDateTime(dtL.Rows[0][12]).ToString("MMMM dd, yyyy");
                txtGender.Text = dtL.Rows[0][13].ToString();
                if (lblStatus.Text == "Pending")
                {
                    btnApprove.Visible = true;
                    btnDecline.Visible = true;
                }
                else
                {
                    btnApprove.Visible = false;
                    btnDecline.Visible = false;
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Approval?", "Approve Request", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                CheckOpen.cons();
                MySqlCommand cmd = new MySqlCommand("UPDATE leaves SET RequestStatus='Approved' WHERE leaveID=" + lID, msqlcon.con);
                cmd.ExecuteNonQuery();
                DataTable dtLD = new DataTable();
                int intLtype;
                if (txtLeaveType.Text == "Maternity")
                {
                    intLtype = 2;
                }
                else
                {
                    intLtype = 1;
                }
                MySqlDataAdapter daLD = new MySqlDataAdapter("SELECT usedLID, usedamt FROM usedLeave WHERE empID=" + txtID.Text + " AND year=" + DateTime.Now.Year + " AND leavedayID=" + intLtype, msqlcon.con);
                daLD.Fill(dtLD);
                
                int usedAmt;
                int myAmt = Convert.ToInt32(txtDaysPay.Text);
                int newAmt;
                int uLID;
                
                if (dtLD.Rows.Count > 0)
                {
                    usedAmt = (int)dtLD.Rows[0][1];
                    uLID = (int)dtLD.Rows[0][0];
                    newAmt = usedAmt + myAmt;
                    MySqlCommand cmd1 = new MySqlCommand("UPDATE usedleave SET usedamt=" + newAmt + " WHERE usedLID=" + uLID, msqlcon.con);
                    cmd1.ExecuteNonQuery();
                }
                else
                {
                    newAmt = myAmt;
                    MySqlCommand cmd1 = new MySqlCommand("INSERT usedleave(empID, usedamt, year, leavedayID) VALUES(" + txtID.Text + "," + newAmt + "," + DateTime.Now.Year + "," + intLtype + ")", msqlcon.con);
                    cmd1.ExecuteNonQuery();
                }
                m_Parent.loadlist();
                MessageBox.Show("Request has been approved", "Request Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
