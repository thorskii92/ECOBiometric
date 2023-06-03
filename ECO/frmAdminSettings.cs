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
    public partial class frmAdminSettings : Form
    {
        public frmAdminSettings()
        {
            InitializeComponent();
        }

        private void btnEmpPos_Click(object sender, EventArgs e)
        {
            frmEmployeePositions empPos = new frmEmployeePositions();
            empPos.StartPosition = FormStartPosition.CenterScreen;
            empPos.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHolidaySettings adset = new frmHolidaySettings();
            adset.StartPosition = FormStartPosition.CenterScreen;
            adset.ShowDialog();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            frmFormula _Formula = new frmFormula();
            _Formula.StartPosition = FormStartPosition.CenterScreen;
            _Formula.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLeaveDaysSettings leavedays = new frmLeaveDaysSettings();
            leavedays.StartPosition = FormStartPosition.CenterScreen;
            leavedays.ShowDialog();
        }
    }
}
