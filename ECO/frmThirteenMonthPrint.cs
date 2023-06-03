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
    public partial class frmThirteenMonthPrint : Form
    {
        public frmThirteenMonthPrint()
        {
            InitializeComponent();
        }

        private void frmThirteenMonthPrint_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}
