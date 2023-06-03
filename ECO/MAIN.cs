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
    public partial class frmMAIN : Form
    {
        public frmMAIN()
        {
            InitializeComponent();
            Initialize();
        }

        public MySqlConnection connection;
        public string server, database, uid, password, timeNow, dateNow, temp;
        public int second = 0;

        public void Initialize()
        {
            CheckOpen.cons();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            closeforms();
            resetcolors();
            btnBiometrics.BackColor = Color.LightGreen;

            frmBiometric bio = new frmBiometric();
            bio.WindowState = FormWindowState.Maximized;
            bio.MdiParent = this;
            bio.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            closeforms();
            resetcolors();
            btnManageEmp.BackColor = Color.LightGreen;
            frmEmployeeManagement frmEmpMan = new frmEmployeeManagement();
            frmEmpMan.MdiParent = this;
            frmEmpMan.WindowState = FormWindowState.Maximized;
            frmEmpMan.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            closeforms();
            resetcolors();
            btnPayroll.BackColor = Color.LightGreen;
            frmNewPayroll frmProll = new frmNewPayroll();
            frmProll.MdiParent = this;
            frmProll.WindowState = FormWindowState.Maximized;
            frmProll.Show();  
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            closeforms();
            resetcolors();
            btnCheckReq.BackColor = Color.LightGreen;
            frmRequests reqs = new frmRequests();
            reqs.MdiParent = this;
            reqs.WindowState = FormWindowState.Maximized;
            reqs.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            closeforms();
            resetcolors();
            btnUserAccounts.BackColor = Color.LightGreen;
            frmUserAccounts uAcc = new frmUserAccounts();
            uAcc.MdiParent = this;
            uAcc.WindowState = FormWindowState.Maximized;
            uAcc.Show();
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UserOut()
        {

            string query = ("UPDATE logs SET TimeOut = '" + DateTime.Now.ToString("h:mm:ss tt") + "' WHERE LogID = '" + temp + "'");

            CheckOpen.cons();
            {
                MySqlCommand cmd = new MySqlCommand(query, msqlcon.con);
                cmd.ExecuteNonQuery();
                CheckOpen.conx();
            }
        }

        private void tspAdmin_Click(object sender, EventArgs e)
        {
            frmAdminSettings adset = new frmAdminSettings();
            adset.StartPosition = FormStartPosition.CenterScreen;
            adset.ShowDialog();
        }

        private void frmMAIN_Load(object sender, EventArgs e)
        {
            CheckOpen.cons();
            checkFirstTime(StoreData.loggedID);
            temp = StoreData.HoldID;
            resetcolors();

            //RESTRICTIONS
            //hidebuttons();
            //if (StoreData.HoldUserType == "IT Support")
            //{
            //    btnAttendance.Visible = true;
            //    btnBiometrics.Visible = true;
            //    btnLeaveRequest.Visible = true;
            //}
            //else if (StoreData.HoldUserType == "Human Resource")
            //{
            //    btnManageEmp.Visible = true;
            //    btnPayroll.Visible = true;
            //    btnCheckReq.Visible = true;
            //}
            //else if (StoreData.HoldUserType == "Administrator")
            //{
            //    tspAdmin.Visible = true;
            //    btnUserAccounts.Visible = true;
            //}
            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
        }

        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserProfile uProf = new frmUserProfile();
            
            uProf.StartPosition = FormStartPosition.CenterScreen;
            uProf.ShowDialog(); 
        }

        private void btnLeaveRequest_Click(object sender, EventArgs e)
        {
            closeforms();
            resetcolors();
            btnLeaveRequest.BackColor = Color.LightGreen;
            frmLeaveRequest LRequest = new frmLeaveRequest();
            LRequest.MdiParent = this;
            LRequest.WindowState = FormWindowState.Maximized;
            LRequest.Show();
        }

        private void frmMAIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Logoff?", "Logoff", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
           {
               e.Cancel = false;
               resetcolors();
               UserOut();
               UserLogger.LogUser(StoreData.loggedID, "Logout");
               frmLogin lo = new frmLogin();
               lo.Show();
           }
           else
           {
               e.Cancel = true;
           }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            closeforms();
            resetcolors();
            frmAttendance emp = new frmAttendance();
            btnAttendance.BackColor = Color.LightGreen;
            emp.MdiParent = this;
            emp.WindowState = FormWindowState.Maximized;
            //emp.WindowState = FormWindowState.Maximized;
            emp.Show();
        }
        
        public void closeforms()
        {
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
            }
        }

        public void resetcolors()
        {
            btnAttendance.BackColor = Color.Green;
            btnBiometrics.BackColor = Color.Green;
            btnCheckReq.BackColor = Color.Green;
            btnManageEmp.BackColor = Color.Green;
            btnPayroll.BackColor = Color.Green;
            btnUserAccounts.BackColor = Color.Green;
            btnLeaveRequest.BackColor = Color.Green;
        }

        public void hidebuttons()
        {
            btnAttendance.Visible = false;
            btnBiometrics.Visible = false;
            btnCheckReq.Visible = false;
            btnManageEmp.Visible = false;
            btnPayroll.Visible = false;
            btnUserAccounts.Visible = false;
            tspAdmin.Visible = false;
            btnLeaveRequest.Visible = false;
        }

        public void checkFirstTime(int uID)
        {
            CheckOpen.cons();
            DataTable dtFT = new DataTable();
            dtFT.Clear();
            MySqlDataAdapter daFT = new MySqlDataAdapter("SELECT FirstTimeLog FROM user WHERE userID=" + uID, msqlcon.con);
            daFT.Fill(dtFT);
            if (dtFT.Rows.Count > 0)
            {
                string checkMe = dtFT.Rows[0][0].ToString();
                if (checkMe == "YES")
                {
                    frmFirstTimeLog ftLog = new frmFirstTimeLog();
                    ftLog.txtNewPassword.Text = "";
                    ftLog.txtRepeat.Text = "";
                    ftLog.StartPosition = FormStartPosition.CenterScreen;
                    ftLog.ShowDialog();
                }
            }
        }
    }
}
