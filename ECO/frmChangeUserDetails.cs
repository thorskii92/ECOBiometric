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
    public partial class frmChangeUserDetails : Form
    {
        private frmUserProfile m_Parent;
        public frmChangeUserDetails(frmUserProfile frm1)
        {
            InitializeComponent();
            m_Parent = frm1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCurPass.Text == "" || txtNewPass.Text == "" || txtRepPass.Text == "" || txtUserName.Text == "")
            {
                MessageBox.Show("Please enter all necessary data", "Missing Values", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                DataTable dtCheckUser = new DataTable();
                MySqlDataAdapter daCU = new MySqlDataAdapter("SELECT * FROM user WHERE username='" + txtUserName.Text.Replace("'","''") + "' AND NOT userID=" + StoreData.loggedID, msqlcon.con);
                daCU.Fill(dtCheckUser);
                if (dtCheckUser.Rows.Count > 0)
                {
                    MessageBox.Show("Username Already Exists, Please try another", "Username Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtNewPass.Text == txtRepPass.Text)
                    {
                        DataTable dtCheck = new DataTable();
                        dtCheck.Clear();
                        MySqlDataAdapter daCheck = new MySqlDataAdapter("SELECT password FROM user WHERE userid=" + StoreData.loggedID, msqlcon.con);
                        daCheck.Fill(dtCheck);
                        if (dtCheck.Rows.Count > 0)
                        {
                            if (txtCurPass.Text == dtCheck.Rows[0][0].ToString())
                            {
                                if (MessageBox.Show("Confirm Changes?", "Apply Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    updateLogDetails(StoreData.loggedID);
                                    txtCurPass.Text = "";
                                    txtNewPass.Text = "";
                                    txtRepPass.Text = "";
                                    txtUserName.Text = "";
                                    MessageBox.Show("Login Details Successfully Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    m_Parent.profileload();
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Password Invalid", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Password did not match", "Password not match", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                
            }
        }

        public void updateLogDetails(int uid)
        {
            CheckOpen.cons();
            MySqlCommand cmd = new MySqlCommand("UPDATE user SET username='" + txtUserName.Text.Replace("'","''") + "', password='" + txtNewPass.Text.Replace("'","''") + "' WHERE userID=" + uid, msqlcon.con);
            cmd.ExecuteNonQuery();
        }

        private void txtNewPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)39)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtRepPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)39)
            {
                e.Handled = true;
                return;
            }
        }
    }
}
