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
    public partial class frmRequestPasswordReset : Form
    {
        public frmRequestPasswordReset()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            CheckOpen.cons();
            DataTable dtC = new DataTable();
            MySqlDataAdapter daC = new MySqlDataAdapter("SELECT username FROM user WHERE username='" + txtUserName.Text.Replace("'","''") + "'", msqlcon.con);
            daC.Fill(dtC);
            if (dtC.Rows.Count > 0)
            {
                if (MessageBox.Show("Confirm Password Reset Request?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE user SET FirstTimeLog='YES', passwordreser='YES' WHERE username='" + txtUserName.Text.Replace("'","''") + "'", msqlcon.con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Password Reset Request Queued", "Password Reset Request Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("User not found, Please try again", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
