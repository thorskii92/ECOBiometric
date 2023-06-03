using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECO
{
    public partial class frmSplash : MetroFramework.Forms.MetroForm
    {
        public frmSplash()
        {
       
            InitializeComponent();
        }
        private void ECOsplashcs_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void TimerLoad_Tick(object sender, EventArgs e)
        {
            LoadingBar.Increment(5);
            lblLoading.Text = "Loading... " + LoadingBar.Value.ToString() + "%";
            if (LoadingBar.Value == 100)
            {
                TimerLoad.Stop();
                frmLogin login = new frmLogin();
                login.Show();
                this.Hide();
            }

        }
    }
}
