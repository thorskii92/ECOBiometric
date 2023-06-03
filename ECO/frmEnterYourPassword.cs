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
    public partial class frmEnterYourPassword : Form
    {
        private frmUserAccounts m_Parent;
        public frmEnterYourPassword(frmUserAccounts frm1)
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
            CheckOpen.cons();
            DataTable dtP = new DataTable();
            MySqlDataAdapter daP = new MySqlDataAdapter("SELECT * FROM user WHERE Password='" + txtPassword.Text.Replace("'","''") + "' AND userID=" + StoreData.loggedID, msqlcon.con);
            daP.Fill(dtP);
            if (dtP.Rows.Count > 0)
            {
                WhatToOpen(StoreData.WhatToOpenIndex);
            }
            else
            {
                MessageBox.Show("Wrong Password, Please try again", "Wrong Passsword", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void WhatToOpen(int index)
        {
            if (index == 1)
            {
                if (MessageBox.Show("Confirm Reset to User: " + StoreData.HoldName, "Reset Password", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CheckOpen.cons();
                    MySqlCommand cmd = new MySqlCommand("UPDATE user SET Password='ecosolutions', passwordReser='NO' WHERE userID=" + StoreData.SelectedUserID, msqlcon.con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User: ''" + StoreData.HoldName + "'' password has been Resetted to 'ecosolutions'", "Password Reset Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_Parent.loadusers();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else if (index == 2)
            {
                if (MessageBox.Show("","", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CheckOpen.cons();
                    MySqlCommand cmd = new MySqlCommand("UPDATE user SET passwordreser='NO' WHERE userID=" + StoreData.SelectedUserID, msqlcon.con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Password Reset request has been declined for user: ''" + StoreData.HoldName + "''", "Password Reset Declined", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_Parent.loadusers();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
