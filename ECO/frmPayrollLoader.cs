using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECO
{
    public partial class frmPayrollLoader : Form
    {
        int maxdays;
        frmNewPayroll m_Parent;
        public frmPayrollLoader(frmNewPayroll frm1)
        {
            InitializeComponent();
            m_Parent = frm1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void loadyear()
        {
            cboYear.Items.Clear();
            for (int x = 2015; x <= DateTime.Now.Year; x++)
            {
                cboYear.Items.Add(x);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (cboMonth.Text == "" || cboYear.Text == "" || cboDays.Text == "")
            {
                MessageBox.Show("Please Select Dates","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int startd;
                int endd;
                if (cboDays.SelectedIndex == 0)
                {
                    startd = 1;
                    endd = 15;
                }
                else
                {
                    startd = 16;
                    endd = maxdays;
                }
                DateTime startdate = Convert.ToDateTime((cboYear.Text).ToString() + "-" + (cboMonth.SelectedIndex + 1) + "-" + startd);
                DateTime enddate = Convert.ToDateTime((cboYear.Text).ToString() + "-" + (cboMonth.SelectedIndex + 1) + "-" + endd);
                m_Parent.payrollload(startdate, enddate);
                this.Close();
            }
            
        }

        private void frmPayrollLoader_Load(object sender, EventArgs e)
        {
            loadyear();
        }

        public void loaddays(int year, int month)
        {
            cboDays.Items.Clear();
            maxdays = DateTime.DaysInMonth(year, month);
            cboDays.Items.Add("1 to 15");
            cboDays.Items.Add("16 to " + maxdays);
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lvwEmp.Items.Clear();
            try
            {
                loaddays(Convert.ToInt32(cboYear.Text), cboMonth.SelectedIndex + 1);
            }
            catch
            {
                cboDays.Items.Clear();
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lvwEmp.Items.Clear();
            try
            {
                loaddays(Convert.ToInt32(cboYear.Text), cboMonth.SelectedIndex + 1);
            }
            catch
            {
                cboDays.Items.Clear();
            }
        }
    }
}
