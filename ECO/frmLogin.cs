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
using System.Threading;

namespace ECO
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        public MySqlConnection connection;
        public string server, database, uid, password, timeNow, timeOut, dateNow, value, utype;
        public int userID;
        public int second = 0;
        public int attempts = 1;
        public void Initialize()
        {
            CheckOpen.cons();
        }

        public void UserLog()
        {
            string query = ("INSERT INTO logs (Name, Date, TimeIn, UserID) VALUES ('" + txtUser.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "', '" + DateTime.Now.ToString("hh:mm tt") + "', '" + userID + "')");
            CheckOpen.cons();
                MySqlCommand cmd = new MySqlCommand(query, msqlcon.con);
                cmd.ExecuteNonQuery();
                CheckOpen.conx();
        }
        public frmLogin()
        {
            InitializeComponent();
            Initialize();
            CheckOpen.cons();
            //RetrieveID();
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            frmRequestPasswordReset ResPass = new frmRequestPasswordReset();
            ResPass.StartPosition = FormStartPosition.CenterScreen;
            ResPass.ShowDialog();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)39)
            {
                e.Handled = true;
                return;
            }
            //MessageBox.Show(((char)e.KeyChar).ToString());
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //timeLogin.Start();
            txtUser.Focus();
            dateNow = DateTime.Now.ToString("yyyy/MM/dd");
            // value = lblID_IN.Text;
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                lblTip.Visible = true;
                lblTip.Text = "Invalid username/password.";
                txtUser.Focus();
                txtUser.SelectAll();
                attempts++;
                if (attempts == 4)
                {
                    MessageBox.Show("You have attempted multiple invalid logins.\nThe application will now close.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Environment.Exit(0);
                }
            }
            else
            {
                CheckOpen.cons();
                string _Quer = "SELECT UserID, FullName, UserType, userStatus FROM user WHERE Username='" + txtUser.Text.Replace("'or'1'='1", "").Replace("'","''") + "' AND Password='" + txtPass.Text.Replace("'or'1'='1", "").Replace("'", "''") + "'";
                MySqlDataAdapter daLog = new MySqlDataAdapter(_Quer, msqlcon.con);
                DataTable dtLog = new DataTable();
                daLog.Fill(dtLog);
                if (dtLog.Rows.Count > 0)
                {
                    string checkStat = dtLog.Rows[0][3].ToString();
                    if (checkStat == "Active")
                    {
                        Object dRow = dtLog.Rows[0][0];
                        StoreData.HoldID = dtLog.Rows[0][0].ToString();
                        StoreData.loggedID = (int)dtLog.Rows[0][0];
                        userID = (int)dtLog.Rows[0][0];
                        utype = dtLog.Rows[0][2].ToString();
                        frmMAIN mainf = new frmMAIN();
                        UserLogger.LogUser(StoreData.loggedID, "Login");
                        StoreData.HoldUserType = utype;
                        mainf.stpLogged.Text = "Logged User: " + dtLog.Rows[0][1].ToString();
                        mainf.Show();
                        //UserLog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("User is Inactive", "User Disabled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    lblTip.Visible = true;
                    lblTip.Text = "Invalid username/password/user type.";
                    txtUser.Focus();
                    attempts++;
                }
            }

            if (attempts == 4)
            {
                MessageBox.Show("You have attempted multiple invalid logins.\nThe application will now close.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }   
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked == true)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Do you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
            }
        }

    }
}
