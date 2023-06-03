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
    public partial class frmLeaveDaysSettings : Form
    {
        public frmLeaveDaysSettings()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save values?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                CheckOpen.cons();
                MySqlCommand cmd = new MySqlCommand("UPDATE leavedays SET totaldays=" + txtLeavePerYear.Text + " WHERE leavedayID=1", msqlcon.con);
                cmd.ExecuteNonQuery();
                MySqlCommand cmdM = new MySqlCommand("UPDATE leavedays SET totaldays=" + txtMaternityLeave.Text + " WHERE leavedayID=2", msqlcon.con);
                cmdM.ExecuteNonQuery();
                MySqlCommand cmdP = new MySqlCommand("UPDATE leavedays SET totaldays=" + txtPaternity.Text + " WHERE leavedayID=3", msqlcon.con);

                MessageBox.Show("Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
            }
        }

        private void txtLeavePerMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtLeavePerYear.Text = (Convert.ToInt32(txtLeavePerMonth.Text) * 12).ToString();
            }
            catch
            {
                txtLeavePerYear.Text = "0";
            }
           
        }

        public void loadvalues()
        {
            CheckOpen.cons();
            DataTable dtV = new DataTable();
            MySqlDataAdapter daV = new MySqlDataAdapter("SELECT * FROM leavedays WHERE leavedayID=1", msqlcon.con);
            daV.Fill(dtV);
            txtLeavePerYear.Text = (dtV.Rows[0][2].ToString());
            try
            {
                txtLeavePerMonth.Text = ((int)dtV.Rows[0][2] / 12).ToString();
            }
            catch
            {
                txtLeavePerMonth.Text = "0";

            }
            

            DataTable dtM = new DataTable();
            MySqlDataAdapter daM = new MySqlDataAdapter("SELECT * FROM leavedays WHERE leavedayID=2", msqlcon.con);
            daM.Fill(dtM);
            txtMaternityLeave.Text = dtM.Rows[0][2].ToString();

            DataTable dtP = new DataTable();
            MySqlDataAdapter daP = new MySqlDataAdapter("SELECT * FROM leavedays WHERE leavedayID=3", msqlcon.con);
            daP.Fill(dtP);
           txtPaternity.Text = dtP.Rows[0][2].ToString();
        }

        private void frmLeaveDaysSettings_Load(object sender, EventArgs e)
        {
            loadvalues();
        }

        private void txtLeavePerMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtMaternityLeave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }
    }
}
