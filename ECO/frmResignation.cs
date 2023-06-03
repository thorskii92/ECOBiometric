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
    public partial class frmResignation : Form
    {
        private frmEmployeeManagement m_Parent;
        public frmResignation(frmEmployeeManagement frm1)
        {
            InitializeComponent();
            m_Parent = frm1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtReason.Text = "";
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (txtReason.Text == "")
            {
                MessageBox.Show("Please enter Reason of Resignation", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Confirm Employee Resignation?", "Confirm Resignation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CheckOpen.cons();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO tblResiglist(empID, ResigDate, Purpose, dateMade, uID) VALUES(@eID, @ResDate, @Ppose, @dMade, @userID)", msqlcon.con);
                    cmd.Parameters.AddWithValue("@eID", txtID.Text);
                    cmd.Parameters.AddWithValue("@ResDate", dtpRes.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Ppose", txtReason.Text);
                    cmd.Parameters.AddWithValue("@dMade", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@userID", StoreData.loggedID);
                    cmd.ExecuteNonQuery();
                    MySqlCommand cmdUp = new MySqlCommand("UPDATE emp SET empStat='Resigned' WHERE empID=" + txtID.Text, msqlcon.con);
                    cmdUp.ExecuteNonQuery();
                    MessageBox.Show("Employee has been resigned","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = "";
                    txtName.Text = "";
                    txtReason.Text = "";
                    m_Parent.loademployees();
                    this.Close();
                }
            }
            
        }
    }
}
