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
    public partial class frmFirstTimeLog : Form
    {
        public frmFirstTimeLog()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == "" || txtRepeat.Text == "")
            {
                MessageBox.Show("Please Provide your new Password", "No Values", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtNewPassword.Text == txtRepeat.Text)
                {
                    if (txtNewPassword.TextLength <= 6)
                    {
                        MessageBox.Show("Password must be more than 6 character", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (MessageBox.Show("Confirm new Password?", "Save Password", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            MySqlCommand cmd = new MySqlCommand("UPDATE user SET Password='" + txtNewPassword.Text.Replace("'","''") + "', FirstTimeLog='NO' WHERE userID=" + StoreData.loggedID, msqlcon.con);
                            cmd.ExecuteNonQuery();
                            txtNewPassword.Text = "";
                            txtRepeat.Text = "";
                            this.Close();
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Your password do not match, Please try again", "Password Unmatched", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
                   
        }
    }
}

