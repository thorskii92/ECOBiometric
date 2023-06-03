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
    public partial class frmAddEdHoliday : Form
    {
        private frmHolidaySettings m_Parent;
        public frmAddEdHoliday(frmHolidaySettings frm1)
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
            if (txtHoliday.Text == "" || cboType.Text == "")
            {
                MessageBox.Show("Please Fill All Neccessary Data", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Save?","Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (this.Text == "New Holiday")
                    {
                        CheckOpen.cons();
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO holidays(holidayname, holidaytype, holidaydate) VALUES('" + txtHoliday.Text.Replace("'", "''") + "','" + cboType.Text + "','" + dtpDate.Value.ToString("yyyy-MM-dd") + "')", msqlcon.con);
                        cmd.ExecuteNonQuery();
                        m_Parent.loadholidaylist();
                        this.Close();
                    }
                    else
                    {
                        CheckOpen.cons();
                        MySqlCommand cmd = new MySqlCommand("UPDATE holidays SET holidayname='" + txtHoliday.Text.Replace("'", "''") + "', holidaytype='" + cboType.Text + "', holidaydate='" + dtpDate.Value.ToString("yyyy-MM-dd") + "' WHERE holidayID=" + StoreData.selectedHolID, msqlcon.con);
                        cmd.ExecuteNonQuery();
                        m_Parent.loadholidaylist();
                        this.Close();
                    }
                }
                
                
            }
        }

        private void txtHoliday_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }
    }
}
