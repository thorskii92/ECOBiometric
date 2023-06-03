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
    public partial class frmUserAccounts : Form
    {
        private frmCreateUser _CreateUser;
        public List<string> uActive;
        public List<string> uReset;
        public frmUserAccounts()
        {
            InitializeComponent();
            _CreateUser = new frmCreateUser(this);
        }
        public frmEnterYourPassword _EntPass;
        private void frmUserAccounts_Load(object sender, EventArgs e)
        {
            loadusers();
           enabler();
            _EntPass = new frmEnterYourPassword(this);
        }

        public void loadusers()
        {
            CheckOpen.cons();
            DataTable dtUsers = new DataTable();
            dtUsers.Clear();
            MySqlDataAdapter daUsers = new MySqlDataAdapter("SELECT UserID, FullName, UserType, userStatus, passwordreset FROM user", msqlcon.con);
            daUsers.Fill(dtUsers);
            lvwUser.Items.Clear();
            StoreData.HoldUserIDArr = new List<int>();
            StoreData.HoldUserIDArr.Clear();
            
            if (dtUsers.Rows.Count > 0)
            {
                uActive = new List<string>();
                uReset = new List<string>();
                uActive.Clear();
                uReset.Clear();
                int x=0;
                for (x=0; x <= dtUsers.Rows.Count - 1; x++)
                {
                    StoreData.HoldUserIDArr.Add((int)dtUsers.Rows[x][0]);
                    ListViewItem lst = new ListViewItem();
                    lst.Text = dtUsers.Rows[x][1].ToString();
                    lst.SubItems.Add(dtUsers.Rows[x][3].ToString());
                    uActive.Add(dtUsers.Rows[x][3].ToString());
                    DataTable dtLog = new DataTable();
                    MySqlDataAdapter daLog = new MySqlDataAdapter("SELECT * FROM userlog WHERE uLogID=(SELECT max(uLogID) FROM userlog WHERE uID=" + StoreData.HoldUserIDArr[x] + ")", msqlcon.con);
                    daLog.Fill(dtLog);
                    if (dtLog.Rows.Count > 0)
                    {
                        lst.SubItems.Add(Convert.ToDateTime(dtLog.Rows[0][2]).ToString("MMMM dd, yyyy") + " " + dtLog.Rows[0][3].ToString());
                        lst.SubItems.Add(dtLog.Rows[0][4].ToString());
                    }
                    else
                    {
                        lst.SubItems.Add("");
                        lst.SubItems.Add("");
                    }
                    lst.SubItems.Add(dtUsers.Rows[x][4].ToString());
                    uReset.Add(dtUsers.Rows[x][4].ToString());
                    dtLog.Clear();
                    lvwUser.Items.Add(lst);
                }
            }
        }

        private void lvwUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            enabler();
        }

        public void enabler()
        {
            if (lvwUser.SelectedItems.Count > 0)    
            {
                if (uActive[lvwUser.FocusedItem.Index] == "Active")
                {
                    btnEnableDisableUser.Text = "Disable User";
                }
                else
                {
                    btnEnableDisableUser.Text = "Enable User";
                }
                
                if (StoreData.HoldUserIDArr[lvwUser.FocusedItem.Index] == 1)
                {
                    btnEnableDisableUser.Visible = false;
                }
                else
                {
                    btnEnableDisableUser.Visible = true;
                }

                if (uReset[lvwUser.FocusedItem.Index] == "YES")
                {
                    btnConfirm.Visible = true;
                    btnDecline.Visible = true;
                }
                else
                {
                    btnConfirm.Visible = false;
                    btnDecline.Visible = false;
                }
                

                
                btnViewLogs.Visible = true;
            }
            else
            {
                btnEnableDisableUser.Visible = false;
                btnViewLogs.Visible = false;
            }
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            //frmCreateUser CreateUser = new frmCreateUser();
            _CreateUser.txtName.Text = "";
            _CreateUser.txtUsername.Text = "";
            _CreateUser.StartPosition = FormStartPosition.CenterScreen;
            _CreateUser.ShowDialog();
        }

        private void btnEnableDisableUser_Click(object sender, EventArgs e)
        {
            if (lvwUser.SelectedItems.Count > 0)
            {
                if (btnEnableDisableUser.Text == "Enable User")
                {
                    if (MessageBox.Show("Enable Selected User?", "Enable User", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        changeActiveUser("Active");
                        MessageBox.Show("User has been Enabled", "User Enabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadusers();
                    }
                }
                else
                {
                    if (MessageBox.Show("Disable Selected User?", "Disable User", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        changeActiveUser("Disabled");
                        MessageBox.Show("User has been Disabled", "User Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadusers();
                    }
                }
            }
            
        }

        public void changeActiveUser(string status)
        {
            CheckOpen.cons();
            MySqlCommand cmd = new MySqlCommand("UPDATE user SET userStatus='" + status + "' WHERE userID=" + StoreData.HoldUserIDArr[lvwUser.FocusedItem.Index], msqlcon.con);
            cmd.ExecuteNonQuery();
        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            if (lvwUser.SelectedItems.Count > 0)
            {
                frmUserLogHistory loghistory = new frmUserLogHistory();
                loghistory.logload(StoreData.HoldUserIDArr[lvwUser.FocusedItem.Index]);
                loghistory.StartPosition = FormStartPosition.CenterParent;
                loghistory.ShowDialog();
            }
        }

        private void lvwUser_DoubleClick(object sender, EventArgs e)
        {
            if (lvwUser.SelectedItems.Count > 0)
            {
                frmUserLogHistory loghistory = new frmUserLogHistory();
                loghistory.logload(StoreData.HoldUserIDArr[lvwUser.FocusedItem.Index]);
                loghistory.StartPosition = FormStartPosition.CenterParent;
                loghistory.ShowDialog();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //frmEnterYourPassword _EnterPass = new frmEnterYourPassword();
            StoreData.WhatToOpenIndex = 1;
            StoreData.SelectedUserID = StoreData.HoldUserIDArr[lvwUser.FocusedItem.Index];
            StoreData.HoldName = lvwUser.FocusedItem.Text;
            _EntPass.StartPosition = FormStartPosition.CenterScreen;
            _EntPass.ShowDialog();
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            StoreData.WhatToOpenIndex = 2;
            StoreData.SelectedUserID = StoreData.HoldUserIDArr[lvwUser.FocusedItem.Index];
            StoreData.HoldName = lvwUser.FocusedItem.Text;
            _EntPass.StartPosition = FormStartPosition.CenterScreen;
            _EntPass.ShowDialog();
        }
    }
}
