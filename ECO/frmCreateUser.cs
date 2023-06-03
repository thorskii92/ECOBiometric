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
    public partial class frmCreateUser : Form
    {
        private frmUserAccounts m_Parent;
        public frmCreateUser(frmUserAccounts frm1)
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
            if (txtName.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Please fill all neccessary Information", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            { 
                if (MessageBox.Show("Save New User", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CheckOpen.cons();

                    DataTable dtC = new DataTable();
                    MySqlDataAdapter daC = new MySqlDataAdapter("SELECT * FROM user WHERE username='" + txtUsername.Text.Replace("'", "''") + "'", msqlcon.con);
                    daC.Fill(dtC);
                    if (dtC.Rows.Count > 0)
                    {
                        MessageBox.Show("Username already exists, Please try another.", "Username Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO user(Username, Password, UserType, FullName, FirstTimeLog, userStatus, passwordReser) VALUES('" + txtUsername.Text.Replace("'", "''") + "','ecosolutions','" + cboUsertype.Text + "','" + txtName.Text.Replace("'", "''") + "','YES','Active','NO')", msqlcon.con);
                        cmd.ExecuteNonQuery();
                        txtName.Text = "";
                        txtUsername.Text = "";
                        m_Parent.loadusers();
                        MessageBox.Show("Saved!", "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
            }
        }

        private void frmCreateUser_Load(object sender, EventArgs e)
        {

        }
    }
}
