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
    public partial class frmNewEditPosition : Form
    {
        private frmEmployeePositions m_Parent;
        public frmNewEditPosition(frmEmployeePositions frm1)
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
            CheckOpen.cons();
            if (this.Text == "New Position")
            {
                if (MessageBox.Show("Save Position?","Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO empposition(PositionName, BasicPay, SSS, Pagibig, PhilHealth, DailyRate) VALUES(@PosName, @BPay, @SS, @Pbig, @PHealth, @DRate)", msqlcon.con);
                    cmd.Parameters.AddWithValue("@PosName", txtPos.Text);
                    cmd.Parameters.AddWithValue("@BPay", txtBasic.Text);
                    cmd.Parameters.AddWithValue("@SS", txtSSS.Text);
                    cmd.Parameters.AddWithValue("@Pbig", txtPagibig.Text);
                    cmd.Parameters.AddWithValue("@PHealth", txtPhilHealth.Text);
                    cmd.Parameters.AddWithValue("@DRate", txtDailyRate.Text);
                    cmd.ExecuteNonQuery();
                    clear();
                    MessageBox.Show("Position Saved!", "Saved!");
                    this.Close();
                    m_Parent.loadpositions();

                }
            }
            else if (this.Text == "Edit Position")
            {
                if (MessageBox.Show("Save Changes to Position?","Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE empposition SET PositionName='" + txtPos.Text + "', BasicPay=" + txtBasic.Text + ", SSS=" + txtSSS.Text + ", PagIbig=" + txtPagibig.Text + ", PhilHealth=" + txtPhilHealth.Text + ", DailyRate=" + txtDailyRate.Text + " WHERE PositionID=" + StoreData.HoldEmpID, msqlcon.con);
                    cmd.ExecuteNonQuery();
                    clear();
                    MessageBox.Show("Saved", "Saved");
                    this.Close();
                    m_Parent.loadpositions();
                }
            }
            
        }

        public void clear()
        {
            txtBasic.Text = "";
            txtDailyRate.Text = "";
            txtPagibig.Text = "";
            txtPhilHealth.Text = "";
            txtPos.Text = "";
            txtSSS.Text = "";
        }

        private void frmNewEditPosition_Load(object sender, EventArgs e)
        {

        }

        private void txtPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtBasic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtSSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtPagibig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtPhilHealth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtDailyRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtBasic_TextChanged(object sender, EventArgs e)
        {
            if (txtBasic.Text == "")
            {
                txtBasic.Text = "0";
                txtDailyRate.Text = "0";
            }
            else
            {
                txtDailyRate.Text = Salary.DailyRate(Convert.ToDouble(txtBasic.Text)).ToString();
            }
            
        }


    }
}
