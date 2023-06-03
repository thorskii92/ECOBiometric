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
    public partial class frmLoading : MetroFramework.Forms.MetroForm
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            TimerLoad.Start();
        }

        private void TimerLoad_Tick(object sender, EventArgs e)
        {
            LoadingBar.Increment(2);
            lblLoading.Text = "Loading... " + LoadingBar.Value.ToString() + "%" ;
            if (LoadingBar.Value == 100)
            {
                TimerLoad.Stop();
                this.Hide();
            }
        }
    }
}
