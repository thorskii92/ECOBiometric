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
    public partial class frmLeaveRequest : Form
    {
        private frmNewLeaveRequest _LReq;
        List<int> arrLeaveID;
        public frmLeaveRequest()
        {
            InitializeComponent();
            _LReq = new frmNewLeaveRequest(this);
        }

        private void frmLeaveRequest_Load(object sender, EventArgs e)
        {
            cboFilter.SelectedIndex = 0;
            loadleaverequest();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            //frmLeaveRequest _LReq = new frmLeaveRequest();
            _LReq.StartPosition = FormStartPosition.CenterScreen;
            _LReq.cboNames.Text = "";
            _LReq.cboNames.Items.Clear();
            _LReq.LoadEmployees();
            _LReq.ShowDialog();
        }

        public void loadleaverequest()
        {
            CheckOpen.cons();
            arrLeaveID = new List<int>();
            arrLeaveID.Clear();
            DataTable dtL = new DataTable();
            dtL.Clear();
            MySqlDataAdapter daL = new MySqlDataAdapter("SELECT L.leaveID, E.empID, E.LastName, E.FirstName, E.MiddleInitial, L.LeaveFrom, L.LeaveTo, L.totalDays, L.DaysWithPay, L.RequestStatus, L.LeaveType, U.FullName, L.requestdate FROM leaves AS L LEFT JOIN emp AS E ON L.empID=E.empID LEFT JOIN user AS U ON L.uID=U.userID", msqlcon.con);
            daL.Fill(dtL);
            lvwLeaveRequest.Items.Clear();
            if (dtL.Rows.Count > 0)
            {
                for (int x=0; x <=dtL.Rows.Count - 1; x++)
                {
                    arrLeaveID.Add((int)dtL.Rows[x][0]);
                    ListViewItem lst = new ListViewItem();
                    lst.Text = dtL.Rows[x][2].ToString() + ", " + dtL.Rows[x][3].ToString() + " " + dtL.Rows[x][4].ToString() + "." ;
                    lst.SubItems.Add(Convert.ToDateTime(dtL.Rows[x][5]).ToString("MMMM dd, yyyy"));
                    lst.SubItems.Add(Convert.ToDateTime(dtL.Rows[x][6]).ToString("MMMM dd, yyyy"));
                    lst.SubItems.Add(dtL.Rows[x][7].ToString());
                    lst.SubItems.Add(dtL.Rows[x][8].ToString());
                    lst.SubItems.Add(dtL.Rows[x][9].ToString());
                    lst.SubItems.Add(Convert.ToDateTime(dtL.Rows[x][12]).ToString("MMMM dd, yyyy"));
                    lvwLeaveRequest.Items.Add(lst);
                }
            }
            //btnModify.Visible = false;
            btnWithdraw.Visible = false;
        }

        private void lvwLeaveRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwLeaveRequest.SelectedItems.Count > 0)
            {
                CheckOpen.cons();
                DataTable dtLC = new DataTable();
                dtLC.Clear();
                MySqlDataAdapter daLC = new MySqlDataAdapter("SELECT RequestStatus FROM leaves WHERE leaveID=" + arrLeaveID[lvwLeaveRequest.FocusedItem.Index] + " AND RequestStatus='Pending'", msqlcon.con);
                daLC.Fill(dtLC);
                if (dtLC.Rows.Count>0)
                {
                    //btnModify.Visible = true;
                    btnWithdraw.Visible = true;
                }
                else
                {
                    //btnModify.Visible = false;
                    btnWithdraw.Visible = false;
                }
            }
            else
            {
                //btnModify.Visible = false;
                btnWithdraw.Visible = false;
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel Request?", "Cancel Request", MessageBoxButtons.YesNo, MessageBoxIcon.Information)== DialogResult.Yes)
            {
                CheckOpen.cons();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM leaves WHERE leaveID=" + arrLeaveID[lvwLeaveRequest.FocusedItem.Index], msqlcon.con);
                cmd.ExecuteNonQuery();
                loadleaverequest();
                MessageBox.Show("Leave has been cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }
    }
}
